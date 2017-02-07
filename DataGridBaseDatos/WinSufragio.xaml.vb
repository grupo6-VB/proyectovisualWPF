Imports System.Data.OleDb
Imports System.Data
Public Class WinSufragio
    Public dbPath As String = "sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Public dsDignidades As DataSet
    Public dsCandidatos As DataSet

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        Using conexion As New OleDbConnection(strConexion)

            Dim consulta As String = "Select * FROM dignidades;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim dignidadCmdBuilder = New OleDbCommandBuilder(adapter)
            dsDignidades = New DataSet("dignidades")
            adapter.FillSchema(dsDignidades, SchemaType.Source)
            adapter.Fill(dsDignidades, "dignidades")
           
        End Using

        For Each row As DataRow In dsDignidades.Tables("dignidades").Rows
            Dim item As New MenuItem()
            item.Header = row.Item(1)
            item.TabIndex = row.Item(0)
            AddHandler item.Click, AddressOf Menu_Item_Clic
            'item.se Title(row.Item(1))

            Me.menu_dignidades.Items.Add(item)
            'MessageBox.Show(row.Item(1))
        Next

    End Sub

    Private Sub Menu_Item_Clic(ByVal sender As Object, ByVal e As EventArgs)
        Dim item_ev As New MenuItem
        item_ev = sender
        'If item_ev.Header = "PRESIDENTE" Then
        'End If
        'MessageBox.Show(item_ev.Header)
        Carga_Candidatos(item_ev.TabIndex)

    End Sub

    Public Sub Carga_Candidatos(dig As Integer)
        Using conexion As New OleDbConnection(strConexion)

            Dim consulta As String = "Select * FROM candidatos where dignidad = " & dig & ";"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim candidatoCmdBuilder = New OleDbCommandBuilder(adapter)
            dsCandidatos = New DataSet("candidatos")
            adapter.FillSchema(dsCandidatos, SchemaType.Source)
            adapter.Fill(dsCandidatos, "candidatos")
        End Using

        For Each row As DataRow In dsCandidatos.Tables("candidatos").Rows
            Dim candid As New CheckBox
            candid.Content = row.Item(4) & " " & row.Item(5)
            wrp_candidatos.Children.Add(candid)
        Next

    End Sub
End Class
