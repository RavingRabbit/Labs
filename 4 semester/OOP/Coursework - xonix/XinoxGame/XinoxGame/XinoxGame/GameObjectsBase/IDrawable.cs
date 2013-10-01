using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XonixGame.GameObjectsBase
{
    public interface IDrawable : IGameObject
    {
        bool Visible { get; set; }

        Vector2 Position { get; set; }

        Vector2 CenterPosition { get; set; }

        float Width { get; }

        float Height { get; }

        event EventHandler VisibleChanged;

        void Draw(SpriteBatch spriteBatch);
    }
}