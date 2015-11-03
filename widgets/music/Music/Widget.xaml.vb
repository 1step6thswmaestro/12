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

        ' 이벤트 연결
        ' - 미디어 변경 이벤트
        AddHandler MediaManager.OnMediaChanged,
            Sub(ByVal Path As String, ByVal IDX As Integer)
                ' 태그 갱신
                Dim Title As String = TagManager.GetTag(Path, TagManager.TagType.Title)
                Dim Artist As String = TagManager.GetTag(Path, TagManager.TagType.Artist)
                Dim AlbumArt As BitmapFrame = TagManager.GetAlbumArt(Path)
                MusicView.TextTitle.Text = Title
                MusicView.TextArtist.Text = Artist
                ExpandView.TextTitle.Text = Title
                ExpandView.TextArtist.Text = Artist

                ' 앨범 이미지 갱신
                Dim Brush As New ImageBrush
                If AlbumArt IsNot Nothing Then
                    Brush.ImageSource = AlbumArt
                Else
                    Brush.ImageSource = ImageHelper.ImageLoad("pack://application:,,,/Music;component/Images/Default.png")
                End If
                MusicView.EllipseAlbum.Fill = Brush
                ExpandView.ImgBackground.Source = ImageHelper.SetBlurEffect(AlbumArt)

                ' 스펙트럼 색상 변경
                For i As Integer = 0 To MusicView.ProgressBarList.Count - 1
                    MusicView.ProgressBarList(i).Foreground = New SolidColorBrush(ImageHelper.AverageColor(AlbumArt))
                Next

                ' 스펙트럼 패널 표시
                If MusicView.SpectrumPanel.Visibility <> Visibility.Visible Then
                    MusicView.SpectrumPanel.Visibility = Visibility.Visible
                End If

                ' 선택된 앨범 표시 갱신
                ExpandView.ListMusic.SelectedIndex = IDX
            End Sub

        ' - 재생 위치 변경 이벤트
        AddHandler MediaManager.OnPositionChanged,
            Sub()
                If Not Expand Then
                    MusicView.TextTime.Text = Milli2HMS(mplaytime) + " / " + Milli2HMS(mplaytimelen)
                End If
            End Sub

        ' - 미디어 재생 완료 이벤트
        AddHandler MediaManager.OnMediaCompleted,
            Sub(ByVal Path As String)
                MediaManager.PlayNext()
            End Sub

        ' - 미디어 재생 상태 변경 이벤트
        AddHandler MediaManager.OnStatusChanged,
            Sub(ByVal Status As MediaManager.Status)
                Select Case Status
                    Case MediaManager.Status.Play
                        ExpandView.BtnPlay.Source = ImageHelper.ImageLoad("pack://application:,,,/Music;component/Images/BtnPause.png")

                    Case MediaManager.Status.Pause
                        ExpandView.BtnPlay.Source = ImageHelper.ImageLoad("pack://application:,,,/Music;component/Images/BtnPlay.png")
                End Select
            End Sub
    End Sub

    Private Sub IsExpand(ByVal Value As Boolean)
        Expand = Value

        Dim ExpandAnimation As New Storyboard
        Dim OpacityAnimation As New DoubleAnimation

        OpacityAnimation.From = PagePresenterExpand.Opacity
        OpacityAnimation.To = If(Value, 1, 0)
        OpacityAnimation.Duration = TimeSpan.FromMilliseconds(450)
        OpacityAnimation.EasingFunction = New CubicEase()

        Storyboard.SetTargetProperty(OpacityAnimation, New PropertyPath(OpacityProperty))
        Storyboard.SetTarget(OpacityAnimation, PagePresenterExpand)

        If Value Then
            PagePresenterExpand.Visibility = Visibility.Visible
        Else
            ExpandView.GridRoot.Visibility = Visibility.Collapsed
        End If

        AddHandler ExpandAnimation.Completed,
                Sub()
                    If Value Then
                        ExpandView.GridRoot.Visibility = Visibility.Visible
                    Else
                        ExpandView.GridRoot.Visibility = Visibility.Collapsed
                        PagePresenterExpand.Visibility = Visibility.Collapsed
                    End If
                End Sub

        ExpandAnimation.Children.Add(OpacityAnimation)
        ExpandAnimation.Begin()
    End Sub

    Private Sub SetArgument(ByVal Value As String)
        DataStore = Value
    End Sub

    Private Sub Widget_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles Me.MouseDoubleClick
        If e.ChangedButton = MouseButton.Right Then
            Expand = Not Expand
            IsExpand(Expand)
        End If
    End Sub
End Class
