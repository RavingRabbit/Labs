using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XonixGame.GameObjectsBase
{
    [Serializable]
    public abstract class DrawableGameObject : GameObject, IDrawable
    {
        private bool _visible = true;

        protected DrawableGameObject(IGame game)
            : base(game)
        {
        }

        public abstract Vector2 Position { get; set; }

        public virtual Vector2 CenterPosition
        {
            get { return Position + new Vector2(Width/2, Height/2); }
            set { Position = value - new Vector2(Width/2, Height/2); }
        }

        public abstract float Width { get; }

        public abstract float Height { get; }

        public virtual bool Visible
        {
            get { return _visible; }
            set
            {
                if (_visible == value) return;
                _visible = value;
                OnVisibleChanged();
            }
        }

        public event EventHandler VisibleChanged;

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }

        protected virtual void OnVisibleChanged()
        {
            EventHandler handler = VisibleChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}