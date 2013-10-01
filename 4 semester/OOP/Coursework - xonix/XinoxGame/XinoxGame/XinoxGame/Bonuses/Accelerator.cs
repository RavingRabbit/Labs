using System;
using Microsoft.Xna.Framework;
using SupportTypes;
using UtilLib;
using XonixGame.GameObjects;
using XonixGame.GameObjectsBase;

namespace XonixGame.Bonuses
{
    internal class Accelerator : Box, IBonus
    {
        private const float DefaultAcceleration = 2f;
        private static readonly TimeSpan BonusPeriod = TimeSpan.FromSeconds(5);
        private readonly float _acceleration;
        private readonly GameTimer _timer;
        private bool _improved;
        private IMoveable _improvedObject;

        public Accelerator(IGame game, Vector2 position)
            : this(game, position, DefaultAcceleration)
        {
        }

        public Accelerator(IGame game, Vector2 position, float acceleration)
            : base(game, game.ContentProvider.GetAcceleratorSprite(), position, 10)
        {
            Requires.Range(acceleration > 0, "acceleration");
            _acceleration = acceleration;
            _timer = new GameTimer(BonusPeriod);
        }

        public override void Interact(IInteractive with)
        {
            if (with is MainDevice)
            {
                Improve(with as MainDevice);
            }
            else
            {
                if (with is IEnemy)
                {
                    Destroy();
                }
            }
        }

        public override void Update(TimeSpan elapsed)
        {
            if (_improved && _timer.Update(elapsed))
            {
                Restore();
                Dispose();
            }
            base.Update(elapsed);
        }

        private void Improve(IMoveable moveable)
        {
            if (_improved)
                return;
            moveable.Velocity += _acceleration;
            _improvedObject = moveable;
            _improved = true;
            Game.GameObjectCollection.Add(new BubbleLabel(Game, "Accelerate!", CenterPosition));
            Visible = false;
        }

        private void Restore()
        {
            _improvedObject.Velocity -= _acceleration;
        }
    }
}