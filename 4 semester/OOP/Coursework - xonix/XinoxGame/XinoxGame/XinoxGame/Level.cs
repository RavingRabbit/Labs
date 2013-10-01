using System;
using UtilLib;
using XonixGame.GameObjects;
using XonixGame.GameObjects;

namespace XonixGame
{
    [Serializable]
    public class Level
    {
        private readonly int _hardBalls;
        private readonly int _levelNumber;
        private readonly int _mines;
        private readonly Playground _playground;
        private readonly int _softBalls;
        private readonly int _startLifes;

        public Level(Playground playground, int levelNumber, int startLifes, int hardBalls, int softBalls, int mines)
        {
            Requires.Range(levelNumber > 0, "levelNumber");
            Requires.Range(startLifes > 0, "startLifes");
            Requires.Range(hardBalls >= 0, "hardBalls");
            Requires.Range(softBalls >= 0, "softBalls");
            Requires.Range(mines >= 0, "mines");
            _playground = playground;
            _levelNumber = levelNumber;
            _startLifes = startLifes;
            _hardBalls = hardBalls;
            _softBalls = softBalls;
            _mines = mines;
        }

        public Playground Playground
        {
            get { return _playground; }
        }

        public int StartLifes
        {
            get { return _startLifes; }
        }

        public int LevelNumber
        {
            get { return _levelNumber; }
        }

        public int HardBalls
        {
            get { return _hardBalls; }
        }

        public int SoftBalls
        {
            get { return _softBalls; }
        }

        public int Mines
        {
            get { return _mines; }
        }
    }
}