﻿Imports System.Data.OleDb
Imports System.Data
Public Class tablaConsulta
    
    Public dsCandidatos As DataSet
    Private candidato As Candidato

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        candidato = Me.DataContext

        Me.Title = "RESULTADOS PARCIALES --> " & candidato.Nombre & "  " & candidato.Apellido

        If candidato.EstadoSufragio Then
            Me.btn_sufragar.IsEnabled = False
        End If


        Using conexion As New OleDbConnection(DatosPublicos.cd_conexion)
           
            Dim consulta As String = "Select * FROM candidatos WHERE dignidad =" & candidato.Dignidad & ";"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsCandidatos = New DataSet("candidatos")
            adapter.FillSchema(dsCandidatos, SchemaType.Source)

            adapter.Fill(dsCandidatos, "candidatos")
            dtg_resultados.DataContext = dsCandidatos

        End Using

    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim winPersona As New WinPersona
        winPersona.Owner = Me


        winPersona.Show()
        Me.Hide()
    End Sub


    Public Sub UpdatePersona(id As Integer, nombre As String, apellido As String, lugar As String)
        'If id = 0 Then
        '    Me.dsPersonas.Tables("tbl_master").Rows.Add(id, nombre, apellido, lugar)
        'Else
        '    For Each persona As DataRow In Me.dsPersonas.Tables("tbl_master").Rows
        '        If persona("EmployeeID") = id Then
        '            persona("FirstName") = nombre
        '            persona("LastName") = apellido
        '            persona("Location") = lugar
        '        End If
        '    Next
        'End If

        'Using conexion As New OleDbConnection(strConexion)
        '    Dim consulta As String = "Select * FROM tbl_master;"

        '    Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
        '    Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)

        '    Try
        '        adapter.Update(dsPersonas.Tables("tbl_master"))
        '    Catch ex As Exception
        '        MessageBox.Show("Error al guardar")
        '    End Try

        'End Using
    End Sub


    Private Sub btn_sufragar_Click(sender As Object, e As RoutedEventArgs) Handles btn_sufragar.Click

    End Sub
End Class
