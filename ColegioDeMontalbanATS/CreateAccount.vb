Imports MySql.Data.MySqlClient
Public Class CreateAccount
    Dim cmd As MySqlCommand
    Dim con As MySqlConnection
    Dim cnstr As String = "data source = 172.104.187.153; user = root;password = root; database = alumni_db"

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub CreateAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rm As Integer
        Randomize()

        rm = Int(Rnd() * 8556) * 3
        TextBox1.Text = "adm-" & rm
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Birthday As String
        Birthday = ComboBox2.Text + " " + ComboBox3.Text + " ," + ComboBox4.Text

        If Val(TextBox5.Text) >= 110 Then
            MessageBox.Show("select appropriate age")
        ElseIf Val(TextBox5.Text) <= 18 Then
            MessageBox.Show("select appropriate age")

        Else
            If TextBox7.TextLength = 10 Then
                Try
                    con = New MySqlConnection(cnstr)
                    con.Open()
                    Dim sql As String = "insert into admin (AdminNo, FullName, Age, Birthday, Sex, Contact, Username,Pin) values(@AdminNo, @FullName, @Age, @Birthday, @Sex, @Contact, @Username, @Pin)"
                    cmd = New MySqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@AdminNo", TextBox1.Text)
                    cmd.Parameters.AddWithValue("@FullName", TextBox4.Text)
                    cmd.Parameters.AddWithValue("@Age", TextBox5.Text)
                    cmd.Parameters.AddWithValue("@Birthday", Birthday)
                    cmd.Parameters.AddWithValue("@Sex", ComboBox1.Text)
                    cmd.Parameters.AddWithValue("@Contact", TextBox7.Text)
                    cmd.Parameters.AddWithValue("@Username", TextBox2.Text)

                    cmd.Parameters.AddWithValue("@PIN", TextBox9.Text)



                    Dim i As Integer = cmd.ExecuteNonQuery
                    If i > 0 Then
                        MsgBox("Create Successful")
                        TextBox1.Clear()
                        TextBox4.Clear()
                        TextBox5.Clear()
                        ComboBox2.ResetText()
                        ComboBox3.ResetText()
                        ComboBox4.ResetText()
                        ComboBox1.ResetText()
                        TextBox7.Clear()
                        TextBox2.Clear()

                        Me.Hide()
                        Form1.Show()







                    Else
                        MsgBox("FAILED")

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try

            Else
                MessageBox.Show("re-enter contact number")
            End If





        End If




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.Show()

    End Sub

End Class