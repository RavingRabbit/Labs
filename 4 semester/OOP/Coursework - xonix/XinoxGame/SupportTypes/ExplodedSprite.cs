using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SupportTypes
{
    public class ExplodedSprite : Sprite
    {
        private const int FramesNumber = 70;
        private static readonly Random Random = new Random();
        private readonly float[,] _angles;
        private readonly int _colCount;
        private readonly int _peaceWidth;
        private readonly StaticSprite[,] _peaces;
        private readonly Rectangle _rectangle;
        private readonly int _rowCount;
        private readonly float[,] _velocities;
        private int _currentFrame;

        public ExplodedSprite(Sprite sprite, Vector2 position, int rowCount, int colCount, int peaceWidth = 4)
            : this(sprite.Texture, sprite.Rectangle, position, rowCount, colCount, peaceWidth)
        {
        }

        internal ExplodedSprite(Texture2D texture, Rectangle rectangle, Vector2 position, int rowCount, int colCount,
                                int peaceWidth = 4)
            : base(texture, position)
        {
            _peaceWidth = peaceWidth;
            _rowCount = rowCount;
            _colCount = colCount;
            _peaces = new StaticSprite[_rowCount,_colCount];
            _angles = new float[_rowCount,_colCount];
            _velocities = new float[_rowCount,_colCount];
            _rectangle = rectangle;
            InitFramesRectangles();
        }

        public override sealed float Width
        {
            get { return _colCount*_peaceWidth*4; }
        }

        public override sealed float Height
        {
            get { return _rowCount*_peaceWidth*4; }
        }

        public bool Finished { get; private set; }

        private void InitFramesRectangles()
        {
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _colCount; j++)
                {
                    var rectangle = new Rectangle(_peaceWidth*(j) + _rectangle.X, _peaceWidth*(i) + _rectangle.Y,
                                                  _peaceWidth,
                                                  _peaceWidth);
                    _peaces[i, j] = new StaticSprite(Texture, Position, rectangle);
                }
            }
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _colCount; j++)
                {
                    _angles[i, j] = (float) Random.Next(628)/100;
                }
            }
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _colCount; j++)
                {
                    _velocities[i, j] = (float) Random.Next(5, 30)/10;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Finished)
                return;
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _colCount; j++)
                {
                    _peaces[i, j].Draw(spriteBatch, _angles[i, j],
                                       new Vector2(_peaceWidth*(j - _colCount/2), _peaceWidth*(i - _rowCount/2)),
                                       1f - (float) _currentFrame/70);
                }
            }
        }

        public override void Update(TimeSpan elapsed)
        {
            NextFrame();
            base.Update(elapsed);
        }

        private void NextFrame()
        {
            _currentFrame++;
            if (_currentFrame == FramesNumber)
            {
                Finished = true;
                return;
            }
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _colCount; j++)
                {
                    StaticSprite sprite = _peaces[i, j];
                    sprite.Position += new Vector2((j - (float) _colCount/2), (i - (float) _rowCount/2))*
                                       _velocities[i, j]/3f;
                }
            }
        }
    }
}