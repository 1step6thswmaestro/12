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

namespace Calendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Awake(); 
        }

        public void Awake()
        {
/*            // Canvas will replace this.Content
            Canvas canvas = new Canvas();

            // List of colors used.
            string FONTFAMILY       = "나눔고딕";
            Brush BACKGROUND_COLOR  = Brushes.Black;
            Brush NORMAL_COLOR      = Brushes.White;
            Brush HIGHLIGHT_COLOR   = Brushes.Red;

            const int NUMBER_OF_DAYS = 7; // The number of days

            const float START_Y = 0.3f; // Start y-cordinate of line
            const float COL_DIS = 0.1f; // Seperate distance between lines
            const float ROW_DIS = 1.0f / (float)NUMBER_OF_DAYS; // not

            // Set background color
            canvas.Background = BACKGROUND_COLOR;

            // Add list of days
            string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            for (int i = 0; i < NUMBER_OF_DAYS; i++)
            {
                canvas.Children.Add(new Label
                {
                    Content = days[i],
                    Foreground = (i == 0 ? HIGHLIGHT_COLOR : NORMAL_COLOR),
                    FontFamily = new System.Windows.Media.FontFamily (FONTFAMILY),
                    FontWeight = FontWeights.Bold,
                    // Move 0.02f right to make alignment
                    Margin = new Thickness(x_in_pixel(ROW_DIS*(float)i + 0.02f),
                        y_in_pixel(START_Y - 0.06f), 0, 0)
                });
            }

            DateTime.Today.AddDays(-DateTime.Today.Day);

            CalendarInfo info = CalendarInfo.Instance;
            int year = info.Today.Year;
            int month = info.Today.Month;
            int day = info.Today.Day;

            DateTime start_day_of_month = DateTime.Today.AddDays(-day + 1);
            int days_in_month = DateTime.DaysInMonth(year, month);

            int NUMBER_OF_WEEKS;
            int start_day = 0;

            switch (start_day_of_month.DayOfWeek)
            {
                case DayOfWeek.Sunday :
                    start_day = 0;
                    break;
                case DayOfWeek.Monday:
                    start_day = 1;
                    break;
                case DayOfWeek.Tuesday :
                    start_day = 2;
                    break;
                case DayOfWeek.Wednesday :
                    start_day = 3;
                    break;
                case DayOfWeek.Thursday :
                    start_day = 4;
                    break;
                case DayOfWeek.Friday :
                    start_day = 5;
                    break;
                case DayOfWeek.Saturday :
                    start_day = 6;
                    break;
                default:
                    break;
            }

            int cnt = 1;
            for (int i = 0; ; i++)
            {
                int j;
                for (j = (i == 0 ? start_day : 0); j < NUMBER_OF_DAYS; j++)
                {
                    if (cnt > days_in_month) break;

                    // if draw today, make highlight
                    if (cnt == day)
                    {
                        canvas.Children.Add(new Ellipse
                        {
                            Margin = new Thickness(x_in_pixel(ROW_DIS * (float)j + 0.02f),
                                              y_in_pixel(START_Y + 0.01f + COL_DIS * (float)i), 0, 0),
                            Width = x_in_pixel(1 / (float)NUMBER_OF_DAYS * 0.4f),
                            Height = y_in_pixel(1 / (float)NUMBER_OF_DAYS * 0.4f),
                            Fill = HIGHLIGHT_COLOR
                        });
                    }

                    // draw the date
                    TextBlock label = new TextBlock
                    {
//                        HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right,
                        Text = cnt + "",
                        TextAlignment = System.Windows.TextAlignment.Center,
                        Foreground = NORMAL_COLOR,
                        FontFamily = new System.Windows.Media.FontFamily(FONTFAMILY),
                        FontWeight = FontWeights.Bold,
                        // Move 0.02f right to make alignment
//                        Margin = new Thickness(x_in_pixel(ROW_DIS * (float)j + 0.02f + ( cnt < 10 ? 0.03f : 0.02f)),
//                            y_in_pixel(START_Y + 0.01f + COL_DIS * (float)i), 0, 0)
                    };
                    label.Text = label.ActualWidth + "";
                    label.Margin = new Thickness(x_in_pixel(ROW_DIS * (float)j + 0.02f),
                            y_in_pixel(START_Y + 0.01f + COL_DIS * (float)i), 0, 0);
                    canvas.Children.Add(label);

                    cnt++;
                }
                if (j != NUMBER_OF_DAYS)
                {
                    NUMBER_OF_WEEKS = i;
                    break;
                }
            }

            // Add horizontal lines to split weeks
            for (int i = 0; i < NUMBER_OF_WEEKS; i++)
            {
                canvas.Children.Add(new Line
                    {
                        X1 = x_in_pixel(0.0f),
                        Y1 = y_in_pixel(START_Y + COL_DIS * i),
                        X2 = x_in_pixel(1.0f),
                        Y2 = y_in_pixel(START_Y + COL_DIS * i),
                        Stroke = NORMAL_COLOR,
                        StrokeThickness = 1
                    });
            }

            // Change content
            this.Content = canvas;*/
        }
        public int x_in_pixel(float x_in_ratio) { return (int)(this.Width * x_in_ratio); }
        public int y_in_pixel(float y_in_ratio) { return (int)(this.Height * y_in_ratio); }
    }

    public static class CalendarRenderer
    {
        static public void drawLines()
        {
            Line line = new Line();
            line.X1 = 1;
            line.Y1 = 1;
            line.X2 = 50;
            line.Y2 = 50;

            line.StrokeThickness = 2;
        }
    }

    public class CalendarInfo
    {
        // Singleton Design Pattern
        public static CalendarInfo Instance
        {
            get {
                if (_instance == null)
                {
                    _instance = new CalendarInfo();
                }
                return _instance;
            }

        }
        private static CalendarInfo _instance;

        // Private constructor
        private CalendarInfo() {
            Init();
        }

        private void Init()
        {
            setToday();
        }

        private void setToday() { today = DateTime.Today; }

        public DateTime Today
        {
            get
            {
                return today;
            }
        }
        private DateTime today;
    }
}
