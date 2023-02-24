Imports MySql.Data.MySqlClient
Imports System.IO
Public Class topic
    Dim cmd As MySqlCommand
    Dim con As MySqlConnection
    Dim dr As MySqlDataReader
    Dim cnstr As String = "data source = 172.104.187.153; user = root;password = root; database = alumni_db"
    Sub TOPIC(valueTosearch)
        DataGridView1.Rows.Clear()
        con = New MySqlConnection(cnstr)
        con.Open()
        cmd = New MySqlCommand("select * from  forum_topics WHERE CONCAT (id,title,description,user_id,date_created) Like '%" & valueTosearch & "%'", con)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr.Item("id").ToString, dr.Item("title").ToString, dr.Item("description").ToString, dr.Item("user_id").ToString, dr.Item("date_created").ToString)
        End While
        dr.Close()
        con.Close()

        For i = 0 To DataGridView1.Rows.Count - 1
            Dim r As DataGridViewRow = DataGridView1.Rows(i)
            r.Height = 50

        Next

    End Sub
    Private Sub topic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TOPIC("")
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        DateTimePicker1.Enabled = False
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Button2.Visible = True
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("Column1").Value.ToString()
            TextBox2.Text = row.Cells("Column2").Value.ToString()
            TextBox3.Text = row.Cells("Column3").Value.ToString()
            TextBox4.Text = row.Cells("Column4").Value.ToString()
            DateTimePicker1.Text = row.Cells("Column5").Value.ToString()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            con.Open()
            Dim sql As String = " INSERT INTO forum_topics (id,title,description,user_id,date_created) values (@id,@title,@description,@user_id,@date_created) "
            cmd = New MySqlCommand(sql, con)
            With cmd


                cmd.Parameters.AddWithValue("@id", TextBox1.Text)
                cmd.Parameters.AddWithValue("@title", TextBox2.Text)
                cmd.Parameters.AddWithValue("@description", TextBox3.Text)
                cmd.Parameters.AddWithValue("@user_id", TextBox4.Text)
                cmd.Parameters.AddWithValue("@date_created", DateTimePicker1.Text)



                Dim i As Integer = cmd.ExecuteNonQuery

                If i > 0 Then
                    MsgBox("The Record Was Saved Successfully!")

                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    DateTimePicker1.Refresh()

                    TOPIC("")



                Else
                    MsgBox("FAILED")



                End If

                con.Close()


            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TextBox1.Text = "" Then
            MessageBox.Show("select item")
        Else

            Try
                con = New MySqlConnection(cnstr)
                con.Open()
                Dim sql1 As String = "DELETE FROM forum_topics WHERE id = @id"
                cmd = New MySqlCommand(sql1, con)
                cmd.Parameters.AddWithValue("@id", TextBox1.Text)
                Dim B As Integer = cmd.ExecuteNonQuery
                If B > 0 Then

                    MsgBox("delete")

                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    Button2.Visible = False

                    DateTimePicker1.Refresh()
                    TOPIC("")

                Else
                    MsgBox("FAILED")

                End If
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)


            End Try

        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        TOPIC(TextBox5.Text)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        TOPIC("")

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        DateTimePicker1.Refresh()
        Button2.Visible = False
    End Sub
End Class