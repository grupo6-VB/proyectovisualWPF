Public Class WinPersona

    Private Sub btnCerrar_Click(sender As Object, e As RoutedEventArgs) Handles btnCerrar.Click
        Me.Owner.Show()
        Me.Close()
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.Owner.Show()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click
        Dim id = 0
        Try
            id = Me.DataContext.Id()
        Catch ex As Exception

        End Try
        Dim padre As tablaConsulta = CType(Me.Owner, tablaConsulta)
        padre.UpdatePersona(id, txtNombre.Text, txtApellido.Text, txtLugar.Text)
        Me.Close()
    End Sub
End Class
