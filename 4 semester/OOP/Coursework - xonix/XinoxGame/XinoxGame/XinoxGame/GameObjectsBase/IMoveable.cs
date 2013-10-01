using Microsoft.Xna.Framework;

namespace XonixGame.GameObjectsBase
{
    public interface IMoveable : IInteractive
    {
        bool Moving { get; }

        float Velocity { get; set; }

        void MoveTo(Vector2 target);

        void Stop();
    }
}