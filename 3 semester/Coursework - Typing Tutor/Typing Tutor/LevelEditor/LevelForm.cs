using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Typing_Tutor;

namespace LevelEditor
{
    public partial class LevelForm : Form
    {
        public LevelForm(Level level)
        {
            InitializeComponent();
            if (level != null)
            {
                textTextBox.Text = level.Text;
                errorsTextBox.Text = level.MaxErrorsNumber.ToString(CultureInfo.InvariantCulture);
                typingSpeedTextBox.Text = level.MinTypingSpeed.SymblesPerMinute.ToString(CultureInfo.InvariantCulture);
                if (!string.IsNullOrWhiteSpace(level.Name))
                    levelNameTextBox.Text = level.Name;
            }
        }

        private void LevelForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = textTextBox.Text;
            int errorsNumber;
            if (!int.TryParse(errorsTextBox.Text, out errorsNumber) || errorsNumber < 0)
            {
                MessageBox.Show("Количество ошибок - целое неотрицательное число.");
                return;
            }
            int ts;
            if (!int.TryParse(typingSpeedTextBox.Text, out ts) || ts < 0)
            {
                MessageBox.Show("Скорость печати - целое неотрицательное число.");
                return;
            }
            var typingSpeed = new TypingSpeed(ts);
            var name = levelNameTextBox.Text;
            var level = new Level(text, errorsNumber, typingSpeed, name);
            OnLevelCreated(new EventArgs<Level>(level));
            Dispose();
        }

        public event EventHandler<EventArgs<Level>> LevelCreated;

        protected virtual void OnLevelCreated(EventArgs<Level> e)
        {
            EventHandler<EventArgs<Level>> handler = LevelCreated;
            if (handler != null) handler(this, e);
        }
    }
}
