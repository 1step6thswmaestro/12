Public Class MusicItem

    Private _Path As String
    Public Property Path As String
        Get
            Return _Path
        End Get
        Set(value As String)
            _Path = value
        End Set
    End Property

    Private _Title As String
    Public Property Title As String
        Get
            Return _Title
        End Get
        Set(value As String)
            _Title = value
        End Set
    End Property

    Private _Artist As String
    Public Property Artist As String
        Get
            Return _Artist
        End Get
        Set(value As String)
            _Artist = value
        End Set
    End Property

    Private _AlbumArt As BitmapFrame
    Public Property AlbumArt As BitmapFrame
        Get
            Return _AlbumArt
        End Get
        Set(value As BitmapFrame)
            _AlbumArt = value
        End Set
    End Property
End Class
