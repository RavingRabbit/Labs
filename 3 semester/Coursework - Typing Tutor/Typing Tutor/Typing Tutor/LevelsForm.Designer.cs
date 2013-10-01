namespace Typing_Tutor
{
    partial class LevelsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleSelectLevelLabel = new System.Windows.Forms.Label();
            this.levelsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // titleSelectLevelLabel
            // 
            this.titleSelectLevelLabel.AutoSize = true;
            this.titleSelectLevelLabel.Location = new System.Drawing.Point(8, 14);
            this.titleSelectLevelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleSelectLevelLabel.Name = "titleSelectLevelLabel";
            this.titleSelectLevelLabel.Size = new System.Drawing.Size(154, 20);
            this.titleSelectLevelLabel.TabIndex = 0;
            this.titleSelectLevelLabel.Text = "Выберите уровень:";
            // 
            // levelsListBox
            // 
            this.levelsListBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.levelsListBox.FormattingEnabled = true;
            this.levelsListBox.ItemHeight = 20;
            this.levelsListBox.Location = new System.Drawing.Point(12, 37);
            this.levelsListBox.Name = "levelsListBox";
            this.levelsListBox.Size = new System.Drawing.Size(311, 204);
            this.levelsListBox.TabIndex = 1;
            this.levelsListBox.SelectedIndexChanged += new System.EventHandler(this.levelsListBox_SelectedIndexChanged);
            // 
            // LevelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 258);
            this.Controls.Add(this.levelsListBox);
            this.Controls.Add(this.titleSelectLevelLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LevelsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Уровни";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LevelsForm_FormClosed);
            this.Load += new System.EventHandler(this.LevelsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleSelectLevelLabel;
        private System.Windows.Forms.ListBox levelsListBox;
    }
}