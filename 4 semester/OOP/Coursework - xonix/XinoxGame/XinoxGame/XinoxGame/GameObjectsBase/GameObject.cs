using System;
using System.Runtime.Serialization;
using UtilLib;

namespace XonixGame.GameObjectsBase
{
    [Serializable]
    public abstract class GameObject : IGameObject
    {
        protected bool IsDisposed;
        private bool _enabled = true;
        [NonSerialized] private IGame _game;

        protected GameObject(IGame game)
        {
            Requires.NotNull(game, "game");
            _game = game;
        }


        public IGame Game
        {
            get { return _game; }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (_enabled == value) return;
                _enabled = value;
                OnEnabledChanged();
            }
        }

        public event EventHandler EnabledChanged;

        public event EventHandler Disposed;

        public virtual void Update(TimeSpan elapsed)
        {
        }

        public void Dispose()
        {
            if (IsDisposed)
                return;
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            _game = context.Context as IGame;
        }

        protected virtual void OnEnabledChanged()
        {
            EventHandler handler = EnabledChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnDisposed()
        {
            EventHandler handler = Disposed;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void Dispose(bool disposing)
        {
            IsDisposed = true;
            if (disposing)
                OnDisposed();
        }
    }
}