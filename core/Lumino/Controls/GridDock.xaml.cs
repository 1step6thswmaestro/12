using Lumino.Controls;
using Lumino.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Lumino
{
    /// <summary>
    /// GridDock.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GridDock : UserControl
    {
        #region 속성
        public List<Double> RowDefinitions = new List<Double>();
        public List<Double> ColumnDefinitions = new List<Double>();

        private int _Row;
        public int Row
        {
            get { return _Row; }
            set
            {
                _Row = value;
                UpdateView();
            }
        }

        private int _Column;
        public int Column
        {
            get { return _Column; }
            set
            {
                _Column = value;
                UpdateView();
            }
        }

        private double _GridWidth;
        public double GridWidth
        {
            get { return _GridWidth; }
        }

        private double _GridHeight;
        public double GridHeight
        {
            get { return _GridHeight; }
        }

        private bool _Guideline;
        public bool Guideline
        {
            get { return _Guideline; }
            set
            {
                _Guideline = value;
                UpdateView();
            }
        }

        private bool _GuidelineWhenMove;
        public bool GuidelineWhenMove
        {
            get { return _GuidelineWhenMove; }
            set
            {
                _GuidelineWhenMove = value;
            }
        }

        private bool _Overflow;
        public bool Overflow
        {
            get { return _Overflow; }
            set
            {
                _Overflow = value;
            }
        }

        private int _GridThickness = 2;
        public int GridThickness
        {
            get { return _GridThickness; }
            set
            {
                _GridThickness = value;
            }
        }

        private bool _IsDrawerOpen;
        public bool IsDrawerOpen
        {
            get { return _IsDrawerOpen; }
            set
            {
                if (!_IsDrawerOpening)
                {
                    _IsDrawerOpening = true;
                    _IsDrawerOpen = value;
                    Storyboard DrawerAnimation = new Storyboard();
                    DoubleAnimation AnimationRotate = new DoubleAnimation();
                    ThicknessAnimation AnimationMargin = new ThicknessAnimation();
                    CubicEase AnimationEasing = new CubicEase();
                    TimeSpan AnimationDuration = TimeSpan.FromMilliseconds(500);

                    RotateTransform Rotate = (RotateTransform)ImageGrip.RenderTransform;
                    AnimationRotate.From = Rotate.Angle;
                    AnimationRotate.To = value ? 180 : 0;
                    AnimationRotate.Duration = AnimationDuration;
                    AnimationRotate.EasingFunction = AnimationEasing;

                    AnimationMargin.From = StackDrawer.Margin;
                    AnimationMargin.To = value ? new Thickness(0, 0, 0, 0) : new Thickness(0, 0, 0, -StackDrawerContent.ActualHeight);
                    AnimationMargin.Duration = AnimationDuration;
                    AnimationMargin.EasingFunction = AnimationEasing;

                    DrawerAnimation.Children.Add(AnimationRotate);
                    DrawerAnimation.Children.Add(AnimationMargin);

                    Storyboard.SetTargetProperty(AnimationRotate, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));
                    Storyboard.SetTargetProperty(AnimationMargin, new PropertyPath(MarginProperty));

                    Storyboard.SetTarget(AnimationRotate, ImageGrip);
                    Storyboard.SetTarget(AnimationMargin, StackDrawer);

                    if (value)
                    {
                        StackDrawerContent.Visibility = Visibility.Visible;
                    }

                    DrawerAnimation.Completed += (s, e) =>
                    {
                        if (!value)
                        {
                            StackDrawerContent.Visibility = Visibility.Hidden;
                        }

                        _IsDrawerOpening = false;
                    };
                    DrawerAnimation.Begin();
                }
            }
        }

        private bool _IsDrawerOpening;
        public bool IsDrawerOpening
        {
            get { return _IsDrawerOpening; }
        }

        private GridWidget _ExpandedWidget;
        public GridWidget ExpandedWidget
        {
            get
            {
                foreach (GridWidget Widget in WidgetList)
                {
                    if (Widget.Expand)
                    {
                        return Widget;
                    }
                }

                return null;
            }
        }
        #endregion

        #region 객체
        public ConfigManager Config = new ConfigManager();
        public List<GridWidget> WidgetList = new List<GridWidget>();
        #endregion

        #region 그래픽
        protected override void OnRender(DrawingContext dc)
        {
            if (Guideline)
            {
                double TopOffset = 0;
                double LeftOffset = 0;

                Pen DrawPen = new Pen(Brushes.White, GridThickness);
                DrawPen.Freeze();

                foreach (double Row in RowDefinitions)
                {
                    dc.DrawLine(DrawPen, new Point(0, TopOffset), new Point(this.ActualWidth, TopOffset));
                    TopOffset += Row;
                }

                dc.DrawLine(DrawPen, new Point(0, TopOffset), new Point(this.ActualWidth, TopOffset));

                foreach (double Column in ColumnDefinitions)
                {
                    dc.DrawLine(DrawPen, new Point(LeftOffset, 0), new Point(LeftOffset, this.ActualHeight));
                    LeftOffset += Column;
                }

                dc.DrawLine(DrawPen, new Point(LeftOffset, 0), new Point(LeftOffset, this.ActualHeight));
            }

            base.OnRender(dc);
        }
        #endregion

        #region 내부 함수
        private BitmapImage ImageLoad(string Path)
        {
            BitmapImage Image = new BitmapImage();
            Image.BeginInit();
            Image.UriSource = new Uri(Path);
            Image.CacheOption = BitmapCacheOption.OnDemand;
            Image.EndInit();

            return Image;
        }
        #endregion

        #region 사용자 함수
        public void Add(GridWidget Widget)
        {
            Widget.ParentDock = this;
            WidgetList.Add(Widget);
            CanvasRoot.Children.Add(Widget);
            Config.SaveWidgets();
        }

        public void Remove(GridWidget Widget)
        {
            Widget.ParentDock = null;
            WidgetList.Remove(Widget);
            CanvasRoot.Children.Remove(Widget);
            Config.SaveWidgets();
        }

        public void BringToFront(GridWidget Widget)
        {
            int Max = 0;

            foreach (GridWidget Target in CanvasRoot.Children)
            {
                if (Target != Widget)
                {
                    Max = Math.Max(Math.Max(Panel.GetZIndex(Target), Panel.GetZIndex(Widget)), Max);
                    Console.WriteLine(Panel.GetZIndex(Target));
                }
            }

            Panel.SetZIndex(Widget, Max + 1);
        }
        #endregion

        private void UpdateView()
        {
            // 초기화
            RowDefinitions.Clear();
            ColumnDefinitions.Clear();

            // 그리드 추가
            double ActualRow = ActualHeight / Row;
            for (int i = 0; i < Row; i++)
            {
                RowDefinitions.Add(ActualRow);
            }

            double ActualColumn = ActualWidth / Column;
            for (int i = 0; i < Column; i++)
            {
                ColumnDefinitions.Add(ActualColumn);
            }

            // 속성 정보 갱신
            _GridWidth = ActualColumn;
            _GridHeight = ActualRow;

            // 그래픽 표시 갱신
            InvalidateVisual();

            // 위젯 서랍 크기 갱신
            StackDrawer.Margin = new Thickness(0, 0, 0, -StackDrawerContent.ActualHeight);
        }

        private void LoadWidgets()
        {
            // 위젯 검색
            string[] Widgets = Directory.GetFiles(ConfigManager.WidgetPath, "*.ini", SearchOption.AllDirectories);

            // 검색된 위젯 추가
            foreach(string Path in Widgets)
            {
                // 위젯 구성 분석
                INI Widget = new INI(Path);
                string Title = Widget.GetValue("General", "Title");

                // 위젯 섬네일 컨트롤 생성
                StackPanel WidgetStack = new StackPanel
                {
                    Width = 120,
                    Height = 120,
                    Margin = new Thickness(15, 10, 0, 0)
                };

                Image WidgerThumb = new Image
                {
                    Width = 80,
                    Height = 80,
                    Source = ImageLoad(Directory.GetParent(Path) + "\\" + System.IO.Path.GetFileNameWithoutExtension(Path) + ".png")
                };
                WidgetStack.Children.Add(WidgerThumb);

                TextBlock WidgetTitle = new TextBlock
                {
                    Text = Title,
                    Margin = new Thickness(0, 10, 0, 0),
                    VerticalAlignment = VerticalAlignment.Bottom,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                WidgetStack.Children.Add(WidgetTitle);

                // 위젯 섬네일 컨트롤 이벤트 설정
                WidgetStack.MouseLeftButtonDown  += (s, e) =>
                {
                    IsDrawerOpen = false;
                    GridWidget Target = new GridWidget
                    {
                        NowLoading = true
                    };
                    if (Target.Load(Path))
                    {
                        Add(Target);
                        Target.StartMouseDown();
                    }
                };

                // 콘텐츠 스택에 섬네일 컨트롤 추가
                StackDrawerContent.Children.Add(WidgetStack);
            }
        }

        public GridDock()
        {
            InitializeComponent();
            Loaded += GridDock_Loaded;
            SizeChanged += GridDock_SizeChanged;
            GripDrawer.MouseLeftButtonDown += GripDrawer_MouseLeftButtonDown;
            BtnBack.MouseLeftButtonUp += BtnBack_MouseLeftButtonUp;
            BtnAbout.MouseLeftButtonUp += BtnAbout_MouseLeftButtonUp;
            Config.Initialize(this);
            Config.LoadWidgets();
        }

        private void BtnBack_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ExpandedWidget.Expand = false;
        }

        private void BtnAbout_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AlertDialog Dialog = new AlertDialog(Application.Current.MainWindow,
                "정보",
                "이름: " + ExpandedWidget.Title + "\n" +
                "제작: " + ExpandedWidget.Author + "\n" +
                "설명: " + ExpandedWidget.Summary,
                false);

            Dialog.ShowDialog();
        }

        private void GridDock_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateView();
            LoadWidgets();
            StackDrawerContent.Visibility = Visibility.Hidden;
        }

        private void GridDock_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateView();
        }

        private void GripDrawer_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            IsDrawerOpen = !IsDrawerOpen;
        }
    }
}
