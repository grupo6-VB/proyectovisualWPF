Imports System.Xml
Imports System.Data.OleDb
Imports System.Data
Public Class Persona
    Public dbPath As String = "sample.mdb"
    Public strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Public _cedula As String
    Public Property Cedula() As String
        Get
            Return _cedula
        End Get
        Set(ByVal value As String)
            _cedula = value
        End Set
    End Property

    Public _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Public _apellido As String
    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Public _estadoSufragio As Boolean 'Para saber si la persona ya sufragó o no
    Public Property EstadoSufragio() As Boolean
        Get
            Return _estadoSufragio
        End Get
        Set(ByVal value As Boolean)
            _estadoSufragio = value
        End Set
    End Property

    Public Sub New()
        Me.Cedula = ""
        Me.Nombre = ""
        Me.Apellido = ""
        Me.EstadoSufragio = False
    End Sub

    Public Sub New(cedula As String)
        Me.Cedula = cedula
        Me.Nombre = ""
        Me.Apellido = ""
        Me.EstadoSufragio = False
    End Sub

    Sub New(id As Integer, nombre As String, apellido As String, lugar As String, estado As String)
        '_id = id
        _nombre = nombre
        _apellido = apellido
        '_lugar = lugar
    End Sub

    Sub New(cedula As String, nombre As String, apellido As String)
        _cedula = cedula
        _nombre = nombre
        _apellido = apellido
        '   _lugar = lugar
    End Sub



    Public Sub MostrarDatos()
        Console.WriteLine(Me.Cedula & vbTab & Me.Nombre & vbTab & Me.Apellido)
    End Sub

    Public Sub GuardarEstadoSufragio(cedula As String)
        Dim path As String = "DATOS.xml"
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(path)
        Dim lista_votantes As XmlNodeList = xmlDoc.GetElementsByTagName("votante")
        For Each votante As XmlNode In lista_votantes
            'Console.WriteLine(votante.Name)
            If votante.Attributes("cedula").Value = cedula Then
                For Each nodo As XmlNode In votante
                    If nodo.Name = "estadoSufragio" Then
                        Dim n As XmlNode = xmlDoc.CreateElement("estadoSufragio")
                        n.InnerText = "TRUE"
                        votante.RemoveChild(nodo)
                        votante.AppendChild(n)
                        xmlDoc.Save(path)
                        Exit For
                    End If
                Next
            End If
        Next
    End Sub

End Class
