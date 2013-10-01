using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SupportTypes;
using UtilLib;
using XonixGame.GameObjects;

namespace XonixGame.GameObjectsBase
{
    public class Ball : MoveableGameObject, ISpriteBased
    {
        private readonly BoundingCircle _boundingCircle = new BoundingCircle();
        private readonly float _margin;
        private readonly float _radius;
        private readonly Sprite _sprite;

        public Ball(IGame game, Sprite sprite, Vector2 startCenterPosition, float margin = 0)
            : base(game)
        {
            Requires.NotNull(sprite, "sprite");
            _sprite = sprite;
            _boundingCircle.Radius = _radius = (sprite.Height + sprite.Width)/4 - margin;
            _margin = margin;
            CenterPosition = startCenterPosition;
            UpdateBoundingShapePosition();
        }

        public bool Reflected { get; set; }

        public override BoundingShape BoundingShape
        {
            get { return _boundingCircle; }
        }

        Sprite ISpriteBased.Sprite
        {
            get { return _sprite; }
        }

        public override sealed Vector2 Position
        {
            get { return _sprite.Position; }
            set
            {
                _sprite.Position = value;
                UpdateBoundingShapePosition();
            }
        }

        public override sealed Vector2 CenterPosition
        {
            get { return Position + new Vector2(_radius + _margin); }
            set { Position = value - new Vector2(_radius + _margin); }
        }

        public override sealed float Width
        {
            get { return _radius*2; }
        }

        public override sealed float Height
        {
            get { return _radius*2; }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
        }

        public override void Update(TimeSpan elapsed)
        {
            _sprite.Update(elapsed);
            base.Update(elapsed);
        }

        private void UpdateBoundingShapePosition()
        {
            _boundingCircle.Center = CenterPosition;
        }

        public override void Interact(IInteractive with)
        {
            if (Reflected)
                return;
            if (with is Ball && !(with is IBonus))
            {
                var ball = with as Ball;
                Vector2 penetrationDirection = (CenterPosition - ball.CenterPosition);
                penetrationDirection.Normalize();
                Stop();
                MoveTo(penetrationDirection*1000);
                ball.Stop();
                ball.MoveTo(-penetrationDirection*1000);
                //Reflected = true;
                //ball.Reflected = true;
            }
        }

        public override void Destroy()
        {
            Game.GameObjectCollection.Add(new ExplodedObject(this));
            base.Destroy();
        }
    }
}