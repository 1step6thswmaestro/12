using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Lumino.Functions;
using CefSharp.Wpf;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Media;
using Lumino.Controls;

namespace Lumino
{
    /// <summary>
    /// GridWidget.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GridWidget : UserControl
    {
        #region 속성
        private int _Row;
        public int Row
        {
            get { return _Row; }
            set
            {
                _Row = value;
                SetPosition(value, Column);
            }
        }

        private int _Column;
        public int Column
        {
            get { return _Column; }
            set
            {
                _Column = value;
                SetPosition(Row, value);
            }
        }

        private bool _Expand = false;
        public bool Expand
        {
            get { return _Expand; }
            set
            {
                if (AppearanceExpandable && !ParentDock.IsDrawerOpening && !Resizing)
                {
                    _Expand = value;
                    if (value)
                    {
                        ParentDock.BringToFront(this);

                        OriginalX = Canvas.GetLeft(this);
                        OriginalY = Canvas.GetTop(this);
                        OriginalWidth = ActualWidth;
                        OriginalHeight = ActualHeight;

                        ExpandAnimation(true);
                        if (!AssemblyFile.Equals("local"))
                        {
                            CallMethod("IsExpand", true);
                        }
                        else
                        {
                            switch (AssemblyEntry)
                            {
                                case "WebView":
                                    ((ChromiumWebBrowser)BorderContent.Child).ExecuteScriptAsync("IsExpand(true);");
                                    break;
                            }
                        }

                        ParentDock.TextTitle.Text = Title;
                        ParentDock.GripDrawer.Visibility = Visibility.Collapsed;
                        ParentDock.StackDrawerContent.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        ExpandAnimation(false);
                        if (!AssemblyFile.Equals("local"))
                        {
                            CallMethod("IsExpand", false);
                        }
                        else
                        {
                            switch (AssemblyEntry)
                            {
                                case "WebView":
                                    ((ChromiumWebBrowser)BorderContent.Child).ExecuteScriptAsync("IsExpand(false);");
                                    break;
                            }
                        }

                        ParentDock.GripDrawer.Visibility = Visibility.Visible;
                        ParentDock.StackDrawerContent.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private int _ExpandMargin = 0;
        public int ExpandMargin
        {
            get { return _ExpandMargin; }
            set { _ExpandMargin = value; }
        }

        private GridDock _ParentDock;
        public GridDock ParentDock
        {
            get { return _ParentDock; }
            set { _ParentDock = value; }
        }

        private string _INI;
        public string INI
        {
            get { return _INI; }
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
        }

        private string _Author;
        public string Author
        {
            get { return _Author; }
        }

        private string _Summary;
        public string Summary
        {
            get { return _Summary; }
        }

        private string _AssemblyFile;
        public string AssemblyFile
        {
            get { return _AssemblyFile; }
        }

        private string _AssemblyEntry;
        public string AssemblyEntry
        {
            get { return _AssemblyEntry; }
        }

        private string _AssemblyArgument;
        public string AssemblyArgument
        {
            get { return _AssemblyArgument; }
        }

        private Type _WidgetTarget;
        public Type WidgetTarget
        {
            get { return _WidgetTarget; }
        }

        private UserControl _WidgetControl;
        public UserControl WidgetControl
        {
            get { return _WidgetControl; }
        }

        private int _AppearanceWidth;
        public int AppearanceWidth
        {
            get { return _AppearanceWidth; }
        }

        private int _AppearanceHeight;
        public int AppearanceHeight
        {
            get { return _AppearanceHeight; }
        }

        private bool _AppearanceExpandable;
        public bool AppearanceExpandable
        {
            get { return _AppearanceExpandable; }
        }

        private bool _NowLoading;
        public bool NowLoading
        {
            get { return _NowLoading; }
            set
            {
                _NowLoading = value;
            }
        }

        private string _LazyLoading;
        public string LazyLoading
        {
            get { return _LazyLoading; }
            set
            {
                _LazyLoading = value;
            }
        }

        private BitmapImage _LoadingImage;
        public BitmapImage LoadingImage
        {
            get { return _LoadingImage; }
            set
            {
                _LoadingImage = value;
                ImgLoading.Source = value;
            }
        }
        #endregion

        #region 객체
        private int LastRow;
        private int LastColumn;
        private int HeightRow;
        private int WidthColumn;
        private double OriginalX;
        private double OriginalY;
        private double OriginalWidth;
        private double OriginalHeight;
        private bool PositionError;
        private bool DeleteSelect;
        private bool GuidelineOriginal;
        private bool Resizing = false;
        private bool LongClick = false;
        private DispatcherTimer LongClickTimer;
        private Point LocalPosition;
        private BitmapImage SwapThumb;
        private BitmapImage SwapThumbExpand;
        #endregion

        #region 제어 함수
        private BitmapImage GetImageFromVisual(Visual visual)
        {
            Thickness margin = (Thickness)visual.GetValue(MarginProperty);
            if (margin == null | margin.Equals(new Thickness(0)))
            {
                visual.SetValue(MarginProperty, new Thickness(0));
            }

            MemoryStream memory = new MemoryStream();
            RenderTargetBitmap bitmap = new RenderTargetBitmap(
                Convert.ToInt32(visual.GetValue(ActualWidthProperty)),
                Convert.ToInt32(visual.GetValue(ActualHeightProperty)),
                96,
                96,
                PixelFormats.Pbgra32);
            bitmap.Render(visual);

            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));
            encoder.Save(memory);

            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.StreamSource = new MemoryStream(memory.ToArray());
            img.EndInit();

            memory.Dispose();
            visual.SetValue(MarginProperty, margin);

            return img;
        }

        private void ExpandAnimation(bool Value, Action Completed = null)
        {
            if (!Resizing)
            {
                Resizing = true;
                double X; double Y; double Width; double Height;

                // 값 계산
                if (Value)
                {
                    X = ExpandMargin;
                    Y = ExpandMargin;
                    Width = ParentDock.ActualWidth - ExpandMargin * 2;
                    Height = ParentDock.ActualHeight - ExpandMargin * 2;
                    ParentDock.GridTopMenu.Visibility = Visibility.Visible;
                    SwapThumb = GetImageFromVisual(BorderContent);
                }
                else
                {
                    X = OriginalX;
                    Y = OriginalY;
                    Width = OriginalWidth;
                    Height = OriginalHeight;
                    SwapThumbExpand = GetImageFromVisual(BorderContent);
                }

                // 전환 섬네일 생성
                Grid SwapGrid = new Grid();
                Image SwapImage = new Image
                {
                    Stretch = Stretch.Uniform,
                    Source = SwapThumb,
                    Opacity = Value ? 1 : 0
                };
                Image SwapImageExpand = new Image
                {
                    Stretch = Stretch.Uniform,
                    Source = SwapThumbExpand,
                    Opacity = Value ? 0 : 1
                };
                SwapGrid.Children.Add(SwapImageExpand);
                SwapGrid.Children.Add(SwapImage);
                BorderContentSwap.Child = SwapGrid;
                BorderContentSwap.Visibility = Visibility.Visible;
                BorderContent.Visibility = Visibility.Collapsed;

                // 애니메이션 설정
                Storyboard ExpandAnimation = new Storyboard();
                DoubleAnimation AnimationX = new DoubleAnimation();
                DoubleAnimation AnimationY = new DoubleAnimation();
                DoubleAnimation AnimationWidth = new DoubleAnimation();
                DoubleAnimation AnimationHeight = new DoubleAnimation();
                DoubleAnimation AnimationOpacity = new DoubleAnimation();
                DoubleAnimation AnimationSwapOpacity = new DoubleAnimation();
                DoubleAnimation AnimationSwapExpandOpacity = new DoubleAnimation();
                CubicEase AnimationEasing = new CubicEase();
                TimeSpan AnimationDuration = TimeSpan.FromMilliseconds(500);

                AnimationX.From = Canvas.GetLeft(this);
                AnimationX.To = X;
                AnimationX.Duration = AnimationDuration;
                AnimationX.EasingFunction = AnimationEasing;

                AnimationY.From = Canvas.GetTop(this);
                AnimationY.To = Y;
                AnimationY.Duration = AnimationDuration;
                AnimationY.EasingFunction = AnimationEasing;

                AnimationWidth.From = ActualWidth;
                AnimationWidth.To = Width;
                AnimationWidth.Duration = AnimationDuration;
                AnimationWidth.EasingFunction = AnimationEasing;

                AnimationHeight.From = ActualHeight;
                AnimationHeight.To = Height;
                AnimationHeight.Duration = AnimationDuration;
                AnimationHeight.EasingFunction = AnimationEasing;

                AnimationOpacity.From = ParentDock.GridTopMenu.Opacity;
                AnimationOpacity.To = Value ? 1 : 0;
                AnimationOpacity.Duration = AnimationDuration;
                AnimationOpacity.EasingFunction = AnimationEasing;

                AnimationSwapOpacity.From = ((Grid)BorderContentSwap.Child).Children[1].Opacity;
                AnimationSwapOpacity.To = Value ? 0 : 1;
                AnimationSwapOpacity.Duration = AnimationDuration;
                AnimationSwapOpacity.EasingFunction = AnimationEasing;

                AnimationSwapExpandOpacity.From = ((Grid)BorderContentSwap.Child).Children[0].Opacity;
                AnimationSwapExpandOpacity.To = Value ? 1 : 0;
                AnimationSwapExpandOpacity.Duration = AnimationDuration;
                AnimationSwapExpandOpacity.EasingFunction = AnimationEasing;

                ExpandAnimation.Children.Add(AnimationX);
                ExpandAnimation.Children.Add(AnimationY);
                ExpandAnimation.Children.Add(AnimationWidth);
                ExpandAnimation.Children.Add(AnimationHeight);
                ExpandAnimation.Children.Add(AnimationOpacity);
                ExpandAnimation.Children.Add(AnimationSwapOpacity);
                ExpandAnimation.Children.Add(AnimationSwapExpandOpacity);

                // 애니메이션 대상 속성 설정
                Storyboard.SetTargetProperty(AnimationX, new PropertyPath(Canvas.LeftProperty));
                Storyboard.SetTargetProperty(AnimationY, new PropertyPath(Canvas.TopProperty));
                Storyboard.SetTargetProperty(AnimationWidth, new PropertyPath(WidthProperty));
                Storyboard.SetTargetProperty(AnimationHeight, new PropertyPath(HeightProperty));
                Storyboard.SetTargetProperty(AnimationOpacity, new PropertyPath(OpacityProperty));
                Storyboard.SetTargetProperty(AnimationSwapOpacity, new PropertyPath(OpacityProperty));
                Storyboard.SetTargetProperty(AnimationSwapExpandOpacity, new PropertyPath(OpacityProperty));

                // 애니메이션 대상 설정
                Storyboard.SetTarget(AnimationX, this);
                Storyboard.SetTarget(AnimationY, this);
                Storyboard.SetTarget(AnimationWidth, this);
                Storyboard.SetTarget(AnimationHeight, this);
                Storyboard.SetTarget(AnimationOpacity, ParentDock.GridTopMenu);
                Storyboard.SetTarget(AnimationSwapOpacity, ((Grid)BorderContentSwap.Child).Children[1]);
                Storyboard.SetTarget(AnimationSwapExpandOpacity, ((Grid)BorderContentSwap.Child).Children[0]);

                // 애니메이션 완료 이벤트 설정
                ExpandAnimation.Completed += (o, i) =>
                {
                    // 액션 호출
                    if (Completed != null)
                    {
                        Completed();
                    }

                    // 변경된 값 반영
                    this.Width = Width;
                    this.Height = Height;
                    Canvas.SetLeft(this, X);
                    Canvas.SetTop(this, Y);
                    ParentDock.GridTopMenu.Opacity = Value ? 1 : 0;
                    ParentDock.GridTopMenu.Visibility = Value ? Visibility.Visible : Visibility.Collapsed;
                    BorderContent.Visibility = Visibility.Visible;
                    ((Grid)BorderContentSwap.Child).Children[1].Opacity = Value ? 0 : 1;
                    ((Grid)BorderContentSwap.Child).Children[0].Opacity = Value ? 1 : 0;

                    // 웹 위젯 렌더링 지연 처리
                    if (AssemblyEntry.Equals("WebView"))
                    {
                        DispatcherTimer CompleteTimer = new DispatcherTimer();
                        CompleteTimer.Tick += (Tick_object, Tick_sender) =>
                        {
                            CompleteTimer.Stop();
                            if (!Resizing)
                            {
                                BorderContentSwap.Visibility = Visibility.Collapsed;
                            }
                        };
                        CompleteTimer.Interval = TimeSpan.FromMilliseconds(500);
                        CompleteTimer.Start();
                    }
                    else
                    {
                        BorderContentSwap.Visibility = Visibility.Collapsed;
                    }

                    // 플래그 갱신
                    Resizing = false;
                };

                // 애니메이션 실행
                ExpandAnimation.FillBehavior = FillBehavior.Stop;
                ExpandAnimation.Begin();
            }
        }

        private void CallMethod(string Method, object Parameter = null)
        {
            if (WidgetTarget != null)
            {
                MethodInfo WidgetMethod = WidgetTarget.GetMethod(Method, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if (Parameter == null)
                {
                    WidgetMethod.Invoke(WidgetControl, new object[] { });
                }
                else
                {
                    WidgetMethod.Invoke(WidgetControl, new object[] { Parameter });
                }
            }
        }
        #endregion

        #region 사용자 함수
        public bool Load(string Path, bool AssemblyOnly = false)
        {
            try
            {
                // 구성 파일 로드
                if (!AssemblyOnly)
                {
                    LoadConfig(Path);
                }

                if (AssemblyFile.Equals("local"))
                {
                    // 내부 어셈블리 사용
                    switch (AssemblyEntry)
                    {
                        case "WebView":
                            BorderContent.Background = Brushes.Black;
                            ChromiumWebBrowser WebView = new ChromiumWebBrowser();
                            WebView.Address = AssemblyArgument;
                            BorderContent.Child = WebView;
                            break;
                    }
                }
                else
                {
                    // 외부 어셈블리 참조
                    Assembly WidgetAssembly = Assembly.LoadFrom(AssemblyFile);
                    Type[] TypeList = WidgetAssembly.GetTypes();
                    foreach (Type Target in TypeList)
                    {
                        if (Target.Name == AssemblyEntry)
                        {
                            // 어셈블리 진입점 검색 및 인스턴스 생성
                            _WidgetTarget = Target;
                            _WidgetControl = Activator.CreateInstance(Target) as UserControl;

                            // 어셈블리에 전달할 인자가 존재하는 경우 메소드 호출
                            if (AssemblyArgument.Length > 0)
                            {
                                CallMethod("SetArgument", AssemblyArgument);
                            }

                            break;
                        }
                    };

                    // 검색된 컨트롤을 현재 컨트롤에 추가
                    BorderContent.Child = WidgetControl;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LoadConfig(string Path)
        {
            try
            {
                // 위젯 분석
                INI Widget = new INI(Path);
                string Local = "<%LOCAL%>";
                _INI = Path;
                _Title = Widget.GetValue("General", "Title");
                _Author = Widget.GetValue("General", "Author");
                _Summary = Widget.GetValue("General", "Summary");
                _AssemblyFile = Widget.GetValue("Assembly", "File").Replace(Local, System.IO.Path.GetDirectoryName(Path)).Trim();
                _AssemblyEntry = Widget.GetValue("Assembly", "Entry").Replace(Local, System.IO.Path.GetDirectoryName(Path)).Trim();
                _AssemblyArgument = Widget.GetValue("Assembly", "Argument").Replace(Local, System.IO.Path.GetDirectoryName(Path)).Trim();
                _AppearanceWidth = int.Parse(Widget.GetValue("Appearance", "Width"));
                _AppearanceHeight = int.Parse(Widget.GetValue("Appearance", "Height"));
                _AppearanceExpandable = bool.Parse(Widget.GetValue("Appearance", "Expandable"));

                // 위젯 모양새 적용
                if (ParentDock != null)
                {
                    Width = AppearanceWidth * ParentDock.GridWidth;
                    Height = AppearanceHeight * ParentDock.GridHeight;
                }
                else
                {
                    WidthColumn = AppearanceWidth;
                    HeightRow = AppearanceHeight;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SetPosition(int Row, int Column, bool Animation = false)
        {
            if (ParentDock != null)
            {
                LastRow = Row;
                LastColumn = Column;

                if (Animation)
                {
                    Storyboard PositionAnimation = new Storyboard();
                    DoubleAnimation AnimationX = new DoubleAnimation();
                    DoubleAnimation AnimationY = new DoubleAnimation();
                    CubicEase AnimationEasing = new CubicEase();
                    TimeSpan AnimationDuration = TimeSpan.FromMilliseconds(300);

                    AnimationX.From = Canvas.GetLeft(this);
                    AnimationX.To = ParentDock.GridWidth * Column;
                    AnimationX.Duration = AnimationDuration;
                    AnimationX.EasingFunction = AnimationEasing;

                    AnimationY.From = Canvas.GetTop(this);
                    AnimationY.To = ParentDock.GridHeight * Row;
                    AnimationY.Duration = AnimationDuration;
                    AnimationY.EasingFunction = AnimationEasing;

                    PositionAnimation.Children.Add(AnimationX);
                    PositionAnimation.Children.Add(AnimationY);

                    Storyboard.SetTargetProperty(AnimationX, new PropertyPath(Canvas.LeftProperty));
                    Storyboard.SetTargetProperty(AnimationY, new PropertyPath(Canvas.TopProperty));

                    Storyboard.SetTarget(AnimationX, this);
                    Storyboard.SetTarget(AnimationY, this);

                    PositionAnimation.Completed += PositionAnimation_Completed;
                    PositionAnimation.FillBehavior = FillBehavior.Stop;
                    PositionAnimation.Begin();
                }
                else
                {
                    Canvas.SetLeft(this, ParentDock.GridWidth * LastColumn);
                    Canvas.SetTop(this, ParentDock.GridHeight * LastRow);
                }
            }
        }

        private void PositionAnimation_Completed(object sender, EventArgs e)
        {
            if (ParentDock != null)
            {
                Canvas.SetLeft(this, ParentDock.GridWidth * LastColumn);
                Canvas.SetTop(this, ParentDock.GridHeight * LastRow);
            }
        }

        public void StartMouseDown(MouseButtonEventArgs e = null)
        {
            GuidelineOriginal = ParentDock.Guideline;
            if (ParentDock.GuidelineWhenMove)
            {
                ParentDock.Guideline = true;
            }

            ParentDock.BringToFront(this);
            ParentDock.GridTopDeleteMenu.Visibility = Visibility.Visible;
            GridSelect.Visibility = Visibility.Visible;
            if (e != null)
            {
                LocalPosition = e.GetPosition(this);
            }
            CaptureMouse();
        }

        public void StopMouseDown()
        {
            if (GuidelineOriginal == false && ParentDock.GuidelineWhenMove)
            {
                ParentDock.Guideline = false;
            }

            if (ParentDock != null)
            {
                ParentDock.GridTopDeleteMenu.Visibility = Visibility.Collapsed;
            }

            if (DeleteSelect)
            {
                ParentDock.Remove(this);
            }
            else
            {
                if (PositionError)
                {
                    if (NowLoading)
                    {
                        ParentDock.Remove(this);
                    }
                    else
                    {
                        SetPosition(LastRow, LastColumn, true);
                        GridError.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    LastRow = Row;
                    LastColumn = Column;
                    SetPosition(Row, Column, true);
                    ParentDock.Config.SaveWidgets();
                }
            }

            GridSelect.Visibility = Visibility.Collapsed;
            ReleaseMouseCapture();
        }
        #endregion

        public GridWidget()
        {
            InitializeComponent();

            PreviewMouseLeftButtonUp += GridWidget_PreviewMouseLeftButtonUp;
            PreviewMouseLeftButtonDown += GridWidget_PreviewMouseLeftButtonDown;
            PreviewMouseRightButtonUp += GridWidget_PreviewMouseRightButtonUp;
            PreviewMouseRightButtonDown += GridWidget_PreviewMouseRightButtonDown;
            PreviewMouseMove += GridWidget_PreviewMouseMove;
            Loaded += GridWidget_Loaded;
        }

        private void GridWidget_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!Expand)
            {
                if (LongClickTimer != null)
                {
                    LongClickTimer.Stop();
                    LongClickTimer = null;
                }

                if (!LongClick)
                {
                    if (!NowLoading)
                    {
                        Expand = true;
                    }
                    else
                    {
                        StopMouseDown();
                        NowLoading = false;

                        if (LazyLoading != null)
                        {
                            if (Load(LazyLoading, true))
                            {
                                ImgLoading.Visibility = Visibility.Collapsed;
                            }
                            else if (ParentDock != null)
                            {
                                ParentDock.Remove(this);

                                AlertDialog Dialog = new AlertDialog(Application.Current.MainWindow,
                                    "오류",
                                    "위젯을 로드할 수 없습니다.\n" +
                                    "어셈블리 오류가 발생하였습니다.",
                                    false);

                                Dialog.ShowDialog();
                            }
                        }
                    }
                }
                else
                {
                    LongClick = false;
                }
            }
        }

        private void GridWidget_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!Expand)
            {
                if (LongClickTimer == null)
                {
                    LongClickTimer = new DispatcherTimer();
                    LongClickTimer.Interval = TimeSpan.FromMilliseconds(300);
                    LongClickTimer.Tick += (ts, te) =>
                    {
                        LongClick = true;
                        LongClickTimer.Stop();
                        LongClickTimer = null;
                        GridWidget_LongClick();
                    };
                    LongClickTimer.Start();
                }
            }
        }

        private void GridWidget_LongClick()
        {
            // MOUSE LONG CLICK EVENT
        }

        private void GridWidget_Loaded(object sender, RoutedEventArgs e)
        {
            SetPosition(Row, Column);
            Width = WidthColumn * ParentDock.GridWidth;
            Height = HeightRow * ParentDock.GridHeight;
        }

        private void GridWidget_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!Expand)
            {
                StartMouseDown(e);
            }
        }

        private void GridWidget_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!Expand)
            {
                StopMouseDown();
            }
        }

        private void GridWidget_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseCaptured)
            {
                Point TargetPosition = e.GetPosition(ParentDock.CanvasRoot);
                Point TargetContentPosition = LocalPosition;

                if (NowLoading)
                {
                    Canvas.SetLeft(this, TargetPosition.X - ActualWidth / 2);
                    Canvas.SetTop(this, TargetPosition.Y - ActualHeight / 2);
                }
                else
                {
                    Canvas.SetLeft(this, TargetPosition.X - TargetContentPosition.X);
                    Canvas.SetTop(this, TargetPosition.Y - TargetContentPosition.Y);
                }

                _Column = (int)Math.Round(Canvas.GetLeft(this) / ParentDock.GridWidth);
                _Row = (int)Math.Round(Canvas.GetTop(this) / ParentDock.GridHeight);

                if (!ParentDock.Overflow)
                {
                    if (Row < 0 ||
                        Column < 0)
                    {
                        PositionError = true;
                        GridError.Visibility = Visibility.Visible;
                    }
                    else if (ParentDock.ActualHeight < ParentDock.GridHeight * Row + ActualHeight ||
                             ParentDock.ActualWidth < ParentDock.GridWidth * Column + ActualWidth)
                    {
                        PositionError = true;
                        GridError.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        bool IsIntersect = false;
                        foreach (GridWidget Widget in ParentDock.WidgetList)
                        {
                            if (Widget != this)
                            {
                                double Margin = ParentDock.GridThickness / 2;
                                Rect RectThis = new Rect(ParentDock.GridWidth * Column, ParentDock.GridHeight * Row, Width - Margin, Height - Margin);
                                Rect RectTarget = new Rect(Canvas.GetLeft(Widget), Canvas.GetTop(Widget), Widget.Width - Margin, Widget.Height - Margin);
                                IsIntersect = RectThis.IntersectsWith(RectTarget);
                                if (IsIntersect)
                                {
                                    break;
                                }
                            }
                        }

                        // 다른 위젯과의 충돌 검사
                        if (IsIntersect)
                        {
                            PositionError = true;
                            GridError.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            PositionError = false;
                            GridError.Visibility = Visibility.Collapsed;
                        }
                    }
                }

                // 삭제 영역으로의 충돌 검사
                if (TargetPosition.Y <= ParentDock.GridTopDeleteMenu.ActualHeight)
                {
                    DeleteSelect = true;
                    ParentDock.GridDeleteLight.Visibility = Visibility.Visible;
                }
                else
                {
                    DeleteSelect = false;
                    ParentDock.GridDeleteLight.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
