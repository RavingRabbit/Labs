namespace Typing_Tutor
{
    partial class UserSelectionForm
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
            this.userChoiseFormTitleLabel = new System.Windows.Forms.Label();
            this.createUserAccountButton = new System.Windows.Forms.Button();
            this.usersListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // userChoiseFormTitleLabel
            // 
            this.userChoiseFormTitleLabel.AutoSize = true;
            this.userChoiseFormTitleLabel.Location = new System.Drawing.Point(8, 9);
            this.userChoiseFormTitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userChoiseFormTitleLabel.Name = "userChoiseFormTitleLabel";
            this.userChoiseFormTitleLabel.Size = new System.Drawing.Size(163, 20);
            this.userChoiseFormTitleLabel.TabIndex = 2;
            this.userChoiseFormTitleLabel.Text = "Выберите профиль:";
            // 
            // createUserAccountButton
            // 
            this.createUserAccountButton.Location = new System.Drawing.Point(12, 182);
            this.createUserAccountButton.Name = "createUserAccountButton";
            this.createUserAccountButton.Size = new System.Drawing.Size(262, 30);
            this.createUserAccountButton.TabIndex = 3;
            this.createUserAccountButton.Text = "Создать профиль";
            this.createUserAccountButton.UseVisualStyleBackColor = true;
            this.createUserAccountButton.Click += new System.EventHandler(this.createUserAccountButton_Click);
            // 
            // usersListBox
            // 
            this.usersListBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.usersListBox.FormattingEnabled = true;
            this.usersListBox.ItemHeight = 20;
            this.usersListBox.Location = new System.Drawing.Point(12, 32);
            this.usersListBox.Name = "usersListBox";
            this.usersListBox.Size = new System.Drawing.Size(260, 144);
            this.usersListBox.TabIndex = 6;
            this.usersListBox.SelectedIndexChanged += new System.EventHandler(this.usersListBox_SelectedIndexChanged);
            // 
            // UserSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 221);
            this.Controls.Add(this.usersListBox);
            this.Controls.Add(this.createUserAccountButton);
            this.Controls.Add(this.userChoiseFormTitleLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор профиля";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserSelectionForm_FormClosed);
            this.Load += new System.EventHandler(this.UserChoiceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userChoiseFormTitleLabel;
        private System.Windows.Forms.Button createUserAccountButton;
        private System.Windows.Forms.ListBox usersListBox;
    }
}