Imports System.Data.OleDb
Imports System.Data
Public Class WinSufragio
    Public dbPath As String = "sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Public dsDignidades As DataSet
    Public dsCandidatos As DataSet
    Public dsPartidos As DataSet
    Public partidos As ArrayList

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        partidos = New ArrayList
        'cargar_partidos()
        Cargar_Dignidades()
        Cargar_Partidos()
        Asignar_Paneles()
        Carga_Candidatos()
        'ubicar_listas()
    End Sub

    Private Sub Menu_Item_Clic(ByVal sender As Object, ByVal e As EventArgs)
        Dim item_ev As New MenuItem
        item_ev = sender
        'If item_ev.Header = "PRESIDENTE" Then
        'End If
        'MessageBox.Show(item_ev.Header)
        Carga_CandidatosActuales(item_ev.TabIndex)

    End Sub

    Public Sub Carga_Candidatos()

        For Each partido As Partido_Politico In partidos
            'MessageBox.Show(partido.Siglas)
            partido.Carga_Candidatos(partido.Id)
        Next

    End Sub

    Public Sub Carga_CandidatosActuales(dig As Integer)

        For Each partido As Partido_Politico In partidos
            partido.Asignar_CandidatosActuales(dig)
        Next

    End Sub

 
    Public Sub ubicar_listas()

        'Dim f As Byte = 0
        'Dim c As Byte = 0
        'For Each part As Partido_Politico In partidos
        '    If c = 7 Then
        '        f = +1
        '        c = 0
        '    Else
        '        Dim lab As New Label()
        '        lab.Content = part.Siglas
        '        stk_00.Children.Add(lab)
        '        c = +1
        '    End If
        'Next

        For Each part As Partido_Politico In partidos
            Dim lab As New Label()
            lab.Content = part.Siglas
            CD.Children.Add(lab)
        Next

    End Sub

    Public Sub Asignar_Paneles()

        For Each partido As Partido_Politico In partidos
            Dim lab As New Label()
            lab.Content = partido.Siglas
            Select Case partido.Siglas
                Case "CD"
                    partido.Panel = CD
                Case "PSP3"
                    partido.Panel = PSP3
                Case "MFCS"
                    partido.Panel = MFCS
                Case "PSC"
                    partido.Panel = PSC
                Case "PAEA"
                    partido.Panel = PAEA
                Case "PPA"
                    partido.Panel = PPA
                Case "FE"
                    partido.Panel = FE
                Case "ID"
                    partido.Panel = ID
                Case "CD"
                    partido.Panel = CD
                Case "PSE"
                    partido.Panel = PSE
                Case "MUPP"
                    partido.Panel = MUPP
                Case "UE"
                    partido.Panel = UE
                Case "CREO"
                    partido.Panel = CREO
                Case "SUMA"
                    partido.Panel = SUMA
                Case "PAIS"
                    partido.Panel = PAIS
                Case "MC"
                    partido.Panel = MC
                Case Else
                    partido.Panel = XXX
            End Select
            partido.Panel.Children.Add(lab)
        Next

    End Sub

    Public Sub Cargar_Dignidades()
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
            Me.menu_dignidades.Items.Add(item)
        Next
    End Sub

    Public Sub Cargar_Partidos()

       Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM partidopolitico;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim partidoCmdBuilder = New OleDbCommandBuilder(adapter)
            dsPartidos = New DataSet("partidopolitico")
            adapter.FillSchema(dsPartidos, SchemaType.Source)
            adapter.Fill(dsPartidos, "partidopolitico")
        End Using

        For Each row As DataRow In dsPartidos.Tables("partidopolitico").Rows
            Dim part As Partido_Politico = New Partido_Politico(row.Item(0), row.Item(1), row.Item(2))
            partidos.Add(part)
        Next
    End Sub

End Class
