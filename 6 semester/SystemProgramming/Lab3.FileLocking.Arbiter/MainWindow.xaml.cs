using System;
using System.Configuration;
using System.Linq;
using System.Windows;

namespace Lab3.FileLocking.Arbiter
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const String ShowWindowsConfigKeyName = "showWindow";

        public MainWindow()
        {
            InitializeComponent();
            var settings = ConfigurationManager.AppSettings;
            Boolean showWindow = false;
            if (settings.AllKeys.Contains(ShowWindowsConfigKeyName))
            {
                if (!Boolean.TryParse(settings.Get(ShowWindowsConfigKeyName), out showWindow))
                {
                    showWindow = false;
                }
            }
            if (showWindow)
            {
                DataContext = new MainWindowViewModel(App.Arbiter);
            }
            else
            {
                Visibility = Visibility.Hidden;
            }
        }
    }
}