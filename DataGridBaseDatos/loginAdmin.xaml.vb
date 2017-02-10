
Imports System.Data.OleDb
Imports System.Data
Public Class loginAdmin

    Public dsPersonas As DataSet
    'Dim ced As String
    Dim nom As String

    Private Sub btn_admin_Click(sender As Object, e As RoutedEventArgs) Handles btn_admin.Click

        If validar_Login() = True Then
            MsgBox("Bienvenido " & nom)
            txtUser.Clear()
            pwd_pass.Clear()
            DatosPublicos.admin = txtUser.Text
            Dim adminWin As New WinAdministrar()
            adminWin.Owner = Me.Owner
            adminWin.Show()
            Me.Hide()
        Else
            MsgBox("Usuario o contraseña incorrecta")

        End If

        'Dim adminWin As New WinAdministrar()
        'adminWin.Owner = Me
        'adminWin.Show()



    End Sub

    Public Function validar_Login()
        Dim dt As New DataTable
        Dim ds As New DataSet

        Using conexion As New OleDbConnection(DatosPublicos.cd_conexion)
            Dim consulta As String = "Select * FROM admin;"
            Dim ad As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            ad.Fill(dt)
            For Each DataRow In dt.Rows
                If txtUser.Text = DataRow(1) And pwd_pass.Password = DataRow(2) Then
                    nom = DataRow(4) & " " & DataRow(5)
                    conexion.Close()
                    Return True

                End If
            Next
            Return False


        End Using


    End Function

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim padre As WinElecciones
        padre = Me.Owner
        padre.Show()
        Me.Hide()
    End Sub
End Class
