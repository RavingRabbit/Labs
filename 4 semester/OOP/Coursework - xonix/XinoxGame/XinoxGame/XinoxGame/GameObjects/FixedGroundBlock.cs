using System;
using Microsoft.Xna.Framework;
using SupportTypes;
using XonixGame.GameObjectsBase;
using XonixGame.GameObjects;

namespace XonixGame.GameObjects
{
    [Serializable]
    internal class FixedGroundBlock : PlaygroundBlock
    {
        public FixedGroundBlock(Playground playground, Point point)
            : base(playground, point)
        {
        }

        public override void Interact(IInteractive with)
        {
            //nothing
        }

        protected override Sprite ProvideSprite()
        {
            return Game.ContentProvider.GetGroundBlockSprite(PositionOnPlayground, Game.Level.LevelNumber - 1);
        }
    }
}