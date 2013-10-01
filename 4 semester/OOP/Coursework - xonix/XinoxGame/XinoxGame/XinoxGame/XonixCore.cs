using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SupportTypes;
using UtilLib;
using XonixGame.Bonuses;
using XonixGame.Diagnostics;
using XonixGame.GameObjects;
using XonixGame.GameObjectsBase;
using XonixGame.GameSettings;
using IDrawable = XonixGame.GameObjectsBase.IDrawable;

namespace XonixGame
{
    internal class XonixCore : IGame
    {
        private readonly Camera2D _camera;
        private readonly Game _game;
        private readonly GameObjectCollection _gameObjects;
        private readonly Random _random;
        private bool _changingLevel;
        private ContentProvider _contentHelper;
        private DebugHelper _debugHelper;
        private List<IDrawable> _drawablesWithoutTransform;
        private KeyboardHelper _keyboardHelper;
        private Level _level;
        private MainDevice _mainDevice;
        private Playground _playground;
        private BonusGenerator _bonusGenerator;
        private SpriteBatch _spriteBatch;
        private StatisticsPanel _statisticsPanel;
        private GameTimer _scoresTimer;

        public XonixCore(Game game)
        {
            Requires.NotNull(game, "game");
            _game = game;
            _camera = new Camera2D(this);
            _gameObjects = new GameObjectCollection(this);
            _random = new Random();
        }

        public IGameObjectCollection GameObjectCollection
        {
            get { return _gameObjects; }
        }

        public IContentProvider ContentProvider
        {
            get { return _contentHelper; }
        }

        public ICamera2D Camera
        {
            get { return _camera; }
        }

        public Random Random
        {
            get { return _random; }
        }

        public Level Level
        {
            get { return _level; }
        }

        public MainDevice PlayerDevice
        {
            get { return _mainDevice; }
        }

        public int Scores { get; set; }

        public int Lifes { get; set; }

        public bool Completed { get; set; }

        public void RestartGame(LossReason lossReason)
        {
            if (_changingLevel)
                return;
            switch (lossReason)
            {
                case LossReason.LastLifeSpent:
                    _statisticsPanel.LastLifeSpent = true;
                    break;
                case LossReason.TimeSpent:
                    _statisticsPanel.TimeSpent = true;
                    break;
            }
            _changingLevel = true;
            _statisticsPanel.TryAgain = true;
            var zoomingEffect = new ZoomingEffect(this, 1f, 3f, 1.7f);
            GameObjectCollection.Add(zoomingEffect);
            zoomingEffect.Disposed += (sender, args) =>
                {
                    Lifes = 3;
                    StartLevel(1);
                    _changingLevel = false;
                };
        }

        public TimeSpan TimeLeft { get; private set; }

        public void AddTime(TimeSpan time)
        {
            TimeLeft += time;
        }

        public void Pause()
        {
            Paused = true;
            _gameObjects.Enabled = false;
        }

        public void Resume()
        {
            Paused = false;
            _gameObjects.Enabled = true;
        }

        public void Exit()
        {
            _game.Exit();
        }

        public bool Paused { get; private set; }

        public void Initialize()
        {
            UpdateScreenSettings(Settings.Instance);
            _keyboardHelper = new KeyboardHelper(Settings.FirstPlayer);
            _contentHelper = new ContentProvider(_game.Content);
            _debugHelper = new DebugHelper(this);
            Lifes = 3;
            StartLevel(1);
        }

        public void StartLevel(int levelNumber)
        {
            GameObjectCollection.Clear();
            GameObjectCollection.Add(new Background(this));
            var bf = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.All, this));
            /*_level = new Level(null, 3, 5, 3, 2, 3);
            var position = new Vector2(Settings.Instance.Width/2 - Settings.Instance.PlaygroundBlockWidth*144/2,
                                       Settings.Instance.Height/2 - Settings.Instance.PlaygroundBlockHeight*81/2);
            _playground = new Playground(this, position, 144, 81);
            _level = new Level(_playground, 3, 5, 3, 2, 3);
            using (var stream = File.Create("level3.pg"))
            {
                bf.Serialize(stream, _level);
            }*/
            _level = new Level(null, levelNumber, 1, 1, 0, 0);
            using (FileStream stream = File.OpenRead(string.Format("level{0}.pg", levelNumber)))
            {
                _level = (Level) bf.Deserialize(stream);
            }
            _playground = _level.Playground;
            _statisticsPanel = new StatisticsPanel(this);
            _mainDevice = new MainDevice(this) {Position = _playground.StartPosition};
            _camera.Focus = _mainDevice;
            _camera.Position = _mainDevice.Position;
            _drawablesWithoutTransform = new List<IDrawable>();
            _bonusGenerator = new BonusGenerator(this);
            DrawWithoutTransform(_statisticsPanel);
            GameObjectCollection.Add(_playground);
            GameObjectCollection.Add(_mainDevice);
            GameObjectCollection.Add(new ZoomingEffect(this, 0.4f, 1f, 0.4f));
            GameObjectCollection.Add(_bonusGenerator);
            var safePositions = new Queue<Vector2>();
            safePositions.Enqueue(_playground.Position + new Vector2(200));
            safePositions.Enqueue(_playground.Position + new Vector2(_playground.Width, _playground.Height) -
                                  new Vector2(200));
            safePositions.Enqueue(_playground.Position + new Vector2(_playground.Width, 0) - new Vector2(200, -200));
            safePositions.Enqueue(_playground.Position + new Vector2(0, _playground.Height) - new Vector2(-200, 200));
            safePositions.Enqueue(_playground.Position + new Vector2(300));
            safePositions.Enqueue(_playground.Position + new Vector2(_playground.Width, _playground.Height) -
                                  new Vector2(300));
            safePositions.Enqueue(_playground.Position + new Vector2(_playground.Width, 0) - new Vector2(300, -300));
            safePositions.Enqueue(_playground.Position + new Vector2(0, _playground.Height) - new Vector2(-300, 300));
            for (int i = 0; i < _level.HardBalls; i++)
            {
                GameObjectCollection.Add(new HardBall(this, safePositions.Dequeue()));
            }
            for (int i = 0; i < _level.SoftBalls; i++)
            {
                GameObjectCollection.Add(new SoftBall(this, safePositions.Dequeue()));
            }
            for (int i = 0; i < _level.Mines; i++)
            {
                GameObjectCollection.Add(new Mine(this, _playground.Position + new Vector2(200 + 150*i, 30)));
            }
            _playground.Completed += (sender, args) => NextLevel();
            TimeLeft = TimeSpan.FromSeconds(61);
            _scoresTimer = new GameTimer(TimeSpan.FromSeconds(10));
            GC.Collect();
        }

        private void GenerateMines()
        {
            for (int i = 0; i < 50; i++)
            {
                GameObjectCollection.Add(new Mine(this,
                                                  _playground.Position +
                                                  new Vector2(Random.Next((int) _playground.Width - 40),
                                                              Random.Next((int) _playground.Height - 40))));
            }
        }

        private void UpdateScreenSettings(IScreenSettings screenSettings)
        {
            var graphics = (GraphicsDeviceManager) _game.Services.GetService(typeof (IGraphicsDeviceManager));
            graphics.PreferredBackBufferHeight = screenSettings.Height;
            graphics.PreferredBackBufferWidth = screenSettings.Width;
            graphics.IsFullScreen = screenSettings.IsFullScreen;
            graphics.SynchronizeWithVerticalRetrace = screenSettings.SynchronizeWithVerticalRetrace;
            graphics.PreferMultiSampling = true;
            graphics.GraphicsDevice.PresentationParameters.MultiSampleCount = 4;

            var state = new RasterizerState
                {
                    CullMode = CullMode.CullCounterClockwiseFace,
                    MultiSampleAntiAlias = true
                };
            _game.GraphicsDevice.RasterizerState = state;
            graphics.ApplyChanges();
        }

        public void LoadContent()
        {
            _spriteBatch = new SpriteBatch(_game.GraphicsDevice);
        }

        public void Update(TimeSpan elapsed)
        {
            if (!Paused && !Completed)
            {
                if (TimeLeft > TimeSpan.Zero)
                    TimeLeft -= elapsed;
                else
                    RestartGame(LossReason.TimeSpent); 
                if (_scoresTimer.Update(elapsed))
                {
                    Scores -= 100;
                    if (Scores < 0)
                        Scores = 0;
                }
            }
            KeyboardState keyboardState = Keyboard.GetState(PlayerIndex.One);
            if (keyboardState.IsKeyDown(Keys.M)) GenerateMines();
            if (keyboardState.IsKeyDown(Keys.G)) GC.Collect();
            _keyboardHelper.Update(keyboardState);
            if (_keyboardHelper.Pause)
                Pause();
            if (!_keyboardHelper.Pause && _keyboardHelper.Resume)
                Resume();
            if (_keyboardHelper.GetDirection() != Vector2.Zero && _mainDevice.Enabled)
                _mainDevice.MoveTo(_mainDevice.Position + _keyboardHelper.GetDirection()*_mainDevice.Velocity);
            _gameObjects.Update(elapsed);
            _debugHelper.Update(elapsed);
        }

        private void NextLevel()
        {
            if (Level.LevelNumber == 3)
                    Completed = true;
            _changingLevel = true;
            _scoresTimer = new GameTimer(TimeSpan.MaxValue);
            var effect = new ZoomingEffect(this, 1f, 0.6f, 0.4f);
            GameObjectCollection.Add(effect);
            _mainDevice.Enabled = false;
            _mainDevice.Visible = false;
            _mainDevice.CenterPosition = _playground.CenterPosition;
            _gameObjects.Add(new FireworkGenerator(this));
            effect.Disposed += (sender, args) =>
                {
                    int nextLevelNumber = _level.LevelNumber + 1;
                    if (nextLevelNumber > 3)
                        Completed = true;
                    else
                    {
                        StartLevel(nextLevelNumber);
                        _changingLevel = false;
                    }
                };
        }

        public void DrawWithoutTransform(IDrawable drawable)
        {
            _drawablesWithoutTransform.Add(drawable);
            _gameObjects.Add(drawable as IGameObject);
            drawable.Disposed += (sender, args) => _drawablesWithoutTransform.Remove(sender as IDrawable);
        }

        public void Draw(TimeSpan elapsed)
        {
            _camera.Update(elapsed);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap,
                               DepthStencilState.None, null, null, _camera.Transform);
            _gameObjects.Draw(_spriteBatch);
            _spriteBatch.End();


            _spriteBatch.Begin();
            foreach (IDrawable drawable in _drawablesWithoutTransform)
            {
                drawable.Draw(_spriteBatch);
            }
            _debugHelper.Draw(_spriteBatch);
            _spriteBatch.End();
        }
    }
}