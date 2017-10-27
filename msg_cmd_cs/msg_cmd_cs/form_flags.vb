Public Module form_flags
    'form shared
    Public command_stack As New Stack(Of String)
    Public log As String = ""
    Public loged As Boolean = False
    Public logpath As String = ""
    'form flags
    Public tocleartxt As Boolean = False
    Public movetobottom As Boolean = False
    Public movetotop As Boolean = False
    Public quit As Boolean = False
    Public restart As Boolean = False
    Public showabout As Boolean = False
    Public tochangeenter As Boolean = False
    Public changeenterto As Boolean = False
    Public toappendtext As Boolean = False
    Public appendtext As String = ""
    Public rundelegate As Boolean = False
    Public deltorun As [Delegate] = Nothing
    Public restart_have_args As Boolean = True
    Public restart_custom As Boolean = False
    Public restart_custom_args As String()
End Module
