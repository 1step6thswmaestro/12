
Module ModFmodControl

    ''' <summary>
    ''' 
    '''  ' [ FMOD EX Control - 1.3 ]
    ''' 
    '''  
    '''  본 클래스는 FMOD EX 를 간편하게 제어하기 위한 클래스 입니다.
    '''  
    '''  EQ 는 0 ~ 9 까지 10 개가 존재하며 0 ~ 200 사이의 값을 설정할 수 있습니다.  
    '''  스펙트럼 분석기는 외부 폼의 BarGraphe 에 스펙트럼을 표시하여 줍니다.
    ''' 
    ''' 
    ''' </summary>

#Region " [ FMOD 선언 ]"
    Private system As FMOD.System = Nothing
    Private sound1 As FMOD.Sound = Nothing
    Private channel As FMOD.Channel = Nothing
    Private playpath As String

    Private dspconnectiontemp As FMOD.DSPConnection = Nothing
    Private eqa1 As FMOD.DSPConnection
    Private eqa2 As FMOD.DSPConnection
    Private eqa3 As FMOD.DSPConnection
    Private eqa4 As FMOD.DSPConnection
    Private eqa5 As FMOD.DSPConnection
    Private eqa6 As FMOD.DSPConnection
    Private eqa7 As FMOD.DSPConnection
    Private eqa8 As FMOD.DSPConnection
    Private eqa9 As FMOD.DSPConnection
    Private eqa10 As FMOD.DSPConnection

    Public dsplowpass As FMOD.DSP = Nothing
    Public dsphighpass As FMOD.DSP = Nothing
    Public dspecho As FMOD.DSP = Nothing
    Public dspflange As FMOD.DSP = Nothing
    Public dspdistortion As FMOD.DSP = Nothing
    Public dspchorus As FMOD.DSP = Nothing
    Public dspparameq As FMOD.DSP = Nothing
    Public dsppitchshift As FMOD.DSP = Nothing
    Public dspsfxreverb As FMOD.DSP = Nothing

    Public Eq0 As FMOD.DSP
    Public Eq1 As FMOD.DSP
    Public Eq2 As FMOD.DSP
    Public Eq3 As FMOD.DSP
    Public Eq4 As FMOD.DSP
    Public Eq5 As FMOD.DSP
    Public Eq6 As FMOD.DSP
    Public Eq7 As FMOD.DSP
    Public Eq8 As FMOD.DSP
    Public Eq9 As FMOD.DSP
#End Region

#Region " [ FMOD 시작 ]"
    Public Sub InitFmodEX()
        Dim version As UInteger = 0
        Dim result As FMOD.RESULT

        result = FMOD.Factory.System_Create(system)
        ERRCHECK(result)

        result = system.getVersion(version)
        ERRCHECK(result)
        If version < FMOD.VERSION.number Then
            MessageBox.Show("경고 : " & vbCrLf & "본 프로그램이 요구하는 FMODEX.DLL의 버전과 현재의 FMODEX.DLL의 버전이 다릅니다.")
        End If

        result = system.init(32, FMOD.INITFLAGS.NORMAL, CType(Nothing, IntPtr))
        ERRCHECK(result)

        result = system.setStreamBufferSize(6400 * 1024, FMOD.TIMEUNIT.RAWBYTES)
        ERRCHECK(result)
    End Sub

    Public Sub InitEffect()
        Dim result As FMOD.RESULT

        result = system.createDSPByType(FMOD.DSP_TYPE.LOWPASS, dsplowpass)
        ERRCHECK(result)
        result = system.createDSPByType(FMOD.DSP_TYPE.HIGHPASS, dsphighpass)
        ERRCHECK(result)
        result = system.createDSPByType(FMOD.DSP_TYPE.ECHO, dspecho)
        ERRCHECK(result)
        result = system.createDSPByType(FMOD.DSP_TYPE.FLANGE, dspflange)
        ERRCHECK(result)
        result = system.createDSPByType(FMOD.DSP_TYPE.DISTORTION, dspdistortion)
        ERRCHECK(result)
        result = system.createDSPByType(FMOD.DSP_TYPE.CHORUS, dspchorus)
        ERRCHECK(result)
        result = system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ, dspparameq)
        ERRCHECK(result)
        result = system.createDSPByType(FMOD.DSP_TYPE.PITCHSHIFT, dsppitchshift)
        ERRCHECK(result)
        result = system.createDSPByType(FMOD.DSP_TYPE.SFXREVERB, dspsfxreverb)
        ERRCHECK(result)

    End Sub

    Public Sub InitEQ()
        Dim result As FMOD.RESULT

        result = system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ, Eq0)
        ERRCHECK(result)
        result = system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ, Eq1)
        ERRCHECK(result)
        result = system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ, Eq2)
        ERRCHECK(result)
        result = system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ, Eq3)
        ERRCHECK(result)
        result = system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ, Eq4)
        ERRCHECK(result)
        result = system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ, Eq5)
        ERRCHECK(result)
        result = system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ, Eq6)
        ERRCHECK(result)
        result = system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ, Eq7)
        ERRCHECK(result)
        result = system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ, Eq8)
        ERRCHECK(result)
        result = system.createDSPByType(FMOD.DSP_TYPE.PARAMEQ, Eq9)
        ERRCHECK(result)
        result = system.addDSP(Eq0, eqa1)
        ERRCHECK(result)
        result = system.addDSP(Eq1, eqa2)
        ERRCHECK(result)
        result = system.addDSP(Eq2, eqa3)
        ERRCHECK(result)
        result = system.addDSP(Eq3, eqa4)
        ERRCHECK(result)
        result = system.addDSP(Eq4, eqa5)
        ERRCHECK(result)
        result = system.addDSP(Eq5, eqa6)
        ERRCHECK(result)
        result = system.addDSP(Eq6, eqa7)
        ERRCHECK(result)
        result = system.addDSP(Eq7, eqa8)
        ERRCHECK(result)
        result = system.addDSP(Eq8, eqa9)
        ERRCHECK(result)
        result = system.addDSP(Eq9, eqa10)
        ERRCHECK(result)
        result = Eq0.setParameter(FMOD.DSP_PARAMEQ.CENTER, 80)
        ERRCHECK(result)
        result = Eq0.setParameter(FMOD.DSP_PARAMEQ.BANDWIDTH, 2)
        ERRCHECK(result)
        result = Eq0.setParameter(FMOD.DSP_PARAMEQ.GAIN, 1)
        ERRCHECK(result)
        result = Eq1.setParameter(FMOD.DSP_PARAMEQ.CENTER, 170)
        ERRCHECK(result)
        result = Eq1.setParameter(FMOD.DSP_PARAMEQ.BANDWIDTH, 2)
        ERRCHECK(result)
        result = Eq1.setParameter(FMOD.DSP_PARAMEQ.GAIN, 1)
        ERRCHECK(result)
        result = Eq2.setParameter(FMOD.DSP_PARAMEQ.CENTER, 310)
        ERRCHECK(result)
        result = Eq2.setParameter(FMOD.DSP_PARAMEQ.BANDWIDTH, 1)
        ERRCHECK(result)
        result = Eq2.setParameter(FMOD.DSP_PARAMEQ.GAIN, 1)
        ERRCHECK(result)
        result = Eq3.setParameter(FMOD.DSP_PARAMEQ.CENTER, 600)
        ERRCHECK(result)
        result = Eq3.setParameter(FMOD.DSP_PARAMEQ.BANDWIDTH, 2)
        ERRCHECK(result)
        result = Eq3.setParameter(FMOD.DSP_PARAMEQ.GAIN, 1)
        ERRCHECK(result)
        result = Eq4.setParameter(FMOD.DSP_PARAMEQ.CENTER, 1000)
        ERRCHECK(result)
        result = Eq4.setParameter(FMOD.DSP_PARAMEQ.BANDWIDTH, 2)
        ERRCHECK(result)
        result = Eq4.setParameter(FMOD.DSP_PARAMEQ.GAIN, 1)
        ERRCHECK(result)
        result = Eq5.setParameter(FMOD.DSP_PARAMEQ.CENTER, 3000)
        ERRCHECK(result)
        result = Eq5.setParameter(FMOD.DSP_PARAMEQ.BANDWIDTH, 2)
        ERRCHECK(result)
        result = Eq5.setParameter(FMOD.DSP_PARAMEQ.GAIN, 1)
        ERRCHECK(result)
        result = Eq6.setParameter(FMOD.DSP_PARAMEQ.CENTER, 6000)
        ERRCHECK(result)
        result = Eq6.setParameter(FMOD.DSP_PARAMEQ.BANDWIDTH, 2)
        ERRCHECK(result)
        result = Eq6.setParameter(FMOD.DSP_PARAMEQ.GAIN, 1)
        ERRCHECK(result)
        result = Eq7.setParameter(FMOD.DSP_PARAMEQ.CENTER, 12000)
        ERRCHECK(result)
        result = Eq7.setParameter(FMOD.DSP_PARAMEQ.BANDWIDTH, 2)
        ERRCHECK(result)
        result = Eq7.setParameter(FMOD.DSP_PARAMEQ.GAIN, 1)
        ERRCHECK(result)
        result = Eq8.setParameter(FMOD.DSP_PARAMEQ.CENTER, 14000)
        ERRCHECK(result)
        result = Eq8.setParameter(FMOD.DSP_PARAMEQ.BANDWIDTH, 2)
        ERRCHECK(result)
        result = Eq8.setParameter(FMOD.DSP_PARAMEQ.GAIN, 1)
        ERRCHECK(result)
        result = Eq9.setParameter(FMOD.DSP_PARAMEQ.CENTER, 16000)
        ERRCHECK(result)
        result = Eq9.setParameter(FMOD.DSP_PARAMEQ.BANDWIDTH, 2)
        ERRCHECK(result)
        result = Eq9.setParameter(FMOD.DSP_PARAMEQ.GAIN, 1)
        ERRCHECK(result)
    End Sub
#End Region

#Region " [ FMOD 종료 ]"
    Public Sub ReleaseSound()
        Dim result As FMOD.RESULT

        If sound1 IsNot Nothing Then
            result = sound1.release()
            ERRCHECK(result)
        End If
    End Sub

    Public Sub ReleaseFmodEX()
        Dim result As FMOD.RESULT

        If system IsNot Nothing Then
            result = system.close()
            ERRCHECK(result)
            result = system.release()
            ERRCHECK(result)
        End If
    End Sub
#End Region

#Region " [ FMOD 설정 ]"
    Public Sub SetEffect(ByVal cccc As FMOD.DSP)
        Dim result As FMOD.RESULT
        Dim active As Boolean = False

        result = cccc.getActive(active)
        ERRCHECK(result)

        If active = False Then
            result = system.addDSP(cccc, dspconnectiontemp)
            ERRCHECK(result)
        Else
            result = cccc.remove()
            ERRCHECK(result)
        End If

        result = system.update()
        ERRCHECK(result)
    End Sub

    Public Sub SetReverb(ByVal Presets As FMOD.REVERB_PROPERTIES)
        system.setReverbProperties(Presets)
    End Sub

    Public Sub SetEQ(ByVal eq As FMOD.DSP, ByVal value As Single)
        Dim result As FMOD.RESULT
        Dim iniEqPos = value / 100

        If eq Is Nothing Then Exit Sub
        result = eq.setParameter(FMOD.DSP_PARAMEQ.GAIN, iniEqPos)
        ERRCHECK(result)
    End Sub

    Public Sub SetVolume(ByVal value As String)
        On Error Resume Next
        If Not SetPath Is Nothing Then
            Dim result As FMOD.RESULT

            result = channel.setVolume(value)
            ERRCHECK(result)
        End If
    End Sub

    Public Function GetVolume()
        On Error Resume Next
        Dim result As FMOD.RESULT
        Dim NowVol As Integer
        result = channel.getVolume(NowVol)
        ERRCHECK(result)

        Return NowVol
    End Function

    Public Sub SetPosition(ByVal value As UInteger)
        Dim result As FMOD.RESULT

        If mplaytimelen() <> 0 Then
            result = channel.setPosition(value, FMOD.TIMEUNIT.MS)
            ERRCHECK((result))
        End If
    End Sub

    Public Property SetPath As String
        Set(ByVal value As String)
            If value = "" Then Exit Property

            Dim result As FMOD.RESULT
            Dim openstate As FMOD.OPENSTATE = 0
            Dim percentbuffered As UInteger = 0
            Dim starving As Boolean = False

            If InStr(LCase(value), "http://") > 0 Then
                result = system.createSound(value, FMOD.MODE.HARDWARE Or FMOD.MODE.CREATESTREAM, sound1)
                ERRCHECK(result)
                result = sound1.getOpenState(openstate, percentbuffered, starving, False)
                ERRCHECK(result)
            Else
                result = system.createSound(value, FMOD.MODE.HARDWARE Or FMOD.MODE.CREATESTREAM, sound1)
                ERRCHECK(result)
            End If

            playpath = value
        End Set
        Get
            Return playpath
        End Get
    End Property

    Public Sub SetFrequency(ByVal Value As Long)
        On Error Resume Next
        Dim result As FMOD.RESULT

        result = channel.setFrequency(Value)
        ERRCHECK(result)
    End Sub

    Public Function GetFrequency()
        Dim result As FMOD.RESULT
        Dim Temp As Long
        result = channel.getFrequency(Temp)
        ERRCHECK(result)

        Return Temp
    End Function
#End Region

#Region " [ FMOD 제어 ]"
    Public Sub PlaySoundFmodEX()
        Dim result As FMOD.RESULT

        If channel Is Nothing Then
            result = system.playSound(FMOD.CHANNELINDEX.FREE, sound1, False, channel)
            ERRCHECK(result)
        Else
            result = channel.stop()
            ERRCHECK(result)
            result = system.playSound(FMOD.CHANNELINDEX.FREE, sound1, False, channel)
            ERRCHECK(result)
        End If
    End Sub

    Public Sub PauseSoundFmodEX()
        Dim result As FMOD.RESULT
        Dim paused As Boolean

        result = channel.getPaused(paused)
        ERRCHECK(result)

        paused = Not paused

        result = channel.setPaused(paused)
        ERRCHECK(result)
    End Sub

    Public Sub StopSoundFmodEX()
        On Error Resume Next
        Dim result As FMOD.RESULT

        result = channel.stop()
        ERRCHECK(result)
    End Sub
#End Region

#Region " [ FMOD 기능 ]"
    Public Function NowPauseed() As Boolean
        Try
            If SetPath Is Nothing Then
                Return True
            Else
                Dim result As FMOD.RESULT
                Dim paused As Boolean

                result = channel.getPaused(paused)
                ERRCHECK(result)

                If paused = True Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            Return True
        End Try
    End Function

    Public Function ConvertTime(ByVal Time As Integer) As String
        Dim CentSec As Integer
        Dim Sec As Integer
        Dim Min As Integer
        Dim Heure As Integer

        CentSec = Time \ 10
        Sec = Time \ 1000
        CentSec = CentSec - Sec * 100
        Min = Sec \ 60
        Sec = Sec - Min * 60
        Heure = Min \ 60
        Min = Min - Heure * 60
        If Heure <> 0 Then
            ConvertTime = Heure & ":" & Format(Min, "00") & ":" & Format(Sec, "00") & "." & Format(CentSec, "00")
        Else
            If Min <> 0 Then
                ConvertTime = Min & ":" & Format(Sec, "00") & "." & Format(CentSec, "00")
            Else
                If Sec <> 0 Then
                    ConvertTime = Sec & "." & Format(CentSec, "00")
                Else
                    ConvertTime = CentSec
                End If
            End If
        End If
    End Function

    Public Function GetSpectrum(ByVal SpectrumSize As Integer) As Single()
        Dim Spec(SpectrumSize) As Single
        Dim Spec1(SpectrumSize) As Single
        Dim Spec2(SpectrumSize) As Single
        channel.getSpectrum(Spec1, SpectrumSize, 0, FMOD.DSP_FFT_WINDOW.RECT)
        channel.getSpectrum(Spec2, SpectrumSize, 1, FMOD.DSP_FFT_WINDOW.RECT)

        For i As Integer = 0 To SpectrumSize - 1
            Spec(i) = ((Spec1(i) + Spec2(i)) / 2)
        Next

        Return Spec
    End Function
#End Region

#Region " [ FMOD 정보 ]"
    Public Function mplaytime() As UInteger
        Dim result As FMOD.RESULT
        Dim currentsound As FMOD.Sound = Nothing
        Dim ms As UInteger
        If channel IsNot Nothing Then
            result = channel.getPosition(ms, FMOD.TIMEUNIT.MS)
            ERRCHECK(result)
        End If

        Return ms
    End Function

    Public Function mplaytimelen() As UInteger
        Dim result As FMOD.RESULT
        Dim currentsound As FMOD.Sound = Nothing
        Dim lenms As UInteger

        If channel IsNot Nothing Then
            channel.getCurrentSound(currentsound)
            If currentsound IsNot Nothing Then
                result = currentsound.getLength(lenms, FMOD.TIMEUNIT.MS)
                ERRCHECK(result)
            End If
        End If

        Return lenms
    End Function

    Public Function GetVUMeter() As Integer
        Dim VULevels As Integer = 0
        Dim Result As FMOD.RESULT
        Dim Levels(1) As Single
        Dim Wavedata(440) As Single
        Dim Numchannels As Integer
        Result = system.getSoftwareFormat(0, 0, Numchannels, 0, 0, 0)
        ERRCHECK((Result))
        For Count1 = 0 To (Numchannels - 1)
            Result = system.getWaveData(Wavedata, 441, Count1)
            ERRCHECK((Result))
            For count2 = 0 To 440
                If Wavedata(count2) > Levels(Count1) Then
                    Levels(Count1) = Wavedata(count2)
                End If
            Next
            If Count1 = 0 Then
                VULevels = Levels(Count1) * 100
                If VULevels >= 100 Then
                    VULevels = 100
                End If
            End If
        Next
        Result = system.update
        ERRCHECK((Result))

        Return VULevels
    End Function

    Public Sub ERRCHECK(ByVal result As FMOD.RESULT)
        If result <> FMOD.RESULT.OK Then
            If result <> 36 Then
                ' ERROR
            End If
        End If
    End Sub
#End Region

End Module
