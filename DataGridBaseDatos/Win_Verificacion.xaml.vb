Imports System.Data.OleDb
Imports System.Data
Public Class Win_Verificacion
    Public dbPath As String = "sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Private Sub txt_cedula_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_cedula.KeyDown
        If (e.Key >= Key.D0 And e.Key <= Key.D9 Or e.Key >= Key.NumPad0 And e.Key <= Key.NumPad9) Then
            e.Handled = False
        Else
            If e.Key = Key.Enter Then
                If txt_cedula.Text.Length = 10 Then
                    Dim p As Persona = Consultar_Votante(txt_cedula.Text)
                    If p.Nombre = "" Then
                        MessageBox.Show("CEDULA INVALIDA")
                    Else
                        If p.EstadoSufragio Then
                            MessageBox.Show("YA EJERCIO SU DERECHO")
                        Else
                            MessageBox.Show("BIENVENIDO")
                            Dim sufragio As New WinSufragio()
                            'Dim w_el As WinElecciones
                            'w_el = sufragio.Owner
                            sufragio.DataContext = p
                            sufragio.Show()
                            Me.Close()
                        End If
                    End If
                Else
                    MessageBox.Show("CEDULA CORTA")
                End If
            End If
            e.Handled = True
        End If
    End Sub

    Public Function Consultar_Votante(cedula As String) As Persona
        Dim p As Persona = New Persona
        Dim dsPersona As DataSet

        Using conexion As New OleDbConnection(strConexion)
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
        Next

        Return p
    End Function

    Private Sub win_verificacion_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles MyBase.Closing, MyBase.Closing
        Dim padre As WinElecciones
        padre = Me.Owner
        padre.Show()
        Me.Hide()
    End Sub
End Class
