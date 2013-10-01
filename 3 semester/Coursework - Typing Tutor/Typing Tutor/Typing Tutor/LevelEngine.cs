using System;
using System.Collections.Generic;
using System.Linq;

namespace Typing_Tutor
{
    class LevelEngine
    {
        private readonly Level _level;
        private int _errorsNumber;
        private DateTime _startTime;
        private DateTime _finishTime;
        private bool _finished;
        private Queue<char> _charsForTyping; 

        public LevelEngine(Level level)
        {
            if (level == null)
                throw new ArgumentNullException("level");
            _level = level;
        }

        public Level Level { get { return _level; } }

        public char CurrentChar
        {
            get { return _charsForTyping.Count != 0 ? _charsForTyping.Peek() : ' '; }
        }

        public int ErrorsNumber { get { return _errorsNumber; } }

        public void Start()
        {
            _charsForTyping = new Queue<char>(_level.Text.ToList());
            _startTime = DateTime.Now;
        }

        public bool EnterChar(char symble)
        {
            if (_finished)
                throw new Exception("Level already finished. You need to restart it.");
            if (symble == CurrentChar)
            {
                RightCharEnteret(symble);
                return true;
            }
            WrongCharEntered(symble);
            return false;
        }

        private void RightCharEnteret(char symble)
        {
            OnCharEntered(new EventArgs<char>(symble));
            MoveToNextChar();
        }

        private void MoveToNextChar()
        {
            _charsForTyping.Dequeue();
            if (!_charsForTyping.Any())
                Finish();
        }

        private void WrongCharEntered(char symble)
        {
            _errorsNumber++;
            OnErrorCharEntered(new EventArgs<char>(symble));
            if (_errorsNumber > _level.MaxErrorsNumber)
                Finish();
        }

        public void Reset()
        {
            _errorsNumber = 0;
            _finished = false;
        }

        private void Finish()
        {
            _finished = true;
            _finishTime = DateTime.Now;
            var elapsedTime = _finishTime - _startTime;
            var typingSpeed = new TypingSpeed(_level.Text.Length, elapsedTime);
            var isSucceed = _errorsNumber <= _level.MaxErrorsNumber && typingSpeed >= _level.MinTypingSpeed;
            var levelStatistics = new LevelStatistics(_level, _errorsNumber, typingSpeed, isSucceed);
            OnFinished(new EventArgs<LevelStatistics>(levelStatistics));
        }

        public event EventHandler<EventArgs<char>> CharEntered;

        public void OnCharEntered(EventArgs<char> e)
        {
            var handler = CharEntered;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<EventArgs<char>> ErrorCharEntered;

        public void OnErrorCharEntered(EventArgs<char> e)
        {
            var handler = ErrorCharEntered;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<EventArgs<LevelStatistics>> Finished;

        public void OnFinished(EventArgs<LevelStatistics> e)
        {
            var handler = Finished;
            if (handler != null) handler(this, e);
        }
    }
}
