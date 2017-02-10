Imports System.Data
Imports System.Data.OleDb

Public Class WinAdministrar
    Public dbPath As String = "sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Public dsPersonas As DataSet
    Dim ced As String
    Dim passw As String

    Public Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        Using conexion As New OleDbConnection(strConexion)
            ced = Module1.cedula
            passw = Module1.pass

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

    Friend Sub UpdatePersona(cedula As String, nombre As String, apellido As String, lista As String, usuario As String, clave As String, estado As String, puesto As String, votos As String)

        If cedula = 0 Then
            Me.dsPersonas.Tables("tbl_master").Rows.Add(cedula, nombre, apellido, lista, usuario, clave, estado, puesto, votos)
        Else
            For Each persona As DataRow In Me.dsPersonas.Tables("tbl_master").Rows
                If persona("cedula") = cedula Then
                    persona("nombre") = nombre
                    persona("apellido") = apellido
                    persona("partido") = lista
                    persona("usuario") = usuario
                    persona("clave") = clave
                    persona("estadosufragio") = estado
                    persona("puesto") = puesto
                    persona("votos") = CInt(votos)
                End If
            Next
        End If

        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM candidatos;"
            'Dim adapter As New OleDbDataAdapter(consulta, conexion)
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            'adapter.FillSchema(dsPersonas, SchemaType.Source)
            Try
                adapter.Update(dsPersonas.Tables("tbl_master"))
            Catch ex As Exception
                MessageBox.Show("Error al guardar")
            End Try

        End Using
    End Sub

    Private Sub btn_Agregar_Click(sender As Object, e As RoutedEventArgs) Handles btn_Agregar.Click
        Dim agrecand As New agregarcand()
        agrecand.Owner = Me
        agrecand.Show()
    End Sub

    Public Sub tablacandidatos_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles tablacandidatos.SelectionChanged



        Dim fila As DataRowView = sender.SelectedItem


        Dim winAct As New WinActualizar
        winAct.Owner = Me


        Dim candidato As New Candidato(fila("cedula"), fila("nombre"), fila("apellido"), fila("partido"), fila("puesto"), fila("usuario"), fila("clave"), fila("estadosufragio"), fila("votos"))
        winAct.DataContext = candidato

        winAct.Show()
        Me.Hide()


    End Sub


End Class
