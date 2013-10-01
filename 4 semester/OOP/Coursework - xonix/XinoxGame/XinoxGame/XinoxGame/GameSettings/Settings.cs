using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Input;
using UtilLib;

namespace XonixGame.GameSettings
{
    public class Settings : IKeyboardSettings, IScreenSettings, IGameObjectsSettings
    {
        private const string DefaultFileName = "settings.xml";
        private static Settings _defaultSettings;
        private static volatile Settings _instance;
        private static readonly object Locker = new object();

        public static Settings Instance
        {
            get
            {
                try
                {
                    if (_instance == null)
                    {
                        lock (Locker)
                        {
                            if (_instance == null)
                            {
                                _instance = Load();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    _instance = Default;
                }
                return _instance;
            }
        }

        public static void SetSettings(Settings settings)
        {
            Requires.NotNull(settings, "settings");
            _instance = settings;
        }

        #region Default settings

        public static Settings Default
        {
            get
            {
                return _defaultSettings ?? (_defaultSettings = new Settings
                    {
                        MoveLeft = Keys.A,
                        MoveRight = Keys.D,
                        MoveUp = Keys.W,
                        MoveDown = Keys.S,
                        Exit = Keys.Escape,
                        Pause = Keys.P,
                        Cancel = Keys.Escape,
                        Confirm = Keys.Enter,
#if DEBUG
                        IsFullScreen = false,
                        Width = 1366,
                        Height = 768,
                        SynchronizeWithVerticalRetrace = true,
#else
                        IsFullScreen = true,
                        Width = 1366,
                        Height = 768,
                        SynchronizeWithVerticalRetrace = true,
#endif
                        PlaygroundBlockWidth = 8,
                        PlaygroundBlockHeight = 8
                    });
            }
        }

        public static IKeyboardSettings FirstPlayer
        {
            get
            {
                return new Settings
                    {
                        MoveLeft = Keys.A,
                        MoveRight = Keys.D,
                        MoveUp = Keys.W,
                        MoveDown = Keys.S,
                        Exit = Keys.Escape,
                        Pause = Keys.P,
                        Cancel = Keys.Escape,
                        Confirm = Keys.Enter,
                    };
            }
        }

        public static IKeyboardSettings SecondPlayer
        {
            get
            {
                return new Settings
                    {
                        MoveLeft = Keys.Left,
                        MoveRight = Keys.Right,
                        MoveUp = Keys.Up,
                        MoveDown = Keys.Down,
                        Exit = Keys.Escape,
                        Pause = Keys.P,
                        Cancel = Keys.Escape,
                        Confirm = Keys.Enter,
                    };
            }
        }

        #endregion

        #region Keyboard settings

        public Keys MoveLeft { get; set; }

        public Keys MoveRight { get; set; }

        public Keys MoveUp { get; set; }

        public Keys MoveDown { get; set; }

        public Keys Exit { get; set; }

        public Keys Pause { get; set; }

        public Keys Cancel { get; set; }

        public Keys Confirm { get; set; }

        #endregion

        #region Screen settings

        public bool IsFullScreen { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public bool SynchronizeWithVerticalRetrace { get; set; }

        #endregion

        #region Game Objects settings

        public int PlaygroundBlockWidth { get; set; }

        public int PlaygroundBlockHeight { get; set; }

        #endregion

        #region Save/Load

        public void Save()
        {
            Save(DefaultFileName);
        }

        public void Save(string filename)
        {
            using (FileStream stream = File.Create(filename))
            {
                var serializer = new XmlSerializer(typeof (Settings));
                serializer.Serialize(stream, this);
            }
        }

        public static Settings Load()
        {
            return Load(DefaultFileName);
        }

        public static Settings Load(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                var serializer = new XmlSerializer(typeof (Settings));
                return (Settings) serializer.Deserialize(stream);
            }
        }

        #endregion
    }
}