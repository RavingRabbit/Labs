using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typing_Tutor
{
    public partial class UserSelectionForm : Form
    {
        private bool _accountSelected;
        public UserSelectionForm()
        {
            InitializeComponent();
        }

        private void UserChoiceForm_Load(object sender, EventArgs e)
        {
            foreach (var user in UserAccountsEngine.GetInstance().UserAccounts)
            {
                usersListBox.Items.Add(user.Name);
            }
        }

        private void createUserAccountButton_Click(object sender, EventArgs e)
        {
            var newAccount = RequestNewUserAccount();
            if (newAccount == null) return;
            OnUserAccountSelected(new EventArgs<UserAccount>(newAccount));
            Dispose();
        }

        private UserAccount RequestNewUserAccount()
        {
            var newUserCreatingForm = new UserAccountCreatingForm();
            UserAccount newAccount = null;
            newUserCreatingForm.AccountCreated += (sender, args) => newAccount = args.EventInfo;
            newUserCreatingForm.ShowDialog();
            if (newAccount != null)
                _accountSelected = true;
            return newAccount;
        }

        public event EventHandler<EventArgs<UserAccount>> UserAccountSelected;

        public void OnUserAccountSelected(EventArgs<UserAccount> e)
        {
            var handler = UserAccountSelected;
            if (handler != null) handler(this, e);
        }

        private void SelectAccount(UserAccount userAccount)
        {
            OnUserAccountSelected(new EventArgs<UserAccount>(userAccount));
            _accountSelected = true;
            Dispose();
        }

        private void UserSelectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_accountSelected)
                ProgrammEngine.CloseProgram();
        }

        private void usersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = sender as ListBox;
            Debug.Assert(listBox != null, "listBox != null");
            if (listBox.SelectedItem == null)
                return;
            var userName = listBox.SelectedItem.ToString();
            var userAccount = UserAccountsEngine.GetInstance().UserAccounts.Find(account => account.Name == userName);
            SelectAccount(userAccount);
        }
    }
}
