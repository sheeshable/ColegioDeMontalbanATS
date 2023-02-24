Imports MySql.Data.MySqlClient
Public Class Form1
    Dim cmd As MySqlCommand
    Dim con As MySqlConnection
    Dim cnstr As String = "data source = 172.104.187.153; user = root;password = root; database = alumni_db"
    Dim sql As String
    Dim dr As MySqlDataReader

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Hide()
        Mode.Show()

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        CreateAccount.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            con = New MySqlConnection(cnstr)
            con.Open()
            sql = "SELECT * FROM admin where UserName='" & TextBox1.Text & "' and Pin = '" & TextBox2.Text & "' "
            cmd = New MySqlCommand(sql, con)
            dr = cmd.ExecuteReader

            Dim a As Integer
            a = 0
            While dr.Read
                a = a + 1
            End While

            If a = 1 Then
                MessageBox.Show("UserName and Pin is Correct!")


                Me.Hide()
                Dashboard.Show()



            ElseIf a < 1 Then

                MessageBox.Show("TRY AGAIN")
            End If


            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
