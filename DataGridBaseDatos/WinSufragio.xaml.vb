Imports System.Data.OleDb
Imports System.Data
Public Class WinSufragio
    Public dbPath As String = "sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Public dsDignidades As DataSet
    Public dsCandidatos As DataSet
    Private partidos As New ArrayList

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        'partidos = New ArrayList
        cargar_partidos()
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
        'ubicar_listas()
    End Sub

    Private Sub Menu_Item_Clic(ByVal sender As Object, ByVal e As EventArgs)
        Dim item_ev As New MenuItem
        item_ev = sender
        'If item_ev.Header = "PRESIDENTE" Then
        'End If
        'MessageBox.Show(item_ev.Header)
        'Carga_Candidatos(item_ev.TabIndex)

    End Sub

    Public Sub Carga_Candidatos(dig As Integer)
        'wrp_candidatos.Children.Clear()
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

            'wrp_candidatos.Children.Add(candid)
        Next

    End Sub

    Private Sub cargar_partidos()
        Dim dsPartidos As DataSet
        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM partidopolitico;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim dignidadCmdBuilder = New OleDbCommandBuilder(adapter)
            dsPartidos = New DataSet("partidos")
            adapter.FillSchema(dsPartidos, SchemaType.Source)
            adapter.Fill(dsPartidos, "partidos")
        End Using

        For Each row As DataRow In dsPartidos.Tables("partidos").Rows
            Dim part As Partido_Politico = New Partido_Politico(row.Item(0), row.Item(1), row.Item(2))
            partidos.Add(part)
        Next
    End Sub

    Public Sub ubicar_listas()
        Dim f As Byte = 0
        Dim c As Byte = 0

        For Each part As Partido_Politico In partidos
            If c = 7 Then
                f = +1
                c = 0
            End If
            Dim lab As Label = New Label().Content(part.Siglas)

        Next

    End Sub
End Class
