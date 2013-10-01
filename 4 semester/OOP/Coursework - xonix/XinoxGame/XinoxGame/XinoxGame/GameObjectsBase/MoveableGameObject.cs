using System;
using Microsoft.Xna.Framework;
using SupportTypes;

namespace XonixGame.GameObjectsBase
{
    public abstract class MoveableGameObject : InteractiveGameObject, IMoveable
    {
        private static readonly Vector2 NanVector = new Vector2(float.NaN, float.NaN);
        private readonly QueueSet<Vector2> _previousPositions;
        private Vector2 _direction = Vector2.Zero;
        private Vector2 _previousPosition;
        private float _stepLength = 3;
        private Vector2 _target;

        protected MoveableGameObject(IGame game)
            : base(game)
        {
            _previousPosition = Vector2.Zero;
            _previousPositions = new QueueSet<Vector2>(5);
        }

        protected Vector2 Direction
        {
            get { return _direction; }
            set
            {
                value.Normalize();
                _direction = value;
            }
        }

        protected Vector2 TargetPosition
        {
            get { return _target; }
            set { _target = value; }
        }

        protected Vector2 PreviousPosition
        {
            get { return _previousPosition; }
            set { _previousPosition = value; }
        }

        public float Velocity
        {
            get { return _stepLength; }
            set
            {
                if (value < 1) throw new ArgumentOutOfRangeException("value");
                _stepLength = value;
            }
        }

        public bool Moving
        {
            get { return !IsTargetAchieved(); }
        }

        public virtual void MoveTo(Vector2 target)
        {
            _target = target;
            Direction = _target - Position;
        }

        public void Stop()
        {
            Position = _target = PreviousPosition;
        }

        public override void Update(TimeSpan elapsed)
        {
            if (!IsTargetAchieved())
            {
                Move();
            }
            else
            {
                if (_target == Position)
                    _previousPosition = Position;
            }
            base.Update(elapsed);
        }

        public void ReturnOnSteps(int stepsNumber)
        {
            stepsNumber = stepsNumber%5;
            Vector2 lastPosition = Vector2.Zero;
            for (int i = 0; i < stepsNumber; i++)
            {
                lastPosition = _previousPositions.Dequeue();
            }
            Position = _previousPosition = lastPosition;
        }

        protected void Move()
        {
            Vector2 step = _direction*_stepLength;
            _previousPosition = Position;
            _previousPositions.Add(_previousPosition);
            if (step.Length() > GetTargetDistance())
                Position = _target;
            else
                Position += step;
        }

        private float GetTargetDistance()
        {
            return (_target - Position).Length();
        }

        private bool IsTargetAchieved()
        {
            return _target == Position || _direction == NanVector || _direction == Vector2.Zero;
        }
    }
}