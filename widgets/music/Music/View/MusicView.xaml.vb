Imports System.ComponentModel
Imports System.Windows.Threading

Public Class MusicView

#Region " [ 객체 ] "
    Public IsReady As Boolean = False
    Public SpectrumCount As Integer = 70
    Public SpectrumTimer As DispatcherTimer
    Public ProgressBarList As List(Of ProgressBar)
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
                                           If SetPath IsNot Nothing AndAlso Not Expand Then
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

    Private Sub MusicView_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If Not IsReady AndAlso Not DesignerProperties.GetIsInDesignMode(Me) Then
            ' 스펙트럼 그리기
            SpectrumPanel.Visibility = Visibility.Hidden
            StartDraw()

            ' 플래그 갱신
            IsReady = True
        End If
    End Sub
End Class
