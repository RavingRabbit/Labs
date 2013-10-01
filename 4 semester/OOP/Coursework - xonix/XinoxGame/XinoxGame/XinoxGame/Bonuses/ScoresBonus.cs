using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using XonixGame.GameObjects;
using XonixGame.GameObjectsBase;

namespace XonixGame.Bonuses
{
    class ScoresBonus : Ball, IBonus
    {
        public ScoresBonus(IGame game, Vector2 position)
            : base(game, game.ContentProvider.GetScoresBonusSprite(), position)
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
            Game.GameObjectCollection.Add(new BubbleLabel(Game, "Scores!", CenterPosition));
            Game.Scores += 1000;
        }
    }
}
