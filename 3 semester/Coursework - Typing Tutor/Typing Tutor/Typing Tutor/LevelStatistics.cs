using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typing_Tutor.Properties;

namespace Typing_Tutor
{
    [Serializable]
    public class LevelStatistics
    {
        private readonly Level _level;
        private readonly int _errorsNumber;
        private readonly TypingSpeed _typingSpeed;
        private readonly bool _complited;

        public LevelStatistics(Level level, int errorsNumber, TypingSpeed typingSpeed, bool complited)
        {
            if (level == null)
                throw new ArgumentNullException("level");
            if (errorsNumber < 0)
                throw new ArgumentException(Resources.Level_Invalid_maxErrorsNumber_ExceptionMsg, "errorsNumber");
            if (typingSpeed == null)
                throw new ArgumentNullException("typingSpeed");
            _level = level;
            _errorsNumber = errorsNumber;
            _typingSpeed = typingSpeed;
            _complited = complited;
        }

        public Level Level { get { return _level; } }

        public int ErrorsNumber { get { return _errorsNumber; } }

        public TypingSpeed TypingSpeed { get { return _typingSpeed; } }

        public bool Complited { get { return _complited; } }
    }
}
