using Microsoft.Xna.Framework;
using XonixGame.GameObjects;
using XonixGame.GameObjectsBase;

namespace XonixGame.Bonuses
{
    internal class LifeBonus : Box, IBonus
    {
        public LifeBonus(IGame game, Vector2 position)
            : base(game, game.ContentProvider.GetLifeBonusSprite(), position)
        {
        }

        public override void Interact(IInteractive with)
        {
            if (with is MainDevice)
            {
                Improve(with as MainDevice);
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

        private void Improve(MainDevice mainDevice)
        {
            Game.GameObjectCollection.Add(new BubbleLabel(Game, "Life!", CenterPosition));
            Game.Lifes++;
        }
    }
}