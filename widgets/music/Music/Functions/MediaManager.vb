Imports System.Windows.Threading

Public Class MediaManager

    Public Enum Status
        Play
        [Stop]
        Pause
    End Enum

    Public Shared MusicIDX As Integer = -1
    Public Shared MusicList As New List(Of MusicItem)
    Public Shared CurrentStatus As Status = Status.Stop
    Public Shared CurrentVolume As Single = -1

    Public Shared Event OnMediaChanged(ByVal Path As String, ByVal IDX As Integer)
    Public Shared Event OnMediaCompleted(ByVal Path As String)
    Public Shared Event OnPositionChanged()
    Public Shared Event OnStatusChanged(ByVal Status As Status)

    Private Shared PlayerTimer As DispatcherTimer

    Public Shared Sub Play(ByVal IDX As Integer)
        If IDX < MusicList.Count Then
            ' 정보 갱신
            MusicIDX = IDX

            ' 타이머 초기화
            Dim Path As String = MusicList(IDX).Path
            PlayerTimer = New DispatcherTimer
            PlayerTimer.Interval = TimeSpan.FromMilliseconds(1)
            AddHandler PlayerTimer.Tick,
                    Sub()
                        If SetPath IsNot Nothing Then
                            RaiseEvent OnPositionChanged()

                            If mplaytime() >= mplaytimelen() Then
                                RaiseEvent OnMediaCompleted(Path)
                            End If
                        End If
                    End Sub
            PlayerTimer.Start()

            ' 미디어 초기화
            If SetPath IsNot Nothing Then
                ReleaseSound()
            End If
            SetPath = Path
            PlaySoundFmodEX()
            If CurrentVolume = -1 Then
                SetVolume(50)
            Else
                SetVolume(CurrentVolume)
            End If

            ' 미디어 변경 이벤트 발생
            RaiseEvent OnMediaChanged(Path, IDX)

            ' 재생 상태 변경 이벤트 발생
            CurrentStatus = Status.Play
            RaiseEvent OnStatusChanged(CurrentStatus)
        End If
    End Sub

    Public Shared Sub Pause(ByVal Value As Boolean)
        If SetPath IsNot Nothing Then
            ' 일시 정지
            PauseSoundFmodEX()

            ' 재생 상태 변경 이벤트 발생
            CurrentStatus = If(Value, Status.Pause, Status.Play)
            RaiseEvent OnStatusChanged(CurrentStatus)
        End If
    End Sub

    Public Shared Sub PlayNext()
        If MusicIDX + 1 < MusicList.Count Then
            Play(MusicIDX + 1)
        Else
            Play(0)
        End If
    End Sub

    Public Shared Sub PlayPrevious()
        If MusicIDX - 1 >= 0 Then
            Play(MusicIDX - 1)
        Else
            Play(MusicList.Count - 1)
        End If
    End Sub

    Public Shared Sub SetVolume(ByVal Value As Single)
        CurrentVolume = Value
        ModFmodControl.SetVolume(CurrentVolume / 100)
    End Sub
End Class
