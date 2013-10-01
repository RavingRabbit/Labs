using System;
using XonixGame.GameObjects;

namespace XonixGame
{
    public interface IGame
    {
        IGameObjectCollection GameObjectCollection { get; }

        IContentProvider ContentProvider { get; }

        ICamera2D Camera { get; }

        Random Random { get; }

        Level Level { get; }

        MainDevice PlayerDevice { get; }

        TimeSpan TimeLeft { get; }

        int Scores { get; set; }

        int Lifes { get; set; }

        bool Completed { get; }

        void RestartGame(LossReason lossReason);

        void AddTime(TimeSpan time);
    }
}