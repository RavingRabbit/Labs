using System;
using Microsoft.Xna.Framework;
using SupportTypes;
using XonixGame.GameObjects;

namespace XonixGame.GameObjects
{
    [Serializable]
    internal class WaterBlock : PlaygroundBlock
    {
        public WaterBlock(Playground playground, Point point)
            : base(playground, point)
        {
        }

        protected override Sprite ProvideSprite()
        {
            return Game.ContentProvider.GetWaterBlockSprite(PositionOnPlayground,
                                                            Game.Level.LevelNumber - 1);
        }
    }
}