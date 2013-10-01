using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SupportTypes;
using XonixGame.GameObjects;

namespace XonixGame.GameObjectsBase
{
    internal class Box : MoveableGameObject, ISpriteBased
    {
        private readonly BoundingRectangle _boundingRectangle = new BoundingRectangle();
        private readonly float _height;
        private readonly float _margin;
        private readonly Sprite _sprite;
        private readonly float _width;

        public Box(IGame game, Sprite sprite, Vector2 startPosition, float margin = 0)
            : base(game)
        {
            _sprite = sprite;
            _margin = margin;
            _boundingRectangle.Width = _width = sprite.Width - margin;
            _boundingRectangle.Height = _height = sprite.Height - margin;
            Position = startPosition;
        }

        public override BoundingShape BoundingShape
        {
            get { return _boundingRectangle; }
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

        public override Vector2 CenterPosition
        {
            get { return Position + new Vector2(Width/2 + _margin, Height/2 + _margin); }
            set { Position = value - new Vector2(Width/2 + _margin, Height/2 + _margin); }
        }

        public override sealed float Width
        {
            get { return _width; }
        }

        public override sealed float Height
        {
            get { return _height; }
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
            _boundingRectangle.Position = Position + new Vector2(_margin);
        }

        public override void Destroy()
        {
            Game.GameObjectCollection.Add(new ExplodedObject(this));
            base.Destroy();
        }
    }
}