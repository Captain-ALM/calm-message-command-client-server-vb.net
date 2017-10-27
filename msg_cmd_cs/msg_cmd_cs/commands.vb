Imports System.IO

Module commands_data
    Public commandhelplst As New List(Of String)

    Public Function help(args As Object) As Object
        If IsNothing(args) Then
            Dim helpstr As String = "Help:" & ControlChars.CrLf
            For i As Integer = 0 To commandhelplst.Count - 1 Step 1
                helpstr = helpstr & commandhelplst(i)
                If i <> commandhelplst.Count - 1 Then
                    helpstr = helpstr & ControlChars.CrLf
                End If
            Next
            Return helpstr
        Else
            Try
                Dim commandhelplst_local As List(Of String) = commandhelplst.FindAll(Function(x) x.Contains(args(0)))
                Dim helpstr As String = "Help:" & ControlChars.CrLf & "Help Returned For '" & args(0) & "'" & ControlChars.CrLf
                For i As Integer = 0 To commandhelplst_local.Count - 1 Step 1
                    helpstr = helpstr & commandhelplst_local(i)
                    If i <> commandhelplst_local.Count - 1 Then
                        helpstr = helpstr & ControlChars.CrLf
                    End If
                Next
                Return helpstr
            Catch ex As Exception
                Return "Command Error: " & ex.GetType.ToString & " : " & ex.Message
            End Try
        End If
    End Function

    Public Function invalid(args As Object) As Object
        Return "Invalid Command"
    End Function

    Public Function str(args As Object) As Object
        If Not IsNothing(args) Then
            Return args(0)
        Else
            Return ""
        End If
    End Function

    Public Function int(args As Object) As Object
        If Not IsNothing(args) Then
            Try
                Return Integer.Parse(args(0))
            Catch ex As Exception
                Return 0
            End Try
        Else
            Return 0
        End If
    End Function

    Public Function dec(args As Object) As Object
        If Not IsNothing(args) Then
            Try
                Return Decimal.Parse(args(0))
            Catch ex As Exception
                Return 0
            End Try
        Else
            Return 0
        End If
    End Function

    Public Function cls(args As Object) As Object
        tocleartxt = True
        Return ""
    End Function

    Public Function charconv(args As Object) As Object
        If Not IsNothing(args) Then
            Try
                Return ChrW(Integer.Parse(args(0)))
            Catch ex As Exception
                Return ""
            End Try
        Else
            Return ""
        End If
    End Function

    Public Function move_gui(args As Object) As Object
        If Not IsNothing(args) Then
            If args(0).ToString.ToLower = "top" Or args(0) = "0" Or args(0).ToString.ToLower = "up" Then
                movetotop = True
            ElseIf args(0).ToString.ToLower = "bottom" Or args(0) = "1" Or args(0).ToString.ToLower = "down" Then
                movetobottom = True
            End If
        End If
        Return ""
    End Function

    Public Function quitp(args As Object) As Object
        quit = True
        Return ""
    End Function

    Public Function restartp(args As Object) As Object
        If Not IsNothing(args) Then
            Dim numofargs As Integer = numberofindexes(args)
            If numofargs = 1 Then
                If args(0).ToString.ToLower = "true" Then
                    restart_have_args = True
                    restart_custom = False
                ElseIf args(0).ToString.ToLower = "false" Then
                    restart_have_args = False
                    restart_custom = False
                Else
                    ReDim Preserve restart_custom_args(0)
                    restart_custom_args(0) = args(0).ToString.Replace(ControlChars.Quote, "'")
                    restart_custom = True
                End If
            ElseIf numofargs >= 2 Then
                ReDim Preserve restart_custom_args(numofargs - 1)
                For i As Integer = 0 To numofargs - 1 Step 1
                    restart_custom_args(i) = args(i).ToString.Replace(ControlChars.Quote, "'")
                Next
                restart_custom = True
            End If
        End If
        restart = True
        Return ""
    End Function

    Public Function aboutsh(args As Object) As Object
        showabout = True
        Return ""
    End Function

    Public Function chenter(args As Object) As Object
        tochangeenter = True
        Dim lastch = changeenterto
        Try
            If args(0).ToString.ToLower = "true" Or args(0) = "1" Then
                changeenterto = True
            Else
                changeenterto = False
            End If
        Catch ex As Exception
            changeenterto = lastch
        End Try
        Return ""
    End Function

    Public Function changelang(args As Object) As Object
        If Not IsNothing(args) Then
            Dim lastcmd As commandtype_mode = commandmode
            Dim numofargs As Integer = numberofindexes(args)
            Try
                If numofargs = 1 Then
                    If args(0).ToString.ToLower = "calm" Or args(0) = "0" Then
                        commandmode = commandtype_mode.calm_type
                    ElseIf args(0).ToString.ToLower = "spaced" Or args(0) = "1" Then
                        commandmode = commandtype_mode.spaced_type
                    ElseIf args(0).ToString.ToLower = "commad" Or args(0) = "3" Then
                        commandmode = commandtype_mode.commad_type
                    ElseIf args(0).ToString.ToLower = "objective()" Or args(0) = "2" Then
                        commandmode = commandtype_mode.objective_type
                    ElseIf args(0).ToString.ToLower = "objective{}" Or args(0) = "4" Then
                        commandmode = commandtype_mode.cbrak_objective_type
                    End If
                ElseIf numofargs >= 2 Then
                    If args(0).ToString.ToLower = "calm" Or args(0) = "0" Or (args(0).ToString.ToLower = "default" And (args(1) = "calm" Or args(1) = "0" Or args(1) = "1")) Then
                        commandmode = commandtype_mode.calm_type
                    ElseIf args(0).ToString.ToLower = "spaced" Or args(0) = "1" Or (args(0).ToString.ToLower = "delimited" And (args(1) = "spaced" Or args(1) = "1")) Then
                        commandmode = commandtype_mode.spaced_type
                    ElseIf args(0).ToString.ToLower = "commad" Or args(0) = "3" Or (args(0).ToString.ToLower = "delimited" And (args(1) = "commad" Or args(1) = "3" Or args(1) = "2")) Then
                        commandmode = commandtype_mode.commad_type
                    ElseIf args(0).ToString.ToLower = "objective()" Or args(0) = "2" Or (args(0).ToString.ToLower = "objective" And (args(1) = "()" Or args(1) = "2" Or args(1) = "1")) Then
                        commandmode = commandtype_mode.objective_type
                    ElseIf args(0).ToString.ToLower = "objective{}" Or args(0) = "4" Or (args(0).ToString.ToLower = "objective" And (args(1) = "{}" Or args(1) = "4" Or args(1) = "2")) Then
                        commandmode = commandtype_mode.cbrak_objective_type
                    End If
                End If
            Catch ex As Exception
                commandmode = lastcmd
            End Try
        End If
        Return ""
    End Function

    Public Function runfile(args As Object) As Object
        If Not IsNothing(args) Then
            Dim numofargs As Integer = numberofindexes(args)
            If numofargs >= 1 Then
                Try
                    If File.Exists(args(0)) Then
                        Dim data As String() = loadfilelines(args(0))
                        Dim l_stack As New Stack(Of String)
                        For Each comcmd As String In data
                            If comcmd <> "" Then
                                l_stack.Push(comcmd)
                            End If
                        Next
                        For i As Integer = 1 To l_stack.Count Step 1
                            Dim comcmd As String = l_stack.Pop()
                            command_stack.Push(comcmd)
                        Next
                    Else
                        Return "File Does Not Exist: " & args(0) & "."
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
        Return ""
    End Function

    Public Function logger(args As Object) As Object
        If Not IsNothing(args) Then
            Dim numofargs As Integer = numberofindexes(args)
            If numofargs >= 1 Then
                Try
                    If args(0).ToString.ToLower = "true" Or args(0) = "1" Or args(0).ToString.ToLower = "on" Or args(0).ToString.ToLower = "enabled" Then
                        loged = True
                    ElseIf args(0).ToString.ToLower = "false" Or args(0) = "0" Or args(0).ToString.ToLower = "off" Or args(0).ToString.ToLower = "disabled" Then
                        loged = False
                    ElseIf args(0).ToString.ToLower = "clear" Then
                        log = ""
                    ElseIf args(0).ToString.ToLower = "dump" Then
                        If log <> "" Then
                            savefile(logpath & "\msg_cmd_cs-" & DateTime.Now.Hour & "-" & DateTime.Now.Minute & "-" & DateTime.Now.Second & "-" & DateTime.Now.Day & "-" & DateTime.Now.Month & "-" & DateTime.Now.Year & "-" & ".txt", log)
                            log = ""
                        End If
                    ElseIf args(0).ToString.ToLower = "default" Then
                        System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly.FullName)
                    Else
                        If savefile(args(0) & "\test.txt", "test") Then
                            logpath = args(0)
                        End If
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
        Return ""
    End Function

    Public Function startserver(args As Object) As Object
        Try
        If Not IsNothing(args) Then
            Dim argcont As Integer = numberofindexes(args)
            Dim strargs As String() = convertobjectargstostringargs(args)
            If argcont = 0 Then
                Return start_server()
            ElseIf argcont = 1 Then
                Return start_server(strargs(0))
            ElseIf argcont = 2 Then
                Return start_server(strargs(0), UInteger.Parse(strargs(1)))
            ElseIf argcont >= 4 Then
                    Return start_server(strargs(0), UInteger.Parse(strargs(1)), strargs(2), Integer.Parse(strargs(3)))
            End If
            End If
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Function stopserver(args As Object) As Object
        Try
            Return stop_server()
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Function startclient(args As Object) As Object
        Try
        If Not IsNothing(args) Then
            Dim argcont As Integer = numberofindexes(args)
            Dim strargs As String() = convertobjectargstostringargs(args)
            If argcont = 1 Then
                Return start_client(strargs(0))
            ElseIf argcont = 2 Then
                Return start_client(strargs(0), UInteger.Parse(strargs(1)))
                ElseIf argcont >= 4 Then
                    Return start_client(strargs(0), UInteger.Parse(strargs(1)), strargs(2), Integer.Parse(strargs(3)))
            End If
            End If
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Function disclient(args As Object) As Object
        Try
            If Not IsNothing(args) Then
                Dim argcont As Integer = numberofindexes(args)
                Dim strargs As String() = convertobjectargstostringargs(args)
                If argcont >= 1 Then
                    Return disconnect_client(strargs(0))
                End If
            End If
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Function chkserv(args As Object) As Object
        Try
            If Not IsNothing(args) Then
                Dim argcont As Integer = numberofindexes(args)
                Dim strargs As String() = convertobjectargstostringargs(args)
                If argcont >= 1 Then
                    Return server_up(strargs(0))
                ElseIf argcont >= 2 Then
                    Return server_up(strargs(0), UInteger.Parse(strargs(1)))
                End If
            End If
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Function stopclient(args As Object) As Object
        Try
            Return stop_client()
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Function send_msg(args As Object) As Object
        Try
            If Not IsNothing(args) Then
                Dim argcont As Integer = numberofindexes(args)
                Dim strargs As String() = convertobjectargstostringargs(args)
                If argcont = 1 Then
                    If current_mode = current_cs_mode.client Then
                        Return send_message_to_server(strargs(0))
                    Else
                        Return "Cannot Send Message - Is The Client/Server Running?"
                    End If
                ElseIf argcont = 2 Then
                    If current_mode = current_cs_mode.client Then
                        Return send_message_to_server(strargs(1), strargs(0))
                    ElseIf current_mode = current_cs_mode.server Then
                        Return send_message_to_client(strargs(0), strargs(1))
                    Else
                        Return "Cannot Send Message - Is The Client/Server Running?"
                    End If
                ElseIf argcont >= 3 Then
                    If current_mode = current_cs_mode.client Then
                        Return send_message_to_server(strargs(1), strargs(0)) ' for compactability
                    ElseIf current_mode = current_cs_mode.server Then
                        Return send_message_to_client(strargs(0), strargs(2), strargs(1))
                    Else
                        Return "Cannot Send Message - Is The Client/Server Running?"
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Function bc_msg(args As Object) As Object
        Try
            If Not IsNothing(args) Then
                Dim argcont As Integer = numberofindexes(args)
                Dim strargs As String() = convertobjectargstostringargs(args)
                If argcont = 1 Then
                    If current_mode = current_cs_mode.server Then
                        Return broadcast_mesage_to_all_clients(strargs(0))
                    Else
                        Return "Cannot Broadcast Message - Is The Server Running?"
                    End If
                ElseIf argcont = 2 Then
                    If current_mode = current_cs_mode.server Then
                        Return broadcast_mesage_to_all_clients(strargs(1), strargs(0))
                    Else
                        Return "Cannot Broadcast Message - Is The Server Running?"
                    End If
                ElseIf argcont >= 3 Then
                    If current_mode = current_cs_mode.server Then
                        Return broadcast_mesage_to_all_clients(strargs(1), strargs(0)) 'for compactability
                    Else
                        Return "Cannot Broadcast Message - Is The Server Running?"
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Function gcl(args As Object) As Object
        Try
            Dim ret As String = "Connected Clients : "
            For Each current As String In get_clients()
                ret = ret & current & " "
            Next
            Return ret
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Function plog(args As Object) As Object
        Try
            Return pull_log()
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Function updatclid(args As Object) As Object
        Try
            Return updatcldat()
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Function clog(args As Object) As Object
        Try
            clear_log()
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Function cmode(args As Object) As Object
        Try
            If current_mode = current_cs_mode.client Then
                Return "Client Mode"
            ElseIf current_mode = current_cs_mode.server Then
                Return "Server Mode"
            ElseIf current_mode = current_cs_mode.relay Then 'future reference #{future}
                Return "Relay Mode"
            Else
                Return "No Mode"
            End If
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Function convertobjectargstostringargs(args As Object) As String()
        Dim toret(0) As String
        If IsNothing(args) Then
            Return Nothing
        End If
        Try
            Dim numofi As Integer = numberofindexes(args)
            ReDim toret(numofi - 1)
            For i As Integer = 0 To numofi - 1 Step 1
                toret(i) = args(i).ToString
            Next
        Catch ex As Exception
            Return Nothing
        End Try
        Return toret
    End Function

    Public Function numberofindexes(args As Object) As Integer
        If IsNothing(args) Then
            Return 0
        End If
        Try
            Dim i As Integer = 0
            Try
                While "True"
                    Dim tmp As Object = args(i)
                    tmp = Nothing
                    i = i + 1
                End While
                Return 0
            Catch ex As Exception
                Return i
            End Try
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Module
