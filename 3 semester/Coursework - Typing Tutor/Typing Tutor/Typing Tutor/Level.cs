using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Typing_Tutor.Properties;

namespace Typing_Tutor
{
    [Serializable]
    public class Level : IEquatable<Level>
    {
        private readonly string _text;
        private readonly int _maxErrorsNumber;
        private readonly TypingSpeed _minTypingSpeed;
        [OptionalField]
        private readonly string _name;

        public Level(string text, int maxErrorsNumber, TypingSpeed minTypingSpeed, string name)
        {
            if (text == null)
                throw new ArgumentNullException("text");
            if (maxErrorsNumber < 0)
                throw new ArgumentException(Resources.Level_Invalid_maxErrorsNumber_ExceptionMsg, "maxErrorsNumber");
            if (minTypingSpeed == null)
                throw new ArgumentNullException("minTypingSpeed");
            _text = text;
            _maxErrorsNumber = maxErrorsNumber;
            _minTypingSpeed = minTypingSpeed;
            _name = name;
        }

        public int LevelNumber { get; private set; }

        public string Text
        {
            get { return _text; }
        }

        public int MaxErrorsNumber
        {
            get { return _maxErrorsNumber; }
        }

        public TypingSpeed MinTypingSpeed
        {
            get { return _minTypingSpeed; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Title
        {
            get
            {
                var title = string.Format("Уровень {0}.", LevelNumber);
                if (!string.IsNullOrWhiteSpace(_name))
                    title += " " + _name + ".";
                return title;
            }
        }

        internal void SetLevelNumber(int levelNumber)
        {
            LevelNumber = levelNumber;
        }

        public override int GetHashCode()
        {
            return _text.GetHashCode();
        }

        public bool Equals(Level other)
        {
            if (other == null)
                throw new ArgumentNullException("other");
            return other.Text == Text && other.LevelNumber == LevelNumber;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Level);
        }
    }
}
