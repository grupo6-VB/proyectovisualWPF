
Imports System.Data.OleDb
Imports System.Data
Public Class tablaConsulta
    Public dbPath As String = "sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Public dsPersonas As DataSet
    'Dim usuario As String

    'Public Sub New(text As String)
    '    usuario = text
    '    MsgBox(usuario)
    'End Sub
    'Dim ced As String
    Dim user As String


    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)


        Using conexion As New OleDbConnection(strConexion)
            user = Module1.usuario
            'passw = Module1.pass

            '  MsgBox(passw)

            Dim consulta As String = "Select * FROM candidatos WHERE usuario = '" & user & "'"


            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsPersonas = New DataSet("tbl_master")
            adapter.FillSchema(dsPersonas, SchemaType.Source)

            adapter.Fill(dsPersonas, "tbl_master")

            tabla_consulta.DataContext = dsPersonas

            tabla_consulta.IsEnabled = False

        End Using

    End Sub










    Public Sub UpdatePersona(id As Integer, nombre As String, apellido As String, lugar As String)

    End Sub


End Class
