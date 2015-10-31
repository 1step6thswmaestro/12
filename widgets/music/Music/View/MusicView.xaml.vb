Imports System.IO
Imports System.ComponentModel
Imports System.Windows.Threading

Public Class MusicView

#Region " [ 객체 ] "
    Private IsReady As Boolean = False
    Private PlayerTimer As DispatcherTimer
    Private SpectrumCount As Integer = 70
    Private SpectrumTimer As DispatcherTimer
    Private ProgressBarList As List(Of ProgressBar)
#End Region

#Region " [ 스펙트럼 함수 ] "
    Public Sub StartDraw()
        ' 값 보정
        If ProgressBarList Is Nothing OrElse ProgressBarList.Count = 0 Then
            SpectrumCount -= 1
        End If

        ' 스펙트럼 그리기
        ProgressBarList = New List(Of ProgressBar)
        SpectrumPanel.Children.Clear()

        Dim Angle As Double = 360 / SpectrumCount
        Dim TransformHeight As Double = 155
        For i = 0 To SpectrumCount
            Dim ProgressBar As New ProgressBar
            ProgressBar.Orientation = Orientation.Vertical
            ProgressBar.Height = 50
            ProgressBar.Width = 5
            ProgressBar.Maximum = 0
            ProgressBar.VerticalAlignment = VerticalAlignment.Top
            ProgressBar.Margin = New Thickness(0, 0, 0, TransformHeight + (ProgressBar.Height * 2))
            ProgressBar.RenderTransform = New RotateTransform(Angle * i, 0, TransformHeight)
            ProgressBar.Foreground = Brushes.White

            SpectrumPanel.Children.Add(ProgressBar)
            ProgressBarList.Add(ProgressBar)
        Next

        ' 스펙트럼 그리기 타이머 생성
        SpectrumTimer = New DispatcherTimer
        SpectrumTimer.Interval = TimeSpan.FromMilliseconds(30)
        AddHandler SpectrumTimer.Tick, Sub()
                                           If SetPath IsNot Nothing Then
                                               ' 스펙트럼 불러오기
                                               ' 2의 배수만 가능. 256 권장.
                                               Dim Spectrum As Single() = GetSpectrum(1024)
                                               Dim Max As Single = 0.0F

                                               ' 스펙트럼 최대 값 검사
                                               For Each Spt As Single In Spectrum
                                                   If Max < Spt Then Max = Spt
                                               Next

                                               ' 스펙트럼 값 갱신
                                               For i = 0 To ProgressBarList.Count - 1
                                                   If Spectrum(i) > ProgressBarList(i).Maximum Then
                                                       ProgressBarList(i).Maximum = Max
                                                   End If
                                                   ProgressBarList(i).Value = Spectrum(i)
                                               Next
                                           End If
                                       End Sub

        ' 스펙트럼 타이머 시작
        SpectrumTimer.Start()
    End Sub
#End Region

#Region " [ 시간 변환 함수 ] "
    Public Function Milli2HMS(ByVal lngTimeInMilliSeconds As Long) As String
        Dim lngSecRemainder As Long
        Dim lngMinSecRemainder As Long
        Dim lngHoursPart As Long
        Dim lngMinutesPart As Long
        Dim lngSecondsPart As Long
        Dim sTimeRemaining As String
        Dim sMinutesPart As String
        Dim sSecondsPart As String

        lngHoursPart = lngTimeInMilliSeconds \ 3600000
        lngMinSecRemainder = lngTimeInMilliSeconds Mod 3600000
        lngMinutesPart = lngMinSecRemainder \ 60000
        lngSecRemainder = lngMinSecRemainder Mod 60000
        lngSecondsPart = lngSecRemainder \ 1000

        sMinutesPart = Format(lngMinutesPart, "00")
        sSecondsPart = Format(lngSecondsPart, "00")

        sTimeRemaining = sMinutesPart & ":" & sSecondsPart

        Milli2HMS = sTimeRemaining
    End Function
#End Region

    Private Sub MusicView_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If Not IsReady AndAlso Not DesignerProperties.GetIsInDesignMode(Me) Then
            ' 계산 타이머 생성
            PlayerTimer = New DispatcherTimer
            PlayerTimer.Interval = TimeSpan.FromMilliseconds(1)
            AddHandler PlayerTimer.Tick, Sub()
                                             If SetPath IsNot Nothing Then
                                                 TextTime.Text = Milli2HMS(mplaytime) + " / " + Milli2HMS(mplaytimelen)
                                             End If
                                         End Sub
            PlayerTimer.Start()

            ' 스펙트럼 그리기
            SpectrumPanel.Visibility = Visibility.Hidden
            StartDraw()

            ' 플래그 갱신
            IsReady = True

            ' 이벤트 연결
            AddHandler MediaManager.OnMediaChanged,
                Sub(ByVal Path As String)
                    ' 태그 갱신
                    TextTitle.Text = TagManager.GetTag(SetPath, TagManager.TagType.Title)
                    TextArtist.Text = TagManager.GetTag(SetPath, TagManager.TagType.Artist)

                    ' 앨범 이미지 갱신
                    Dim Brush As New ImageBrush
                    Dim Album As BitmapFrame = TagManager.GetAlbumArt(Path)
                    If Album IsNot Nothing Then
                        Brush.ImageSource = Album
                    Else
                        Brush.ImageSource = ImageHelper.ImageLoad("pack://application:,,,/Music;component/Images/Default.png")
                    End If
                    EllipseAlbum.Fill = Brush

                    ' 앨범 평균색 계산
                    Dim Bitmap As System.Drawing.Bitmap
                    Using Stream As New MemoryStream()
                        Dim Encoder As BitmapEncoder = New BmpBitmapEncoder()
                        Encoder.Frames.Add(BitmapFrame.Create(TryCast(EllipseAlbum.Fill, ImageBrush).ImageSource))
                        Encoder.Save(Stream)
                        Bitmap = New System.Drawing.Bitmap(Stream)
                    End Using

                    Dim TotalR As Integer = 0
                    Dim TotalG As Integer = 0
                    Dim TotalB As Integer = 0
                    Dim TotalPX As Integer = 0
                    Dim ScanStep As Integer = 50

                    For i As Integer = 0 To Bitmap.Width - 1 Step ScanStep
                        For j As Integer = 0 To Bitmap.Height - 1 Step ScanStep
                            Dim RGB As System.Drawing.Color = Bitmap.GetPixel(i, j)
                            TotalR += RGB.R
                            TotalG += RGB.G
                            TotalB += RGB.B
                            TotalPX += 1
                        Next
                    Next

                    Dim Light As Double = 1.2
                    Dim AverageR As Integer = Math.Min(255, (TotalR \ TotalPX) * Light)
                    Dim AverageG As Integer = Math.Min(255, (TotalG \ TotalPX) * Light)
                    Dim AverageB As Integer = Math.Min(255, (TotalB \ TotalPX) * Light)

                    ' 스펙트럼 색상 변경
                    For i As Integer = 0 To ProgressBarList.Count - 1
                        ProgressBarList(i).Foreground = New SolidColorBrush(Color.FromArgb(255, AverageR, AverageG, AverageB))
                    Next

                    ' 스펙트럼 패널 표시
                    SpectrumPanel.Visibility = Visibility.Visible
                End Sub
        End If
    End Sub
End Class
