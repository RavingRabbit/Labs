using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AudioPlayer
{
    internal class Player
    {
        private const int VisualizationPeriod = 5000;
        private Playlist _playlist;
        private readonly LinkedList<Track> _tracks = new LinkedList<Track>();
        private Track _currentTrack;
        private bool _playing;
        private bool _paused;
        private bool _stopped;
        private readonly AutoResetEvent _pauseSemaphore = new AutoResetEvent(false);
        private readonly AutoResetEvent _stopSemaphore = new AutoResetEvent(false);

        public bool Playing { get { return _playing; } }

        public bool Paused { get { return _paused; } }

        public Track CurrentTrack { get { return _currentTrack; } }

        public void LoadPlayList(Playlist playlist)
        {
            if (playlist == null)
                throw new ArgumentNullException("playlist");
            _playlist = playlist;
            foreach (var track in playlist)
            {
                _tracks.AddLast(track);
            }
        }

        /*
        public void RepeatPlayList()
        {
            if (!_playing)
            {
                LoadPlayList(_playlist);
                Play();
            }
        }
        */

        public void Play()
        {
            _stopped = false;
            if (_paused)
            {
                Resume();
                return;
            }
            if (_playing)
                throw new InvalidOperationException("Player busy.");
            if (_tracks.Count == 0)
                return;
            var track = _tracks.First();
            _tracks.RemoveFirst();
            if (track != null)
                PlayTrack(track);
        }

        private void PlayTrack(Track track)
        {
            _currentTrack = track;
            _playing = true;
            OnTrackPlayingStarted(new EventArgs<Track>(track));
            Task.Run(() => PlayAndVisualizeTrack(track));
        }

        private void PlayAndVisualizeTrack(Track track)
        {
            Timer timer = null;
            try
            {
                var i = 0;
                var numOfSteps = track.Duration.TotalMilliseconds/(VisualizationPeriod);
                timer = new Timer(state =>
                    {
                        if (_paused) _pauseSemaphore.WaitOne();
                        if (++i > numOfSteps || _stopped)
                            _stopSemaphore.Set();
                        else
                        {
                            Console.Beep();
                            //Console.Write('*');
                        }
                    }, null, 0, VisualizationPeriod);
                _stopSemaphore.WaitOne();
            }
            finally
            {
                if (timer != null)
                    timer.Dispose();
                _playing = false;
                OnTrackPlayingFinished(new EventArgs<Track>(track));
                if (!_stopped)
                    Play();
            }
        }

        public void Pause()
        {
            _paused = true;
        }

        public void Stop()
        {
            if (_stopped) return;
            _stopped = true;
            _playing = false;
            _tracks.AddFirst(_currentTrack); //возвращаем в очередь текущий трек
            _stopSemaphore.Set();
        }

        private void Resume()
        {
            if (!_paused) return;
            _paused = false;
            _pauseSemaphore.Set();
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
            var handler = TrackPlayingFinished;
            if (handler != null) handler(this, e);
        }
    }
}
