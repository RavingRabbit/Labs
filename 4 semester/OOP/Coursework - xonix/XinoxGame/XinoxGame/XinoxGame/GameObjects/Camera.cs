using System;
using Microsoft.Xna.Framework;
using XonixGame.GameObjectsBase;
using XonixGame.GameSettings;
using IDrawable = XonixGame.GameObjectsBase.IDrawable;

namespace XonixGame.GameObjects
{
    public interface IFocusable
    {
        Vector2 Position { get; }
    }

    public interface ICamera2D
    {
        Vector2 Position { get; set; }

        float MoveSpeed { get; set; }

        float Rotation { get; set; }

        Vector2 Origin { get; }

        float Scale { get; set; }
        Vector2 ScreenCenter { get; }
        Matrix Transform { get; }

        IFocusable Focus { get; set; }

        bool IsInView(IDrawable drawable);

        bool IsInView(Vector2 position, float width, float height);
    }

    public class Camera2D : GameObject, ICamera2D
    {
        private Vector2 _position;
        protected float _viewportHeight;
        protected float _viewportWidth;

        public Camera2D(IGame game)
            : base(game)
        {
            _viewportWidth = Settings.Instance.Width;
            _viewportHeight = Settings.Instance.Height;
            ScreenCenter = new Vector2(_viewportWidth/2, _viewportHeight/2);
            Scale = 1;
            MoveSpeed = 1.25f;
        }

        #region Properties

        private Vector2 _origin;

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public float Rotation { get; set; }

        public Vector2 Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        public float Scale { get; set; }
        public Vector2 ScreenCenter { get; protected set; }
        public Matrix Transform { get; set; }

        public IFocusable Focus { get; set; }

        public float MoveSpeed { get; set; }

        #endregion

        public bool IsInView(Vector2 position, float width, float height)
        {
            if ((position.X + width) < (_position.X - _origin.X) || (position.X) > (_position.X + _origin.X))
                return false;
            if ((position.Y + height) < (_position.Y - _origin.Y) || (position.Y) > (_position.Y + _origin.Y))
                return false;
            return true;
        }

        public bool IsInView(IDrawable drawable)
        {
            return IsInView(drawable.Position, drawable.Width, drawable.Height);
        }

        public override void Update(TimeSpan elapsed)
        {
            Transform = Matrix.Identity*
                        Matrix.CreateTranslation(-Position.X, -Position.Y, 0)*
                        Matrix.CreateRotationZ(Rotation)*
                        Matrix.CreateTranslation(Origin.X, Origin.Y, 0)*
                        Matrix.CreateScale(new Vector3(Scale, Scale, Scale));

            Origin = ScreenCenter/Scale;

            var delta = (float) elapsed.TotalSeconds;

            _position.X += (Focus.Position.X - Position.X)*MoveSpeed*delta;
            _position.Y += (Focus.Position.Y - Position.Y)*MoveSpeed*delta;

            //_position = Focus.Position;
        }
    }
}