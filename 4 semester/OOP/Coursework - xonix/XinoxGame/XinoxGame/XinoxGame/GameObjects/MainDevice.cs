using System;
using System.Linq;
using Microsoft.Xna.Framework;
using XonixGame.GameObjectsBase;
using XonixGame.GameObjects;

namespace XonixGame.GameObjects
{
    public class MainDevice : Ball, IFocusable
    {
        private bool _killed;
        private bool _onPath;

        public MainDevice(IGame game)
            : this(game, Vector2.Zero)
        {
        }

        public MainDevice(IGame game, Vector2 startPosition)
            : base(game, game.ContentProvider.GetMainDeviceSprite(), startPosition, 12)
        {
            Velocity = 4;
        }
        
        Vector2 IFocusable.Position
        {
            get { return CenterPosition; }
        }

        public override void Interact(IInteractive with)
        {
            if (with is Playground)
            {
                var playground = with as Playground;
                PlaygroundBlock block = playground.FindBlockContaining(CenterPosition);
                if (block is GroundBlock || block is FixedGroundBlock)
                {
                    Game.Level.Playground.UpdateGround(true);
                    _onPath = false;
                }
                if (block is WaterBlock)
                {
                    playground.ReplaceWithPath(block);
                    _onPath = true;
                }
                if (block is PathBlock)
                {
                    if (playground.Path.Count != 0)
                    {
                        PathBlock lastInPath = playground.Path.Last();
                        if (lastInPath != block)
                            Destroy();
                    }
                }
            }
        }

        public override void Update(TimeSpan elapsed)
        {
            if (_onPath)
                MoveTo(Position + Direction*Velocity);
            base.Update(elapsed);
        }

        public override void MoveTo(Vector2 target)
        {
            if (_onPath)
            {
                Vector2 direction = target - Position;
                direction.Normalize();
                if (direction == -Direction)
                    return;
            }
            base.MoveTo(target);
        }

        public override void Destroy()
        {
            if (_killed)
                return;
            _killed = true;
            var exploded = new ExplodedObject(this, 8, 12, 12, 4);
            Visible = false;
            Enabled = false;
            if (Game.Lifes == 0)
            {
                Game.GameObjectCollection.Add(exploded);
                Dispose();
                Game.RestartGame(LossReason.LastLifeSpent);
                Game.Level.Playground.UpdateGround(false);
                return;
            }
            TargetPosition = PreviousPosition = Position = Game.Level.Playground.StartPosition;
            exploded.Disposed += (sender, args) =>
                {
                    _killed = false;
                    Visible = true;
                    Enabled = true;
                    Stop();
                };
            Game.GameObjectCollection.Add(exploded);
            Game.Lifes--;
            Game.Level.Playground.UpdateGround(false);
        }
    }
}