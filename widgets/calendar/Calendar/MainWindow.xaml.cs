using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

using System.IO;
using System.Threading;

namespace Calendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /* Dictionary for matching DateTime to <row, column> in Grid_Number
         * Key = DateTime
         * Value = row * 100 + column
         */
        private Dictionary<DateTime, int> date_to_grid;

        public MainWindow()
        {
            InitializeComponent();
            Awake(); 
        }

        static private int NUMBER_OF_GRID_ROW = 6;
        static private int NUMBER_OF_GRID_COL = 7;

        // Check if it's out of Grid_Number's range
        static private bool is_out_of_grid(int row, int col) {
            return (row >= NUMBER_OF_GRID_ROW 
                || row < 0 
                || col < 0 
                || col >= NUMBER_OF_GRID_COL);
        }
        // Get inner grid of Grid_Number
        private Grid get_nested_grid (int row, int col) {
            return (Grid)first(Grid_Number, row, col, "Grid");
        }
        // Get TextBlock of Grid_Number
        private TextBlock get_textblock(int row, int col)
        {
            if (is_out_of_grid(row, col)) return null;

            row += 2;

            return (TextBlock)first(Grid_Number, row, col, "TextBlock");
        }

        // Refactored methods to access inner UIElements of grids
        private IEnumerable<UIElement> cast(Grid grid)
        {
            return grid.Children.Cast<UIElement>();
        }
        private IEnumerable<UIElement> where(Grid grid, int row, int col)
        {
            return cast(grid).Where(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col);
        }
        private UIElement first(Grid grid, int row, int col)
        {
            return where(grid, row, col).ElementAt(0);
        }
        private UIElement first(Grid grid, int row, int col, string type)
        {
            var elements = where(grid, row, col);
            foreach (var element in elements)
            {
                if (element.GetType().ToString().Contains(type)) return element;
            }
            return null;
        }
        private int count(Grid grid, int row, int col)
        {
            return where(grid, row, col).Count();
        }

        // Methods for highlight of today
        private bool is_highlighted_today (int row, int col)
        {
            if (is_out_of_grid(row, col)) return false;

            row += 2;

            Grid nested_grid = get_nested_grid(row, col);
            return (count(nested_grid, 1, 0) != 0);
        }
        private void unhighlight_today(int row, int col)
        {
            if (is_out_of_grid(row, col)) return;

            row += 2;

            Grid nested_grid = get_nested_grid(row, col);
            Ellipse highlight = (Ellipse)first(nested_grid, 1, 0, "Ellipse"); //(Ellipse)nested_grid.Children.Cast<UIElement>().First(e => Grid.GetRow(e) == 1 && Grid.GetColumn(e) == 0);
            nested_grid.Children.Remove(highlight);
            return;
        }
        private void highlight_today(int row, int col)
        {

            if (is_out_of_grid(row, col)) return;

            row += 2;

            Grid nested_grid = get_nested_grid(row, col);
            Ellipse today_highlight = new Ellipse
            {
                Width = 6.5,
                Height = 6.5,
                Fill = Brushes.Red,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            };
            Grid.SetRow(today_highlight, 1);
            Grid.SetColumn(today_highlight, 0);
            nested_grid.Children.Add(today_highlight);
        }

        // Methods for highlights of schedules
        private bool is_highlighted_schedule(int row, int col)
        {
            if (is_out_of_grid(row, col)) return false;

            row += 2;

            Grid nested_grid = get_nested_grid(row, col);
            return (count(nested_grid, 3, 0) != 0);
        }
        private void unhighlight_schedule(int row, int col)
        {
            if (is_out_of_grid(row, col)) return;

            row += 2;

            Grid nested_grid = get_nested_grid(row, col);
            Ellipse highlight = (Ellipse)first(nested_grid, 3, 0);
            nested_grid.Children.Remove(highlight);
        }
        private void highlight_schedule(int row, int col)
        {
            if (is_out_of_grid(row, col)) return;

            row += 2;

            Grid nested_grid = get_nested_grid(row, col);
            Ellipse today_highlight = new Ellipse
            {
                Width = 2,
                Height = 2,
                Fill = Brushes.White,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            };
            Grid.SetRow(today_highlight,3);
            Grid.SetColumn(today_highlight, 0);
            nested_grid.Children.Add(today_highlight);
        }

        /* Set date and days
         * date is text at the top, in "YYYY년 MM월 DD일" format
         * days are numbers in grid.
         */
        private void set_date()
        {
            DateTime today = DateTime.Today;
            Year.Text = today.ToString("yyyy년");
            Date.Text = today.ToString("MM월 dd일");
        }
        private void set_days()
        {
            DateTime today = DateTime.Today;
            int year = today.Year;
            int month = today.Month;
            int days = DateTime.DaysInMonth(year, month);
            int start_day_of_month = (int)DateTime.Today.AddDays(-today.Day + 1).DayOfWeek;
            int days_in_month = DateTime.DaysInMonth(year, month);

            int day = 1;
            Brush font_color = Brushes.White;

            DateTime dateTime_for_dictionay = DateTime.Today.AddDays(-today.Day + 1);

            for (int row = 0; row < 6; row++)
            {
                for (int col = (row == 0 ? start_day_of_month : 0); col < 7; col++)
                {
                    TextBlock text = get_textblock(row, col);
                    text.Foreground = font_color;
                    text.Text = day.ToString();

                    date_to_grid.Add(dateTime_for_dictionay, row * 100 + col);
                    dateTime_for_dictionay = dateTime_for_dictionay.AddDays(1);

                    if (day == today.Day) highlight_today(row, col);

                    day++;
                    if (day > days_in_month)
                    {
                        day = 1;
                        font_color = Brushes.Gray;
                    }
                }
            }
            dateTime_for_dictionay = DateTime.Today.AddDays(-today.Day);

            day = DateTime.DaysInMonth((month == 1 ? year - 1 : year), (month == 1 ? 12 : month - 1));
            for (int row = 0, col = start_day_of_month - 1; col >= 0; col--)
            {
                TextBlock text = get_textblock(row, col);
                text.Foreground = font_color;
                text.Text = day.ToString();

                date_to_grid.Add(dateTime_for_dictionay, col);
                dateTime_for_dictionay = dateTime_for_dictionay.AddDays(-1);

                day --;
            }
        }

        // Reset all UIElements
        private void reset()
        {
            Year.Text = "9999년";
            Date.Text = "99월 99일";
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

        // Get and highlight schedules from Google Calendar
        static private string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static private string ApplicationName = "Google Calendar API .NET Quickstart";
        private void set_schedule_highlight()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = System.IO.Path.Combine(credPath, ".credentials/calendar-dotnet-quickstart");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            DateTime today = DateTime.Today;
            int year = today.Year;
            int month = today.Month;
            int days = DateTime.DaysInMonth(year, month);
            int start_day_of_month = (int)DateTime.Today.AddDays(-today.Day + 1).DayOfWeek;
            int days_in_month = DateTime.DaysInMonth(year, month);

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Today.AddDays(-today.Day + 1);
            request.TimeMax = DateTime.Today.AddDays(-today.Day + 1 + days_in_month);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();
            Console.WriteLine("Upcoming events:");
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {

                    try
                    {
                        DateTime start_date = DateTime.ParseExact(eventItem.Start.Date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime end_date = DateTime.ParseExact(eventItem.End.Date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture); ;

                        while (start_date != end_date)
                        {
                            int row_and_col = date_to_grid[start_date];
                            int row = row_and_col / 100, col = row_and_col % 100;
                            highlight_schedule(row, col);
                            start_date = start_date.AddDays(1);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine("No upcoming events found.");
            }
        }

        // Initialize
        public void Awake()
        {
            date_to_grid = new Dictionary<DateTime, int>();

            reset();

            set_date();
            set_days();
            set_schedule_highlight();
        }
    }
}
