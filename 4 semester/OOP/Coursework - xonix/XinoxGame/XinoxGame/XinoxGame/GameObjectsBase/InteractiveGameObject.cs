using System;
using SupportTypes;

namespace XonixGame.GameObjectsBase
{
    [Serializable]
    public abstract class InteractiveGameObject : DrawableGameObject, IInteractive
    {
        protected InteractiveGameObject(IGame game) : base(game)
        {
        }

        public abstract BoundingShape BoundingShape { get; }

        public virtual bool Intersects(IInteractive with)
        {
            return BoundingShape.Intersects(with.BoundingShape);
        }

        public virtual void Interact(IInteractive with)
        {
        }

        public virtual void Destroy()
        {
            Dispose();
        }
    }
}