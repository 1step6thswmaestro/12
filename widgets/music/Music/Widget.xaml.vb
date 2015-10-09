Imports Microsoft.Win32
Imports System.ComponentModel
Imports System.Windows.Threading

Public Class Widget

#Region " [ 객체 ] "
    Private SpectrumCount As Integer = 70
    Private SpectrumTimer As DispatcherTimer
    Private ProgressBarList As List(Of ProgressBar)
#End Region

#Region " [ 태그 함수 ] "
    Enum TagType
        Title
        Artist
    End Enum

    Public Function GetTag(ByVal Path As String, ByVal Type As TagType) As String
        Try
            Dim File As TagLib.File = TagLib.File.Create(Path)
            Select Case Type
                Case TagType.Title
                    Return If(String.IsNullOrEmpty(File.Tag.Title), "알 수 없는 제목", File.Tag.Title)

                Case TagType.Artist
                    Return If(String.IsNullOrEmpty(File.Tag.FirstPerformer), "알 수 없는 음악가", File.Tag.FirstPerformer)

                Case Else
                    Return "잘못된 파일"

            End Select

            File.Dispose()
        Catch ex As Exception
            Return "잘못된 파일"
        End Try
    End Function
#End Region

#Region " [ 스펙트럼 함수 ] "
    Public Sub StartDraw()
        If Not SetPath Is Nothing Then
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

                SpectrumPanel.Children.Add(ProgressBar)
                ProgressBarList.Add(ProgressBar)
            Next

            ' 스펙트럼 그리기 타이머 생성
            SpectrumTimer = New DispatcherTimer
            SpectrumTimer.Interval = TimeSpan.FromMilliseconds(30)
            AddHandler SpectrumTimer.Tick, Sub()
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
                                           End Sub

            ' 스펙트럼 타이머 시작
            SpectrumTimer.Start()
        End If
    End Sub
#End Region

    Private Sub MusicView_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If Not DesignerProperties.GetIsInDesignMode(Me) Then
            ' 사운드 엔진 초기화
            InitFmodEX()
        End If
    End Sub

    Private Sub MusicView_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles Me.MouseUp
        ' 마우스 클릭을 통한 파일 탐색기 호출
        If e.ChangedButton = MouseButton.Middle Then
            Dim OpenFileDialog As New OpenFileDialog() With {
                .DefaultExt = ".mp3",
                .Filter = "MP3 Files (*.mp3)|*.mp3"
            }

            If OpenFileDialog.ShowDialog() Then
                ' 선택된 음악 재생
                SetPath = OpenFileDialog.FileName
                PlaySoundFmodEX()
                SetVolume(0.5)

                ' 스펙트럼 그리기
                StartDraw()

                ' 태그 갱신
                TextTitle.Text = GetTag(SetPath, TagType.Title)
                TextArtist.Text = GetTag(SetPath, TagType.Artist)
            End If
        End If
    End Sub
End Class
