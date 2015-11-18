using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Calendar_for_JARVIS
{
    /// <summary>
    /// This class is for controling calendar widget.
    /// This class shows Fullscreen view and get schedules from calendar_for_jarvis class.
    /// This class starts after calendar_for_jarvis class item is created.
    /// 
    /// @version 2015-11-18
    /// @author NULLEDGE
    /// </summary>
    public partial class ScheduleList : UserControl
    {
        public ScheduleList()
        {
            InitializeComponent();

            // clear all schedules.
            ScheduleListView.Items.Clear();

            // add date and schedule items into list.
            CultureInfo ci = new CultureInfo("en-US");
            Events events = calendar_for_jarvis.events;
            int? prevDay = null;
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {

                    try
                    {
                        // add date item only if start date of event is changed.
                        DateTime startDateTime = (eventItem.Start.DateTime == null ? DateTime.Parse(eventItem.Start.Date) : eventItem.Start.DateTime.Value);
                        if (prevDay == null || startDateTime.Day != prevDay )
                            ScheduleListView.Items.Add(NewDateItem(startDateTime));
                        ScheduleListView.Items.Add(NewScheduleItem(eventItem));

                        prevDay = startDateTime.Day;
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

        /// <summary>
        /// Add new date into schedule list
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private ListViewItem NewDateItem(DateTime date)
        {
            ListViewItem _listViewItem = new ListViewItem {
                Padding = new Thickness(0) };
            StackPanel _innerStackPannel = new StackPanel
            { VerticalAlignment = VerticalAlignment.Center };
            CultureInfo ci = new CultureInfo("en-US");
            _innerStackPannel.Children.Add(new TextBlock 
            { Text = date.ToString("MMM dd", ci), Style = Resources["DateStyle"] as Style });
            _innerStackPannel.Children.Add(new Line
            { Style = Resources["DateUnderline"] as Style });

            _listViewItem.Content = _innerStackPannel;

            return _listViewItem;
        }

        /// <summary>
        /// Add new schedule into schedule list
        /// </summary>
        /// <param name="eventItem"></param>
        /// <returns></returns>
        private ListViewItem NewScheduleItem(Event eventItem)
        {
            CultureInfo ci = new CultureInfo("en-US");
            ListViewItem _listViewItem = new ListViewItem {
                Padding = new Thickness(0) };
            StackPanel _innerStackPannel = new StackPanel
            { VerticalAlignment = VerticalAlignment.Center,
              Orientation = Orientation.Horizontal };
            StackPanel _timeStackPanel = new StackPanel {
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                Margin = new Thickness (3, 0, 0, 0) };

            // not all day event
            if (eventItem.Start.Date == null)
            {
                _timeStackPanel.Children.Add(new TextBlock
                {
                    Text = eventItem.Start.DateTime.Value.ToString("hh:mmtt", ci),
                    Style = Resources["ScheduleTimeStyle"] as Style
                }); _timeStackPanel.Children.Add(new TextBlock
                {
                    Text = eventItem.End.DateTime.Value.ToString("hh:mmtt", ci),
                    Style = Resources["ScheduleTimeStyle"] as Style
                });
            }
            else
            {
                _timeStackPanel.Children.Add(new TextBlock { Text = "All Day",
                Style = Resources["ScheduleTimeStyle"] as Style});
                _timeStackPanel.Children.Add(new TextBlock { Text = "Event",
                Style = Resources["ScheduleTimeStyle"] as Style});
            }
            _innerStackPannel.Children.Add(_timeStackPanel);

            _innerStackPannel.Children.Add(new TextBlock
            {
                Text = (eventItem.Summary == null ? "Untitled" : eventItem.Summary),
                Style = Resources["ScheduleStyle"] as Style });

            _listViewItem.Content = _innerStackPannel;

            return _listViewItem;
        }
    }
}
