using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typing_Tutor
{
    public partial class LevelsForm : Form
    {
        private bool _levelSelected;
        public LevelsForm()
        {
            InitializeComponent();
        }

        private void LevelsForm_Load(object sender, EventArgs e)
        {
            var levels = Levels.GetInstance().LevelList;
            foreach (var level in levels)
            {
                var stat = ProgrammEngine.GetInstance().Progress.GetStatistics(level);
                string title = level.Title;
                if (stat != null)
                {
                    title += " " + "Пройден!";
                }
                levelsListBox.Items.Add(title);
            }
        }

        public event EventHandler<EventArgs<Level>> LevelSelected;

        protected virtual void OnLevelSelected(EventArgs<Level> e)
        {
            EventHandler<EventArgs<Level>> handler = LevelSelected;
            if (handler != null) handler(this, e);
        }

        private void levelsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = levelsListBox.SelectedIndex;
            var level = Levels.GetInstance().Get(index + 1);
            if (level != null)
                SelectAccount(level);
        }

        private void SelectAccount(Level level)
        {
            OnLevelSelected(new EventArgs<Level>(level));
            _levelSelected = true;
            Dispose();
        }

        private void LevelsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_levelSelected)
                ProgrammEngine.CloseProgram();
        }
    }
}
