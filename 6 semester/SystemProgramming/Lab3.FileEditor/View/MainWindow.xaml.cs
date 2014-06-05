using System.Diagnostics;
using System.Windows;
using Lab3.FileEditor.ViewModel;

namespace Lab3.FileEditor.View
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
            Title += " " + Process.GetCurrentProcess().Id;
        }
    }
}