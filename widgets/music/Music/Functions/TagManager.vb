Imports System.IO

Public Class TagManager
    Enum TagType
        Title
        Artist
    End Enum

    Public Shared Function GetTag(ByVal Path As String, ByVal Type As TagType) As String
        Try
            Dim File As TagLib.File = TagLib.File.Create(Path)
            Select Case Type
                Case TagType.Title
                    Return If(String.IsNullOrEmpty(File.Tag.Title), IO.Path.GetFileNameWithoutExtension(Path), File.Tag.Title)

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

    Public Shared Function GetAlbumArt(ByVal Path As String) As BitmapFrame
        Try
            Dim File As TagLib.File = TagLib.File.Create(Path)
            If File.Tag.Pictures.Length >= 1 Then
                Dim AlbumStream As New MemoryStream(File.Tag.Pictures(0).Data.Data)
                Dim Bitmap As BitmapFrame = BitmapFrame.Create(AlbumStream)

                Return Bitmap
            Else
                Return Nothing
            End If

            File.Dispose()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
