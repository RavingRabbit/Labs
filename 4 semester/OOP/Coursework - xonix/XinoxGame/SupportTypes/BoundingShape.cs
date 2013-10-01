using System;
using Microsoft.Xna.Framework;

namespace SupportTypes
{
    [Serializable]
    public abstract class BoundingShape
    {
        public abstract float RadiusLength { get; }

        public abstract Vector2 Position { get; set; }

        public abstract float Width { get; set; }

        public abstract float Height { get; set; }

        public abstract bool Intersects(BoundingShape other);

        internal static bool Intersects(BoundingCircle circle, BoundingRectangle rectangle)
        {
            return circle.BoundingSphere.Intersects(rectangle.BoundingBox);
        }
    }
}