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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lumino.Controls
{
    /// <summary>
    /// 사용자 지정 형식의 대화 상자를 제공합니다.
    /// </summary>
    public partial class AlertDialog : Window
    {
        private bool Result = false;
        private bool Question = false;

        public AlertDialog(Window Owner, string Title, string Content, bool IsQuestion)
        {
            InitializeComponent();
            this.Owner = Owner;
            TextTitle.Text = Title;
            TextContent.Text = Content;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Question = IsQuestion;

            Loaded += AlertDialog_Loaded;
            TextYES.MouseLeftButtonDown += TextYES_MouseLeftButtonDown;
            TextNO.MouseLeftButtonDown += TextNO_MouseLeftButtonDown;
        }

        public bool GetResult()
        {
            return Result;
        }

        private void TextNO_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Result = false;
            Storyboard storyboard = this.FindResource("DialogHide") as Storyboard;
            storyboard.Begin();
        }

        private void TextYES_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Result = true;
            Storyboard storyboard = this.FindResource("DialogHide") as Storyboard;
            storyboard.Begin();
        }

        private void AlertDialog_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Question)
            {
                TextNO.Visibility = Visibility.Collapsed;
                BorderButton.Visibility = Visibility.Collapsed;
                TextYES.Width = ButtonStack.ActualWidth;
            }
            else
            {
                TextYES.Width = ButtonStack.ActualWidth / 2;
            }
            TextNO.Width = ButtonStack.ActualWidth / 2;
            TextYES.Height = ButtonStack.ActualHeight;
            TextNO.Height = ButtonStack.ActualHeight;
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
