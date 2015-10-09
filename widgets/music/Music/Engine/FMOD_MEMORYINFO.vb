' ============================================================================================= 

' FMOD Ex - Memory info header file. Copyright (c), Firelight Technologies Pty, Ltd. 2009-2011. 

'                                                                                               

' Use this header if you are interested in getting detailed information on FMOD's memory        

' usage. See the documentation for more details.                                                

'                                                                                               

' ============================================================================================= 


Imports System.Runtime.InteropServices

Namespace FMOD
    '
    '    [STRUCTURE]
    '    [
    '        [DESCRIPTION]
    '        Structure to be filled with detailed memory usage information of an FMOD object
    '
    '        [REMARKS]
    '        Every public FMOD class has a getMemoryInfo function which can be used to get detailed information on what memory resources are associated with the object in question. 
    '        On return from getMemoryInfo, each member of this structure will hold the amount of memory used for its type in bytes.<br>
    '        <br>
    '        Members marked with [in] mean the user sets the value before passing it to the function.<br>
    '        Members marked with [out] mean FMOD sets the value to be used after the function exits.<br>
    '
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3
    '
    '        [SEE_ALSO]
    '        System::getMemoryInfo
    '        EventSystem::getMemoryInfo
    '        FMOD_MEMBITS    
    '        FMOD_EVENT_MEMBITS
    '    ]
    '    

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure MEMORY_USAGE_DETAILS
        Public other As UInteger
        ' [out] Memory not accounted for by other types 
        Public stringdata As UInteger
        ' [out] String data 
        Public system As UInteger
        ' [out] System object and various internals 
        Public plugins As UInteger
        ' [out] Plugin objects and internals 
        Public output As UInteger
        ' [out] Output module object and internals 
        Public channel As UInteger
        ' [out] Channel related memory 
        Public channelgroup As UInteger
        ' [out] ChannelGroup objects and internals 
        Public codec As UInteger
        ' [out] Codecs allocated for streaming 
        Public file As UInteger
        ' [out] File buffers and structures 
        Public sound As UInteger
        ' [out] Sound objects and internals 
        Public secondaryram As UInteger
        ' [out] Sound data stored in secondary RAM 
        Public soundgroup As UInteger
        ' [out] SoundGroup objects and internals 
        Public streambuffer As UInteger
        ' [out] Stream buffer memory 
        Public dspconnection As UInteger
        ' [out] DSPConnection objects and internals 
        Public dsp As UInteger
        ' [out] DSP implementation objects 
        Public dspcodec As UInteger
        ' [out] Realtime file format decoding DSP objects 
        Public profile As UInteger
        ' [out] Profiler memory footprint. 
        Public recordbuffer As UInteger
        ' [out] Buffer used to store recorded data from microphone 
        Public reverb As UInteger
        ' [out] Reverb implementation objects 
        Public reverbchannelprops As UInteger
        ' [out] Reverb channel properties structs 
        Public geometry As UInteger
        ' [out] Geometry objects and internals 
        Public syncpoint As UInteger
        ' [out] Sync point memory. 
        Public eventsystem As UInteger
        ' [out] EventSystem and various internals 
        Public musicsystem As UInteger
        ' [out] MusicSystem and various internals 
        Public fev As UInteger
        ' [out] Definition of objects contained in all loaded projects e.g. events, groups, categories 
        Public memoryfsb As UInteger
        ' [out] Data loaded with registerMemoryFSB 
        Public eventproject As UInteger
        ' [out] EventProject objects and internals 
        Public eventgroupi As UInteger
        ' [out] EventGroup objects and internals 
        Public soundbankclass As UInteger
        ' [out] Objects used to manage wave banks 
        Public soundbanklist As UInteger
        ' [out] Data used to manage lists of wave bank usage 
        Public streaminstance As UInteger
        ' [out] Stream objects and internals 
        Public sounddefclass As UInteger
        ' [out] Sound definition objects 
        Public sounddefdefclass As UInteger
        ' [out] Sound definition static data objects 
        Public sounddefpool As UInteger
        ' [out] Sound definition pool data 
        Public reverbdef As UInteger
        ' [out] Reverb definition objects 
        Public eventreverb As UInteger
        ' [out] Reverb objects 
        Public userproperty As UInteger
        ' [out] User property objects 
        Public eventinstance As UInteger
        ' [out] Event instance base objects 
        Public eventinstance_complex As UInteger
        ' [out] Complex event instance objects 
        Public eventinstance_simple As UInteger
        ' [out] Simple event instance objects 
        Public eventinstance_layer As UInteger
        ' [out] Event layer instance objects 
        Public eventinstance_sound As UInteger
        ' [out] Event sound instance objects 
        Public eventenvelope As UInteger
        ' [out] Event envelope objects 
        Public eventenvelopedef As UInteger
        ' [out] Event envelope definition objects 
        Public eventparameter As UInteger
        ' [out] Event parameter objects 
        Public eventcategory As UInteger
        ' [out] Event category objects 
        Public eventenvelopepoint As UInteger
        ' [out] Event envelope point objects 
        Public eventinstancepool As UInteger
        ' [out] Event instance pool memory 
    End Structure


    '
    '    [DEFINE]
    '    [
    '        [NAME]
    '        FMOD_MEMBITS
    '
    '        [DESCRIPTION]
    '        Bitfield used to request specific memory usage information from the getMemoryInfo function of every public FMOD Ex class.<br>
    '        Use with the "memorybits" parameter of getMemoryInfo to get information on FMOD Ex memory usage.
    '
    '        [REMARKS]
    '        Every public FMOD class has a getMemoryInfo function which can be used to get detailed information on what memory resources are associated with the object in question. 
    '        The FMOD_MEMBITS defines can be OR'd together to specify precisely what memory usage you'd like to get information on. See System::getMemoryInfo for an example.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii, Solaris
    '
    '        [SEE_ALSO]
    '        FMOD_EVENT_MEMBITS
    '        EventSystem::getMemoryInfo
    '    ]
    '    

    Public Enum MEMBITS As UInteger
        OTHER = &H1
        ' Memory not accounted for by other types 
        [STRING] = &H2
        ' String data 

        SYSTEM = &H4
        ' System object and various internals 
        PLUGINS = &H8
        ' Plugin objects and internals 
        OUTPUT = &H10
        ' Output module object and internals 
        CHANNEL = &H20
        ' Channel related memory 
        CHANNELGROUP = &H40
        ' ChannelGroup objects and internals 
        CODEC = &H80
        ' Codecs allocated for streaming 
        FILE = &H100
        ' Codecs allocated for streaming 
        SOUND = &H200
        ' Sound objects and internals 
        SOUND_SECONDARYRAM = &H400
        ' Sound data stored in secondary RAM 
        SOUNDGROUP = &H800
        ' SoundGroup objects and internals 
        STREAMBUFFER = &H1000
        ' Stream buffer memory 
        DSPCONNECTION = &H2000
        ' DSPConnection objects and internals 
        DSP = &H4000
        ' DSP implementation objects 
        DSPCODEC = &H8000
        ' Realtime file format decoding DSP objects 
        PROFILE = &H10000
        ' Profiler memory footprint. 
        RECORDBUFFER = &H20000
        ' Buffer used to store recorded data from microphone 
        REVERB = &H40000
        ' Reverb implementation objects 
        REVERBCHANNELPROPS = &H80000
        ' Reverb channel properties structs 
        GEOMETRY = &H100000
        ' Geometry objects and internals 
        SYNCPOINT = &H200000
        ' Sync point memory. 
        ALL = &HFFFFFFFFUI
        ' All memory used by FMOD Ex 
    End Enum

    '
    '    [DEFINE]
    '    [
    '        [NAME]
    '        FMOD_EVENT_MEMBITS
    '
    '        [DESCRIPTION]   
    '        Bitfield used to request specific memory usage information from the getMemoryInfo function of every public FMOD Event System class.<br>
    '        Use with the "event_memorybits" parameter of getMemoryInfo to get information on FMOD Event System memory usage.
    '
    '        [REMARKS]
    '        Every public FMOD Event System class has a getMemoryInfo function which can be used to get detailed information on what memory resources are associated with the object in question. 
    '        The FMOD_EVENT_MEMBITS defines can be OR'd together to specify precisely what memory usage you'd like to get information on. See EventSystem::getMemoryInfo for an example.
    '
    '        [PLATFORMS]
    '        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii, Solaris
    '
    '        [SEE_ALSO]
    '        FMOD_MEMBITS
    '        System::getMemoryInfo
    '    ]
    '    

    Public Enum EVENT_MEMBITS As UInteger
        EVENTSYSTEM = &H1
        ' EventSystem and various internals 
        MUSICSYSTEM = &H2
        ' MusicSystem and various internals 
        FEV = &H4
        ' Definition of objects contained in all loaded projects e.g. events, groups, categories 
        MEMORYFSB = &H8
        ' Data loaded with registerMemoryFSB 
        EVENTPROJECT = &H10
        ' EventProject objects and internals 
        EVENTGROUPI = &H20
        ' EventGroup objects and internals 
        SOUNDBANKCLASS = &H40
        ' Objects used to manage wave banks 
        SOUNDBANKLIST = &H80
        ' Data used to manage lists of wave bank usage 
        STREAMINSTANCE = &H100
        ' Stream objects and internals 
        SOUNDDEFCLASS = &H200
        ' Sound definition objects 
        SOUNDDEFDEFCLASS = &H400
        ' Sound definition static data objects 
        SOUNDDEFPOOL = &H800
        ' Sound definition pool data 
        REVERBDEF = &H1000
        ' Reverb definition objects 
        EVENTREVERB = &H2000
        ' Reverb objects 
        USERPROPERTY = &H4000
        ' User property objects 
        EVENTINSTANCE = &H8000
        ' Event instance base objects 
        EVENTINSTANCE_COMPLEX = &H10000
        ' Complex event instance objects 
        EVENTINSTANCE_SIMPLE = &H20000
        ' Simple event instance objects 
        EVENTINSTANCE_LAYER = &H40000
        ' Event layer instance objects 
        EVENTINSTANCE_SOUND = &H80000
        ' Event sound instance objects 
        EVENTENVELOPE = &H100000
        ' Event envelope objects 
        EVENTENVELOPEDEF = &H200000
        ' Event envelope definition objects 
        EVENTPARAMETER = &H400000
        ' Event parameter objects 
        EVENTCATEGORY = &H800000
        ' Event category objects 
        EVENTENVELOPEPOINT = &H1000000
        ' Event envelope point objects 
        EVENTINSTANCEPOOL = &H2000000
        ' Event instance pool data 
        ALL = &HFFFFFFFFUI
        ' All memory used by FMOD Event System 

        ' All event instance memory 

        EVENTINSTANCE_GROUP = (EVENTINSTANCE Or EVENTINSTANCE_COMPLEX Or EVENTINSTANCE_SIMPLE Or EVENTINSTANCE_LAYER Or EVENTINSTANCE_SOUND)

        ' All sound definition memory 

        SOUNDDEF_GROUP = (SOUNDDEFCLASS Or SOUNDDEFDEFCLASS Or SOUNDDEFPOOL)
    End Enum
End Namespace
