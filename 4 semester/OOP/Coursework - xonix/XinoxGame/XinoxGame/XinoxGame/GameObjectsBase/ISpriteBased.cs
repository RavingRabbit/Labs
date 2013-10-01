using SupportTypes;
using XonixGame.GameObjectsBase;

namespace XonixGame.GameObjects
{
    internal interface ISpriteBased : IDrawable
    {
        Sprite Sprite { get; }
    }
}