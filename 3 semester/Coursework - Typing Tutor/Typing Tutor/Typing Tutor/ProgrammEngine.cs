using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Typing_Tutor
{
    class ProgrammEngine
    {
        private static ProgrammEngine _instance;
        private UserAccount _userAccount;
        
        public Progress Progress { get { return _userAccount.Progress; } }

        protected ProgrammEngine()
        {
            Initialize();
        }
        
        public static ProgrammEngine GetInstance()
        {
            return _instance ?? (_instance = new ProgrammEngine());
        }

        public void SetUserAccount(UserAccount userAccount)
        {
            if (userAccount == null)
                throw new ArgumentNullException("userAccount");
            _userAccount = userAccount;
        }

        public UserAccount RequestUserAccount()
        {
            var userChoiceForm = new UserSelectionForm();
            UserAccount userAccount = null;
            userChoiceForm.UserAccountSelected += (sender, args) => userAccount = args.EventInfo;
            userChoiceForm.ShowDialog();
            Debug.Assert(userAccount != null, "Account was not selected.");
            return userAccount;
        }

        public Level RequestLevel()
        {
            var levelsForm = new LevelsForm();
            Level selectedLevel = null;
            levelsForm.LevelSelected += (sender, args) => selectedLevel = args.EventInfo;
            levelsForm.ShowDialog();
            return selectedLevel;
        }

        public LevelStatistics PlayLevel(Level level)
        {
            if (level == null)
                throw new ArgumentNullException("level");
            var levelForm = new LevelForm(level);
            LevelStatistics statistics = null;
            levelForm.LevelFinished += (sender, args) => statistics = args.EventInfo;
            levelForm.ShowDialog();
            if (statistics != null && statistics.Complited)
                Progress.AddStatistics(statistics);
            return statistics;
        }

        private static void Initialize()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                UserAccountsEngine.Deserialize();
                Levels.Deserialize();
            }
            catch (Exception)
            {
            }
        }

        public static void CloseProgram()
        {
            try
            {
                UserAccountsEngine.Serialize();
                Levels.Serialize();
            }
            catch (Exception)
            {
            }
            finally
            {
                Environment.Exit(0);
            }
        }
    }
}
