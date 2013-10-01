using Microsoft.Xna.Framework.Input;

namespace XonixGame.GameSettings
{
    public interface IKeyboardSettings
    {
        Keys MoveLeft { get; }

        Keys MoveRight { get; }

        Keys MoveUp { get; }

        Keys MoveDown { get; }

        Keys Exit { get; }

        Keys Pause { get; }

        Keys Cancel { get; }

        Keys Confirm { get; }
    }
}