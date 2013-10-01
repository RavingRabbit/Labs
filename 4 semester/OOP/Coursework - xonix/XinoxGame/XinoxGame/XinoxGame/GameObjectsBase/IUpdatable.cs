using System;

namespace XonixGame.GameObjectsBase
{
    public interface IUpdatable
    {
        bool Enabled { get; set; }

        event EventHandler EnabledChanged;

        void Update(TimeSpan elapsed);
    }
}