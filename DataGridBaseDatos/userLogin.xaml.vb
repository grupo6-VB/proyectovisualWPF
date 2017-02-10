Imports System.Data.OleDb
Imports System.Data

Class userLogin

    Public dbPath As String = "sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Public dsPersonas As DataSet

    Dim nom As String


    Private Sub btn_ingresar_Click(sender As Object, e As RoutedEventArgs) Handles btn_ingresar.Click


        Using conexion As New OleDbConnection(strConexion)
            'Module1.cedula = txtUser.Text



            If validar_Login() = True Then
                MsgBox("Bienvenido " & nom)
                Module1.usuario = txt_user.Text
                Dim userWin As New tablaConsulta()
                txt_user.Clear()
                txt_pass.Clear()
                userWin.Owner = Me
                userWin.Show()
            Else
                MsgBox("Usuario o contraseña incorrecta")

            End If



        End Using

    End Sub

    Function validar_Login()
        Dim dt As New DataTable
        Dim ds As New DataSet

        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM candidatos;"
            Dim ad As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            ad.Fill(dt)
            For Each DataRow In dt.Rows
                If txt_user.Text = DataRow(1) And txt_pass.Text = DataRow(2) Then
                    nom = DataRow(5) & " " & DataRow(6)
                    conexion.Close()
                    Return True

                End If
            Next
            Return False


        End Using
    End Function


End Class
