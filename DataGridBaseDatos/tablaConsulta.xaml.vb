
Imports System.Data.OleDb
Imports System.Data
Public Class tablaConsulta
    Public dbPath As String = "C:\Users\ronny\Source\Repos\proyectovisualWPF\sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Public dsPersonas As DataSet
    Dim ced As String
    Dim passw As String


    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)



        Using conexion As New OleDbConnection(strConexion)
            ced = Module1.cedula
            passw = Module1.pass

            '  MsgBox(passw)

            Dim consulta As String = "Select * FROM tbl_master WHERE Cedula =" & ced & ";"
            '  Dim consulta As String = "Select * FROM tbl_master WHERE Cedula =" & ced & " AND pass =" & passw & ";"
            'Dim consulta As String = "Select * FROM tbl_master;"

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsPersonas = New DataSet("tbl_master")
            adapter.FillSchema(dsPersonas, SchemaType.Source)

            adapter.Fill(dsPersonas, "tbl_master")

            dataGrid2.DataContext = dsPersonas



        End Using

    End Sub



    Private Sub dataGrid1_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dataGrid2.SelectionChanged
        Dim fila As DataRowView = sender.SelectedItem


        Dim winPersona As New WinPersona
        winPersona.Owner = Me

        'Dim persona As New Persona(fila("EmployeeID"), fila("FirstName"), fila("LastName"), fila("Lugardevotacion"))
        Dim persona As New Persona(fila("Cedula"), fila("Nombre"), fila("Apellido"), fila("Lugardevotacion"), fila("EstadoSufragio"))
        winPersona.DataContext = persona

        winPersona.Show()
        Me.Hide()
    End Sub



    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim winPersona As New WinPersona
        winPersona.Owner = Me


        winPersona.Show()
        Me.Hide()
    End Sub


    Public Sub UpdatePersona(id As Integer, nombre As String, apellido As String, lugar As String)
        If id = 0 Then
            Me.dsPersonas.Tables("tbl_master").Rows.Add(id, nombre, apellido, lugar)
        Else
            For Each persona As DataRow In Me.dsPersonas.Tables("tbl_master").Rows
                If persona("EmployeeID") = id Then
                    persona("FirstName") = nombre
                    persona("LastName") = apellido
                    persona("Location") = lugar
                End If
            Next
        End If

        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM tbl_master;"

            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)

            Try
                adapter.Update(dsPersonas.Tables("tbl_master"))
            Catch ex As Exception
                MessageBox.Show("Error al guardar")
            End Try

        End Using
    End Sub


End Class
