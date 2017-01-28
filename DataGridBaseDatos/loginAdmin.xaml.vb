
Imports System.Data.OleDb
Imports System.Data
Public Class loginAdmin

    Public dbPath As String = "C:\Users\ronny\Documents\Visual Studio 2015\projects\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Public dsPersonas As DataSet
    'Dim ced As String


    Private Sub btn_admin_Click(sender As Object, e As RoutedEventArgs) Handles btn_admin.Click
        Module1.cedula = txtUser.Text
        Module1.pass = txt_pass.Text


        Dim consult As New tablaConsulta()
        consult.Owner = Me
        consult.Show()
    End Sub
End Class
