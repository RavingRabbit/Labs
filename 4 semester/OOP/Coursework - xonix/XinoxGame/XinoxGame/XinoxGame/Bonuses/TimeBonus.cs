using System;
using Microsoft.Xna.Framework;
using XonixGame.GameObjects;
using XonixGame.GameObjectsBase;

namespace XonixGame.Bonuses
{
    internal class TimeBonus : Ball, IBonus
    {
        private static readonly TimeSpan AdditionalTime = TimeSpan.FromSeconds(15);

        public TimeBonus(IGame game, Vector2 position)
            : base(game, game.ContentProvider.GetTimeBonusSprite(), position)
        {
        }

        public override void Interact(IInteractive with)
        {
            if (with is MainDevice)
            {
                Improve();
                Dispose();
            }
            else
            {
                if (with is IEnemy)
                {
                    Destroy();
                }
            }
        }

        private void Improve()
        {
            Game.GameObjectCollection.Add(new BubbleLabel(Game, "Time!", CenterPosition));
            Game.AddTime(AdditionalTime);
        }
    }
}