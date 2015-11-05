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

namespace clock_for_jarvis
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();

            Awake();
        }


        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        // Initialization
        private void Awake()
        {
            Hour.Text = "INIT";
            Minute.Text = "ALIZE";

            Timer.Tick += new EventHandler(timer_tick);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

        static private bool divider_visible = false;
        private void timer_tick(object sender, EventArgs e)
        {
            Hour.Text = DateTime.Now.Hour.ToString("00");
            Minute.Text = DateTime.Now.Minute.ToString("00");

            Divider.Visibility = (divider_visible ? Visibility.Visible : Visibility.Hidden); //Visibility.Hidden;
            divider_visible = !divider_visible;
        }
    }
}
