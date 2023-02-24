Public Class Mode
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        RFID.Refresh()

        RFID.Show()

    End Sub

    Private Sub Mode_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class