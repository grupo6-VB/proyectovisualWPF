Imports System.Data.OleDb
Imports System.Data
Public Class Win_Bloqueo
    Private bloqueo As Boolean
    Private Sub txt_cedula_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_cedula.KeyDown
        If (e.Key >= Key.D0 And e.Key <= Key.D9 Or e.Key >= Key.NumPad0 And e.Key <= Key.NumPad9) Then
            e.Handled = False
        Else
            If e.Key = Key.Enter Then
                If txt_cedula.Text.Length = 10 Then
                    Dim p As Persona = Consultar_Votante(txt_cedula.Text)
                    If p.Nombre = "" Then
                        txt_cedula.Text = ""
                        MessageBox.Show("CEDULA INVALIDA")
                    Else
                        If Me.bloqueo Then
                            txt_cedula.Text = ""
                            MessageBox.Show("EL VOTANTE YA ESTABA BLOQUEADO")
                        Else
                            Bloquear(p.Cedula)
                        End If
                    End If
                Else
                    txt_cedula.Text = ""
                    MessageBox.Show("CEDULA CORTA")
                End If
            End If
            e.Handled = True
        End If
    End Sub

    Public Function Consultar_Votante(cedula As String) As Persona
        Dim p As Persona = New Persona
        Dim dsPersona As DataSet

        Using conexion As New OleDbConnection(DatosPublicos.cd_conexion)
            Dim consulta As String = "Select * FROM votantes WHERE cedula = '" & cedula & "';"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsPersona = New DataSet("votantes")
            adapter.FillSchema(dsPersona, SchemaType.Source)
            adapter.Fill(dsPersona, "votantes")
            'MessageBox.Show("LEIDO")
        End Using

        For Each row As DataRow In dsPersona.Tables("votantes").Rows
            'MessageBox.Show(row.Item(0) & row.Item(1) & row.Item(2) & row.Item(3) & row.Item(4))
            p.Cedula = row.Item(1)
            p.Nombre = row.Item(2)
            p.Apellido = row.Item(3)
            p.EstadoSufragio = row.Item(4)
            Me.bloqueo = row.Item(5)
        Next

        Return p
    End Function

    Public Sub Bloquear(cedula As String)
        Dim dsPersonas As DataSet = New DataSet
        Using conexion As New OleDbConnection(DatosPublicos.cd_conexion)
            Dim sentencia As String
            Dim Adapter As New OleDbDataAdapter
            Dim actualizacion = New OleDbCommandBuilder(Adapter)
            sentencia = "UPDATE votantes SET bloqueo = 'TRUE' WHERE cedula = '" & cedula & "';"
            Adapter = New OleDbDataAdapter(New OleDbCommand(sentencia, conexion))
            Adapter.Fill(dsPersonas, "votantes")
            Try
                Adapter.Update(dsPersonas.Tables("votantes"))
                'MessageBox.Show("MODIFICADO CON EXITO")
            Catch ex As Exception
                'MessageBox.Show("ERROR AL MODIFICAR")
            End Try
        End Using
        txt_cedula.Text = ""
        MessageBox.Show("VOTANTE BLOQUEADO")

    End Sub

    Private Sub win_bloqueo_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles MyBase.Closing, MyBase.Closing
        Dim adm As WinAdministrar
        adm = Me.Owner
        adm.Show()
        Me.Hide()
    End Sub
End Class
