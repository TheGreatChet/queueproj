using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QueueStat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavFr.Navigate(new Pages.LogInPage());
        }
        private void LogOffBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                DataSp.Visibility = Visibility.Hidden;
                DataSp.IsEnabled = false;
                PagesSp.Visibility = Visibility.Hidden;
                PagesSp.IsEnabled = false;
                PagesRl.Visibility = Visibility.Hidden;
                Classes.DataClass.Current = null;
                NavFr.Navigate(new Pages.LogInPage());
            }
        }
    }
}
