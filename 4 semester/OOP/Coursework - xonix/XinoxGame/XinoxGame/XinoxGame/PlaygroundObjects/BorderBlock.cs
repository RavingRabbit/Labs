using System;
using Microsoft.Xna.Framework;
using SupportTypes;
using XonixGame.GameObjectsBase;
using XonixGame.GameObjects;

namespace XonixGame.GameObjects
{
    [Serializable]
    internal class BorderBlock : PlaygroundBlock
    {
        public BorderBlock(Playground playground, Point point)
            : base(playground, point)
        {
        }

        public override void Interact(IInteractive with)
        {
            var moveable = with as IMoveable;
            if (moveable == null)
                return;
            if (moveable is MainDevice)
            {
                moveable.Stop();
            }
            /*else
            {
                //что-то другое
            }*/
        }

        protected override Sprite ProvideSprite()
        {
            return Game.ContentProvider.GetBorderBlockSprite(PositionOnPlayground, Game.Level.LevelNumber - 1);
        }
    }
}