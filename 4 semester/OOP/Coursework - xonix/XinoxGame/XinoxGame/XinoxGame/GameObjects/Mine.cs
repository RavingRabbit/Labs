using System;
using Microsoft.Xna.Framework;
using XonixGame.GameObjectsBase;
using XonixGame.GameObjects;

namespace XonixGame.GameObjects
{
    internal sealed class Mine : Ball, IEnemy
    {
        public Mine(IGame game)
            : this(game, Vector2.Zero)
        {
        }

        public Mine(IGame game, Vector2 position)
            : base(game, game.ContentProvider.GetMineSprite(), position, 3)
        {
            var target = new Vector2(Game.Random.Next(), Game.Random.Next());
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
            {
                Destroy();
                Game.PlayerDevice.Destroy();
            }
            if (with is PlaygroundBlock)
            {
                if (Reflected)
                    return;
                if (with is WaterBlock || with is BorderBlock || with is PathBlock)
                {
                    //Stop();
                    Vector2 newDirection = Vector2.Reflect(Direction,
                                                           (with as PlaygroundBlock).GetNormal(this));
                    Vector2 target = newDirection*10000;
                    MoveTo(target);
                    Reflected = true;
                }
            }
            base.Interact(with);
        }

        public bool CanWalkOnLand
        {
            get { return true; }
        }

        public bool CanWalkOnWater
        {
            get { return false; }
        }

        public override void Destroy()
        {
            Game.GameObjectCollection.Add(new Explosion(Game, Position));
            base.Destroy();
        }
    }
}