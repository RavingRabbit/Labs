using System;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SupportTypes;
using UtilLib;
using XonixGame.GameObjects;
using XonixGame.GameObjectsBase;
using XonixGame.GameSettings;
using GameObjectHelper = XonixGame.GameObjects.GameObjectHelper;
using IDrawable = XonixGame.GameObjectsBase.IDrawable;

namespace XonixGame.GameObjects
{
    [Serializable]
    public abstract class PlaygroundBlock : InteractiveGameObject, ISpriteBased
    {
        private readonly Playground _playground;
        private readonly Point _positionOnPlayground;
        [NonSerialized] private BoundingRectangle _boundingRectangle;
        [NonSerialized] private Sprite _sprite;

        protected PlaygroundBlock(Playground playground, Point point)
            : base(playground.Game)
        {
            _playground = playground;
            _positionOnPlayground = point;
            Init();
        }

        public Point PositionOnPlayground
        {
            get { return _positionOnPlayground; }
        }

        public Playground Playground
        {
            get { return _playground; }
        }

        public override BoundingShape BoundingShape
        {
            get { return _boundingRectangle; }
        }

        Sprite ISpriteBased.Sprite
        {
            get { return _sprite; }
        }

        public override sealed Vector2 Position
        {
            get { return _sprite.Position; }
            set { _sprite.Position = value; }
        }

        public override sealed float Width
        {
            get { return Settings.Instance.PlaygroundBlockWidth; }
        }

        public override sealed float Height
        {
            get { return Settings.Instance.PlaygroundBlockHeight; }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible && _sprite != null)
                _sprite.Draw(spriteBatch);
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Init();
        }

        private void Init()
        {
            SetSprite(ProvideSprite());
            _boundingRectangle = new BoundingRectangle {Position = Position, Height = Height, Width = Width};
        }

        protected abstract Sprite ProvideSprite();

        public Vector2 GetNormal(IInteractive obj)
        {
            var corners = new Vector2[4];
            corners[0] = Position;
            corners[1] = Position + new Vector2(Width, 0);
            corners[2] = Position + new Vector2(Width, Height);
            corners[3] = Position + new Vector2(0, Height);

            var distances = new double[4];
            BoundingShape boundingShape = obj.BoundingShape;
            Vector2 direction = GameObjectHelper.GetDirection((IDrawable) this, (IDrawable) obj);
            if (boundingShape.Intersects(_boundingRectangle))
                while (boundingShape.Intersects(_boundingRectangle))
                    obj.Position -= direction;
            distances[0] = ((corners[0] - obj.CenterPosition).Length() + (corners[1] - obj.CenterPosition).Length())/
                           (double) 2;
            distances[1] = ((corners[1] - obj.CenterPosition).Length() + (corners[2] - obj.CenterPosition).Length())/
                           (double) 2;
            distances[2] = ((corners[2] - obj.CenterPosition).Length() + (corners[3] - obj.CenterPosition).Length())/
                           (double) 2;
            distances[3] = ((corners[3] - obj.CenterPosition).Length() + (corners[0] - obj.CenterPosition).Length())/
                           (double) 2;
            double minValue = double.MaxValue;
            int minIndex = 0;
            for (int i = 0; i < distances.Length; i++)
            {
                if (distances[i] < minValue)
                {
                    minValue = distances[i];
                    minIndex = i;
                }
            }
            switch (minIndex)
            {
                case 0:
                    return new Vector2(0, -1);
                case 1:
                    return new Vector2(1, 0);
                case 2:
                    return new Vector2(0, 1);
                case 3:
                    return new Vector2(-1, 0);
            }
            throw new InvalidOperationException();
        }

        protected void SetSprite(Sprite sprite)
        {
            Requires.NotNull(sprite, "sprite");
            _sprite = sprite;
            _sprite.Position = GetBlockPosition();
        }

        private Vector2 GetBlockPosition()
        {
            return _playground.Position + new Vector2(_positionOnPlayground.Y*Width, _positionOnPlayground.X*Height);
        }

        public override void Destroy()
        {
            Game.GameObjectCollection.Add(new ExplodedObject(this, 4, 2, 2, 2));
            base.Destroy();
        }
    }
}