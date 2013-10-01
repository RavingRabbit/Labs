using System;
using Microsoft.Xna.Framework;
using SupportTypes;
using XonixGame.GameObjectsBase;
using XonixGame.GameObjects;

namespace XonixGame.GameObjects
{
    [Serializable]
    public class PathBlock : PlaygroundBlock
    {
        public PathBlock(Playground playground, Point point)
            : base(playground, point)
        {
        }

        public override void Interact(IInteractive with)
        {
            if (with is IEnemy && ((IEnemy) with).CanWalkOnWater)
                Game.Level.Playground.StartDeadPath(this);
        }

        protected override Sprite ProvideSprite()
        {
            return Game.ContentProvider.GetPathBlockSprite(PositionOnPlayground);
        }
    }
}