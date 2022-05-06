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
using QueueProj.ADO;
using QueueProj.Classes;
using System.Windows.Threading;


namespace QueueProj.Pages
{
    /// <summary>
    /// Логика взаимодействия для QueueMainPage.xaml
    /// </summary>
    /// 
    public partial class QueueMainPage : Page
    {
        /// <summary>
        /// Конструктор страницы. Обновляет списки при открытии.
        /// </summary>
        DispatcherTimer timer;
        public QueueMainPage()
        {
            InitializeComponent();
            Upd();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();
        }

        /// <summary>
        /// Динамическое обновление
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e) => Upd();

        /// <summary>
        /// Метод для обновления списков
        /// </summary>
        void Upd()
        {
            int last = ConnectionClass.dB.Queue.ToList().Last<Queue>().Id_q;
            var list = ConnectionClass.dB.QueueElement.ToList();
            WindowOneLw.ItemsSource = list.Where(c => c.Id_window == "1" && c.Id_status != 2 && c.Id_status != 3 && c.Id_q == last).ToList();
            WindowTwoLw.ItemsSource = list.Where(c => c.Id_window == "2" && c.Id_status != 2 && c.Id_status != 3 && c.Id_q == last).ToList();
            WindowThreeeLw.ItemsSource = list.Where(c => c.Id_window == "3" && c.Id_status != 2 && c.Id_status != 3 && c.Id_q == last).ToList();

            if (WindowOneLw.Items.Count == 0) FirstWindowEmptLbl.Visibility = Visibility.Visible;
            else FirstWindowEmptLbl.Visibility = Visibility.Hidden;
            if (WindowTwoLw.Items.Count == 0) SecondWindowEmptLbl.Visibility = Visibility.Visible;
            else SecondWindowEmptLbl.Visibility = Visibility.Hidden;
            if (WindowThreeeLw.Items.Count == 0) ThirdWindowEmptLbl.Visibility = Visibility.Visible;
            else ThirdWindowEmptLbl.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Переход на страницу записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignPage());
        }
        /// <summary>
        /// Динамическое обновление данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
    }
}
