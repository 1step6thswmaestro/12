using System;
using System.Windows;
using System.Windows.Media;

namespace Lumino
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 초기화
            bool IsFullscreen = false;
            foreach(string arg in Environment.GetCommandLineArgs())
            {
                try
                {
                    if (arg.Equals("-Fullscreen"))
                    {
                        Top = 0;
                        Left = 0;
                        Width = SystemParameters.PrimaryScreenWidth;
                        Height = SystemParameters.PrimaryScreenHeight;
                        WindowStyle = WindowStyle.None;
                        ResizeMode = ResizeMode.NoResize;
                        Topmost = true;
                        IsFullscreen = true;
                    }
                    if (arg.IndexOf("-Margin(") != -1)
                    {
                        string[] margin = arg.Split('(')[1].Split(')')[0].Split(',');
                        DockRoot.Margin = new Thickness(double.Parse(margin[0]), double.Parse(margin[1]), double.Parse(margin[2]), double.Parse(margin[3]));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (!IsFullscreen)
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }

            // 이미지 품질
            RenderOptions.SetBitmapScalingMode(this, BitmapScalingMode.HighQuality);

            // 이벤트 설정
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 독 설정
            DockRoot.Row = 18;
            DockRoot.Column = 12;
            DockRoot.Overflow = false;
            DockRoot.GuidelineWhenMove = true;
        }
    }
}
