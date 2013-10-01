using Microsoft.Xna.Framework;

namespace XonixGame
{
    public class XonixGame : Game
    {
        private readonly XonixCore _core;
        private readonly GraphicsDeviceManager _graphics;

        public XonixGame()
        {
            _graphics = new GraphicsDeviceManager(this);

            _core = new XonixCore(this);
        }

        public GraphicsDeviceManager Graphics
        {
            get { return _graphics; }
        }

        protected override void Initialize()
        {
            _core.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _core.LoadContent();
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            _core.Update(gameTime.ElapsedGameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _core.Draw(gameTime.ElapsedGameTime);
            base.Draw(gameTime);
        }
    }
}