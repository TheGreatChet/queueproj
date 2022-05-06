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
using System.Windows.Shapes;
using QueueOper.ADO;
using QueueOper.Classes;
using System.Windows.Threading;

namespace QueueOper.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChngStatusWindow.xaml
    /// </summary>
    public partial class ChngStatusWindow : Window
    {
        QueueElement Current;
        public ChngStatusWindow(QueueElement cur)
        {
            InitializeComponent();
            Current = cur;
            NumLbl.Content = "Номер талона - " + cur.Id_el.ToString();
            PrevStatusTb.Text = Classes.ConnectionClass.dB.Status.Where(c => c.Id_status == Current.Id_status).FirstOrDefault().Name;
            NewStatusCb.ItemsSource = Classes.ConnectionClass.dB.Status.ToList();
            NewStatusCb.DisplayMemberPath = "Name";
            NewStatusCb.SelectedValuePath = "Id_status";
        }

        private void SaveChngBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NewStatusCb.SelectedItem != null)
            {
                Current.Id_status = Convert.ToInt32(NewStatusCb.SelectedValue);
                Classes.ConnectionClass.dB.SaveChanges();
                MessageBox.Show("Успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

        private void CancelChngBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
