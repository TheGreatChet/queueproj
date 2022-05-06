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

namespace QueueOper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Констурктор страницы, переход на авторизацию
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            NavFr.Navigate(new Pages.LoginPage());
        }
        /// <summary>
        /// Метод выхода из аккаунта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogOffBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                LogOffBtn.IsEnabled = false;
                LogOffBtn.Visibility = Visibility.Hidden;
                UserSpColor.Color = Color.FromRgb(173, 216, 230);
                UserSpColor.Opacity = 0;
                UserImg.Source = null;
                UserName.Content = "";
                UserSurn.Content = "";
                Classes.DataClass.Current = null;
                UserPatr.Content = "";
                NavFr.Navigate(new Pages.LoginPage());
            }
        }
    }
}
