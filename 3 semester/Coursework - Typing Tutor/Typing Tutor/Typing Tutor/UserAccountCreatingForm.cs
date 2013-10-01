using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Typing_Tutor.Properties;

namespace Typing_Tutor
{
    public partial class UserAccountCreatingForm : Form
    {
        public UserAccountCreatingForm()
        {
            InitializeComponent();
        }

        private void userAccountNameTextBox_TextChanged(object sender, EventArgs e)
        {
            var userAccountName = ((TextBox)sender).Text;
            if (!string.IsNullOrWhiteSpace(userAccountName))
                if (!UserAccountsEngine.GetInstance().UserExists(userAccountName))
                {
                    validUserAccountNameLabel.Text = "ⱱ";
                    validUserAccountNameLabel.ForeColor = Color.Green;
                    return;
                }
            validUserAccountNameLabel.Text = "X";
            validUserAccountNameLabel.ForeColor = Color.Red;
        }

        public event EventHandler<EventArgs<UserAccount>> AccountCreated;

        public void OnAccountCreated(EventArgs<UserAccount> e)
        {
            var handler = AccountCreated;
            if (handler != null) handler(this, e);
        }

        private void createAccountButtonClick(object sender, EventArgs e)
        {
            var userAccountName = userAccountNameTextBox.Text;
            if (!string.IsNullOrWhiteSpace(userAccountName))
                if (!UserAccountsEngine.GetInstance().UserExists(userAccountName))
                {
                    var newUser = UserAccountsEngine.GetInstance().CreateNewUser(userAccountName);
                    OnAccountCreated(new EventArgs<UserAccount>(newUser));
                    Dispose();
                }
                else
                {
                    MessageBox.Show(Resources.UserAccountCreatingForm_Name_reserved);
                }
            else
            {
                MessageBox.Show(Resources.UserAccountCreatingForm_InvalidUserName);
            }
        }
    }
}
