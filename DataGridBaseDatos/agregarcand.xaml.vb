Imports System.Data
Imports System.Data.OleDb

Public Class agregarcand

    Public dbPath As String = "sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Public dsPersonas As DataSet

    Dim dt As New DataTable
    Dim ds As New DataSet
    Dim nuevo As DataRow = dt.NewRow
    Dim d As Integer
    Dim caracteres() As Char = New Char() {">"c, "<"c, "."c, ","c, ";"c, ":"c, "^"c, "["c, "`"c, "+"c, "*"c, "]"c, "ç"c, "}"c, "{"c, "´"c, "¨"c, "º"c, "\"c, "!"c, "|"c, "="c, "?"c, "'"c, "?"c, "¡"c, ")"c, "%"c, "&"c, "$"c, "#"c, "/"c, "-"c, "_"c, "@"c, "("c, "¿"c, Chr(34)}
    Dim ban As Boolean


    Sub limpiar_campos()

        box_dignidades.Text = ""
        txt_cedula.Clear()
        txt_clave.Clear()
        txt_nombre.Clear()
        txt_apellido.Clear()
        txt_usuario.Clear()
        box_estado.Text = ""
        box_lista.Text = ""
        txt_votos.Clear()

    End Sub

    Private Sub btn_ok_Click(sender As Object, e As RoutedEventArgs) Handles btn_ok.Click

        If box_dignidades.Text = "presidente" Then
            d = 1
        End If
        If box_dignidades.Text = "asambleista" Then
            d = 2
        End If
        If box_dignidades.Text = "parlamento andino" Then
            d = 3
        End If

        If txt_cedula.Text = "" Or txt_nombre.Text = "" Or txt_apellido.Text = "" Or box_dignidades.Text = "" Or box_lista.Text = "" Then
            MsgBox("Debe llenar todos los campos")
        Else
            'nuevo_Candidato()

            If buscar_Candidato() = True Then
                MsgBox("esa cedula ya existe")
                limpiar_campos()

                'MsgBox("Ha ingresado un nuevo candidato")
            Else
                Using conexion As New OleDbConnection(strConexion)
                    'conexion.Open()
                    Dim consulta As String = "Select * FROM candidatos;"
                    Dim ad As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
                    ad.Fill(dt)

                    ds.Tables.Add(dt)
                    ad.Fill(dt)

                    insertar_datos()


                    dt.Rows.Add(nuevo)
                    Dim cb As New OleDbCommandBuilder(ad)
                    ad.Update(dt)
                    conexion.Close()
                    MsgBox("candidato ingresado correctamente")
                    limpiar_campos()
                    'Me.Close()
                End Using

            End If


        End If

    End Sub

    Sub insertar_datos()
        'Dim nuevo As DataRow = dt.NewRow

        With nuevo
            .Item("usuario") = txt_usuario.Text
            .Item("clave") = txt_clave.Text
            .Item("cedula") = txt_cedula.Text
            .Item("tipousuario") = "candidato"
            .Item("cedula") = txt_cedula.Text
            .Item("nombre") = txt_nombre.Text
            .Item("apellido") = txt_apellido.Text
            .Item("estadosufragio") = box_estado.Text
            .Item("dignidad") = d
            .Item("partido") = box_lista.Text
            .Item("puesto") = box_dignidades.Text
            .Item("votos") = txt_votos.Text

        End With

    End Sub
    Public Function buscar_Candidato()
        'Dim dt As New DataTable
        'Dim ds As New DataSet

        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM candidatos;"
            Dim ad As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            ad.Fill(dt)
            For Each DataRow In dt.Rows


                'If txt_cedula.Text = DataRow(4) And txt_apellido.Text = DataRow(6) And txt_nombre.Text = DataRow(5) And (box_dignidades.Text) = DataRow(11) And CInt(box_lista.Text) = DataRow(9) Then

                '    Return True
                'End If

                If txt_cedula.Text = DataRow(4) Then

                    Return True

                End If

            Next
            Return False
            conexion.Close()
        End Using

    End Function



    Private Sub txt_cedula_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txt_cedula.TextChanged
        'Dim c As Integer
        'c = txt_cedula
        If Not IsNumeric(txt_cedula.Text) And txt_cedula.Text <> “” Then
            Beep()
            MsgBox(“Se debe ingresar solo números”)
            txt_cedula.Text = “”
            txt_cedula.Focus()

        End If

    End Sub



    Private Sub txt_cedula_LostFocus(sender As Object, e As RoutedEventArgs) Handles txt_cedula.LostFocus
        'Dim KeyAscii As Integer
        If Not Len(txt_cedula.Text) = 10 Then
            txt_cedula.Clear()
            MsgBox(“ingrese 10 números”)
        End If


    End Sub


    Private Sub txt_nombre_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txt_nombre.TextChanged
        'c = txt_cedula
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

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub txt_apellido_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txt_apellido.TextChanged
        If caracteres.Contains(txt_apellido.Text) Then
            txt_apellido.Clear()
            MsgBox(“ingrese solo texto”)

        End If


        If IsNumeric(txt_apellido.Text) And txt_apellido.Text <> “” Then
            Beep()
            MsgBox(“ingrese solo texto”)
            txt_apellido.Text = “”

        End If
    End Sub

    Private Sub txt_usuario_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txt_usuario.TextChanged
        If caracteres.Contains(txt_usuario.Text) Then
            txt_usuario.Clear()
            MsgBox(“ingrese solo letras y numeros”)

        End If
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
End Class
