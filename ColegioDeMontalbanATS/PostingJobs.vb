Imports MySql.Data.MySqlClient
Imports System.IO
Public Class PostingJobs
    Dim cmd As MySqlCommand
    Dim con As MySqlConnection
    Dim dr As MySqlDataReader
    Dim cnstr As String = "data source = 172.104.187.153; user = root;password = root; database = alumni_db"
    Dim imgpath As String
    Dim arrImage() As Byte




    Sub Postingjobs(valueTosearch)
        DataGridView1.Rows.Clear()
        con = New MySqlConnection(cnstr)
        con.Open()
        cmd = New MySqlCommand("select * from  careers WHERE CONCAT (id,company,location,job_title,description,user_id,date_created) Like '%" & valueTosearch & "%'", con)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr.Item("id").ToString, dr.Item("company").ToString, dr.Item("location").ToString, dr.Item("job_title").ToString, dr.Item("description").ToString, dr.Item("user_id").ToString, dr.Item("date_created").ToString)
        End While
        dr.Close()
        con.Close()

        For i = 0 To DataGridView1.Rows.Count - 1
            Dim r As DataGridViewRow = DataGridView1.Rows(i)
            r.Height = 50

        Next

    End Sub


    Sub PostingEvents(valueTosearch)
        DataGridView2.Rows.Clear()
        con = New MySqlConnection(cnstr)
        con.Open()
        cmd = New MySqlCommand("select id,title,content,schedule from  events WHERE CONCAT (id,title,content,schedule) Like '%" & valueTosearch & "%'", con)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView2.Rows.Add(dr.Item("id").ToString, dr.Item("title").ToString, dr.Item("content").ToString, dr.Item("schedule").ToString)
        End While
        dr.Close()
        con.Close()

        For i = 0 To DataGridView2.Rows.Count - 1
            Dim r As DataGridViewRow = DataGridView2.Rows(i)
            r.Height = 50

        Next

    End Sub
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub PostingJobs_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        TextBox6.Text = 1


        Postingjobs("")
        PostingEvents("")
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        DateTimePicker1.Enabled = False
        TextBox10.Enabled = False
        TextBox11.Enabled = False
        TextBox12.Enabled = False
        DateTimePicker2.Enabled = False
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click

        GSM.Show()
        Try
            con.Open()
            Dim sql As String = " INSERT INTO careers ( id,company,location,job_title,description,user_id,date_created) values (@id,@company,@location,@job_title,@description,@user_id,@date_created) "
            cmd = New MySqlCommand(sql, con)
            With cmd


                cmd.Parameters.AddWithValue("@id", TextBox1.Text)
                cmd.Parameters.AddWithValue("@company", TextBox2.Text)
                cmd.Parameters.AddWithValue("@location", TextBox3.Text)
                cmd.Parameters.AddWithValue("@job_title", TextBox4.Text)
                cmd.Parameters.AddWithValue("@description", TextBox5.Text)
                cmd.Parameters.AddWithValue("@user_id", TextBox6.Text)
                cmd.Parameters.AddWithValue("@date_created", DateTimePicker1.Text)

                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    MsgBox("The Record Was Saved Successfully!")

                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()
                    TextBox6.Clear()
                    DateTimePicker1.Refresh()
                    Postingjobs("")
                    TextBox1.Enabled = False
                    TextBox2.Enabled = False
                    TextBox3.Enabled = False
                    TextBox4.Enabled = False
                    TextBox5.Enabled = False
                    TextBox6.Enabled = False
                    DateTimePicker1.Enabled = False

                    Button10.Visible = True
                    Button11.Visible = False
                Else
                    MsgBox("FAILED")



                End If




            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Postingjobs("")
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        DateTimePicker1.Refresh()
        TextBox8.Clear()

        Button3.Visible = False
        Button11.Visible = False

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        Postingjobs(TextBox8.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("select item")
        Else

            Try
                con = New MySqlConnection(cnstr)
                con.Open()
                Dim sql1 As String = "DELETE FROM careers WHERE id = @id"
                cmd = New MySqlCommand(sql1, con)
                cmd.Parameters.AddWithValue("@id", TextBox1.Text)
                Dim B As Integer = cmd.ExecuteNonQuery
                If B > 0 Then

                    MsgBox("delete")

                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()
                    TextBox6.Clear()
                    DateTimePicker2.Refresh()
                    Postingjobs("")
                    Button11.Visible = False
                    Button3.Visible = False
                Else
                    MsgBox("FAILED")

                End If
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)


            End Try

        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Button11.Visible = True
        Button3.Visible = True
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("Column1").Value.ToString()
            TextBox2.Text = row.Cells("Column2").Value.ToString()
            TextBox3.Text = row.Cells("Column3").Value.ToString()
            TextBox4.Text = row.Cells("Column4").Value.ToString()
            TextBox5.Text = row.Cells("Column5").Value.ToString()

            TextBox6.Text = row.Cells("Column6").Value.ToString()

            DateTimePicker1.Text = row.Cells("Column7").Value.ToString()

        End If
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Button5.Visible = True
        Button8.Visible = True

        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            TextBox10.Text = row.Cells("Column8").Value.ToString()
            TextBox11.Text = row.Cells("Column9").Value.ToString()
            TextBox12.Text = row.Cells("Column10").Value.ToString()
            DateTimePicker2.Text = row.Cells("Column11").Value.ToString()


        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        GSM.Show()
        Try

            con.Open()
            Dim sql As String = " INSERT INTO events (id,title,content,schedule) values (@id,@title,@content,@schedule) "
            cmd = New MySqlCommand(sql, con)
            With cmd


                cmd.Parameters.AddWithValue("@id", TextBox10.Text)
                cmd.Parameters.AddWithValue("@title", TextBox11.Text)
                cmd.Parameters.AddWithValue("@content", TextBox12.Text)
                cmd.Parameters.AddWithValue("@schedule", DateTimePicker2.Text)



                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    MsgBox("The Record Was Saved Successfully!")

                    TextBox10.Clear()
                    TextBox11.Clear()
                    TextBox12.Clear()
                    DateTimePicker2.Refresh()

                    PostingEvents("")

                    TextBox10.Enabled = False
                    TextBox11.Enabled = False
                    TextBox12.Enabled = False
                    DateTimePicker2.Enabled = False
                    Button13.Visible = True
                    Button8.Visible = False
                Else
                    MsgBox("FAILED")



                End If

                con.Close()


            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try







        con = New MySqlConnection(cnstr)
        con.Open()
        Dim sql1 As String = "Select banner from events where id"
        cmd = New MySqlCommand(sql1, con)
        cmd.Parameters.AddWithValue("@id", TextBox10.Text)

        Using dr As MySqlDataReader = cmd.ExecuteReader()
            While dr.Read()

                Dim a() As Byte = DirectCast(dr("banner"), Byte())

                Using fs As New FileStream("C:\xampp\htdocs\alumnifinal\admin\assets\uploads\image.jpg", FileMode.Create)
                    fs.Write(a, 0, a.Length)

                End Using

            End While
        End Using
        con.Close()





    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox10.Text = "" Then
            MessageBox.Show("select item")
        Else

            Try
                con = New MySqlConnection(cnstr)
                con.Open()
                Dim sql1 As String = "DELETE FROM events WHERE id = @id"
                cmd = New MySqlCommand(sql1, con)
                cmd.Parameters.AddWithValue("@id", TextBox10.Text)
                Dim B As Integer = cmd.ExecuteNonQuery
                If B > 0 Then

                    MsgBox("delete")

                    TextBox10.Clear()
                    TextBox11.Clear()
                    TextBox12.Clear()
                    DateTimePicker2.Refresh()
                    Button8.Visible = False
                    Button5.Visible = False
                    PostingEvents("")

                Else
                    MsgBox("FAILED")

                End If
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)


            End Try

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PostingEvents("")
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        DateTimePicker2.Refresh()
        Button13.Visible = True
        Button5.Visible = False
        Button8.Visible = False

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        PostingEvents(TextBox9.Text)

    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        Try
            Dim OFD As FileDialog = New OpenFileDialog()

            OFD.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif"

            If OFD.ShowDialog() = DialogResult.OK Then
                imgpath = OFD.FileName




            End If

            OFD = Nothing

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub



    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Button3.Visible = False
        Button11.Visible = False
        Button10.Visible = True
        Button12.Visible = True
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        DateTimePicker1.Refresh()
        TextBox8.Clear()





        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        DateTimePicker1.Enabled = False
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Button5.Visible = False
        Button8.Visible = False
        Button13.Visible = True
        Button14.Visible = True

        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        DateTimePicker2.Refresh()


        TextBox10.Enabled = False
        TextBox11.Enabled = False
        TextBox12.Enabled = False
        DateTimePicker2.Enabled = False
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            con = New MySqlConnection(cnstr)
            con.Open()
            Dim sql As String = "UPDATE careers SET company=@company,location=@location,job_title=@job_title,description=@description,user_id=@user_id,date_created=@date_created Where id=@id"
            cmd = New MySqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@id", TextBox1.Text)
            cmd.Parameters.AddWithValue("@company", TextBox2.Text)
            cmd.Parameters.AddWithValue("@location", TextBox3.Text)
            cmd.Parameters.AddWithValue("@job_title", TextBox4.Text)
            cmd.Parameters.AddWithValue("@description", TextBox5.Text)
            cmd.Parameters.AddWithValue("@user_id", TextBox6.Text)
            cmd.Parameters.AddWithValue("@date_created", DateTimePicker1.Text)

            Dim B As Integer = cmd.ExecuteNonQuery
            If B > 0 Then
                MsgBox("The Record Was Updated Successfully!")
                Button3.Visible = False
                Button11.Visible = False
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                DateTimePicker1.Refresh()
                TextBox8.Clear()

                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                TextBox6.Enabled = False
                DateTimePicker1.Enabled = False


                Button7.Visible = False
                Button12.Visible = True


            Else
                MsgBox("The Record Cannot Be Updated!")

            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)


        End Try




    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click


        Try
            con = New MySqlConnection(cnstr)
            con.Open()
            Dim sql As String = "UPDATE events SET title=@title,content=@content,schedule=@schedule Where id=@id"
            cmd = New MySqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@id", TextBox10.Text)
            cmd.Parameters.AddWithValue("@title", TextBox11.Text)
            cmd.Parameters.AddWithValue("@content", TextBox12.Text)
            cmd.Parameters.AddWithValue("@schedule", DateTimePicker2.Text)



            Dim B As Integer = cmd.ExecuteNonQuery
            If B > 0 Then
                MsgBox("The Record Was Updated Successfully!")
                TextBox10.Clear()
                TextBox11.Clear()
                TextBox12.Clear()

                DateTimePicker2.Refresh()
                TextBox10.Enabled = False
                TextBox11.Enabled = False
                TextBox12.Enabled = False
                DateTimePicker2.Enabled = False
                Button14.Visible = True
                Button9.Visible = False
            Else
                MsgBox("The Record Cannot Be Updated!")

            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        button1.Visible = True
        Button10.Visible = False
        Button11.Visible = True
        TextBox1.Enabled = False
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = False
        DateTimePicker1.Enabled = True


        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Text=1
        DateTimePicker1.Refresh()
        TextBox8.Clear()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Button7.Visible = True
        Button12.Visible = False
        Button3.Visible = True
        Button11.Visible = True

        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        DateTimePicker1.Enabled = True
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        TextBox10.Enabled = False
        TextBox11.Enabled = True
        TextBox12.Enabled = True
        DateTimePicker2.Enabled = True
        Button6.Visible = True
        Button13.Visible = False
        Button5.Visible = False
        Button8.Visible = True
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click

        TextBox10.Enabled = False
        TextBox11.Enabled = True
        TextBox12.Enabled = True
        DateTimePicker2.Enabled = True
        Button14.Visible = False
        Button9.Visible = True
        Button5.Visible = False
        Button8.Visible = True
    End Sub
End Class