using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Typing_Tutor
{
    [Serializable]
    public class UserAccountsEngine
    {
        private static UserAccountsEngine _instance;
        private readonly List<UserAccount> _userAccounts;
        public const string DefaultSavingPath = "users.dat";

        protected UserAccountsEngine()
        {
            _userAccounts = new List<UserAccount>();
        }

        public static UserAccountsEngine GetInstance()
        {
            return _instance ?? (_instance = new UserAccountsEngine());
        }

        public List<UserAccount> UserAccounts
        {
            get { return _userAccounts; }
        }

        public UserAccount CreateNewUser(string userName)
        {
            if (userName == null)
                throw new ArgumentNullException("userName");
            if (UserExists(userName))
                return null;
            var userAccount = new UserAccount(userName);
            _userAccounts.Add(userAccount);
            return userAccount;
        }
        
        public bool UserExists(string userName)
        {
            if (userName == null)
                throw new ArgumentNullException("userName");
            return _userAccounts.Any(account => account.Name == userName);
        }

        public static void Serialize()
        {
            Serialize(DefaultSavingPath);
        }

        public static void Serialize(string path)
        {
            if (_instance == null) return;
            using (Stream fileStream = File.Create(path))
            {
                var br = new BinaryFormatter();
                br.Serialize(fileStream, _instance);
            }
        }

        public static void Deserialize()
        {
            Deserialize(DefaultSavingPath);
        }

        public static void Deserialize(string path)
        {
            using (Stream fileStream = File.OpenRead(path))
            {
                var br = new BinaryFormatter();
                _instance = (UserAccountsEngine)br.Deserialize(fileStream);
            }
        }
    }
}
