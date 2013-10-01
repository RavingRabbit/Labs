using System;
using Microsoft.Xna.Framework;

namespace SupportTypes
{
    [Serializable]
    public sealed class BoundingRectangle : BoundingShape
    {
        internal BoundingBox BoundingBox;
        private float _height;
        private Vector2 _position;
        private float _radius;
        private float _width;

        public override float RadiusLength
        {
            get { return _radius; }
        }

        public override float Width
        {
            get { return _width; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("value");
                _width = value;
                UpdateRadius();
                BoundingBox.Max = new Vector3(Position + new Vector2(value, Height), 0);
            }
        }

        public override float Height
        {
            get { return _height; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("value");
                _height = value;
                UpdateRadius();
                BoundingBox.Max = new Vector3(Position + new Vector2(Width, value), 0);
            }
        }

        public override Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                BoundingBox.Min = new Vector3(value, 0);
                BoundingBox.Max = new Vector3(value + new Vector2(Width, Height), 0);
            }
        }

        private void UpdateRadius()
        {
            _radius = (float) Math.Sqrt(_height*_height + _width*_width);
        }

        public override bool Intersects(BoundingShape other)
        {
            if (other is BoundingCircle)
                return Intersects(other as BoundingCircle, this);
            if (other is BoundingRectangle)
                return (other as BoundingRectangle).BoundingBox.Intersects(BoundingBox);
            throw new NotSupportedException();
        }
    }
}