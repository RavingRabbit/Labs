using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XonixGame.GameObjectsBase;
using XonixGame.GameSettings;

namespace XonixGame.GameObjects
{
    internal class StatisticsPanel : DrawableGameObject
    {
        private const int Offset = 15;
        private readonly SpriteFont _statFont;
        private readonly SpriteFont _titlesFont;
        private int _completed;

        public StatisticsPanel(IGame game) : base(game)
        {
            _statFont = game.ContentProvider.GetFont(1);
            _titlesFont = game.ContentProvider.GetFont(2);
            Game.Level.Playground.Completed += (sender, args) =>
                {
                    Complete = true;
                };
        }

        public bool Complete { get; set; }

        public bool TryAgain { get; set; }

        public bool TimeSpent { get; set; }

        public bool LastLifeSpent { get; set; }

        public override Vector2 Position
        {
            get { return Vector2.Zero; }
            set { throw new NotSupportedException(); }
        }

        public override float Width
        {
            get { return Settings.Instance.Width; }
        }

        public override float Height
        {
            get { return Settings.Instance.Height; }
        }

        public override void Update(TimeSpan elapsed)
        {
            _completed = Game.Level.Playground.GroundBlocksNumber*100/Game.Level.Playground.BlocksNumber;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            string title = string.Format("Level: {0} ({1}%)", Game.Level.LevelNumber, _completed);
            spriteBatch.DrawString(_statFont, title,
                                   new Vector2(Offset,
                                               Settings.Instance.Height - _statFont.MeasureString(title).Y - Offset),
                                   Color.Wheat);
            title = string.Format("Lifes: {0}", Game.Lifes);
            spriteBatch.DrawString(_statFont, title, new Vector2(Offset, Offset), Color.Wheat);
            title = string.Format("Time: {0}", (int)Game.TimeLeft.TotalSeconds);
            spriteBatch.DrawString(_statFont, title,
                                   new Vector2(Settings.Instance.Width - Offset - _statFont.MeasureString(title).X,
                                               Offset),
                                   Color.Wheat);
            title = string.Format("Scores: {0}", Game.Scores);
            spriteBatch.DrawString(_statFont, title,
                                   new Vector2(Settings.Instance.Width - Offset - _statFont.MeasureString(title).X,
                                               Settings.Instance.Height - Offset - _statFont.MeasureString(title).Y),
                                   Color.Wheat);
            if (Complete && !Game.Completed)
                spriteBatch.DrawString(_titlesFont, "Complete!",
                                       new Vector2(
                                           (Settings.Instance.Width - _titlesFont.MeasureString("Complete!").X) / 2,
                                           (float) Settings.Instance.Height/2),
                                       Color.Red);
            if (Game.Completed)
            {
                spriteBatch.DrawString(_titlesFont, "Congratulate!",
                                       new Vector2(
                                           (Settings.Instance.Width - _titlesFont.MeasureString("Congratulate!").X) / 2,
                                           (float)Settings.Instance.Height / 2),
                                       Color.Red);
                title = string.Format("Your scores: {0}", Game.Scores);
                spriteBatch.DrawString(_statFont, title,
                                       new Vector2((float)Settings.Instance.Width/2 - _statFont.MeasureString(title).X/2,
                                                   Settings.Instance.Height/2 - Offset - _statFont.MeasureString(title).Y/2 + 100),
                                       Color.Red);
            }
            if (TryAgain)
                spriteBatch.DrawString(_titlesFont, "Try again!",
                                       new Vector2(
                                           (Settings.Instance.Width - _titlesFont.MeasureString("Try again!").X)/2,
                                           (float) Settings.Instance.Height/2),
                                       Color.Red);
            if (TimeSpent)
                spriteBatch.DrawString(_titlesFont, "Time spent :(",
                                       new Vector2(
                                           (Settings.Instance.Width - _titlesFont.MeasureString("Time spent :(").X)/2,
                                           (float) Settings.Instance.Height/2 -
                                           _titlesFont.MeasureString("Time spent :(").Y - 10),
                                       Color.Red);
            if (LastLifeSpent)
                spriteBatch.DrawString(_titlesFont, "Last life spent :(",
                                       new Vector2(
                                           (Settings.Instance.Width - _titlesFont.MeasureString("Last life spent :(").X)/
                                           2,
                                           (float) Settings.Instance.Height/2 -
                                           _titlesFont.MeasureString("Last life spent :(").Y - 10),
                                       Color.Red);
        }
    }
}