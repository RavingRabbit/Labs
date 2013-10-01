using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XonixGame.GameObjectsBase;
using IDrawable = XonixGame.GameObjectsBase.IDrawable;

namespace XonixGame.Diagnostics
{
    public class DebugHelper
    {
        private static readonly Vector2 DebugInformationPosition = new Vector2(30);
        private readonly SpriteFont _font;
        private readonly FpsCounter _fpsCounter = new FpsCounter();
        private readonly IGame _game;
        private readonly StringBuilder _sb = new StringBuilder();

        public DebugHelper(IGame game)
        {
            if (game == null)
                throw new ArgumentNullException("game");
            _game = game;
            _font = game.ContentProvider.GetFont(0);
        }

        [Conditional("DEBUG")]
        public void Draw(SpriteBatch spriteBatch)
        {
            string debugInformation = GenerateDebugInformation();
            spriteBatch.DrawString(_font, debugInformation, DebugInformationPosition, Color.White);
        }

        [Conditional("DEBUG")]
        public void Update(TimeSpan elapsed)
        {
            _fpsCounter.Update(elapsed);
        }

        private string GenerateDebugInformation()
        {
            _sb.Clear();

            _sb.Append("FPS = " + _fpsCounter.FPS + Environment.NewLine);

            _sb.Append("Garbage collection count = " + GC.CollectionCount(0) + " + " + GC.CollectionCount(1) + " + " +
                       GC.CollectionCount(2) + Environment.NewLine);

            ReadOnlyCollection<IGameObject> gameObjects = _game.GameObjectCollection.GameObjects;
            _sb.Append("GameObjects = " + gameObjects.Count + Environment.NewLine);

            ReadOnlyCollection<IUpdatable> updatableGameObjects = _game.GameObjectCollection.UpdatableObjects;
            _sb.Append("Updatable = " + updatableGameObjects.Count + Environment.NewLine);

            ReadOnlyCollection<IDrawable> drawableGameObjects = _game.GameObjectCollection.DrawableObjects;
            _sb.Append("Drawable = " + drawableGameObjects.Count + Environment.NewLine);

            ReadOnlyCollection<IInteractive> interactiveGameObjects = _game.GameObjectCollection.InteractiveObjects;
            _sb.Append("Interactive = " + interactiveGameObjects.Count + Environment.NewLine);

            return _sb.ToString();
        }

        /*
        private string GenerateDebugInformation()
        {
            var sb = new StringBuilder();
            sb.Append("FPS = " + _fpsCounter.FPS + Environment.NewLine);

            List<IGameObject> gameObjects = _game.GameObjectCollection.GameObjects;
            sb.Append(string.Format("GameObjects = {0}: {1}", gameObjects.Count, Environment.NewLine));
            foreach (IGameObject gameObject in gameObjects)
            {
                sb.Append(string.Format("    " + gameObject.GetType() + Environment.NewLine));
            }

            List<IUpdatable> updatableGameObjects = _game.GameObjectCollection.UpdatableObjects;
            sb.Append(string.Format("UpdatableGameObjects = {0}: {1}", updatableGameObjects.Count, Environment.NewLine));
            foreach (IUpdatable gameObject in updatableGameObjects)
            {
                sb.Append(string.Format("    " + gameObject.GetType() + Environment.NewLine));
            }

            List<IDrawable> drawableGameObjects = _game.GameObjectCollection.DrawableObjects;
            sb.Append(string.Format("DrawableGameObjects = {0}: {1}", drawableGameObjects.Count, Environment.NewLine));
            foreach (IDrawable gameObject in drawableGameObjects)
            {
                sb.Append(string.Format("    " + gameObject.GetType() + Environment.NewLine));
            }

            List<IInteractive> interactiveGameObjects = _game.GameObjectCollection.InteractiveObjects;
            sb.Append(string.Format("InteractiveGameObjects = {0}: {1}", interactiveGameObjects.Count,
                                    Environment.NewLine));
            foreach (IInteractive gameObject in interactiveGameObjects)
            {
                sb.Append(string.Format("    " + gameObject.GetType() + Environment.NewLine));
            }

            return sb.ToString();
        }*/
    }
}