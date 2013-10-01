using System;
using System.Windows.Forms;

namespace Typing_Tutor
{
    public static class Program
    {
        private static ProgrammEngine _gameEngine;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            _gameEngine = ProgrammEngine.GetInstance();
            var userAccount = _gameEngine.RequestUserAccount();
            _gameEngine.SetUserAccount(userAccount);
            while (true)
            {
                var level = _gameEngine.RequestLevel();
                if (level != null)
                    _gameEngine.PlayLevel(level);
            }
        }
    }
}