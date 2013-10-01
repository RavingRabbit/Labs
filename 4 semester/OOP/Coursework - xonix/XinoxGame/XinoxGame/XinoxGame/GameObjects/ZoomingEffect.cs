using System;
using XonixGame.GameObjectsBase;

namespace XonixGame.GameObjects
{
    internal class ZoomingEffect : GameObject
    {
        private readonly float _endScale;
        private readonly float _speed = 0.75f;

        public ZoomingEffect(IGame game, float startScale, float endScale, float speed = 0.5f)
            : base(game)
        {
            game.Camera.Scale = startScale;
            _speed = speed;
            _endScale = endScale;
        }

        public override void Update(TimeSpan elapsed)
        {
            float step = (Game.Camera.Scale - _endScale)*_speed*(float) elapsed.TotalSeconds;
            if (Math.Abs(Game.Camera.Scale - _endScale) <= 0.02f)
            {
                Dispose();
                return;
            }
            Game.Camera.Scale -= step;
        }
    }
}