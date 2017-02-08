Imports System.Data.OleDb
Imports System.Data
Public Class WinSufragio
    Public dbPath As String = "sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Public dsDignidades As DataSet
    Public dsCandidatos As DataSet
    Public dsPartidos As DataSet
    Private dignidades As ArrayList
    Private partidos As ArrayList
    Private contador As Integer
    Private max As Integer
    Private votante As Persona

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        contador = 0
        max = 0
        votante = Me.DataContext
        Me.Title = "BIENVENIDO ---> " & votante.Nombre & "  " & votante.Apellido
        'MessageBox.Show(votante.Nombre)
        dignidades = New ArrayList
        partidos = New ArrayList
        Cargar_Dignidades()
        Cargar_Partidos()
        Asignar_Paneles()
        Carga_Candidatos()

    End Sub

    Private Sub Menu_Item_Clic(ByVal sender As Object, ByVal e As EventArgs)
        Dim item_ev As New MenuItem
        item_ev = sender
        Carga_CandidatosActuales(item_ev.TabIndex)
        For Each d As Dignidad In dignidades
            If d.Id = item_ev.TabIndex Then
                max = d.CantElegir
            End If
        Next
        lbl_mensaje.Content = "SELECCIONAR  " & max & "  CANDIDATO(S)"
    End Sub

    Private Sub Seleccion_Candidato(ByVal sender As Object, ByVal e As EventArgs)
        Dim seleccion As New CheckBox
        seleccion = sender
        If seleccion.IsChecked Then
            MessageBox.Show("MAYOR")
            contador = +1
            lbl_mensaje.Content = "Seleccionados : " & contador
        End If
    End Sub

    Public Sub Carga_Candidatos()
        'Dim seleccion As New CheckBox
        'AddHandler seleccion.Checked, AddressOf Seleccion_Candidato
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
            Dim dignidad As Dignidad = New Dignidad(row.Item(1), row.Item(0), row.Item(2))
            dignidades.Add(dignidad)
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


    Private Sub btn_procesar_Click(sender As Object, e As RoutedEventArgs) Handles btn_procesar.Click
        For Each partido As Partido_Politico In partidos
            For Each cand As Candidato In partido.CandidatosActuales
                If cand.Seleccion.IsChecked Then
                    contador += 1
                End If
            Next
        Next

        If contador = max Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult
            msg = "¿DESEA PROCESAR SU ELECCION?"
            style = MsgBoxStyle.DefaultButton2 Or _
               MsgBoxStyle.OkOnly Or MsgBoxStyle.YesNo
            title = ""  
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Yes Then
                Proceso_Guardado()
                contador = 0
            Else
                contador = 0
                Exit Sub
            End If
        ElseIf contador < max Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult
            msg = "¿DESEA PROCESAR SU ELECCION?"
            style = MsgBoxStyle.DefaultButton2 Or _
               MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo
            title = "FALTAN CANDIDATOS POR ELEGIR"
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Yes Then
                Proceso_Guardado()
                contador = 0
            Else
                contador = 0
                Exit Sub
            End If
        Else
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult
            msg = "LIMITE DE SELECCION EXCEDIDO"
            style = MsgBoxStyle.DefaultButton2 Or _
               MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly
            title = "ERROR"
            response = MsgBox(msg, style, title)
            contador = 0
            Exit Sub
        End If

        MessageBox.Show("CANDIDATOS SELECCIONADOS: " & contador)
    End Sub

    Public Sub Proceso_Guardado()
        For Each p As Partido_Politico In partidos
            For Each c As Candidato In p.CandidatosActuales
                If c.Seleccion.IsEnabled Then
                    If c.Seleccion.IsChecked Then
                        c.Votos += 1
                        MessageBox.Show(c.Id & "     " & c.Votos)
                        dsCandidatos = New DataSet
                        Using conexion As New OleDbConnection(strConexion)
                            Dim sentencia As String
                            Dim Adapter As New OleDbDataAdapter
                            Dim actualizacion = New OleDbCommandBuilder(Adapter)
                            sentencia = "UPDATE candidatos SET votos = " & c.Votos & " WHERE idusuario = " & c.Id & ";"
                            Adapter = New OleDbDataAdapter(New OleDbCommand(sentencia, conexion))
                            Adapter.Fill(dsCandidatos, "candidatos")
                            Try
                                Adapter.Update(dsCandidatos.Tables("candidatos"))
                                'MessageBox.Show("MODIFICADO CON EXITO")
                            Catch ex As Exception
                                'MessageBox.Show("ERROR AL MODIFICAR")
                            End Try
                        End Using
                    End If
                    c.Seleccion.IsEnabled = False
                End If
            Next
        Next

    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim padre As New WinElecciones
        padre.Show()
        Try
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub
End Class
