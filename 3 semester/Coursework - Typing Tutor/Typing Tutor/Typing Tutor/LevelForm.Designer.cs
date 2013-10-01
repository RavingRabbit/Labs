namespace Typing_Tutor
{
    partial class LevelForm
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
            this.taskTextBox = new System.Windows.Forms.TextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.titleTimeLabel = new System.Windows.Forms.Label();
            this.titleErrorsLabel = new System.Windows.Forms.Label();
            this.errorsLabel = new System.Windows.Forms.Label();
            this.titleLevelLabel = new System.Windows.Forms.Label();
            this.lavelLabel = new System.Windows.Forms.Label();
            this.titleMaxErrorsNumberLabel = new System.Windows.Forms.Label();
            this.titleMinTypingSpeedLabel = new System.Windows.Forms.Label();
            this.maxErrorsNumberLabel = new System.Windows.Forms.Label();
            this.minTypingSpeedLabel = new System.Windows.Forms.Label();
            this.currentCharLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // taskTextBox
            // 
            this.taskTextBox.Enabled = false;
            this.taskTextBox.Location = new System.Drawing.Point(13, 36);
            this.taskTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.taskTextBox.Multiline = true;
            this.taskTextBox.Name = "taskTextBox";
            this.taskTextBox.ReadOnly = true;
            this.taskTextBox.Size = new System.Drawing.Size(463, 154);
            this.taskTextBox.TabIndex = 0;
            // 
            // inputTextBox
            // 
            this.inputTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.inputTextBox.Enabled = false;
            this.inputTextBox.Location = new System.Drawing.Point(13, 238);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ReadOnly = true;
            this.inputTextBox.Size = new System.Drawing.Size(463, 154);
            this.inputTextBox.TabIndex = 1;
            this.inputTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputTextBox_KeyPress);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(13, 200);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(463, 28);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButtonClick);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(561, 241);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(18, 20);
            this.timeLabel.TabIndex = 3;
            this.timeLabel.Text = "0";
            // 
            // titleTimeLabel
            // 
            this.titleTimeLabel.AutoSize = true;
            this.titleTimeLabel.Location = new System.Drawing.Point(482, 241);
            this.titleTimeLabel.Name = "titleTimeLabel";
            this.titleTimeLabel.Size = new System.Drawing.Size(62, 20);
            this.titleTimeLabel.TabIndex = 4;
            this.titleTimeLabel.Text = "Время:";
            // 
            // titleErrorsLabel
            // 
            this.titleErrorsLabel.AutoSize = true;
            this.titleErrorsLabel.Location = new System.Drawing.Point(482, 270);
            this.titleErrorsLabel.Name = "titleErrorsLabel";
            this.titleErrorsLabel.Size = new System.Drawing.Size(73, 20);
            this.titleErrorsLabel.TabIndex = 5;
            this.titleErrorsLabel.Text = "Ошибок:";
            // 
            // errorsLabel
            // 
            this.errorsLabel.AutoSize = true;
            this.errorsLabel.Location = new System.Drawing.Point(561, 270);
            this.errorsLabel.Name = "errorsLabel";
            this.errorsLabel.Size = new System.Drawing.Size(18, 20);
            this.errorsLabel.TabIndex = 6;
            this.errorsLabel.Text = "0";
            // 
            // titleLevelLabel
            // 
            this.titleLevelLabel.AutoSize = true;
            this.titleLevelLabel.Location = new System.Drawing.Point(11, 9);
            this.titleLevelLabel.Name = "titleLevelLabel";
            this.titleLevelLabel.Size = new System.Drawing.Size(77, 20);
            this.titleLevelLabel.TabIndex = 7;
            this.titleLevelLabel.Text = "Уровень:";
            // 
            // lavelLabel
            // 
            this.lavelLabel.AutoSize = true;
            this.lavelLabel.Location = new System.Drawing.Point(88, 9);
            this.lavelLabel.Name = "lavelLabel";
            this.lavelLabel.Size = new System.Drawing.Size(18, 20);
            this.lavelLabel.TabIndex = 8;
            this.lavelLabel.Text = "0";
            // 
            // titleMaxErrorsNumberLabel
            // 
            this.titleMaxErrorsNumberLabel.AutoSize = true;
            this.titleMaxErrorsNumberLabel.Location = new System.Drawing.Point(129, 9);
            this.titleMaxErrorsNumberLabel.Name = "titleMaxErrorsNumberLabel";
            this.titleMaxErrorsNumberLabel.Size = new System.Drawing.Size(150, 20);
            this.titleMaxErrorsNumberLabel.TabIndex = 9;
            this.titleMaxErrorsNumberLabel.Text = "Максимум ошибок:";
            // 
            // titleMinTypingSpeedLabel
            // 
            this.titleMinTypingSpeedLabel.AutoSize = true;
            this.titleMinTypingSpeedLabel.Location = new System.Drawing.Point(328, 9);
            this.titleMinTypingSpeedLabel.Name = "titleMinTypingSpeedLabel";
            this.titleMinTypingSpeedLabel.Size = new System.Drawing.Size(192, 20);
            this.titleMinTypingSpeedLabel.TabIndex = 10;
            this.titleMinTypingSpeedLabel.Text = "Минимальная скорость:";
            // 
            // maxErrorsNumberLabel
            // 
            this.maxErrorsNumberLabel.AutoSize = true;
            this.maxErrorsNumberLabel.Location = new System.Drawing.Point(285, 9);
            this.maxErrorsNumberLabel.Name = "maxErrorsNumberLabel";
            this.maxErrorsNumberLabel.Size = new System.Drawing.Size(18, 20);
            this.maxErrorsNumberLabel.TabIndex = 11;
            this.maxErrorsNumberLabel.Text = "0";
            // 
            // minTypingSpeedLabel
            // 
            this.minTypingSpeedLabel.AutoSize = true;
            this.minTypingSpeedLabel.Location = new System.Drawing.Point(526, 9);
            this.minTypingSpeedLabel.Name = "minTypingSpeedLabel";
            this.minTypingSpeedLabel.Size = new System.Drawing.Size(18, 20);
            this.minTypingSpeedLabel.TabIndex = 12;
            this.minTypingSpeedLabel.Text = "0";
            // 
            // currentCharLabel
            // 
            this.currentCharLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.currentCharLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentCharLabel.Location = new System.Drawing.Point(489, 36);
            this.currentCharLabel.Name = "currentCharLabel";
            this.currentCharLabel.Size = new System.Drawing.Size(151, 154);
            this.currentCharLabel.TabIndex = 13;
            this.currentCharLabel.Text = " ";
            this.currentCharLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(489, 364);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(169, 28);
            this.exitButton.TabIndex = 14;
            this.exitButton.Text = "К списку уровней";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // LevelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 408);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.currentCharLabel);
            this.Controls.Add(this.minTypingSpeedLabel);
            this.Controls.Add(this.maxErrorsNumberLabel);
            this.Controls.Add(this.titleMinTypingSpeedLabel);
            this.Controls.Add(this.titleMaxErrorsNumberLabel);
            this.Controls.Add(this.lavelLabel);
            this.Controls.Add(this.titleLevelLabel);
            this.Controls.Add(this.errorsLabel);
            this.Controls.Add(this.titleErrorsLabel);
            this.Controls.Add(this.titleTimeLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.taskTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LevelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Уровень №";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LevelForm_FormClosed);
            this.Load += new System.EventHandler(this.LevelForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox taskTextBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label titleTimeLabel;
        private System.Windows.Forms.Label titleErrorsLabel;
        private System.Windows.Forms.Label errorsLabel;
        private System.Windows.Forms.Label titleLevelLabel;
        private System.Windows.Forms.Label lavelLabel;
        private System.Windows.Forms.Label titleMaxErrorsNumberLabel;
        private System.Windows.Forms.Label titleMinTypingSpeedLabel;
        private System.Windows.Forms.Label maxErrorsNumberLabel;
        private System.Windows.Forms.Label minTypingSpeedLabel;
        private System.Windows.Forms.Label currentCharLabel;
        private System.Windows.Forms.Button exitButton;
    }
}