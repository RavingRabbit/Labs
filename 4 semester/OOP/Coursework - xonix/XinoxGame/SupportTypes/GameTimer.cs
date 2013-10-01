using System;

namespace SupportTypes
{
    public class GameTimer
    {
        private readonly TimeSpan _period;
        private TimeSpan _timeLeft;

        public GameTimer(TimeSpan period)
        {
            _period = period;
            _timeLeft = new TimeSpan(_period.Ticks);
        }

        public static GameTimer OneSecond
        {
            get { return new GameTimer(TimeSpan.FromSeconds(1)); }
        }

        public bool Update(TimeSpan elapsed)
        {
            _timeLeft -= elapsed;
            if (_timeLeft > TimeSpan.Zero)
                return false;
            _timeLeft = _period;
            return true;
        }
    }
}