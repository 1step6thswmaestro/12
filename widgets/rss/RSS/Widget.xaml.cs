using RSS.Functions;
using RSS.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace RSS
{
    /// <summary>
    /// Widget.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Widget : UserControl
    {

        #region 객체
        int itemIndex = 0;
        RSSParser parser;
        RSSView RSSView = new RSSView();
        DispatcherTimer timer = new DispatcherTimer();
        #endregion

        public Widget()
        {
            InitializeComponent();
            Loaded += Widget_Loaded;
            PreviewMouseLeftButtonUp += Widget_PreviewMouseLeftButtonUp;
        }

        private void Widget_Loaded(object sender, RoutedEventArgs e)
        {
            // 기본 페이지 설정
            PagePresenter.Content = RSSView;
            ChangeRSS(itemIndex);

            // 타이머 설정
            timer.Interval = TimeSpan.FromMilliseconds(5000);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void SetArgument(string Value)
        {
            parser = new RSSParser(Value);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            NextRSS();
        }

        private void Widget_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            timer.Stop();
            NextRSS();
            timer.Start();
        }

        private void NextRSS()
        {
            if (parser != null)
            {
                RSSView.TextTitle.Foreground = new SolidColorBrush(Colors.Transparent);

                if (itemIndex + 1 >= parser.Items.Count)
                {
                    itemIndex = 0;
                }
                else
                {
                    itemIndex += 1;
                }
                ChangeRSS(itemIndex);

                ShowRSS();
            }
        }

        private void ChangeRSS(int index)
        {
            if (parser != null)
            {
                Item item = parser.Items[index];
                RSSView.TextTitle.Text = item.Title;
                RSSView.TextPublicationDate.Text = parser.Title + " - " + item.PublicationDate.ToString("yyyy년 MM월 dd일 tt hh시 mmm분");
            }
        }

        private void ShowRSS()
        {
            // 애니메이션 설정
            Storyboard fadeAnimation = new Storyboard();
            CubicEase colorEassing = new CubicEase();
            TimeSpan durationColor = TimeSpan.FromMilliseconds(300);

            // 글자 애니메이션 설정
            RSSView.TextTitle.TextEffects = null;
            for (int i = 0; i < RSSView.TextTitle.Text.Length; ++i)
            {
                // 글자 효과 설정
                SetTextEffect(RSSView.TextTitle, i);

                // 애니메이션 생성
                ColorAnimation color = new ColorAnimation
                {
                    From = Colors.Transparent,
                    To = Colors.White,
                    Duration = durationColor,
                    EasingFunction = colorEassing
                };

                // 애니메이션 시간 설정
                SetBeginTime(color, i);

                // 애니메이션 대상 설정
                Storyboard.SetTarget(color, RSSView.TextTitle);
                Storyboard.SetTargetProperty(color, new PropertyPath(string.Format("TextEffects[{0}].Foreground.Color", i)));

                // 스토리보드에 애니메이션 추가
                fadeAnimation.Children.Add(color);
            }

            // 애니메이션 실행
            fadeAnimation.Begin();
        }

        private void SetTextEffect(TextBlock target, int idx)
        {
            if (target.TextEffects == null)
            {
                target.TextEffects = new TextEffectCollection();
            }

            TextEffect effect = new TextEffect
            {
                Foreground = new SolidColorBrush(((SolidColorBrush)target.Foreground).Color),
                PositionStart = idx,
                PositionCount = 1
            };

            target.TextEffects.Add(effect);
        }

        private void SetBeginTime(Timeline target, int idx)
        {
            double totalMs = target.Duration.TimeSpan.TotalMilliseconds;
            double offset = totalMs / 10;
            double resolvedOffset = offset * idx;
            target.BeginTime = TimeSpan.FromMilliseconds(resolvedOffset);
        }
    }
}
