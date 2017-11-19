Imports captainalm.calmclientandserver
Imports System.Net
Imports System.Security.Principal

Public Module cs 'client and server module
    Public server_obj As server = New server()
    Public client_obj As client = New client()
    Public current_mode As current_cs_mode = current_cs_mode.none
    Public current_name As String = server_obj.ip.ToString & "-" & WindowsIdentity.GetCurrent.User.ToString
    Public password As String = ""
    Public log_cs As String = ""

    Public Function start_server(Optional ipadd As String = "", Optional port As UInteger = 100, Optional password2 As String = "", Optional encryptt As EncryptionMethod = EncryptionMethod.none) As String
        If current_mode = current_cs_mode.none Then
            Dim ipaddtopass2 As IPAddress = IPAddress.None
            Try
                ipaddtopass2 = IPAddress.Parse(ipadd)
            Catch ex As Exception
                ipaddtopass2 = IPAddress.None
            End Try
            current_mode = current_cs_mode.server
            password = password2
            server_obj = New server(ipaddtopass2, port)
            reg_events()
            Return server_obj.Start(password, encryptt)
        Else
            Return "Could Not Start Server - Something is Already Running"
        End If
    End Function

    Public Function start_client(ipadd As String, Optional port As UInteger = 100, Optional password2 As String = "", Optional encryptt As EncryptionMethod = EncryptionMethod.none) As String
        If current_mode = current_cs_mode.none Then
            current_mode = current_cs_mode.client
            password = password2
            If Not client.CheckServer(ipadd, port) Then
                Return "Server Not Running!"
            End If
            client_obj = New client()
            reg_events()
            Dim toret As String = client_obj.Connect(current_name, ipadd, port, password2, encryptt)
            Return toret
        Else
            Return "Could Not Start Client - Something is Already Running"
        End If
    End Function

    Public Function stop_server() As String
        If current_mode = current_cs_mode.server Then
            server_obj.Stop()
            server_obj.flush()
            unreg_events()
            current_mode = current_cs_mode.none
            Return True
        Else
            Return "Could Not Stop Server - Something is Already Running or there is Nothing Running"
        End If
    End Function

    Public Function stop_client() As String
        If current_mode = current_cs_mode.client Then
            client_obj.Disconnect()
            client_obj.flush()
            unreg_events()
            current_mode = current_cs_mode.none
            Return True
        Else
            Return "Could Not Stop Client - Something is Already Running or there is Nothing Running"
        End If
    End Function

    Public Function disconnect_client(clientnom As String) As String
        If current_mode = current_cs_mode.server Then
            Return server_obj.Disconnect(clientnom)
        Else
            Return "Could Not Disconnect Client - is the Server Running?"
        End If
    End Function

    Public Function send_message_to_server(msg As String) As String
        If current_mode = current_cs_mode.client Then
            Return client_obj.Send(New packet(0, client_obj.Name, New List(Of String), "msg_cmd_cs", msg))
        Else
            Return "Could Not Send Message - is the Client Running?"
        End If
    End Function

    Public Function send_message_to_server(head As String, msg As String) As String
        If current_mode = current_cs_mode.client Then
            Return client_obj.Send(New packet(0, client_obj.Name, New List(Of String), head, msg))
        Else
            Return "Could Not Send Message - is the Client Running?"
        End If
    End Function

    Public Function send_message_to_server(head As String, msg As String, rec As List(Of String)) As String
        If current_mode = current_cs_mode.client Then
            Return client_obj.Send(New packet(0, client_obj.Name, rec, head, msg))
        Else
            Return "Could Not Send Message - is the Client Running?"
        End If
    End Function

    Public Function send_message_to_client(client As String, msg As String) As String
        If current_mode = current_cs_mode.server Then
            Return server_obj.Send(client, New packet(0, "", New List(Of String), "msg_cmd_cs", msg))
        Else
            Return "Could Not Send Message - is the Server Running?"
        End If
    End Function

    Public Function send_message_to_client(client As String, head As String, msg As String) As String
        If current_mode = current_cs_mode.server Then
            Return server_obj.Send(client, New packet(0, "", New List(Of String), head, msg))
        Else
            Return "Could Not Send Message - is the Server Running?"
        End If
    End Function

    Public Function send_message_to_client(client As String, head As String, msg As String, rec As List(Of String)) As String
        If current_mode = current_cs_mode.server Then
            Return server_obj.Send(client, New packet(0, "", rec, head, msg))
        Else
            Return "Could Not Send Message - is the Server Running?"
        End If
    End Function

    Public Function broadcast_mesage_to_all_clients(msg As String) As String
        If current_mode = current_cs_mode.server Then
            Return server_obj.broadcast(New packet(0, "", New List(Of String), "msg_cmd_cs", msg))
        Else
            Return "Could Not Send Message - is the Server Running?"
        End If
    End Function

    Public Function broadcast_mesage_to_all_clients(head As String, msg As String) As String
        If current_mode = current_cs_mode.server Then
            Return server_obj.broadcast(New packet(0, "", New List(Of String), head, msg))
        Else
            Return "Could Not Send Message - is the Server Running?"
        End If
    End Function

    Public Function broadcast_mesage_to_all_clients(head As String, msg As String, rec As List(Of String)) As String
        If current_mode = current_cs_mode.server Then
            Return server_obj.broadcast(New packet(0, "", rec, head, msg))
        Else
            Return "Could Not Send Message - is the Server Running?"
        End If
    End Function

    Public Function get_clients() As List(Of String)
        If current_mode = current_cs_mode.server Then
            Return server_obj.connected_clients
        ElseIf current_mode = current_cs_mode.client Then
            Return client_obj.connected_clients
        Else
            Dim toret As New List(Of String)
            toret.Add("Could Not Get Clients - is the Server or Client Running?")
            Return toret
        End If
    End Function

    Private Sub reg_events()
        If current_mode = current_cs_mode.client Then
            AddHandler client_obj.ServerDisconnect, AddressOf srdis
            AddHandler client_obj.ServerMessage, AddressOf srmsg
        ElseIf current_mode = current_cs_mode.server Then
            AddHandler server_obj.ClientConnect, AddressOf clcon
            AddHandler server_obj.ClientDisconnect, AddressOf cldis
            AddHandler server_obj.ClientMessage, AddressOf clmsg
        End If
    End Sub

    Private Sub unreg_events()
        If current_mode = current_cs_mode.client Then
            RemoveHandler client_obj.ServerDisconnect, AddressOf srdis
            RemoveHandler client_obj.ServerMessage, AddressOf srmsg
        ElseIf current_mode = current_cs_mode.server Then
            RemoveHandler server_obj.ClientConnect, AddressOf clcon
            RemoveHandler server_obj.ClientDisconnect, AddressOf cldis
            RemoveHandler server_obj.ClientMessage, AddressOf clmsg
        End If
    End Sub

    Private Sub clcon(clientname As String)
        log_cs = log_cs & "Client Connected : " & clientname & ControlChars.CrLf
    End Sub

    Private Sub cldis(clientname As String)
        log_cs = log_cs & "Client Disconnected : " & clientname & ControlChars.CrLf
    End Sub

    Private Sub clmsg(clientname As String, packetsent As packet)
        log_cs = log_cs & "Client Message : " & clientname & ControlChars.CrLf
        log_cs = log_cs & packetsent.referencenumber & " : " & packetsent.header & " : sender : " & packetsent.sender & ControlChars.CrLf
        log_cs = log_cs & "Message : " & packetsent.stringdata(password) & ControlChars.CrLf
    End Sub

    Private Sub srdis()
        log_cs = log_cs & "Server Disconnected : " & client_obj.Name & ControlChars.CrLf
    End Sub

    Private Sub srmsg(packetsent As packet)
        log_cs = log_cs & "Server Message :" & ControlChars.CrLf
        log_cs = log_cs & packetsent.referencenumber & " : " & packetsent.header & " : sender : " & packetsent.sender & ControlChars.CrLf
        log_cs = log_cs & "Message : " & packetsent.stringdata(password) & ControlChars.CrLf
    End Sub

    Public Function pull_log() As String
        Dim toret As String = log_cs
        log_cs = ""
        Return toret
    End Function

    Public Sub clear_log()
        log_cs = ""
    End Sub

    Public Function server_up(server As String, Optional port As UInteger = 100) As String
        If current_mode = current_cs_mode.none Then
            Return client.CheckServer(server, port)
        End If
        Return "The Server or Client is Already Running."
    End Function

    Public Function updatcldat() As String
        If current_mode = current_cs_mode.client Then
            client_obj.UpdateClientData()
            Return "Done Client Update!"
        End If
        Return "Failed - Is the Client Running?"
    End Function
End Module

Public Enum current_cs_mode As Integer
    none = 0
    client = 1
    server = 2
    relay = 3 'Not currently to be used (for future reference)
End Enum
