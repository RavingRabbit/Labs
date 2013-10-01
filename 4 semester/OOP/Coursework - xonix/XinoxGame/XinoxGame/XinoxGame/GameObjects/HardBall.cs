using System;
using Microsoft.Xna.Framework;
using XonixGame.GameObjectsBase;
using XonixGame.GameObjects;

namespace XonixGame.GameObjects
{
    internal sealed class HardBall : Ball, IEnemy
    {
        public HardBall(IGame game)
            : this(game, Vector2.Zero)
        {
        }

        public HardBall(IGame game, Vector2 position)
            : base(game, game.ContentProvider.GetBallSprite(0), position, 5)
        {
            Velocity = 2;
            var target = new Vector2(Game.Random.Next() - Game.Random.Next(), Game.Random.Next() - Game.Random.Next());
            MoveTo(target);
        }

        public override void Update(TimeSpan elapsed)
        {
            if (Reflected)
                Move();
            Reflected = false;
            base.Update(elapsed);
        }

        public override void Interact(IInteractive with)
        {
            if (with is MainDevice)
                Game.PlayerDevice.Destroy();
            if (Reflected)
                return;
            if (with is PlaygroundBlock && !(with is WaterBlock))
            {
                //Stop();
                Vector2 newDirection = Vector2.Reflect(Direction, (with as PlaygroundBlock).GetNormal(this));
                Vector2 target = newDirection*10000;
                MoveTo(target);
                Reflected = true;
            }
            base.Interact(with);
        }

        public bool CanWalkOnLand
        {
            get { return false; }
        }

        public bool CanWalkOnWater
        {
            get { return true; }
        }
    }
}