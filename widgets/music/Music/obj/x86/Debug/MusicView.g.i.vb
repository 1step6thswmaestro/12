﻿#ExternalChecksum("..\..\..\MusicView.xaml","{406ea660-64cf-4c82-b6f0-42d48172a799}","CEC1AAFAA8BC3DDAE496D8F07618969D")
'------------------------------------------------------------------------------
' <auto-generated>
'     이 코드는 도구를 사용하여 생성되었습니다.
'     런타임 버전:4.0.30319.42000
'
'     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
'     이러한 변경 내용이 손실됩니다.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports Music
Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell


'''<summary>
'''MusicView
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class MusicView
    Inherits System.Windows.Controls.UserControl
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\..\MusicView.xaml",39)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents SpectrumPanel As System.Windows.Controls.Grid
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\MusicView.xaml",40)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents EllipseAlbum As System.Windows.Shapes.Ellipse
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\MusicView.xaml",45)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents EllipseAlbumOver As System.Windows.Shapes.Ellipse
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\MusicView.xaml",47)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents TextTitle As System.Windows.Controls.TextBlock
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\MusicView.xaml",58)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents TextArtist As System.Windows.Controls.TextBlock
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\MusicView.xaml",68)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents TextTime As System.Windows.Controls.TextBlock
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/Music;component/musicview.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\..\MusicView.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            Me.SpectrumPanel = CType(target,System.Windows.Controls.Grid)
            Return
        End If
        If (connectionId = 2) Then
            Me.EllipseAlbum = CType(target,System.Windows.Shapes.Ellipse)
            Return
        End If
        If (connectionId = 3) Then
            Me.EllipseAlbumOver = CType(target,System.Windows.Shapes.Ellipse)
            Return
        End If
        If (connectionId = 4) Then
            Me.TextTitle = CType(target,System.Windows.Controls.TextBlock)
            Return
        End If
        If (connectionId = 5) Then
            Me.TextArtist = CType(target,System.Windows.Controls.TextBlock)
            Return
        End If
        If (connectionId = 6) Then
            Me.TextTime = CType(target,System.Windows.Controls.TextBlock)
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class

