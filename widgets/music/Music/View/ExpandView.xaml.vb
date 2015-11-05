Imports System.ComponentModel

Public Class ExpandView

    Private Sub ExpandView_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If IO.Directory.Exists(DataStore) Then
            ' 경로에서 음악 탐색
            Dim LoadWorker As New BackgroundWorker
            AddHandler LoadWorker.DoWork,
                Sub()
                    MediaManager.MusicList.Clear()

                    Dim Musics() As String = IO.Directory.GetFiles(DataStore, "*.mp3")
                    For Each Target As String In Musics
                        Dim Music As New MusicItem With {
                            .Path = Target,
                            .Title = TagManager.GetTag(Target, TagManager.TagType.Title),
                            .Artist = TagManager.GetTag(Target, TagManager.TagType.Artist),
                            .AlbumArt = TagManager.GetAlbumArt(Target)
                        }

                        MediaManager.MusicList.Add(Music)
                    Next

                    ' 리스트 바인딩 설정
                    ListMusic.Dispatcher.Invoke(Sub() ListMusic.ItemsSource = MediaManager.MusicList)
                End Sub

            LoadWorker.RunWorkerAsync()
        End If
    End Sub

    Private Sub ListMusic_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles ListMusic.MouseLeftButtonUp
        Static LastIDX As Integer = -1
        Dim CurrentListBox As ListBox = TryCast(sender, ListBox)
        If LastIDX <> CurrentListBox.SelectedIndex Then
            MediaManager.Play(CurrentListBox.SelectedIndex)
            LastIDX = CurrentListBox.SelectedIndex
        End If
    End Sub

    Private Sub BtnPlay_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles BtnPlay.MouseLeftButtonUp
        If MediaManager.MusicIDX = -1 Then
            MediaManager.Play(0)
        ElseIf MediaManager.CurrentStatus = MediaManager.Status.Play
            MediaManager.Pause(True)
        ElseIf MediaManager.CurrentStatus = MediaManager.Status.Pause
            MediaManager.Pause(False)
        End If
    End Sub

    Private Sub BtnNext_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles BtnNext.MouseLeftButtonUp
        MediaManager.PlayNext()
    End Sub

    Private Sub BtnPrevious_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles BtnPrevious.MouseLeftButtonUp
        MediaManager.PlayPrevious()
    End Sub

    Private Sub SliderVolume_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles SliderVolume.ValueChanged
        MediaManager.SetVolume(TryCast(sender, VertexSlider).Value)
    End Sub
End Class
