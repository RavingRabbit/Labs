using System;
using Microsoft.Xna.Framework;

namespace SupportTypes
{
    internal static class VectorExtension
    {
        public static Vector2 Rounded(this Vector2 vector2)
        {
            return new Vector2((int) Math.Round(vector2.X), (int) Math.Round(vector2.Y));
        }
    }
}