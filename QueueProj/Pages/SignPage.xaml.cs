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

namespace QueueProj.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignPage.xaml
    /// </summary>
    public partial class SignPage : Page
    {
        /// <summary>
        /// Констурктор страницы, вывод элементов Cb
        /// </summary>
        public SignPage()
        {
            InitializeComponent();
            OperCb.ItemsSource = ConnectionClass.dB.Operation.ToList();
            OperCb.DisplayMemberPath = "Name";
            OperCb.SelectedValuePath = "Id_oper";
        }

        /// <summary>
        /// Обработка записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTb.Name) || OperCb.SelectedItem == null)
            {
                MessageBox.Show("Заполните поле имени и выберите услугу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int idw = 0;
            if (Convert.ToInt32(OperCb.SelectedValue) == 1 || Convert.ToInt32(OperCb.SelectedValue) == 2 || Convert.ToInt32(OperCb.SelectedValue) == 6) idw = 1;
            else if (Convert.ToInt32(OperCb.SelectedValue) == 3 || Convert.ToInt32(OperCb.SelectedValue) == 4 || Convert.ToInt32(OperCb.SelectedValue) == 5) idw = 2;
            else if (Convert.ToInt32(OperCb.SelectedValue) == 7 || Convert.ToInt32(OperCb.SelectedValue) == 8) idw = 3;
            QueueElement nw = new QueueElement()
            {
                Id_q = Classes.ConnectionClass.dB.Queue.Where(c => c.Date == DateTime.Today).First().Id_q,
                Name = NameTb.Text,
                Id_status = 1,
                Id_oper = Convert.ToInt32(OperCb.SelectedValue),
                Id_window = idw.ToString()
            };
            ConnectionClass.dB.QueueElement.Add(nw);             
            ConnectionClass.dB.SaveChanges();
            MessageBox.Show("Ваш номер в очереди - " + nw.Id_el + "\nОкно - " + nw.Id_window, "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();
            
        }
    }
}
