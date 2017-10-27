Imports System.Threading

Public Module cmdpr
    Public commands As New Dictionary(Of String, executable_command)
    Public commandmode As commandtype_mode = commandtype_mode.calm_type

    Public Function run_cmd(cmd As String) As String
        Try
            Dim com As command = New command(cmd, commandmode, False)
            com.init()
            Dim toret As String = CType(com.execute(), String)
            Return toret
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Sub init_cmd()
        'help
        commands.Add("help", New executable_command("help", Function(obj As Object) As Object
                                                                Return help(obj)
                                                            End Function))
        commandhelplst.Add("help : provides help for commands.")
        'invalid
        commands.Add("invalid", New executable_command("invalid", Function(obj As Object) As Object
                                                                      Return invalid(obj)
                                                                  End Function))
        commandhelplst.Add("invalid : provides an invalid command error message.")
        'str / string
        commands.Add("str", New executable_command("str", Function(obj As Object) As Object
                                                              Return str(obj)
                                                          End Function))
        commands.Add("string", New executable_command("string", Function(obj As Object) As Object
                                                                    Return str(obj)
                                                                End Function))
        commandhelplst.Add("str/string%string% : provides a converter to string for functions.")
        'int / integer
        commands.Add("int", New executable_command("int", Function(obj As Object) As Object
                                                              Return int(obj)
                                                          End Function))
        commands.Add("integer", New executable_command("integer", Function(obj As Object) As Object
                                                                      Return int(obj)
                                                                  End Function))
        commandhelplst.Add("int/integer%string% : provides a converter to integer for functions.")
        'dec / decimal
        commands.Add("dec", New executable_command("dec", Function(obj As Object) As Object
                                                              Return dec(obj)
                                                          End Function))
        commands.Add("decimal", New executable_command("decimal", Function(obj As Object) As Object
                                                                      Return dec(obj)
                                                                  End Function))
        commandhelplst.Add("dec/decimal%string% : provides a converter to decimal for functions.")
        'cls / clear
        commands.Add("cls", New executable_command("cls", Function(obj As Object) As Object
                                                              Return cls(obj)
                                                          End Function))
        commands.Add("clear", New executable_command("clear", Function(obj As Object) As Object
                                                                  Return cls(obj)
                                                              End Function))
        commandhelplst.Add("cls/clear : clears the operation log.")
        'move_gui
        commands.Add("move_gui", New executable_command("move_gui", Function(obj As Object) As Object
                                                                        Return move_gui(obj)
                                                                    End Function))
        commandhelplst.Add("move_gui%top/bottom/up/down% : allows the command area portion of the gui to move.")
        'exit / quit / end / close / terminate
        commands.Add("exit", New executable_command("exit", Function(obj As Object) As Object
                                                                Return quitp(obj)
                                                            End Function))
        commands.Add("quit", New executable_command("quit", Function(obj As Object) As Object
                                                                Return quitp(obj)
                                                            End Function))
        commands.Add("end", New executable_command("end", Function(obj As Object) As Object
                                                              Return quitp(obj)
                                                          End Function))
        commands.Add("close", New executable_command("close", Function(obj As Object) As Object
                                                                  Return quitp(obj)
                                                              End Function))
        commands.Add("terminate", New executable_command("terminate", Function(obj As Object) As Object
                                                                          Return quitp(obj)
                                                                      End Function))
        commandhelplst.Add("exit/quit/end/close/terminate : closes and then ends the program.")
        'reset / restart
        commands.Add("reset", New executable_command("reset", Function(obj As Object) As Object
                                                                  Return restartp(obj)
                                                              End Function))
        commands.Add("restart", New executable_command("restart", Function(obj As Object) As Object
                                                                      Return restartp(obj)
                                                                  End Function))
        commandhelplst.Add("reset/restart%false[no arguments]/true[use current program arguments]/*(args)...[this + later arguments are each command line argument to be passed to the restarted program]% : restarts the program.")
        'about
        commands.Add("about", New executable_command("about", Function(obj As Object) As Object
                                                                  Return aboutsh(obj)
                                                              End Function))
        commandhelplst.Add("about : shows the about box.")
        'allow_enter
        commands.Add("allow_enter", New executable_command("allow_enter", Function(obj As Object) As Object
                                                                              Return chenter(obj)
                                                                          End Function))
        commandhelplst.Add("allow_enter%true/false% : allow enter in the command box : if true multiline commands will run, false an enter will execute the current command.")
        'lang / language
        commands.Add("lang", New executable_command("lang", Function(obj As Object) As Object
                                                                Return changelang(obj)
                                                            End Function))
        commands.Add("language", New executable_command("language", Function(obj As Object) As Object
                                                                        Return changelang(obj)
                                                                    End Function))
        commandhelplst.Add("lang/language%calm/spaced/commad/objective()/objective{}/(next bits require second argument)/default/delimeted/objective%%calm/spaced/commad/()/{}% : switches the program's command language.")
        'char_conv / character_convert
        commands.Add("char_conv", New executable_command("char_conv", Function(obj As Object) As Object
                                                                          Return charconv(obj)
                                                                      End Function))
        commands.Add("character_convert", New executable_command("character_convert", Function(obj As Object) As Object
                                                                                          Return charconv(obj)
                                                                                      End Function))
        commandhelplst.Add("char_conv/character_convert%string(as a number)% : converts an integer to a character.")
        'run / execute
        commands.Add("run", New executable_command("run", Function(obj As Object) As Object
                                                              Return runfile(obj)
                                                          End Function))
        commands.Add("execute", New executable_command("execute", Function(obj As Object) As Object
                                                                      Return runfile(obj)
                                                                  End Function))
        commandhelplst.Add("run/execute%string(file path)% : executes a script from a file.")
        'log / logger
        commands.Add("log", New executable_command("log", Function(obj As Object) As Object
                                                              Return logger(obj)
                                                          End Function))
        commands.Add("logger", New executable_command("logger", Function(obj As Object) As Object
                                                                    Return logger(obj)
                                                                End Function))
        commandhelplst.Add("log/logger%true/on/enabled/false/off/disabled/default(default folder for log)/dump/clear/*(folder for log)% : performs command for the log.")
        'start_server
        commands.Add("start_server", New executable_command("start_server", Function(obj As Object) As Object
                                                                                Return startserver(obj)
                                                                            End Function))
        commandhelplst.Add("start_server%IP%%Port%%Password(Optional if Encrypt Method is none or unicode)%%Encrypt Method% : starts the server.")
        'start_client
        commands.Add("start_client", New executable_command("start_client", Function(obj As Object) As Object
                                                                                Return startclient(obj)
                                                                            End Function))
        commandhelplst.Add("start_client%IP%%Port%%Password(Optional if Encrypt Method is none or unicode)%%Encrypt Method% : starts the client.")
        'mode / current_mode
        commands.Add("mode", New executable_command("mode", Function(obj As Object) As Object
                                                                Return cmode(obj)
                                                            End Function))
        commands.Add("current_mode", New executable_command("current_mode", Function(obj As Object) As Object
                                                                                Return cmode(obj)
                                                                            End Function))
        commandhelplst.Add("mode/current_mode : gets the program's current mode.")
        'stop_server
        commands.Add("stop_server", New executable_command("stop_server", Function(obj As Object) As Object
                                                                              Return stopserver(obj)
                                                                          End Function))
        commandhelplst.Add("stop_server : stops the server and disconnects all clients.")
        'stop_client
        commands.Add("stop_client", New executable_command("stop_server", Function(obj As Object) As Object
                                                                              Return stopclient(obj)
                                                                          End Function))
        commandhelplst.Add("stop_client : stops the client and disconnects from the server.")
        'check_server / server_up_check
        commands.Add("check_server", New executable_command("check_server", Function(obj As Object) As Object
                                                                                Return chkserv(obj)
                                                                            End Function))
        commands.Add("server_up_check", New executable_command("server_up_check", Function(obj As Object) As Object
                                                                                      Return chkserv(obj)
                                                                                  End Function))
        commandhelplst.Add("check_server/server_up_check%IP%%Port(Optional [Default : 100])% : checks an adress to see if a server is listening on it.")
        'remove_client / disconnect_client
        commands.Add("remove_client", New executable_command("remove_client", Function(obj As Object) As Object
                                                                                  Return disclient(obj)
                                                                              End Function))
        commands.Add("disconnect_client", New executable_command("disconnect_client", Function(obj As Object) As Object
                                                                                          Return disclient(obj)
                                                                                      End Function))
        commandhelplst.Add("remove_client/disconnect_client%clientname% : disconnects the given client from the server.")
        'update_client_list
        commands.Add("update_client_list", New executable_command("update_client_list", Function(obj As Object) As Object
                                                                                            Return updatclid(obj)
                                                                                        End Function))
        commandhelplst.Add("update_client_list : updates the list of clients in client mode.")
        'get_log / pull_log
        commands.Add("get_log", New executable_command("get_log", Function(obj As Object) As Object
                                                                      Return plog(obj)
                                                                  End Function))
        commands.Add("pull_log", New executable_command("pull_log", Function(obj As Object) As Object
                                                                        Return plog(obj)
                                                                    End Function))
        commandhelplst.Add("get_log/pull_log : gets the current client/server log data.")
        'get_clients / clients / client_list / list_of_clients
        commands.Add("get_clients", New executable_command("get_clients", Function(obj As Object) As Object
                                                                              Return gcl(obj)
                                                                          End Function))
        commands.Add("clients", New executable_command("clients", Function(obj As Object) As Object
                                                                      Return gcl(obj)
                                                                  End Function))
        commands.Add("client_list", New executable_command("client_list", Function(obj As Object) As Object
                                                                              Return gcl(obj)
                                                                          End Function))
        commands.Add("list_of_clients", New executable_command("list_of_clients", Function(obj As Object) As Object
                                                                                      Return gcl(obj)
                                                                                  End Function))
        commandhelplst.Add("get_clients/clients/client_list/list_of_clients : gets the currently connected clients on the server.")
        'clear_log
        commands.Add("clear_log", New executable_command("clear_log", Function(obj As Object) As Object
                                                                          Return clog(obj)
                                                                      End Function))
        commandhelplst.Add("clear_log : clears the current client/server log data.")
        'send_msg / send_message
        commands.Add("send_msg", New executable_command("send_msg", Function(obj As Object) As Object
                                                                        Return send_msg(obj)
                                                                    End Function))
        commands.Add("send_message", New executable_command("send_message", Function(obj As Object) As Object
                                                                                Return send_msg(obj)
                                                                            End Function))
        commandhelplst.Add("send_msg/send_message%client(If mode is server)/message(If mode is client)%%message(If mode is server)/header(If mode is client [Optional])%%header(If mode is server [Optional])% : sends a message to a selected client (If mode is server) or sends a message to the server (If mode is client).")
        'broadcast_msg / broadcast_message
        commands.Add("broadcast_msg", New executable_command("broadcast_msg", Function(obj As Object) As Object
                                                                                  Return bc_msg(obj)
                                                                              End Function))
        commands.Add("broadcast_message", New executable_command("broadcast_message", Function(obj As Object) As Object
                                                                                          Return bc_msg(obj)
                                                                                      End Function))
        commandhelplst.Add("broadcast_msg/broadcast_message%message%%header [Optional]% : sends a message to all clients connected to the server (Server Only).")
    End Sub
End Module

Public Class command
    Private name As String = ""
    Private cmdstr As String = ""
    Private arguments As New List(Of command)
    Private cmdtype As commandtype_mode = commandtype_mode.calm_type
    Private log As String = ""
    Private ecmd As executable_command
    Private args As Object() = Nothing

    Public Sub New(cmdstrp As String, cmdtypearg As commandtype_mode, Optional initnow As Boolean = False)
        cmdstr = cmdstrp
        cmdtype = cmdtypearg
        If initnow Then
            init()
        End If
    End Sub

    Public Sub init()
        Try
            If name = "" And cmdstr <> "" Then
                Dim argumentsstr As List(Of String) = decryptcommands(cmdstr, cmdtype)
                name = argumentsstr(0)
                If argumentsstr.Count > 1 Then
                    If IsNothing(args) Then
                        args = New Object() {}
                    End If
                    ReDim Preserve args(argumentsstr.Count - 2)
                    For i As Integer = 1 To argumentsstr.Count - 1 Step 1
                        'ReDim Preserve args(i - 1)
                        If ((argumentsstr(i).StartsWith(ControlChars.Quote) And argumentsstr(i).EndsWith(ControlChars.Quote)) Or (argumentsstr(i).StartsWith("'") And argumentsstr(i).EndsWith("'"))) Then
                            args(i - 1) = argumentsstr(i).Substring(1, argumentsstr(i).Length - 2)
                        Else
                            arguments.Add(New command(argumentsstr(i), cmdtype, True))
                            args(i - 1) = arguments(arguments.Count - 1).execute()
                        End If
                    Next
                Else
                    args = Nothing
                End If
                If commands.ContainsKey(name) Then
                    ecmd = commands(name)
                Else
                    ecmd = commands("invalid")
                End If
            End If
        Catch ex As Exception
            args = Nothing
            ecmd = commands("invalid")
        End Try
    End Sub

    Public Function execute() As Object
        Dim toret As Object = ecmd.execute_and_return(args)
        ecmd.flush()
        Return toret
    End Function

    Private Function checkifconvert(toconv As String, format As commandtype_mode, is_converted As Boolean) As String
        Dim isfunc As Boolean = False
        Dim isinteger As Boolean = False
        Dim isdecimal As Boolean = False
        Dim isstring As Boolean = False

        Dim returned As New Object

        If ((toconv.StartsWith(ControlChars.Quote) And toconv.EndsWith(ControlChars.Quote)) Or (toconv.StartsWith("'") And toconv.EndsWith("'"))) Then
            isfunc = False
            If is_converted Then
                isstring = False
                Return toconv
            Else
                isstring = True
                toconv = toconv.Substring(1, toconv.Length - 2)
            End If
        End If

        isfunc = commands.ContainsKey(toconv)

        If Not isfunc Then
            Try
                isinteger = Integer.TryParse(toconv, returned)
            Catch ex As Exception
                isinteger = False
            End Try
            If Not isinteger Then
                Try
                    isdecimal = Decimal.TryParse(toconv, returned)
                Catch ex As Exception
                    isdecimal = False
                End Try
                If Not isdecimal Then
                    isstring = True
                Else
                    isstring = False
                End If
            Else
                isdecimal = False
            End If
        Else
            isinteger = False
        End If

        If isinteger Then
            If format = commandtype_mode.calm_type Then
                Return "int['" & toconv & "']"
            ElseIf format = commandtype_mode.spaced_type Then
                Return "int '" & toconv & "'"
            ElseIf format = commandtype_mode.objective_type Then
                Return "int('" & toconv & "')"
            ElseIf format = commandtype_mode.commad_type Then
                Return "int,'" & toconv & "'"
            ElseIf format = commandtype_mode.cbrak_objective_type Then
                Return "int{'" & toconv & "'}"
            End If
        ElseIf isdecimal Then
            If format = commandtype_mode.calm_type Then
                Return "dec['" & toconv & "']"
            ElseIf format = commandtype_mode.spaced_type Then
                Return "dec '" & toconv & "'"
            ElseIf format = commandtype_mode.objective_type Then
                Return "dec('" & toconv & "')"
            ElseIf format = commandtype_mode.commad_type Then
                Return "dec,'" & toconv & "'"
            ElseIf format = commandtype_mode.cbrak_objective_type Then
                Return "dec{'" & toconv & "'}"
            End If
        ElseIf isstring Then
            If format = commandtype_mode.calm_type Then
                Return "str['" & toconv.Replace("[", "/[").Replace("]", "/]") & "']"
            ElseIf format = commandtype_mode.spaced_type Then
                Return "str '" & toconv.Replace(" ", "/ ") & "'"
            ElseIf format = commandtype_mode.objective_type Then
                Return "str('" & toconv.Replace("(", "/(").Replace(")", "/)").Replace(",", "/,") & "')"
            ElseIf format = commandtype_mode.commad_type Then
                Return "str,'" & toconv.Replace(",", "/,") & "'"
            ElseIf format = commandtype_mode.cbrak_objective_type Then
                Return "str{'" & toconv.Replace("{", "/{").Replace("}", "/}").Replace(",", "/,") & "'}"
            End If
        ElseIf isfunc Then
            Return toconv
        End If
        Return toconv
    End Function

    Private Function decryptcommands(cmdstr As String, cmdtyp As commandtype_mode) As List(Of String)
        Dim commandlst As New List(Of String)
        Dim carg As String = ""
        Dim incommand As Boolean = False
        Dim inarg As Boolean = False
        Dim isescape As Boolean = False
        Dim escapestr As String = ""
        Dim custr As String = ""

        If cmdtyp = commandtype_mode.calm_type Then
            incommand = True
            inarg = False
            isescape = False
            For i As Integer = 0 To cmdstr.Length - 1 Step 1
                custr = cmdstr.Substring(i, 1)
                If Not isescape Then
                    If incommand Then
                        If custr = "[" Then
                            commandlst.Add(checkifconvert(carg, cmdtyp, False))
                            inarg = True
                            incommand = False
                            carg = ""
                        ElseIf custr = "/" Then
                            isescape = True
                        Else
                            carg = carg & custr
                        End If
                    ElseIf inarg Then
                        If custr = "]" Then
                            If carg <> "" Then
                                If commandlst(0) = "str" Or commandlst(0) = "string" Or commandlst(0) = "int" Or commandlst(0) = "integer" Or commandlst(0) = "dec" Or commandlst(0) = "decimal" Then
                                    commandlst.Add(checkifconvert(carg, cmdtyp, True))
                                Else
                                    commandlst.Add(checkifconvert(carg, cmdtyp, False))
                                End If
                            End If
                            inarg = False
                            carg = ""
                        ElseIf custr = "/" Then
                            isescape = True
                        Else
                            carg = carg & custr
                        End If
                        Else
                            If custr = "[" Then
                                inarg = True
                            End If
                        End If
                Else
                    carg = carg & custr
                    isescape = False
                End If
            Next
            If incommand Then
                commandlst.Add(checkifconvert(carg, cmdtyp, False))
                incommand = False
                carg = ""
            End If
        ElseIf cmdtyp = commandtype_mode.spaced_type Then
            isescape = False
            For i As Integer = 0 To cmdstr.Length - 1 Step 1
                custr = cmdstr.Substring(i, 1)
                If Not isescape Then
                    If custr = " " Then
                        If commandlst.Count = 0 Then
                            commandlst.Add(checkifconvert(carg, cmdtyp, False))
                        Else
                            If commandlst(0) = "str" Or commandlst(0) = "string" Or commandlst(0) = "int" Or commandlst(0) = "integer" Or commandlst(0) = "dec" Or commandlst(0) = "decimal" Then
                                commandlst.Add(checkifconvert(carg, cmdtyp, True))
                            Else
                                commandlst.Add(checkifconvert(carg, cmdtyp, False))
                            End If
                        End If
                        carg = ""
                    ElseIf custr = "/" Then
                        isescape = True
                    Else
                        carg = carg & custr
                    End If
                Else
                    carg = carg & custr
                    isescape = False
                End If
            Next
            If carg <> "" Then
                If commandlst.Count = 0 Then
                    commandlst.Add(checkifconvert(carg, cmdtyp, False))
                Else
                    If commandlst(0) = "str" Or commandlst(0) = "string" Or commandlst(0) = "int" Or commandlst(0) = "integer" Or commandlst(0) = "dec" Or commandlst(0) = "decimal" Then
                        commandlst.Add(checkifconvert(carg, cmdtyp, True))
                    Else
                        commandlst.Add(checkifconvert(carg, cmdtyp, False))
                    End If
                End If
            End If
        ElseIf cmdtyp = commandtype_mode.commad_type Then
            isescape = False
            For i As Integer = 0 To cmdstr.Length - 1 Step 1
                custr = cmdstr.Substring(i, 1)
                If Not isescape Then
                    If custr = "," Then
                        If commandlst.Count = 0 Then
                            commandlst.Add(checkifconvert(carg, cmdtyp, False))
                        Else
                            If commandlst(0) = "str" Or commandlst(0) = "string" Or commandlst(0) = "int" Or commandlst(0) = "integer" Or commandlst(0) = "dec" Or commandlst(0) = "decimal" Then
                                commandlst.Add(checkifconvert(carg, cmdtyp, True))
                            Else
                                commandlst.Add(checkifconvert(carg, cmdtyp, False))
                            End If
                        End If
                        carg = ""
                    ElseIf custr = "/" Then
                        isescape = True
                    Else
                        carg = carg & custr
                    End If
                Else
                    carg = carg & custr
                    isescape = False
                End If
            Next
            If carg <> "" Then
                If commandlst.Count = 0 Then
                    commandlst.Add(checkifconvert(carg, cmdtyp, False))
                Else
                    If commandlst(0) = "str" Or commandlst(0) = "string" Or commandlst(0) = "int" Or commandlst(0) = "integer" Or commandlst(0) = "dec" Or commandlst(0) = "decimal" Then
                        commandlst.Add(checkifconvert(carg, cmdtyp, True))
                    Else
                        commandlst.Add(checkifconvert(carg, cmdtyp, False))
                    End If
                End If
            End If
            ElseIf cmdtyp = commandtype_mode.objective_type Then
                incommand = True
                inarg = False
                isescape = False
                For i As Integer = 0 To cmdstr.Length - 1 Step 1
                    custr = cmdstr.Substring(i, 1)
                    If Not isescape Then
                        If incommand Then
                            If custr = "(" Then
                                commandlst.Add(checkifconvert(carg, cmdtyp, False))
                                inarg = True
                                incommand = False
                                carg = ""
                            ElseIf custr = "/" Then
                                isescape = True
                            Else
                                carg = carg & custr
                            End If
                        ElseIf inarg Then
                            If custr = ")" Then
                                If carg <> "" Then
                                    If commandlst(0) = "str" Or commandlst(0) = "string" Or commandlst(0) = "int" Or commandlst(0) = "integer" Or commandlst(0) = "dec" Or commandlst(0) = "decimal" Then
                                        commandlst.Add(checkifconvert(carg, cmdtyp, True))
                                    Else
                                        commandlst.Add(checkifconvert(carg, cmdtyp, False))
                                    End If
                                End If
                                inarg = False
                                carg = ""
                            ElseIf custr = "," Then
                                If commandlst(0) = "str" Or commandlst(0) = "string" Or commandlst(0) = "int" Or commandlst(0) = "integer" Or commandlst(0) = "dec" Or commandlst(0) = "decimal" Then
                                    commandlst.Add(checkifconvert(carg, cmdtyp, True))
                                Else
                                    commandlst.Add(checkifconvert(carg, cmdtyp, False))
                                End If
                                carg = ""
                            ElseIf custr = "/" Then
                                isescape = True
                            Else
                                carg = carg & custr
                            End If
                        End If
                    Else
                        carg = carg & custr
                        isescape = False
                    End If
                Next
        ElseIf cmdtyp = commandtype_mode.cbrak_objective_type Then
            incommand = True
            inarg = False
            isescape = False
            For i As Integer = 0 To cmdstr.Length - 1 Step 1
                custr = cmdstr.Substring(i, 1)
                If Not isescape Then
                    If incommand Then
                        If custr = "{" Then
                            commandlst.Add(checkifconvert(carg, cmdtyp, False))
                            inarg = True
                            incommand = False
                            carg = ""
                        ElseIf custr = "/" Then
                            isescape = True
                        Else
                            carg = carg & custr
                        End If
                    ElseIf inarg Then
                        If custr = "}" Then
                            If carg <> "" Then
                                If commandlst(0) = "str" Or commandlst(0) = "string" Or commandlst(0) = "int" Or commandlst(0) = "integer" Or commandlst(0) = "dec" Or commandlst(0) = "decimal" Then
                                    commandlst.Add(checkifconvert(carg, cmdtyp, True))
                                Else
                                    commandlst.Add(checkifconvert(carg, cmdtyp, False))
                                End If
                            End If
                            inarg = False
                            carg = ""
                        ElseIf custr = "," Then
                            If commandlst(0) = "str" Or commandlst(0) = "string" Or commandlst(0) = "int" Or commandlst(0) = "integer" Or commandlst(0) = "dec" Or commandlst(0) = "decimal" Then
                                commandlst.Add(checkifconvert(carg, cmdtyp, True))
                            Else
                                commandlst.Add(checkifconvert(carg, cmdtyp, False))
                            End If
                            carg = ""
                        ElseIf custr = "/" Then
                            isescape = True
                        Else
                            carg = carg & custr
                        End If
                    End If
                Else
                    carg = carg & custr
                    isescape = False
                End If
            Next
        End If
        Return commandlst
    End Function
End Class

Public Class executable_command
    Private _name As String = ""
    Private _intdel As [Delegate]
    Private _isthread As Boolean = False
    Private _thread As Thread
    Private _args As Object = Nothing
    Private _retur As Object = Nothing

    Sub New(name As String, passed_delegate As [Delegate], Optional isthreaded As Boolean = False)
        _name = name
        _intdel = passed_delegate
        _isthread = isthreaded
    End Sub

    Public ReadOnly Property name As String
        Get
            Return _name
        End Get
    End Property

    Public ReadOnly Property is_threaded As String
        Get
            Return _isthread
        End Get
    End Property

    Public Property arguments As Object
        Get
            Return _args
        End Get
        Set(value As Object)
            _args = value
        End Set
    End Property

    Public ReadOnly Property returned_values As Object
        Get
            Return _retur
        End Get
    End Property

    Public Sub execute(Optional args As Object = Nothing)
        If Not IsNothing(args) Then
            _args = args
        End If
        If _isthread Then
            If Not IsNothing(_thread) Then
                If _thread.IsAlive = False Then
                    _thread = New Thread(New ThreadStart(AddressOf execdel))
                    _thread.IsBackground = True
                    _thread.Start()
                End If
            End If
        Else
            execdel()
        End If
    End Sub

    Public Function execute_and_return(Optional args As Object = Nothing)
        If Not IsNothing(args) Then
            _args = args
        End If
        If _isthread Then
            If Not IsNothing(_thread) Then
                If _thread.IsAlive = False Then
                    _thread = New Thread(New ThreadStart(AddressOf execdel))
                    _thread.IsBackground = True
                    _thread.Start()
                End If
            End If
        Else
            execdel()
        End If
        Return _retur
    End Function

    Public Sub thead_abort()
        If _isthread And Not IsNothing(_thread) Then
            If _thread.IsAlive Then
                _thread.Abort()
            End If
        End If
    End Sub

    Public Sub flush_arguments()
        If Not IsNothing(_args) Then
            _args = Nothing
        End If
    End Sub

    Public Sub flush_return()
        If Not IsNothing(_retur) Then
            _retur = Nothing
        End If
    End Sub

    Public Sub flush()
        If Not IsNothing(_args) Then
            _args = Nothing
        End If
        If Not IsNothing(_retur) Then
            _retur = Nothing
        End If
    End Sub

    Private Sub execdel()
        Try
            _retur = _intdel.DynamicInvoke(_args)
        Catch ex As Exception
            _retur = ex.GetType.ToString & " : " & ex.Message
        End Try
    End Sub
End Class

Public Enum commandtype_mode As Integer
    calm_type = 0
    spaced_type = 1
    objective_type = 2
    commad_type = 3
    cbrak_objective_type = 4
End Enum