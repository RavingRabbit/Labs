using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using UtilLib;
using XonixGame.GameSettings;

namespace XonixGame
{
    public class KeyboardHelper
    {
        private readonly IKeyboardSettings _settings;
        private KeyboardState _previousKeyboardState;


        public KeyboardHelper(IKeyboardSettings settings)
        {
            Requires.NotNull(settings, "settings");
            _settings = settings;
        }

        public KeyboardHelper()
        {
            _settings = Settings.Default;
        }

        public bool MoveRight { get; private set; }
        public bool MoveLeft { get; private set; }
        public bool MoveUp { get; private set; }
        public bool MoveDown { get; private set; }
        public bool Exit { get; private set; }
        public bool Pause { get; private set; }
        public bool Resume { get; private set; }
        public bool Cancel { get; private set; }
        public bool Confirm { get; private set; }

        public void Update(KeyboardState keyboardState)
        {
            MoveRight = keyboardState.IsKeyDown(_settings.MoveRight);
            MoveLeft = keyboardState.IsKeyDown(_settings.MoveLeft);
            MoveUp = keyboardState.IsKeyDown(_settings.MoveUp);
            MoveDown = keyboardState.IsKeyDown(_settings.MoveDown);
            Exit = keyboardState.IsKeyDown(_settings.Exit);
            Cancel = keyboardState.IsKeyDown(_settings.Cancel);
            Confirm = keyboardState.IsKeyDown(_settings.Confirm);
            Pause = _previousKeyboardState.IsKeyUp(_settings.Pause) && keyboardState.IsKeyDown(_settings.Pause);
            Resume = keyboardState.GetPressedKeys().Where(key => !_previousKeyboardState.IsKeyDown(key)).Any();

            _previousKeyboardState = keyboardState;
        }

        public Vector2 GetDirection()
        {
            if (MoveUp)
                return new Vector2(0, -1);
            if (MoveDown)
                return new Vector2(0, 1);
            if (MoveRight)
                return new Vector2(1, 0);
            if (MoveLeft)
                return new Vector2(-1, 0);
            return Vector2.Zero;
        }
    }
}