using System;
using Microsoft.Xna.Framework;
using SupportTypes;
using XonixGame.GameObjects;
using XonixGame.GameObjectsBase;
using XonixGame.GameObjects;

namespace XonixGame.Bonuses
{
    internal class BonusGenerator : GameObject
    {
        private GameTimer _acceleratorTimer;
        private bool _hasAccelerator;
        private bool _hasLife;
        private bool _hasTime;
        private bool _hasScores;
        private GameTimer _lifeTimer;
        private GameTimer _timeTimer;
        private GameTimer _scoresTimer;


        public BonusGenerator(IGame game)
            : base(game)
        {
            _acceleratorTimer = new GameTimer(TimeSpan.FromSeconds(Game.Random.Next(3, 10)));
            _lifeTimer = new GameTimer(TimeSpan.FromSeconds(Game.Random.Next(15, 25)));
            _timeTimer = new GameTimer(TimeSpan.FromSeconds(Game.Random.Next(5, 15)));
            _scoresTimer = new GameTimer(TimeSpan.FromSeconds(Game.Random.Next(5,15)));
        }

        public override void Update(TimeSpan elapsed)
        {
            if (_acceleratorTimer.Update(elapsed) && !_hasAccelerator)
            {
                GenerateAccelerator();
                _acceleratorTimer = new GameTimer(TimeSpan.FromSeconds(Game.Random.Next(12, 17)));
            }
            if (_lifeTimer.Update(elapsed) && !_hasLife)
            {
                GenerateLife();
                _lifeTimer = new GameTimer(TimeSpan.FromSeconds(Game.Random.Next(20, 35)));
            }
            if (_timeTimer.Update(elapsed) && !_hasTime)
            {
                GenerateTime();
                _timeTimer = new GameTimer(TimeSpan.FromSeconds(Game.Random.Next(10, 20)));
            }
            if (_scoresTimer.Update(elapsed) && !_hasScores)
            {
                GenerateScores();
                _scoresTimer = new GameTimer(TimeSpan.FromSeconds(Game.Random.Next(10, 20)));
            }
        }

        private ScoresBonus GenerateScores()
        {
            var bonus = new ScoresBonus(Game, GenerateRandomPositionOnPlayground());
            bonus.Disposed += (sender, args) => _hasScores = false;
            _hasScores = true;
            Game.GameObjectCollection.Add(bonus);
            return bonus;
        }

        private Accelerator GenerateAccelerator()
        {
            var bonus = new Accelerator(Game, GenerateRandomPositionOnPlayground());
            bonus.Disposed += (sender, args) => _hasAccelerator = false;
            _hasAccelerator = true;
            Game.GameObjectCollection.Add(bonus);
            return bonus;
        }

        private LifeBonus GenerateLife()
        {
            var bonus = new LifeBonus(Game, GenerateRandomPositionOnPlayground());
            bonus.Disposed += (sender, args) => _hasLife = false;
            _hasLife = true;
            Game.GameObjectCollection.Add(bonus);
            return bonus;
        }

        private TimeBonus GenerateTime()
        {
            var bonus = new TimeBonus(Game, GenerateRandomPositionOnPlayground());
            bonus.Disposed += (sender, args) => _hasTime = false;
            _hasTime = true;
            Game.GameObjectCollection.Add(bonus);
            return bonus;
        }

        private Vector2 GenerateRandomPositionOnPlayground()
        {
            Playground pg = Game.Level.Playground;
            return pg.Position +
                   new Vector2(50 + Game.Random.Next((int) pg.Width - 100),
                               50 + Game.Random.Next((int) pg.Height - 100));
        }
    }
}