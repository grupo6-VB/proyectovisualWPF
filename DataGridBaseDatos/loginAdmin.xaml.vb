
Imports System.Data.OleDb
Imports System.Data
Public Class loginAdmin

    Public dbPath As String = "sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Public dsPersonas As DataSet
    'Dim ced As String
    Dim nom As String

    Private Sub btn_admin_Click(sender As Object, e As RoutedEventArgs) Handles btn_admin.Click

        If validar_Login() = True Then
            MsgBox("Bienvenido " & nom)
            txtUser.Clear()
            txt_pass.Clear()
             Module1.admin = txtUser.Text
            Dim adminWin As New WinAdministrar()
            adminWin.Owner = Me
            adminWin.Show()
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

        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM admin;"
            Dim ad As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            ad.Fill(dt)
            For Each DataRow In dt.Rows
                If txtUser.Text = DataRow(1) And txt_pass.Text = DataRow(2) Then
                    nom = DataRow(4) & " " & DataRow(5)
                    conexion.Close()
                    Return True

                End If
            Next
            Return False


        End Using


    End Function

End Class
