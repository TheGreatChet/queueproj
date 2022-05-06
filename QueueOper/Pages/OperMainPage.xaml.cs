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
using QueueOper.ADO;
using QueueOper.Classes;
using System.Windows.Threading;

namespace QueueOper.Pages
{
    /// <summary>
    /// Логика взаимодействия для OperMainPage.xaml
    /// </summary>
    public partial class OperMainPage : Page
    {

        /// <summary>
        /// Констуктор страницы и запуск таймера
        /// </summary>
        DispatcherTimer timer;
        int QueueNum;
        public OperMainPage()
        {
            InitializeComponent();
            QueueNum = ConnectionClass.dB.Queue.ToList().Last<Queue>().Id_q;
            Upd();
            DateCb.SelectedValuePath = "Id_q";
            DateCb.DisplayMemberPath = "Date";
            UpdQ();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();
        }


        void UpdQ()
        { 
            DateCb.ItemsSource = ConnectionClass.dB.Queue.ToList();
            DateCb.SelectedValue = ConnectionClass.dB.Queue.ToList().Last<Queue>().Id_q;
            NumLbl.Text = "Номер очереди - " + (DateCb.SelectedItem as Queue).Id_q;
        }
        /// <summary>
        /// Динамическое обновление данных по таймеру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            Upd();   
        }

        /// <summary>
        /// Метод обновления данных в Lw
        /// </summary>
        public void Upd()
        {
            QueryLw.ItemsSource = ConnectionClass.dB.QueueElement.ToList().Where(c => c.Id_q == QueueNum).ToList();
        }

        /// <summary>
        /// Обработка удаления элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var cur = QueryLw.SelectedItem as QueueElement;
            if (cur != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    ConnectionClass.dB.QueueElement.Remove(cur);
                    ConnectionClass.dB.SaveChanges();
                    MessageBox.Show("Успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    Upd();
                }
            }
            else MessageBox.Show("Выберите талон для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Переход в окно изменения статуса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChngStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            var cur = QueryLw.SelectedItem as QueueElement;
            if (cur != null)
            {
                Windows.ChngStatusWindow cw = new Windows.ChngStatusWindow(cur);
                cw.Show();
            }
            else MessageBox.Show("Выберите талон изменения статуса", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Кнопка для создания новой очереди
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartNewQuBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                if (ConnectionClass.dB.Queue.ToList().Last<Queue>().Date == DateTime.Today)
                {
                    MessageBox.Show("Невозможно начать новую очередь в тот же день", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                ConnectionClass.dB.Queue.Add(new Queue() 
                { 
                    Date = DateTime.Today
                });
                ConnectionClass.dB.SaveChanges();
                UpdQ();
                Upd();
                MessageBox.Show("Успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ClearThisQuBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                foreach(QueueElement a in ConnectionClass.dB.QueueElement.ToList().Where(c => c.Id_q == QueueNum)) ConnectionClass.dB.QueueElement.Remove(a);
                ConnectionClass.dB.SaveChanges();
                Upd();
                MessageBox.Show("Успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        /// <summary>
        /// Выбор-сортировка по дате очереди
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DateCb.SelectedItem != null)
            {
                NumLbl.Text = "Номер очереди - " + (DateCb.SelectedItem as Queue).Id_q.ToString();
                QueueNum = Convert.ToInt32(DateCb.SelectedValue);
                Upd();
            }
        }
    }
}
