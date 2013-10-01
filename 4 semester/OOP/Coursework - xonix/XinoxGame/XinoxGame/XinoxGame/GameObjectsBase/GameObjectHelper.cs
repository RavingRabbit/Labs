using Microsoft.Xna.Framework;

namespace XonixGame.GameObjectsBase
{
    public static class GameObjectHelper
    {
        public static float GetDistance(this IDrawable obj1, IDrawable obj2)
        {
            return Vector2.Distance(obj1.Position, obj2.Position);
        }

        public static Vector2 GetDirection(this IDrawable obj1, IDrawable obj2)
        {
            Vector2 direction = obj1.Position - obj2.Position;
            direction.Normalize();
            return direction;
        }
    }
}