Imports System.Xml
Imports System.Data.OleDb
Imports System.Data
Public Class Persona
    Private _cedula As String
    Public Property Cedula() As String
        Get
            Return _cedula
        End Get
        Set(ByVal value As String)
            _cedula = value
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

    Private _apellido As String
    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Private _estadoSufragio As Boolean 'Para saber si la persona ya sufragó o no
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

    Sub New(nombre As String, apellido As String, lugar As String)
        _nombre = nombre
        _apellido = apellido
        '   _lugar = lugar
    End Sub

    Public Sub MostrarDatos()
        Console.WriteLine(Me.Cedula & vbTab & Me.Nombre & vbTab & Me.Apellido)
    End Sub

    Public Sub GuardarEstadoSufragio(tipo As String, cedula As String)
        Dim dsPersonas As DataSet = New DataSet
        Using conexion As New OleDbConnection(DatosPublicos.cd_conexion)
            Dim sentencia As String
            Dim Adapter As New OleDbDataAdapter
            Dim actualizacion = New OleDbCommandBuilder(Adapter)
            sentencia = "UPDATE " & tipo & " SET estadosufragio = 'TRUE' WHERE cedula = '" & cedula & "';"
            Adapter = New OleDbDataAdapter(New OleDbCommand(sentencia, conexion))
            Adapter.Fill(dsPersonas, "votantes")
            Try
                Adapter.Update(dsPersonas.Tables("votantes"))
                'MessageBox.Show("MODIFICADO CON EXITO")
            Catch ex As Exception
                'MessageBox.Show("ERROR AL MODIFICAR")
            End Try
        End Using
    End Sub

End Class
