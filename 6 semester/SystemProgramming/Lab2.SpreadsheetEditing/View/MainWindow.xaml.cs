using System.Windows;
using Lab2.SpreadsheetEditing.ViewModel;

namespace Lab2.SpreadsheetEditing.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
    }
}
