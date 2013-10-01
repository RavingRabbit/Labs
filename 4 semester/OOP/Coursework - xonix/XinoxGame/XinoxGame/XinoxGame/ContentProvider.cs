using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SupportTypes;
using UtilLib;
using XonixGame.GameSettings;

namespace XonixGame
{
    public class ContentProvider : IContentProvider
    {
        private readonly Rectangle _blockRectangle;
        private readonly ContentManager _contentManager;
        private Texture2D _acceleratorTexture;
        private Texture2D _scoresBonusTexture;
        private Texture2D _backgroundTexture;
        private Texture2D[] _ballsTextures;
        private Texture2D _borderTexture;
        private Texture2D _deadPathTexture;
        private Texture2D _defaultTexture;
        private Texture2D[] _explosionTextures;
        private SpriteFont[] _fonts;
        private Texture2D _gridTexture;
        private Texture2D[] _groundTextures;
        private Texture2D _lifeBonusTexture;
        private Texture2D _mainDeviceTexture;
        private Texture2D _mineTexture;
        private Texture2D _pathTexture;
        private Song[] _songs;
        private Texture2D _timeBonusTexture;
        private Texture2D[] _waterTextures;


        public ContentProvider(ContentManager contentManager)
        {
            Requires.NotNull(contentManager, "contentsManager");
            _contentManager = contentManager;
            LoadContent();
            _blockRectangle = new Rectangle(0, 0, Settings.Instance.PlaygroundBlockWidth,
                                            Settings.Instance.PlaygroundBlockHeight);
        }

        public Sprite GetMainDeviceSprite()
        {
            if (_mainDeviceTexture == null)
                return GetDefaultSprite();
            var spriteInfo = new SpriteInfo
                {
                    FrameCount = 71,
                    RowCount = 5,
                    ColCount = 16,
                    FramesPerSecond = 40
                };
            return new AnimatedSprite(_mainDeviceTexture, spriteInfo, Vector2.Zero, true);
        }

        public Sprite GetBallSprite(int index)
        {
            if (_ballsTextures == null)
                return GetDefaultSprite();
            var ballSpriteInfo = new SpriteInfo
                {
                    FrameCount = 9,
                    RowCount = 1,
                    ColCount = 9,
                    FramesPerSecond = 15
                };
            switch (index)
            {
                case 0:
                    {
                        var spriteInfo = new SpriteInfo
                            {
                                FrameCount = 15,
                                RowCount = 3,
                                ColCount = 5,
                                FramesPerSecond = 15
                            };
                        return new AnimatedSprite(_ballsTextures[0], spriteInfo, Vector2.Zero, true);
                    }
                case 1:
                case 2:
                case 3:
                case 4:
                    return new AnimatedSprite(_ballsTextures[index], ballSpriteInfo, Vector2.Zero, true);
            }
            throw new IndexOutOfRangeException();
        }

        public Sprite GetAcceleratorSprite()
        {
            if (_acceleratorTexture == null)
                return GetDefaultSprite();
            var spriteInfo = new SpriteInfo
                {
                    FrameCount = 7,
                    RowCount = 1,
                    ColCount = 7,
                    FramesPerSecond = 4
                };
            return new AnimatedSprite(_acceleratorTexture, spriteInfo, Vector2.Zero, true);
        }

        public Sprite GetLifeBonusSprite()
        {
            if (_lifeBonusTexture == null)
                return GetDefaultSprite();
            var spriteInfo = new SpriteInfo
                {
                    FrameCount = 7,
                    RowCount = 1,
                    ColCount = 7,
                    FramesPerSecond = 4
                };
            return new AnimatedSprite(_lifeBonusTexture, spriteInfo, Vector2.Zero, true);
        }

        public Sprite GetScoresBonusSprite()
        {
            if (_scoresBonusTexture == null)
                return GetDefaultSprite();
            var spriteInfo = new SpriteInfo
            {
                FrameCount = 64,
                RowCount = 8,
                ColCount = 8,
                FramesPerSecond = 40
            };
            return new AnimatedSprite(_scoresBonusTexture, spriteInfo, Vector2.Zero, true);
        }

        public Sprite GetTimeBonusSprite()
        {
            if (_timeBonusTexture == null)
                return GetDefaultSprite();
            var spriteInfo = new SpriteInfo
                {
                    FrameCount = 12,
                    RowCount = 2,
                    ColCount = 6,
                    FramesPerSecond = 4
                };
            return new AnimatedSprite(_timeBonusTexture, spriteInfo, Vector2.Zero, true);
        }

        public Sprite GetExplosionSprite(int index)
        {
            if (_explosionTextures == null)
                return GetDefaultSprite();
            if (index == 0)
            {
                var spriteInfo = new SpriteInfo
                    {
                        FrameCount = 40,
                        RowCount = 5,
                        ColCount = 8,
                        FramesPerSecond = 40
                    };
                return new AnimatedSprite(_explosionTextures[0], spriteInfo);
            }
            throw new NotSupportedException();
        }

        public Sprite GetMineSprite()
        {
            if (_mineTexture == null)
                return GetDefaultSprite();
            var spriteInfo = new SpriteInfo
                {
                    FrameCount = 30,
                    RowCount = 3,
                    ColCount = 10,
                    FramesPerSecond = 25
                };
            return new AnimatedSprite(_mineTexture, spriteInfo, Vector2.Zero, true);
        }

        public Sprite GetBorderBlockSprite(Point point, int index)
        {
            return _borderTexture == null
                       ? GetDefaultSprite(_blockRectangle)
                       : new StaticSprite(_borderTexture, Vector2.Zero,
                                          GetBlockRectangle(point, _borderTexture.Height, _borderTexture.Width));
        }

        public Sprite GetGroundBlockSprite(Point point, int index)
        {
            return new StaticSprite(_groundTextures[index], Vector2.Zero,
                                    GetBlockRectangle(point, _groundTextures[index].Height, _groundTextures[index].Width));
        }

        public Sprite GetWaterBlockSprite(Point point, int index)
        {
            return new StaticSprite(_waterTextures[index], Vector2.Zero,
                                    GetBlockRectangle(point, _waterTextures[index].Height, _waterTextures[index].Width));
        }

        public Sprite GetPathBlockSprite(Point point)
        {
            return _pathTexture == null
                       ? GetDefaultSprite(_blockRectangle)
                       : new StaticSprite(_pathTexture, Vector2.Zero,
                                          GetBlockRectangle(point, _pathTexture.Height, _pathTexture.Width));
        }

        public Sprite GetDeadPathBlockSprite(Point point)
        {
            return _deadPathTexture == null
                       ? GetDefaultSprite(_blockRectangle)
                       : new StaticSprite(_deadPathTexture, Vector2.Zero,
                                          GetBlockRectangle(point, _deadPathTexture.Height, _deadPathTexture.Width));
        }

        public Sprite GetGridSprite(int width, int height)
        {
            return _gridTexture == null
                       ? GetDefaultSprite(new Rectangle(0, 0, width, height))
                       : new StaticSprite(_gridTexture, Vector2.Zero, new Rectangle(0, 0, width, height));
        }

        public Sprite GetBackgroundSprite(int index)
        {
            return _backgroundTexture == null
                       ? GetDefaultSprite()
                       : new StaticSprite(_backgroundTexture);
        }

        public SpriteFont GetFont(int index)
        {
            return _fonts[index];
        }

        public Song GetSong(int index)
        {
            return _songs[index];
        }

        public Sprite GetDefaultSprite()
        {
            return new StaticSprite(_defaultTexture);
        }

        public Sprite GetGroundBlockSprite(Point point, int index, int m, int n)
        {
            return new StaticSprite(_groundTextures[index], Vector2.Zero,
                                    GetBlockRectangle(point, _groundTextures[index].Height*m,
                                                      _groundTextures[index].Width*n));
        }

        private void LoadContent()
        {
            _defaultTexture = _contentManager.Load<Texture2D>("content\\textures\\default");
            _fonts = new SpriteFont[4];

            _fonts[0] = _contentManager.Load<SpriteFont>("content\\fonts\\defaultSpriteFont");
            _fonts[1] = _contentManager.Load<SpriteFont>("content\\fonts\\StatisticsSpriteFont");
            _fonts[2] = _contentManager.Load<SpriteFont>("content\\fonts\\TitlesSpriteFont");
            _fonts[3] = _contentManager.Load<SpriteFont>("content\\fonts\\BonusesSpriteFont");
            _mainDeviceTexture = _contentManager.Load<Texture2D>("content\\textures\\space-core");
            _ballsTextures = new Texture2D[5];
            _ballsTextures[0] = _contentManager.Load<Texture2D>("content\\textures\\greenBall");
            _ballsTextures[1] = _contentManager.Load<Texture2D>("content\\textures\\ball1");
            _ballsTextures[2] = _contentManager.Load<Texture2D>("content\\textures\\ball2");
            _ballsTextures[3] = _contentManager.Load<Texture2D>("content\\textures\\ball3");
            _ballsTextures[4] = _contentManager.Load<Texture2D>("content\\textures\\ball4");
            _acceleratorTexture = _contentManager.Load<Texture2D>("content\\textures\\accelerator");
            _scoresBonusTexture = _contentManager.Load<Texture2D>("content\\textures\\coin");
            _lifeBonusTexture = _contentManager.Load<Texture2D>("content\\textures\\lifeBonus");
            _timeBonusTexture = _contentManager.Load<Texture2D>("content\\textures\\clock");
            _explosionTextures = new Texture2D[1];
            _explosionTextures[0] = _contentManager.Load<Texture2D>("content\\textures\\explosion");
            _mineTexture = _contentManager.Load<Texture2D>("content\\textures\\mine");
            _groundTextures = new Texture2D[3];
            _groundTextures[0] = _contentManager.Load<Texture2D>("content\\textures\\simpsons");
            _groundTextures[1] = _contentManager.Load<Texture2D>("content\\textures\\FamilyGuy");
            _groundTextures[2] = _contentManager.Load<Texture2D>("content\\textures\\south-park");
            _waterTextures = new Texture2D[3];
            _waterTextures[0] = _contentManager.Load<Texture2D>("content\\textures\\water");
            _waterTextures[1] = _contentManager.Load<Texture2D>("content\\textures\\water1");
            _waterTextures[2] = _contentManager.Load<Texture2D>("content\\textures\\water2");
            _pathTexture = _contentManager.Load<Texture2D>("content\\textures\\path");
            _deadPathTexture = _contentManager.Load<Texture2D>("content\\textures\\deadPath");
            _gridTexture = _contentManager.Load<Texture2D>("content\\textures\\grid");
            _backgroundTexture = _contentManager.Load<Texture2D>("content\\textures\\back");
            _borderTexture = _defaultTexture;

            _songs = new Song[1];
            _songs[0] = _contentManager.Load<Song>("content\\sounds\\song0");
        }

        private Rectangle GetBlockRectangle(Point point, int textureHeight, int textureWidth)
        {
            int blockHeight = Settings.Instance.PlaygroundBlockHeight;
            int blockWidth = Settings.Instance.PlaygroundBlockWidth;
            int n = textureHeight/blockHeight - 1;
            if (n < 0) n = 1;
            int m = textureWidth/blockWidth - 1;
            if (m < 0) m = 1;
            return new Rectangle((point.Y%m)*blockWidth, (point.X%n)*blockHeight, blockWidth, blockHeight);
        }

        private Sprite GetDefaultSprite(Rectangle rectangle)
        {
            return new StaticSprite(_defaultTexture, Vector2.Zero, rectangle);
        }
    }
}