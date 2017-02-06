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

    Private Sub btn_ok_Click(sender As Object, e As RoutedEventArgs) Handles btn_ok.Click

        If txt_cedula.Text = "" Or txt_nombre.Text = "" Or txt_apellido.Text = "" Or box_dignidades.Text = "" Then
            MsgBox("Debe llenar todos los campos")
        Else
            ' nuevo_Candidato()

            If nuevo_Candidato() = True Then
                MsgBox("Ha ingresado un nuevo candidato")

            End If

        End If

    End Sub

    Sub insertar_datos()
        'Dim nuevo As DataRow = dt.NewRow

        With nuevo
            .Item("usuario") = txt_apellido.Text & txt_nombre.Text
            .Item("clave") = "1234"
            .Item("cedula") = txt_cedula.Text
            .Item("tipousuario") = "candidato"
            .Item("cedula") = txt_cedula.Text
            .Item("nombre") = txt_nombre.Text
            .Item("apellido") = txt_apellido.Text
            .Item("estadosufragio") = "FALSE"
            .Item("dignidad") = d
            .Item("partido") = txt_partido.Text
            .Item("puesto") = box_dignidades.Text
            .Item("votos") = 0

        End With

    End Sub
    Public Function nuevo_Candidato()
        'Dim dt As New DataTable
        'Dim ds As New DataSet

        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM candidatosprueba;"
            Dim ad As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            ad.Fill(dt)
            For Each DataRow In dt.Rows



                If Not txt_cedula.Text = DataRow(4) And (txt_apellido.Text = DataRow(6) Or txt_nombre.Text = DataRow(5)) Then
                    'MsgBox("Esa cedula ya existe")


                    If box_dignidades.Text = "Presidente" Then
                        d = 1
                    End If
                    If box_dignidades.Text = "Asambleista" Then
                        d = 2
                    End If
                    If box_dignidades.Text = "Parlamento Andino" Then
                        d = 3
                    End If


                    ds.Tables.Add(dt)
                    ad.Fill(dt)

                    insertar_datos()

                    'Dim nuevo As DataRow = dt.NewRow

                    'With nuevo
                    '    .Item("usuario") = txt_nombre.Text
                    '    .Item("clave") = "1234"
                    '    .Item("cedula") = txt_cedula.Text
                    '    .Item("tipousuario") = "candidato"
                    '    .Item("cedula") = txt_cedula.Text
                    '    .Item("nombre") = txt_apellido.Text & txt_nombre.Text
                    '    .Item("apellido") = txt_apellido.Text
                    '    .Item("estadosufragio") = "FALSE"
                    '    .Item("dignidad") = d
                    '    .Item("partido") = txt_partido.Text
                    '    .Item("puesto") = box_dignidades.Text
                    '    .Item("votos") = 0

                    'End With

                    dt.Rows.Add(nuevo)
                    Dim cb As New OleDbCommandBuilder(ad)
                    ad.Update(dt)
                    conexion.Close()

                    Return True
                End If


                If Not txt_cedula.Text = DataRow(4) And Not txt_apellido.Text = DataRow(6) And Not txt_nombre.Text = DataRow(5) Then
                    Dim d As Integer

                    If box_dignidades.Text = "Presidente" Then
                        d = 1
                    End If
                    If box_dignidades.Text = "Asambleista" Then
                        d = 2
                    End If
                    If box_dignidades.Text = "Parlamento Andino" Then
                        d = 3
                    End If


                    ds.Tables.Add(dt)
                    ad.Fill(dt)

                    insertar_datos()


                    dt.Rows.Add(nuevo)
                    Dim cb As New OleDbCommandBuilder(ad)
                    ad.Update(dt)
                    conexion.Close()


                    conexion.Close()
                    Return True
                End If


                If txt_cedula.Text = DataRow(4) Then
                    MsgBox("Esa cedula ya existe")
                    'conexion.Close()
                    Return False

                End If


            Next

        End Using

    End Function

End Class
