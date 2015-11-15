Imports System.IO
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

    Public Shared Function AverageColor(ByVal Target As BitmapSource) As Color
        Dim Bitmap As System.Drawing.Bitmap
        Using Stream As New MemoryStream()
            Dim Encoder As BitmapEncoder = New BmpBitmapEncoder()
            Encoder.Frames.Add(BitmapFrame.Create(Target))
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

        Return Color.FromArgb(255, AverageR, AverageG, AverageB)
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

    Public Shared Function Resize(ByVal Target As BitmapFrame, ByVal Width As Integer, ByVal Height As Integer) As BitmapFrame
        Return BitmapFrame.Create(New TransformedBitmap(Target, New ScaleTransform(Width / Target.Width, Height / Target.Height, 0, 0)))
    End Function
End Class
