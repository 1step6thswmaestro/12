using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Lumino.Functions;
using CefSharp.Wpf;
using System.Collections.Generic;

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
                if (!Resizing)
                {
                    _Expand = value;
                    if (value)
                    {
                        ParentDock.BringToFront(this);

                        OriginalX = Canvas.GetLeft(this);
                        OriginalY = Canvas.GetTop(this);
                        OriginalWidth = ActualWidth;
                        OriginalHeight = ActualHeight;

                        if (!AssemblyEntry.Equals("local"))
                        {

                        }

                        Resize(ExpandMargin, ExpandMargin, ParentDock.ActualWidth - ExpandMargin * 2, ParentDock.ActualHeight - ExpandMargin * 2);
                    }
                    else
                    {
                        Resize(OriginalX, OriginalY, OriginalWidth, OriginalHeight);
                    }
                }
            }
        }

        private int _ExpandMargin;
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

        private String _Title;
        public String Title
        {
            get { return _Title; }
        }

        private String _Author;
        public String Author
        {
            get { return _Author; }
        }

        private String _Summary;
        public String Summary
        {
            get { return _Summary; }
        }

        private String _AssemblyFile;
        public String AssemblyFile
        {
            get { return _AssemblyFile; }
        }

        private String _AssemblyEntry;
        public String AssemblyEntry
        {
            get { return _AssemblyEntry; }
        }

        private String _AssemblyArgument;
        public String AssemblyArgument
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
        private bool GuidelineOriginal;
        private bool Resizing = false;
        private Point LocalPosition;
        #endregion

        #region 제어 함수
        private void Resize(double X, double Y, double Width, double Height)
        {
            if (!Resizing)
            {
                Resizing = true;

                Storyboard ResizeAnimation = new Storyboard();
                DoubleAnimation AnimationX = new DoubleAnimation();
                DoubleAnimation AnimationY = new DoubleAnimation();
                DoubleAnimation AnimationWidth = new DoubleAnimation();
                DoubleAnimation AnimationHeight = new DoubleAnimation();
                BackEase AnimationEasing = new BackEase();
                TimeSpan AnimationDuration = TimeSpan.FromMilliseconds(500);

                AnimationEasing.Amplitude = 0.4;

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

                ResizeAnimation.Children.Add(AnimationX);
                ResizeAnimation.Children.Add(AnimationY);
                ResizeAnimation.Children.Add(AnimationWidth);
                ResizeAnimation.Children.Add(AnimationHeight);

                Storyboard.SetTargetProperty(AnimationX, new PropertyPath(Canvas.LeftProperty));
                Storyboard.SetTargetProperty(AnimationY, new PropertyPath(Canvas.TopProperty));
                Storyboard.SetTargetProperty(AnimationWidth, new PropertyPath(WidthProperty));
                Storyboard.SetTargetProperty(AnimationHeight, new PropertyPath(HeightProperty));

                Storyboard.SetTarget(AnimationX, this);
                Storyboard.SetTarget(AnimationY, this);
                Storyboard.SetTarget(AnimationWidth, this);
                Storyboard.SetTarget(AnimationHeight, this);

                ResizeAnimation.Completed += (o, i) =>
                {
                    Canvas.SetLeft(this, X);
                    Canvas.SetTop(this, Y);
                    this.Width = Width;
                    this.Height = Height;

                    Resizing = false;
                };

                ResizeAnimation.FillBehavior = FillBehavior.Stop;
                ResizeAnimation.Begin();
            }
        }

        private void CallMethod(String Method, String Parameter)
        {
            if (WidgetTarget != null)
            {
                MethodInfo WidgetMethod = WidgetTarget.GetMethod(Method, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                WidgetMethod.Invoke(WidgetControl, new object[] { Parameter });
            }
        }
        #endregion

        #region 사용자 함수
        public bool Load(string Path)
        {
            try
            {
                // 위젯 분석
                INI Widget = new INI(Path);
                string Local = "<%LOCAL%>";
                _Title = Widget.GetValue("General", "Title");
                _Author = Widget.GetValue("General", "Author");
                _Summary = Widget.GetValue("General", "Summary");
                _AssemblyFile = Widget.GetValue("Assembly", "File").Replace(Local, System.IO.Path.GetDirectoryName(Path)).Trim();
                _AssemblyEntry = Widget.GetValue("Assembly", "Entry").Replace(Local, System.IO.Path.GetDirectoryName(Path)).Trim();
                _AssemblyArgument = Widget.GetValue("Assembly", "Argument").Replace(Local, System.IO.Path.GetDirectoryName(Path)).Trim();
                int AppearanceWidth = int.Parse(Widget.GetValue("Appearance", "Width"));
                int AppearanceHeight = int.Parse(Widget.GetValue("Appearance", "Height"));

                if (AssemblyFile.Equals("local"))
                {
                    // 내부 어셈블리 사용
                    switch (AssemblyEntry)
                    {
                        case "WebView":
                            ChromiumWebBrowser WebView = new ChromiumWebBrowser();
                            WebView.Address = AssemblyArgument;
                            GridContent.Children.Add(WebView);
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
                    GridContent.Children.Add(WidgetControl);
                }

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
            Canvas.SetLeft(this, ParentDock.GridWidth * LastColumn);
            Canvas.SetTop(this, ParentDock.GridHeight * LastRow);
        }
        #endregion

        public GridWidget()
        {
            InitializeComponent();

            PreviewMouseLeftButtonUp += GridWidget_PreviewMouseLeftButtonUp;
            PreviewMouseRightButtonUp += GridWidget_PreviewMouseRightButtonUp;
            PreviewMouseRightButtonDown += GridWidget_PreviewMouseRightButtonDown;
            PreviewMouseMove += GridWidget_PreviewMouseMove;
            Loaded += GridWidget_Loaded;
        }

        private void GridWidget_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Expand = !Expand;
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
                GuidelineOriginal = ParentDock.Guideline;
                if (ParentDock.GuidelineWhenMove)
                {
                    ParentDock.Guideline = true;
                }

                ParentDock.BringToFront(this);
                GridSelect.Visibility = Visibility.Visible;
                LocalPosition = e.GetPosition(this);
                CaptureMouse();
            }
        }

        private void GridWidget_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!Expand)
            {
                if (GuidelineOriginal == false && ParentDock.GuidelineWhenMove)
                {
                    ParentDock.Guideline = false;
                }

                if (PositionError)
                {
                    SetPosition(LastRow, LastColumn, true);
                    GridError.Visibility = Visibility.Collapsed;
                }
                else
                {
                    LastRow = Row;
                    LastColumn = Column;
                    SetPosition(Row, Column, true);
                }

                GridSelect.Visibility = Visibility.Collapsed;
                ReleaseMouseCapture();
            }
        }

        private void GridWidget_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseCaptured)
            {
                Point TargetPosition = e.GetPosition(ParentDock.CanvasRoot);
                Point TargetContentPosition = LocalPosition;

                Canvas.SetLeft(this, TargetPosition.X - TargetContentPosition.X);
                Canvas.SetTop(this, TargetPosition.Y - TargetContentPosition.Y);

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
                            }
                        }

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
            }
        }
    }
}
