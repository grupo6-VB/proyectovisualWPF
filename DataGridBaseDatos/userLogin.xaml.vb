Imports System.Data.OleDb
Imports System.Data

Class userLogin

    Public dbPath As String = "C:\Users\ronny\Documents\Visual Studio 2015\projects\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Public dsPersonas As DataSet




    Private Sub btn_ingresar_Click(sender As Object, e As RoutedEventArgs) Handles btn_ingresar.Click


        Using conexion As New OleDbConnection(strConexion)
            Module1.cedula = txtUser.Text


            'Dim consulta As String = "Select * FROM tbl_master;"
            '    'Dim consulta As String = "Select * FROM tbl_master WHERE EmployeeID =" & txtUser.Text & ";"
            '    Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))

            '    Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            '    dsPersonas = New DataSet("tbl_master")
            '    adapter.FillSchema(dsPersonas, SchemaType.Source)

            'adapter.Fill(dsPersonas, "tbl_master")

            Dim consult As New tablaConsulta()
            consult.Owner = Me
            consult.Show()



        End Using

    End Sub

    Private Sub txtUser_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtUser.TextChanged

    End Sub
End Class
