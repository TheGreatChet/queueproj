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

namespace QueueProj
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavFr.Navigate(new Pages.QueueMainPage());
            if (!Classes.ConnectionClass.dB.Queue.Where(c => c.Date == DateTime.Today).Any())
            {
                Classes.ConnectionClass.dB.Queue.Add(new Queue() { Date = DateTime.Today });
                Classes.ConnectionClass.dB.SaveChanges();
            }
        }
    }
}
