Imports System.Data.OleDb
Imports System.Data
Public Class Partido_Politico
    Public dbPath As String = "sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath

    Private _panel As StackPanel
    Public Property Panel() As StackPanel
        Get
            Return _panel
        End Get
        Set(ByVal value As StackPanel)
            _panel = value
        End Set
    End Property

    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _siglas As String
    Public Property Siglas() As String
        Get
            Return _siglas
        End Get
        Set(ByVal value As String)
            _siglas = value
        End Set
    End Property

    'Private _estado As Boolean
    'Public Property Estado() As Boolean
    '    Get
    '        Return _estado
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _estado = value
    '    End Set
    'End Property

    Private _candidatos As ArrayList
    Public Property Candidatos() As ArrayList
        Get
            Return _candidatos
        End Get
        Set(ByVal value As ArrayList)
            _candidatos = value
        End Set
    End Property

    Private _candidatosActuales As ArrayList
    Public Property CandidatosActuales() As ArrayList
        Get
            Return _candidatosActuales
        End Get
        Set(ByVal value As ArrayList)
            _candidatosActuales = value
        End Set
    End Property

    Public Sub New(id As String, nombre As String, siglas As String)
        Me.Id = id
        Me.Nombre = nombre
        Me.Candidatos = New ArrayList()
        Me.CandidatosActuales = New ArrayList()
        Me.Siglas = siglas
        Me.Panel = New StackPanel()
    End Sub

    Public Sub AgregarCandidato(candidato As Candidato)
        Me.Candidatos.Add(candidato)
    End Sub

    Public Sub MostrarCandidatos()
        Console.WriteLine("ESTOS SON LOS CANDIDATOS DE {0}", Me.Nombre)
        For Each candidato As Candidato In Candidatos
            'candidato.MostrarDatosC()
        Next
    End Sub

    Public Sub Carga_Candidatos(partido As Integer)
        Dim dsCandidatos As DataSet

        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM candidatos WHERE partido = " & partido & ";"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim candidatoCmdBuilder = New OleDbCommandBuilder(adapter)
            dsCandidatos = New DataSet("candidatos")
            adapter.FillSchema(dsCandidatos, SchemaType.Source)
            adapter.Fill(dsCandidatos, "candidatos")
            'MessageBox.Show("LEIDO")
        End Using

        For Each row As DataRow In dsCandidatos.Tables("candidatos").Rows
            'MessageBox.Show(row.Item(5))
            Dim candidato As New Candidato()
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
            Candidatos.Add(candidato)
            'MessageBox.Show("añadido")
        Next

    End Sub

    Public Sub Asignar_CandidatosActuales(dignidad As Integer)
        CandidatosActuales.Clear()
        For Each candidato As Candidato In Candidatos
            If candidato.Dignidad = dignidad Then
                CandidatosActuales.Add(candidato)
                'MessageBox.Show(candidato.Nombre)
            End If
        Next

        Panel.Children.Clear()
        For Each candidato As Candidato In CandidatosActuales
            candidato.Seleccion.Content = candidato.Nombre + " " + candidato.Apellido
            Panel.Children.Add(candidato.Seleccion)
        Next
    End Sub

    Public Sub Cambiar_Check(nuevo As CheckBox)
        For Each c As Candidato In Candidatos
            c.Seleccion = nuevo
        Next
    End Sub
End Class
