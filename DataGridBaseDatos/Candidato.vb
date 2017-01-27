﻿Public Class Candidato
    Inherits Persona

    Private _seleccion As Boolean
    Public Property Seleccion() As Boolean
        Get
            Return _seleccion
        End Get
        Set(ByVal value As Boolean)
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

    Private _cargo As String 'dignidad a la que aspira ejem: PRESIDENTE, ASAMBLEISTA, ETC
    Public Property Cargo() As String
        Get
            Return _cargo
        End Get
        Set(ByVal value As String)
            _cargo = value
        End Set
    End Property

    Private _partido As String 'nombre del partido politico en el que milita
    Public Property Partido() As String
        Get
            Return _partido
        End Get
        Set(ByVal value As String)
            _partido = value
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

    Public Sub New(id As String, cargo As String)
        Me.Id = id
        Me.Cargo = cargo
    End Sub

    Public Sub MostrarDatosC()
        Console.Write(Me.Nombre)
        If Me.Nombre.Length <= 4 Then
            Console.Write(vbTab & vbTab)
        Else
            Console.Write(vbTab)
        End If
        Console.Write(Me.Apellido)
        If Me.Apellido.Length <= 5 Then
            Console.Write(vbTab & vbTab)
        Else
            Console.Write(vbTab)
        End If
        Console.Write(Me.Cargo)

        'Console.Write(Me.Nombre & vbTab & Me.Apellido & vbTab & Me.Cargo)
    End Sub

    Public Sub MostrarDatos_D()
        If Seleccion Then
            Console.ForegroundColor = ConsoleColor.Yellow
        Else
            Console.ForegroundColor = ConsoleColor.White
        End If
        Console.Write(Me.Nombre)
        If Me.Nombre.Length <= 3 Then
            Console.Write(vbTab & vbTab)
        Else
            Console.Write(vbTab)
        End If
        Console.Write(Me.Apellido)
        If Me.Apellido.Length <= 7 Then
            Console.Write(vbTab & vbTab)
        Else
            Console.Write(vbTab)
        End If
        Console.WriteLine("(" & Me.Partido & ")")
        Console.ForegroundColor = ConsoleColor.White
        'Console.Write(Me.Nombre & vbTab & Me.Apellido & vbTab & Me.Cargo)
    End Sub

End Class
