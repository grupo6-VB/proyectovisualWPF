﻿#ExternalChecksum("..\..\loginAdmin.xaml","{406ea660-64cf-4c82-b6f0-42d48172a799}","1A363A8F965E1E4DE0F16A3E64921B34")
'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports DataGridBaseDatos
Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell


'''<summary>
'''loginAdmin
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class loginAdmin
    Inherits System.Windows.Window
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\loginAdmin.xaml",1)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents win_loginAdmin As loginAdmin
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\loginAdmin.xaml",14)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents txtUser As System.Windows.Controls.TextBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\loginAdmin.xaml",15)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents lbl_user As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\loginAdmin.xaml",16)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents lbl_pass As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\loginAdmin.xaml",17)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents btn_admin As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\loginAdmin.xaml",18)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents pwd_pass As System.Windows.Controls.PasswordBox
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/DataGridBaseDatos;component/loginadmin.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\loginAdmin.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            Me.win_loginAdmin = CType(target,loginAdmin)
            
            #ExternalSource("..\..\loginAdmin.xaml",8)
            AddHandler Me.win_loginAdmin.Closing, New System.ComponentModel.CancelEventHandler(AddressOf Me.Window_Closing)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 2) Then
            Me.txtUser = CType(target,System.Windows.Controls.TextBox)
            Return
        End If
        If (connectionId = 3) Then
            Me.lbl_user = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 4) Then
            Me.lbl_pass = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 5) Then
            Me.btn_admin = CType(target,System.Windows.Controls.Button)
            Return
        End If
        If (connectionId = 6) Then
            Me.pwd_pass = CType(target,System.Windows.Controls.PasswordBox)
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class

