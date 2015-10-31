Imports System.Windows.Media.Effects

Public Class ImageHelper

    Public Shared Function ImageLoad(ByVal Path As String) As BitmapImage
        Dim Image As New BitmapImage()
        Image.BeginInit()
        Image.UriSource = New Uri(Path)
        Image.CacheOption = BitmapCacheOption.OnDemand
        Image.EndInit()

        Return Image
    End Function

    Public Shared Function SetBlurEffect(ByVal Target As BitmapSource) As RenderTargetBitmap
        Dim PixelWidth As Integer
        Dim PixelHeight As Integer
        Dim DpiX As Integer
        Dim DpiY As Integer

        Dim SetValue As New Action(Sub()
                                       PixelWidth = Target.PixelWidth
                                       PixelHeight = Target.PixelHeight
                                       DpiX = Target.DpiX * 1.5
                                       DpiY = Target.DpiY * 1.5
                                   End Sub)

        If Target.Dispatcher Is Nothing Then
            SetValue()
        Else
            Target.Dispatcher.Invoke(Sub()
                                         SetValue()
                                     End Sub)
        End If

        Dim MyRectangle As New Rectangle
        MyRectangle.Fill = New ImageBrush(Target)
        MyRectangle.Effect = New BlurEffect() With {.Radius = 50, .RenderingBias = RenderingBias.Quality}

        Dim MySize As New Size(PixelWidth, PixelHeight)
        MyRectangle.Measure(MySize)
        MyRectangle.Arrange(New Rect(MySize))

        Dim MyRenderTargetBitmap As New RenderTargetBitmap(PixelWidth, PixelHeight, DpiX, DpiY, PixelFormats.Pbgra32)
        MyRenderTargetBitmap.Render(MyRectangle)

        Return MyRenderTargetBitmap
    End Function

End Class
