using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SupportTypes
{
    public sealed class StaticSprite : Sprite
    {
        private readonly Rectangle? _rectangle;

        public StaticSprite(Texture2D texture)
            : base(texture)
        {
            _rectangle = null;
        }

        public StaticSprite(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
            _rectangle = null;
        }

        public StaticSprite(Texture2D texture, Vector2 position, Rectangle rectangle)
            : base(texture, position)
        {
            _rectangle = rectangle;
        }

        internal override Rectangle Rectangle
        {
            get { return _rectangle.HasValue ? _rectangle.Value : base.Rectangle; }
        }

        public override float Width
        {
            get { return Texture.Width; }
        }

        public override float Height
        {
            get { return Texture.Height; }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position.Rounded(), _rectangle, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, float angle, Vector2 origin, float scale)
        {
            spriteBatch.Draw(Texture, Position.Rounded(), _rectangle, Color.White, angle, origin, scale,
                             SpriteEffects.None, 0f);
        }
    }
}