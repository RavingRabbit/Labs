using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Typing_Tutor;

namespace LevelEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Levels.Deserialize();
            var levels = Levels.GetInstance().LevelList;
            foreach (var level in levels)
            {
                levelsListBox.Items.Add(level.Title);
            }
        }

        private void Refresh()
        {
            levelsListBox.Items.Clear();
            var levels = Levels.GetInstance().LevelList;
            foreach (var level in levels)
            {
                levelsListBox.Items.Add(level.Title);
            }
        }

        private void addLevelButton_Click(object sender, EventArgs e)
        {
            var levelForm = new LevelForm(null);
            Level newLevel = null;
            levelForm.LevelCreated += (o, args) => newLevel = args.EventInfo;
            levelForm.ShowDialog();
            if (newLevel != null)
            {
                Levels.GetInstance().Add(newLevel);
                //levelsListBox.Items.Add(newLevel.Title);
            }
            Refresh();
        }

        private void removeLevelButton_Click(object sender, EventArgs e)
        {
            var title = levelsListBox.SelectedItem.ToString();
            var level = Levels.GetInstance().LevelList.Find(level1 => level1.Title == title);
            if (level != null)
            {
                Levels.GetInstance().Remove(level);
                //levelsListBox.Items.Remove(levelsListBox.SelectedItem);
            }
            Refresh();
        }

        private void editLevelButton_Click(object sender, EventArgs e)
        {
            var title = levelsListBox.SelectedItem.ToString();
            var level = Levels.GetInstance().LevelList.Find(level1 => level1.Title == title);
            if (level != null)
            {
                var levelForm = new LevelForm(level);
                Level newLevel = null;
                levelForm.LevelCreated += (o, args) => newLevel = args.EventInfo;
                levelForm.ShowDialog();
                if (newLevel != null)
                {
                    Levels.GetInstance().Replace(level, newLevel);
                }
            }
            Refresh();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Levels.Serialize();
        }
    }
}
