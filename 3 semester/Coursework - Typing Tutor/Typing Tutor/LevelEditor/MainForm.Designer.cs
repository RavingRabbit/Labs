namespace LevelEditor
{
    partial class MainForm
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
            this.levelsListBox = new System.Windows.Forms.ListBox();
            this.titleSelectLevelLabel = new System.Windows.Forms.Label();
            this.addLevelButton = new System.Windows.Forms.Button();
            this.removeLevelButton = new System.Windows.Forms.Button();
            this.editLevelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // levelsListBox
            // 
            this.levelsListBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.levelsListBox.FormattingEnabled = true;
            this.levelsListBox.ItemHeight = 20;
            this.levelsListBox.Location = new System.Drawing.Point(18, 34);
            this.levelsListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.levelsListBox.Name = "levelsListBox";
            this.levelsListBox.Size = new System.Drawing.Size(334, 304);
            this.levelsListBox.TabIndex = 3;
            // 
            // titleSelectLevelLabel
            // 
            this.titleSelectLevelLabel.AutoSize = true;
            this.titleSelectLevelLabel.Location = new System.Drawing.Point(14, 9);
            this.titleSelectLevelLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.titleSelectLevelLabel.Name = "titleSelectLevelLabel";
            this.titleSelectLevelLabel.Size = new System.Drawing.Size(154, 20);
            this.titleSelectLevelLabel.TabIndex = 2;
            this.titleSelectLevelLabel.Text = "Выберите уровень:";
            // 
            // addLevelButton
            // 
            this.addLevelButton.Location = new System.Drawing.Point(18, 346);
            this.addLevelButton.Name = "addLevelButton";
            this.addLevelButton.Size = new System.Drawing.Size(98, 30);
            this.addLevelButton.TabIndex = 4;
            this.addLevelButton.Text = "Добавить";
            this.addLevelButton.UseVisualStyleBackColor = true;
            this.addLevelButton.Click += new System.EventHandler(this.addLevelButton_Click);
            // 
            // removeLevelButton
            // 
            this.removeLevelButton.Location = new System.Drawing.Point(122, 346);
            this.removeLevelButton.Name = "removeLevelButton";
            this.removeLevelButton.Size = new System.Drawing.Size(86, 30);
            this.removeLevelButton.TabIndex = 5;
            this.removeLevelButton.Text = "Удалить";
            this.removeLevelButton.UseVisualStyleBackColor = true;
            this.removeLevelButton.Click += new System.EventHandler(this.removeLevelButton_Click);
            // 
            // editLevelButton
            // 
            this.editLevelButton.Location = new System.Drawing.Point(214, 345);
            this.editLevelButton.Name = "editLevelButton";
            this.editLevelButton.Size = new System.Drawing.Size(138, 30);
            this.editLevelButton.TabIndex = 6;
            this.editLevelButton.Text = "Редактировать";
            this.editLevelButton.UseVisualStyleBackColor = true;
            this.editLevelButton.Click += new System.EventHandler(this.editLevelButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 391);
            this.Controls.Add(this.editLevelButton);
            this.Controls.Add(this.removeLevelButton);
            this.Controls.Add(this.addLevelButton);
            this.Controls.Add(this.levelsListBox);
            this.Controls.Add(this.titleSelectLevelLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Редактор уровней";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox levelsListBox;
        private System.Windows.Forms.Label titleSelectLevelLabel;
        private System.Windows.Forms.Button addLevelButton;
        private System.Windows.Forms.Button removeLevelButton;
        private System.Windows.Forms.Button editLevelButton;
    }
}

