using System;
using SupportTypes;

namespace XonixGame.Diagnostics
{
    internal class FpsCounter
    {
        private readonly GameTimer _fpsTimer = GameTimer.OneSecond;
        private int _currentFps;

        public int FPS { get; private set; }

        public void Update(TimeSpan elapsed)
        {
            if (!_fpsTimer.Update(elapsed))
                _currentFps++;
            else
            {
                FPS = ++_currentFps;
                _currentFps = 0;
            }
        }
    }
}