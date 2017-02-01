Imports System.Data.OleDb
Imports System.Data
Public Class WinSufragio
    Public dbPath As String = "sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Public dsDignidades As DataSet

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        Using conexion As New OleDbConnection(strConexion)

            '  MsgBox(passw)

            Dim consulta As String = "Select * FROM dignidades;"

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim dignidadCmdBuilder = New OleDbCommandBuilder(adapter)
            dsDignidades = New DataSet("dignidades")
            adapter.FillSchema(dsDignidades, SchemaType.Source)

            adapter.Fill(dsDignidades, "dignidades")
        End Using

    End Sub
End Class
