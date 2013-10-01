using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SupportTypes
{
    public abstract class Sprite
    {
        private readonly Texture2D _texture;

        protected Sprite(Texture2D texture)
            : this(texture, Vector2.Zero)
        {
        }

        protected Sprite(Texture2D texture, Vector2 position)
        {
            if (texture == null)
                throw new ArgumentNullException("texture");
            _texture = texture;
            Position = position;
        }

        internal virtual Rectangle Rectangle
        {
            get { return new Rectangle(0, 0, (int) Width, (int) Height); }
        }

        public Vector2 Position { get; set; }

        public abstract float Width { get; }

        public abstract float Height { get; }

        internal Texture2D Texture
        {
            get { return _texture; }
        }

        public abstract void Draw(SpriteBatch spriteBatch);

        public virtual void Update(TimeSpan elapsed)
        {
        }
    }
}