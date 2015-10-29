Public Class ExpandView

    Private Sub ExpandView_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        ' 이벤트 연결
        AddHandler MediaManager.OnMediaChanged,
            Sub(ByVal Path As String)
                TextTitle.Text = TagManager.GetTag(Path, TagManager.TagType.Title)
                TextArtist.Text = TagManager.GetTag(Path, TagManager.TagType.Artist)
                ImgBackground.Source = ImageHelper.SetBlurEffect(TagManager.GetAlbumArt(Path))
            End Sub

        ' 음악 경로 탐색
        Dim Musics() As String = IO.Directory.GetFiles("C:\Users\SEOP\Music\Sample\", "*.mp3")
        For Each Target As String In Musics
            Dim Music As New MusicItem With {
                .Path = Target,
                .Title = TagManager.GetTag(Target, TagManager.TagType.Title),
                .Artist = TagManager.GetTag(Target, TagManager.TagType.Artist),
                .AlbumArt = TagManager.GetAlbumArt(Target)
            }
            ListMusic.Items.Add(Music)
        Next
    End Sub

    Private Sub ListMusic_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles ListMusic.MouseLeftButtonUp
        MediaManager.Play(TryCast(TryCast(sender, ListBox).SelectedItem, MusicItem).Path)
    End Sub
End Class
