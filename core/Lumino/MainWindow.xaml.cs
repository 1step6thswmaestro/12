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
            /*
            Top = 0;
            Left = 0;
            Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            Topmost = true;
            */
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // 이미지 품질
            RenderOptions.SetBitmapScalingMode(this, BitmapScalingMode.HighQuality);

            // 이벤트 설정
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 독 설정
            DockRoot.Row = 15;
            DockRoot.Column = 10;
            DockRoot.Overflow = false;
            DockRoot.GuidelineWhenMove = true;

            // 위젯 불러오기
            GridWidget Clock = new GridWidget();
            Clock.Load(@"C:\Users\SEOP\Documents\Visual Studio 2015\Projects\Lumino\Widgets\Clock\Clock.ini");
            DockRoot.Add(Clock);

            GridWidget ParticleClock = new GridWidget();
            ParticleClock.Load(@"C:\Users\SEOP\Documents\Visual Studio 2015\Projects\Lumino\Widgets\ParticleClock\ParticleClock.ini");
            DockRoot.Add(ParticleClock);
        }
    }
}
