using System;
using Microsoft.Xna.Framework;
using SupportTypes;
using XonixGame.GameObjectsBase;
using XonixGame.GameObjects;

namespace XonixGame.GameObjects
{
    [Serializable]
    internal class GroundBlock : PlaygroundBlock
    {
        public GroundBlock(Playground playground, Point point)
            : base(playground, point)
        {
        }

        public override void Interact(IInteractive with)
        {
            if (with is HardBall)
                Playground.ReplaceWithWater(this);
        }

        protected override Sprite ProvideSprite()
        {
            return Game.ContentProvider.GetGroundBlockSprite(PositionOnPlayground, Game.Level.LevelNumber - 1);
        }
    }
}