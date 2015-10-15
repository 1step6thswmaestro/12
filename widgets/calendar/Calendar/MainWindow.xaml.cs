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

        private bool is_highlighted_today (int row, int col)
        {
            if (row >= 6 || row < 0 || col < 0 || col >= 7) return false;
            int _row = row + 2, _col = col;
            var elements =
            Grid_Number.Children.Cast<UIElement>().Where(e => Grid.GetRow(e) == _row && Grid.GetColumn(e) == _col);
            foreach (var element in elements)
            {
                if (element.GetType().ToString().Contains("Grid"))
                {
                    Grid nested_grid = (Grid)element;
                    int count = nested_grid.Children.Cast<UIElement>().Count(e => Grid.GetRow(e) == 1 && Grid.GetColumn(e) == 0);
                    return (count!= 0);

                }
            }
            return false;
        }
        private void unhighlight_today(int row, int col)
        {
            if (row >= 6 || row < 0 || col < 0 || col >= 7) return;
            int _row = row + 2, _col = col;
            var elements =
            Grid_Number.Children.Cast<UIElement>().Where(e => Grid.GetRow(e) == _row && Grid.GetColumn(e) == _col);
            foreach (var element in elements)
            {
                if (element.GetType().ToString().Contains("Grid"))
                {
                    Grid nested_grid = (Grid)element;
                    Ellipse highlight = (Ellipse)nested_grid.Children.Cast<UIElement>().First(e => Grid.GetRow(e) == 1 && Grid.GetColumn(e) == 0);
                    nested_grid.Children.Remove(highlight);
                    return;

                }
            }
        }
        private void highlight_today(int row, int col)
        {

            if (row >= 6 || row < 0 || col < 0 || col >= 7) return;
            int _row = row + 2, _col = col;
            var elements =
            Grid_Number.Children.Cast<UIElement>().Where(e => Grid.GetRow(e) == _row && Grid.GetColumn(e) == _col);
            foreach (var element in elements)
            {
                if (element.GetType().ToString().Contains("Grid"))
                {
                    Grid nested_grid = (Grid)element;
                    Ellipse today_highlight = new Ellipse
                    {
                        Width = 6.5, //nested_grid.ActualHeight * 0.65F,
                        Height = 6.5,
//                        Width = ((Grid)nested_grid.Children.Cast<UIElement>().First(e => Grid.GetRow(e) == 1 && Grid.GetColumn(e) == 0)).ActualHeight,
                        Fill = Brushes.Red,
                        HorizontalAlignment = System.Windows.HorizontalAlignment.Center
                    };
                    Grid.SetRow(today_highlight, 1);
                    Grid.SetColumn(today_highlight, 0);
                    nested_grid.Children.Add(today_highlight);

                }
            }
        }

        private bool is_highlighted_schedule(int row, int col)
        {
            if (row >= 6 || row < 0 || col < 0 || col >= 7) return false;
            int _row = row + 2, _col = col;
            var elements =
            Grid_Number.Children.Cast<UIElement>().Where(e => Grid.GetRow(e) == _row && Grid.GetColumn(e) == _col);
            foreach (var element in elements)
            {
                if (element.GetType().ToString().Contains("Grid"))
                {
                    Grid nested_grid = (Grid)element;
                    int count = nested_grid.Children.Cast<UIElement>().Count(e => Grid.GetRow(e) == 3 && Grid.GetColumn(e) == 0);
                    return (count != 0);

                }
            }
            return false;
        }
        private void unhighlight_schedule(int row, int col)
        {
            if (row >= 6 || row < 0 || col < 0 || col >= 7) return;
            int _row = row + 2, _col = col;
            var elements =
            Grid_Number.Children.Cast<UIElement>().Where(e => Grid.GetRow(e) == _row && Grid.GetColumn(e) == _col);
            foreach (var element in elements)
            {
                if (element.GetType().ToString().Contains("Grid"))
                {
                    Grid nested_grid = (Grid)element;
                    Ellipse highlight = (Ellipse)nested_grid.Children.Cast<UIElement>().First(e => Grid.GetRow(e) == 3 && Grid.GetColumn(e) == 0);
                    nested_grid.Children.Remove(highlight);
                    return;

                }
            }
        }
        private void highlight_schedule(int row, int col)
        {
            if (row >= 6 || row < 0 || col < 0 || col >= 7) return;
            int _row = row + 2, _col = col;
            var elements =
            Grid_Number.Children.Cast<UIElement>().Where(e => Grid.GetRow(e) == _row && Grid.GetColumn(e) == _col);
            foreach (var element in elements)
            {
                if (element.GetType().ToString().Contains("Grid"))
                {
                    Grid nested_grid = (Grid)element;
                    Ellipse today_highlight = new Ellipse
                    {
                        Width = 2, //nested_grid.ActualHeight * 0.65F,
                        Height = 2,
                        //                        Width = ((Grid)nested_grid.Children.Cast<UIElement>().First(e => Grid.GetRow(e) == 1 && Grid.GetColumn(e) == 0)).ActualHeight,
                        Fill = Brushes.White,
                        HorizontalAlignment = System.Windows.HorizontalAlignment.Center
                    };
                    Grid.SetRow(today_highlight,3);
                    Grid.SetColumn(today_highlight, 0);
                    nested_grid.Children.Add(today_highlight);

                }
            }
        }


        private void set_date()
        {
            DateTime today = DateTime.Today;
            Date.Text = today.ToShortDateString();
        }
        private void set_days()
        {
            DateTime today = DateTime.Today;
            int year = today.Year;
            int month = today.Month;
            int days = DateTime.DaysInMonth(year, month);
            int start_day_of_month = day_of_week (DateTime.Today.AddDays(-today.Day + 1));
            int days_in_month = DateTime.DaysInMonth(year, month);

            int day = 1;
            Brush font_color = Brushes.White;

            for (int row = 0; row < 6; row++)
            {
                for (int col = (row == 0 ? start_day_of_month : 0 ); col < 7; col++)
                {
                    TextBlock text = get_textblock(row, col);
                    text.Foreground = font_color;
                    text.Text = day.ToString();

                    if (day == today.Day) highlight_today(row, col);

                    day++;
                    if (day > days_in_month)
                    {
                        day = 1;
                        font_color = Brushes.Gray;
                    }
                }
            }
            day = DateTime.DaysInMonth((month == 1 ? year - 1 : year), (month == 1 ? 12 : month - 1));
            for (int row = 0, col = start_day_of_month - 1; col >= 0; col--)
            {
                TextBlock text = get_textblock(row, col);
                text.Foreground = font_color;
                text.Text = day.ToString();
                day --;
            }
        }
        private int day_of_week(DateTime date)
        {
            int _return = 0;
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    _return = 0;
                    break;
                case DayOfWeek.Monday:
                    _return = 1;
                    break;
                case DayOfWeek.Tuesday:
                    _return = 2;
                    break;
                case DayOfWeek.Wednesday:
                    _return = 3;
                    break;
                case DayOfWeek.Thursday:
                    _return = 4;
                    break;
                case DayOfWeek.Friday:
                    _return = 5;
                    break;
                case DayOfWeek.Saturday:
                    _return = 6;
                    break;
                default:
                    break;
            }
            return _return;
        }

        private TextBlock get_textblock(int row, int col)
        {
            TextBlock _return = null;

            if (row >= 6 || row < 0 || col < 0 || col >= 7) return null;
            int _row = row + 2, _col = col;
            var elements =
            Grid_Number.Children.Cast<UIElement>().Where(e => Grid.GetRow(e) == _row && Grid.GetColumn(e) == _col);
            foreach (var element in elements)
            {
                if (element.GetType().ToString().Contains("TextBlock"))
                {
                    _return = (TextBlock)element;
                    break;

                }
            }

            return _return;
        }

        private void reset()
        {
            Date.Text = "9999-99-99";
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    TextBlock text = get_textblock(row, col);
                    text.Text = "99";
                    text.Foreground = Brushes.White;

                    if (is_highlighted_today(row, col)) unhighlight_today(row, col);
                    if (is_highlighted_schedule(row, col)) unhighlight_schedule(row, col);
                }
            }
        }

        public void Awake()
        {
            reset();
            set_date();
            set_days();
        }
    }
}
