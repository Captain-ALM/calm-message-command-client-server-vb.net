Imports System.Reflection
Imports System.IO
Imports System.Threading

Public Class main
    Public cmdpos As cmd_gui_position = cmd_gui_position.top
    Public thisassembly As Assembly = Assembly.GetEntryAssembly
    Public assemblyname As String = Path.GetFileNameWithoutExtension(thisassembly.Location)
    Public assemblypath As String = thisassembly.Location
    Public assemblydir As String = Path.GetDirectoryName(thisassembly.Location)
    Public allowenter As Boolean = True
    Private aboutbx As New AboutBx
    Private license As String = ""
    Private description As String = ""
    Private checkchkbxthread As Thread
    Private flags_thread As Thread
    Private command_thread As Thread
    Private commands_init As Boolean = False
    Private prrun As Boolean = True

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        contrvis(False)

        cmdpos = gui_pos_edit(cmd_gui_position.top)

        contrvis(False)

        If File.Exists(assemblydir & "\license.txt") Then
            license = loadfile(assemblydir & "\license.txt")
        End If

        If File.Exists(assemblydir & "\description.txt") Then
            description = loadfile(assemblydir & "\description.txt")
        End If

        aboutbx.setupdata(description, license)

        logpath = assemblydir

        checkchkbxthread = New Thread(New ThreadStart(AddressOf chkchkbxtsub))
        flags_thread = New Thread(New ThreadStart(AddressOf flags_sub))
        command_thread = New Thread(New ThreadStart(AddressOf command_sub))
        checkchkbxthread.IsBackground = True
        flags_thread.IsBackground = True
        command_thread.IsBackground = True
        checkchkbxthread.Start()
        flags_thread.Start()

        init_cmd()
        commands_init = True

        contrvis(True)
    End Sub

    Private Sub butmcmdarr_Click(sender As Object, e As EventArgs) Handles butmcmdarr.Click
        If cmdpos = cmd_gui_position.top Then
            cmdpos = gui_pos_edit(cmd_gui_position.bottom)
        ElseIf cmdpos = cmd_gui_position.bottom Then
            cmdpos = gui_pos_edit(cmd_gui_position.top)
        End If
    End Sub

    Public Function gui_pos_edit(newpos As cmd_gui_position) As cmd_gui_position
        contrvis(False)
        If newpos = cmd_gui_position.bottom Then
            butmcmdarr.Invoke(Sub() butmcmdarr.Text = "Move Command Area To The Top")
            TableLayoutPanel1.Invoke(Sub() TableLayoutPanel1.RowStyles(0).Height = 75)
            TableLayoutPanel1.Invoke(Sub() TableLayoutPanel1.RowStyles(1).Height = 25)
            TableLayoutPanel1.Invoke(Sub() TableLayoutPanel1.SetRow(TableLayoutPanel2, 1))
            TableLayoutPanel1.Invoke(Sub() TableLayoutPanel1.SetRow(GroupBoxLog, 0))
        ElseIf newpos = cmd_gui_position.top Then
            butmcmdarr.Invoke(Sub() butmcmdarr.Text = "Move Command Area To The Bottom")
            TableLayoutPanel1.Invoke(Sub() TableLayoutPanel1.RowStyles(0).Height = 25)
            TableLayoutPanel1.Invoke(Sub() TableLayoutPanel1.RowStyles(1).Height = 75)
            TableLayoutPanel1.Invoke(Sub() TableLayoutPanel1.SetRow(TableLayoutPanel2, 0))
            TableLayoutPanel1.Invoke(Sub() TableLayoutPanel1.SetRow(GroupBoxLog, 1))
        End If
        contrvis(True)
        Return newpos
    End Function

    Public Sub callonform(subtocall As [Delegate])
        Me.Invoke(subtocall)
    End Sub

    Public Sub calloncontrol(contr As Control, subtocall As [Delegate])
        contr.Invoke(subtocall)
    End Sub

    Private Sub butreset_Click(sender As Object, e As EventArgs) Handles butreset.Click
        contrvis(False)
        Process.Start(assemblypath, convertcmdlinetocmdlinestr(Environment.GetCommandLineArgs(), 1))
        Me.Close()
    End Sub

    Private Function convertcmdlinetocmdlinestr(cmdline As String(), start As Integer) As String
        Dim toreturn As String = ""
        Try
            For i As Integer = start To cmdline.Length - 1 Step 1
                toreturn = toreturn & ControlChars.Quote & cmdline(i) & ControlChars.Quote
                If i <> cmdline.Length - 1 Then
                    toreturn = toreturn & " "
                End If
            Next
        Catch ex As Exception
        End Try
        Return toreturn
    End Function

    Private Sub butexit_Click(sender As Object, e As EventArgs) Handles butexit.Click
        contrvis(False)
        Me.Close()
    End Sub

    Private Sub txtbxcmd_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbxcmd.KeyDown
        If (e.KeyCode = Keys.A And e.Control And Not txtbxcmd.SelectionLength >= txtbxcmd.Text.Length) Then
            e.SuppressKeyPress = True
            txtbxcmd.SelectAll()
            e.Handled = True
            'ElseIf e.KeyCode = Keys.A And e.Control Then
            '    e.SuppressKeyPress = True
            '    e.Handled = True
        ElseIf e.KeyCode = Keys.Return And Not allowenter Then
            e.SuppressKeyPress = True
            e.Handled = True
            contrcmdvis(False)
            cmd_inter(txtbxcmd.Text)
            contrcmdvis(True)
        End If
    End Sub

    Private Sub txtbxlog_KeyDown(sender As Object, e As KeyEventArgs)
        If (e.KeyCode = Keys.A And e.Control And Not txtbxlog.SelectionLength >= txtbxlog.Text.Length) Then
            e.SuppressKeyPress = True
            txtbxlog.SelectAll()
            e.Handled = True
            'ElseIf e.KeyCode = Keys.A And e.Control Then
            '    e.SuppressKeyPress = True
            '    e.Handled = True
        End If
    End Sub

    Private Sub chkbxenter_CheckedChanged(sender As Object, e As EventArgs) Handles chkbxenter.CheckedChanged
        If txtbxcmd.Text.Length = 0 Then
            allowenter = chkbxenter.Checked
        Else
            chkbxenter.Checked = allowenter
        End If
    End Sub

    Private Sub butabout_Click(sender As Object, e As EventArgs) Handles butabout.Click
        contrvis(False)
        aboutbx.ShowDialog()
        contrvis(True)
    End Sub

    Private Sub contrvis(vis As Boolean)
        txtbxcmd.Enabled = vis
        txtbxlog.Enabled = vis
        chkbxenter.Enabled = vis
        butabout.Enabled = vis
        butenter.Enabled = vis
        butexit.Enabled = vis
        butmcmdarr.Enabled = vis
        butreset.Enabled = vis
    End Sub

    Private Sub contrcmdvis(vis As Boolean)
        txtbxcmd.Enabled = vis
        txtbxlog.Enabled = True
        chkbxenter.Enabled = vis
        butabout.Enabled = vis
        butenter.Enabled = vis
        butexit.Enabled = vis
        butmcmdarr.Enabled = vis
        butreset.Enabled = vis
    End Sub

    Private Sub chkchkbxtsub()
        While prrun
threadstart1:
            Try
                Try
                    callonform(Sub()
                                   If txtbxcmd.Text.Length = 0 Then
                                       If chkbxenter.Enabled = False Then
                                           chkbxenter.Enabled = True
                                       End If
                                   Else
                                       If chkbxenter.Enabled = True Then
                                           chkbxenter.Enabled = False
                                       End If
                                   End If
                               End Sub)
                Catch ex As Exception
                End Try
                Thread.Sleep(50)
            Catch ex As Exception
                GoTo threadstart1
            End Try
        End While
    End Sub

    Private Sub flags_sub()
        While prrun
threadstart2:
            Try
                Try
                    callonform(Sub()
                                   If tocleartxt Then
                                       txtbxlog.Clear()
                                       tocleartxt = False
                                   End If
                               End Sub)
                    callonform(Sub()
                                   If movetobottom Then
                                       cmdpos = gui_pos_edit(cmd_gui_position.bottom)
                                       movetobottom = False
                                   End If
                               End Sub)
                    callonform(Sub()
                                   If movetotop Then
                                       cmdpos = gui_pos_edit(cmd_gui_position.top)
                                       movetotop = False
                                   End If
                               End Sub)
                    callonform(Sub()
                                   If quit Then
                                       contrvis(False)
                                       Me.Close()
                                       quit = False
                                   End If
                               End Sub)
                    callonform(Sub()
                                   If restart Then
                                       contrvis(False)
                                       If restart_have_args Then
                                           If restart_custom Then
                                               Dim cargstoformat As String = convertcmdlinetocmdlinestr(restart_custom_args, 0)
                                               Process.Start(assemblypath, cargstoformat)
                                           Else
                                               Process.Start(assemblypath, convertcmdlinetocmdlinestr(Environment.GetCommandLineArgs(), 1))
                                           End If
                                       Else
                                           Process.Start(assemblypath)
                                       End If
                                       Me.Close()
                                       restart = False
                                   End If
                               End Sub)
                    callonform(Sub()
                                   If showabout Then
                                       contrvis(False)
                                       aboutbx.ShowDialog()
                                       contrvis(True)
                                       showabout = False
                                   End If
                               End Sub)
                    callonform(Sub()
                                   If tochangeenter Then
                                       contrvis(False)
                                       allowenter = changeenterto
                                       chkbxenter.Checked = allowenter
                                       contrvis(True)
                                       tochangeenter = False
                                   End If
                               End Sub)
                    callonform(Sub()
                                   If toappendtext Then
                                       txtbxlog.AppendText(appendtext)
                                       If loged Then
                                           log = log & appendtext
                                       End If
                                       toappendtext = False
                                       appendtext = ""
                                   End If
                               End Sub)
                    callonform(Sub()
                                   If rundelegate Then
                                       If Not IsNothing(deltorun) Then
                                           callonform(deltorun)
                                           deltorun = Nothing
                                       End If
                                       rundelegate = False
                                   End If
                               End Sub)
                Catch ex As Exception
                End Try
                Thread.Sleep(50)
            Catch ex As Exception
                GoTo threadstart2
            End Try
        End While
    End Sub

    Private Sub main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        contrvis(False)
        If checkchkbxthread.IsAlive Then
            checkchkbxthread.Abort()
        End If
        If flags_thread.IsAlive Then
            flags_thread.Abort()
        End If
        If command_thread.IsAlive Then
            command_thread.Abort()
        End If
        If log <> "" Then
            savefile(logpath & "\msg_cmd_cs-" & DateTime.Now.Hour & "-" & DateTime.Now.Minute & "-" & DateTime.Now.Second & "-" & DateTime.Now.Day & "-" & DateTime.Now.Month & "-" & DateTime.Now.Year & "-" & ".txt", log)
            log = ""
        End If
    End Sub

    Private Sub butenter_Click(sender As Object, e As EventArgs) Handles butenter.Click
        contrcmdvis(False)
        cmd_inter(txtbxcmd.Text)
        contrcmdvis(True)
    End Sub

    Private Sub cmd_inter(cmd As String)
        If txtbxcmd.Text <> "" Then
            If allowenter Then
                Dim ccom As String = ""
                Dim cuchar As String = ""
                Dim lchar As String = ""
                Dim comlist As New List(Of String)
                For i As Integer = 0 To txtbxcmd.Text.Length - 1 Step 1
                    cuchar = txtbxcmd.Text.Substring(i, 1)
                    If (cuchar = Chr(10) And lchar = Chr(13)) Then
                        comlist.Add(ccom)
                        ccom = ""
                    ElseIf i = txtbxcmd.Text.Length - 1 Then
                        If cuchar <> Chr(10) And cuchar <> Chr(13) Then
                            ccom = ccom & cuchar
                        End If
                        comlist.Add(ccom)
                        ccom = ""
                    Else
                        If cuchar <> Chr(10) And cuchar <> Chr(13) Then
                            ccom = ccom & cuchar
                        End If
                    End If
                    lchar = cuchar
                Next
                Dim l_stack As New Stack(Of String)
                For Each curcom As String In comlist
                    If curcom <> "" Then
                        l_stack.Push(curcom)
                    End If
                Next
                For i As Integer = 1 To l_stack.Count Step 1
                    Dim comcmd As String = l_stack.Pop()
                    command_stack.Push(comcmd)
                Next
            Else
                command_stack.Push(cmd)
            End If
        End If
        txtbxcmd.Text = ""
    End Sub

    Private Sub command_sub()
        While prrun
threadstart3:
            Try
                Try
                    callonform(Sub()
                                   While command_stack.Count > 0 And commands_init
                                       Dim curcom As String = command_stack.Pop()
                                       Dim retfromruncmd As String = run_cmd(curcom)
                                       If retfromruncmd <> "" Then
                                           If loged Then
                                               log = log & retfromruncmd & ControlChars.CrLf
                                           End If
                                           txtbxlog.AppendText(retfromruncmd & ControlChars.CrLf)
                                       End If
                                       Thread.Sleep(25)
                                   End While
                               End Sub)
                    If log.Length > 999999 And loged Then
                        If savefile(logpath & "\msg_cmd_cs-" & DateTime.Now.Hour & "-" & DateTime.Now.Minute & "-" & DateTime.Now.Second & "-" & DateTime.Now.Day & "-" & DateTime.Now.Month & "-" & DateTime.Now.Year & "-" & ".txt", log) Then
                            log = ""
                        Else
                            MsgBox("Error Saving Log To: " & logpath & ".", MsgBoxStyle.OkOnly, "msg_cmd_cs Error")
                        End If
                    End If
                Catch ex As Exception
                End Try
                Thread.Sleep(50)
            Catch ex As Exception
                GoTo threadstart3
            End Try
        End While
    End Sub

    Private Sub main_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        command_thread.Start()

        Dim cmdargs As String() = Environment.GetCommandLineArgs()
        Dim l_stack As New Stack(Of String)
        For i As Integer = 1 To cmdargs.Count - 1 Step 1
            If cmdargs(i) <> "" Then
                l_stack.Push(cmdargs(i))
            End If
        Next
        For i As Integer = 1 To l_stack.Count Step 1
            Dim comcmd As String = l_stack.Pop()
            command_stack.Push(comcmd)
        Next
    End Sub

    Private Sub main_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'callonform(Sub() Application.Exit())
        'callonform(Sub() Application.ExitThread())
        'aboutbx.Dispose()
        'Thread.Sleep(50)
        'Application.Exit()
        'Application.ExitThread()
        'Thread.Sleep(50)
        'Environment.Exit(0)
        'Dim pro As Process = Process.GetCurrentProcess()
        'pro.Kill()
        'End
        'Thread.CurrentThread.Abort()
    End Sub
End Class

Public Enum cmd_gui_position As Integer
    top = 0
    bottom = 1
End Enum
