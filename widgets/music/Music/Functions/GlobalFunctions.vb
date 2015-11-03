Module GlobalFunctions
    Public Function Milli2HMS(ByVal lngTimeInMilliSeconds As Long) As String
        Dim lngSecRemainder As Long
        Dim lngMinSecRemainder As Long
        Dim lngHoursPart As Long
        Dim lngMinutesPart As Long
        Dim lngSecondsPart As Long
        Dim sTimeRemaining As String
        Dim sMinutesPart As String
        Dim sSecondsPart As String

        lngHoursPart = lngTimeInMilliSeconds \ 3600000
        lngMinSecRemainder = lngTimeInMilliSeconds Mod 3600000
        lngMinutesPart = lngMinSecRemainder \ 60000
        lngSecRemainder = lngMinSecRemainder Mod 60000
        lngSecondsPart = lngSecRemainder \ 1000

        sMinutesPart = Format(lngMinutesPart, "00")
        sSecondsPart = Format(lngSecondsPart, "00")

        sTimeRemaining = sMinutesPart & ":" & sSecondsPart

        Milli2HMS = sTimeRemaining
    End Function
End Module
