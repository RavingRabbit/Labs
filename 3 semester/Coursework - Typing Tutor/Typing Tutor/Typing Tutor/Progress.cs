using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typing_Tutor
{
    [Serializable]
    public class Progress
    {
        private readonly Dictionary<Level, LevelStatistics> _levelStatisticses;

        public Progress()
        {
            _levelStatisticses = new Dictionary<Level, LevelStatistics>();
        }

        public Level QurrentLevel
        {
            get
            {
                {
                    int lastComplitedLevelNumber;
                    if (_levelStatisticses.Keys.Any())
                    {
                        lastComplitedLevelNumber = _levelStatisticses.Keys.Max(level => level.LevelNumber);
                    }
                    else
                    {
                        lastComplitedLevelNumber = 0;
                    }
                    return Levels.GetInstance().Get(lastComplitedLevelNumber + 1);
                }
            }
        }

        public void AddStatistics(LevelStatistics statistics)
        {
            if (statistics == null)
                throw new ArgumentNullException("statistics");
            if (!statistics.Complited)
                throw new Exception("Level is not complited.");
            if (_levelStatisticses.ContainsKey(statistics.Level))
            {
                if (_levelStatisticses[statistics.Level].TypingSpeed < statistics.TypingSpeed)
                    _levelStatisticses[statistics.Level] = statistics;
            }
            else
            {
                _levelStatisticses[statistics.Level] = statistics;
            }
        }

        public LevelStatistics GetStatistics(Level level)
        {
            if (level == null)
                throw new ArgumentNullException("level");
            return _levelStatisticses.ContainsKey(level) ? _levelStatisticses[level] : null;
        }
    }
}
