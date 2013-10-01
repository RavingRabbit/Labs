using Microsoft.Xna.Framework;
using IDrawable = XonixGame.GameObjectsBase.IDrawable;

namespace XonixGame.GameObjects
{
    internal static class GameObjectHelper
    {
        public static float GetDistance(this IDrawable obj1, IDrawable obj2)
        {
            return Vector2.Distance(obj1.Position, obj2.Position);
        }

        public static Vector2 GetDirection(this IDrawable obj1, IDrawable obj2)
        {
            Vector2 direction = obj1.CenterPosition - obj2.CenterPosition;
            direction.Normalize();
            return direction;
        }
    }
}