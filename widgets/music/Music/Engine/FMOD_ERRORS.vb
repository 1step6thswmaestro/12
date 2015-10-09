' ============================================================================================= = 

' FMOD Ex - Error string header file. Copyright (c), Firelight Technologies Pty, Ltd. 2004-2011.  

'                                                                                                 

' Use this header if you want to store or display a string version / english explanation of       

' the FMOD error codes.                                                                           

'                                                                                                 

' =============================================================================================== 


Namespace FMOD
    Public Class [Error]
        Public Shared Function [String](ByVal errcode As FMOD.RESULT) As String
            Select Case errcode
                Case FMOD.RESULT.OK
                    Return "No errors."
                Case FMOD.RESULT.ERR_ALREADYLOCKED
                    Return "Tried to call lock a second time before unlock was called. "
                Case FMOD.RESULT.ERR_BADCOMMAND
                    Return "Tried to call a function on a data type that does not allow this type of functionality (ie calling Sound::lock on a streaming sound). "
                Case FMOD.RESULT.ERR_CDDA_DRIVERS
                    Return "Neither NTSCSI nor ASPI could be initialised. "
                Case FMOD.RESULT.ERR_CDDA_INIT
                    Return "An error occurred while initialising the CDDA subsystem. "
                Case FMOD.RESULT.ERR_CDDA_INVALID_DEVICE
                    Return "Couldn't find the specified device. "
                Case FMOD.RESULT.ERR_CDDA_NOAUDIO
                    Return "No audio tracks on the specified disc. "
                Case FMOD.RESULT.ERR_CDDA_NODEVICES
                    Return "No CD/DVD devices were found. "
                Case FMOD.RESULT.ERR_CDDA_NODISC
                    Return "No disc present in the specified drive. "
                Case FMOD.RESULT.ERR_CDDA_READ
                    Return "A CDDA read error occurred. "
                Case FMOD.RESULT.ERR_CHANNEL_ALLOC
                    Return "Error trying to allocate a channel. "
                Case FMOD.RESULT.ERR_CHANNEL_STOLEN
                    Return "The specified channel has been reused to play another sound. "
                Case FMOD.RESULT.ERR_COM
                    Return "A Win32 COM related error occured. COM failed to initialize or a QueryInterface failed meaning a Windows codec or driver was not installed properly. "
                Case FMOD.RESULT.ERR_DMA
                    Return "DMA Failure.  See debug output for more information. "
                Case FMOD.RESULT.ERR_DSP_CONNECTION
                    Return "DSP connection error.  Connection possibly caused a cyclic dependancy. "
                Case FMOD.RESULT.ERR_DSP_FORMAT
                    Return "DSP Format error.  A DSP unit may have attempted to connect to this network with the wrong format. "
                Case FMOD.RESULT.ERR_DSP_NOTFOUND
                    Return "DSP connection error.  Couldn't find the DSP unit specified. "
                Case FMOD.RESULT.ERR_DSP_RUNNING
                    Return "DSP error.  Cannot perform this operation while the network is in the middle of running.  This will most likely happen if a connection or disconnection is attempted in a DSP callback. "
                Case FMOD.RESULT.ERR_DSP_TOOMANYCONNECTIONS
                    Return "DSP connection error.  The unit being connected to or disconnected should only have 1 input or output. "
                Case FMOD.RESULT.ERR_FILE_BAD
                    Return "Error loading file. "
                Case FMOD.RESULT.ERR_FILE_COULDNOTSEEK
                    Return "Couldn't perform seek operation.  This is a limitation of the medium (ie netstreams) or the file format. "
                Case FMOD.RESULT.ERR_FILE_DISKEJECTED
                    Return "Media was ejected while reading. "
                Case FMOD.RESULT.ERR_FILE_EOF
                    Return "End of file unexpectedly reached while trying to read essential data (truncated data?). "
                Case FMOD.RESULT.ERR_FILE_NOTFOUND
                    Return "File not found. "
                Case FMOD.RESULT.ERR_FILE_UNWANTED
                    Return "Unwanted file access occured. "
                Case FMOD.RESULT.ERR_FORMAT
                    Return "Unsupported file or audio format. "
                Case FMOD.RESULT.ERR_HTTP
                    Return "A HTTP error occurred. This is a catch-all for HTTP errors not listed elsewhere. "
                Case FMOD.RESULT.ERR_HTTP_ACCESS
                    Return "The specified resource requires authentication or is forbidden. "
                Case FMOD.RESULT.ERR_HTTP_PROXY_AUTH
                    Return "Proxy authentication is required to access the specified resource. "
                Case FMOD.RESULT.ERR_HTTP_SERVER_ERROR
                    Return "A HTTP server error occurred. "
                Case FMOD.RESULT.ERR_HTTP_TIMEOUT
                    Return "The HTTP request timed out. "
                Case FMOD.RESULT.ERR_INITIALIZATION
                    Return "FMOD was not initialized correctly to support this function. "
                Case FMOD.RESULT.ERR_INITIALIZED
                    Return "Cannot call this command after System::init. "
                Case FMOD.RESULT.ERR_INTERNAL
                    Return "An error occured that wasn't supposed to.  Contact support. "
                Case FMOD.RESULT.ERR_INVALID_ADDRESS
                    Return "On Xbox 360, this memory address passed to FMOD must be physical, (ie allocated with XPhysicalAlloc.) "
                Case FMOD.RESULT.ERR_INVALID_FLOAT
                    Return "Value passed in was a NaN, Inf or denormalized float. "
                Case FMOD.RESULT.ERR_INVALID_HANDLE
                    Return "An invalid object handle was used. "
                Case FMOD.RESULT.ERR_INVALID_PARAM
                    Return "An invalid parameter was passed to this function. "
                Case FMOD.RESULT.ERR_INVALID_POSITION
                    Return "An invalid seek position was passed to this function. "
                Case FMOD.RESULT.ERR_INVALID_SPEAKER
                    Return "An invalid speaker was passed to this function based on the current speaker mode. "
                Case FMOD.RESULT.ERR_INVALID_SYNCPOINT
                    Return "The syncpoint did not come from this sound handle."
                Case FMOD.RESULT.ERR_INVALID_VECTOR
                    Return "The vectors passed in are not unit length, or perpendicular. "
                Case FMOD.RESULT.ERR_MAXAUDIBLE
                    Return "Reached maximum audible playback count for this sound's soundgroup. "
                Case FMOD.RESULT.ERR_MEMORY
                    Return "Not enough memory or resources. "
                Case FMOD.RESULT.ERR_MEMORY_CANTPOINT
                    Return "Can't use FMOD_OPENMEMORY_POINT on non PCM source data, or non mp3/xma/adpcm data if FMOD_CREATECOMPRESSEDSAMPLE was used. "
                Case FMOD.RESULT.ERR_MEMORY_SRAM
                    Return "Not enough memory or resources on console sound ram. "
                Case FMOD.RESULT.ERR_NEEDS2D
                    Return "Tried to call a command on a 3d sound when the command was meant for 2d sound. "
                Case FMOD.RESULT.ERR_NEEDS3D
                    Return "Tried to call a command on a 2d sound when the command was meant for 3d sound. "
                Case FMOD.RESULT.ERR_NEEDSHARDWARE
                    Return "Tried to use a feature that requires hardware support.  (ie trying to play a VAG compressed sound in software on PS2). "
                Case FMOD.RESULT.ERR_NEEDSSOFTWARE
                    Return "Tried to use a feature that requires the software engine.  Software engine has either been turned off, or command was executed on a hardware channel which does not support this feature. "
                Case FMOD.RESULT.ERR_NET_CONNECT
                    Return "Couldn't connect to the specified host. "
                Case FMOD.RESULT.ERR_NET_SOCKET_ERROR
                    Return "A socket error occurred.  This is a catch-all for socket-related errors not listed elsewhere. "
                Case FMOD.RESULT.ERR_NET_URL
                    Return "The specified URL couldn't be resolved. "
                Case FMOD.RESULT.ERR_NET_WOULD_BLOCK
                    Return "Operation on a non-blocking socket could not complete immediately. "
                Case FMOD.RESULT.ERR_NOTREADY
                    Return "Operation could not be performed because specified sound is not ready. "
                Case FMOD.RESULT.ERR_OUTPUT_ALLOCATED
                    Return "Error initializing output device, but more specifically, the output device is already in use and cannot be reused. "
                Case FMOD.RESULT.ERR_OUTPUT_CREATEBUFFER
                    Return "Error creating hardware sound buffer. "
                Case FMOD.RESULT.ERR_OUTPUT_DRIVERCALL
                    Return "A call to a standard soundcard driver failed, which could possibly mean a bug in the driver or resources were missing or exhausted. "
                Case FMOD.RESULT.ERR_OUTPUT_ENUMERATION
                    Return "Error enumerating the available driver list. List may be inconsistent due to a recent device addition or removal."
                Case FMOD.RESULT.ERR_OUTPUT_FORMAT
                    Return "Soundcard does not support the minimum features needed for this soundsystem (16bit stereo output). "
                Case FMOD.RESULT.ERR_OUTPUT_INIT
                    Return "Error initializing output device. "
                Case FMOD.RESULT.ERR_OUTPUT_NOHARDWARE
                    Return "FMOD_HARDWARE was specified but the sound card does not have the resources nescessary to play it. "
                Case FMOD.RESULT.ERR_OUTPUT_NOSOFTWARE
                    Return "Attempted to create a software sound but no software channels were specified in System::init. "
                Case FMOD.RESULT.ERR_PAN
                    Return "Panning only works with mono or stereo sound sources. "
                Case FMOD.RESULT.ERR_PLUGIN
                    Return "An unspecified error has been returned from a 3rd party plugin. "
                Case FMOD.RESULT.ERR_PLUGIN_INSTANCES
                    Return "The number of allowed instances of a plugin has been exceeded "
                Case FMOD.RESULT.ERR_PLUGIN_MISSING
                    Return "A requested output, dsp unit type or codec was not available. "
                Case FMOD.RESULT.ERR_PLUGIN_RESOURCE
                    Return "A resource that the plugin requires cannot be found. (ie the DLS file for MIDI playback) "
                Case FMOD.RESULT.ERR_PRELOADED
                    Return "The specified sound is still in use by the event system, call EventSystem::unloadFSB before trying to release it. "
                Case FMOD.RESULT.ERR_PROGRAMMERSOUND
                    Return "The specified sound is still in use by the event system, wait for the event which is using it finish with it. "
                Case FMOD.RESULT.ERR_RECORD
                    Return "An error occured trying to initialize the recording device. "
                Case FMOD.RESULT.ERR_REVERB_INSTANCE
                    Return "Specified Instance in FMOD_REVERB_PROPERTIES couldn't be set. Most likely because another application has locked the EAX4 FX slot. "
                Case FMOD.RESULT.ERR_SUBSOUND_ALLOCATED
                    Return "This subsound is already being used by another sound, you cannot have more than one parent to a sound.  Null out the other parent's entry first. "
                Case FMOD.RESULT.ERR_SUBSOUND_CANTMOVE
                    Return "Shared subsounds cannot be replaced or moved from their parent stream, such as when the parent stream is an FSB file."
                Case FMOD.RESULT.ERR_SUBSOUND_MODE
                    Return "The subsound's mode bits do not match with the parent sound's mode bits.  See documentation for function that it was called with."
                Case FMOD.RESULT.ERR_SUBSOUNDS
                    Return "The error occured because the sound referenced contains subsounds.  (ie you cannot play the parent sound as a static sample, only its subsounds.) "
                Case FMOD.RESULT.ERR_TAGNOTFOUND
                    Return "The specified tag could not be found or there are no tags. "
                Case FMOD.RESULT.ERR_TOOMANYCHANNELS
                    Return "The sound created exceeds the allowable input channel count.  This can be increased using the maxinputchannels parameter in System::setSoftwareFormat. "
                Case FMOD.RESULT.ERR_UNIMPLEMENTED
                    Return "Something in FMOD hasn't been implemented when it should be! contact support! "
                Case FMOD.RESULT.ERR_UNINITIALIZED
                    Return "This command failed because System::init or System::setDriver was not called. "
                Case FMOD.RESULT.ERR_UNSUPPORTED
                    Return "A command issued was not supported by this object.  Possibly a plugin without certain callbacks specified. "
                Case FMOD.RESULT.ERR_UPDATE
                    Return "An error caused by System::update occured. "
                Case FMOD.RESULT.ERR_VERSION
                    Return "The version number of this file format is not supported. "

                Case FMOD.RESULT.ERR_EVENT_FAILED
                    Return "An Event failed to be retrieved, most likely due to 'just fail' being specified as the max playbacks behavior. "
                Case FMOD.RESULT.ERR_EVENT_GUIDCONFLICT
                    Return "An event with the same GUID already exists. "
                Case FMOD.RESULT.ERR_EVENT_INFOONLY
                    Return "Can't execute this command on an EVENT_INFOONLY event. "
                Case FMOD.RESULT.ERR_EVENT_INTERNAL
                    Return "An error occured that wasn't supposed to.  See debug log for reason. "
                Case FMOD.RESULT.ERR_EVENT_MAXSTREAMS
                    Return "Event failed because 'Max streams' was hit when FMOD_INIT_FAIL_ON_MAXSTREAMS was specified. "
                Case FMOD.RESULT.ERR_EVENT_MISMATCH
                    Return "FSB mis-matches the FEV it was compiled with. "
                Case FMOD.RESULT.ERR_EVENT_NAMECONFLICT
                    Return "A category with the same name already exists. "
                Case FMOD.RESULT.ERR_EVENT_NEEDSSIMPLE
                    Return "Tried to call a function on a complex event that's only supported by simple events. "
                Case FMOD.RESULT.ERR_EVENT_NOTFOUND
                    Return "The requested event, event group, event category or event property could not be found. "
                Case FMOD.RESULT.ERR_EVENT_ALREADY_LOADED
                    Return "The specified project has already been loaded. Having multiple copies of the same project loaded simultaneously is forbidden. "

                Case FMOD.RESULT.ERR_MUSIC_NOCALLBACK
                    Return "The music callback is required, but it has not been set. "
                Case FMOD.RESULT.ERR_MUSIC_UNINITIALIZED
                    Return "Music system is not initialized probably because no music data is loaded. "
                Case FMOD.RESULT.ERR_MUSIC_NOTFOUND
                    Return "The requested music entity could not be found."
                Case Else

                    Return "Unknown error."
            End Select
        End Function
    End Class
End Namespace
