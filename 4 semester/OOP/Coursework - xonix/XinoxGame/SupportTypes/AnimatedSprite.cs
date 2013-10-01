using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SupportTypes
{
    public sealed class AnimatedSprite : Sprite
    {
        private readonly float _frameHeight;
        private readonly float _frameWidth;
        private readonly Rectangle[] _framesRectangles;
        private readonly SpriteInfo _spriteInfo;
        private readonly GameTimer _timer;
        private int _currentFrame;

        public AnimatedSprite(Texture2D texture, SpriteInfo spriteInfo)
            : this(texture, spriteInfo, Vector2.Zero)
        {
        }

        public AnimatedSprite(Texture2D texture, SpriteInfo spriteInfo, Vector2 position, bool randomStartFrame = false)
            : base(texture, position)
        {
            _spriteInfo = spriteInfo;
            _timer = new GameTimer(TimeSpan.FromSeconds((double) 1/spriteInfo.FramesPerSecond));
            _frameWidth = (float) Texture.Width/_spriteInfo.ColCount;
            _frameHeight = (float) Texture.Height/_spriteInfo.RowCount;
            if (randomStartFrame)
                _currentFrame = new Random().Next(_spriteInfo.FrameCount - 1);
            _framesRectangles = new Rectangle[_spriteInfo.FrameCount];
            InitFramesRectangles();
        }

        internal override Rectangle Rectangle
        {
            get { return _framesRectangles[_currentFrame]; }
        }

        public override float Width
        {
            get { return _frameWidth; }
        }

        public override float Height
        {
            get { return _frameHeight; }
        }

        public bool Repeated { get; private set; }

        private void InitFramesRectangles()
        {
            for (int i = 0; i < _spriteInfo.FrameCount; i++)
            {
                _framesRectangles[i] = new Rectangle((int) Math.Round(_frameWidth*(i%(_spriteInfo.ColCount))),
                                                     (int) Math.Round(_frameHeight*(i/_spriteInfo.ColCount)),
                                                     (int) Math.Round(_frameWidth), (int) Math.Round(_frameHeight));
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position.Rounded(), _framesRectangles[_currentFrame], Color.White);
        }

        public override void Update(TimeSpan elapsed)
        {
            if (_timer.Update(elapsed))
                NextFrame();
        }

        private void NextFrame()
        {
            _currentFrame++;
            if (_currentFrame == _spriteInfo.FrameCount)
                _currentFrame = 0;
            Repeated = _currentFrame == (_spriteInfo.FrameCount - 1);
        }
    }
}