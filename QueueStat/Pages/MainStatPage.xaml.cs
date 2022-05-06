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
using System.Diagnostics;
using QueueStat.ADO;
using QueueStat.Classes;

namespace QueueStat.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainStatPage.xaml
    /// </summary>
    public partial class MainStatPage : Page
    {
        private List<Category> Categories { get; set; }
        public MainStatPage()
        {
            InitializeComponent();           
        }

        void CalcData(out List<StaticticsData> data)
        {
            data = new List<StaticticsData>() { };
            var queuesList = ConnectionClass.dB.Queue.ToList();
            var queueElsList = ConnectionClass.dB.QueueElement.ToList();
            StaticticsData curData = null;
            //Перебирает ближайшие года
            for (int y = 2018; y < 2022; y++)
            {
                //Перебор месяцов этого года
                for (int m = 1; m < 13; m++)
                {                  
                    //Очереди в этом месяце этого года
                    var curQueList = queuesList.Where(c => c.Date.Value.Year == y && c.Date.Value.Month == m).ToList();
                    //Экземпляр для подсчёта в этот момент времени
                    Dictionary<int, int> curCountList = new Dictionary<int, int>() { };
                    curCountList.Add(1, 0);
                    curCountList.Add(2, 0);
                    curCountList.Add(3, 0);
                    curCountList.Add(4, 0);
                    curCountList.Add(5, 0);
                    curCountList.Add(6, 0);
                    curCountList.Add(7, 0);
                    curCountList.Add(8, 0);
                    curData = new StaticticsData(y, m, curCountList);
                
                    //Перебор очереди
                    foreach (Queue q in curQueList)
                    {
                        //Элементы очереди в текущей очереди
                        var curElsList = queueElsList.Where(c => c.Id_q == q.Id_q).ToList();
                        //Деление на операции
                        int count = 0;
                        for (int o = 1; o < 9; o++)
                        {
                            //Перебор элеметов в очереди                          
                            foreach (QueueElement element in curElsList)
                            {
                                if (element.Id_oper == o) count++;
                            }
                            int prev = curCountList.Where(c => c.Key == o).First().Value;
                            curCountList[o] = prev += count;
                            count = 0;
                        }                       
                    }
                    data.Add(curData);
                    curData = null;
                }               
            }
        }

        void DrawPieChart()
        {
            CalcData(out List<StaticticsData> data);
            float pieWidth = 250, pieHeight = 250, centerX = pieWidth / 2, centerY = pieHeight / 2, radius = pieWidth / 2;
            mainCanvas.Width = pieWidth;
            mainCanvas.Height = pieHeight;
            if (MonthCb.SelectedItem != null && YearCb.SelectedItem != null)
            {
                ComboBoxItem year = (ComboBoxItem)YearCb.SelectedItem;
                ComboBoxItem month = (ComboBoxItem)MonthCb.SelectedItem;
                if (!data.Where(c => c.Year == Convert.ToInt32(year.Content) && c.Month == Convert.ToInt32(month.Content)).Any())
                {
                    MessageBox.Show("Записи отсутвуют в этото промежуток времени!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                StaticticsData current = data.Where(c => c.Year == Convert.ToInt32(year.Content) && c.Month == Convert.ToInt32(month.Content)).First();
                int summary = 0;
                foreach (KeyValuePair<int, int> s in current.OperationCountList.ToList())
                {
                    summary += s.Value;
                }
                MessageBox.Show(summary.ToString());
                Categories = new List<Category>()
                {
                    #region Data
                    new Category
                    {
                        Title = "Смена номера карты",
                        Percentage = (float)Math.Round(Convert.ToDecimal((current.OperationCountList.Where(c => c.Key == 1).First().Value * 100) / summary), 0, MidpointRounding.ToEven),
                        ColorBrush = Brushes.Gold,
                    },

                    new Category
                    {
                        Title = "Оформление дебетовой карты",
                        Percentage = (float)Math.Round(Convert.ToDecimal((current.OperationCountList.Where(c => c.Key == 2).First().Value * 100) / summary), 0, MidpointRounding.ToEven),
                        ColorBrush = Brushes.Pink,
                    },

                    new Category
                    {
                        Title = "Подача заявки на кредит",
                        Percentage = (float)Math.Round(Convert.ToDecimal((current.OperationCountList.Where(c => c.Key == 3).First().Value * 100) / summary), 0, MidpointRounding.ToEven),
                        ColorBrush = Brushes.CadetBlue,
                    },

                    new Category
                    {
                        Title = "Получение кредита",
                        Percentage = (float)Math.Round(Convert.ToDecimal((current.OperationCountList.Where(c => c.Key == 4).First().Value * 100) / summary), 0, MidpointRounding.ToEven),
                        ColorBrush = Brushes.Blue,
                    },

                    new Category
                    {
                        Title = "Обновление карты",
                        Percentage = (float)Math.Round(Convert.ToDecimal((current.OperationCountList.Where(c => c.Key == 5).First().Value * 100) / summary), 0, MidpointRounding.ToEven),
                        ColorBrush = Brushes.Green,
                    },

                    new Category
                    {
                        Title = "Получение дебетовой карты",
                        Percentage = (float)Math.Round(Convert.ToDecimal((current.OperationCountList.Where(c => c.Key == 6).First().Value * 100) / summary), 0, MidpointRounding.ToEven),
                        ColorBrush = Brushes.Yellow,
                    },

                    new Category
                    {
                        Title = "Обмен валют",
                        Percentage = (float)Math.Round(Convert.ToDecimal((current.OperationCountList.Where(c => c.Key == 7).First().Value * 100) / summary), 0, MidpointRounding.ToEven),
                        ColorBrush = Brushes.Brown,
                    },

                    new Category
                    {
                        Title = "Получение большой суммы наличных",
                        Percentage = (float)Math.Round(Convert.ToDecimal((current.OperationCountList.Where(c => c.Key == 8).First().Value * 100) / summary), 0, MidpointRounding.ToEven),
                        ColorBrush = Brushes.Red,
                    },
                    #endregion
                };

                detailsItemsControl.ItemsSource = Categories;

                float angle = 0, prevAngle = 0;
                foreach (var category in Categories)
                {
                    double line1X = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
                    double line1Y = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

                    angle = category.Percentage * (float)360 / 100 + prevAngle;
                    Debug.WriteLine(angle);

                    double arcX = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
                    double arcY = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

                    var line1Segment = new LineSegment(new Point(line1X, line1Y), false);
                    double arcWidth = radius, arcHeight = radius;
                    bool isLargeArc = category.Percentage > 50;
                    var arcSegment = new ArcSegment()
                    {
                        Size = new Size(arcWidth, arcHeight),
                        Point = new Point(arcX, arcY),
                        SweepDirection = SweepDirection.Clockwise,
                        IsLargeArc = isLargeArc,
                    };
                    var line2Segment = new LineSegment(new Point(centerX, centerY), false);

                    var pathFigure = new PathFigure(
                        new Point(centerX, centerY),
                        new List<PathSegment>()
                        {
                        line1Segment,
                        arcSegment,
                        line2Segment,
                        },
                        true);

                    var pathFigures = new List<PathFigure>() { pathFigure, };
                    var pathGeometry = new PathGeometry(pathFigures);
                    var path = new Path()
                    {
                        Fill = category.ColorBrush,
                        Data = pathGeometry,
                    };
                    mainCanvas.Children.Add(path);

                    prevAngle = angle;
                }
            }
        }

        private void OutputBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MonthCb.SelectedItem != null && YearCb.SelectedItem != null)
            {
                DrawPieChart();
            }
            else MessageBox.Show("Выберите месяц и год", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
