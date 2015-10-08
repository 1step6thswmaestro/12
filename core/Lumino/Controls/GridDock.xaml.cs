using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
        #endregion

        #region 객체
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

        #region 사용자 함수
        public void Add(GridWidget Widget)
        {
            Widget.ParentDock = this;
            WidgetList.Add(Widget);
            CanvasRoot.Children.Add(Widget);
        }

        public void BringToFront(GridWidget Widget)
        {
            int Max = 0;

            foreach (GridWidget Target in CanvasRoot.Children)
            {
                if (Target != Widget)
                {
                    Max = Math.Max(Panel.GetZIndex(Target), Panel.GetZIndex(Widget));
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
        }

        public GridDock()
        {
            InitializeComponent();
            SizeChanged += GridDock_SizeChanged;
        }

        private void GridDock_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateView();
        }
    }
}
