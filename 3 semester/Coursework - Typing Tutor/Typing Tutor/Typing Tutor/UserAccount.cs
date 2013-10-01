using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typing_Tutor.Properties;

namespace Typing_Tutor
{
    [Serializable]
    public class UserAccount
    {
        private readonly string _userName;
        private readonly Progress _gameProgress;

        public UserAccount(string userName)
        {
            if (userName == null)
                throw new ArgumentNullException("userName");
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException(Resources.UserAccount_Invalid_user_name, "userName");
            _userName = userName;
            _gameProgress = new Progress();
        }

        public Progress Progress { get { return _gameProgress; } }

        public string Name { get { return _userName; } }
    }
}
