using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SupportTypes;
using XonixGame.GameObjectsBase;

namespace XonixGame.GameObjects
{
    internal class Background : DrawableGameObject
    {
        private readonly Sprite _sprite;

        public Background(IGame game) : base(game)
        {
            _sprite = game.ContentProvider.GetBackgroundSprite(0);
        }

        public override Vector2 Position
        {
            get { return new Vector2(float.MinValue/2, float.MinValue/2); }
            set { throw new NotSupportedException(); }
        }

        public override float Width
        {
            get { return float.MaxValue; }
        }

        public override float Height
        {
            get { return float.MaxValue; }
        }

        public override void Update(TimeSpan elapsed)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = -10; i < 15; i++)
            {
                for (int j = -10; j < 15; j++)
                {
                    _sprite.Position = new Vector2(_sprite.Width*i, _sprite.Height*j);
                    if (Game.Camera.IsInView(_sprite.Position, _sprite.Width + 50, _sprite.Height + 50))
                        _sprite.Draw(spriteBatch);
                }
            }
        }
    }
}