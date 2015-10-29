Public Class MediaManager

    Public Shared Event OnMediaChanged(ByVal Path As String)

    Public Shared Sub Play(ByVal Path As String)
        If SetPath IsNot Nothing Then ReleaseSound()
        SetPath = Path
        PlaySoundFmodEX()

        RaiseEvent OnMediaChanged(Path)
    End Sub
End Class
