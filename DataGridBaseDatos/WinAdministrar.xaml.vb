Imports System.Data
Imports System.Data.OleDb

Public Class WinAdministrar
    Public dbPath As String = "sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Public dsPersonas As DataSet
    Dim ced As String
    Dim passw As String

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        Using conexion As New OleDbConnection(strConexion)
            ced = DatosPublicos.cedula
            passw = DatosPublicos.pass

            '  MsgBox(passw)

            Dim consulta As String = "Select * FROM candidatos;"
            '  Dim consulta As String = "Select * FROM tbl_master WHERE Cedula =" & ced & " AND pass =" & passw & ";"
            'Dim consulta As String = "Select * FROM tbl_master;"

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsPersonas = New DataSet("tbl_master")
            adapter.FillSchema(dsPersonas, SchemaType.Source)

            adapter.Fill(dsPersonas, "tbl_master")

            tablacandidatos.DataContext = dsPersonas

        End Using
    End Sub

    Private Sub btn_Agregar_Click(sender As Object, e As RoutedEventArgs) Handles btn_Agregar.Click
        Dim agrecand As New agregarcand()
        agrecand.Owner = Me
        agrecand.Show()
    End Sub
End Class
