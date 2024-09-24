using System.Windows;
using WpfAppFileAndTaskStorage.ViewModels;

namespace WpfAppFileAndTaskStorage
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

    }
}
