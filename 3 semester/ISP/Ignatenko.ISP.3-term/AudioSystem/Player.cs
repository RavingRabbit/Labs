using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AudioPlayer;
using AudioSystem.PlayerStates;

namespace AudioSystem
{
    internal class Player : IDisposable
    {
        private const int VisualizationPeriod = 5000;
        private Playlist _playlist;
        private readonly LinkedList<Track> _tracks = new LinkedList<Track>();
        private Track _currentTrack;
        private readonly int _id = KeyGenerator.Instance.GetKey();
        private readonly Stack<Track> _playedTracks = new Stack<Track>(); 
        private readonly ManualResetEvent _pauseSemaphore = new ManualResetEvent(true);
        private CancellationTokenSource _cancellationTokenSource;
        private PlayerState _state = new StoppedPlayerState();

        public bool Playing
        {
            get { return _state is PlayingPlayerState; }
        }

        public bool Stopped
        {
            get { return _state is StoppedPlayerState; }
        }

        public bool Paused
        {
            get { return _state is PausedPlayerState; }
        }

        public Track CurrentTrack
        {
            get { return !Stopped ? _currentTrack : null; }
        }

        public void LoadPlayList(Playlist playlist)
        {
            if (playlist == null)
                throw new ArgumentNullException("playlist");
            _playlist = playlist;
            _tracks.Clear();
            foreach (var track in playlist)
            {
                _tracks.AddLast(track);
            }
        }

        public void RepeatPlayList()
        {
            Stop();
            _playedTracks.Clear();
            LoadPlayList(_playlist);
            Play();
        }

        public void NextTrack()
        {
            if (_tracks.Count == 0)
                return;
            Stop();
            var track = _tracks.First();
            _tracks.RemoveFirst();
            _playedTracks.Push(track);
            Play();
        }

        public void PreviousTrack()
        {
            if (_playedTracks.Count == 0)
                return;
            Stop();
            var track = _playedTracks.Pop();
            _tracks.AddFirst(track);
            Play();
        }

        public void Play()
        {
            _state.Play(this);
        }

        internal void InternalPlay()
        {
            if (_tracks.Count == 0)
                return;
            var track = _tracks.First();
            _tracks.RemoveFirst();
            _playedTracks.Push(track);
            if (track != null)
                PlayTrack(track);
        }

        private void PlayTrack(Track track)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _currentTrack = track;
            OnTrackPlayingStarted(new EventArgs<Track>(track));
            var task = new Task(() => PlayAndVisualizeTrack(track), _cancellationTokenSource.Token);
            task.Start();
        }

        private void PlayAndVisualizeTrack(Track track)
        {
            try
            {
                var numOfSteps = track.Duration.TotalMilliseconds/(VisualizationPeriod);
                for (int i = 0; i < numOfSteps; i++)
                {
                    if (_cancellationTokenSource.IsCancellationRequested)
                        return;
                    _pauseSemaphore.WaitOne();
                    Console.Beep();
                    Console.Title = "*" + _id + "*" + _currentTrack.Title + "*" + i;
                    Thread.Sleep(VisualizationPeriod);
                }
            }
            finally
            {
                OnTrackPlayingFinished(new EventArgs<Track>(track));
            }
        }
        
        public void Pause()
        {
            _state.Pause(this);
        }

        internal void InternalPause()
        {
            _pauseSemaphore.Reset();
        }

        public void Stop()
        {
            _state.Stop(this);
        }

        internal void InternalStop()
        {
            _cancellationTokenSource.Cancel();
            _tracks.AddFirst(_currentTrack); //возвращаем в очередь текущий трек
        }

        internal void InternalResume()
        {
            _pauseSemaphore.Set();
        }

        internal void SetState(PlayerState state)
        {
            _state = state;
        }

        public event EventHandler<EventArgs<Track>> TrackPlayingStarter;

        protected virtual void OnTrackPlayingStarted(EventArgs<Track> e)
        {
            var handler = TrackPlayingStarter;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<EventArgs<Track>> TrackPlayingFinished;

        protected virtual void OnTrackPlayingFinished(EventArgs<Track> e)
        {
            if (!Stopped)
                InternalPlay();
            var handler = TrackPlayingFinished;
            if (handler != null) handler(this, e);
        }

        private bool _disposed;

        ~Player()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            Stop();
            if (disposing)
            {
                _pauseSemaphore.Dispose();
                _cancellationTokenSource.Dispose();
            }
            _disposed = true;
        }
    }
}
