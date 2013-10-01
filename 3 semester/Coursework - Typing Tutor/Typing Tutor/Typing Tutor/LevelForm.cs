using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Typing_Tutor
{
    public partial class LevelForm : Form
    {
        private readonly LevelEngine _levelEngine;
        private int _elapsed;
        private System.Threading.Timer _timer;

        public LevelForm(Level level)
        {
            InitializeComponent();
            if (level == null)
                throw new ArgumentNullException("level");
            _levelEngine = new LevelEngine(level);
            _levelEngine.CharEntered += (sender, args) => inputTextBox.Text += args.EventInfo;
            _levelEngine.ErrorCharEntered += (sender, args) =>
                {
                    currentCharLabel.ForeColor = Color.Red;
                    MessageBox.Show("Опечатка!");
                };
            _levelEngine.ErrorCharEntered += (sender, args) =>
                {
                    errorsLabel.Text = _levelEngine.ErrorsNumber.ToString(CultureInfo.InvariantCulture);
                };
            _levelEngine.Finished += OnLevelFinished;
            lavelLabel.Text = level.LevelNumber.ToString(CultureInfo.InvariantCulture);
            maxErrorsNumberLabel.Text = level.MaxErrorsNumber.ToString(CultureInfo.InvariantCulture);
            minTypingSpeedLabel.Text = level.MinTypingSpeed.ToString();
        }

        public void OnLevelFinished(object sender, EventArgs<LevelStatistics> args)
        {
            var stat = args.EventInfo;
            inputTextBox.Enabled = false;
            if (_timer != null)
                _timer.Dispose();
            if (!stat.Complited)
            {
                MessageBox.Show("Средняя скорость печати: " + stat.TypingSpeed +
                "; опечаток: " + stat.ErrorsNumber + ". Попробуйте ещё раз.");
                inputTextBox.Clear();
                timeLabel.Text = "0";
                errorsLabel.Text = "0";
                _elapsed = 0;
                _levelEngine.Reset();
            }
            else
            {
                MessageBox.Show("Средняя скорость печати: " + stat.TypingSpeed +
                "; опечаток: " + stat.ErrorsNumber);
                OnLevelFinished(args);
                Dispose();
            }
        }

        private void LevelForm_Load(object sender, EventArgs e)
        {
            Text = "Уровень " + _levelEngine.Level.LevelNumber;
        }

        public event EventHandler<EventArgs<LevelStatistics>> LevelFinished;

        public void OnLevelFinished(EventArgs<LevelStatistics> e)
        {
            var handler = LevelFinished;
            if (handler != null) handler(this, e);
        }

        private void startButtonClick(object sender, EventArgs e)
        {
            taskTextBox.Text = _levelEngine.Level.Text;
            inputTextBox.Enabled = true;
            if (_timer != null)
            {
                _timer.Dispose();
                _elapsed = 0;
                _levelEngine.Reset();
            }
            _levelEngine.Start();
            currentCharLabel.Text = _levelEngine.CurrentChar.ToString(CultureInfo.InvariantCulture);
            _timer =
                new System.Threading.Timer(
                    state =>
                    timeLabel.Invoke(
                        new Action<object>(o =>
                            {
                                timeLabel.Text = (++_elapsed).ToString(CultureInfo.InvariantCulture);
                            }), 1), null, 1000, 1000);
            inputTextBox.Focus();
        }

        private void inputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_levelEngine.EnterChar(e.KeyChar))
            {
                currentCharLabel.ForeColor = Color.Black;
            }
            else
            {
                currentCharLabel.ForeColor = Color.Red;
            }
            var currentChar = _levelEngine.CurrentChar;
            currentCharLabel.Text = currentChar == ' ' ? "_" : currentChar.ToString(CultureInfo.InvariantCulture);
        }

        private void LevelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_timer != null)
                _timer.Dispose();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
