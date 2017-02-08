Public Class Candidato
    Inherits Persona
    Public dbPath As String = "sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Private _seleccion As CheckBox
    Public Property Seleccion() As CheckBox
        Get
            Return _seleccion
        End Get
        Set(ByVal value As CheckBox)
            _seleccion = value
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

    Private _dignidad As Integer 'dignidad a la que aspira ejem: PRESIDENTE, ASAMBLEISTA, ETC
    Public Property Dignidad() As Integer
        Get
            Return _dignidad
        End Get
        Set(ByVal value As Integer)
            _dignidad = value
        End Set
    End Property

    Private _partido As Integer 'nombre del partido politico en el que milita
    Public Property Partido() As Integer
        Get
            Return _partido
        End Get
        Set(ByVal value As Integer)
            _partido = value
        End Set
    End Property

    Private _user As String 'clave para acceder a las consultas en linea
    Public Property User() As String
        Get
            Return _user
        End Get
        Set(ByVal value As String)
            _user = value
        End Set
    End Property

    Private _pass As String 'clave para acceder a las consultas en linea
    Public Property Pass() As String
        Get
            Return _pass
        End Get
        Set(ByVal value As String)
            _pass = value
        End Set
    End Property

    Private _votos As Integer 'La cantidad de votos que va acumulando por parte de los votantes
    Public Property Votos() As Integer
        Get
            Return _votos
        End Get
        Set(ByVal value As Integer)
            _votos = value
        End Set
    End Property

    Public Sub New(id As Integer, dignidad As Integer)
        Me.Id = id
        Me.Dignidad = dignidad
    End Sub

    Public Sub New()
        Me.Seleccion = New CheckBox
        AddHandler Seleccion.Checked, AddressOf Seleccion_Candidato
    End Sub



    'Private Function Seleccion_Candidato(ByVal sender As Object, ByVal e As EventArgs) As Boolean

    '    If Seleccion.IsChecked Then

    '        Return True
    '    End If
    '    Return False
    'End Function

    Private Sub Seleccion_Candidato(ByVal sender As Object, ByVal e As EventArgs)

        If Seleccion.IsChecked Then
            'MessageBox.Show("CANDIDATO SELECCIONADO")

        End If

    End Sub
End Class
