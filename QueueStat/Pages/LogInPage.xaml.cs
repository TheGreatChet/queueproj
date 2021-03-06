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
using QueueStat.ADO;
using QueueStat.Classes;

namespace QueueStat.Pages
{
    /// <summary>
    /// Логика взаимодействия для LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        /// <summary>
        /// Констурктор страницы
        /// </summary>
        public LogInPage()
        {
            InitializeComponent();
            LoginTb.Focus();
        }       
        /// <summary>
        /// Метод авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginTb.Text) && !string.IsNullOrEmpty(PasswPb.Password))
            {
                if (ConnectionClass.dB.User.Where(c => c.Login == LoginTb.Text).Any())
                {
                    var user = ConnectionClass.dB.User.Where(c => c.Login == LoginTb.Text).First();
                    if (user.Password == PasswPb.Password)
                    {
                        if (user.Id_role != 0)
                        {
                            NavigationService.Navigate(new MainStatPage());
                            DataClass.Current = user;
                            var win = (MainWindow)Application.Current.MainWindow;
                            win.DataSp.Visibility = Visibility.Visible;
                            win.DataSp.IsEnabled = true;
                            win.PagesSp.Visibility = Visibility.Visible;
                            win.PagesSp.IsEnabled = true;
                            win.PagesRl.Visibility = Visibility.Visible;
                            var empl = ConnectionClass.dB.Employee.Where(c => c.Id_empl == user.Id_user).First();
                            win.UserName.Content = empl.Name;
                            win.UserSurn.Content = empl.Surname;
                            win.UserPatr.Content = empl.Patronymic;
                            win.LogOffBtn.IsEnabled = true;
                            win.LogOffBtn.Visibility = Visibility.Visible;
                            win.UserSpColor.Color = Color.FromRgb(240, 248, 255);
                            win.UserSpColor.Opacity = 0.5;
                            win.UserImg.Source = new BitmapImage(new Uri(empl.Image_link, UriKind.RelativeOrAbsolute));
                        }
                        else MessageBox.Show("Доступ разрешён только статисту", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else MessageBox.Show("Неправильный пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
