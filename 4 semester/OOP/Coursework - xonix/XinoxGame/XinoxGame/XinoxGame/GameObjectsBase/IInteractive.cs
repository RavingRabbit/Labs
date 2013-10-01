using SupportTypes;

namespace XonixGame.GameObjectsBase
{
    public interface IInteractive : IDrawable
    {
        BoundingShape BoundingShape { get; }

        bool Intersects(IInteractive with);

        void Interact(IInteractive with);

        void Destroy();
    }
}