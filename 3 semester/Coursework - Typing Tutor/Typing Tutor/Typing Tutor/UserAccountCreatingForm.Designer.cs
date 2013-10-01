namespace Typing_Tutor
{
    partial class UserAccountCreatingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.userAccountNameTextBox = new System.Windows.Forms.TextBox();
            this.validUserAccountNameLabel = new System.Windows.Forms.Label();
            this.createAccountButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя профиля:";
            // 
            // userAccountNameTextBox
            // 
            this.userAccountNameTextBox.Location = new System.Drawing.Point(134, 20);
            this.userAccountNameTextBox.Name = "userAccountNameTextBox";
            this.userAccountNameTextBox.Size = new System.Drawing.Size(221, 26);
            this.userAccountNameTextBox.TabIndex = 1;
            this.userAccountNameTextBox.TextChanged += new System.EventHandler(this.userAccountNameTextBox_TextChanged);
            // 
            // validUserAccountNameLabel
            // 
            this.validUserAccountNameLabel.AutoSize = true;
            this.validUserAccountNameLabel.Location = new System.Drawing.Point(361, 23);
            this.validUserAccountNameLabel.Name = "validUserAccountNameLabel";
            this.validUserAccountNameLabel.Size = new System.Drawing.Size(13, 20);
            this.validUserAccountNameLabel.TabIndex = 2;
            this.validUserAccountNameLabel.Text = " ";
            // 
            // createAccountButton
            // 
            this.createAccountButton.Location = new System.Drawing.Point(17, 57);
            this.createAccountButton.Name = "createAccountButton";
            this.createAccountButton.Size = new System.Drawing.Size(338, 30);
            this.createAccountButton.TabIndex = 3;
            this.createAccountButton.Text = "Создать профиль";
            this.createAccountButton.UseVisualStyleBackColor = true;
            this.createAccountButton.Click += new System.EventHandler(this.createAccountButtonClick);
            // 
            // UserAccountCreatingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 99);
            this.Controls.Add(this.createAccountButton);
            this.Controls.Add(this.validUserAccountNameLabel);
            this.Controls.Add(this.userAccountNameTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserAccountCreatingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание нового профиля";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userAccountNameTextBox;
        private System.Windows.Forms.Label validUserAccountNameLabel;
        private System.Windows.Forms.Button createAccountButton;
    }
}