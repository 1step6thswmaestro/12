Imports System.Windows.Media.Animation

Public Class Widget

#Region " [ 객체 ] "
    Private MusicView As New MusicView
    Private ExpandView As New ExpandView
#End Region

    Private Sub Widget_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        ' 사운드 엔진 초기화
        InitFmodEX()

        ' 그래픽 품질 설정
        RenderOptions.SetBitmapScalingMode(Me, BitmapScalingMode.HighQuality)

        ' 페이지 설정
        PagePresenterMusic.Content = MusicView
        PagePresenterExpand.Opacity = 0
        PagePresenterExpand.Content = ExpandView
        PagePresenterExpand.Visibility = Visibility.Collapsed
    End Sub

    Private Sub IsExpand(ByVal Value As Boolean)
        Expand = Value

        Dim ExpandAnimation As New Storyboard
        Dim OpacityAnimation As New DoubleAnimation

        OpacityAnimation.From = PagePresenterExpand.Opacity
        OpacityAnimation.To = If(Value, 1, 0)
        OpacityAnimation.Duration = TimeSpan.FromMilliseconds(350)
        OpacityAnimation.EasingFunction = New CubicEase()

        Storyboard.SetTargetProperty(OpacityAnimation, New PropertyPath(OpacityProperty))
        Storyboard.SetTarget(OpacityAnimation, PagePresenterExpand)

        If Value Then
            PagePresenterExpand.Visibility = Visibility.Visible
        End If

        If Not Value Then
            AddHandler ExpandAnimation.Completed,
                Sub()
                    PagePresenterExpand.Visibility = Visibility.Collapsed
                End Sub
        End If

        ExpandAnimation.Children.Add(OpacityAnimation)
        ExpandAnimation.Begin()
    End Sub

    Private Sub Widget_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles Me.MouseDoubleClick
        Expand = Not Expand
        IsExpand(Expand)
    End Sub
End Class
