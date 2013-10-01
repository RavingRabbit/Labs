using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SupportTypes;
using XonixGame.GameObjectsBase;

namespace XonixGame.GameObjects
{
    internal class ExplodedObject : DrawableGameObject
    {
        private const int PeaceWidth = 8;
        private ExplodedSprite _sprite;

        public ExplodedObject(ISpriteBased obj) : base(obj.Game)
        {
            int colCount = Game.Random.Next((int) obj.Width/PeaceWidth, (int) obj.Width/PeaceWidth + 4);
            int rowCount = Game.Random.Next((int) obj.Height/PeaceWidth, (int) obj.Height/PeaceWidth + 4);
            Init(obj.Sprite, obj.CenterPosition, PeaceWidth, colCount, rowCount);
        }

        public ExplodedObject(ISpriteBased obj, int peaceWidth, int colCount, int rowCount, int rand)
            : base(obj.Game)
        {
            Init(obj.Sprite, obj.CenterPosition, peaceWidth, colCount + Game.Random.Next(-rand, rand),
                 rowCount + Game.Random.Next(-rand, rand));
        }

        public override Vector2 Position
        {
            get { return _sprite.Position; }
            set { _sprite.Position = value; }
        }

        public override float Width
        {
            get { return _sprite.Width; }
        }

        public override float Height
        {
            get { return _sprite.Height; }
        }

        private void Init(Sprite sprite, Vector2 position, int peaceWidth, int colCount, int rowCount)
        {
            _sprite = new ExplodedSprite(sprite, position, colCount, rowCount, peaceWidth);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }

        public override void Update(TimeSpan elapsed)
        {
            _sprite.Update(elapsed);
            if (_sprite.Finished)
            {
                Dispose();
                return;
            }
            base.Update(elapsed);
        }
    }
}