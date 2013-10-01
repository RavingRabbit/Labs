using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using UtilLib;
using XonixGame.GameObjectsBase;

namespace XonixGame
{
    public sealed class GameObjectCollection : IGameObjectCollection
    {
        private const int MaxCollectionSize = 10000;
        private readonly List<IDrawable> _drawableObjects;
        private readonly IGame _game;
        private readonly List<IGameObject> _gameObjects;
        private readonly List<IInteractive> _interactiveObjects;
        private readonly IInteractive[] _interactiveObjectsBuffer;
        private readonly List<IUpdatable> _updatableObjects;
        private readonly IUpdatable[] _updatableObjectsBuffer;
        private readonly float[] _yMinusRadiusArray;
        private readonly float[] _yPlusRadiusArray;
        private bool _disposed;
        private bool _enabled = true;

        public GameObjectCollection(IGame game)
            : this(game, MaxCollectionSize)
        {
        }

        public GameObjectCollection(IGame game, int maxCollectionSize)
        {
            Requires.Range(maxCollectionSize > 0, "maxCollectionSize");
            _game = game;
            _drawableObjects = new List<IDrawable>(maxCollectionSize);
            _gameObjects = new List<IGameObject>(maxCollectionSize);
            _interactiveObjects = new List<IInteractive>(maxCollectionSize);
            _interactiveObjectsBuffer = new IInteractive[maxCollectionSize];
            _updatableObjectsBuffer = new IUpdatable[maxCollectionSize];
            _updatableObjects = new List<IUpdatable>(maxCollectionSize);
            _yMinusRadiusArray = new float[maxCollectionSize];
            _yPlusRadiusArray = new float[maxCollectionSize];
        }


        public ReadOnlyCollection<IGameObject> GameObjects
        {
            get { return _gameObjects.AsReadOnly(); }
        }

        public ReadOnlyCollection<IUpdatable> UpdatableObjects
        {
            get { return _updatableObjects.AsReadOnly(); }
        }

        public ReadOnlyCollection<IDrawable> DrawableObjects
        {
            get { return _drawableObjects.AsReadOnly(); }
        }

        public ReadOnlyCollection<IInteractive> InteractiveObjects
        {
            get { return _interactiveObjects.AsReadOnly(); }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public void Dispose()
        {
            if (_disposed)
                return;
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Add(IInteractive gameObject)
        {
            Requires.NotNull(gameObject, "gameObject");
            Add(gameObject as IDrawable);
            AddInteractive(gameObject);
        }

        public void Add(IDrawable gameObject)
        {
            Requires.NotNull(gameObject, "gameObject");
            Add(gameObject as IGameObject);
            AddDrawable(gameObject);
        }

        public void Add(IGameObject gameObject)
        {
            Requires.NotNull(gameObject, "gameObject");
            AddGameObject(gameObject);
            AddUpdatable(gameObject);
        }

        public void Clear()
        {
            _gameObjects.Clear();
            _drawableObjects.Clear();
            _updatableObjects.Clear();
            _interactiveObjects.Clear();
        }

        private void AddGameObject(IGameObject gameObject, bool subscribe = true)
        {
            if (subscribe)
                gameObject.Disposed += OnGameObjectDisposed;
            _gameObjects.Add(gameObject);
        }

        private void AddUpdatable(IUpdatable gameObject, bool subscribe = true)
        {
            if (subscribe)
                gameObject.EnabledChanged += OnEnabledChanged;
            _updatableObjects.Add(gameObject);
        }

        private void AddDrawable(IDrawable gameObject, bool subscribe = true)
        {
            if (subscribe)
                gameObject.VisibleChanged += OnVisibleChanged;
            _drawableObjects.Add(gameObject);
        }

        private void AddInteractive(IInteractive gameObject)
        {
            _interactiveObjects.Add(gameObject);
        }

        private void RemoveGameObject(IGameObject gameObject, bool unSubscribe = true)
        {
            if (unSubscribe)
                gameObject.Disposed -= OnGameObjectDisposed;
            _gameObjects.Remove(gameObject);
        }

        private void RemoveUpdatable(IUpdatable gameObject, bool unSubscribe = true)
        {
            if (unSubscribe)
                gameObject.EnabledChanged -= OnEnabledChanged;
            _updatableObjects.Remove(gameObject);
        }

        private void RemoveDrawable(IDrawable gameObject, bool unSubscribe = true)
        {
            if (unSubscribe)
                gameObject.VisibleChanged -= OnVisibleChanged;
            _drawableObjects.Remove(gameObject);
        }

        private void RemoveInteractive(IInteractive gameObject)
        {
            _interactiveObjects.Remove(gameObject);
        }

        private void OnEnabledChanged(object sender, EventArgs args)
        {
            var updatable = sender as IUpdatable;
            if (updatable != null)
                OnEnabledChanged(updatable);
        }

        private void OnEnabledChanged(IUpdatable updatable)
        {
            if (updatable.Enabled)
            {
                AddUpdatable(updatable, false);
            }
            else
            {
                RemoveUpdatable(updatable, false);
            }
        }

        private void OnVisibleChanged(object sender, EventArgs args)
        {
            var drawable = sender as IDrawable;
            if (drawable != null)
                OnVisibleChanged(drawable);
        }

        private void OnVisibleChanged(IDrawable drawable)
        {
            if (drawable.Visible)
            {
                AddDrawable(drawable, false);
                if (drawable is IInteractive)
                    AddInteractive(drawable as IInteractive);
            }
            else
            {
                RemoveDrawable(drawable, false);
                if (drawable is IInteractive)
                    RemoveInteractive(drawable as IInteractive);
            }
        }

        private void OnGameObjectDisposed(object sender, EventArgs args)
        {
            var gameObject = sender as IGameObject;
            if (gameObject != null)
                OnGameObjectDisposed(gameObject);
        }

        private void OnGameObjectDisposed(IGameObject gameObject)
        {
            RemoveGameObject(gameObject);
            RemoveUpdatable(gameObject);
            var drawable = gameObject as IDrawable;
            if (drawable != null)
                RemoveDrawable(drawable);
            var interactive = gameObject as IInteractive;
            if (interactive != null)
                RemoveInteractive(interactive);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IDrawable drawable in _drawableObjects)
            {
                if (_game.Camera.IsInView(drawable))
                    drawable.Draw(spriteBatch);
            }
        }

        public void Update(TimeSpan elapsed)
        {
            if (!_enabled) return;
            _updatableObjects.CopyTo(_updatableObjectsBuffer);
            int updatableObjectsNumber = _updatableObjects.Count;
            for (int i = 0; i < updatableObjectsNumber; i++)
            {
                _updatableObjectsBuffer[i].Update(elapsed);
            }
            UpdateInteractiveObjects();
        }

        private void UpdateInteractiveObjects()
        {
            _interactiveObjects.Sort(InteractiveComparer.Instance);
            _interactiveObjects.CopyTo(_interactiveObjectsBuffer);
            int interactiveObjectsNumber = _interactiveObjects.Count;
            float[] yPlusRadius = YPlusRadius(_interactiveObjectsBuffer, interactiveObjectsNumber);
            float[] yMinusRadius = YMinusRadius(_interactiveObjectsBuffer, interactiveObjectsNumber);
            for (int i = 0; i < interactiveObjectsNumber; ++i)
            {
                IInteractive interactive1 = _interactiveObjectsBuffer[i];
                float y1AxisLengths = yPlusRadius[i];
                for (int j = i + 1; j < interactiveObjectsNumber && y1AxisLengths > yMinusRadius[j]; ++j)
                {
                    IInteractive interactive2 = _interactiveObjectsBuffer[j];
                    if (!interactive1.Intersects(interactive2)) continue;
                    interactive1.Interact(interactive2);
                    interactive2.Interact(interactive1);
                }
            }
        }

        private float[] YPlusRadius(IInteractive[] interactiveObjects, int length)
        {
            for (int i = 0; i < length; i++)
            {
                _yPlusRadiusArray[i] = interactiveObjects[i].Position.Y +
                                       interactiveObjects[i].BoundingShape.RadiusLength;
            }
            return _yPlusRadiusArray;
        }

        private float[] YMinusRadius(IInteractive[] interactiveObjects, int length)
        {
            for (int i = 0; i < length; i++)
            {
                _yMinusRadiusArray[i] = interactiveObjects[i].Position.Y -
                                        interactiveObjects[i].BoundingShape.RadiusLength;
            }
            return _yMinusRadiusArray;
        }

        ~GameObjectCollection()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (IGameObject gameObject in GameObjects)
                {
                    gameObject.Dispose();
                }
            }
            _disposed = true;
        }

        private sealed class InteractiveComparer : Comparer<IInteractive>
        {
            public static readonly InteractiveComparer Instance = new InteractiveComparer();

            public override int Compare(IInteractive x, IInteractive y)
            {
                Debug.Assert(x != null, "x != null");
                Debug.Assert(y != null, "y != null");
// ReSharper disable PossibleNullReferenceException
                return (int) (x.Position.Y - y.Position.Y);
// ReSharper restore PossibleNullReferenceException
            }
        }
    }
}