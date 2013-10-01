using System;
using System.Collections.ObjectModel;
using XonixGame.GameObjectsBase;

namespace XonixGame
{
    public interface IGameObjectCollection : IDisposable
    {
        ReadOnlyCollection<IGameObject> GameObjects { get; }

        ReadOnlyCollection<IUpdatable> UpdatableObjects { get; }

        ReadOnlyCollection<IDrawable> DrawableObjects { get; }

        ReadOnlyCollection<IInteractive> InteractiveObjects { get; }
        bool Enabled { get; set; }

        void Add(IInteractive gameObject);

        void Add(IDrawable gameObject);

        void Add(IGameObject gameObject);

        void Clear();
    }
}