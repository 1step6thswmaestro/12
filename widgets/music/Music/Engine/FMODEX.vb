' ========================================================================================== 

'                                                                                            

' FMOD Ex - C# Wrapper . Copyright (c), Firelight Technologies Pty, Ltd. 2004-2011.          

'                                                                                            

' ========================================================================================== 


Imports System.Text
Imports System.Runtime.InteropServices

Namespace FMOD
    '
    '        FMOD version number.  Check this against FMOD::System::getVersion / System_GetVersion
    '        0xaaaabbcc -> aaaa = major version number.  bb = minor version number.  cc = development version number.
    '    

    Public Class VERSION
        Public Const number As Integer = &H44300
#If WIN64 Then
		Public Const dll As String = "fmodex64"
#Else
        Public Const dll As String = "fmodex"
#End If
    End Class

    '
    '        FMOD types 
    '    

    '
    '    [STRUCTURE] 
    '    [
    '        [DESCRIPTION]   
    '        Structure describing a point in 3D space.
    '
    '        [REMARKS]
    '        FMOD uses a left handed co-ordinate system by default.
    '        To use a right handed co-ordinate system specify FMOD_INIT_3D_RIGHTHANDED from FMOD_INITFLAGS in System::init.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]      
    '        System::set3DListenerAttributes
    '        System::get3DListenerAttributes
    '        Channel::set3DAttributes
    '        Channel::get3DAttributes
    '        Geometry::addPolygon
    '        Geometry::setPolygonVertex
    '        Geometry::getPolygonVertex
    '        Geometry::setRotation
    '        Geometry::getRotation
    '        Geometry::setPosition
    '        Geometry::getPosition
    '        Geometry::setScale
    '        Geometry::getScale
    '        FMOD_INITFLAGS
    '    ]
    '    

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure VECTOR
        Public x As Single
        ' X co-ordinate in 3D space. 
        Public y As Single
        ' Y co-ordinate in 3D space. 
        Public z As Single
        ' Z co-ordinate in 3D space. 
    End Structure


    '
    '    [STRUCTURE] 
    '    [
    '        [DESCRIPTION]   
    '        Structure describing a globally unique identifier.
    '
    '        [REMARKS]
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]      
    '        System::getDriverInfo
    '    ]
    '    

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure GUID
        Public Data1 As UInteger
        ' Specifies the first 8 hexadecimal digits of the GUID 
        Public Data2 As UShort
        ' Specifies the first group of 4 hexadecimal digits.   
        Public Data3 As UShort
        ' Specifies the second group of 4 hexadecimal digits.  
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> _
        Public Data4 As Byte()
        ' Array of 8 bytes. The first 2 bytes contain the third group of 4 hexadecimal digits. The remaining 6 bytes contain the final 12 hexadecimal digits. 
    End Structure

    '
    '    [STRUCTURE] 
    '    [
    '        [DESCRIPTION]   
    '
    '        [REMARKS]
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii, iPhone
    '
    '        [SEE_ALSO]      
    '    ]
    '    

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure ASYNCREADINFO
        Public handle As IntPtr
        ' [r] The file handle that was filled out in the open callback. 
        Public offset As UInteger
        ' [r] Seek position, make sure you read from this file offset. 
        Public sizebytes As UInteger
        ' [r] how many bytes requested for read. 
        Public priority As Integer
        ' [r] 0 = low importance.  100 = extremely important (ie 'must read now or stuttering may occur') 

        Public buffer As IntPtr
        ' [w] Buffer to read file data into. 
        Public bytesread As UInteger
        ' [w] Fill this in before setting result code to tell FMOD how many bytes were read. 
        Public result As RESULT
        ' [r/w] Result code, FMOD_OK tells the system it is ready to consume the data.  Set this last!  Default value = FMOD_ERR_NOTREADY. 

        Public userdata As IntPtr
        ' [r] User data pointer. 
    End Structure

    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]   
    '        error codes.  Returned from every function.
    '
    '        [REMARKS]
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]      
    '    ]
    '    

    Public Enum RESULT As Integer
        OK
        ' No errors. 
        ERR_ALREADYLOCKED
        ' Tried to call lock a second time before unlock was called. 
        ERR_BADCOMMAND
        ' Tried to call a function on a data type that does not allow this type of functionality (ie calling Sound::lock on a streaming sound). 
        ERR_CDDA_DRIVERS
        ' Neither NTSCSI nor ASPI could be initialised. 
        ERR_CDDA_INIT
        ' An error occurred while initialising the CDDA subsystem. 
        ERR_CDDA_INVALID_DEVICE
        ' Couldn't find the specified device. 
        ERR_CDDA_NOAUDIO
        ' No audio tracks on the specified disc. 
        ERR_CDDA_NODEVICES
        ' No CD/DVD devices were found. 
        ERR_CDDA_NODISC
        ' No disc present in the specified drive. 
        ERR_CDDA_READ
        ' A CDDA read error occurred. 
        ERR_CHANNEL_ALLOC
        ' Error trying to allocate a channel. 
        ERR_CHANNEL_STOLEN
        ' The specified channel has been reused to play another sound. 
        ERR_COM
        ' A Win32 COM related error occured. COM failed to initialize or a QueryInterface failed meaning a Windows codec or driver was not installed properly. 
        ERR_DMA
        ' DMA Failure.  See debug output for more information. 
        ERR_DSP_CONNECTION
        ' DSP connection error.  Connection possibly caused a cyclic dependancy. 
        ERR_DSP_FORMAT
        ' DSP Format error.  A DSP unit may have attempted to connect to this network with the wrong format. 
        ERR_DSP_NOTFOUND
        ' DSP connection error.  Couldn't find the DSP unit specified. 
        ERR_DSP_RUNNING
        ' DSP error.  Cannot perform this operation while the network is in the middle of running.  This will most likely happen if a connection or disconnection is attempted in a DSP callback. 
        ERR_DSP_TOOMANYCONNECTIONS
        ' DSP connection error.  The unit being connected to or disconnected should only have 1 input or output. 
        ERR_FILE_BAD
        ' Error loading file. 
        ERR_FILE_COULDNOTSEEK
        ' Couldn't perform seek operation.  This is a limitation of the medium (ie netstreams) or the file format. 
        ERR_FILE_DISKEJECTED
        ' Media was ejected while reading. 
        ERR_FILE_EOF
        ' End of file unexpectedly reached while trying to read essential data (truncated data?). 
        ERR_FILE_NOTFOUND
        ' File not found. 
        ERR_FILE_UNWANTED
        ' Unwanted file access occured. 
        ERR_FORMAT
        ' Unsupported file or audio format. 
        ERR_HTTP
        ' A HTTP error occurred. This is a catch-all for HTTP errors not listed elsewhere. 
        ERR_HTTP_ACCESS
        ' The specified resource requires authentication or is forbidden. 
        ERR_HTTP_PROXY_AUTH
        ' Proxy authentication is required to access the specified resource. 
        ERR_HTTP_SERVER_ERROR
        ' A HTTP server error occurred. 
        ERR_HTTP_TIMEOUT
        ' The HTTP request timed out. 
        ERR_INITIALIZATION
        ' FMOD was not initialized correctly to support this function. 
        ERR_INITIALIZED
        ' Cannot call this command after System::init. 
        ERR_INTERNAL
        ' An error occured that wasn't supposed to.  Contact support. 
        ERR_INVALID_ADDRESS
        ' On Xbox 360, this memory address passed to FMOD must be physical, (ie allocated with XPhysicalAlloc.) 
        ERR_INVALID_FLOAT
        ' Value passed in was a NaN, Inf or denormalized float. 
        ERR_INVALID_HANDLE
        ' An invalid object handle was used. 
        ERR_INVALID_PARAM
        ' An invalid parameter was passed to this function. 
        ERR_INVALID_POSITION
        ' An invalid seek position was passed to this function. 
        ERR_INVALID_SPEAKER
        ' An invalid speaker was passed to this function based on the current speaker mode. 
        ERR_INVALID_SYNCPOINT
        ' The syncpoint did not come from this sound handle. 
        ERR_INVALID_VECTOR
        ' The vectors passed in are not unit length, or perpendicular. 
        ERR_MAXAUDIBLE
        ' Reached maximum audible playback count for this sound's soundgroup. 
        ERR_MEMORY
        ' Not enough memory or resources. 
        ERR_MEMORY_CANTPOINT
        ' Can't use FMOD_OPENMEMORY_POINT on non PCM source data, or non mp3/xma/adpcm data if CREATECOMPRESSEDSAMPLE was used. 
        ERR_MEMORY_SRAM
        ' Not enough memory or resources on console sound ram. 
        ERR_NEEDS2D
        ' Tried to call a command on a 3d sound when the command was meant for 2d sound. 
        ERR_NEEDS3D
        ' Tried to call a command on a 2d sound when the command was meant for 3d sound. 
        ERR_NEEDSHARDWARE
        ' Tried to use a feature that requires hardware support.  (ie trying to play a GCADPCM compressed sound in software on Wii). 
        ERR_NEEDSSOFTWARE
        ' Tried to use a feature that requires the software engine.  Software engine has either been turned off, or command was executed on a hardware channel which does not support this feature. 
        ERR_NET_CONNECT
        ' Couldn't connect to the specified host. 
        ERR_NET_SOCKET_ERROR
        ' A socket error occurred.  This is a catch-all for socket-related errors not listed elsewhere. 
        ERR_NET_URL
        ' The specified URL couldn't be resolved. 
        ERR_NET_WOULD_BLOCK
        ' Operation on a non-blocking socket could not complete immediately. 
        ERR_NOTREADY
        ' Operation could not be performed because specified sound is not ready. 
        ERR_OUTPUT_ALLOCATED
        ' Error initializing output device, but more specifically, the output device is already in use and cannot be reused. 
        ERR_OUTPUT_CREATEBUFFER
        ' Error creating hardware sound buffer. 
        ERR_OUTPUT_DRIVERCALL
        ' A call to a standard soundcard driver failed, which could possibly mean a bug in the driver or resources were missing or exhausted. 
        ERR_OUTPUT_ENUMERATION
        ' Error enumerating the available driver list. List may be inconsistent due to a recent device addition or removal. 
        ERR_OUTPUT_FORMAT
        ' Soundcard does not support the minimum features needed for this soundsystem (16bit stereo output). 
        ERR_OUTPUT_INIT
        ' Error initializing output device. 
        ERR_OUTPUT_NOHARDWARE
        ' FMOD_HARDWARE was specified but the sound card does not have the resources nescessary to play it. 
        ERR_OUTPUT_NOSOFTWARE
        ' Attempted to create a software sound but no software channels were specified in System::init. 
        ERR_PAN
        ' Panning only works with mono or stereo sound sources. 
        ERR_PLUGIN
        ' An unspecified error has been returned from a 3rd party plugin. 
        ERR_PLUGIN_INSTANCES
        ' The number of allowed instances of a plugin has been exceeded 
        ERR_PLUGIN_MISSING
        ' A requested output, dsp unit type or codec was not available. 
        ERR_PLUGIN_RESOURCE
        ' A resource that the plugin requires cannot be found. (ie the DLS file for MIDI playback) 
        ERR_PRELOADED
        ' The specified sound is still in use by the event system, call EventSystem::unloadFSB before trying to release it. 
        ERR_PROGRAMMERSOUND
        ' The specified sound is still in use by the event system, wait for the event which is using it finish with it. 
        ERR_RECORD
        ' An error occured trying to initialize the recording device. 
        ERR_REVERB_INSTANCE
        ' Specified Instance in REVERB_PROPERTIES couldn't be set. Most likely because another application has locked the EAX4 FX slot. 
        ERR_SUBSOUND_ALLOCATED
        ' This subsound is already being used by another sound, you cannot have more than one parent to a sound.  Null out the other parent's entry first. 
        ERR_SUBSOUND_CANTMOVE
        ' Shared subsounds cannot be replaced or moved from their parent stream, such as when the parent stream is an FSB file. 
        ERR_SUBSOUND_MODE
        ' The subsound's mode bits do not match with the parent sound's mode bits.  See documentation for function that it was called with. 
        ERR_SUBSOUNDS
        ' The error occured because the sound referenced contains subsounds.  (ie you cannot play the parent sound as a static sample, only its subsounds.) 
        ERR_TAGNOTFOUND
        ' The specified tag could not be found or there are no tags. 
        ERR_TOOMANYCHANNELS
        ' The sound created exceeds the allowable input channel count.  This can be increased using the maxinputchannels parameter in System::setSoftwareFormat. 
        ERR_UNIMPLEMENTED
        ' Something in FMOD hasn't been implemented when it should be! contact support! 
        ERR_UNINITIALIZED
        ' This command failed because System::init or System::setDriver was not called. 
        ERR_UNSUPPORTED
        ' A command issued was not supported by this object.  Possibly a plugin without certain callbacks specified. 
        ERR_UPDATE
        ' An error caused by System::update occured. 
        ERR_VERSION
        ' The version number of this file format is not supported. 

        ERR_EVENT_FAILED
        ' An Event failed to be retrieved, most likely due to 'just fail' being specified as the max playbacks behavior. 
        ERR_EVENT_INFOONLY
        ' Can't execute this command on an EVENT_INFOONLY event. 
        ERR_EVENT_INTERNAL
        ' An error occured that wasn't supposed to.  See debug log for reason. 
        ERR_EVENT_MAXSTREAMS
        ' Event failed because 'Max streams' was hit when FMOD_INIT_FAIL_ON_MAXSTREAMS was specified. 
        ERR_EVENT_MISMATCH
        ' FSB mis-matches the FEV it was compiled with. 
        ERR_EVENT_NAMECONFLICT
        ' A category with the same name already exists. 
        ERR_EVENT_NOTFOUND
        ' The requested event, event group, event category or event property could not be found. 
        ERR_EVENT_NEEDSSIMPLE
        ' Tried to call a function on a complex event that's only supported by simple events. 
        ERR_EVENT_GUIDCONFLICT
        ' An event with the same GUID already exists. 
        ERR_EVENT_ALREADY_LOADED
        ' The specified project has already been loaded. Having multiple copies of the same project loaded simultaneously is forbidden. 

        ERR_MUSIC_UNINITIALIZED
        ' Music system is not initialized probably because no music data is loaded. 
        ERR_MUSIC_NOTFOUND
        ' The requested music entity could not be found. 
        ERR_MUSIC_NOCALLBACK
        ' The music callback is required, but it has not been set. 
    End Enum



    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]   
    '        These output types are used with System::setOutput/System::getOutput, to choose which output method to use.
    '  
    '        [REMARKS]
    '        To drive the output synchronously, and to disable FMOD's timing thread, use the FMOD_INIT_NONREALTIME flag.
    '        
    '        To pass information to the driver when initializing fmod use the extradriverdata parameter for the following reasons.
    '        <li>FMOD_OUTPUTTYPE_WAVWRITER - extradriverdata is a pointer to a char * filename that the wav writer will output to.
    '        <li>FMOD_OUTPUTTYPE_WAVWRITER_NRT - extradriverdata is a pointer to a char * filename that the wav writer will output to.
    '        <li>FMOD_OUTPUTTYPE_DSOUND - extradriverdata is a pointer to a HWND so that FMOD can set the focus on the audio for a particular window.
    '        <li>FMOD_OUTPUTTYPE_GC - extradriverdata is a pointer to a FMOD_ARAMBLOCK_INFO struct. This can be found in fmodgc.h.
    '        Currently these are the only FMOD drivers that take extra information.  Other unknown plugins may have different requirements.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]      
    '        System::setOutput
    '        System::getOutput
    '        System::setSoftwareFormat
    '        System::getSoftwareFormat
    '        System::init
    '    ]
    '    

    Public Enum OUTPUTTYPE As Integer
        AUTODETECT
        ' Picks the best output mode for the platform.  This is the default. 

        UNKNOWN
        ' All             - 3rd party plugin, unknown.  This is for use with System::getOutput only. 
        NOSOUND
        ' All             - All calls in this mode succeed but make no sound. 
        WAVWRITER
        ' All             - Writes output to fmodoutput.wav by default.  Use the 'extradriverdata' parameter in System::init, by simply passing the filename as a string, to set the wav filename. 
        NOSOUND_NRT
        ' All             - Non-realtime version of _NOSOUND.  User can drive mixer with System::update at whatever rate they want. 
        WAVWRITER_NRT
        ' All             - Non-realtime version of _WAVWRITER.  User can drive mixer with System::update at whatever rate they want. 

        DSOUND
        ' Win32/Win64     - DirectSound output.                       (Default on Windows XP and below) 
        WINMM
        ' Win32/Win64     - Windows Multimedia output. 
        WASAPI
        ' Win32           - Windows Audio Session API.                (Default on Windows Vista and above) 
        ASIO
        ' Win32           - Low latency ASIO 2.0 driver. 
        OSS
        ' Linux/Linux64   - Open Sound System output.                 (Default on Linux, third preference) 
        ALSA
        ' Linux/Linux64   - Advanced Linux Sound Architecture output. (Default on Linux, second preference if available) 
        ESD
        ' Linux/Linux64   - Enlightment Sound Daemon output. 
        PULSEAUDIO
        ' Linux/Linux64   - PulseAudio output.                        (Default on Linux, first preference if available) 
        COREAUDIO
        ' Mac             - Macintosh CoreAudio output.               (Default on Mac) 
        XBOX360
        ' Xbox 360        - Native Xbox360 output.                    (Default on Xbox 360) 
        PSP
        ' PSP             - Native PSP output.                        (Default on PSP) 
        PS3
        ' PS3             - Native PS3 output.                        (Default on PS3) 
        NGP
        ' NGP             - Native NGP output.                        (Default on NGP) 
        WII
        ' Wii			    - Native Wii output.                        (Default on Wii) 
        _3DS
        ' 3DS             - Native 3DS output                         (Default on 3DS) 
        AUDIOTRACK
        ' Android         - Java Audio Track output.                  (Default on Android 2.2 and below) 
        OPENSL
        ' Android         - OpenSL ES output.                         (Default on Android 2.3 and above) 
        NACL
        ' Native Client   - Native Client output.                     (Default on Native Client) 
        WIIU
        ' Wii U           - Native Wii U output.                      (Default on Wii U) 

        MAX
        ' Maximum number of output types supported. 
    End Enum


    '
    '    [ENUM] 
    '    [
    '        [DESCRIPTION]   
    '
    '        [REMARKS]
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]
    '    ]
    '    

    Public Enum CAPS
        NONE = &H0
        ' Device has no special capabilities. 
        HARDWARE = &H1
        ' Device supports hardware mixing. 
        HARDWARE_EMULATED = &H2
        ' User has device set to 'Hardware acceleration = off' in control panel, and now extra 200ms latency is incurred. 
        OUTPUT_MULTICHANNEL = &H4
        ' Device can do multichannel output, ie greater than 2 channels. 
        OUTPUT_FORMAT_PCM8 = &H8
        ' Device can output to 8bit integer PCM. 
        OUTPUT_FORMAT_PCM16 = &H10
        ' Device can output to 16bit integer PCM. 
        OUTPUT_FORMAT_PCM24 = &H20
        ' Device can output to 24bit integer PCM. 
        OUTPUT_FORMAT_PCM32 = &H40
        ' Device can output to 32bit integer PCM. 
        OUTPUT_FORMAT_PCMFLOAT = &H80
        ' Device can output to 32bit floating point PCM. 
        REVERB_LIMITED = &H2000
        ' Device supports some form of limited hardware reverb, maybe parameterless and only selectable by environment. 
    End Enum

    '
    '    [DEFINE] 
    '    [
    '        [NAME]
    '        FMOD_DEBUGLEVEL
    '
    '        [DESCRIPTION]   
    '        Bit fields to use with FMOD::Debug_SetLevel / FMOD::Debug_GetLevel to control the level of tty debug output with logging versions of FMOD (fmodL).
    '
    '        [REMARKS]
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]
    '        Debug_SetLevel 
    '        Debug_GetLevel
    '    ]
    '    

    Public Enum DEBUGLEVEL
        LEVEL_NONE = &H0
        LEVEL_LOG = &H1
        LEVEL_ERROR = &H2
        LEVEL_WARNING = &H4
        LEVEL_HINT = &H8
        LEVEL_ALL = &HFF
        TYPE_MEMORY = &H100
        TYPE_THREAD = &H200
        TYPE_FILE = &H400
        TYPE_NET = &H800
        TYPE_EVENT = &H1000
        TYPE_ALL = &HFFFF
        DISPLAY_TIMESTAMPS = &H1000000
        DISPLAY_LINENUMBERS = &H2000000
        DISPLAY_COMPRESS = &H4000000
        DISPLAY_THREAD = &H8000000
        DISPLAY_ALL = &HF000000
        ALL = &HFFFFFFFF
    End Enum


    '
    '    [DEFINE] 
    '    [
    '        [NAME]
    '        FMOD_MEMORY_TYPE
    '
    '        [DESCRIPTION]   
    '        Bit fields for memory allocation type being passed into FMOD memory callbacks.
    '
    '        [REMARKS]
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]
    '        FMOD_MEMORY_ALLOCCALLBACK
    '        FMOD_MEMORY_REALLOCCALLBACK
    '        FMOD_MEMORY_FREECALLBACK
    '        Memory_Initialize
    '    
    '    ]
    '    

    Public Enum MEMORY_TYPE
        NORMAL = &H0
        ' Standard memory. 
        STREAM_FILE = &H1
        ' Stream file buffer, size controllable with System::setStreamBufferSize. 
        STREAM_DECODE = &H2
        ' Stream decode buffer, size controllable with FMOD_CREATESOUNDEXINFO::decodebuffersize. 
        SAMPLEDATA = &H4
        ' Sample data buffer.  Raw audio data, usually PCM/MPEG/ADPCM/XMA data. 
        DSP_OUTPUTBUFFER = &H8
        ' DSP memory block allocated when more than 1 output exists on a DSP node. 
        XBOX360_PHYSICAL = &H100000
        ' Requires XPhysicalAlloc / XPhysicalFree. 
        PERSISTENT = &H200000
        ' Persistent memory. Memory will be freed when System::release is called. 
        SECONDARY = &H400000
        ' Secondary memory. Allocation should be in secondary memory. For example RSX on the PS3. 
    End Enum


    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]   
    '        These are speaker types defined for use with the System::setSpeakerMode or System::getSpeakerMode command.
    '
    '        [REMARKS]
    '        These are important notes on speaker modes in regards to sounds created with FMOD_SOFTWARE.<br>
    '        Note below the phrase 'sound channels' is used.  These are the subchannels inside a sound, they are not related and 
    '        have nothing to do with the FMOD class "Channel".<br>
    '        For example a mono sound has 1 sound channel, a stereo sound has 2 sound channels, and an AC3 or 6 channel wav file have 6 "sound channels".<br>
    '        <br>
    '        FMOD_SPEAKERMODE_RAW<br>
    '        ---------------------<br>
    '        This mode is for output devices that are not specifically mono/stereo/quad/surround/5.1 or 7.1, but are multichannel.<br>
    '        Sound channels map to speakers sequentially, so a mono sound maps to output speaker 0, stereo sound maps to output speaker 0 & 1.<br>
    '        The user assumes knowledge of the speaker order.  FMOD_SPEAKER enumerations may not apply, so raw channel indicies should be used.<br>
    '        Multichannel sounds map input channels to output channels 1:1. <br>
    '        Channel::setPan and Channel::setSpeakerMix do not work.<br>
    '        Speaker levels must be manually set with Channel::setSpeakerLevels.<br>
    '        <br>
    '        FMOD_SPEAKERMODE_MONO<br>
    '        ---------------------<br>
    '        This mode is for a 1 speaker arrangement.<br>
    '        Panning does not work in this speaker mode.<br>
    '        Mono, stereo and multichannel sounds have each sound channel played on the one speaker unity.<br>
    '        Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.<br>
    '        Channel::setSpeakerMix does not work.<br>
    '        <br>
    '        FMOD_SPEAKERMODE_STEREO<br>
    '        -----------------------<br>
    '        This mode is for 2 speaker arrangements that have a left and right speaker.<br>
    '        <li>Mono sounds default to an even distribution between left and right.  They can be panned with Channel::setPan.<br>
    '        <li>Stereo sounds default to the middle, or full left in the left speaker and full right in the right speaker.  
    '        <li>They can be cross faded with Channel::setPan.<br>
    '        <li>Multichannel sounds have each sound channel played on each speaker at unity.<br>
    '        <li>Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.<br>
    '        <li>Channel::setSpeakerMix works but only front left and right parameters are used, the rest are ignored.<br>
    '        <br>
    '        FMOD_SPEAKERMODE_QUAD<br>
    '        ------------------------<br>
    '        This mode is for 4 speaker arrangements that have a front left, front right, rear left and a rear right speaker.<br>
    '        <li>Mono sounds default to an even distribution between front left and front right.  They can be panned with Channel::setPan.<br>
    '        <li>Stereo sounds default to the left sound channel played on the front left, and the right sound channel played on the front right.<br>
    '        <li>They can be cross faded with Channel::setPan.<br>
    '        <li>Multichannel sounds default to all of their sound channels being played on each speaker in order of input.<br>
    '        <li>Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.<br>
    '        <li>Channel::setSpeakerMix works but side left, side right, center and lfe are ignored.<br>
    '        <br>
    '        FMOD_SPEAKERMODE_SURROUND<br>
    '        ------------------------<br>
    '        This mode is for 4 speaker arrangements that have a front left, front right, front center and a rear center.<br>
    '        <li>Mono sounds default to the center speaker.  They can be panned with Channel::setPan.<br>
    '        <li>Stereo sounds default to the left sound channel played on the front left, and the right sound channel played on the front right.  
    '        <li>They can be cross faded with Channel::setPan.<br>
    '        <li>Multichannel sounds default to all of their sound channels being played on each speaker in order of input.<br>
    '        <li>Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.<br>
    '        <li>Channel::setSpeakerMix works but side left, side right and lfe are ignored, and rear left / rear right are averaged into the rear speaker.<br>
    '        <br>
    '        FMOD_SPEAKERMODE_5POINT1<br>
    '        ------------------------<br>
    '        This mode is for 5.1 speaker arrangements that have a left/right/center/rear left/rear right and a subwoofer speaker.<br>
    '        <li>Mono sounds default to the center speaker.  They can be panned with Channel::setPan.<br>
    '        <li>Stereo sounds default to the left sound channel played on the front left, and the right sound channel played on the front right.  
    '        <li>They can be cross faded with Channel::setPan.<br>
    '        <li>Multichannel sounds default to all of their sound channels being played on each speaker in order of input.  
    '        <li>Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.<br>
    '        <li>Channel::setSpeakerMix works but side left / side right are ignored.<br>
    '        <br>
    '        FMOD_SPEAKERMODE_7POINT1<br>
    '        ------------------------<br>
    '        This mode is for 7.1 speaker arrangements that have a left/right/center/rear left/rear right/side left/side right 
    '        and a subwoofer speaker.<br>
    '        <li>Mono sounds default to the center speaker.  They can be panned with Channel::setPan.<br>
    '        <li>Stereo sounds default to the left sound channel played on the front left, and the right sound channel played on the front right.  
    '        <li>They can be cross faded with Channel::setPan.<br>
    '        <li>Multichannel sounds default to all of their sound channels being played on each speaker in order of input.  
    '        <li>Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.<br>
    '        <li>Channel::setSpeakerMix works and every parameter is used to set the balance of a sound in any speaker.<br>
    '        <br>
    '        FMOD_SPEAKERMODE_SRS5_1_MATRIX<br>
    '        ------------------------------------------------------<br>
    '		This mode is for mono, stereo, 5.1 and 7.1 speaker arrangements, as it is backwards and forwards compatible with 
    '		stereo, but to get a surround effect a SRS 5.1, Prologic or Prologic 2 hardware decoder / amplifier is needed.<br>
    '		Pan behavior is the same as FMOD_SPEAKERMODE_5POINT1.<br>
    '		<br>
    '		If this function is called the numoutputchannels setting in System::setSoftwareFormat is overwritten.<br>
    '		<br>
    '		Output rate must be 44100, 48000 or 96000 for this to work otherwise FMOD_ERR_OUTPUT_INIT will be returned.<br>
    '    
    '        FMOD_SPEAKERMODE_MYEARS<br>
    '        ------------------------------------------------------<br>
    '        This mode is for headphones.  This will attempt to load a MyEars profile (see myears.net.au) and use it to generate
    '        surround sound on headphones using a personalized HRTF algorithm, for realistic 3d sound.<br>
    '        Pan behavior is the same as FMOD_SPEAKERMODE_7POINT1.<br>
    '        MyEars speaker mode will automatically be set if the speakermode is FMOD_SPEAKERMODE_STEREO and the MyEars profile exists.<br>
    '        If this mode is set explicitly, FMOD_INIT_DISABLE_MYEARS_AUTODETECT has no effect.<br>
    '        If this mode is set explicitly and the MyEars profile does not exist, FMOD_ERR_OUTPUT_DRIVERCALL will be returned.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]
    '        System::setSpeakerMode
    '        System::getSpeakerMode
    '        System::getDriverCaps
    '        Channel::setSpeakerLevels
    '    ]
    '    

    Public Enum SPEAKERMODE As Integer
        RAW
        ' There is no specific speakermode.  Sound channels are mapped in order of input to output.  See remarks for more information. 
        MONO
        ' The speakers are monaural. 
        STEREO
        ' The speakers are stereo (DEFAULT). 
        QUAD
        ' 4 speaker setup.  This includes front left, front right, rear left, rear right.  
        SURROUND
        ' 4 speaker setup.  This includes front left, front right, center, rear center (rear left/rear right are averaged). 
        _5POINT1
        ' 5.1 speaker setup.  This includes front left, front right, center, rear left, rear right and a subwoofer. 
        _7POINT1
        ' 7.1 speaker setup.  This includes front left, front right, center, rear left, rear right, side left, side right and a subwoofer. 

        SRS5_1_MATRIX
        ' Stereo compatible output, embedded with surround information. SRS 5.1/Prologic/Prologic2 decoders will split the signal into a 5.1 speaker set-up or SRS virtual surround will decode into a 2-speaker/headphone setup.  See remarks about limitations. 
        MYEARS
        ' Stereo output, but data is encoded using personalized HRTF algorithms.  See myears.net.au 

        MAX
        ' Maximum number of speaker modes supported. 
    End Enum


    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]   
    '        These are speaker types defined for use with the Channel::setSpeakerLevels command.
    '        It can also be used for speaker placement in the System::setSpeakerPosition command.
    '
    '        [REMARKS]
    '        If you are using FMOD_SPEAKERMODE_RAW and speaker assignments are meaningless, just cast a raw integer value to this type.<br>
    '        For example (FMOD_SPEAKER)7 would use the 7th speaker (also the same as FMOD_SPEAKER_SIDE_RIGHT).<br>
    '        Values higher than this can be used if an output system has more than 8 speaker types / output channels.  15 is the current maximum.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]
    '        FMOD_SPEAKERMODE
    '        Channel::setSpeakerLevels
    '        Channel::getSpeakerLevels
    '        System::setSpeakerPosition
    '        System::getSpeakerPosition
    '    ]
    '    

    Public Enum SPEAKER As Integer
        FRONT_LEFT
        FRONT_RIGHT
        FRONT_CENTER
        LOW_FREQUENCY
        BACK_LEFT
        BACK_RIGHT
        SIDE_LEFT
        SIDE_RIGHT

        MAX
        ' Maximum number of speaker types supported. 
        MONO = FRONT_LEFT
        ' For use with FMOD_SPEAKERMODE_MONO and Channel::SetSpeakerLevels.  Mapped to same value as FMOD_SPEAKER_FRONT_LEFT. 
        NULL = MAX
        ' A non speaker.  Use this to send. 
        SBL = SIDE_LEFT
        ' For use with FMOD_SPEAKERMODE_7POINT1 on PS3 where the extra speakers are surround back inside of side speakers. 
        SBR = SIDE_RIGHT
        ' For use with FMOD_SPEAKERMODE_7POINT1 on PS3 where the extra speakers are surround back inside of side speakers. 
    End Enum


    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]   
    '        These are plugin types defined for use with the System::getNumPlugins / System_GetNumPlugins, 
    '        System::getPluginInfo / System_GetPluginInfo and System::unloadPlugin / System_UnloadPlugin functions.
    '
    '        [REMARKS]
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]
    '        System::getNumPlugins
    '        System::getPluginInfo
    '        System::unloadPlugin
    '    ]
    '    

    Public Enum PLUGINTYPE As Integer
        OUTPUT
        ' The plugin type is an output module.  FMOD mixed audio will play through one of these devices 
        CODEC
        ' The plugin type is a file format codec.  FMOD will use these codecs to load file formats for playback. 
        DSP
        ' The plugin type is a DSP unit.  FMOD will use these plugins as part of its DSP network to apply effects to output or generate sound in realtime. 
    End Enum


    '
    '    [ENUM] 
    '    [
    '        [DESCRIPTION]   
    '        Initialization flags.  Use them with System::init in the flags parameter to change various behaviour.  
    '
    '        [REMARKS]
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]
    '        System::init
    '    ]
    '    

    Public Enum INITFLAGS As Integer
        NORMAL = &H0
        ' All platforms - Initialize normally 
        STREAM_FROM_UPDATE = &H1
        ' All platforms - No stream thread is created internally.  Streams are driven from System::update.  Mainly used with non-realtime outputs. 
        _3D_RIGHTHANDED = &H2
        ' All platforms - FMOD will treat +X as left, +Y as up and +Z as forwards. 
        SOFTWARE_DISABLE = &H4
        ' All platforms - Disable software mixer to save memory.  Anything created with FMOD_SOFTWARE will fail and DSP will not work. 
        OCCLUSION_LOWPASS = &H8
        ' All platforms - All FMOD_SOFTWARE (and FMOD_HARDWARE on 3DS and NGP) with FMOD_3D based voices will add a software lowpass filter effect into the DSP chain which is automatically used when Channel::set3DOcclusion is used or the geometry API. 
        HRTF_LOWPASS = &H10
        ' All platforms - All FMOD_SOFTWARE (and FMOD_HARDWARE on 3DS and NGP) with FMOD_3D based voices will add a software lowpass filter effect into the DSP chain which causes sounds to sound duller when the sound goes behind the listener.  Use System::setAdvancedSettings to adjust cutoff frequency. 
        DISTANCE_FILTERING = &H200
        ' All platforms - All FMOD_SOFTWARE with FMOD_3D based voices will add a software lowpass and highpass filter effect into the DSP chain which will act as a distance-automated bandpass filter. Use System::setAdvancedSettings to adjust the center frequency. 
        SOFTWARE_REVERB_LOWMEM = &H40
        ' All platforms - SFX reverb is run using 22/24khz delay buffers, halving the memory required. 
        ENABLE_PROFILE = &H20
        ' All platforms - Enable TCP/IP based host which allows "DSPNet Listener.exe" to connect to it, and view the DSP dataflow network graph in real-time. 
        VOL0_BECOMES_VIRTUAL = &H80
        ' All platforms - Any sounds that are 0 volume will go virtual and not be processed except for having their positions updated virtually.  Use System::setAdvancedSettings to adjust what volume besides zero to switch to virtual at. 
        WASAPI_EXCLUSIVE = &H100
        ' Win32 Vista only - for WASAPI output - Enable exclusive access to hardware, lower latency at the expense of excluding other applications from accessing the audio hardware. 
        DISABLEDOLBY = &H100000
        ' Wii / 3DS - Disable Dolby Pro Logic surround. Speakermode will be set to STEREO even if user has selected surround in the system settings. 
        WII_DISABLEDOLBY = &H100000
        ' Wii only - Disable Dolby Pro Logic surround. Speakermode will be set to STEREO even if user has selected surround in the Wii system settings. 
        _360_MUSICMUTENOTPAUSE = &H200000
        ' Xbox 360 only - The "music" channelgroup which by default pauses when custom 360 dashboard music is played, can be changed to mute (therefore continues playing) instead of pausing, by using this flag. 
        SYNCMIXERWITHUPDATE = &H400000
        ' Win32/Wii/PS3/Xbox 360 - FMOD Mixer thread is woken up to do a mix when System::update is called rather than waking periodically on its own timer. 
        DTS_NEURALSURROUND = &H2000000
        ' Win32/Mac/Linux - Use DTS Neural surround downmixing from 7.1 if speakermode set to FMOD_SPEAKERMODE_STEREO or FMOD_SPEAKERMODE_5POINT1.  Internal DSP structure will be set to 7.1. 
        GEOMETRY_USECLOSEST = &H4000000
        ' All platforms - With the geometry engine, only process the closest polygon rather than accumulating all polygons the sound to listener line intersects. 
        DISABLE_MYEARS_AUTODETECT = &H8000000
        ' Win32 - Disables automatic setting of FMOD_SPEAKERMODE_STEREO to FMOD_SPEAKERMODE_MYEARS if the MyEars profile exists on the PC.  MyEars is HRTF 7.1 downmixing through headphones. 
    End Enum


    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]   
    '        These definitions describe the type of song being played.
    '
    '        [REMARKS]
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]      
    '        Sound::getFormat
    '    ]
    '    

    Public Enum SOUND_TYPE
        UNKNOWN
        ' 3rd party / unknown plugin format. 
        AIFF
        ' AIFF. 
        ASF
        ' Microsoft Advanced Systems Format (ie WMA/ASF/WMV). 
        AT3
        ' Sony ATRAC 3 format 
        CDDA
        ' Digital CD audio. 
        DLS
        ' Sound font / downloadable sound bank. 
        FLAC
        ' FLAC lossless codec. 
        FSB
        ' FMOD Sample Bank. 
        GCADPCM
        ' GameCube ADPCM 
        IT
        ' Impulse Tracker. 
        MIDI
        ' MIDI. 
        [MOD]
        ' Protracker / Fasttracker MOD. 
        MPEG
        ' MP2/MP3 MPEG. 
        OGGVORBIS
        ' Ogg vorbis. 
        PLAYLIST
        ' Information only from ASX/PLS/M3U/WAX playlists 
        RAW
        ' Raw PCM data. 
        S3M
        ' ScreamTracker 3. 
        SF2
        ' Sound font 2 format. 
        USER
        ' User created sound. 
        WAV
        ' Microsoft WAV. 
        XM
        ' FastTracker 2 XM. 
        XMA
        ' Xbox360 XMA 
        VAG
        ' PlayStation Portable adpcm VAG format. 
        AUDIOQUEUE
        ' iPhone hardware decoder, supports AAC, ALAC and MP3. 
        XWMA
        ' Xbox360 XWMA 
        BCWAV
        ' 3DS BCWAV container format for DSP ADPCM and PCM 
        AT9
        ' NGP ATRAC 9 format 
        VORBIS
        ' Raw vorbis 
    End Enum


    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]   
    '        These definitions describe the native format of the hardware or software buffer that will be used.
    '
    '        [REMARKS]
    '        This is the format the native hardware or software buffer will be or is created in.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]
    '        System::createSoundEx
    '        Sound::getFormat
    '    ]
    '    

    Public Enum SOUND_FORMAT As Integer
        NONE
        ' Unitialized / unknown 
        PCM8
        ' 8bit integer PCM data 
        PCM16
        ' 16bit integer PCM data  
        PCM24
        ' 24bit integer PCM data  
        PCM32
        ' 32bit integer PCM data  
        PCMFLOAT
        ' 32bit floating point PCM data  
        GCADPCM
        ' Compressed GameCube DSP data 
        IMAADPCM
        ' Compressed XBox ADPCM data 
        VAG
        ' Compressed PlayStation 2 ADPCM data 
        HEVAG
        ' Compressed NGP ADPCM data. 
        XMA
        ' Compressed Xbox360 data. 
        MPEG
        ' Compressed MPEG layer 2 or 3 data. 
        MAX
        ' Maximum number of sound formats supported. 
        CELT
        ' Compressed CELT data. 
        AT9
        ' Compressed ATRAC9 data. 
        XWMA
        ' Compressed Xbox360 xWMA data. 
        VORBIS
        ' Compressed Vorbis data. 
    End Enum


    '
    '    [DEFINE]
    '    [
    '        [NAME] 
    '        FMOD_MODE
    '
    '        [DESCRIPTION]   
    '        Sound description bitfields, bitwise OR them together for loading and describing sounds.
    '
    '        [REMARKS]
    '        By default a sound will open as a static sound that is decompressed fully into memory.<br>
    '        To have a sound stream instead, use FMOD_CREATESTREAM.<br>
    '        Some opening modes (ie FMOD_OPENUSER, FMOD_OPENMEMORY, FMOD_OPENRAW) will need extra information.<br>
    '        This can be provided using the FMOD_CREATESOUNDEXINFO structure.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]
    '        System::createSound
    '        System::createStream
    '        Sound::setMode
    '        Sound::getMode
    '        Channel::setMode
    '        Channel::getMode
    '        Sound::set3DCustomRolloff
    '        Channel::set3DCustomRolloff
    '    ]
    '    

    Public Enum MODE As UInteger
        [DEFAULT] = &H0
        ' FMOD_DEFAULT is a default sound type.  Equivalent to all the defaults listed below.  FMOD_LOOP_OFF, FMOD_2D, FMOD_HARDWARE. 
        LOOP_OFF = &H1
        ' For non looping sounds. (default).  Overrides FMOD_LOOP_NORMAL / FMOD_LOOP_BIDI. 
        LOOP_NORMAL = &H2
        ' For forward looping sounds. 
        LOOP_BIDI = &H4
        ' For bidirectional looping sounds. (only works on software mixed static sounds). 
        _2D = &H8
        ' Ignores any 3d processing. (default). 
        _3D = &H10
        ' Makes the sound positionable in 3D.  Overrides FMOD_2D. 
        HARDWARE = &H20
        ' Attempts to make sounds use hardware acceleration. (default). 
        SOFTWARE = &H40
        ' Makes sound reside in software.  Overrides FMOD_HARDWARE.  Use this for FFT, DSP, 2D multi speaker support and other software related features. 
        CREATESTREAM = &H80
        ' Decompress at runtime, streaming from the source provided (standard stream).  Overrides FMOD_CREATESAMPLE. 
        CREATESAMPLE = &H100
        ' Decompress at loadtime, decompressing or decoding whole file into memory as the target sample format. (standard sample). 
        CREATECOMPRESSEDSAMPLE = &H200
        ' Load MP2, MP3, IMAADPCM or XMA into memory and leave it compressed.  During playback the FMOD software mixer will decode it in realtime as a 'compressed sample'.  Can only be used in combination with FMOD_SOFTWARE. 
        OPENUSER = &H400
        ' Opens a user created static sample or stream. Use FMOD_CREATESOUNDEXINFO to specify format and/or read callbacks.  If a user created 'sample' is created with no read callback, the sample will be empty.  Use FMOD_Sound_Lock and FMOD_Sound_Unlock to place sound data into the sound if this is the case. 
        OPENMEMORY = &H800
        ' "name_or_data" will be interpreted as a pointer to memory instead of filename for creating sounds. 
        OPENMEMORY_POINT = &H10000000
        ' "name_or_data" will be interpreted as a pointer to memory instead of filename for creating sounds.  Use FMOD_CREATESOUNDEXINFO to specify length.  This differs to FMOD_OPENMEMORY in that it uses the memory as is, without duplicating the memory into its own buffers.  FMOD_SOFTWARE only.  Doesn't work with FMOD_HARDWARE, as sound hardware cannot access main ram on a lot of platforms.  Cannot be freed after open, only after Sound::release.   Will not work if the data is compressed and FMOD_CREATECOMPRESSEDSAMPLE is not used. 
        OPENRAW = &H1000
        ' Will ignore file format and treat as raw pcm.  User may need to declare if data is FMOD_SIGNED or FMOD_UNSIGNED 
        OPENONLY = &H2000
        ' Just open the file, dont prebuffer or read.  Good for fast opens for info, or when sound::readData is to be used. 
        ACCURATETIME = &H4000
        ' For FMOD_CreateSound - for accurate FMOD_Sound_GetLength / FMOD_Channel_SetPosition on VBR MP3, AAC and MOD/S3M/XM/IT/MIDI files.  Scans file first, so takes longer to open. FMOD_OPENONLY does not affect this. 
        MPEGSEARCH = &H8000
        ' For corrupted / bad MP3 files.  This will search all the way through the file until it hits a valid MPEG header.  Normally only searches for 4k. 
        NONBLOCKING = &H10000
        ' For opening sounds and getting streamed subsounds (seeking) asyncronously.  Use Sound::getOpenState to poll the state of the sound as it opens or retrieves the subsound in the background. 
        UNIQUE = &H20000
        ' Unique sound, can only be played one at a time 
        _3D_HEADRELATIVE = &H40000
        ' Make the sound's position, velocity and orientation relative to the listener. 
        _3D_WORLDRELATIVE = &H80000
        ' Make the sound's position, velocity and orientation absolute (relative to the world). (DEFAULT) 
        _3D_INVERSEROLLOFF = &H100000
        ' This sound will follow the inverse rolloff model where mindistance = full volume, maxdistance = where sound stops attenuating, and rolloff is fixed according to the global rolloff factor.  (DEFAULT) 
        _3D_LINEARSQUAREROLLOFF = &H400000
        ' This sound will follow a linear-square rolloff model where mindistance = full volume, maxdistance = silence.  Rolloffscale is ignored. 
        _3D_LOGROLLOFF = &H100000
        ' This sound will follow the standard logarithmic rolloff model where mindistance = full volume, maxdistance = where sound stops attenuating, and rolloff is fixed according to the global rolloff factor.  (default) 
        _3D_LINEARROLLOFF = &H200000
        ' This sound will follow a linear rolloff model where mindistance = full volume, maxdistance = silence.  
        _3D_CUSTOMROLLOFF = &H4000000
        ' This sound will follow a rolloff model defined by Sound::set3DCustomRolloff / Channel::set3DCustomRolloff.  
        _3D_IGNOREGEOMETRY = &H40000000
        ' Is not affect by geometry occlusion.  If not specified in Sound::setMode, or Channel::setMode, the flag is cleared and it is affected by geometry again. 
        CDDA_FORCEASPI = &H400000
        ' For CDDA sounds only - use ASPI instead of NTSCSI to access the specified CD/DVD device. 
        CDDA_JITTERCORRECT = &H800000
        ' For CDDA sounds only - perform jitter correction. Jitter correction helps produce a more accurate CDDA stream at the cost of more CPU time. 
        UNICODE = &H1000000
        ' Filename is double-byte unicode. 
        IGNORETAGS = &H2000000
        ' Skips id3v2/asf/etc tag checks when opening a sound, to reduce seek/read overhead when opening files (helps with CD performance). 
        LOWMEM = &H8000000
        ' Removes some features from samples to give a lower memory overhead, like Sound::getName. 
        LOADSECONDARYRAM = &H20000000
        ' Load sound into the secondary RAM of supported platform.  On PS3, sounds will be loaded into RSX/VRAM. 
        VIRTUAL_PLAYFROMSTART = &H80000000UI
        ' For sounds that start virtual (due to being quiet or low importance), instead of swapping back to audible, and playing at the correct offset according to time, this flag makes the sound play from the start. 
    End Enum


    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]   
    '        These values describe what state a sound is in after NONBLOCKING has been used to open it.
    '
    '        [REMARKS]    
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]
    '        Sound::getOpenState
    '        MODE
    '    ]
    '    

    Public Enum OPENSTATE As Integer
        READY = 0
        ' Opened and ready to play 
        LOADING
        ' Initial load in progress 
        [ERROR]
        ' Failed to open - file not found, out of memory etc.  See return value of Sound::getOpenState for what happened. 
        CONNECTING
        ' Connecting to remote host (internet sounds only) 
        BUFFERING
        ' Buffering data 
        SEEKING
        ' Seeking to subsound and re-flushing stream buffer. 
        PLAYING
        ' Ready and playing, but not possible to release at this time without stalling the main thread. 
        SETPOSITION
        ' Seeking within a stream to a different position. 
    End Enum


    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]   
    '        These flags are used with SoundGroup::setMaxAudibleBehavior to determine what happens when more sounds 
    '        are played than are specified with SoundGroup::setMaxAudible.
    '
    '        [REMARKS]
    '        When using FMOD_SOUNDGROUP_BEHAVIOR_MUTE, SoundGroup::setMuteFadeSpeed can be used to stop a sudden transition.  
    '        Instead, the time specified will be used to cross fade between the sounds that go silent and the ones that become audible.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]      
    '        SoundGroup::setMaxAudibleBehavior
    '        SoundGroup::getMaxAudibleBehavior
    '        SoundGroup::setMaxAudible
    '        SoundGroup::getMaxAudible
    '        SoundGroup::setMuteFadeSpeed
    '        SoundGroup::getMuteFadeSpeed
    '    ]
    '    

    Public Enum SOUNDGROUP_BEHAVIOR As Integer
        BEHAVIOR_FAIL
        ' Any sound played that puts the sound count over the SoundGroup::setMaxAudible setting, will simply fail during System::playSound. 
        BEHAVIOR_MUTE
        ' Any sound played that puts the sound count over the SoundGroup::setMaxAudible setting, will be silent, then if another sound in the group stops the sound that was silent before becomes audible again. 
        BEHAVIOR_STEALLOWEST
        ' Any sound played that puts the sound count over the SoundGroup::setMaxAudible setting, will steal the quietest / least important sound playing in the group. 
    End Enum

    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]   
    '        These callback types are used with System::setCallback.
    '
    '        [REMARKS]
    '        Each callback has commanddata parameters passed as int unique to the type of callback.<br>
    '        See reference to FMOD_SYSTEM_CALLBACK to determine what they might mean for each type of callback.<br>
    '        <br>
    '        <b>Note!</b>  Currently the user must call System::update for these callbacks to trigger!
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]      
    '        System::setCallback
    '        FMOD_SYSTEM_CALLBACK
    '        System::update
    '    ]
    '    

    Public Enum SYSTEM_CALLBACKTYPE As Integer
        DEVICELISTCHANGED
        ' Called when the enumerated list of devices has changed. 
        DEVICELOST
        ' Called from System::update when an output device has been lost due to control panel parameter changes and FMOD cannot automatically recover. 
        MEMORYALLOCATIONFAILED
        ' Called directly when a memory allocation fails somewhere in FMOD. 
        THREADCREATED
        ' Called directly when a thread is created. 
        BADDSPCONNECTION
        ' Called when a bad connection was made with DSP::addInput. Usually called from mixer thread because that is where the connections are made.  
        BADDSPLEVEL
        ' Called when too many effects were added exceeding the maximum tree depth of 128.  This is most likely caused by accidentally adding too many DSP effects. Usually called from mixer thread because that is where the connections are made.  

        MAX
        ' Maximum number of callback types supported. 
    End Enum

    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]   
    '        These callback types are used with Channel::setCallback.
    '
    '        [REMARKS]
    '        Each callback has commanddata parameters passed int unique to the type of callback.
    '        See reference to FMOD_CHANNEL_CALLBACK to determine what they might mean for each type of callback.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]      
    '        Channel::setCallback
    '        FMOD_CHANNEL_CALLBACK
    '    ]
    '    

    Public Enum CHANNEL_CALLBACKTYPE As Integer
        [END]
        ' Called when a sound ends. 
        VIRTUALVOICE
        ' Called when a voice is swapped out or swapped in. 
        SYNCPOINT
        ' Called when a syncpoint is encountered.  Can be from wav file markers. 
        OCCLUSION
        ' Called when the channel has its geometry occlusion value calculated.  Can be used to clamp or change the value. 

        MAX
    End Enum


    ' 
    '        FMOD Callbacks
    '    

    Public Delegate Function SYSTEM_CALLBACK(ByVal systemraw As IntPtr, ByVal type As SYSTEM_CALLBACKTYPE, ByVal commanddata1 As IntPtr, ByVal commanddata2 As IntPtr) As RESULT

    Public Delegate Function CHANNEL_CALLBACK(ByVal channelraw As IntPtr, ByVal type As CHANNEL_CALLBACKTYPE, ByVal commanddata1 As IntPtr, ByVal commanddata2 As IntPtr) As RESULT

    Public Delegate Function SOUND_NONBLOCKCALLBACK(ByVal soundraw As IntPtr, ByVal result As RESULT) As RESULT
    Public Delegate Function SOUND_PCMREADCALLBACK(ByVal soundraw As IntPtr, ByVal data As IntPtr, ByVal datalen As UInteger) As RESULT
    Public Delegate Function SOUND_PCMSETPOSCALLBACK(ByVal soundraw As IntPtr, ByVal subsound As Integer, ByVal position As UInteger, ByVal postype As TIMEUNIT) As RESULT

    Public Delegate Function FILE_OPENCALLBACK(<MarshalAs(UnmanagedType.LPWStr)> ByVal name As String, ByVal unicode As Integer, ByRef filesize As UInteger, ByRef handle As IntPtr, ByRef userdata As IntPtr) As RESULT
    Public Delegate Function FILE_CLOSECALLBACK(ByVal handle As IntPtr, ByVal userdata As IntPtr) As RESULT
    Public Delegate Function FILE_READCALLBACK(ByVal handle As IntPtr, ByVal buffer As IntPtr, ByVal sizebytes As UInteger, ByRef bytesread As UInteger, ByVal userdata As IntPtr) As RESULT
    Public Delegate Function FILE_SEEKCALLBACK(ByVal handle As IntPtr, ByVal pos As Integer, ByVal userdata As IntPtr) As RESULT
    Public Delegate Function FILE_ASYNCREADCALLBACK(ByVal handle As IntPtr, ByVal info As IntPtr, ByVal userdata As IntPtr) As RESULT
    Public Delegate Function FILE_ASYNCCANCELCALLBACK(ByVal handle As IntPtr, ByVal userdata As IntPtr) As RESULT

    Public Delegate Function CB_3D_ROLLOFFCALLBACK(ByVal channelraw As IntPtr, ByVal distance As Single) As Single

    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]   
    '        List of windowing methods used in spectrum analysis to reduce leakage / transient signals intefering with the analysis.
    '        This is a problem with analysis of continuous signals that only have a small portion of the signal sample (the fft window size).
    '        Windowing the signal with a curve or triangle tapers the sides of the fft window to help alleviate this problem.
    '
    '        [REMARKS]
    '        Cyclic signals such as a sine wave that repeat their cycle in a multiple of the window size do not need windowing.
    '        I.e. If the sine wave repeats every 1024, 512, 256 etc samples and the FMOD fft window is 1024, then the signal would not need windowing.
    '        Not windowing is the same as FMOD_DSP_FFT_WINDOW_RECT, which is the default.
    '        If the cycle of the signal (ie the sine wave) is not a multiple of the window size, it will cause frequency abnormalities, so a different windowing method is needed.
    '        <exclude>
    '        
    '        FMOD_DSP_FFT_WINDOW_RECT.
    '        <img src = "rectangle.gif"></img>
    '        
    '        FMOD_DSP_FFT_WINDOW_TRIANGLE.
    '        <img src = "triangle.gif"></img>
    '        
    '        FMOD_DSP_FFT_WINDOW_HAMMING.
    '        <img src = "hamming.gif"></img>
    '        
    '        FMOD_DSP_FFT_WINDOW_HANNING.
    '        <img src = "hanning.gif"></img>
    '        
    '        FMOD_DSP_FFT_WINDOW_BLACKMAN.
    '        <img src = "blackman.gif"></img>
    '        
    '        FMOD_DSP_FFT_WINDOW_BLACKMANHARRIS.
    '        <img src = "blackmanharris.gif"></img>
    '        </exclude>
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]      
    '        System::getSpectrum
    '        Channel::getSpectrum
    '    ]
    '    

    Public Enum DSP_FFT_WINDOW As Integer
        RECT
        ' w[n] = 1.0                                                                                            
        TRIANGLE
        ' w[n] = TRI(2n/N)                                                                                      
        HAMMING
        ' w[n] = 0.54 - (0.46 * COS(n/N) )                                                                      
        HANNING
        ' w[n] = 0.5 *  (1.0  - COS(n/N) )                                                                      
        BLACKMAN
        ' w[n] = 0.42 - (0.5  * COS(n/N) ) + (0.08 * COS(2.0 * n/N) )                                           
        BLACKMANHARRIS
        ' w[n] = 0.35875 - (0.48829 * COS(1.0 * n/N)) + (0.14128 * COS(2.0 * n/N)) - (0.01168 * COS(3.0 * n/N)) 

        MAX
    End Enum


    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]   
    '        List of interpolation types that the FMOD Ex software mixer supports.  
    '
    '        [REMARKS]
    '        The default resampler type is FMOD_DSP_RESAMPLER_LINEAR.<br>
    '        Use System::setSoftwareFormat to tell FMOD the resampling quality you require for FMOD_SOFTWARE based sounds.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]      
    '        System::setSoftwareFormat
    '        System::getSoftwareFormat
    '    ]
    '    

    Public Enum DSP_RESAMPLER As Integer
        NOINTERP
        ' No interpolation.  High frequency aliasing hiss will be audible depending on the sample rate of the sound. 
        LINEAR
        ' Linear interpolation (default method).  Fast and good quality, causes very slight lowpass effect on low frequency sounds. 
        CUBIC
        ' Cubic interpolation.  Slower than linear interpolation but better quality. 
        SPLINE
        ' 5 point spline interpolation.  Slowest resampling method but best quality. 

        MAX
        ' Maximum number of resample methods supported. 
    End Enum


    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]   
    '        List of tag types that could be stored within a sound.  These include id3 tags, metadata from netstreams and vorbis/asf data.
    '
    '        [REMARKS]
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]      
    '        Sound::getTag
    '    ]
    '    

    Public Enum TAGTYPE As Integer
        UNKNOWN = 0
        ID3V1
        ID3V2
        VORBISCOMMENT
        SHOUTCAST
        ICECAST
        ASF
        MIDI
        PLAYLIST
        FMOD
        USER
    End Enum


    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]   
    '        List of data types that can be returned by Sound::getTag
    '
    '        [REMARKS]
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]      
    '        Sound::getTag
    '    ]
    '    

    Public Enum TAGDATATYPE As Integer
        BINARY = 0
        INT
        FLOAT
        [STRING]
        STRING_UTF16
        STRING_UTF16BE
        STRING_UTF8
        CDTOC
    End Enum

    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]   
    '        Types of delay that can be used with Channel::setDelay / Channel::getDelay.
    '
    '        [REMARKS]
    '        If you haven't called Channel::setDelay yet, if you call Channel::getDelay with FMOD_DELAYTYPE_DSPCLOCK_START it will return the 
    '        equivalent global DSP clock value to determine when a channel started, so that you can use it for other channels to sync against.<br>
    '        <br>
    '        Use System::getDSPClock to also get the current dspclock time, a base for future calls to Channel::setDelay.<br>
    '        <br>
    '        Use FMOD_64BIT_ADD or FMOD_64BIT_SUB to add a hi/lo combination together and cope with wraparound.
    '        <br>
    '        If FMOD_DELAYTYPE_END_MS is specified, the value is not treated as a 64 bit number, just the delayhi value is used and it is treated as milliseconds.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]      
    '        Channel::setDelay
    '        Channel::getDelay
    '        System::getDSPClock
    '    ]
    '    

    Public Enum DELAYTYPE As Integer
        END_MS
        ' Delay at the end of the sound in milliseconds.  Use delayhi only.   Channel::isPlaying will remain true until this delay has passed even though the sound itself has stopped playing.
        DSPCLOCK_START
        ' Time the sound started if Channel::getDelay is used, or if Channel::setDelay is used, the sound will delay playing until this exact tick. 
        DSPCLOCK_END
        ' Time the sound should end. If this is non-zero, the channel will go silent at this exact tick. 
        DSPCLOCK_PAUSE
        ' Time the sound should pause. If this is non-zero, the channel will pause at this exact tick. 

        MAX
        ' Maximum number of tag datatypes supported. 
    End Enum

    Public Class DELAYTYPE_UTILITY
        Private Sub FMOD_64BIT_ADD(ByRef hi1 As UInteger, ByRef lo1 As UInteger, ByVal hi2 As UInteger, ByVal lo2 As UInteger)
            hi1 += CUInt((hi2) + (If((((lo1) + (lo2)) < (lo1)), 1, 0)))
            lo1 += (lo2)
        End Sub

        Private Sub FMOD_64BIT_SUB(ByRef hi1 As UInteger, ByRef lo1 As UInteger, ByVal hi2 As UInteger, ByVal lo2 As UInteger)
            hi1 -= CUInt((hi2) + (If((((lo1) - (lo2)) > (lo1)), 1, 0)))
            lo1 -= (lo2)
        End Sub
    End Class


    '
    '    [STRUCTURE] 
    '    [
    '        [DESCRIPTION]   
    '        Structure describing a piece of tag data.
    '
    '        [REMARKS]
    '        Members marked with [in] mean the user sets the value before passing it to the function.
    '        Members marked with [out] mean FMOD sets the value to be used after the function exits.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]      
    '        Sound::getTag
    '        TAGTYPE
    '        TAGDATATYPE
    '    ]
    '    

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure TAG
        Public type As TAGTYPE
        ' [out] The type of this tag. 
        Public datatype As TAGDATATYPE
        ' [out] The type of data that this tag contains 
        Public namePtr As IntPtr
        ' [out] The name of this tag i.e. "TITLE", "ARTIST" etc. 
        Public data As IntPtr
        ' [out] Pointer to the tag data - its format is determined by the datatype member 
        Public datalen As UInteger
        ' [out] Length of the data contained in this tag 
        Public updated As Boolean
        ' [out] True if this tag has been updated since last being accessed with Sound::getTag 

        Public ReadOnly Property name() As String
            Get
                Return Marshal.PtrToStringAnsi(namePtr)
            End Get
        End Property
    End Structure


    '
    '    [STRUCTURE] 
    '    [
    '        [DESCRIPTION]   
    '        Structure describing a CD/DVD table of contents
    '
    '        [REMARKS]
    '        Members marked with [in] mean the user sets the value before passing it to the function.
    '        Members marked with [out] mean FMOD sets the value to be used after the function exits.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]      
    '        Sound::getTag
    '    ]
    '    

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure CDTOC
        Public numtracks As Integer
        ' [out] The number of tracks on the CD 
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=100)> _
        Public min As Integer()
        ' [out] The start offset of each track in minutes 
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=100)> _
        Public sec As Integer()
        ' [out] The start offset of each track in seconds 
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=100)> _
        Public frame As Integer()
        ' [out] The start offset of each track in frames 
    End Structure


    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]   
    '        List of time types that can be returned by Sound::getLength and used with Channel::setPosition or Channel::getPosition.
    '
    '        [REMARKS]
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]      
    '        Sound::getLength
    '        Channel::setPosition
    '        Channel::getPosition
    '    ]
    '    

    Public Enum TIMEUNIT
        MS = &H1
        ' Milliseconds. 
        PCM = &H2
        ' PCM Samples, related to milliseconds * samplerate / 1000. 
        PCMBYTES = &H4
        ' Bytes, related to PCM samples * channels * datawidth (ie 16bit = 2 bytes). 
        RAWBYTES = &H8
        ' Raw file bytes of (compressed) sound data (does not include headers).  Only used by Sound::getLength and Channel::getPosition. 
        PCMFRACTION = &H10
        ' Fractions of 1 PCM sample.  Unsigned int range 0 to 0xFFFFFFFF.  Used for sub-sample granularity for DSP purposes. 
        MODORDER = &H100
        ' MOD/S3M/XM/IT.  Order in a sequenced module format.  Use Sound::getFormat to determine the format. 
        MODROW = &H200
        ' MOD/S3M/XM/IT.  Current row in a sequenced module format.  Sound::getLength will return the number if rows in the currently playing or seeked to pattern. 
        MODPATTERN = &H400
        ' MOD/S3M/XM/IT.  Current pattern in a sequenced module format.  Sound::getLength will return the number of patterns in the song and Channel::getPosition will return the currently playing pattern. 
        SENTENCE_MS = &H10000
        ' Currently playing subsound in a sentence time in milliseconds. 
        SENTENCE_PCM = &H20000
        ' Currently playing subsound in a sentence time in PCM Samples, related to milliseconds * samplerate / 1000. 
        SENTENCE_PCMBYTES = &H40000
        ' Currently playing subsound in a sentence time in bytes, related to PCM samples * channels * datawidth (ie 16bit = 2 bytes). 
        SENTENCE = &H80000
        ' Currently playing sentence index according to the channel. 
        SENTENCE_SUBSOUND = &H100000
        ' Currently playing subsound index in a sentence. 
        BUFFERED = &H10000000
        ' Time value as seen by buffered stream.  This is always ahead of audible time, and is only used for processing. 
    End Enum


    '
    '    [ENUM]
    '    [
    '        [DESCRIPTION]
    '        When creating a multichannel sound, FMOD will pan them to their default speaker locations, for example a 6 channel sound will default to one channel per 5.1 output speaker.<br>
    '        Another example is a stereo sound.  It will default to left = front left, right = front right.<br>
    '        <br>
    '        This is for sounds that are not 'default'.  For example you might have a sound that is 6 channels but actually made up of 3 stereo pairs, that should all be located in front left, front right only.
    '
    '        [REMARKS]
    '        For full flexibility of speaker assignments, use Channel::setSpeakerLevels.  This functionality is cheaper, uses less memory and easier to use.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]
    '        FMOD_CREATESOUNDEXINFO
    '        Channel::setSpeakerLevels
    '    ]
    '    

    Public Enum SPEAKERMAPTYPE
        [DEFAULT]
        ' This is the default, and just means FMOD decides which speakers it puts the source channels. 
        ALLMONO
        ' This means the sound is made up of all mono sounds.  All voices will be panned to the front center by default in this case.  
        ALLSTEREO
        ' This means the sound is made up of all stereo sounds.  All voices will be panned to front left and front right alternating every second channel.  
        _51_PROTOOLS
        ' Map a 5.1 sound to use protools L C R Ls Rs LFE mapping.  Will return an error if not a 6 channel sound. 
    End Enum


    '
    '    [STRUCTURE] 
    '    [
    '        [DESCRIPTION]
    '        Use this structure with System::createSound when more control is needed over loading.
    '        The possible reasons to use this with System::createSound are:
    '        <li>Loading a file from memory.
    '        <li>Loading a file from within another larger (possibly wad/pak) file, by giving the loader an offset and length.
    '        <li>To create a user created / non file based sound.
    '        <li>To specify a starting subsound to seek to within a multi-sample sounds (ie FSB/DLS/SF2) when created as a stream.
    '        <li>To specify which subsounds to load for multi-sample sounds (ie FSB/DLS/SF2) so that memory is saved and only a subset is actually loaded/read from disk.
    '        <li>To specify 'piggyback' read and seek callbacks for capture of sound data as fmod reads and decodes it.  Useful for ripping decoded PCM data from sounds as they are loaded / played.
    '        <li>To specify a MIDI DLS/SF2 sample set file to load when opening a MIDI file.
    '        See below on what members to fill for each of the above types of sound you want to create.
    '
    '        [REMARKS]
    '        This structure is optional!  Specify 0 or NULL in System::createSound if you don't need it!
    '        
    '        Members marked with [in] mean the user sets the value before passing it to the function.
    '        Members marked with [out] mean FMOD sets the value to be used after the function exits.
    '        
    '        <u>Loading a file from memory.</u>
    '        <li>Create the sound using the FMOD_OPENMEMORY flag.
    '        <li>Mandantory.  Specify 'length' for the size of the memory block in bytes.
    '        <li>Other flags are optional.
    '        
    '        
    '        <u>Loading a file from within another larger (possibly wad/pak) file, by giving the loader an offset and length.</u>
    '        <li>Mandantory.  Specify 'fileoffset' and 'length'.
    '        <li>Other flags are optional.
    '        
    '        
    '        <u>To create a user created / non file based sound.</u>
    '        <li>Create the sound using the FMOD_OPENUSER flag.
    '        <li>Mandantory.  Specify 'defaultfrequency, 'numchannels' and 'format'.
    '        <li>Other flags are optional.
    '        
    '        
    '        <u>To specify a starting subsound to seek to and flush with, within a multi-sample stream (ie FSB/DLS/SF2).</u>
    '        
    '        <li>Mandantory.  Specify 'initialsubsound'.
    '        
    '        
    '        <u>To specify which subsounds to load for multi-sample sounds (ie FSB/DLS/SF2) so that memory is saved and only a subset is actually loaded/read from disk.</u>
    '        
    '        <li>Mandantory.  Specify 'inclusionlist' and 'inclusionlistnum'.
    '        
    '        
    '        <u>To specify 'piggyback' read and seek callbacks for capture of sound data as fmod reads and decodes it.  Useful for ripping decoded PCM data from sounds as they are loaded / played.</u>
    '        
    '        <li>Mandantory.  Specify 'pcmreadcallback' and 'pcmseekcallback'.
    '        
    '        
    '        <u>To specify a MIDI DLS/SF2 sample set file to load when opening a MIDI file.</u>
    '        
    '        <li>Mandantory.  Specify 'dlsname'.
    '        
    '        
    '        Setting the 'decodebuffersize' is for cpu intensive codecs that may be causing stuttering, not file intensive codecs (ie those from CD or netstreams) which are normally altered with System::setStreamBufferSize.  As an example of cpu intensive codecs, an mp3 file will take more cpu to decode than a PCM wav file.
    '        If you have a stuttering effect, then it is using more cpu than the decode buffer playback rate can keep up with.  Increasing the decode buffersize will most likely solve this problem.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]
    '        System::createSound
    '        System::setStreamBufferSize
    '        FMOD_MODE
    '    ]
    '    

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure CREATESOUNDEXINFO
        Public cbsize As Integer
        ' [in] Size of this structure.  This is used so the structure can be expanded in the future and still work on older versions of FMOD Ex. 
        Public length As UInteger
        ' [in] Optional. Specify 0 to ignore. Size in bytes of file to load, or sound to create (in this case only if FMOD_OPENUSER is used).  Required if loading from memory.  If 0 is specified, then it will use the size of the file (unless loading from memory then an error will be returned). 
        Public fileoffset As UInteger
        ' [in] Optional. Specify 0 to ignore. Offset from start of the file to start loading from.  This is useful for loading files from inside big data files. 
        Public numchannels As Integer
        ' [in] Optional. Specify 0 to ignore. Number of channels in a sound specified only if OPENUSER is used. 
        Public defaultfrequency As Integer
        ' [in] Optional. Specify 0 to ignore. Default frequency of sound in a sound specified only if OPENUSER is used.  Other formats use the frequency determined by the file format. 
        Public format As SOUND_FORMAT
        ' [in] Optional. Specify 0 or SOUND_FORMAT_NONE to ignore. Format of the sound specified only if OPENUSER is used.  Other formats use the format determined by the file format.   
        Public decodebuffersize As UInteger
        ' [in] Optional. Specify 0 to ignore. For streams.  This determines the size of the double buffer (in PCM samples) that a stream uses.  Use this for user created streams if you want to determine the size of the callback buffer passed to you.  Specify 0 to use FMOD's default size which is currently equivalent to 400ms of the sound format created/loaded. 
        Public initialsubsound As Integer
        ' [in] Optional. Specify 0 to ignore. In a multi-sample file format such as .FSB/.DLS/.SF2, specify the initial subsound to seek to, only if CREATESTREAM is used. 
        Public numsubsounds As Integer
        ' [in] Optional. Specify 0 to ignore or have no subsounds.  In a user created multi-sample sound, specify the number of subsounds within the sound that are accessable with Sound::getSubSound / SoundGetSubSound. 
        Public inclusionlist As IntPtr
        ' [in] Optional. Specify 0 to ignore. In a multi-sample format such as .FSB/.DLS/.SF2 it may be desirable to specify only a subset of sounds to be loaded out of the whole file.  This is an array of subsound indicies to load into memory when created. 
        Public inclusionlistnum As Integer
        ' [in] Optional. Specify 0 to ignore. This is the number of integers contained within the 
        Public pcmreadcallback As SOUND_PCMREADCALLBACK
        ' [in] Optional. Specify 0 to ignore. Callback to 'piggyback' on FMOD's read functions and accept or even write PCM data while FMOD is opening the sound.  Used for user sounds created with OPENUSER or for capturing decoded data as FMOD reads it. 
        Public pcmsetposcallback As SOUND_PCMSETPOSCALLBACK
        ' [in] Optional. Specify 0 to ignore. Callback for when the user calls a seeking function such as Channel::setPosition within a multi-sample sound, and for when it is opened.
        Public nonblockcallback As SOUND_NONBLOCKCALLBACK
        ' [in] Optional. Specify 0 to ignore. Callback for successful completion, or error while loading a sound that used the FMOD_NONBLOCKING flag.
        Public dlsname As String
        ' [in] Optional. Specify 0 to ignore. Filename for a DLS or SF2 sample set when loading a MIDI file.   If not specified, on windows it will attempt to open /windows/system32/drivers/gm.dls, otherwise the MIDI will fail to open.  
        Public encryptionkey As String
        ' [in] Optional. Specify 0 to ignore. Key for encrypted FSB file.  Without this key an encrypted FSB file will not load. 
        Public maxpolyphony As Integer
        ' [in] Optional. Specify 0 to ingore. For sequenced formats with dynamic channel allocation such as .MID and .IT, this specifies the maximum voice count allowed while playing.  .IT defaults to 64.  .MID defaults to 32. 
        Public userdata As IntPtr
        ' [in] Optional. Specify 0 to ignore. This is user data to be attached to the sound during creation.  Access via Sound::getUserData. 
        Public suggestedsoundtype As SOUND_TYPE
        ' [in] Optional. Specify 0 or FMOD_SOUND_TYPE_UNKNOWN to ignore.  Instead of scanning all codec types, use this to speed up loading by making it jump straight to this codec. 
        Public useropen As FILE_OPENCALLBACK
        ' [in] Optional. Specify 0 to ignore. Callback for opening this file. 
        Public userclose As FILE_CLOSECALLBACK
        ' [in] Optional. Specify 0 to ignore. Callback for closing this file. 
        Public userread As FILE_READCALLBACK
        ' [in] Optional. Specify 0 to ignore. Callback for reading from this file. 
        Public userseek As FILE_SEEKCALLBACK
        ' [in] Optional. Specify 0 to ignore. Callback for seeking within this file. 
        Public userasyncread As FILE_ASYNCREADCALLBACK
        ' [in] Optional. Specify 0 to ignore. Callback for asyncronously reading from this file. 
        Public userasynccancel As FILE_ASYNCCANCELCALLBACK
        ' [in] Optional. Specify 0 to ignore. Callback for cancelling an asyncronous read. 
        Public speakermap As SPEAKERMAPTYPE
        ' [in] Optional. Specify 0 to ignore. Use this to differ the way fmod maps multichannel sounds to speakers.  See FMOD_SPEAKERMAPTYPE for more. 
        Public initialsoundgroup As IntPtr
        ' [in] Optional. Specify 0 to ignore. Specify a sound group if required, to put sound in as it is created. 
        Public initialseekposition As UInteger
        ' [in] Optional. Specify 0 to ignore. For streams. Specify an initial position to seek the stream to. 
        Public initialseekpostype As TIMEUNIT
        ' [in] Optional. Specify 0 to ignore. For streams. Specify the time unit for the position set in initialseekposition. 
        Public ignoresetfilesystem As Integer
        ' [in] Optional. Specify 0 to ignore. Set to 1 to use fmod's built in file system. Ignores setFileSystem callbacks and also FMOD_CREATESOUNEXINFO file callbacks.  Useful for specific cases where you don't want to use your own file system but want to use fmod's file system (ie net streaming). 
        Public cddaforceaspi As Integer
        ' [in] Optional. Specify 0 to ignore. For CDDA sounds only - if non-zero use ASPI instead of NTSCSI to access the specified CD/DVD device. 
        Public audioqueuepolicy As UInteger
        ' [in] Optional. Specify 0 or FMOD_AUDIOQUEUE_CODECPOLICY_DEFAULT to ignore. Policy used to determine whether hardware or software is used for decoding, see FMOD_AUDIOQUEUE_CODECPOLICY for options (iOS >= 3.0 required, otherwise only hardware is available) 
        Public minmidigranularity As UInteger
        ' [in] Optional. Specify 0 to ignore. Allows you to set a minimum desired MIDI mixer granularity. Values smaller than 512 give greater than default accuracy at the cost of more CPU and vise versa. Specify 0 for default (512 samples). 
        Public nonblockthreadid As Integer
        ' [in] Optional. Specify 0 to ignore. Specifies a thread index to execute non blocking load on.  Allows for up to 5 threads to be used for loading at once.  This is to avoid one load blocking another.  Maximum value = 4. 
    End Structure


    '
    '    [STRUCTURE] 
    '    [
    '        [DESCRIPTION]
    '        Structure defining a reverb environment.<br>
    '        <br>
    '        For more indepth descriptions of the reverb properties under win32, please see the EAX2 and EAX3
    '        documentation at http://developer.creative.com/ under the 'downloads' section.<br>
    '        If they do not have the EAX3 documentation, then most information can be attained from
    '        the EAX2 documentation, as EAX3 only adds some more parameters and functionality on top of 
    '        EAX2.
    '
    '        [REMARKS]
    '        Note the default reverb properties are the same as the FMOD_PRESET_GENERIC preset.<br>
    '        Note that integer values that typically range from -10,000 to 1000 are represented in 
    '        decibels, and are of a logarithmic scale, not linear, wheras float values are always linear.<br>
    '        <br>
    '        The numerical values listed below are the maximum, minimum and default values for each variable respectively.<br>
    '        <br>
    '        <b>SUPPORTED</b> next to each parameter means the platform the parameter can be set on.  Some platforms support all parameters and some don't.<br>
    '        EAX   means hardware reverb on FMOD_OUTPUTTYPE_DSOUND on windows only (must use FMOD_HARDWARE), on soundcards that support EAX 1 to 4.<br>
    '        EAX4  means hardware reverb on FMOD_OUTPUTTYPE_DSOUND on windows only (must use FMOD_HARDWARE), on soundcards that support EAX 4.<br>
    '        I3DL2 means hardware reverb on FMOD_OUTPUTTYPE_DSOUND on windows only (must use FMOD_HARDWARE), on soundcards that support I3DL2 non EAX native reverb.<br>
    '        GC    means Nintendo Gamecube hardware reverb (must use FMOD_HARDWARE).<br>
    '        WII   means Nintendo Wii hardware reverb (must use FMOD_HARDWARE).<br>
    '        PS2   means Playstation 2 hardware reverb (must use FMOD_HARDWARE).<br>
    '        SFX   means FMOD SFX software reverb.  This works on any platform that uses FMOD_SOFTWARE for loading sounds.<br>
    '        <br>
    '        Members marked with [in] mean the user sets the value before passing it to the function.<br>
    '        Members marked with [out] mean FMOD sets the value to be used after the function exits.<br>
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]
    '        System::setReverbProperties
    '        System::getReverbProperties
    '        FMOD_REVERB_PRESETS
    '        FMOD_REVERB_FLAGS
    '    ]
    '    

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure REVERB_PROPERTIES
        '          MIN     MAX    DEFAULT   DESCRIPTION 
        Public Instance As Integer
        ' [in]     0     , 3     , 0      , EAX4 only. Environment Instance. 3 seperate reverbs simultaneously are possible. This specifies which one to set. (win32 only) 
        Public Environment As Integer
        ' [in/out] -1    , 25    , -1     , sets all listener properties (win32/ps2) 
        Public EnvDiffusion As Single
        ' [in/out] 0.0   , 1.0   , 1.0    , environment diffusion (win32/xbox) 
        Public Room As Integer
        ' [in/out] -10000, 0     , -1000  , room effect level (at mid frequencies) (win32/xbox) 
        Public RoomHF As Integer
        ' [in/out] -10000, 0     , -100   , relative room effect level at high frequencies (win32/xbox) 
        Public RoomLF As Integer
        ' [in/out] -10000, 0     , 0      , relative room effect level at low frequencies (win32 only) 
        Public DecayTime As Single
        ' [in/out] 0.1   , 20.0  , 1.49   , reverberation decay time at mid frequencies (win32/xbox) 
        Public DecayHFRatio As Single
        ' [in/out] 0.1   , 2.0   , 0.83   , high-frequency to mid-frequency decay time ratio (win32/xbox) 
        Public DecayLFRatio As Single
        ' [in/out] 0.1   , 2.0   , 1.0    , low-frequency to mid-frequency decay time ratio (win32 only) 
        Public Reflections As Integer
        ' [in/out] -10000, 1000  , -2602  , early reflections level relative to room effect (win32/xbox) 
        Public ReflectionsDelay As Single
        ' [in/out] 0.0   , 0.3   , 0.007  , initial reflection delay time (win32/xbox) 
        Public Reverb As Integer
        ' [in/out] -10000, 2000  , 200    , late reverberation level relative to room effect (win32/xbox) 
        Public ReverbDelay As Single
        ' [in/out] 0.0   , 0.1   , 0.011  , late reverberation delay time relative to initial reflection (win32/xbox) 
        Public ModulationTime As Single
        ' [in/out] 0.04  , 4.0   , 0.25   , modulation time (win32 only) 
        Public ModulationDepth As Single
        ' [in/out] 0.0   , 1.0   , 0.0    , modulation depth (win32 only) 
        Public HFReference As Single
        ' [in/out] 1000.0, 20000 , 5000.0 , reference high frequency (hz) (win32/xbox) 
        Public LFReference As Single
        ' [in/out] 20.0  , 1000.0, 250.0  , reference low frequency (hz) (win32 only) 
        Public Diffusion As Single
        ' [in/out] 0.0   , 100.0 , 100.0  , Value that controls the echo density in the late reverberation decay. (xbox only) 
        Public Density As Single
        ' [in/out] 0.0   , 100.0 , 100.0  , Value that controls the modal density in the late reverberation decay (xbox only) 
        Public Flags As UInteger
        ' [in/out] REVERB_FLAGS - modifies the behavior of above properties (win32/ps2) 

#Region "wrapperinternal"
        Public Sub New(ByVal instance__1 As Integer, ByVal environment__2 As Integer, ByVal envDiffusion__3 As Single, ByVal room__4 As Integer, ByVal roomHF__5 As Integer, ByVal roomLF__6 As Integer, _
         ByVal decayTime__7 As Single, ByVal decayHFRatio__8 As Single, ByVal decayLFRatio__9 As Single, ByVal reflections__10 As Integer, ByVal reflectionsDelay__11 As Single, ByVal reverb__12 As Integer, _
         ByVal reverbDelay__13 As Single, ByVal modulationTime__14 As Single, ByVal modulationDepth__15 As Single, ByVal hfReference__16 As Single, ByVal lfReference__17 As Single, ByVal diffusion__18 As Single, _
         ByVal density__19 As Single, ByVal flags__20 As UInteger)
            Instance = instance__1
            Environment = environment__2
            EnvDiffusion = envDiffusion__3
            Room = room__4
            RoomHF = roomHF__5
            RoomLF = roomLF__6
            DecayTime = decayTime__7
            DecayHFRatio = decayHFRatio__8
            DecayLFRatio = decayLFRatio__9
            Reflections = reflections__10
            ReflectionsDelay = reflectionsDelay__11
            Reverb = reverb__12
            ReverbDelay = reverbDelay__13
            ModulationTime = modulationTime__14
            ModulationDepth = modulationDepth__15
            HFReference = hfReference__16
            LFReference = lfReference__17
            Diffusion = diffusion__18
            Density = density__19
            Flags = flags__20
        End Sub
#End Region
    End Structure


    '
    '    [DEFINE] 
    '    [
    '        [NAME] 
    '        REVERB_FLAGS
    '
    '        [DESCRIPTION]
    '        Values for the Flags member of the REVERB_PROPERTIES structure.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]
    '        REVERB_PROPERTIES
    '    ]
    '    

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure REVERB_FLAGS
        Public Const HIGHQUALITYREVERB As UInteger = &H400
        ' Wii. Use high quality reverb 
        Public Const HIGHQUALITYDPL2REVERB As UInteger = &H800
        ' Wii. Use high quality DPL2 reverb 
        Public Const [DEFAULT] As UInteger = &H0
    End Structure


    '
    '    [DEFINE] 
    '    [
    '    [NAME] 
    '    FMOD_REVERB_PRESETS
    '
    '    [DESCRIPTION]   
    '    A set of predefined environment PARAMETERS, created by Creative Labs
    '    These are used to initialize an FMOD_REVERB_PROPERTIES structure statically.
    '    ie 
    '    FMOD_REVERB_PROPERTIES prop = FMOD_PRESET_GENERIC;
    '
    '    [PLATFORMS]
    '    Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '    [SEE_ALSO]
    '    System::setReverbProperties
    '    ]
    '    

    Class PRESET
        '                                                                           Instance  Env   Diffus  Room   RoomHF  RmLF DecTm   DecHF  DecLF   Refl  RefDel   Revb  RevDel  ModTm  ModDp   HFRef    LFRef   Diffus  Densty  FLAGS 

        Public Shared Function OFF() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, -1, 1.0F, -10000, -10000, 0, _
             1.0F, 1.0F, 1.0F, -2602, 0.007F, 200, _
             0.011F, 0.25F, 0.0F, 5000.0F, 250.0F, 0.0F, _
             0.0F, &H33F)
        End Function
        Public Shared Function GENERIC() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 0, 1.0F, -1000, -100, 0, _
             1.49F, 0.83F, 1.0F, -2602, 0.007F, 200, _
             0.011F, 0.25F, 0.0F, 5000.0F, 250.0F, 100.0F, _
             100.0F, &H3F)
        End Function
        Public Shared Function PADDEDCELL() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 1, 1.0F, -1000, -6000, 0, _
             0.17F, 0.1F, 1.0F, -1204, 0.001F, 207, _
             0.002F, 0.25F, 0.0F, 5000.0F, 250.0F, 100.0F, _
             100.0F, &H3F)
        End Function
        Public Shared Function ROOM() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 2, 1.0F, -1000, -454, 0, _
             0.4F, 0.83F, 1.0F, -1646, 0.002F, 53, _
             0.003F, 0.25F, 0.0F, 5000.0F, 250.0F, 100.0F, _
             100.0F, &H3F)
        End Function
        Public Shared Function BATHROOM() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 3, 1.0F, -1000, -1200, 0, _
             1.49F, 0.54F, 1.0F, -370, 0.007F, 1030, _
             0.011F, 0.25F, 0.0F, 5000.0F, 250.0F, 100.0F, _
             60.0F, &H3F)
        End Function
        Public Shared Function LIVINGROOM() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 4, 1.0F, -1000, -6000, 0, _
             0.5F, 0.1F, 1.0F, -1376, 0.003F, -1104, _
             0.004F, 0.25F, 0.0F, 5000.0F, 250.0F, 100.0F, _
             100.0F, &H3F)
        End Function
        Public Shared Function STONEROOM() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 5, 1.0F, -1000, -300, 0, _
             2.31F, 0.64F, 1.0F, -711, 0.012F, 83, _
             0.017F, 0.25F, 0.0F, 5000.0F, 250.0F, 100.0F, _
             100.0F, &H3F)
        End Function
        Public Shared Function AUDITORIUM() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 6, 1.0F, -1000, -476, 0, _
             4.32F, 0.59F, 1.0F, -789, 0.02F, -289, _
             0.03F, 0.25F, 0.0F, 5000.0F, 250.0F, 100.0F, _
             100.0F, &H3F)
        End Function
        Public Shared Function CONCERTHALL() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 7, 1.0F, -1000, -500, 0, _
             3.92F, 0.7F, 1.0F, -1230, 0.02F, -2, _
             0.029F, 0.25F, 0.0F, 5000.0F, 250.0F, 100.0F, _
             100.0F, &H3F)
        End Function
        Public Shared Function CAVE() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 8, 1.0F, -1000, 0, 0, _
             2.91F, 1.3F, 1.0F, -602, 0.015F, -302, _
             0.022F, 0.25F, 0.0F, 5000.0F, 250.0F, 100.0F, _
             100.0F, &H1F)
        End Function
        Public Shared Function ARENA() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 9, 1.0F, -1000, -698, 0, _
             7.24F, 0.33F, 1.0F, -1166, 0.02F, 16, _
             0.03F, 0.25F, 0.0F, 5000.0F, 250.0F, 100.0F, _
             100.0F, &H3F)
        End Function
        Public Shared Function HANGAR() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 10, 1.0F, -1000, -1000, 0, _
             10.05F, 0.23F, 1.0F, -602, 0.02F, 198, _
             0.03F, 0.25F, 0.0F, 5000.0F, 250.0F, 100.0F, _
             100.0F, &H3F)
        End Function
        Public Shared Function CARPETTEDHALLWAY() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 11, 1.0F, -1000, -4000, 0, _
             0.3F, 0.1F, 1.0F, -1831, 0.002F, -1630, _
             0.03F, 0.25F, 0.0F, 5000.0F, 250.0F, 100.0F, _
             100.0F, &H3F)
        End Function
        Public Shared Function HALLWAY() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 12, 1.0F, -1000, -300, 0, _
             1.49F, 0.59F, 1.0F, -1219, 0.007F, 441, _
             0.011F, 0.25F, 0.0F, 5000.0F, 250.0F, 100.0F, _
             100.0F, &H3F)
        End Function
        Public Shared Function STONECORRIDOR() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 13, 1.0F, -1000, -237, 0, _
             2.7F, 0.79F, 1.0F, -1214, 0.013F, 395, _
             0.02F, 0.25F, 0.0F, 5000.0F, 250.0F, 100.0F, _
             100.0F, &H3F)
        End Function
        Public Shared Function ALLEY() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 14, 0.3F, -1000, -270, 0, _
             1.49F, 0.86F, 1.0F, -1204, 0.007F, -4, _
             0.011F, 0.25F, 0.0F, 5000.0F, 250.0F, 100.0F, _
             100.0F, &H3F)
        End Function
        Public Shared Function FOREST() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 15, 0.3F, -1000, -3300, 0, _
             1.49F, 0.54F, 1.0F, -2560, 0.162F, -229, _
             0.088F, 0.25F, 0.0F, 5000.0F, 250.0F, 79.0F, _
             100.0F, &H3F)
        End Function
        Public Shared Function CITY() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 16, 0.5F, -1000, -800, 0, _
             1.49F, 0.67F, 1.0F, -2273, 0.007F, -1691, _
             0.011F, 0.25F, 0.0F, 5000.0F, 250.0F, 50.0F, _
             100.0F, &H3F)
        End Function
        Public Shared Function MOUNTAINS() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 17, 0.27F, -1000, -2500, 0, _
             1.49F, 0.21F, 1.0F, -2780, 0.3F, -1434, _
             0.1F, 0.25F, 0.0F, 5000.0F, 250.0F, 27.0F, _
             100.0F, &H1F)
        End Function
        Public Shared Function QUARRY() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 18, 1.0F, -1000, -1000, 0, _
             1.49F, 0.83F, 1.0F, -10000, 0.061F, 500, _
             0.025F, 0.25F, 0.0F, 5000.0F, 250.0F, 100.0F, _
             100.0F, &H3F)
        End Function
        Public Shared Function PLAIN() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 19, 0.21F, -1000, -2000, 0, _
             1.49F, 0.5F, 1.0F, -2466, 0.179F, -1926, _
             0.1F, 0.25F, 0.0F, 5000.0F, 250.0F, 21.0F, _
             100.0F, &H3F)
        End Function
        Public Shared Function PARKINGLOT() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 20, 1.0F, -1000, 0, 0, _
             1.65F, 1.5F, 1.0F, -1363, 0.008F, -1153, _
             0.012F, 0.25F, 0.0F, 5000.0F, 250.0F, 100.0F, _
             100.0F, &H1F)
        End Function
        Public Shared Function SEWERPIPE() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 21, 0.8F, -1000, -1000, 0, _
             2.81F, 0.14F, 1.0F, 429, 0.014F, 1023, _
             0.021F, 0.25F, 0.0F, 5000.0F, 250.0F, 80.0F, _
             60.0F, &H3F)
        End Function
        Public Shared Function UNDERWATER() As REVERB_PROPERTIES
            Return New REVERB_PROPERTIES(0, 22, 1.0F, -1000, -4000, 0, _
             1.49F, 0.1F, 1.0F, -449, 0.007F, 1700, _
             0.011F, 1.18F, 0.348F, 5000.0F, 250.0F, 100.0F, _
             100.0F, &H3F)
        End Function
    End Class

    '
    '    [STRUCTURE] 
    '    [
    '        [DESCRIPTION]
    '        Structure defining the properties for a reverb source, related to a FMOD channel.
    '
    '        For more indepth descriptions of the reverb properties under win32, please see the EAX3
    '        documentation at http://developer.creative.com/ under the 'downloads' section.
    '        If they do not have the EAX3 documentation, then most information can be attained from
    '        the EAX2 documentation, as EAX3 only adds some more parameters and functionality on top of 
    '        EAX2.
    '
    '        Note the default reverb properties are the same as the PRESET_GENERIC preset.
    '        Note that integer values that typically range from -10,000 to 1000 are represented in 
    '        decibels, and are of a logarithmic scale, not linear, wheras FLOAT values are typically linear.
    '        PORTABILITY: Each member has the platform it supports in braces ie (win32/xbox).  
    '        Some reverb parameters are only supported in win32 and some only on xbox. If all parameters are set then
    '        the reverb should product a similar effect on either platform.
    '        Linux and FMODCE do not support the reverb api.
    '
    '        The numerical values listed below are the maximum, minimum and default values for each variable respectively.
    '
    '        [REMARKS]
    '        For EAX4 support with multiple reverb environments, set FMOD_REVERB_CHANNELFLAGS_ENVIRONMENT0,
    '        FMOD_REVERB_CHANNELFLAGS_ENVIRONMENT1 or/and FMOD_REVERB_CHANNELFLAGS_ENVIRONMENT2 in the flags member 
    '        of FMOD_REVERB_CHANNELPROPERTIES to specify which environment instance(s) to target. 
    '        Only up to 2 environments to target can be specified at once. Specifying three will result in an error.
    '        If the sound card does not support EAX4, the environment flag is ignored.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]
    '        Channel::setReverbProperties
    '        Channel::getReverbProperties
    '        REVERB_CHANNELFLAGS
    '    ]
    '    

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure REVERB_CHANNELPROPERTIES
        '          MIN     MAX    DEFAULT  DESCRIPTION 
        Public Direct As Integer
        ' [in/out] -10000, 1000,  0,       direct path level (at low and mid frequencies) (win32/xbox) 
        Public Room As Integer
        ' [in/out] -10000, 1000,  0,       room effect level (at low and mid frequencies) (win32/xbox) 
        Public Flags As UInteger
        ' [in/out] REVERB_CHANNELFLAGS - modifies the behavior of properties (win32) 
        Public ConnectionPoint As IntPtr
        ' [in/out] See remarks.            DSP network location to connect reverb for this channel.    (SUPPORTED:SFX only).
    End Structure


    '
    '    [DEFINE] 
    '    [
    '        [NAME] 
    '        REVERB_CHANNELFLAGS
    '
    '        [DESCRIPTION]
    '        Values for the Flags member of the REVERB_CHANNELPROPERTIES structure.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]
    '        REVERB_CHANNELPROPERTIES
    '    ]
    '    

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure REVERB_CHANNELFLAGS
        Public Const INSTANCE0 As UInteger = &H10
        ' SFX/Wii. Specify channel to target reverb instance 0.  Default target. 
        Public Const INSTANCE1 As UInteger = &H20
        ' SFX/Wii. Specify channel to target reverb instance 1. 
        Public Const INSTANCE2 As UInteger = &H40
        ' SFX/Wii. Specify channel to target reverb instance 2. 
        Public Const INSTANCE3 As UInteger = &H80
        ' SFX. Specify channel to target reverb instance 3. 
        Public Const [DEFAULT] As UInteger = INSTANCE0
    End Structure


    '
    '    [STRUCTURE] 
    '    [
    '        [DESCRIPTION]
    '        Settings for advanced features like configuring memory and cpu usage for the FMOD_CREATECOMPRESSEDSAMPLE feature.
    '   
    '        [REMARKS]
    '        maxMPEGcodecs / maxADPCMcodecs / maxXMAcodecs will determine the maximum cpu usage of playing realtime samples.  Use this to lower potential excess cpu usage and also control memory usage.<br>
    '   
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3
    '   
    '        [SEE_ALSO]
    '        System::setAdvancedSettings
    '        System::getAdvancedSettings
    '    ]
    '    

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure ADVANCEDSETTINGS
        Public cbsize As Integer
        ' Size of structure.  Use sizeof(FMOD_ADVANCEDSETTINGS) 
        Public maxMPEGcodecs As Integer
        ' For use with FMOD_CREATECOMPRESSEDSAMPLE only.  Mpeg  codecs consume 48,696 per instance and this number will determine how many mpeg channels can be played simultaneously.  Default = 16. 
        Public maxADPCMcodecs As Integer
        ' For use with FMOD_CREATECOMPRESSEDSAMPLE only.  ADPCM codecs consume 1k per instance and this number will determine how many ADPCM channels can be played simultaneously.  Default = 32. 
        Public maxXMAcodecs As Integer
        ' For use with FMOD_CREATECOMPRESSEDSAMPLE only.  XMA   codecs consume 8k per instance and this number will determine how many XMA channels can be played simultaneously.  Default = 32.  
        Public maxPCMcodecs As Integer
        ' [in/out] Optional. Specify 0 to ignore. For use with PS3 only.                          PCM   codecs consume 12,672 bytes per instance and this number will determine how many streams and PCM voices can be played simultaneously. Default = 16 
        Public maxCELTcodecs As Integer
        ' [in/out] Optional. Specify 0 to ignore. For use with FMOD_CREATECOMPRESSEDSAMPLE only.  CELT  codecs consume 11,500 bytes per instance and this number will determine how many CELT channels can be played simultaneously. Default = 16 
        Public maxVORBIScodecs As Integer
        ' [r/w] Optional. Specify 0 to ignore. For use with FMOD_CREATECOMPRESSEDSAMPLE only.  Vorbis codecs consume 12,000 bytes per instance and this number will determine how many Vorbis channels can be played simultaneously. Default = 32. 
        Public ASIONumChannels As Integer
        ' [in/out] 
        Public ASIOChannelList As IntPtr
        ' [in/out] 
        Public ASIOSpeakerList As IntPtr
        ' [in/out] Optional. Specify 0 to ignore. Pointer to a list of speakers that the ASIO channels map to.  This can be called after System::init to remap ASIO output. 
        Public max3DReverbDSPs As Integer
        ' [in/out] The max number of 3d reverb DSP's in the system. 
        Public HRTFMinAngle As Single
        ' [in/out] For use with FMOD_INIT_HRTF_LOWPASS.  The angle (0-360) of a 3D sound from the listener's forward vector at which the HRTF function begins to have an effect.  Default = 180.0. 
        Public HRTFMaxAngle As Single
        ' [in/out] For use with FMOD_INIT_HRTF_LOWPASS.  The angle (0-360) of a 3D sound from the listener's forward vector at which the HRTF function begins to have maximum effect.  Default = 360.0.  
        Public HRTFFreq As Single
        ' [in/out] For use with FMOD_INIT_HRTF_LOWPASS.  The cutoff frequency of the HRTF's lowpass filter function when at maximum effect. (i.e. at HRTFMaxAngle).  Default = 4000.0. 
        Public vol0virtualvol As Single
        ' [in/out] For use with FMOD_INIT_VOL0_BECOMES_VIRTUAL.  If this flag is used, and the volume is 0.0, then the sound will become virtual.  Use this value to raise the threshold to a different point where a sound goes virtual. 
        Public eventqueuesize As Integer
        ' [in/out] Optional. Specify 0 to ignore. For use with FMOD Event system only.  Specifies the number of slots available for simultaneous non blocking loads.  Default = 32. 
        Public defaultDecodeBufferSize As UInteger
        ' [in/out] Optional. Specify 0 to ignore. For streams. This determines the default size of the double buffer (in milliseconds) that a stream uses.  Default = 400ms 
        Public debugLogFilename As IntPtr
        ' [in/out] Optional. Specify 0 to ignore. Gives fmod's logging system a path/filename.  Normally the log is placed in the same directory as the executable and called fmod.log. When using System::getAdvancedSettings, provide at least 256 bytes of memory to copy into. 
        Public profileport As UShort
        ' [in/out] Optional. Specify 0 to ignore. For use with FMOD_INIT_ENABLE_PROFILE.  Specify the port to listen on for connections by the profiler application. 
        Public geometryMaxFadeTime As UInteger
        ' [in/out] Optional. Specify 0 to ignore. The maximum time in miliseconds it takes for a channel to fade to the new level when its occlusion changes. 
        Public maxSpectrumWaveDataBuffers As UInteger
        ' [in/out] Optional. Specify 0 to ignore. The maximum number of buffers for use with getWaveData/getSpectrum. 
        Public musicSystemCacheDelay As UInteger
        ' [in/out] Optional. Specify 0 to ignore. The delay the music system should allow for loading a sample from disk (in milliseconds). Default = 400 ms. 
        Public distanceFilterCenterFreq As Single
        ' [r/w] Optional. Specify 0 to ignore. For use with FMOD_INIT_DISTANCE_FILTERING.  The default center frequency in Hz for the distance filtering effect. Default = 1500.0. 
    End Structure


    '
    '    [ENUM] 
    '    [
    '        [NAME] 
    '        FMOD_MISC_VALUES
    '
    '        [DESCRIPTION]
    '        Miscellaneous values for FMOD functions.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation Portable, PlayStation 3, Wii
    '
    '        [SEE_ALSO]
    '        System::playSound
    '        System::playDSP
    '        System::getChannel
    '    ]
    '    

    Public Enum CHANNELINDEX
        FREE = -1
        ' For a channel index, FMOD chooses a free voice using the priority system. 
        REUSE = -2
        ' For a channel index, re-use the channel handle that was passed in. 
    End Enum


    '
    '        FMOD System factory functions.  Use this to create an FMOD System Instance.  below you will see System_Init/Close to get started.
    '    

    Public Class Factory
        Public Shared Function System_Create(ByRef system As System) As RESULT
#If WIN64 Then
			If IntPtr.Size <> 8 Then
				' Attempting to use 64-bit FMOD dll with 32-bit application.


				Return RESULT.ERR_FILE_BAD
			End If
#Else
            If IntPtr.Size <> 4 Then
                ' Attempting to use 32-bit FMOD dll with 64-bit application. A likely cause of this error 
                '                 * is targetting platform 'Any CPU'. You cannot link to unmanaged dll with 'Any CPU'
                '                 * target. 
                '                 * 
                '                 * For 32-bit applications: set the platform to 'x86'.
                '                 * 
                '                 * For 64-bit applications:
                '                 * 1. set the platform to x64
                '                 * 2. add the conditional complication symbol WIN64
                '                 * 3. download the win64 fmod release
                '                 * 4. copy the fmodex64.dll to the location of the .exe file for your application 


                Return RESULT.ERR_FILE_BAD
            End If
#End If

            Dim result__1 As RESULT = RESULT.OK
            Dim systemraw As New IntPtr()
            Dim systemnew As System = Nothing

            result__1 = FMOD_System_Create(systemraw)
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            systemnew = New System()
            systemnew.setRaw(systemraw)
            system = systemnew

            Return result__1
        End Function


#Region "importfunctions"

        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_Create(ByRef system As IntPtr) As RESULT
        End Function

#End Region
    End Class


    Public Class Memory
        Public Shared Function GetStats(ByRef currentalloced As Integer, ByRef maxalloced As Integer) As RESULT
            Return FMOD_Memory_GetStats(currentalloced, maxalloced, 1)
        End Function

        Public Shared Function GetStats(ByRef currentalloced As Integer, ByRef maxalloced As Integer, ByVal blocking As Boolean) As RESULT
            Return FMOD_Memory_GetStats(currentalloced, maxalloced, (If(blocking, 1, 0)))
        End Function


#Region "importfunctions"

        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Memory_GetStats(ByRef currentalloced As Integer, ByRef maxalloced As Integer, ByVal blocking As Integer) As RESULT
        End Function

#End Region
    End Class


    '
    '        'System' API
    '    

    Public Class System
        Public Function release() As RESULT
            Return FMOD_System_Release(systemraw)
        End Function


        ' Pre-init functions.
        Public Function setOutput(ByVal output As OUTPUTTYPE) As RESULT
            Return FMOD_System_SetOutput(systemraw, output)
        End Function
        Public Function getOutput(ByRef output As OUTPUTTYPE) As RESULT
            Return FMOD_System_GetOutput(systemraw, output)
        End Function
        Public Function getNumDrivers(ByRef numdrivers As Integer) As RESULT
            Return FMOD_System_GetNumDrivers(systemraw, numdrivers)
        End Function
        Public Function getDriverInfo(ByVal id As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal name As StringBuilder, ByVal namelen As Integer, ByRef guid As GUID) As RESULT
            'use multibyte version
            Return FMOD_System_GetDriverInfoW(systemraw, id, name, namelen, guid)
        End Function
        Public Function getDriverCaps(ByVal id As Integer, ByRef caps As CAPS, ByRef controlpaneloutputrate As Integer, ByRef controlpanelspeakermode As SPEAKERMODE) As RESULT
            Return FMOD_System_GetDriverCaps(systemraw, id, caps, controlpaneloutputrate, controlpanelspeakermode)
        End Function
        Public Function setDriver(ByVal driver As Integer) As RESULT
            Return FMOD_System_SetDriver(systemraw, driver)
        End Function
        Public Function getDriver(ByRef driver As Integer) As RESULT
            Return FMOD_System_GetDriver(systemraw, driver)
        End Function
        Public Function setHardwareChannels(ByVal numhardwarechannels As Integer) As RESULT
            Return FMOD_System_SetHardwareChannels(systemraw, numhardwarechannels)
        End Function
        Public Function setSoftwareChannels(ByVal numsoftwarechannels As Integer) As RESULT
            Return FMOD_System_SetSoftwareChannels(systemraw, numsoftwarechannels)
        End Function
        Public Function getSoftwareChannels(ByRef numsoftwarechannels As Integer) As RESULT
            Return FMOD_System_GetSoftwareChannels(systemraw, numsoftwarechannels)
        End Function
        Public Function setSoftwareFormat(ByVal samplerate As Integer, ByVal format As SOUND_FORMAT, ByVal numoutputchannels As Integer, ByVal maxinputchannels As Integer, ByVal resamplemethod As DSP_RESAMPLER) As RESULT
            Return FMOD_System_SetSoftwareFormat(systemraw, samplerate, format, numoutputchannels, maxinputchannels, resamplemethod)
        End Function
        Public Function getSoftwareFormat(ByRef samplerate As Integer, ByRef format As SOUND_FORMAT, ByRef numoutputchannels As Integer, ByRef maxinputchannels As Integer, ByRef resamplemethod As DSP_RESAMPLER, ByRef bits As Integer) As RESULT
            Return FMOD_System_GetSoftwareFormat(systemraw, samplerate, format, numoutputchannels, maxinputchannels, resamplemethod, _
             bits)
        End Function
        Public Function setDSPBufferSize(ByVal bufferlength As UInteger, ByVal numbuffers As Integer) As RESULT
            Return FMOD_System_SetDSPBufferSize(systemraw, bufferlength, numbuffers)
        End Function
        Public Function getDSPBufferSize(ByRef bufferlength As UInteger, ByRef numbuffers As Integer) As RESULT
            Return FMOD_System_GetDSPBufferSize(systemraw, bufferlength, numbuffers)
        End Function
        Public Function setFileSystem(ByVal useropen As FILE_OPENCALLBACK, ByVal userclose As FILE_CLOSECALLBACK, ByVal userread As FILE_READCALLBACK, ByVal userseek As FILE_SEEKCALLBACK, ByVal userasyncread As FILE_ASYNCREADCALLBACK, ByVal userasynccancel As FILE_ASYNCCANCELCALLBACK, _
         ByVal blockalign As Integer) As RESULT
            Return FMOD_System_SetFileSystem(systemraw, useropen, userclose, userread, userseek, userasyncread, _
             userasynccancel, blockalign)
        End Function
        Public Function attachFileSystem(ByVal useropen As FILE_OPENCALLBACK, ByVal userclose As FILE_CLOSECALLBACK, ByVal userread As FILE_READCALLBACK, ByVal userseek As FILE_SEEKCALLBACK) As RESULT
            Return FMOD_System_AttachFileSystem(systemraw, useropen, userclose, userread, userseek)
        End Function
        Public Function setAdvancedSettings(ByRef settings As ADVANCEDSETTINGS) As RESULT
            Return FMOD_System_SetAdvancedSettings(systemraw, settings)
        End Function
        Public Function getAdvancedSettings(ByRef settings As ADVANCEDSETTINGS) As RESULT
            Return FMOD_System_GetAdvancedSettings(systemraw, settings)
        End Function
        Public Function setSpeakerMode(ByVal speakermode As SPEAKERMODE) As RESULT
            Return FMOD_System_SetSpeakerMode(systemraw, speakermode)
        End Function
        Public Function getSpeakerMode(ByRef speakermode As SPEAKERMODE) As RESULT
            Return FMOD_System_GetSpeakerMode(systemraw, speakermode)
        End Function
        Public Function setCallback(ByVal callback As SYSTEM_CALLBACK) As RESULT
            Return FMOD_System_SetCallback(systemraw, callback)
        End Function

        ' Plug-in support
        Public Function setPluginPath(ByVal path As String) As RESULT
            Return FMOD_System_SetPluginPath(systemraw, path)
        End Function
        Public Function loadPlugin(ByVal filename As String, ByRef handle As UInteger, ByVal priority As UInteger) As RESULT
            Return FMOD_System_LoadPlugin(systemraw, filename, handle, priority)
        End Function
        Public Function unloadPlugin(ByVal handle As UInteger) As RESULT
            Return FMOD_System_UnloadPlugin(systemraw, handle)
        End Function
        Public Function getNumPlugins(ByVal plugintype As PLUGINTYPE, ByRef numplugins As Integer) As RESULT
            Return FMOD_System_GetNumPlugins(systemraw, plugintype, numplugins)
        End Function
        Public Function getPluginHandle(ByVal plugintype As PLUGINTYPE, ByVal index As Integer, ByRef handle As UInteger) As RESULT
            Return FMOD_System_GetPluginHandle(systemraw, plugintype, index, handle)
        End Function
        Public Function getPluginInfo(ByVal handle As UInteger, ByRef plugintype As PLUGINTYPE, ByVal name As StringBuilder, ByVal namelen As Integer, ByRef version As UInteger) As RESULT
            Return FMOD_System_GetPluginInfo(systemraw, handle, plugintype, name, namelen, version)
        End Function

        Public Function setOutputByPlugin(ByVal handle As UInteger) As RESULT
            Return FMOD_System_SetOutputByPlugin(systemraw, handle)
        End Function
        Public Function getOutputByPlugin(ByRef handle As UInteger) As RESULT
            Return FMOD_System_GetOutputByPlugin(systemraw, handle)
        End Function
        Public Function createDSPByPlugin(ByVal handle As UInteger, ByRef dsp As IntPtr) As RESULT
            Return FMOD_System_CreateDSPByPlugin(systemraw, handle, dsp)
        End Function
        Public Function createCodec(ByVal description As IntPtr, ByVal priority As UInteger) As RESULT
            Return FMOD_System_CreateCodec(systemraw, description, priority)
        End Function


        ' Init/Close 
        Public Function init(ByVal maxchannels As Integer, ByVal flags As INITFLAGS, ByVal extradriverdata As IntPtr) As RESULT
            Return FMOD_System_Init(systemraw, maxchannels, flags, extradriverdata)
        End Function
        Public Function close() As RESULT
            Return FMOD_System_Close(systemraw)
        End Function


        ' General post-init system functions
        Public Function update() As RESULT
            Return FMOD_System_Update(systemraw)
        End Function

        Public Function set3DSettings(ByVal dopplerscale As Single, ByVal distancefactor As Single, ByVal rolloffscale As Single) As RESULT
            Return FMOD_System_Set3DSettings(systemraw, dopplerscale, distancefactor, rolloffscale)
        End Function
        Public Function get3DSettings(ByRef dopplerscale As Single, ByRef distancefactor As Single, ByRef rolloffscale As Single) As RESULT
            Return FMOD_System_Get3DSettings(systemraw, dopplerscale, distancefactor, rolloffscale)
        End Function
        Public Function set3DNumListeners(ByVal numlisteners As Integer) As RESULT
            Return FMOD_System_Set3DNumListeners(systemraw, numlisteners)
        End Function
        Public Function get3DNumListeners(ByRef numlisteners As Integer) As RESULT
            Return FMOD_System_Get3DNumListeners(systemraw, numlisteners)
        End Function
        Public Function set3DListenerAttributes(ByVal listener As Integer, ByRef pos As VECTOR, ByRef vel As VECTOR, ByRef forward As VECTOR, ByRef up As VECTOR) As RESULT
            Return FMOD_System_Set3DListenerAttributes(systemraw, listener, pos, vel, forward, up)
        End Function
        Public Function get3DListenerAttributes(ByVal listener As Integer, ByRef pos As VECTOR, ByRef vel As VECTOR, ByRef forward As VECTOR, ByRef up As VECTOR) As RESULT
            Return FMOD_System_Get3DListenerAttributes(systemraw, listener, pos, vel, forward, up)
        End Function

        Public Function set3DRolloffCallback(ByVal callback As CB_3D_ROLLOFFCALLBACK) As RESULT
            Return FMOD_System_Set3DRolloffCallback(systemraw, callback)
        End Function
        Public Function set3DSpeakerPosition(ByVal speaker As SPEAKER, ByVal x As Single, ByVal y As Single, ByVal active As Boolean) As RESULT
            Return FMOD_System_Set3DSpeakerPosition(systemraw, speaker, x, y, (If(active, 1, 0)))
        End Function
        Public Function get3DSpeakerPosition(ByVal speaker As SPEAKER, ByRef x As Single, ByRef y As Single, ByRef active As Boolean) As RESULT
            Dim result As RESULT

            Dim isactive As Integer = 0

            result = FMOD_System_Get3DSpeakerPosition(systemraw, speaker, x, y, isactive)

            active = (isactive <> 0)

            Return result
        End Function

        Public Function setStreamBufferSize(ByVal filebuffersize As UInteger, ByVal filebuffersizetype As TIMEUNIT) As RESULT
            Return FMOD_System_SetStreamBufferSize(systemraw, filebuffersize, filebuffersizetype)
        End Function
        Public Function getStreamBufferSize(ByRef filebuffersize As UInteger, ByRef filebuffersizetype As TIMEUNIT) As RESULT
            Return FMOD_System_GetStreamBufferSize(systemraw, filebuffersize, filebuffersizetype)
        End Function


        ' System information functions.
        Public Function getVersion(ByRef version As UInteger) As RESULT
            Return FMOD_System_GetVersion(systemraw, version)
        End Function
        Public Function getOutputHandle(ByRef handle As IntPtr) As RESULT
            Return FMOD_System_GetOutputHandle(systemraw, handle)
        End Function
        Public Function getChannelsPlaying(ByRef channels As Integer) As RESULT
            Return FMOD_System_GetChannelsPlaying(systemraw, channels)
        End Function
        Public Function getHardwareChannels(ByRef numhardwarechannels As Integer) As RESULT
            Return FMOD_System_GetHardwareChannels(systemraw, numhardwarechannels)
        End Function
        Public Function getCPUUsage(ByRef dsp As Single, ByRef stream As Single, ByRef geometry As Single, ByRef update As Single, ByRef total As Single) As RESULT
            Return FMOD_System_GetCPUUsage(systemraw, dsp, stream, geometry, update, total)
        End Function
        Public Function getSoundRAM(ByRef currentalloced As Integer, ByRef maxalloced As Integer, ByRef total As Integer) As RESULT
            Return FMOD_System_GetSoundRAM(systemraw, currentalloced, maxalloced, total)
        End Function
        Public Function getNumCDROMDrives(ByRef numdrives As Integer) As RESULT
            Return FMOD_System_GetNumCDROMDrives(systemraw, numdrives)
        End Function
        Public Function getCDROMDriveName(ByVal drive As Integer, ByVal drivename As StringBuilder, ByVal drivenamelen As Integer, ByVal scsiname As StringBuilder, ByVal scsinamelen As Integer, ByVal devicename As StringBuilder, _
         ByVal devicenamelen As Integer) As RESULT
            Return FMOD_System_GetCDROMDriveName(systemraw, drive, drivename, drivenamelen, scsiname, scsinamelen, _
             devicename, devicenamelen)
        End Function
        Public Function getSpectrum(ByVal spectrumarray As Single(), ByVal numvalues As Integer, ByVal channeloffset As Integer, ByVal windowtype As DSP_FFT_WINDOW) As RESULT
            Return FMOD_System_GetSpectrum(systemraw, spectrumarray, numvalues, channeloffset, windowtype)
        End Function
        Public Function getWaveData(ByVal wavearray As Single(), ByVal numvalues As Integer, ByVal channeloffset As Integer) As RESULT
            Return FMOD_System_GetWaveData(systemraw, wavearray, numvalues, channeloffset)
        End Function


        ' Sound/DSP/Channel creation and retrieval. 
        Public Function createSound(ByVal name_or_data As String, ByVal mode As MODE, ByRef exinfo As CREATESOUNDEXINFO, ByRef sound As Sound) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim soundraw As New IntPtr()
            Dim soundnew As Sound = Nothing

            mode = mode Or FMOD.MODE.UNICODE

            Try
                result__1 = FMOD_System_CreateSound(systemraw, name_or_data, mode, exinfo, soundraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If sound Is Nothing Then
                soundnew = New Sound()
                soundnew.setRaw(soundraw)
                sound = soundnew
            Else
                sound.setRaw(soundraw)
            End If

            Return result__1
        End Function
        Public Function createSound(ByVal data As Byte(), ByVal mode As MODE, ByRef exinfo As CREATESOUNDEXINFO, ByRef sound As Sound) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim soundraw As New IntPtr()
            Dim soundnew As Sound = Nothing

            Try
                result__1 = FMOD_System_CreateSound(systemraw, data, mode, exinfo, soundraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If sound Is Nothing Then
                soundnew = New Sound()
                soundnew.setRaw(soundraw)
                sound = soundnew
            Else
                sound.setRaw(soundraw)
            End If

            Return result__1
        End Function
        Public Function createSound(ByVal name_or_data As String, ByVal mode As MODE, ByRef sound As Sound) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim soundraw As New IntPtr()
            Dim soundnew As Sound = Nothing

            mode = mode Or FMOD.MODE.UNICODE

            Try
                result__1 = FMOD_System_CreateSound(systemraw, name_or_data, mode, 0, soundraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If sound Is Nothing Then
                soundnew = New Sound()
                soundnew.setRaw(soundraw)
                sound = soundnew
            Else
                sound.setRaw(soundraw)
            End If

            Return result__1
        End Function
        Public Function createStream(ByVal name_or_data As String, ByVal mode As MODE, ByRef exinfo As CREATESOUNDEXINFO, ByRef sound As Sound) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim soundraw As New IntPtr()
            Dim soundnew As Sound = Nothing

            mode = mode Or FMOD.MODE.UNICODE

            Try
                result__1 = FMOD_System_CreateStream(systemraw, name_or_data, mode, exinfo, soundraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If sound Is Nothing Then
                soundnew = New Sound()
                soundnew.setRaw(soundraw)
                sound = soundnew
            Else
                sound.setRaw(soundraw)
            End If

            Return result__1
        End Function
        Public Function createStream(ByVal data As Byte(), ByVal mode As MODE, ByRef exinfo As CREATESOUNDEXINFO, ByRef sound As Sound) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim soundraw As New IntPtr()
            Dim soundnew As Sound = Nothing

            Try
                result__1 = FMOD_System_CreateStream(systemraw, data, mode, exinfo, soundraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If sound Is Nothing Then
                soundnew = New Sound()
                soundnew.setRaw(soundraw)
                sound = soundnew
            Else
                sound.setRaw(soundraw)
            End If

            Return result__1
        End Function
        Public Function createStream(ByVal name_or_data As String, ByVal mode As MODE, ByRef sound As Sound) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim soundraw As New IntPtr()
            Dim soundnew As Sound = Nothing

            mode = mode Or FMOD.MODE.UNICODE

            Try
                result__1 = FMOD_System_CreateStream(systemraw, name_or_data, mode, 0, soundraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If sound Is Nothing Then
                soundnew = New Sound()
                soundnew.setRaw(soundraw)
                sound = soundnew
            Else
                sound.setRaw(soundraw)
            End If

            Return result__1
        End Function
        Public Function createDSP(ByRef description As DSP_DESCRIPTION, ByRef dsp As DSP) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim dspraw As New IntPtr()
            Dim dspnew As DSP = Nothing

            Try
                result__1 = FMOD_System_CreateDSP(systemraw, description, dspraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If dsp Is Nothing Then
                dspnew = New DSP()
                dspnew.setRaw(dspraw)
                dsp = dspnew
            Else
                dsp.setRaw(dspraw)
            End If

            Return result__1
        End Function
        Public Function createDSPByType(ByVal type As DSP_TYPE, ByRef dsp As DSP) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim dspraw As New IntPtr()
            Dim dspnew As DSP = Nothing

            Try
                result__1 = FMOD_System_CreateDSPByType(systemraw, type, dspraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If dsp Is Nothing Then
                dspnew = New DSP()
                dspnew.setRaw(dspraw)
                dsp = dspnew
            Else
                dsp.setRaw(dspraw)
            End If

            Return result__1
        End Function
        Public Function createChannelGroup(ByVal name As String, ByRef channelgroup As ChannelGroup) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim channelgroupraw As New IntPtr()
            Dim channelgroupnew As ChannelGroup = Nothing

            Try
                result__1 = FMOD_System_CreateChannelGroup(systemraw, name, channelgroupraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If channelgroup Is Nothing Then
                channelgroupnew = New ChannelGroup()
                channelgroupnew.setRaw(channelgroupraw)
                channelgroup = channelgroupnew
            Else
                channelgroup.setRaw(channelgroupraw)
            End If

            Return result__1
        End Function
        Public Function createSoundGroup(ByVal name As String, ByRef soundgroup As SoundGroup) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim soundgroupraw As New IntPtr()
            Dim soundgroupnew As SoundGroup = Nothing

            Try
                result__1 = FMOD_System_CreateSoundGroup(systemraw, name, soundgroupraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If soundgroup Is Nothing Then
                soundgroupnew = New SoundGroup()
                soundgroupnew.setRaw(soundgroupraw)
                soundgroup = soundgroupnew
            Else
                soundgroup.setRaw(soundgroupraw)
            End If

            Return result__1
        End Function
        Public Function createReverb(ByRef reverb As Reverb) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim reverbraw As New IntPtr()
            Dim reverbnew As Reverb = Nothing

            Try
                result__1 = FMOD_System_CreateReverb(systemraw, reverbraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If reverb Is Nothing Then
                reverbnew = New Reverb()
                reverbnew.setRaw(reverbraw)
                reverb = reverbnew
            Else
                reverb.setRaw(reverbraw)
            End If

            Return result__1
        End Function
        Public Function playSound(ByVal channelid As CHANNELINDEX, ByVal sound As Sound, ByVal paused As Boolean, ByRef channel As Channel) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim channelraw As IntPtr
            Dim channelnew As Channel = Nothing

            If channel IsNot Nothing Then
                channelraw = channel.getRaw()
            Else
                channelraw = New IntPtr()
            End If

            Try
                result__1 = FMOD_System_PlaySound(systemraw, channelid, sound.getRaw(), (If(paused, 1, 0)), channelraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If channel Is Nothing Then
                channelnew = New Channel()
                channelnew.setRaw(channelraw)
                channel = channelnew
            Else
                channel.setRaw(channelraw)
            End If

            Return result__1
        End Function
        Public Function playDSP(ByVal channelid As CHANNELINDEX, ByVal dsp As DSP, ByVal paused As Boolean, ByRef channel As Channel) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim channelraw As IntPtr
            Dim channelnew As Channel = Nothing

            If channel IsNot Nothing Then
                channelraw = channel.getRaw()
            Else
                channelraw = New IntPtr()
            End If

            Try
                result__1 = FMOD_System_PlayDSP(systemraw, channelid, dsp.getRaw(), (If(paused, 1, 0)), channelraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If channel Is Nothing Then
                channelnew = New Channel()
                channelnew.setRaw(channelraw)
                channel = channelnew
            Else
                channel.setRaw(channelraw)
            End If

            Return result__1
        End Function
        Public Function getChannel(ByVal channelid As Integer, ByRef channel As Channel) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim channelraw As New IntPtr()
            Dim channelnew As Channel = Nothing

            Try
                result__1 = FMOD_System_GetChannel(systemraw, channelid, channelraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If channel Is Nothing Then
                channelnew = New Channel()
                channelnew.setRaw(channelraw)
                channel = channelnew
            Else
                channel.setRaw(channelraw)
            End If

            Return result__1
        End Function

        Public Function getMasterChannelGroup(ByRef channelgroup As ChannelGroup) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim channelgroupraw As New IntPtr()
            Dim channelgroupnew As ChannelGroup = Nothing

            Try
                result__1 = FMOD_System_GetMasterChannelGroup(systemraw, channelgroupraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If channelgroup Is Nothing Then
                channelgroupnew = New ChannelGroup()
                channelgroupnew.setRaw(channelgroupraw)
                channelgroup = channelgroupnew
            Else
                channelgroup.setRaw(channelgroupraw)
            End If

            Return result__1
        End Function

        Public Function getMasterSoundGroup(ByRef soundgroup As SoundGroup) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim soundgroupraw As New IntPtr()
            Dim soundgroupnew As SoundGroup = Nothing

            Try
                result__1 = FMOD_System_GetMasterSoundGroup(systemraw, soundgroupraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If soundgroup Is Nothing Then
                soundgroupnew = New SoundGroup()
                soundgroupnew.setRaw(soundgroupraw)
                soundgroup = soundgroupnew
            Else
                soundgroup.setRaw(soundgroupraw)
            End If

            Return result__1
        End Function

        ' Reverb api
        Public Function setReverbProperties(ByRef prop As REVERB_PROPERTIES) As RESULT
            Return FMOD_System_SetReverbProperties(systemraw, prop)
        End Function
        Public Function getReverbProperties(ByRef prop As REVERB_PROPERTIES) As RESULT
            Return FMOD_System_GetReverbProperties(systemraw, prop)
        End Function

        Public Function setReverbAmbientProperties(ByRef prop As REVERB_PROPERTIES) As RESULT
            Return FMOD_System_SetReverbAmbientProperties(systemraw, prop)
        End Function
        Public Function getReverbAmbientProperties(ByRef prop As REVERB_PROPERTIES) As RESULT
            Return FMOD_System_GetReverbAmbientProperties(systemraw, prop)
        End Function

        ' System level DSP access.
        Public Function getDSPHead(ByRef dsp As DSP) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim dspraw As New IntPtr()
            Dim dspnew As DSP = Nothing

            Try
                result__1 = FMOD_System_GetDSPHead(systemraw, dspraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If dsp Is Nothing Then
                dspnew = New DSP()
                dspnew.setRaw(dspraw)
                dsp = dspnew
            Else
                dsp.setRaw(dspraw)
            End If

            Return result__1
        End Function
        Public Function addDSP(ByVal dsp As DSP, ByRef connection As DSPConnection) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim dspconnectionraw As New IntPtr()
            Dim dspconnectionnew As DSPConnection = Nothing

            Try
                result__1 = FMOD_System_AddDSP(systemraw, dsp.getRaw(), dspconnectionraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If connection Is Nothing Then
                dspconnectionnew = New DSPConnection()
                dspconnectionnew.setRaw(dspconnectionraw)
                connection = dspconnectionnew
            Else
                connection.setRaw(dspconnectionraw)
            End If

            Return result__1
        End Function
        Public Function lockDSP() As RESULT
            Return FMOD_System_LockDSP(systemraw)
        End Function
        Public Function unlockDSP() As RESULT
            Return FMOD_System_UnlockDSP(systemraw)
        End Function
        Public Function getDSPClock(ByRef hi As UInteger, ByRef lo As UInteger) As RESULT
            Return FMOD_System_GetDSPClock(systemraw, hi, lo)
        End Function


        ' Recording api
        Public Function getRecordNumDrivers(ByRef numdrivers As Integer) As RESULT
            Return FMOD_System_GetRecordNumDrivers(systemraw, numdrivers)
        End Function
        Public Function getRecordDriverInfo(ByVal id As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal name As StringBuilder, ByVal namelen As Integer, ByRef guid As GUID) As RESULT
            'use multibyte version
            Return FMOD_System_GetRecordDriverInfoW(systemraw, id, name, namelen, guid)
        End Function
        Public Function getRecordDriverCaps(ByVal id As Integer, ByRef caps As CAPS, ByRef minfrequency As Integer, ByRef maxfrequency As Integer) As RESULT
            Return FMOD_System_GetRecordDriverCaps(systemraw, id, caps, minfrequency, maxfrequency)
        End Function
        Public Function getRecordPosition(ByVal id As Integer, ByRef position As UInteger) As RESULT
            Return FMOD_System_GetRecordPosition(systemraw, id, position)
        End Function

        Public Function recordStart(ByVal id As Integer, ByVal sound As Sound, ByVal [loop] As Boolean) As RESULT
            Return FMOD_System_RecordStart(systemraw, id, sound.getRaw(), (If([loop], 1, 0)))
        End Function
        Public Function recordStop(ByVal id As Integer) As RESULT
            Return FMOD_System_RecordStop(systemraw, id)
        End Function
        Public Function isRecording(ByVal id As Integer, ByRef recording As Boolean) As RESULT
            Dim result As RESULT
            Dim r As Integer = 0

            result = FMOD_System_IsRecording(systemraw, id, r)

            recording = (r <> 0)

            Return result
        End Function


        ' Geometry api 
        Public Function createGeometry(ByVal maxpolygons As Integer, ByVal maxvertices As Integer, ByRef geometry As Geometry) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim geometryraw As New IntPtr()
            Dim geometrynew As Geometry = Nothing

            Try
                result__1 = FMOD_System_CreateGeometry(systemraw, maxpolygons, maxvertices, geometryraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If geometry Is Nothing Then
                geometrynew = New Geometry()
                geometrynew.setRaw(geometryraw)
                geometry = geometrynew
            Else
                geometry.setRaw(geometryraw)
            End If

            Return result__1
        End Function
        Public Function setGeometrySettings(ByVal maxworldsize As Single) As RESULT
            Return FMOD_System_SetGeometrySettings(systemraw, maxworldsize)
        End Function
        Public Function getGeometrySettings(ByRef maxworldsize As Single) As RESULT
            Return FMOD_System_GetGeometrySettings(systemraw, maxworldsize)
        End Function
        Public Function loadGeometry(ByVal data As IntPtr, ByVal datasize As Integer, ByRef geometry As Geometry) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim geometryraw As New IntPtr()
            Dim geometrynew As Geometry = Nothing

            Try
                result__1 = FMOD_System_LoadGeometry(systemraw, data, datasize, geometryraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If geometry Is Nothing Then
                geometrynew = New Geometry()
                geometrynew.setRaw(geometryraw)
                geometry = geometrynew
            Else
                geometry.setRaw(geometryraw)
            End If

            Return result__1
        End Function
        Public Function getGeometryOcclusion(ByRef listener As VECTOR, ByRef source As VECTOR, ByRef direct As Single, ByRef reverb As Single) As RESULT
            Return FMOD_System_GetGeometryOcclusion(systemraw, listener, source, direct, reverb)
        End Function

        ' Network functions
        Public Function setNetworkProxy(ByVal proxy As String) As RESULT
            Return FMOD_System_SetNetworkProxy(systemraw, proxy)
        End Function
        Public Function getNetworkProxy(ByVal proxy As StringBuilder, ByVal proxylen As Integer) As RESULT
            Return FMOD_System_GetNetworkProxy(systemraw, proxy, proxylen)
        End Function
        Public Function setNetworkTimeout(ByVal timeout As Integer) As RESULT
            Return FMOD_System_SetNetworkTimeout(systemraw, timeout)
        End Function
        Public Function getNetworkTimeout(ByRef timeout As Integer) As RESULT
            Return FMOD_System_GetNetworkTimeout(systemraw, timeout)
        End Function

        ' Userdata set/get                         
        Public Function setUserData(ByVal userdata As IntPtr) As RESULT
            Return FMOD_System_SetUserData(systemraw, userdata)
        End Function
        Public Function getUserData(ByRef userdata As IntPtr) As RESULT
            Return FMOD_System_GetUserData(systemraw, userdata)
        End Function

        Public Function getMemoryInfo(ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
            Return FMOD_System_GetMemoryInfo(systemraw, memorybits, event_memorybits, memoryused, memoryused_details)
        End Function


#Region "importfunctions"

        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_Release(ByVal system As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetOutput(ByVal system As IntPtr, ByVal output As OUTPUTTYPE) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetOutput(ByVal system As IntPtr, ByRef output As OUTPUTTYPE) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetNumDrivers(ByVal system As IntPtr, ByRef numdrivers As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetDriverInfo(ByVal system As IntPtr, ByVal id As Integer, ByVal name As StringBuilder, ByVal namelen As Integer, ByRef guid As GUID) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetDriverInfoW(ByVal system As IntPtr, ByVal id As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal name As StringBuilder, ByVal namelen As Integer, ByRef guid As GUID) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetDriverCaps(ByVal system As IntPtr, ByVal id As Integer, ByRef caps As CAPS, ByRef controlpaneloutputrate As Integer, ByRef controlpanelspeakermode As SPEAKERMODE) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetDriver(ByVal system As IntPtr, ByVal driver As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetDriver(ByVal system As IntPtr, ByRef driver As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetHardwareChannels(ByVal system As IntPtr, ByVal numhardwarechannels As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetHardwareChannels(ByVal system As IntPtr, ByRef numhardwarechannels As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetSoftwareChannels(ByVal system As IntPtr, ByVal numsoftwarechannels As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetSoftwareChannels(ByVal system As IntPtr, ByRef numsoftwarechannels As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetSoftwareFormat(ByVal system As IntPtr, ByVal samplerate As Integer, ByVal format As SOUND_FORMAT, ByVal numoutputchannels As Integer, ByVal maxinputchannels As Integer, ByVal resamplemethod As DSP_RESAMPLER) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetSoftwareFormat(ByVal system As IntPtr, ByRef samplerate As Integer, ByRef format As SOUND_FORMAT, ByRef numoutputchannels As Integer, ByRef maxinputchannels As Integer, ByRef resamplemethod As DSP_RESAMPLER, _
   ByRef bits As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetDSPBufferSize(ByVal system As IntPtr, ByVal bufferlength As UInteger, ByVal numbuffers As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetDSPBufferSize(ByVal system As IntPtr, ByRef bufferlength As UInteger, ByRef numbuffers As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetFileSystem(ByVal system As IntPtr, ByVal useropen As FILE_OPENCALLBACK, ByVal userclose As FILE_CLOSECALLBACK, ByVal userread As FILE_READCALLBACK, ByVal userseek As FILE_SEEKCALLBACK, ByVal userasyncread As FILE_ASYNCREADCALLBACK, _
   ByVal userasynccancel As FILE_ASYNCCANCELCALLBACK, ByVal blockalign As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_AttachFileSystem(ByVal system As IntPtr, ByVal useropen As FILE_OPENCALLBACK, ByVal userclose As FILE_CLOSECALLBACK, ByVal userread As FILE_READCALLBACK, ByVal userseek As FILE_SEEKCALLBACK) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetPluginPath(ByVal system As IntPtr, ByVal path As String) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_LoadPlugin(ByVal system As IntPtr, ByVal filename As String, ByRef handle As UInteger, ByVal priority As UInteger) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_UnloadPlugin(ByVal system As IntPtr, ByVal handle As UInteger) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetNumPlugins(ByVal system As IntPtr, ByVal plugintype As PLUGINTYPE, ByRef numplugins As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetPluginHandle(ByVal system As IntPtr, ByVal plugintype As PLUGINTYPE, ByVal index As Integer, ByRef handle As UInteger) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetPluginInfo(ByVal system As IntPtr, ByVal handle As UInteger, ByRef plugintype As PLUGINTYPE, ByVal name As StringBuilder, ByVal namelen As Integer, ByRef version__1 As UInteger) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_CreateDSPByPlugin(ByVal system As IntPtr, ByVal handle As UInteger, ByRef dsp As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_CreateCodec(ByVal system As IntPtr, ByVal description As IntPtr, ByVal priority As UInteger) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetOutputByPlugin(ByVal system As IntPtr, ByVal handle As UInteger) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetOutputByPlugin(ByVal system As IntPtr, ByRef handle As UInteger) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_Init(ByVal system As IntPtr, ByVal maxchannels As Integer, ByVal flags As INITFLAGS, ByVal extradriverdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_Close(ByVal system As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_Update(ByVal system As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_UpdateFinished(ByVal system As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetAdvancedSettings(ByVal system As IntPtr, ByRef settings As ADVANCEDSETTINGS) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetAdvancedSettings(ByVal system As IntPtr, ByRef settings As ADVANCEDSETTINGS) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetSpeakerMode(ByVal system As IntPtr, ByVal speakermode As SPEAKERMODE) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetSpeakerMode(ByVal system As IntPtr, ByRef speakermode As SPEAKERMODE) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_Set3DRolloffCallback(ByVal system As IntPtr, ByVal callback As CB_3D_ROLLOFFCALLBACK) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetCallback(ByVal system As IntPtr, ByVal callback As SYSTEM_CALLBACK) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_Set3DSpeakerPosition(ByVal system As IntPtr, ByVal speaker As SPEAKER, ByVal x As Single, ByVal y As Single, ByVal active As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_Get3DSpeakerPosition(ByVal system As IntPtr, ByVal speaker As SPEAKER, ByRef x As Single, ByRef y As Single, ByRef active As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_Set3DSettings(ByVal system As IntPtr, ByVal dopplerscale As Single, ByVal distancefactor As Single, ByVal rolloffscale As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_Get3DSettings(ByVal system As IntPtr, ByRef dopplerscale As Single, ByRef distancefactor As Single, ByRef rolloffscale As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_Set3DNumListeners(ByVal system As IntPtr, ByVal numlisteners As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_Get3DNumListeners(ByVal system As IntPtr, ByRef numlisteners As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_Set3DListenerAttributes(ByVal system As IntPtr, ByVal listener As Integer, ByRef pos As VECTOR, ByRef vel As VECTOR, ByRef forward As VECTOR, ByRef up As VECTOR) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_Get3DListenerAttributes(ByVal system As IntPtr, ByVal listener As Integer, ByRef pos As VECTOR, ByRef vel As VECTOR, ByRef forward As VECTOR, ByRef up As VECTOR) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetFileBufferSize(ByVal system As IntPtr, ByVal sizebytes As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetFileBufferSize(ByVal system As IntPtr, ByRef sizebytes As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetStreamBufferSize(ByVal system As IntPtr, ByVal filebuffersize As UInteger, ByVal filebuffersizetype As TIMEUNIT) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetStreamBufferSize(ByVal system As IntPtr, ByRef filebuffersize As UInteger, ByRef filebuffersizetype As TIMEUNIT) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetVersion(ByVal system As IntPtr, ByRef version__1 As UInteger) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetOutputHandle(ByVal system As IntPtr, ByRef handle As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetChannelsPlaying(ByVal system As IntPtr, ByRef channels As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetCPUUsage(ByVal system As IntPtr, ByRef dsp As Single, ByRef stream As Single, ByRef geometry As Single, ByRef update As Single, ByRef total As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetSoundRAM(ByVal system As IntPtr, ByRef currentalloced As Integer, ByRef maxalloced As Integer, ByRef total As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetNumCDROMDrives(ByVal system As IntPtr, ByRef numdrives As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetCDROMDriveName(ByVal system As IntPtr, ByVal drive As Integer, ByVal drivename As StringBuilder, ByVal drivenamelen As Integer, ByVal scsiname As StringBuilder, ByVal scsinamelen As Integer, _
   ByVal devicename As StringBuilder, ByVal devicenamelen As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetSpectrum(ByVal system As IntPtr, <MarshalAs(UnmanagedType.LPArray)> ByVal spectrumarray As Single(), ByVal numvalues As Integer, ByVal channeloffset As Integer, ByVal windowtype As DSP_FFT_WINDOW) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetWaveData(ByVal system As IntPtr, <MarshalAs(UnmanagedType.LPArray)> ByVal wavearray As Single(), ByVal numvalues As Integer, ByVal channeloffset As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll, CharSet:=CharSet.Unicode)> _
        Private Shared Function FMOD_System_CreateSound(ByVal system As IntPtr, ByVal name_or_data As String, ByVal mode As MODE, ByRef exinfo As CREATESOUNDEXINFO, ByRef sound As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll, CharSet:=CharSet.Unicode)> _
        Private Shared Function FMOD_System_CreateStream(ByVal system As IntPtr, ByVal name_or_data As String, ByVal mode As MODE, ByRef exinfo As CREATESOUNDEXINFO, ByRef sound As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll, CharSet:=CharSet.Unicode)> _
        Private Shared Function FMOD_System_CreateSound(ByVal system As IntPtr, ByVal name_or_data As String, ByVal mode As MODE, ByVal exinfo As Integer, ByRef sound As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll, CharSet:=CharSet.Unicode)> _
        Private Shared Function FMOD_System_CreateStream(ByVal system As IntPtr, ByVal name_or_data As String, ByVal mode As MODE, ByVal exinfo As Integer, ByRef sound As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_CreateSound(ByVal system As IntPtr, ByVal name_or_data As Byte(), ByVal mode As MODE, ByRef exinfo As CREATESOUNDEXINFO, ByRef sound As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_CreateStream(ByVal system As IntPtr, ByVal name_or_data As Byte(), ByVal mode As MODE, ByRef exinfo As CREATESOUNDEXINFO, ByRef sound As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_CreateSound(ByVal system As IntPtr, ByVal name_or_data As Byte(), ByVal mode As MODE, ByVal exinfo As Integer, ByRef sound As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_CreateStream(ByVal system As IntPtr, ByVal name_or_data As Byte(), ByVal mode As MODE, ByVal exinfo As Integer, ByRef sound As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_CreateDSP(ByVal system As IntPtr, ByRef description As DSP_DESCRIPTION, ByRef dsp As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_CreateDSPByType(ByVal system As IntPtr, ByVal type As DSP_TYPE, ByRef dsp As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_CreateChannelGroup(ByVal system As IntPtr, ByVal name As String, ByRef channelgroup As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_CreateSoundGroup(ByVal system As IntPtr, ByVal name As String, ByRef soundgroup As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_CreateReverb(ByVal system As IntPtr, ByRef reverb As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_PlaySound(ByVal system As IntPtr, ByVal channelid As CHANNELINDEX, ByVal sound As IntPtr, ByVal paused As Integer, ByRef channel As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_PlayDSP(ByVal system As IntPtr, ByVal channelid As CHANNELINDEX, ByVal dsp As IntPtr, ByVal paused As Integer, ByRef channel As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetChannel(ByVal system As IntPtr, ByVal channelid As Integer, ByRef channel As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetMasterChannelGroup(ByVal system As IntPtr, ByRef channelgroup As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetMasterSoundGroup(ByVal system As IntPtr, ByRef soundgroup As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetReverbProperties(ByVal system As IntPtr, ByRef prop As REVERB_PROPERTIES) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetReverbProperties(ByVal system As IntPtr, ByRef prop As REVERB_PROPERTIES) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetReverbAmbientProperties(ByVal system As IntPtr, ByRef prop As REVERB_PROPERTIES) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetReverbAmbientProperties(ByVal system As IntPtr, ByRef prop As REVERB_PROPERTIES) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetDSPHead(ByVal system As IntPtr, ByRef dsp As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_AddDSP(ByVal system As IntPtr, ByVal dsp As IntPtr, ByRef connection As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_LockDSP(ByVal system As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_UnlockDSP(ByVal system As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetDSPClock(ByVal system As IntPtr, ByRef hi As UInteger, ByRef lo As UInteger) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetRecordNumDrivers(ByVal system As IntPtr, ByRef numdrivers As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetRecordDriverInfo(ByVal system As IntPtr, ByVal id As Integer, ByVal name As StringBuilder, ByVal namelen As Integer, ByRef guid As GUID) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetRecordDriverInfoW(ByVal system As IntPtr, ByVal id As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal name As StringBuilder, ByVal namelen As Integer, ByRef guid As GUID) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetRecordDriverCaps(ByVal system As IntPtr, ByVal id As Integer, ByRef caps As CAPS, ByRef minfrequency As Integer, ByRef maxfrequency As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetRecordPosition(ByVal system As IntPtr, ByVal id As Integer, ByRef position As UInteger) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_RecordStart(ByVal system As IntPtr, ByVal id As Integer, ByVal sound As IntPtr, ByVal [loop] As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_RecordStop(ByVal system As IntPtr, ByVal id As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_IsRecording(ByVal system As IntPtr, ByVal id As Integer, ByRef recording As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_CreateGeometry(ByVal system As IntPtr, ByVal maxpolygons As Integer, ByVal maxvertices As Integer, ByRef geometry As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetGeometrySettings(ByVal system As IntPtr, ByVal maxworldsize As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetGeometrySettings(ByVal system As IntPtr, ByRef maxworldsize As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_LoadGeometry(ByVal system As IntPtr, ByVal data As IntPtr, ByVal datasize As Integer, ByRef geometry As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetGeometryOcclusion(ByVal system As IntPtr, ByRef listener As VECTOR, ByRef source As VECTOR, ByRef direct As Single, ByRef reverb As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetNetworkProxy(ByVal system As IntPtr, ByVal proxy As String) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetNetworkProxy(ByVal system As IntPtr, ByVal proxy As StringBuilder, ByVal proxylen As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetNetworkTimeout(ByVal system As IntPtr, ByVal timeout As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetNetworkTimeout(ByVal system As IntPtr, ByRef timeout As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_SetUserData(ByVal system As IntPtr, ByVal userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetUserData(ByVal system As IntPtr, ByRef userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_System_GetMemoryInfo(ByVal system As IntPtr, ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
        End Function

#End Region

#Region "wrapperinternal"

        Private systemraw As IntPtr

        Public Sub setRaw(ByVal system As IntPtr)
            systemraw = New IntPtr()

            systemraw = system
        End Sub

        Public Function getRaw() As IntPtr
            Return systemraw
        End Function

#End Region
    End Class


    '
    '        'Sound' API
    '    

    Public Class Sound
        Public Function release() As RESULT
            Return FMOD_Sound_Release(soundraw)
        End Function
        Public Function getSystemObject(ByRef system As System) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim systemraw As New IntPtr()
            Dim systemnew As System = Nothing

            Try
                result__1 = FMOD_Sound_GetSystemObject(soundraw, systemraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If system Is Nothing Then
                systemnew = New System()
                systemnew.setRaw(systemraw)
                system = systemnew
            Else
                system.setRaw(systemraw)
            End If
            Return result__1
        End Function


        Public Function lock(ByVal offset As UInteger, ByVal length As UInteger, ByRef ptr1 As IntPtr, ByRef ptr2 As IntPtr, ByRef len1 As UInteger, ByRef len2 As UInteger) As RESULT
            Return FMOD_Sound_Lock(soundraw, offset, length, ptr1, ptr2, len1, _
             len2)
        End Function
        Public Function unlock(ByVal ptr1 As IntPtr, ByVal ptr2 As IntPtr, ByVal len1 As UInteger, ByVal len2 As UInteger) As RESULT
            Return FMOD_Sound_Unlock(soundraw, ptr1, ptr2, len1, len2)
        End Function
        Public Function setDefaults(ByVal frequency As Single, ByVal volume As Single, ByVal pan As Single, ByVal priority As Integer) As RESULT
            Return FMOD_Sound_SetDefaults(soundraw, frequency, volume, pan, priority)
        End Function
        Public Function getDefaults(ByRef frequency As Single, ByRef volume As Single, ByRef pan As Single, ByRef priority As Integer) As RESULT
            Return FMOD_Sound_GetDefaults(soundraw, frequency, volume, pan, priority)
        End Function
        Public Function setVariations(ByVal frequencyvar As Single, ByVal volumevar As Single, ByVal panvar As Single) As RESULT
            Return FMOD_Sound_SetVariations(soundraw, frequencyvar, volumevar, panvar)
        End Function
        Public Function getVariations(ByRef frequencyvar As Single, ByRef volumevar As Single, ByRef panvar As Single) As RESULT
            Return FMOD_Sound_GetVariations(soundraw, frequencyvar, volumevar, panvar)
        End Function
        Public Function set3DMinMaxDistance(ByVal min As Single, ByVal max As Single) As RESULT
            Return FMOD_Sound_Set3DMinMaxDistance(soundraw, min, max)
        End Function
        Public Function get3DMinMaxDistance(ByRef min As Single, ByRef max As Single) As RESULT
            Return FMOD_Sound_Get3DMinMaxDistance(soundraw, min, max)
        End Function
        Public Function set3DConeSettings(ByVal insideconeangle As Single, ByVal outsideconeangle As Single, ByVal outsidevolume As Single) As RESULT
            Return FMOD_Sound_Set3DConeSettings(soundraw, insideconeangle, outsideconeangle, outsidevolume)
        End Function
        Public Function get3DConeSettings(ByRef insideconeangle As Single, ByRef outsideconeangle As Single, ByRef outsidevolume As Single) As RESULT
            Return FMOD_Sound_Get3DConeSettings(soundraw, insideconeangle, outsideconeangle, outsidevolume)
        End Function
        Public Function set3DCustomRolloff(ByRef points As VECTOR, ByVal numpoints As Integer) As RESULT
            Return FMOD_Sound_Set3DCustomRolloff(soundraw, points, numpoints)
        End Function
        Public Function get3DCustomRolloff(ByRef points As IntPtr, ByRef numpoints As Integer) As RESULT
            Return FMOD_Sound_Get3DCustomRolloff(soundraw, points, numpoints)
        End Function
        Public Function setSubSound(ByVal index As Integer, ByVal subsound As Sound) As RESULT
            Dim subsoundraw As IntPtr = subsound.getRaw()

            Return FMOD_Sound_SetSubSound(soundraw, index, subsoundraw)
        End Function
        Public Function getSubSound(ByVal index As Integer, ByRef subsound As Sound) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim subsoundraw As New IntPtr()
            Dim subsoundnew As Sound = Nothing

            Try
                result__1 = FMOD_Sound_GetSubSound(soundraw, index, subsoundraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If subsound Is Nothing Then
                subsoundnew = New Sound()
                subsoundnew.setRaw(subsoundraw)
                subsound = subsoundnew
            Else
                subsound.setRaw(subsoundraw)
            End If

            Return result__1
        End Function
        Public Function setSubSoundSentence(ByVal subsoundlist As Integer(), ByVal numsubsounds As Integer) As RESULT
            Return FMOD_Sound_SetSubSoundSentence(soundraw, subsoundlist, numsubsounds)
        End Function
        Public Function getName(ByVal name As StringBuilder, ByVal namelen As Integer) As RESULT
            Return FMOD_Sound_GetName(soundraw, name, namelen)
        End Function
        Public Function getLength(ByRef length As UInteger, ByVal lengthtype As TIMEUNIT) As RESULT
            Return FMOD_Sound_GetLength(soundraw, length, lengthtype)
        End Function
        Public Function getFormat(ByRef type As SOUND_TYPE, ByRef format As SOUND_FORMAT, ByRef channels As Integer, ByRef bits As Integer) As RESULT
            Return FMOD_Sound_GetFormat(soundraw, type, format, channels, bits)
        End Function
        Public Function getNumSubSounds(ByRef numsubsounds As Integer) As RESULT
            Return FMOD_Sound_GetNumSubSounds(soundraw, numsubsounds)
        End Function
        Public Function getNumTags(ByRef numtags As Integer, ByRef numtagsupdated As Integer) As RESULT
            Return FMOD_Sound_GetNumTags(soundraw, numtags, numtagsupdated)
        End Function
        Public Function getTag(ByVal name As String, ByVal index As Integer, ByRef tag As TAG) As RESULT
            Return FMOD_Sound_GetTag(soundraw, name, index, tag)
        End Function
        Public Function getOpenState(ByRef openstate As OPENSTATE, ByRef percentbuffered As UInteger, ByRef starving As Boolean, ByRef diskbusy As Boolean) As RESULT
            Dim result As RESULT
            Dim s As Integer = 0
            Dim b As Integer = 0

            result = FMOD_Sound_GetOpenState(soundraw, openstate, percentbuffered, s, b)

            starving = (s <> 0)
            diskbusy = (b <> 0)

            Return result
        End Function
        Public Function readData(ByVal buffer As IntPtr, ByVal lenbytes As UInteger, ByRef read As UInteger) As RESULT
            Return FMOD_Sound_ReadData(soundraw, buffer, lenbytes, read)
        End Function
        Public Function seekData(ByVal pcm As UInteger) As RESULT
            Return FMOD_Sound_SeekData(soundraw, pcm)
        End Function


        Public Function setSoundGroup(ByVal soundgroup As SoundGroup) As RESULT
            Return FMOD_Sound_SetSoundGroup(soundraw, soundgroup.getRaw())
        End Function
        Public Function getSoundGroup(ByRef soundgroup As SoundGroup) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim soundgroupraw As New IntPtr()
            Dim soundgroupnew As SoundGroup = Nothing

            Try
                result__1 = FMOD_Sound_GetSoundGroup(soundraw, soundgroupraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If soundgroup Is Nothing Then
                soundgroupnew = New SoundGroup()
                soundgroupnew.setRaw(soundgroupraw)
                soundgroup = soundgroupnew
            Else
                soundgroup.setRaw(soundgroupraw)
            End If

            Return result__1
        End Function


        Public Function getNumSyncPoints(ByRef numsyncpoints As Integer) As RESULT
            Return FMOD_Sound_GetNumSyncPoints(soundraw, numsyncpoints)
        End Function
        Public Function getSyncPoint(ByVal index As Integer, ByRef point As IntPtr) As RESULT
            Return FMOD_Sound_GetSyncPoint(soundraw, index, point)
        End Function
        Public Function getSyncPointInfo(ByVal point As IntPtr, ByVal name As StringBuilder, ByVal namelen As Integer, ByRef offset As UInteger, ByVal offsettype As TIMEUNIT) As RESULT
            Return FMOD_Sound_GetSyncPointInfo(soundraw, point, name, namelen, offset, offsettype)
        End Function
        Public Function addSyncPoint(ByVal offset As UInteger, ByVal offsettype As TIMEUNIT, ByVal name As String, ByRef point As IntPtr) As RESULT
            Return FMOD_Sound_AddSyncPoint(soundraw, offset, offsettype, name, point)
        End Function
        Public Function deleteSyncPoint(ByVal point As IntPtr) As RESULT
            Return FMOD_Sound_DeleteSyncPoint(soundraw, point)
        End Function


        Public Function setMode(ByVal mode As MODE) As RESULT
            Return FMOD_Sound_SetMode(soundraw, mode)
        End Function
        Public Function getMode(ByRef mode As MODE) As RESULT
            Return FMOD_Sound_GetMode(soundraw, mode)
        End Function
        Public Function setLoopCount(ByVal loopcount As Integer) As RESULT
            Return FMOD_Sound_SetLoopCount(soundraw, loopcount)
        End Function
        Public Function getLoopCount(ByRef loopcount As Integer) As RESULT
            Return FMOD_Sound_GetLoopCount(soundraw, loopcount)
        End Function
        Public Function setLoopPoints(ByVal loopstart As UInteger, ByVal loopstarttype As TIMEUNIT, ByVal loopend As UInteger, ByVal loopendtype As TIMEUNIT) As RESULT
            Return FMOD_Sound_SetLoopPoints(soundraw, loopstart, loopstarttype, loopend, loopendtype)
        End Function
        Public Function getLoopPoints(ByRef loopstart As UInteger, ByVal loopstarttype As TIMEUNIT, ByRef loopend As UInteger, ByVal loopendtype As TIMEUNIT) As RESULT
            Return FMOD_Sound_GetLoopPoints(soundraw, loopstart, loopstarttype, loopend, loopendtype)
        End Function

        Public Function getMusicNumChannels(ByRef numchannels As Integer) As RESULT
            Return FMOD_Sound_GetMusicNumChannels(soundraw, numchannels)
        End Function
        Public Function setMusicChannelVolume(ByVal channel As Integer, ByVal volume As Single) As RESULT
            Return FMOD_Sound_SetMusicChannelVolume(soundraw, channel, volume)
        End Function
        Public Function getMusicChannelVolume(ByVal channel As Integer, ByRef volume As Single) As RESULT
            Return FMOD_Sound_GetMusicChannelVolume(soundraw, channel, volume)
        End Function
        Public Function setMusicSpeed(ByVal speed As Single) As RESULT
            Return FMOD_Sound_SetMusicSpeed(soundraw, speed)
        End Function
        Public Function getMusicSpeed(ByRef speed As Single) As RESULT
            Return FMOD_Sound_GetMusicSpeed(soundraw, speed)
        End Function

        Public Function setUserData(ByVal userdata As IntPtr) As RESULT
            Return FMOD_Sound_SetUserData(soundraw, userdata)
        End Function
        Public Function getUserData(ByRef userdata As IntPtr) As RESULT
            Return FMOD_Sound_GetUserData(soundraw, userdata)
        End Function

        Public Function getMemoryInfo(ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
            Return FMOD_Sound_GetMemoryInfo(soundraw, memorybits, event_memorybits, memoryused, memoryused_details)
        End Function


#Region "importfunctions"

        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_Release(ByVal sound As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetSystemObject(ByVal sound As IntPtr, ByRef system As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_Lock(ByVal sound As IntPtr, ByVal offset As UInteger, ByVal length As UInteger, ByRef ptr1 As IntPtr, ByRef ptr2 As IntPtr, ByRef len1 As UInteger, _
   ByRef len2 As UInteger) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_Unlock(ByVal sound As IntPtr, ByVal ptr1 As IntPtr, ByVal ptr2 As IntPtr, ByVal len1 As UInteger, ByVal len2 As UInteger) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_SetDefaults(ByVal sound As IntPtr, ByVal frequency As Single, ByVal volume As Single, ByVal pan As Single, ByVal priority As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetDefaults(ByVal sound As IntPtr, ByRef frequency As Single, ByRef volume As Single, ByRef pan As Single, ByRef priority As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_SetVariations(ByVal sound As IntPtr, ByVal frequencyvar As Single, ByVal volumevar As Single, ByVal panvar As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetVariations(ByVal sound As IntPtr, ByRef frequencyvar As Single, ByRef volumevar As Single, ByRef panvar As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_Set3DMinMaxDistance(ByVal sound As IntPtr, ByVal min As Single, ByVal max As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_Get3DMinMaxDistance(ByVal sound As IntPtr, ByRef min As Single, ByRef max As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_Set3DConeSettings(ByVal sound As IntPtr, ByVal insideconeangle As Single, ByVal outsideconeangle As Single, ByVal outsidevolume As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_Get3DConeSettings(ByVal sound As IntPtr, ByRef insideconeangle As Single, ByRef outsideconeangle As Single, ByRef outsidevolume As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_Set3DCustomRolloff(ByVal sound As IntPtr, ByRef points As VECTOR, ByVal numpoints As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_Get3DCustomRolloff(ByVal sound As IntPtr, ByRef points As IntPtr, ByRef numpoints As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_SetSubSound(ByVal sound As IntPtr, ByVal index As Integer, ByVal subsound As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetSubSound(ByVal sound As IntPtr, ByVal index As Integer, ByRef subsound As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_SetSubSoundSentence(ByVal sound As IntPtr, ByVal subsoundlist As Integer(), ByVal numsubsounds As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetName(ByVal sound As IntPtr, ByVal name As StringBuilder, ByVal namelen As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetLength(ByVal sound As IntPtr, ByRef length As UInteger, ByVal lengthtype As TIMEUNIT) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetFormat(ByVal sound As IntPtr, ByRef type As SOUND_TYPE, ByRef format As SOUND_FORMAT, ByRef channels As Integer, ByRef bits As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetNumSubSounds(ByVal sound As IntPtr, ByRef numsubsounds As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetNumTags(ByVal sound As IntPtr, ByRef numtags As Integer, ByRef numtagsupdated As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetTag(ByVal sound As IntPtr, ByVal name As String, ByVal index As Integer, ByRef tag As TAG) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetOpenState(ByVal sound As IntPtr, ByRef openstate As OPENSTATE, ByRef percentbuffered As UInteger, ByRef starving As Integer, ByRef diskbusy As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_ReadData(ByVal sound As IntPtr, ByVal buffer As IntPtr, ByVal lenbytes As UInteger, ByRef read As UInteger) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_SeekData(ByVal sound As IntPtr, ByVal pcm As UInteger) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_SetSoundGroup(ByVal sound As IntPtr, ByVal soundgroup As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetSoundGroup(ByVal sound As IntPtr, ByRef soundgroup As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetNumSyncPoints(ByVal sound As IntPtr, ByRef numsyncpoints As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetSyncPoint(ByVal sound As IntPtr, ByVal index As Integer, ByRef point As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetSyncPointInfo(ByVal sound As IntPtr, ByVal point As IntPtr, ByVal name As StringBuilder, ByVal namelen As Integer, ByRef offset As UInteger, ByVal offsettype As TIMEUNIT) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_AddSyncPoint(ByVal sound As IntPtr, ByVal offset As UInteger, ByVal offsettype As TIMEUNIT, ByVal name As String, ByRef point As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_DeleteSyncPoint(ByVal sound As IntPtr, ByVal point As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_SetMode(ByVal sound As IntPtr, ByVal mode As MODE) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetMode(ByVal sound As IntPtr, ByRef mode As MODE) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_SetLoopCount(ByVal sound As IntPtr, ByVal loopcount As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetLoopCount(ByVal sound As IntPtr, ByRef loopcount As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_SetLoopPoints(ByVal sound As IntPtr, ByVal loopstart As UInteger, ByVal loopstarttype As TIMEUNIT, ByVal loopend As UInteger, ByVal loopendtype As TIMEUNIT) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetLoopPoints(ByVal sound As IntPtr, ByRef loopstart As UInteger, ByVal loopstarttype As TIMEUNIT, ByRef loopend As UInteger, ByVal loopendtype As TIMEUNIT) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetMusicNumChannels(ByVal sound As IntPtr, ByRef numchannels As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_SetMusicChannelVolume(ByVal sound As IntPtr, ByVal channel As Integer, ByVal volume As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetMusicChannelVolume(ByVal sound As IntPtr, ByVal channel As Integer, ByRef volume As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_SetMusicSpeed(ByVal sound As IntPtr, ByVal speed As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetMusicSpeed(ByVal sound As IntPtr, ByRef speed As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_SetUserData(ByVal sound As IntPtr, ByVal userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetUserData(ByVal sound As IntPtr, ByRef userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Sound_GetMemoryInfo(ByVal sound As IntPtr, ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
        End Function
#End Region

#Region "wrapperinternal"

        Private soundraw As IntPtr

        Public Sub setRaw(ByVal sound As IntPtr)
            soundraw = New IntPtr()
            soundraw = sound
        End Sub

        Public Function getRaw() As IntPtr
            Return soundraw
        End Function

#End Region
    End Class


    '
    '        'Channel' API
    '    

    Public Class Channel
        Public Function getSystemObject(ByRef system As System) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim systemraw As New IntPtr()
            Dim systemnew As System = Nothing

            Try
                result__1 = FMOD_Channel_GetSystemObject(channelraw, systemraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If system Is Nothing Then
                systemnew = New System()
                systemnew.setRaw(systemraw)
                system = systemnew
            Else
                system.setRaw(systemraw)
            End If

            Return result__1
        End Function


        Public Function [stop]() As RESULT
            Return FMOD_Channel_Stop(channelraw)
        End Function
        Public Function setPaused(ByVal paused As Boolean) As RESULT
            Return FMOD_Channel_SetPaused(channelraw, (If(paused, 1, 0)))
        End Function
        Public Function getPaused(ByRef paused As Boolean) As RESULT
            Dim result As RESULT
            Dim p As Integer = 0

            result = FMOD_Channel_GetPaused(channelraw, p)

            paused = (p <> 0)

            Return result
        End Function
        Public Function setVolume(ByVal volume As Single) As RESULT
            Return FMOD_Channel_SetVolume(channelraw, volume)
        End Function
        Public Function getVolume(ByRef volume As Single) As RESULT
            Return FMOD_Channel_GetVolume(channelraw, volume)
        End Function
        Public Function setFrequency(ByVal frequency As Single) As RESULT
            Return FMOD_Channel_SetFrequency(channelraw, frequency)
        End Function
        Public Function getFrequency(ByRef frequency As Single) As RESULT
            Return FMOD_Channel_GetFrequency(channelraw, frequency)
        End Function
        Public Function setPan(ByVal pan As Single) As RESULT
            Return FMOD_Channel_SetPan(channelraw, pan)
        End Function
        Public Function getPan(ByRef pan As Single) As RESULT
            Return FMOD_Channel_GetPan(channelraw, pan)
        End Function
        Public Function setDelay(ByVal delaytype As DELAYTYPE, ByVal delayhi As UInteger, ByVal delaylo As UInteger) As RESULT
            Return FMOD_Channel_SetDelay(channelraw, delaytype, delayhi, delaylo)
        End Function
        Public Function getDelay(ByVal delaytype As DELAYTYPE, ByRef delayhi As UInteger, ByRef delaylo As UInteger) As RESULT
            Return FMOD_Channel_GetDelay(channelraw, delaytype, delayhi, delaylo)
        End Function
        Public Function setSpeakerMix(ByVal frontleft As Single, ByVal frontright As Single, ByVal center As Single, ByVal lfe As Single, ByVal backleft As Single, ByVal backright As Single, _
         ByVal sideleft As Single, ByVal sideright As Single) As RESULT
            Return FMOD_Channel_SetSpeakerMix(channelraw, frontleft, frontright, center, lfe, backleft, _
             backright, sideleft, sideright)
        End Function
        Public Function getSpeakerMix(ByRef frontleft As Single, ByRef frontright As Single, ByRef center As Single, ByRef lfe As Single, ByRef backleft As Single, ByRef backright As Single, _
         ByRef sideleft As Single, ByRef sideright As Single) As RESULT
            Return FMOD_Channel_GetSpeakerMix(channelraw, frontleft, frontright, center, lfe, backleft, _
             backright, sideleft, sideright)
        End Function
        Public Function setSpeakerLevels(ByVal speaker As SPEAKER, ByVal levels As Single(), ByVal numlevels As Integer) As RESULT
            Return FMOD_Channel_SetSpeakerLevels(channelraw, speaker, levels, numlevels)
        End Function
        Public Function getSpeakerLevels(ByVal speaker As SPEAKER, ByVal levels As Single(), ByVal numlevels As Integer) As RESULT
            Return FMOD_Channel_GetSpeakerLevels(channelraw, speaker, levels, numlevels)
        End Function
        Public Function setInputChannelMix(ByVal levels As Single(), ByVal numlevels As Integer) As RESULT
            Return FMOD_Channel_SetInputChannelMix(channelraw, levels, numlevels)
        End Function
        Public Function getInputChannelMix(ByVal levels As Single(), ByVal numlevels As Integer) As RESULT
            Return FMOD_Channel_GetInputChannelMix(channelraw, levels, numlevels)
        End Function
        Public Function setMute(ByVal mute As Boolean) As RESULT
            Return FMOD_Channel_SetMute(channelraw, (If(mute, 1, 0)))
        End Function
        Public Function getMute(ByRef mute As Boolean) As RESULT
            Dim result As RESULT
            Dim m As Integer = 0

            result = FMOD_Channel_GetMute(channelraw, m)

            mute = (m <> 0)

            Return result
        End Function
        Public Function setPriority(ByVal priority As Integer) As RESULT
            Return FMOD_Channel_SetPriority(channelraw, priority)
        End Function
        Public Function getPriority(ByRef priority As Integer) As RESULT
            Return FMOD_Channel_GetPriority(channelraw, priority)
        End Function
        Public Function setPosition(ByVal position As UInteger, ByVal postype As TIMEUNIT) As RESULT
            Return FMOD_Channel_SetPosition(channelraw, position, postype)
        End Function
        Public Function getPosition(ByRef position As UInteger, ByVal postype As TIMEUNIT) As RESULT
            Return FMOD_Channel_GetPosition(channelraw, position, postype)
        End Function

        Public Function setLowPassGain(ByVal gain As Single) As RESULT
            Return FMOD_Channel_SetLowPassGain(channelraw, gain)
        End Function
        Public Function getLowPassGain(ByRef gain As Single) As RESULT
            Return FMOD_Channel_GetLowPassGain(channelraw, gain)
        End Function

        Public Function setReverbProperties(ByRef prop As REVERB_CHANNELPROPERTIES) As RESULT
            Return FMOD_Channel_SetReverbProperties(channelraw, prop)
        End Function
        Public Function getReverbProperties(ByRef prop As REVERB_CHANNELPROPERTIES) As RESULT
            Return FMOD_Channel_GetReverbProperties(channelraw, prop)
        End Function
        Public Function setChannelGroup(ByVal channelgroup As ChannelGroup) As RESULT
            Return FMOD_Channel_SetChannelGroup(channelraw, channelgroup.getRaw())
        End Function
        Public Function getChannelGroup(ByRef channelgroup As ChannelGroup) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim channelgroupraw As New IntPtr()
            Dim channelgroupnew As ChannelGroup = Nothing

            Try
                result__1 = FMOD_Channel_GetChannelGroup(channelraw, channelgroupraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If channelgroup Is Nothing Then
                channelgroupnew = New ChannelGroup()
                channelgroupnew.setRaw(channelgroupraw)
                channelgroup = channelgroupnew
            Else
                channelgroup.setRaw(channelgroupraw)
            End If

            Return result__1
        End Function

        Public Function setCallback(ByVal callback As CHANNEL_CALLBACK) As RESULT
            Return FMOD_Channel_SetCallback(channelraw, callback)
        End Function


        Public Function set3DAttributes(ByRef pos As VECTOR, ByRef vel As VECTOR) As RESULT
            Return FMOD_Channel_Set3DAttributes(channelraw, pos, vel)
        End Function
        Public Function get3DAttributes(ByRef pos As VECTOR, ByRef vel As VECTOR) As RESULT
            Return FMOD_Channel_Get3DAttributes(channelraw, pos, vel)
        End Function
        Public Function set3DMinMaxDistance(ByVal mindistance As Single, ByVal maxdistance As Single) As RESULT
            Return FMOD_Channel_Set3DMinMaxDistance(channelraw, mindistance, maxdistance)
        End Function
        Public Function get3DMinMaxDistance(ByRef mindistance As Single, ByRef maxdistance As Single) As RESULT
            Return FMOD_Channel_Get3DMinMaxDistance(channelraw, mindistance, maxdistance)
        End Function
        Public Function set3DConeSettings(ByVal insideconeangle As Single, ByVal outsideconeangle As Single, ByVal outsidevolume As Single) As RESULT
            Return FMOD_Channel_Set3DConeSettings(channelraw, insideconeangle, outsideconeangle, outsidevolume)
        End Function
        Public Function get3DConeSettings(ByRef insideconeangle As Single, ByRef outsideconeangle As Single, ByRef outsidevolume As Single) As RESULT
            Return FMOD_Channel_Get3DConeSettings(channelraw, insideconeangle, outsideconeangle, outsidevolume)
        End Function
        Public Function set3DConeOrientation(ByRef orientation As VECTOR) As RESULT
            Return FMOD_Channel_Set3DConeOrientation(channelraw, orientation)
        End Function
        Public Function get3DConeOrientation(ByRef orientation As VECTOR) As RESULT
            Return FMOD_Channel_Get3DConeOrientation(channelraw, orientation)
        End Function
        Public Function set3DCustomRolloff(ByRef points As VECTOR, ByVal numpoints As Integer) As RESULT
            Return FMOD_Channel_Set3DCustomRolloff(channelraw, points, numpoints)
        End Function
        Public Function get3DCustomRolloff(ByRef points As IntPtr, ByRef numpoints As Integer) As RESULT
            Return FMOD_Channel_Get3DCustomRolloff(channelraw, points, numpoints)
        End Function
        Public Function set3DOcclusion(ByVal directocclusion As Single, ByVal reverbocclusion As Single) As RESULT
            Return FMOD_Channel_Set3DOcclusion(channelraw, directocclusion, reverbocclusion)
        End Function
        Public Function get3DOcclusion(ByRef directocclusion As Single, ByRef reverbocclusion As Single) As RESULT
            Return FMOD_Channel_Get3DOcclusion(channelraw, directocclusion, reverbocclusion)
        End Function
        Public Function set3DSpread(ByVal angle As Single) As RESULT
            Return FMOD_Channel_Set3DSpread(channelraw, angle)
        End Function
        Public Function get3DSpread(ByRef angle As Single) As RESULT
            Return FMOD_Channel_Get3DSpread(channelraw, angle)
        End Function
        Public Function set3DPanLevel(ByVal level As Single) As RESULT
            Return FMOD_Channel_Set3DPanLevel(channelraw, level)
        End Function
        Public Function get3DPanLevel(ByRef level As Single) As RESULT
            Return FMOD_Channel_Get3DPanLevel(channelraw, level)
        End Function
        Public Function set3DDopplerLevel(ByVal level As Single) As RESULT
            Return FMOD_Channel_Set3DDopplerLevel(channelraw, level)
        End Function
        Public Function get3DDopplerLevel(ByRef level As Single) As RESULT
            Return FMOD_Channel_Get3DDopplerLevel(channelraw, level)
        End Function

        Public Function isPlaying(ByRef isplaying__1 As Boolean) As RESULT
            Dim result As RESULT
            Dim p As Integer = 0

            result = FMOD_Channel_IsPlaying(channelraw, p)

            isplaying__1 = (p <> 0)

            Return result
        End Function
        Public Function isVirtual(ByRef isvirtual__1 As Boolean) As RESULT
            Dim result As RESULT
            Dim v As Integer = 0

            result = FMOD_Channel_IsVirtual(channelraw, v)

            isvirtual__1 = (v <> 0)

            Return result
        End Function
        Public Function getAudibility(ByRef audibility As Single) As RESULT
            Return FMOD_Channel_GetAudibility(channelraw, audibility)
        End Function
        Public Function getCurrentSound(ByRef sound As Sound) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim soundraw As New IntPtr()
            Dim soundnew As Sound = Nothing

            Try
                result__1 = FMOD_Channel_GetCurrentSound(channelraw, soundraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If sound Is Nothing Then
                soundnew = New Sound()
                soundnew.setRaw(soundraw)
                sound = soundnew
            Else
                sound.setRaw(soundraw)
            End If

            Return result__1
        End Function
        Public Function getSpectrum(ByVal spectrumarray As Single(), ByVal numvalues As Integer, ByVal channeloffset As Integer, ByVal windowtype As DSP_FFT_WINDOW) As RESULT
            Return FMOD_Channel_GetSpectrum(channelraw, spectrumarray, numvalues, channeloffset, windowtype)
        End Function
        Public Function getWaveData(ByVal wavearray As Single(), ByVal numvalues As Integer, ByVal channeloffset As Integer) As RESULT
            Return FMOD_Channel_GetWaveData(channelraw, wavearray, numvalues, channeloffset)
        End Function
        Public Function getIndex(ByRef index As Integer) As RESULT
            Return FMOD_Channel_GetIndex(channelraw, index)
        End Function

        Public Function getDSPHead(ByRef dsp As DSP) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim dspraw As New IntPtr()
            Dim dspnew As DSP = Nothing

            Try
                result__1 = FMOD_Channel_GetDSPHead(channelraw, dspraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            dspnew = New DSP()
            dspnew.setRaw(dspraw)
            dsp = dspnew

            Return result__1
        End Function
        Public Function addDSP(ByVal dsp As DSP, ByRef connection As DSPConnection) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim dspconnectionraw As New IntPtr()
            Dim dspconnectionnew As DSPConnection = Nothing

            Try
                result__1 = FMOD_Channel_AddDSP(channelraw, dsp.getRaw(), dspconnectionraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If connection Is Nothing Then
                dspconnectionnew = New DSPConnection()
                dspconnectionnew.setRaw(dspconnectionraw)
                connection = dspconnectionnew
            Else
                connection.setRaw(dspconnectionraw)
            End If

            Return result__1
        End Function


        Public Function setMode(ByVal mode As MODE) As RESULT
            Return FMOD_Channel_SetMode(channelraw, mode)
        End Function
        Public Function getMode(ByRef mode As MODE) As RESULT
            Return FMOD_Channel_GetMode(channelraw, mode)
        End Function
        Public Function setLoopCount(ByVal loopcount As Integer) As RESULT
            Return FMOD_Channel_SetLoopCount(channelraw, loopcount)
        End Function
        Public Function getLoopCount(ByRef loopcount As Integer) As RESULT
            Return FMOD_Channel_GetLoopCount(channelraw, loopcount)
        End Function
        Public Function setLoopPoints(ByVal loopstart As UInteger, ByVal loopstarttype As TIMEUNIT, ByVal loopend As UInteger, ByVal loopendtype As TIMEUNIT) As RESULT
            Return FMOD_Channel_SetLoopPoints(channelraw, loopstart, loopstarttype, loopend, loopendtype)
        End Function
        Public Function getLoopPoints(ByRef loopstart As UInteger, ByVal loopstarttype As TIMEUNIT, ByRef loopend As UInteger, ByVal loopendtype As TIMEUNIT) As RESULT
            Return FMOD_Channel_GetLoopPoints(channelraw, loopstart, loopstarttype, loopend, loopendtype)
        End Function


        Public Function setUserData(ByVal userdata As IntPtr) As RESULT
            Return FMOD_Channel_SetUserData(channelraw, userdata)
        End Function
        Public Function getUserData(ByRef userdata As IntPtr) As RESULT
            Return FMOD_Channel_GetUserData(channelraw, userdata)
        End Function

        Public Function getMemoryInfo(ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
            Return FMOD_Channel_GetMemoryInfo(channelraw, memorybits, event_memorybits, memoryused, memoryused_details)
        End Function

#Region "importfunctions"

        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetSystemObject(ByVal channel As IntPtr, ByRef system As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Stop(ByVal channel As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetPaused(ByVal channel As IntPtr, ByVal paused As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetPaused(ByVal channel As IntPtr, ByRef paused As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetVolume(ByVal channel As IntPtr, ByVal volume As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetVolume(ByVal channel As IntPtr, ByRef volume As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetFrequency(ByVal channel As IntPtr, ByVal frequency As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetFrequency(ByVal channel As IntPtr, ByRef frequency As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetPan(ByVal channel As IntPtr, ByVal pan As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetPan(ByVal channel As IntPtr, ByRef pan As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetDelay(ByVal channel As IntPtr, ByVal delaytype As DELAYTYPE, ByVal delayhi As UInteger, ByVal delaylo As UInteger) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetDelay(ByVal channel As IntPtr, ByVal delaytype As DELAYTYPE, ByRef delayhi As UInteger, ByRef delaylo As UInteger) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetSpeakerMix(ByVal channel As IntPtr, ByVal frontleft As Single, ByVal frontright As Single, ByVal center As Single, ByVal lfe As Single, ByVal backleft As Single, _
   ByVal backright As Single, ByVal sideleft As Single, ByVal sideright As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetSpeakerMix(ByVal channel As IntPtr, ByRef frontleft As Single, ByRef frontright As Single, ByRef center As Single, ByRef lfe As Single, ByRef backleft As Single, _
   ByRef backright As Single, ByRef sideleft As Single, ByRef sideright As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetSpeakerLevels(ByVal channel As IntPtr, ByVal speaker As SPEAKER, ByVal levels As Single(), ByVal numlevels As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetSpeakerLevels(ByVal channel As IntPtr, ByVal speaker As SPEAKER, <MarshalAs(UnmanagedType.LPArray)> ByVal levels As Single(), ByVal numlevels As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetInputChannelMix(ByVal channel As IntPtr, ByVal levels As Single(), ByVal numlevels As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetInputChannelMix(ByVal channel As IntPtr, <MarshalAs(UnmanagedType.LPArray)> ByVal levels As Single(), ByVal numlevels As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetMute(ByVal channel As IntPtr, ByVal mute As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetMute(ByVal channel As IntPtr, ByRef mute As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetPriority(ByVal channel As IntPtr, ByVal priority As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetPriority(ByVal channel As IntPtr, ByRef priority As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Set3DAttributes(ByVal channel As IntPtr, ByRef pos As VECTOR, ByRef vel As VECTOR) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Get3DAttributes(ByVal channel As IntPtr, ByRef pos As VECTOR, ByRef vel As VECTOR) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Set3DMinMaxDistance(ByVal channel As IntPtr, ByVal mindistance As Single, ByVal maxdistance As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Get3DMinMaxDistance(ByVal channel As IntPtr, ByRef mindistance As Single, ByRef maxdistance As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Set3DConeSettings(ByVal channel As IntPtr, ByVal insideconeangle As Single, ByVal outsideconeangle As Single, ByVal outsidevolume As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Get3DConeSettings(ByVal channel As IntPtr, ByRef insideconeangle As Single, ByRef outsideconeangle As Single, ByRef outsidevolume As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Set3DConeOrientation(ByVal channel As IntPtr, ByRef orientation As VECTOR) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Get3DConeOrientation(ByVal channel As IntPtr, ByRef orientation As VECTOR) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Set3DCustomRolloff(ByVal channel As IntPtr, ByRef points As VECTOR, ByVal numpoints As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Get3DCustomRolloff(ByVal channel As IntPtr, ByRef points As IntPtr, ByRef numpoints As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Set3DOcclusion(ByVal channel As IntPtr, ByVal directocclusion As Single, ByVal reverbocclusion As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Get3DOcclusion(ByVal channel As IntPtr, ByRef directocclusion As Single, ByRef reverbocclusion As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Set3DSpread(ByVal channel As IntPtr, ByVal angle As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Get3DSpread(ByVal channel As IntPtr, ByRef angle As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Set3DPanLevel(ByVal channel As IntPtr, ByVal level As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Get3DPanLevel(ByVal channel As IntPtr, ByRef level As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Set3DDopplerLevel(ByVal channel As IntPtr, ByVal level As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_Get3DDopplerLevel(ByVal channel As IntPtr, ByRef level As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetReverbProperties(ByVal channel As IntPtr, ByRef prop As REVERB_CHANNELPROPERTIES) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetReverbProperties(ByVal channel As IntPtr, ByRef prop As REVERB_CHANNELPROPERTIES) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetLowPassGain(ByVal channel As IntPtr, ByVal gain As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetLowPassGain(ByVal channel As IntPtr, ByRef gain As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetChannelGroup(ByVal channel As IntPtr, ByVal channelgroup As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetChannelGroup(ByVal channel As IntPtr, ByRef channelgroup As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_IsPlaying(ByVal channel As IntPtr, ByRef isplaying As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_IsVirtual(ByVal channel As IntPtr, ByRef isvirtual As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetAudibility(ByVal channel As IntPtr, ByRef audibility As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetCurrentSound(ByVal channel As IntPtr, ByRef sound As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetSpectrum(ByVal channel As IntPtr, <MarshalAs(UnmanagedType.LPArray)> ByVal spectrumarray As Single(), ByVal numvalues As Integer, ByVal channeloffset As Integer, ByVal windowtype As DSP_FFT_WINDOW) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetWaveData(ByVal channel As IntPtr, <MarshalAs(UnmanagedType.LPArray)> ByVal wavearray As Single(), ByVal numvalues As Integer, ByVal channeloffset As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetIndex(ByVal channel As IntPtr, ByRef index As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetCallback(ByVal channel As IntPtr, ByVal callback As CHANNEL_CALLBACK) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetPosition(ByVal channel As IntPtr, ByVal position As UInteger, ByVal postype As TIMEUNIT) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetPosition(ByVal channel As IntPtr, ByRef position As UInteger, ByVal postype As TIMEUNIT) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetDSPHead(ByVal channel As IntPtr, ByRef dsp As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_AddDSP(ByVal channel As IntPtr, ByVal dsp As IntPtr, ByRef connection As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetMode(ByVal channel As IntPtr, ByVal mode As MODE) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetMode(ByVal channel As IntPtr, ByRef mode As MODE) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetLoopCount(ByVal channel As IntPtr, ByVal loopcount As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetLoopCount(ByVal channel As IntPtr, ByRef loopcount As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetLoopPoints(ByVal channel As IntPtr, ByVal loopstart As UInteger, ByVal loopstarttype As TIMEUNIT, ByVal loopend As UInteger, ByVal loopendtype As TIMEUNIT) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetLoopPoints(ByVal channel As IntPtr, ByRef loopstart As UInteger, ByVal loopstarttype As TIMEUNIT, ByRef loopend As UInteger, ByVal loopendtype As TIMEUNIT) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_SetUserData(ByVal channel As IntPtr, ByVal userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetUserData(ByVal channel As IntPtr, ByRef userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Channel_GetMemoryInfo(ByVal channel As IntPtr, ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
        End Function
#End Region

#Region "wrapperinternal"

        Private channelraw As IntPtr

        Public Sub setRaw(ByVal channel As IntPtr)
            channelraw = New IntPtr()

            channelraw = channel
        End Sub

        Public Function getRaw() As IntPtr
            Return channelraw
        End Function

#End Region
    End Class


    '
    '        'ChannelGroup' API
    '    

    Public Class ChannelGroup
        Public Function release() As RESULT
            Return FMOD_ChannelGroup_Release(channelgroupraw)
        End Function
        Public Function getSystemObject(ByRef system As System) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim systemraw As New IntPtr()
            Dim systemnew As System = Nothing

            Try
                result__1 = FMOD_ChannelGroup_GetSystemObject(channelgroupraw, systemraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If system Is Nothing Then
                systemnew = New System()
                systemnew.setRaw(systemraw)
                system = systemnew
            Else
                system.setRaw(systemraw)
            End If

            Return result__1
        End Function


        ' Channelgroup scale values.  (scales the current volume or pitch of all channels and channel groups, DOESN'T overwrite)
        Public Function setVolume(ByVal volume As Single) As RESULT
            Return FMOD_ChannelGroup_SetVolume(channelgroupraw, volume)
        End Function
        Public Function getVolume(ByRef volume As Single) As RESULT
            Return FMOD_ChannelGroup_GetVolume(channelgroupraw, volume)
        End Function
        Public Function setPitch(ByVal pitch As Single) As RESULT
            Return FMOD_ChannelGroup_SetPitch(channelgroupraw, pitch)
        End Function
        Public Function getPitch(ByRef pitch As Single) As RESULT
            Return FMOD_ChannelGroup_GetPitch(channelgroupraw, pitch)
        End Function
        Public Function set3DOcclusion(ByVal directocclusion As Single, ByVal reverbocclusion As Single) As RESULT
            Return FMOD_ChannelGroup_Set3DOcclusion(channelgroupraw, directocclusion, reverbocclusion)
        End Function
        Public Function get3DOcclusion(ByRef directocclusion As Single, ByRef reverbocclusion As Single) As RESULT
            Return FMOD_ChannelGroup_Get3DOcclusion(channelgroupraw, directocclusion, reverbocclusion)
        End Function
        Public Function setPaused(ByVal paused As Boolean) As RESULT
            Return FMOD_ChannelGroup_SetPaused(channelgroupraw, (If(paused, 1, 0)))
        End Function
        Public Function getPaused(ByRef paused As Boolean) As RESULT
            Dim result As RESULT
            Dim p As Integer = 0

            result = FMOD_ChannelGroup_GetPaused(channelgroupraw, p)

            paused = (p <> 0)

            Return result
        End Function
        Public Function setMute(ByVal mute As Boolean) As RESULT
            Return FMOD_ChannelGroup_SetMute(channelgroupraw, (If(mute, 1, 0)))
        End Function
        Public Function getMute(ByRef mute As Boolean) As RESULT
            Dim result As RESULT
            Dim m As Integer = 0

            result = FMOD_ChannelGroup_GetMute(channelgroupraw, m)

            mute = (m <> 0)

            Return result
        End Function


        ' Channelgroup override values.  (recursively overwrites whatever settings the channels had)
        Public Function [stop]() As RESULT
            Return FMOD_ChannelGroup_Stop(channelgroupraw)
        End Function
        Public Function overrideVolume(ByVal volume As Single) As RESULT
            Return FMOD_ChannelGroup_OverrideVolume(channelgroupraw, volume)
        End Function
        Public Function overrideFrequency(ByVal frequency As Single) As RESULT
            Return FMOD_ChannelGroup_OverrideFrequency(channelgroupraw, frequency)
        End Function
        Public Function overridePan(ByVal pan As Single) As RESULT
            Return FMOD_ChannelGroup_OverridePan(channelgroupraw, pan)
        End Function
        Public Function overrideReverbProperties(ByRef prop As REVERB_CHANNELPROPERTIES) As RESULT
            Return FMOD_ChannelGroup_OverrideReverbProperties(channelgroupraw, prop)
        End Function
        Public Function override3DAttributes(ByRef pos As VECTOR, ByRef vel As VECTOR) As RESULT
            Return FMOD_ChannelGroup_Override3DAttributes(channelgroupraw, pos, vel)
        End Function
        Public Function overrideSpeakerMix(ByVal frontleft As Single, ByVal frontright As Single, ByVal center As Single, ByVal lfe As Single, ByVal backleft As Single, ByVal backright As Single, _
         ByVal sideleft As Single, ByVal sideright As Single) As RESULT
            Return FMOD_ChannelGroup_OverrideSpeakerMix(channelgroupraw, frontleft, frontright, center, lfe, backleft, _
             backright, sideleft, sideright)
        End Function


        ' Nested channel groups.
        Public Function addGroup(ByVal group As ChannelGroup) As RESULT
            Return FMOD_ChannelGroup_AddGroup(channelgroupraw, group.getRaw())
        End Function
        Public Function getNumGroups(ByRef numgroups As Integer) As RESULT
            Return FMOD_ChannelGroup_GetNumGroups(channelgroupraw, numgroups)
        End Function
        Public Function getGroup(ByVal index As Integer, ByRef group As ChannelGroup) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim channelraw As New IntPtr()
            Dim channelnew As ChannelGroup = Nothing

            Try
                result__1 = FMOD_ChannelGroup_GetGroup(channelgroupraw, index, channelraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If group Is Nothing Then
                channelnew = New ChannelGroup()
                channelnew.setRaw(channelraw)
                group = channelnew
            Else
                group.setRaw(channelraw)
            End If

            Return result__1
        End Function
        Public Function getParentGroup(ByRef group As ChannelGroup) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim channelraw As New IntPtr()
            Dim channelnew As ChannelGroup = Nothing

            Try
                result__1 = FMOD_ChannelGroup_GetParentGroup(channelgroupraw, channelraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If group Is Nothing Then
                channelnew = New ChannelGroup()
                channelnew.setRaw(channelraw)
                group = channelnew
            Else
                group.setRaw(channelraw)
            End If

            Return result__1
        End Function


        ' DSP functionality only for channel groups playing sounds created with FMOD_SOFTWARE.
        Public Function getDSPHead(ByRef dsp As DSP) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim dspraw As New IntPtr()
            Dim dspnew As DSP = Nothing

            Try
                result__1 = FMOD_ChannelGroup_GetDSPHead(channelgroupraw, dspraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If dsp Is Nothing Then
                dspnew = New DSP()
                dspnew.setRaw(dspraw)
                dsp = dspnew
            Else
                dsp.setRaw(dspraw)
            End If

            Return result__1
        End Function

        Public Function addDSP(ByVal dsp As DSP, ByRef connection As DSPConnection) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim dspconnectionraw As New IntPtr()
            Dim dspconnectionnew As DSPConnection = Nothing

            Try
                result__1 = FMOD_ChannelGroup_AddDSP(channelgroupraw, dsp.getRaw(), dspconnectionraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If connection Is Nothing Then
                dspconnectionnew = New DSPConnection()
                dspconnectionnew.setRaw(dspconnectionraw)
                connection = dspconnectionnew
            Else
                connection.setRaw(dspconnectionraw)
            End If

            Return result__1
        End Function


        ' Information only functions.
        Public Function getName(ByVal name As StringBuilder, ByVal namelen As Integer) As RESULT
            Return FMOD_ChannelGroup_GetName(channelgroupraw, name, namelen)
        End Function
        Public Function getNumChannels(ByRef numchannels As Integer) As RESULT
            Return FMOD_ChannelGroup_GetNumChannels(channelgroupraw, numchannels)
        End Function
        Public Function getChannel(ByVal index As Integer, ByRef channel As Channel) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim channelraw As New IntPtr()
            Dim channelnew As Channel = Nothing

            Try
                result__1 = FMOD_ChannelGroup_GetChannel(channelgroupraw, index, channelraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If channel Is Nothing Then
                channelnew = New Channel()
                channelnew.setRaw(channelraw)
                channel = channelnew
            Else
                channel.setRaw(channelraw)
            End If

            Return result__1
        End Function
        Public Function getSpectrum(ByVal spectrumarray As Single(), ByVal numvalues As Integer, ByVal channeloffset As Integer, ByVal windowtype As DSP_FFT_WINDOW) As RESULT
            Return FMOD_ChannelGroup_GetSpectrum(channelgroupraw, spectrumarray, numvalues, channeloffset, windowtype)
        End Function
        Public Function getWaveData(ByVal wavearray As Single(), ByVal numvalues As Integer, ByVal channeloffset As Integer) As RESULT
            Return FMOD_ChannelGroup_GetWaveData(channelgroupraw, wavearray, numvalues, channeloffset)
        End Function


        ' Userdata set/get.
        Public Function setUserData(ByVal userdata As IntPtr) As RESULT
            Return FMOD_ChannelGroup_SetUserData(channelgroupraw, userdata)
        End Function
        Public Function getUserData(ByRef userdata As IntPtr) As RESULT
            Return FMOD_ChannelGroup_GetUserData(channelgroupraw, userdata)
        End Function

        Public Function getMemoryInfo(ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
            Return FMOD_ChannelGroup_GetMemoryInfo(channelgroupraw, memorybits, event_memorybits, memoryused, memoryused_details)
        End Function

#Region "importfunctions"


        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_Release(ByVal channelgroup As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_GetSystemObject(ByVal channelgroup As IntPtr, ByRef system As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_SetVolume(ByVal channelgroup As IntPtr, ByVal volume As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_GetVolume(ByVal channelgroup As IntPtr, ByRef volume As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_SetPitch(ByVal channelgroup As IntPtr, ByVal pitch As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_GetPitch(ByVal channelgroup As IntPtr, ByRef pitch As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_Set3DOcclusion(ByVal channelgroup As IntPtr, ByVal directocclusion As Single, ByVal reverbocclusion As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_Get3DOcclusion(ByVal channelgroup As IntPtr, ByRef directocclusion As Single, ByRef reverbocclusion As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_SetPaused(ByVal channelgroup As IntPtr, ByVal paused As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_GetPaused(ByVal channelgroup As IntPtr, ByRef paused As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_SetMute(ByVal channelgroup As IntPtr, ByVal mute As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_GetMute(ByVal channelgroup As IntPtr, ByRef mute As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_Stop(ByVal channelgroup As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_OverridePaused(ByVal channelgroup As IntPtr, ByVal paused As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_OverrideVolume(ByVal channelgroup As IntPtr, ByVal volume As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_OverrideFrequency(ByVal channelgroup As IntPtr, ByVal frequency As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_OverridePan(ByVal channelgroup As IntPtr, ByVal pan As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_OverrideMute(ByVal channelgroup As IntPtr, ByVal mute As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_OverrideReverbProperties(ByVal channelgroup As IntPtr, ByRef prop As REVERB_CHANNELPROPERTIES) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_Override3DAttributes(ByVal channelgroup As IntPtr, ByRef pos As VECTOR, ByRef vel As VECTOR) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_OverrideSpeakerMix(ByVal channelgroup As IntPtr, ByVal frontleft As Single, ByVal frontright As Single, ByVal center As Single, ByVal lfe As Single, ByVal backleft As Single, _
   ByVal backright As Single, ByVal sideleft As Single, ByVal sideright As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_AddGroup(ByVal channelgroup As IntPtr, ByVal group As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_GetNumGroups(ByVal channelgroup As IntPtr, ByRef numgroups As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_GetGroup(ByVal channelgroup As IntPtr, ByVal index As Integer, ByRef group As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_GetParentGroup(ByVal channelgroup As IntPtr, ByRef group As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_GetDSPHead(ByVal channelgroup As IntPtr, ByRef dsp As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_AddDSP(ByVal channelgroup As IntPtr, ByVal dsp As IntPtr, ByRef connection As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_GetName(ByVal channelgroup As IntPtr, ByVal name As StringBuilder, ByVal namelen As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_GetNumChannels(ByVal channelgroup As IntPtr, ByRef numchannels As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_GetChannel(ByVal channelgroup As IntPtr, ByVal index As Integer, ByRef channel As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_GetSpectrum(ByVal channelgroup As IntPtr, <MarshalAs(UnmanagedType.LPArray)> ByVal spectrumarray As Single(), ByVal numvalues As Integer, ByVal channeloffset As Integer, ByVal windowtype As DSP_FFT_WINDOW) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_GetWaveData(ByVal channelgroup As IntPtr, <MarshalAs(UnmanagedType.LPArray)> ByVal wavearray As Single(), ByVal numvalues As Integer, ByVal channeloffset As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_SetUserData(ByVal channelgroup As IntPtr, ByVal userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_GetUserData(ByVal channelgroup As IntPtr, ByRef userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_ChannelGroup_GetMemoryInfo(ByVal channelgroup As IntPtr, ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
        End Function
#End Region

#Region "wrapperinternal"

        Private channelgroupraw As IntPtr

        Public Sub setRaw(ByVal channelgroup As IntPtr)
            channelgroupraw = New IntPtr()

            channelgroupraw = channelgroup
        End Sub

        Public Function getRaw() As IntPtr
            Return channelgroupraw
        End Function

#End Region
    End Class


    '
    '        'SoundGroup' API
    '    

    Public Class SoundGroup
        Public Function release() As RESULT
            Return FMOD_SoundGroup_Release(soundgroupraw)
        End Function

        Public Function getSystemObject(ByRef system As System) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim systemraw As New IntPtr()
            Dim systemnew As System = Nothing

            Try
                result__1 = FMOD_SoundGroup_GetSystemObject(soundgroupraw, systemraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If system Is Nothing Then
                systemnew = New System()
                systemnew.setRaw(systemraw)
                system = systemnew
            Else
                system.setRaw(systemraw)
            End If

            Return result__1
        End Function

        ' SoundGroup control functions.
        Public Function setMaxAudible(ByVal maxaudible As Integer) As RESULT
            Return FMOD_SoundGroup_SetMaxAudible(soundgroupraw, maxaudible)
        End Function

        Public Function getMaxAudible(ByRef maxaudible As Integer) As RESULT
            Return FMOD_SoundGroup_GetMaxAudible(soundgroupraw, maxaudible)
        End Function

        Public Function setMaxAudibleBehavior(ByVal behavior As SOUNDGROUP_BEHAVIOR) As RESULT
            Return FMOD_SoundGroup_SetMaxAudibleBehavior(soundgroupraw, behavior)
        End Function
        Public Function getMaxAudibleBehavior(ByRef behavior As SOUNDGROUP_BEHAVIOR) As RESULT
            Return FMOD_SoundGroup_GetMaxAudibleBehavior(soundgroupraw, behavior)
        End Function
        Public Function setMuteFadeSpeed(ByVal speed As Single) As RESULT
            Return FMOD_SoundGroup_SetMuteFadeSpeed(soundgroupraw, speed)
        End Function
        Public Function getMuteFadeSpeed(ByRef speed As Single) As RESULT
            Return FMOD_SoundGroup_GetMuteFadeSpeed(soundgroupraw, speed)
        End Function

        Public Function setVolume(ByVal volume As Single) As RESULT
            Return FMOD_SoundGroup_SetVolume(soundgroupraw, volume)
        End Function
        Public Function getVolume(ByRef volume As Single) As RESULT
            Return FMOD_SoundGroup_GetVolume(soundgroupraw, volume)
        End Function
        Public Function [stop]() As RESULT
            Return FMOD_SoundGroup_Stop(soundgroupraw)
        End Function

        ' Information only functions.
        Public Function getName(ByVal name As StringBuilder, ByVal namelen As Integer) As RESULT
            Return FMOD_SoundGroup_GetName(soundgroupraw, name, namelen)
        End Function
        Public Function getNumSounds(ByRef numsounds As Integer) As RESULT
            Return FMOD_SoundGroup_GetNumSounds(soundgroupraw, numsounds)
        End Function
        Public Function getSound(ByVal index As Integer, ByRef sound As Sound) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim soundraw As New IntPtr()
            Dim soundnew As Sound = Nothing

            Try
                result__1 = FMOD_SoundGroup_GetSound(soundgroupraw, index, soundraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If sound Is Nothing Then
                soundnew = New Sound()
                soundnew.setRaw(soundraw)
                sound = soundnew
            Else
                sound.setRaw(soundraw)
            End If

            Return result__1
        End Function
        Public Function getNumPlaying(ByRef numplaying As Integer) As RESULT
            Return FMOD_SoundGroup_GetNumPlaying(soundgroupraw, numplaying)
        End Function

        ' Userdata set/get.
        Public Function setUserData(ByVal userdata As IntPtr) As RESULT
            Return FMOD_SoundGroup_SetUserData(soundgroupraw, userdata)
        End Function
        Public Function getUserData(ByRef userdata As IntPtr) As RESULT
            Return FMOD_SoundGroup_GetUserData(soundgroupraw, userdata)
        End Function

        Public Function getMemoryInfo(ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
            Return FMOD_SoundGroup_GetMemoryInfo(soundgroupraw, memorybits, event_memorybits, memoryused, memoryused_details)
        End Function

#Region "importfunctions"
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_Release(ByVal soundgroup As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_GetSystemObject(ByVal soundgroup As IntPtr, ByRef system As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_SetMaxAudible(ByVal soundgroup As IntPtr, ByVal maxaudible As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_GetMaxAudible(ByVal soundgroup As IntPtr, ByRef maxaudible As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_SetMaxAudibleBehavior(ByVal soundgroup As IntPtr, ByVal behavior As SOUNDGROUP_BEHAVIOR) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_GetMaxAudibleBehavior(ByVal soundgroup As IntPtr, ByRef behavior As SOUNDGROUP_BEHAVIOR) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_SetMuteFadeSpeed(ByVal soundgroup As IntPtr, ByVal speed As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_GetMuteFadeSpeed(ByVal soundgroup As IntPtr, ByRef speed As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_SetVolume(ByVal soundgroup As IntPtr, ByVal volume As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_GetVolume(ByVal soundgroup As IntPtr, ByRef volume As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_Stop(ByVal soundgroup As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_GetName(ByVal soundgroup As IntPtr, ByVal name As StringBuilder, ByVal namelen As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_GetNumSounds(ByVal soundgroup As IntPtr, ByRef numsounds As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_GetSound(ByVal soundgroup As IntPtr, ByVal index As Integer, ByRef sound As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_GetNumPlaying(ByVal soundgroup As IntPtr, ByRef numplaying As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_SetUserData(ByVal soundgroup As IntPtr, ByVal userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_GetUserData(ByVal soundgroup As IntPtr, ByRef userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_SoundGroup_GetMemoryInfo(ByVal soundgroup As IntPtr, ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
        End Function
#End Region

#Region "wrapperinternal"

        Private soundgroupraw As IntPtr

        Public Sub setRaw(ByVal soundgroup As IntPtr)
            soundgroupraw = New IntPtr()

            soundgroupraw = soundgroup
        End Sub

        Public Function getRaw() As IntPtr
            Return soundgroupraw
        End Function

#End Region
    End Class


    '
    '        'DSP' API
    '    

    Public Class DSP
        Public Function release() As RESULT
            Return FMOD_DSP_Release(dspraw)
        End Function
        Public Function getSystemObject(ByRef system As System) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim systemraw As New IntPtr()
            Dim systemnew As System = Nothing

            Try
                result__1 = FMOD_DSP_GetSystemObject(dspraw, systemraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If system Is Nothing Then
                systemnew = New System()
                systemnew.setRaw(dspraw)
                system = systemnew
            Else
                system.setRaw(systemraw)
            End If

            Return result__1
        End Function


        Public Function addInput(ByVal target As DSP, ByRef connection As DSPConnection) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim dspconnectionraw As New IntPtr()
            Dim dspconnectionnew As DSPConnection = Nothing

            Try
                result__1 = FMOD_DSP_AddInput(dspraw, target.getRaw(), dspconnectionraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If connection Is Nothing Then
                dspconnectionnew = New DSPConnection()
                dspconnectionnew.setRaw(dspconnectionraw)
                connection = dspconnectionnew
            Else
                connection.setRaw(dspconnectionraw)
            End If

            Return result__1
        End Function
        Public Function disconnectFrom(ByVal target As DSP) As RESULT
            Return FMOD_DSP_DisconnectFrom(dspraw, target.getRaw())
        End Function
        Public Function disconnectAll(ByVal inputs As Boolean, ByVal outputs As Boolean) As RESULT
            Return FMOD_DSP_DisconnectAll(dspraw, (If(inputs, 1, 0)), (If(outputs, 1, 0)))
        End Function
        Public Function remove() As RESULT
            Return FMOD_DSP_Remove(dspraw)
        End Function
        Public Function getNumInputs(ByRef numinputs As Integer) As RESULT
            Return FMOD_DSP_GetNumInputs(dspraw, numinputs)
        End Function
        Public Function getNumOutputs(ByRef numoutputs As Integer) As RESULT
            Return FMOD_DSP_GetNumOutputs(dspraw, numoutputs)
        End Function
        Public Function getInput(ByVal index As Integer, ByRef input As DSP, ByRef inputconnection As DSPConnection) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim dsprawnew As New IntPtr()
            Dim dspnew As DSP = Nothing
            Dim dspconnectionraw As New IntPtr()
            Dim dspconnectionnew As DSPConnection = Nothing

            Try
                result__1 = FMOD_DSP_GetInput(dspraw, index, dsprawnew, dspconnectionraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If input Is Nothing Then
                dspnew = New DSP()
                dspnew.setRaw(dsprawnew)
                input = dspnew
            Else
                input.setRaw(dsprawnew)
            End If

            If inputconnection Is Nothing Then
                dspconnectionnew = New DSPConnection()
                dspconnectionnew.setRaw(dspconnectionraw)
                inputconnection = dspconnectionnew
            Else
                inputconnection.setRaw(dspconnectionraw)
            End If

            Return result__1
        End Function
        Public Function getOutput(ByVal index As Integer, ByRef output As DSP, ByRef outputconnection As DSPConnection) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim dsprawnew As New IntPtr()
            Dim dspnew As DSP = Nothing
            Dim dspconnectionraw As New IntPtr()
            Dim dspconnectionnew As DSPConnection = Nothing

            Try
                result__1 = FMOD_DSP_GetOutput(dspraw, index, dsprawnew, dspconnectionraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If output Is Nothing Then
                dspnew = New DSP()
                dspnew.setRaw(dsprawnew)
                output = dspnew
            Else
                output.setRaw(dsprawnew)
            End If

            If outputconnection Is Nothing Then
                dspconnectionnew = New DSPConnection()
                dspconnectionnew.setRaw(dspconnectionraw)
                outputconnection = dspconnectionnew
            Else
                outputconnection.setRaw(dspconnectionraw)
            End If

            Return result__1
        End Function

        Public Function setActive(ByVal active As Boolean) As RESULT
            Return FMOD_DSP_SetActive(dspraw, (If(active, 1, 0)))
        End Function
        Public Function getActive(ByRef active As Boolean) As RESULT
            Dim result As RESULT
            Dim a As Integer = 0

            result = FMOD_DSP_GetActive(dspraw, a)

            active = (a <> 0)

            Return result
        End Function
        Public Function setBypass(ByVal bypass As Boolean) As RESULT
            Return FMOD_DSP_SetBypass(dspraw, (If(bypass, 1, 0)))
        End Function
        Public Function getBypass(ByRef bypass As Boolean) As RESULT
            Dim result As RESULT
            Dim b As Integer = 0

            result = FMOD_DSP_GetBypass(dspraw, b)

            bypass = (b <> 0)

            Return result
        End Function

        Public Function setSpeakerActive(ByVal speaker As SPEAKER, ByVal active As Boolean) As RESULT
            Return FMOD_DSP_SetSpeakerActive(dspraw, speaker, (If(active, 1, 0)))
        End Function
        Public Function getSpeakerActive(ByVal speaker As SPEAKER, ByRef active As Boolean) As RESULT
            Dim result As RESULT
            Dim a As Integer = 0

            result = FMOD_DSP_GetSpeakerActive(dspraw, speaker, a)

            active = (a <> 0)

            Return result
        End Function

        Public Function reset() As RESULT
            Return FMOD_DSP_Reset(dspraw)
        End Function


        Public Function setParameter(ByVal index As Integer, ByVal value As Single) As RESULT
            Return FMOD_DSP_SetParameter(dspraw, index, value)
        End Function
        Public Function getParameter(ByVal index As Integer, ByRef value As Single, ByVal valuestr As StringBuilder, ByVal valuestrlen As Integer) As RESULT
            Return FMOD_DSP_GetParameter(dspraw, index, value, valuestr, valuestrlen)
        End Function
        Public Function getNumParameters(ByRef numparams As Integer) As RESULT
            Return FMOD_DSP_GetNumParameters(dspraw, numparams)
        End Function
        Public Function getParameterInfo(ByVal index As Integer, ByVal name As StringBuilder, ByVal label As StringBuilder, ByVal description As StringBuilder, ByVal descriptionlen As Integer, ByRef min As Single, _
         ByRef max As Single) As RESULT
            Return FMOD_DSP_GetParameterInfo(dspraw, index, name, label, description, descriptionlen, _
             min, max)
        End Function
        Public Function showConfigDialog(ByVal hwnd As IntPtr, ByVal show As Boolean) As RESULT
            Return FMOD_DSP_ShowConfigDialog(dspraw, hwnd, (If(show, 1, 0)))
        End Function


        Public Function getInfo(ByRef name As IntPtr, ByRef version As UInteger, ByRef channels As Integer, ByRef configwidth As Integer, ByRef configheight As Integer) As RESULT
            Return FMOD_DSP_GetInfo(dspraw, name, version, channels, configwidth, configheight)
        End Function
        Public Overloads Function [getType](ByRef type As DSP_TYPE) As RESULT
            Return FMOD_DSP_GetType(dspraw, type)
        End Function
        Public Function setDefaults(ByVal frequency As Single, ByVal volume As Single, ByVal pan As Single, ByVal priority As Integer) As RESULT
            Return FMOD_DSP_SetDefaults(dspraw, frequency, volume, pan, priority)
        End Function
        Public Function getDefaults(ByRef frequency As Single, ByRef volume As Single, ByRef pan As Single, ByRef priority As Integer) As RESULT
            Return FMOD_DSP_GetDefaults(dspraw, frequency, volume, pan, priority)
        End Function


        Public Function setUserData(ByVal userdata As IntPtr) As RESULT
            Return FMOD_DSP_SetUserData(dspraw, userdata)
        End Function
        Public Function getUserData(ByRef userdata As IntPtr) As RESULT
            Return FMOD_DSP_GetUserData(dspraw, userdata)
        End Function

        Public Function getMemoryInfo(ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
            Return FMOD_DSP_GetMemoryInfo(dspraw, memorybits, event_memorybits, memoryused, memoryused_details)
        End Function

#Region "importfunctions"

        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_Release(ByVal dsp As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_GetSystemObject(ByVal dsp As IntPtr, ByRef system As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_AddInput(ByVal dsp As IntPtr, ByVal target As IntPtr, ByRef connection As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_DisconnectFrom(ByVal dsp As IntPtr, ByVal target As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_DisconnectAll(ByVal dsp As IntPtr, ByVal inputs As Integer, ByVal outputs As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_Remove(ByVal dsp As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_GetNumInputs(ByVal dsp As IntPtr, ByRef numinputs As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_GetNumOutputs(ByVal dsp As IntPtr, ByRef numoutputs As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_GetInput(ByVal dsp As IntPtr, ByVal index As Integer, ByRef input As IntPtr, ByRef inputconnection As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_GetOutput(ByVal dsp As IntPtr, ByVal index As Integer, ByRef output As IntPtr, ByRef outputconnection As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_SetActive(ByVal dsp As IntPtr, ByVal active As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_GetActive(ByVal dsp As IntPtr, ByRef active As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_SetBypass(ByVal dsp As IntPtr, ByVal bypass As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_GetBypass(ByVal dsp As IntPtr, ByRef bypass As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_SetSpeakerActive(ByVal dsp As IntPtr, ByVal speaker As SPEAKER, ByVal active As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_GetSpeakerActive(ByVal dsp As IntPtr, ByVal speaker As SPEAKER, ByRef active As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_Reset(ByVal dsp As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_SetParameter(ByVal dsp As IntPtr, ByVal index As Integer, ByVal value As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_GetParameter(ByVal dsp As IntPtr, ByVal index As Integer, ByRef value As Single, ByVal valuestr As StringBuilder, ByVal valuestrlen As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_GetNumParameters(ByVal dsp As IntPtr, ByRef numparams As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_GetParameterInfo(ByVal dsp As IntPtr, ByVal index As Integer, ByVal name As StringBuilder, ByVal label As StringBuilder, ByVal description As StringBuilder, ByVal descriptionlen As Integer, _
   ByRef min As Single, ByRef max As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_ShowConfigDialog(ByVal dsp As IntPtr, ByVal hwnd As IntPtr, ByVal show As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_GetInfo(ByVal dsp As IntPtr, ByRef name As IntPtr, ByRef version__1 As UInteger, ByRef channels As Integer, ByRef configwidth As Integer, ByRef configheight As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_GetType(ByVal dsp As IntPtr, ByRef type As DSP_TYPE) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_SetDefaults(ByVal dsp As IntPtr, ByVal frequency As Single, ByVal volume As Single, ByVal pan As Single, ByVal priority As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_GetDefaults(ByVal dsp As IntPtr, ByRef frequency As Single, ByRef volume As Single, ByRef pan As Single, ByRef priority As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_SetUserData(ByVal dsp As IntPtr, ByVal userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_GetUserData(ByVal dsp As IntPtr, ByRef userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSP_GetMemoryInfo(ByVal dsp As IntPtr, ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
        End Function
#End Region

#Region "wrapperinternal"

        Private dspraw As IntPtr

        Public Sub setRaw(ByVal dsp As IntPtr)
            dspraw = New IntPtr()

            dspraw = dsp
        End Sub

        Public Function getRaw() As IntPtr
            Return dspraw
        End Function

#End Region
    End Class


    '
    '        'DSPConnection' API
    '    

    Public Class DSPConnection
        Public Function getInput(ByRef input As DSP) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim dspraw As New IntPtr()
            Dim dspnew As DSP = Nothing

            Try
                result__1 = FMOD_DSPConnection_GetInput(dspconnectionraw, dspraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If input Is Nothing Then
                dspnew = New DSP()
                dspnew.setRaw(dspraw)
                input = dspnew
            Else
                input.setRaw(dspraw)
            End If

            Return result__1
        End Function
        Public Function getOutput(ByRef output As DSP) As RESULT
            Dim result__1 As RESULT = RESULT.OK
            Dim dspraw As New IntPtr()
            Dim dspnew As DSP = Nothing

            Try
                result__1 = FMOD_DSPConnection_GetOutput(dspconnectionraw, dspraw)
            Catch
                result__1 = RESULT.ERR_INVALID_PARAM
            End Try
            If result__1 <> RESULT.OK Then
                Return result__1
            End If

            If output Is Nothing Then
                dspnew = New DSP()
                dspnew.setRaw(dspraw)
                output = dspnew
            Else
                output.setRaw(dspraw)
            End If

            Return result__1
        End Function
        Public Function setMix(ByVal volume As Single) As RESULT
            Return FMOD_DSPConnection_SetMix(dspconnectionraw, volume)
        End Function
        Public Function getMix(ByRef volume As Single) As RESULT
            Return FMOD_DSPConnection_GetMix(dspconnectionraw, volume)
        End Function
        Public Function setLevels(ByVal speaker As SPEAKER, ByVal levels As Single(), ByVal numlevels As Integer) As RESULT
            Return FMOD_DSPConnection_SetLevels(dspconnectionraw, speaker, levels, numlevels)
        End Function
        Public Function getLevels(ByVal speaker As SPEAKER, ByVal levels As Single(), ByVal numlevels As Integer) As RESULT
            Return FMOD_DSPConnection_GetLevels(dspconnectionraw, speaker, levels, numlevels)
        End Function
        Public Function setUserData(ByVal userdata As IntPtr) As RESULT
            Return FMOD_DSPConnection_SetUserData(dspconnectionraw, userdata)
        End Function
        Public Function getUserData(ByRef userdata As IntPtr) As RESULT
            Return FMOD_DSPConnection_GetUserData(dspconnectionraw, userdata)
        End Function

        Public Function getMemoryInfo(ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
            Return FMOD_DSPConnection_GetMemoryInfo(dspconnectionraw, memorybits, event_memorybits, memoryused, memoryused_details)
        End Function

#Region "importfunctions"

        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSPConnection_GetInput(ByVal dspconnection As IntPtr, ByRef input As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSPConnection_GetOutput(ByVal dspconnection As IntPtr, ByRef output As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSPConnection_SetMix(ByVal dspconnection As IntPtr, ByVal volume As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSPConnection_GetMix(ByVal dspconnection As IntPtr, ByRef volume As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSPConnection_SetLevels(ByVal dspconnection As IntPtr, ByVal speaker As SPEAKER, ByVal levels As Single(), ByVal numlevels As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSPConnection_GetLevels(ByVal dspconnection As IntPtr, ByVal speaker As SPEAKER, <MarshalAs(UnmanagedType.LPArray)> ByVal levels As Single(), ByVal numlevels As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSPConnection_SetUserData(ByVal dspconnection As IntPtr, ByVal userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSPConnection_GetUserData(ByVal dspconnection As IntPtr, ByRef userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_DSPConnection_GetMemoryInfo(ByVal dspconnection As IntPtr, ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
        End Function
#End Region

#Region "wrapperinternal"

        Private dspconnectionraw As IntPtr

        Public Sub setRaw(ByVal dspconnection As IntPtr)
            dspconnectionraw = New IntPtr()

            dspconnectionraw = dspconnection
        End Sub

        Public Function getRaw() As IntPtr
            Return dspconnectionraw
        End Function

#End Region
    End Class

    '
    '        'Geometry' API
    '    

    Public Class Geometry
        Public Function release() As RESULT
            Return FMOD_Geometry_Release(geometryraw)
        End Function
        Public Function addPolygon(ByVal directocclusion As Single, ByVal reverbocclusion As Single, ByVal doublesided As Boolean, ByVal numvertices As Integer, ByVal vertices As VECTOR(), ByRef polygonindex As Integer) As RESULT
            Return FMOD_Geometry_AddPolygon(geometryraw, directocclusion, reverbocclusion, (If(doublesided, 1, 0)), numvertices, vertices, _
             polygonindex)
        End Function


        Public Function getNumPolygons(ByRef numpolygons As Integer) As RESULT
            Return FMOD_Geometry_GetNumPolygons(geometryraw, numpolygons)
        End Function
        Public Function getMaxPolygons(ByRef maxpolygons As Integer, ByRef maxvertices As Integer) As RESULT
            Return FMOD_Geometry_GetMaxPolygons(geometryraw, maxpolygons, maxvertices)
        End Function
        Public Function getPolygonNumVertices(ByVal index As Integer, ByRef numvertices As Integer) As RESULT
            Return FMOD_Geometry_GetPolygonNumVertices(geometryraw, index, numvertices)
        End Function
        Public Function setPolygonVertex(ByVal index As Integer, ByVal vertexindex As Integer, ByRef vertex As VECTOR) As RESULT
            Return FMOD_Geometry_SetPolygonVertex(geometryraw, index, vertexindex, vertex)
        End Function
        Public Function getPolygonVertex(ByVal index As Integer, ByVal vertexindex As Integer, ByRef vertex As VECTOR) As RESULT
            Return FMOD_Geometry_GetPolygonVertex(geometryraw, index, vertexindex, vertex)
        End Function
        Public Function setPolygonAttributes(ByVal index As Integer, ByVal directocclusion As Single, ByVal reverbocclusion As Single, ByVal doublesided As Boolean) As RESULT
            Return FMOD_Geometry_SetPolygonAttributes(geometryraw, index, directocclusion, reverbocclusion, (If(doublesided, 1, 0)))
        End Function
        Public Function getPolygonAttributes(ByVal index As Integer, ByRef directocclusion As Single, ByRef reverbocclusion As Single, ByRef doublesided As Boolean) As RESULT
            Dim result As RESULT
            Dim ds As Integer = 0

            result = FMOD_Geometry_GetPolygonAttributes(geometryraw, index, directocclusion, reverbocclusion, ds)

            doublesided = (ds <> 0)

            Return result
        End Function

        Public Function setActive(ByVal active As Boolean) As RESULT
            Return FMOD_Geometry_SetActive(geometryraw, (If(active, 1, 0)))
        End Function
        Public Function getActive(ByRef active As Boolean) As RESULT
            Dim result As RESULT
            Dim a As Integer = 0

            result = FMOD_Geometry_GetActive(geometryraw, a)

            active = (a <> 0)

            Return result
        End Function
        Public Function setRotation(ByRef forward As VECTOR, ByRef up As VECTOR) As RESULT
            Return FMOD_Geometry_SetRotation(geometryraw, forward, up)
        End Function
        Public Function getRotation(ByRef forward As VECTOR, ByRef up As VECTOR) As RESULT
            Return FMOD_Geometry_GetRotation(geometryraw, forward, up)
        End Function
        Public Function setPosition(ByRef position As VECTOR) As RESULT
            Return FMOD_Geometry_SetPosition(geometryraw, position)
        End Function
        Public Function getPosition(ByRef position As VECTOR) As RESULT
            Return FMOD_Geometry_GetPosition(geometryraw, position)
        End Function
        Public Function setScale(ByRef scale As VECTOR) As RESULT
            Return FMOD_Geometry_SetScale(geometryraw, scale)
        End Function
        Public Function getScale(ByRef scale As VECTOR) As RESULT
            Return FMOD_Geometry_GetScale(geometryraw, scale)
        End Function
        Public Function save(ByVal data As IntPtr, ByRef datasize As Integer) As RESULT
            Return FMOD_Geometry_Save(geometryraw, data, datasize)
        End Function


        Public Function setUserData(ByVal userdata As IntPtr) As RESULT
            Return FMOD_Geometry_SetUserData(geometryraw, userdata)
        End Function
        Public Function getUserData(ByRef userdata As IntPtr) As RESULT
            Return FMOD_Geometry_GetUserData(geometryraw, userdata)
        End Function

        Public Function getMemoryInfo(ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
            Return FMOD_Geometry_GetMemoryInfo(geometryraw, memorybits, event_memorybits, memoryused, memoryused_details)
        End Function

#Region "importfunctions"

        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_Release(ByVal geometry As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_AddPolygon(ByVal geometry As IntPtr, ByVal directocclusion As Single, ByVal reverbocclusion As Single, ByVal doublesided As Integer, ByVal numvertices As Integer, ByVal vertices As VECTOR(), _
   ByRef polygonindex As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_GetNumPolygons(ByVal geometry As IntPtr, ByRef numpolygons As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_GetMaxPolygons(ByVal geometry As IntPtr, ByRef maxpolygons As Integer, ByRef maxvertices As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_GetPolygonNumVertices(ByVal geometry As IntPtr, ByVal index As Integer, ByRef numvertices As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_SetPolygonVertex(ByVal geometry As IntPtr, ByVal index As Integer, ByVal vertexindex As Integer, ByRef vertex As VECTOR) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_GetPolygonVertex(ByVal geometry As IntPtr, ByVal index As Integer, ByVal vertexindex As Integer, ByRef vertex As VECTOR) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_SetPolygonAttributes(ByVal geometry As IntPtr, ByVal index As Integer, ByVal directocclusion As Single, ByVal reverbocclusion As Single, ByVal doublesided As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_GetPolygonAttributes(ByVal geometry As IntPtr, ByVal index As Integer, ByRef directocclusion As Single, ByRef reverbocclusion As Single, ByRef doublesided As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_Flush(ByVal geometry As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_SetActive(ByVal geometry As IntPtr, ByVal active As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_GetActive(ByVal geometry As IntPtr, ByRef active As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_SetRotation(ByVal geometry As IntPtr, ByRef forward As VECTOR, ByRef up As VECTOR) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_GetRotation(ByVal geometry As IntPtr, ByRef forward As VECTOR, ByRef up As VECTOR) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_SetPosition(ByVal geometry As IntPtr, ByRef position As VECTOR) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_GetPosition(ByVal geometry As IntPtr, ByRef position As VECTOR) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_SetScale(ByVal geometry As IntPtr, ByRef scale As VECTOR) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_GetScale(ByVal geometry As IntPtr, ByRef scale As VECTOR) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_Save(ByVal geometry As IntPtr, ByVal data As IntPtr, ByRef datasize As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_SetUserData(ByVal geometry As IntPtr, ByVal userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_GetUserData(ByVal geometry As IntPtr, ByRef userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Geometry_GetMemoryInfo(ByVal geometry As IntPtr, ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
        End Function
#End Region

#Region "wrapperinternal"

        Private geometryraw As IntPtr

        Public Sub setRaw(ByVal geometry As IntPtr)
            geometryraw = New IntPtr()

            geometryraw = geometry
        End Sub

        Public Function getRaw() As IntPtr
            Return geometryraw
        End Function

#End Region
    End Class

    '
    '        'Reverb' API
    '    

    Public Class Reverb

        Public Function release() As RESULT
            Return FMOD_Reverb_Release(reverbraw)
        End Function

        ' Reverb manipulation.
        Public Function set3DAttributes(ByRef position As VECTOR, ByVal mindistance As Single, ByVal maxdistance As Single) As RESULT
            Return FMOD_Reverb_Set3DAttributes(reverbraw, position, mindistance, maxdistance)
        End Function
        Public Function get3DAttributes(ByRef position As VECTOR, ByRef mindistance As Single, ByRef maxdistance As Single) As RESULT
            Return FMOD_Reverb_Get3DAttributes(reverbraw, position, mindistance, maxdistance)
        End Function
        Public Function setProperties(ByRef properties As REVERB_PROPERTIES) As RESULT
            Return FMOD_Reverb_SetProperties(reverbraw, properties)
        End Function
        Public Function getProperties(ByRef properties As REVERB_PROPERTIES) As RESULT
            Return FMOD_Reverb_GetProperties(reverbraw, properties)
        End Function
        Public Function setActive(ByVal active As Boolean) As RESULT
            Return FMOD_Reverb_SetActive(reverbraw, (If(active, 1, 0)))
        End Function
        Public Function getActive(ByRef active As Boolean) As RESULT
            Dim result As RESULT
            Dim a As Integer = 0

            result = FMOD_Reverb_GetActive(reverbraw, a)

            active = (a <> 0)

            Return result
        End Function

        ' Userdata set/get.
        Public Function setUserData(ByVal userdata As IntPtr) As RESULT
            Return FMOD_Reverb_SetUserData(reverbraw, userdata)
        End Function
        Public Function getUserData(ByRef userdata As IntPtr) As RESULT
            Return FMOD_Reverb_GetUserData(reverbraw, userdata)
        End Function

        Public Function getMemoryInfo(ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
            Return FMOD_Reverb_GetMemoryInfo(reverbraw, memorybits, event_memorybits, memoryused, memoryused_details)
        End Function

#Region "importfunctions"

        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Reverb_Release(ByVal reverb As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Reverb_Set3DAttributes(ByVal reverb As IntPtr, ByRef position As VECTOR, ByVal mindistance As Single, ByVal maxdistance As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Reverb_Get3DAttributes(ByVal reverb As IntPtr, ByRef position As VECTOR, ByRef mindistance As Single, ByRef maxdistance As Single) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Reverb_SetProperties(ByVal reverb As IntPtr, ByRef properties As REVERB_PROPERTIES) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Reverb_GetProperties(ByVal reverb As IntPtr, ByRef properties As REVERB_PROPERTIES) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Reverb_SetActive(ByVal reverb As IntPtr, ByVal active As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Reverb_GetActive(ByVal reverb As IntPtr, ByRef active As Integer) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Reverb_SetUserData(ByVal reverb As IntPtr, ByVal userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Reverb_GetUserData(ByVal reverb As IntPtr, ByRef userdata As IntPtr) As RESULT
        End Function
        <DllImport(VERSION.dll)> _
        Private Shared Function FMOD_Reverb_GetMemoryInfo(ByVal reverb As IntPtr, ByVal memorybits As UInteger, ByVal event_memorybits As UInteger, ByRef memoryused As UInteger, ByRef memoryused_details As MEMORY_USAGE_DETAILS) As RESULT
        End Function
#End Region

#Region "wrapperinternal"

        Private reverbraw As IntPtr

        Public Sub setRaw(ByVal rev As IntPtr)
            reverbraw = New IntPtr()

            reverbraw = rev
        End Sub

        Public Function getRaw() As IntPtr
            Return reverbraw
        End Function

#End Region
    End Class
End Namespace

