Imports MySql.Data.MySqlClient
Public Class Update1
    Dim cmd As MySqlCommand
    Dim con As MySqlConnection
    Dim cnstr As String = "data source = 172.104.187.153; user = root;password = root; database = alumni_db"



    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Update_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            con = New MySqlConnection(cnstr)
            con.Open()
            Dim sql As String = "UPDATE Unverified SET Name=@Name, Age=@Age, Contact=@Contact, Email=@Email, Coursen=@Course Where IDNo = @IDNo"
            cmd = New MySqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@IDNo", TextBox1.Text)
            cmd.Parameters.AddWithValue("@Name", TextBox4.Text)
            cmd.Parameters.AddWithValue("@Age", TextBox5.Text)
            cmd.Parameters.AddWithValue("@Contact", TextBox7.Text)
            cmd.Parameters.AddWithValue("@Email", TextBox2.Text)
            cmd.Parameters.AddWithValue("@Course", TextBox3.Text)


            Dim i As Integer = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Update Successful")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox7.Clear()








            Else
                MsgBox("FAILED")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class