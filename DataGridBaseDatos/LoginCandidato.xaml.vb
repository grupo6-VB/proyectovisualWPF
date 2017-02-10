Imports System.Data.OleDb
Imports System.Data

Class LoginCandidato

    Public dbPath As String = "sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath





    Private Sub btn_ingresar_Click(sender As Object, e As RoutedEventArgs) Handles btn_ingresar.Click
        Dim dsCandidatos As DataSet = New DataSet
        Using conexion As New OleDbConnection(DatosPublicos.cd_conexion)
            DatosPublicos.cedula = txt_user.Text


            'Dim consulta As String = "Select * FROM tbl_master;"
            Dim consulta As String = "Select * FROM candidatos WHERE usuario = '" & txt_user.Text & "';"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim candidatoCmdBuilder = New OleDbCommandBuilder(adapter)
            dsCandidatos = New DataSet("candidatos")
            adapter.FillSchema(dsCandidatos, SchemaType.Source)
            adapter.Fill(dsCandidatos, "candidatos")

            If dsCandidatos.Tables("candidatos").Rows.Count = 0 Then
                Dim style As MsgBoxStyle
                Dim response As MsgBoxResult
                style = MsgBoxStyle.DefaultButton2 Or _
                   MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly
                response = MsgBox("USUARIO INVÁLIDO", style, "ERROR USUARIO")
            ElseIf pwd_pass.Password = dsCandidatos.Tables("candidatos").Rows(0).Item(2) Then
                Dim candidato As Candidato = New Candidato()
                For Each row As DataRow In dsCandidatos.Tables("candidatos").Rows
                    candidato.Id = row.Item(0)
                    candidato.User = row.Item(1)
                    candidato.Pass = row.Item(2)
                    candidato.Cedula = row.Item(4)
                    candidato.Nombre = row.Item(5)
                    candidato.Apellido = row.Item(6)
                    candidato.EstadoSufragio = row.Item(7)
                    candidato.Dignidad = row.Item(8)
                    candidato.Partido = row.Item(9)
                    candidato.Votos = row.Item(10)
                Next
                Dim consult As New tablaConsulta()
                consult.DataContext = candidato
                'consult.Owner = Me
                consult.Show()
                Me.Hide()
            Else
                Dim style As MsgBoxStyle
                Dim response As MsgBoxResult
                style = MsgBoxStyle.DefaultButton2 Or _
                   MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly
                response = MsgBox("CLAVE INVÁLIDA", style, "ERROR CLAVE")
            End If

        End Using

    End Sub


End Class
