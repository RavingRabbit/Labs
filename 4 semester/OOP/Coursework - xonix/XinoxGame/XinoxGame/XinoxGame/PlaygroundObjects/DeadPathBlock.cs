using Microsoft.Xna.Framework;
using SupportTypes;
using XonixGame.GameObjectsBase;
using XonixGame.GameObjects;

namespace XonixGame.GameObjects
{
    internal class DeadPathBlock : PlaygroundBlock
    {
        public DeadPathBlock(Playground playground, Point point)
            : base(playground, point)
        {
        }

        public override void Interact(IInteractive with)
        {
            if (with is MainDevice)
                (with as MainDevice).Destroy();
        }

        protected override Sprite ProvideSprite()
        {
            return Game.ContentProvider.GetDeadPathBlockSprite(PositionOnPlayground);
        }
    }
}