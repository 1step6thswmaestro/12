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
    public partial class WidgetView : Window
    {
        static private bool is_expanded = false;

        public WidgetView()
        {
            InitializeComponent();

            HIGHLIGHT_TODAY     = Resources["HighlightToday"] as Style;
            HIGHLIGHT_SCHEDULE  = Resources["HighlightSchedule"] as Style;

            reset();
            refresh();

            foreach (UIElement element in Grid_Calendar.Children)
            {
                if (element is TextBlock)
                {
                    TextBlock text = element as TextBlock;
                    text.MouseLeftButtonDown += new MouseButtonEventHandler(on_click);
                }
            }
        }

        public void on_click(object sender, MouseButtonEventArgs args)
        {
            if (is_expanded == false) return;

            TextBlock text = sender as TextBlock;

            Year.Text = text.Text;
            Date.Text = "";
        }

        private void show(int row, int col)
        {
            Year.Text = row.ToString();
            Date.Tag = col.ToString();
        }

        Events events;

        private void attatch_schedule_list()
        {
            IEnumerable<ListView> lists = get_all<ListView>(NUMBER_OF_GRID_ROW + 2, 0);
            if (lists != null) {
                lists = get_all<ListView>(NUMBER_OF_GRID_ROW + 1, 0);
                foreach (ListView list in lists)
                    list.Visibility = System.Windows.Visibility.Visible;
                IEnumerable<Button> buttons = get_all<Button>(NUMBER_OF_GRID_ROW + 2, 0);
                foreach (Button button in buttons)
                    button.Visibility = System.Windows.Visibility.Visible;
                return;
            }
            RowDefinition last_row =
                Grid_Calendar.RowDefinitions.ElementAt<RowDefinition>(NUMBER_OF_GRID_ROW+2);
            last_row.Height = new GridLength(40);

            ListView schedule_list = new ListView {
                Background = Brushes.Black,     BorderBrush = Brushes.Black,
            };
            ScrollViewer.SetHorizontalScrollBarVisibility(schedule_list, ScrollBarVisibility.Hidden);
            ScrollViewer.SetVerticalScrollBarVisibility(schedule_list, ScrollBarVisibility.Hidden);
            Grid.SetColumnSpan(schedule_list, NUMBER_OF_GRID_COL);
            Grid.SetRow(schedule_list, NUMBER_OF_GRID_ROW + 2);
            Grid_Calendar.Children.Add(schedule_list);

            int selected_row, selected_col;

            DateTime today = DateTime.Today;
            int days = DateTime.DaysInMonth(today.Year, today.Month);
            int start_day_of_month = (int)today.AddDays(-today.Day + 1).DayOfWeek;
            int days_in_month = DateTime.DaysInMonth(today.Year, today.Month);

            selected_row = (today.Day + start_day_of_month - 1) / 7;
            selected_col = (int)today.DayOfWeek;

            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {

                    try
                    {
                        DateTime start_date = DateTime.ParseExact(
                            eventItem.Start.Date, "yyyy-MM-dd",
                            System.Globalization.CultureInfo.InvariantCulture);
                        DateTime end_date = DateTime.ParseExact(
                            eventItem.End.Date, "yyyy-MM-dd",
                            System.Globalization.CultureInfo.InvariantCulture); ;

                        if (DateTime.Compare(start_date, today) <= 0 && DateTime.Compare(today, end_date) <= 0)
                        {
                            schedule_list.Items.Add(new ListViewItem
                            {
                                Foreground = Brushes.White,
                                FontSize = 4,
                                Content = eventItem.Summary
                            });
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

            Button up_button = new Button
            {
                Background = Brushes.White, BorderThickness = new System.Windows.Thickness(0),
                Height = 7, Width = 7,
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                Margin = new System.Windows.Thickness(0, 2, 2, 0)

            };
            Button down_button = new Button
            {
                Background = Brushes.White,
                BorderThickness = new System.Windows.Thickness(0),
                Height = 7,
                Width = 7,
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                Margin = new System.Windows.Thickness(0, 10, 2, 0)
            };
            Grid.SetColumnSpan(up_button, NUMBER_OF_GRID_COL);
            Grid.SetRow(up_button, NUMBER_OF_GRID_ROW + 2);
            Grid_Calendar.Children.Add(up_button);
            Grid.SetColumnSpan(down_button, NUMBER_OF_GRID_COL);
            Grid.SetRow(down_button, NUMBER_OF_GRID_ROW + 2);
            Grid_Calendar.Children.Add(down_button);
            
        }
        private void detach_schedule_list()
        {
            RowDefinition last_row =
                Grid_Calendar.RowDefinitions.ElementAt<RowDefinition>(NUMBER_OF_GRID_ROW + 2);
            last_row.Height = new GridLength(10);

            foreach (UIElement element in Grid_Calendar.Children)
            {
                if (element is ListView || element is Button)
                {
                    element.Visibility = System.Windows.Visibility.Hidden;
                }
            }
        }

        /// <summary>
        /// Called when widget is expanded or contracted.
        /// </summary>
        /// <param name="type">
        /// If type is true then widget is expaned. Else widget is contracted.
        /// </param>
        public void IsExpand(bool type)
        {
            switch (type)
            {
                    // get smaller
                case false:
                    detach_schedule_list();
                    break;
                    // get larger
                case true:
                    attatch_schedule_list();
                    break;
            }
        }

        /// <summary>
        /// Refresh the content of calendar.
        /// </summary>
        private void refresh()
        {
            set_date();
            set_days();
            set_schedule_highlight();
        }

        static private int NUMBER_OF_GRID_ROW = 6;
        static private int NUMBER_OF_GRID_COL = 7;

        #region Control type of highlight mark
        enum Highlight { TODAY, SCHEDULE }
        private Style HIGHLIGHT_TODAY, HIGHLIGHT_SCHEDULE;
        private Style highlight_style(Highlight type) {
            switch (type) {
                case Highlight.TODAY :
                    return HIGHLIGHT_TODAY;
                case Highlight.SCHEDULE :
                    return HIGHLIGHT_SCHEDULE;
                default:
                    return null;
            }
        }
        #endregion

        /// <summary>
        /// Reset content of calendar.
        /// </summary>
        private void reset()
        {
            Year.Text = "9999년";
            Date.Text = "99월 99일";
            for (int row = 0; row < NUMBER_OF_GRID_ROW; row++)
            {
                for (int col = 0; col < NUMBER_OF_GRID_COL; col++)
                {
                    TextBlock text = get<TextBlock>(row, col);
                    text.Text = "99";
                    text.Style = Resources["ThisMonth"] as Style;

                    if (is_highlighted(row, col, Highlight.TODAY)) unhighlight(row, col, Highlight.TODAY);
                    if (is_highlighted(row, col, Highlight.SCHEDULE)) unhighlight(row, col, Highlight.SCHEDULE);
                }
            }
        }

        /// <summary>
        /// Check if row and column is out of Grid_Calendar.
        /// </summary>
        /// <param name="row">Row of Grid_Calendar.</param>
        /// <param name="col">Column of Grid_Calendar.</param>
        /// <returns>True if row and column is out of Grid_Calendar.</returns>
        static private bool is_out_of_grid(int row, int col) {
            return (row >= NUMBER_OF_GRID_ROW 
                || row < 0 
                || col < 0 
                || col >= NUMBER_OF_GRID_COL);
        }

        #region Methods for get UI elements in Grid. Access using row and column.
        /// <summary>
        /// Get a UIElement of typename T in Grid_Calendar, specified with row and column.
        /// </summary>
        /// <typeparam name="T">typename of class inherit UIElement.</typeparam>
        /// <param name="row">Specified row of Grid_Calendar.</param>
        /// <param name="col">Specified column of Grid_Calendar.</param>
        /// <returns>UIElement</returns>
        private T get<T> (int row, int col) where T : UIElement
        {
            if (is_out_of_grid(row, col)) return default(T);
            row += 2;
            var elements = Grid_Calendar.Children.Cast<UIElement>().Where
                (e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col);
            foreach (var element in elements)
                if (element is T)
                    return element as T;
            return default(T);
        }
        /// <summary>
        /// Get all UIElements of typename T in Grid_Calendar, specified with row and column.
        /// </summary>
        /// <typeparam name="T">typename of class inherit UIElement.</typeparam>
        /// <param name="row">Specified row of Grid_Calendar.</param>
        /// <param name="col">Specified column of Grid_Calendar.</param>
        /// <returns>List of UIElemenets.</returns>
        private IEnumerable<T> get_all<T>(int row, int col) where T : UIElement
        {
            if (is_out_of_grid(row, col)) return null;
            row += 2;
            var elements = Grid_Calendar.Children.Cast<UIElement>().Where
                (e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col);
            List<T> _return = new List<T>();
            foreach (var element in elements)
                if (element is T)
                    _return.Add(element as T);
            return _return;
        }
        #endregion

        #region Methods for highlight mark.
        /// <summary>
        /// Check if cell is highlighted.
        /// </summary>
        /// <param name="row">Row of cell.</param>
        /// <param name="col">Column of cell.</param>
        /// <param name="highlight">Type of highlight.</param>ed
        /// <returns>True if cell is highlighted or not.</returns>
        private bool is_highlighted (int row, int col, Highlight highlight)
        {
            if (is_out_of_grid(row, col)) return false;
            IEnumerable<Ellipse> ellipses = get_all<Ellipse>(row, col);
            foreach (Ellipse ellipse in ellipses)
                if (ellipse.Style.Equals(highlight_style(highlight))) return true;
            return false;
        }
        /// <summary>
        /// Delete highlight of cell.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="highlight"></param>
        private void unhighlight (int row, int col, Highlight highlight)
        {
            if (is_out_of_grid(row, col)) return;
            IEnumerable<Ellipse> ellipses = get_all<Ellipse>(row, col);
            foreach (Ellipse ellipse in ellipses)
                if (ellipse.Style.Equals(highlight_style(highlight)))
                {
                    Grid_Calendar.Children.Remove(ellipse as UIElement);
                    return;
                }
        }
        private void highlight (int row, int col, Highlight highlight)
        {
            if (is_out_of_grid(row, col)) return;
            Ellipse ellipse = new Ellipse { Style = highlight_style(highlight) };
            Grid.SetRow(ellipse, row + 2);
            Grid.SetColumn(ellipse, col);
            Grid_Calendar.Children.Add(ellipse);
        }
        #endregion

        #region Set date and days.
        /* date is text at the top, in "YYYY년 MM월 DD일" format
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
            int days = DateTime.DaysInMonth(today.Year, today.Month);
            int start_day_of_month = (int)today.AddDays(-today.Day + 1).DayOfWeek;
            int days_in_month = DateTime.DaysInMonth(today.Year, today.Month);

            int day = 1;

            Style fontstyle = Resources["ThisMonth"] as Style;

            for (int row = 0; row < 6; row++)
            {
                for (int col = (row == 0 ? start_day_of_month : 0); col < 7; col++)
                {
                    TextBlock text = get<TextBlock>(row, col);
                    text.Style = fontstyle;
                    text.Text = day.ToString();

                    if (day == DateTime.Today.Day 
                        && fontstyle.Equals (Resources["ThisMonth"] as Style) == true)
                        highlight(row, col, Highlight.TODAY);

                    day++;
                    if (day > days_in_month)
                    {
                        day = 1;
                        fontstyle = Resources["NotThisMonth"] as Style;
                    }
                }
            }

            {
                DateTime day_in_last_month = DateTime.Today.AddDays(-DateTime.Today.Day);
                day = DateTime.DaysInMonth(day_in_last_month.Year, day_in_last_month.Month);
            }
            for (int row = 0, col = start_day_of_month - 1; col >= 0; col--)
            {
                TextBlock text = get<TextBlock>(row, col);
                text.Style = fontstyle;
                text.Text = day.ToString();

                day --;
            }
        }
        #endregion

        #region Get and highlight schedules from Google Calendar
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
            int days = DateTime.DaysInMonth(today.Year, today.Month);
            int start_day_of_month = (int)today.AddDays(-today.Day + 1).DayOfWeek;
            int days_in_month = DateTime.DaysInMonth(today.Year, today.Month);

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = today.AddDays(-today.Day + 1);
            request.TimeMax = today.AddDays(-today.Day + 1 + days_in_month);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            events = request.Execute();
            Console.WriteLine("Upcoming events:");
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {

                    try
                    {
                        DateTime start_date = DateTime.ParseExact(
                            eventItem.Start.Date, "yyyy-MM-dd",
                            System.Globalization.CultureInfo.InvariantCulture);
                        DateTime end_date = DateTime.ParseExact(
                            eventItem.End.Date, "yyyy-MM-dd",
                            System.Globalization.CultureInfo.InvariantCulture); ;

                        while (start_date != end_date)
                        {
                            int row = (start_date.Day+start_day_of_month-1)/7,
                                col = (int)start_date.DayOfWeek;
                            highlight (row, col, Highlight.SCHEDULE);
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
        #endregion
    }
}
