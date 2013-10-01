using System;
using Microsoft.Xna.Framework;

namespace SupportTypes
{
    [Serializable]
    public sealed class BoundingCircle : BoundingShape
    {
        internal BoundingSphere BoundingSphere;

        public override float RadiusLength
        {
            get { return BoundingSphere.Radius; }
        }

        public override Vector2 Position
        {
            get { return Center - new Vector2(BoundingSphere.Radius); }
            set { Center = value + new Vector2(BoundingSphere.Radius); }
        }

        public override float Width
        {
            get { return BoundingSphere.Radius*2; }
            set { throw new NotSupportedException(); }
        }

        public override float Height
        {
            get { return BoundingSphere.Radius*2; }
            set { throw new NotSupportedException(); }
        }

        public float Radius
        {
            get { return BoundingSphere.Radius; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("value");
                BoundingSphere.Radius = value;
            }
        }

        public Vector2 Center
        {
            get { return new Vector2(BoundingSphere.Center.X, BoundingSphere.Center.Y); }
            set { BoundingSphere.Center = new Vector3(value, 0); }
        }

        public override bool Intersects(BoundingShape other)
        {
            if (other is BoundingRectangle)
                return Intersects(this, other as BoundingRectangle);
            if (other is BoundingCircle)
                return (other as BoundingCircle).BoundingSphere.Intersects(BoundingSphere);
            throw new NotSupportedException();
        }
    }
}