Imports System.Net.Sockets
Imports System.Net

Public Class Form1

    Private client As TcpClient

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeTcpClient()
    End Sub

    Private Sub InitializeTcpClient()
        Try
            client = New TcpClient("127.0.0.1", 8081) 'conexión a un servidor en el puerto 8080 en localhost
            MessageBox.Show("Se inició correctamente la conexión al servidor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As SocketException
            MessageBox.Show("Error al conectar con el servidor: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al inicializar el TcpClient: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CheckAndCloseSocket()
        If client IsNot Nothing AndAlso client.Connected Then
            client.Close()
            MessageBox.Show("Se cerró el socket abierto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("No se encontró un socket abierto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If client Is Nothing Then
            MessageBox.Show("El TcpClient no está inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            CheckAndCloseSocket()
        End If
    End Sub

End Class
