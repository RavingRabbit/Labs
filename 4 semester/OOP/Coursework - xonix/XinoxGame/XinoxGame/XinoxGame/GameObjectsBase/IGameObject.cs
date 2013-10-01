using System;

namespace XonixGame.GameObjectsBase
{
    public interface IGameObject : IUpdatable, IDisposable
    {
        IGame Game { get; }

        event EventHandler Disposed;
    }
}