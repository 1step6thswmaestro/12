
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Input
Imports System.Windows.Media

Class ScrollViewerWithTouch
    Inherits ScrollViewer
    ''' <summary>
    ''' Original panning mode.
    ''' </summary>
    Private _PanningMode As PanningMode

    ''' <summary>
    ''' Set panning mode only once.
    ''' </summary>
    Private _PanningModeSet As Boolean

    ''' <summary>
    ''' Initializes static members of the <see cref="ScrollViewerWithTouch"/> class.
    ''' </summary>
    Shared Sub New()
        DefaultStyleKeyProperty.OverrideMetadata(GetType(ScrollViewerWithTouch), New FrameworkPropertyMetadata(GetType(ScrollViewerWithTouch)))
    End Sub

    Protected Overrides Sub OnManipulationCompleted(e As ManipulationCompletedEventArgs)
        MyBase.OnManipulationCompleted(e)

        ' set it back
        PanningMode = _PanningMode
    End Sub

    Protected Overrides Sub OnManipulationStarted(e As ManipulationStartedEventArgs)
        ' figure out what has the user touched
        Dim result = VisualTreeHelper.HitTest(Me, e.ManipulationOrigin)
        If result IsNot Nothing AndAlso result.VisualHit IsNot Nothing Then
            Dim hasButtonParent = Me.HasButtonParent(result.VisualHit)

            ' if user touched a button then turn off panning mode, let style bubble down, in other case let it scroll
            PanningMode = If(hasButtonParent, PanningMode.None, _PanningMode)
        End If

        MyBase.OnManipulationStarted(e)
    End Sub

    Protected Overrides Sub OnTouchDown(e As TouchEventArgs)
        ' store panning mode or set it back to it's original state. OnManipulationCompleted does not do it every time, so we need to set it once more.
        If _PanningModeSet = False Then
            _PanningMode = PanningMode
            _PanningModeSet = True
        Else
            PanningMode = _PanningMode
        End If

        MyBase.OnTouchDown(e)
    End Sub

    Private Function HasButtonParent(obj As DependencyObject) As Boolean
        Dim parent = VisualTreeHelper.GetParent(obj)

        If (parent IsNot Nothing) AndAlso (TypeOf parent Is ButtonBase) = False Then
            Return HasButtonParent(parent)
        End If

        Return parent IsNot Nothing
    End Function
End Class