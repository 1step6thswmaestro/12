Class VertexSlider
    Inherits Slider
    Private defaultIsMoveToPointEnabled As Boolean
    Public Shared ReadOnly AutoMoveProperty As DependencyProperty = DependencyProperty.Register("AutoMove", GetType(Boolean), GetType(VertexSlider), New PropertyMetadata(False, AddressOf ChangeAutoMoveProperty))

    Public Property AutoMove() As Boolean
        Get
            Return CBool(GetValue(AutoMoveProperty))
        End Get

        Set(value As Boolean)
            SetValue(AutoMoveProperty, value)
        End Set
    End Property

    Private Shared Sub ChangeAutoMoveProperty(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim slider As VertexSlider = TryCast(d, VertexSlider)
        If slider IsNot Nothing Then
            If CBool(e.NewValue) Then
                slider.defaultIsMoveToPointEnabled = slider.IsMoveToPointEnabled
                slider.IsMoveToPointEnabled = True
                AddHandler slider.PreviewMouseUp, AddressOf CustomSlider_PreviewMouseUp
                AddHandler slider.PreviewMouseDown, AddressOf CustomSlider_PreviewMouseDown
                AddHandler slider.PreviewMouseMove, AddressOf CustomSlider_PreviewMouseMove
            Else
                slider.IsMoveToPointEnabled = slider.defaultIsMoveToPointEnabled
                RemoveHandler slider.PreviewMouseUp, AddressOf CustomSlider_PreviewMouseUp
                RemoveHandler slider.PreviewMouseDown, AddressOf CustomSlider_PreviewMouseDown
                RemoveHandler slider.PreviewMouseMove, AddressOf CustomSlider_PreviewMouseMove
            End If
        End If
    End Sub

    Private Shared IsThumbClicked As Boolean = False

    Private Shared Sub CustomSlider_PreviewMouseUp(sender As Object, e As MouseEventArgs)
        IsThumbClicked = False
    End Sub
    Private Shared Sub CustomSlider_PreviewMouseDown(sender As Object, e As MouseEventArgs)
        IsThumbClicked = True
    End Sub

    Private Shared Sub CustomSlider_PreviewMouseMove(sender As Object, e As MouseEventArgs)
        Dim slider As VertexSlider = TryCast(sender, VertexSlider)
        Dim point As Point = e.GetPosition(slider)
        If e.LeftButton = MouseButtonState.Pressed AndAlso IsThumbClicked = False Then
            If slider.Orientation = Controls.Orientation.Horizontal Then
                slider.Value = point.X / (slider.ActualWidth / slider.Maximum)
            Else
                slider.Value = slider.Minimum + (slider.ActualHeight - point.Y) / (slider.ActualHeight / (slider.Maximum + Math.Abs(slider.Minimum)))
            End If
        End If
    End Sub
End Class