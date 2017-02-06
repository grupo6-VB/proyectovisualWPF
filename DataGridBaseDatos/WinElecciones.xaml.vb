Public Class WinElecciones
    Private Sub btn_Consultar_Click(sender As Object, e As RoutedEventArgs) Handles btn_Consultar.Click


        Dim userlog As New userLogin()
        userlog.Owner = Me
        userlog.Show()

    End Sub

    Private Sub btn_Administrador_Click(sender As Object, e As RoutedEventArgs) Handles btn_Administrador.Click


        Dim admlog As New loginAdmin()
        admlog.Owner = Me
        admlog.Show()

    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As RoutedEventArgs) Handles btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub btn_Sufragar_Click(sender As Object, e As RoutedEventArgs) Handles btn_Sufragar.Click
        Dim winSuf As New WinSufragio()
        winSuf.Owner = Me
        winSuf.Show()
    End Sub
End Class
