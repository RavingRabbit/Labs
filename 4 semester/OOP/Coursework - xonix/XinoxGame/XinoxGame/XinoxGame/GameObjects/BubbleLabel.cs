using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XonixGame.GameObjectsBase;

namespace XonixGame.GameObjects
{
    internal class BubbleLabel : DrawableGameObject
    {
        private readonly SpriteFont _font;
        private readonly string _label;
        private string _currentLabel;
        private Vector2 _position;
        private int _updates;

        public BubbleLabel(IGame game, string label, Vector2 position) : base(game)
        {
            _label = label;
            _font = game.ContentProvider.GetFont(3);
            _position = new Vector2(position.X - Width/2, position.Y - Height/2);
            _currentLabel = new string(' ', _label.Length);
        }

        public override Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public override sealed float Width
        {
            get { return _font.MeasureString(_label).X; }
        }

        public override sealed float Height
        {
            get { return _font.MeasureString(_label).Y; }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, _currentLabel, _position, Color.White);
        }

        public override void Update(TimeSpan elapsed)
        {
            _updates++;
            if (_updates/4 == _label.Length + 15)
            {
                Dispose();
                return;
            }
            int length = _updates/4;
            if (length > _label.Length)
                length = _label.Length;
            _currentLabel = _label.Substring(0, length);
        }
    }
}