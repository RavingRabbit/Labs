using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SupportTypes;
using XonixGame.GameObjectsBase;

namespace XonixGame.GameObjects
{
    internal class Explosion : DrawableGameObject
    {
        private readonly AnimatedSprite _sprite;

        public Explosion(IGame game, Vector2 centerPosition)
            : base(game)
        {
            _sprite = (AnimatedSprite) game.ContentProvider.GetExplosionSprite(0);
            _sprite.Position = centerPosition - new Vector2(_sprite.Height/2, _sprite.Width/2);
        }

        public override Vector2 Position
        {
            get { return _sprite.Position; }
            set { _sprite.Position = value; }
        }

        public override sealed float Width
        {
            get { return _sprite.Width; }
        }

        public override sealed float Height
        {
            get { return _sprite.Height; }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
        }

        public override void Update(TimeSpan elapsed)
        {
            if (_sprite.Repeated)
            {
                Dispose();
                return;
            }
            _sprite.Update(elapsed);
        }
    }
}