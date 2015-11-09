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

namespace Calendar_for_JARVIS
{
    /// <summary>
    /// Interaction logic for ProjectScreen.xaml
    /// </summary>
    public partial class ProjectScreen : UserControl
    {

        private calendar_for_jarvis widgetView;
        private ScheduleList scheduleView;

        public ProjectScreen()
        {
            InitializeComponent();

            widgetView = new calendar_for_jarvis();
            scheduleView = new ScheduleList();

#if DEBUG
            Screen.Content = scheduleView;
#else
            Screen.Content = widgetView;
#endif
        }

        public void IsExpand(bool value)
        {
            if (value == false)
            {
                Screen.Content = widgetView;
            }
            else
            {
                Screen.Content = scheduleView;
            }
        }
    }
}
