using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SupportTypes;
using XonixGame.Bonuses;
using XonixGame.GameObjectsBase;
using XonixGame.GameObjects;

namespace XonixGame.GameObjects
{
    class FireworkGenerator : GameObject
    {
        private GameTimer _timer;

        public FireworkGenerator(IGame game) : base(game)
        {
            _timer = new GameTimer(TimeSpan.FromMilliseconds(250));
        }

        public override void Update(TimeSpan elapsed)
        {
            if (_timer.Update((elapsed)))
            {
                _timer = new GameTimer(TimeSpan.FromMilliseconds(Game.Random.Next(250, 850)));
                var position = GenerateRandomPositionOnPlayground();
                var index = Game.Random.Next(6); 
                if (index == 0)
                    Game.GameObjectCollection.Add(new ExplodedObject(new Accelerator(Game, position), 8, 13,13,6));
                if (index == 1)
                    Game.GameObjectCollection.Add(new ExplodedObject(new LifeBonus(Game, position), 8, 13, 13, 6));
                if (index == 2)
                    Game.GameObjectCollection.Add(new ExplodedObject(new TimeBonus(Game, position), 8, 13, 13, 6));
                if (index == 3)
                    Game.GameObjectCollection.Add(new ExplodedObject(new SoftBall(Game, position), 8, 13, 13, 6));
                if (index == 4)
                    Game.GameObjectCollection.Add(new ExplodedObject(new HardBall(Game, position), 8, 13, 13, 6));
                if (index == 5)
                    Game.GameObjectCollection.Add(new ExplodedObject(new MainDevice(Game, position), 8, 13, 13, 6));
                
            }
            base.Update(elapsed);
        }

        private Vector2 GenerateRandomPositionOnPlayground()
        {
            Playground pg = Game.Level.Playground;
            return pg.Position +
                   new Vector2(50 + Game.Random.Next((int)pg.Width - 100),
                               50 + Game.Random.Next((int)pg.Height - 100));
        }
    }
}
