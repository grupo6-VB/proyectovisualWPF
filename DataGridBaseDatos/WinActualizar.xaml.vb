Imports System.Data
Imports System.Data.OleDb

Public Class WinActualizar
    Public dbPath As String = "sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Public dsPersonas As DataSet

    Dim caracteres() As Char = New Char() {">"c, "<"c, "."c, ","c, ";"c, ":"c, "^"c, "["c, "`"c, "+"c, "*"c, "]"c, "ç"c, "}"c, "{"c, "´"c, "¨"c, "º"c, "\"c, "!"c, "|"c, "="c, "?"c, "'"c, "?"c, "¡"c, ")"c, "%"c, "&"c, "$"c, "#"c, "/"c, "-"c, "_"c, "@"c, "("c, "¿"c, Chr(34)}


    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub btn_actualizar_Click(sender As Object, e As RoutedEventArgs) Handles btn_actualizar.Click
        Dim cedula = 0
        If txt_cedula.Text = "" Or txt_nombre.Text = "" Or txt_apellido.Text = "" Or txt_usuario.Text = "" Or txt_clave.Text = "" Or box_dignidades.Text = "" Or box_lista.Text = "" Or box_estado.Text = "" Or txt_votos.Text = "" Then
            MsgBox("Debe llenar todos los campos")
        Else

            Try
                cedula = Me.DataContext.Cedula()
            Catch ex As Exception

            End Try
            Dim padre As WinAdministrar = CType(Me.Owner, WinAdministrar)
            padre.UpdatePersona(txt_cedula.Text, txt_nombre.Text, txt_apellido.Text, box_lista.Text, txt_usuario.Text, txt_clave.Text, box_estado.Text, box_dignidades.Text, txt_votos.Text)
            Me.Close()
        End If
    End Sub

    Private Sub txt_cedula_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txt_cedula.TextChanged
        If Not IsNumeric(txt_cedula.Text) And txt_cedula.Text <> “” Then
            Beep()
            MsgBox(“Se debe ingresar solo números”)
            txt_cedula.Text = “”
            txt_cedula.Focus()

        End If
    End Sub

    Private Sub txt_cedula_LostFocus(sender As Object, e As RoutedEventArgs) Handles txt_cedula.LostFocus
        If Not Len(txt_cedula.Text) = 10 Then
            txt_cedula.Clear()
            MsgBox(“ingrese 10 números”)
        End If


    End Sub

    Private Sub txt_nombre_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txt_nombre.TextChanged
        If caracteres.Contains(txt_nombre.Text) Then
            txt_nombre.Clear()
            MsgBox(“ingrese solo texto”)

        End If


        If IsNumeric(txt_nombre.Text) And txt_nombre.Text <> “” Then
            Beep()
            MsgBox(“ingrese solo texto”)
            txt_nombre.Text = “”

        End If
    End Sub

    Private Sub txt_usuario_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txt_usuario.TextChanged
        'If caracteres.Contains(txt_usuario.Text) Then
        '    txt_usuario.Clear()
        '    MsgBox(“ingrese solo letras y numeros”)

        'End If
    End Sub

    Private Sub txt_clave_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txt_clave.TextChanged
        If caracteres.Contains(txt_clave.Text) Then
            txt_clave.Clear()
            MsgBox(“ingrese solo letras y numeros”)

        End If
    End Sub

    Private Sub txt_votos_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txt_votos.TextChanged
        If Not IsNumeric(txt_votos.Text) And txt_votos.Text <> “” Then
            Beep()
            MsgBox(“Se debe ingresar solo números”)
            txt_votos.Text = “”
            txt_votos.Focus()

        End If
    End Sub

    Private Sub txt_votos_LostFocus(sender As Object, e As RoutedEventArgs) Handles txt_votos.LostFocus
        If Len(txt_votos.Text) > 7 Then
            txt_votos.Clear()
            MsgBox(“El numero ingresado es demasiado grande”)
        End If
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        'txt_cedula.IsEnabled = False

    End Sub


    Private Sub btn_borrar_Click(sender As Object, e As RoutedEventArgs) Handles btn_borrar.Click
        '  Dim ced = txt_cedula.Text

        Using conexion As New OleDbConnection(strConexion)
            conexion.Open()
            Dim consulta_eliminar As String = "DELETE FROM candidatos WHERE cedula='" & txt_cedula.Text & "'"
            'Dim ad As New OleDbDataAdapter(New OleDbCommand(consulta_eliminar, conexion))
            Dim comandos As New OleDbCommand
            comandos = New OleDbCommand(consulta_eliminar, conexion)

            comandos.ExecuteNonQuery()
            'Dim ad As OleDbCommand = New OleDbCommand(consulta_eliminar, conexion)
            'MsgBox(txt_cedula.Text)


            MsgBox("Registro eliminado")
            box_dignidades.Text = ""
            txt_cedula.Clear()
            txt_clave.Clear()
            txt_nombre.Clear()
            txt_apellido.Clear()
            txt_usuario.Clear()
            box_estado.Text = ""
            box_lista.Text = ""
            txt_votos.Clear()
            conexion.Close()



        End Using
    End Sub
End Class
