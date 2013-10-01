namespace XonixGame.GameSettings
{
    internal interface IScreenSettings
    {
        bool IsFullScreen { get; }

        bool SynchronizeWithVerticalRetrace { get; }

        int Width { get; }

        int Height { get; }
    }
}