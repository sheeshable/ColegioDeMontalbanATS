Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Imaging
Public Class Dashboard

    Dim cmd As MySqlCommand
    Dim con As MySqlConnection
    Dim cnstr As String = "data source = 172.104.187.153; user = root;password = root; database = alumni_db"
    Dim da As MySqlDataAdapter
    Dim dset As DataSet
    Dim dr As MySqlDataReader
    Dim itemcoll(999) As String
    Dim result As Integer
    Dim imgpath As String
    Dim arrImage() As Byte
    Dim sql As String








    Sub Masterlist(valueTosearch)
        DataGridView1.Rows.Clear()
        con = New MySqlConnection(cnstr)
        con.Open()
        cmd = New MySqlCommand("select * from  masterlist WHERE CONCAT (idno,fullname,course,batch) Like '%" & valueTosearch & "%'", con)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr.Item("idno").ToString, dr.Item("fullname").ToString, dr.Item("course").ToString, dr.Item("batch").ToString, dr.Item("img"))
        End While
        dr.Close()
        con.Close()

        For i = 0 To DataGridView1.Rows.Count - 1
            Dim r As DataGridViewRow = DataGridView1.Rows(i)
            r.Height = 100

        Next
        Dim imagecolumn = DirectCast(DataGridView1.Columns("Column5"), DataGridViewImageColumn)
        imagecolumn.ImageLayout = DataGridViewImageCellLayout.Stretch


    End Sub




    Sub Unverified(valueTosearch)
        DataGridView3.Rows.Clear()
        con = New MySqlConnection(cnstr)
        con.Open()
        cmd = New MySqlCommand("select * from alumnus_bio  WHERE CONCAT (id,firstname,middlename,lastname,batch,course) Like '%" & valueTosearch & "%'", con)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView3.Rows.Add(dr.Item("id").ToString, dr.Item("firstname").ToString, dr.Item("middlename").ToString, dr.Item("lastname").ToString, dr.Item("gender").ToString, dr.Item("batch").ToString, dr.Item("email").ToString, dr.Item("course").ToString, dr.Item("contact").ToString, dr.Item("idno").ToString, dr.Item("section").ToString, dr.Item("status1").ToString, dr.Item("status").ToString)
        End While
        dr.Close()
        con.Close()



    End Sub



    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Unverified("")
        Masterlist("")


        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox8.Enabled = False
        TextBox9.Enabled = False
        TextBox10.Enabled = False
        TextBox13.Enabled = False
        TextBox14.Enabled = False
        TextBox15.Enabled = False
        TextBox16.Enabled = False
        TextBox17.Enabled = False
        TextBox18.Enabled = False
        TextBox19.Enabled = False

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Unverified(TextBox2.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Unverified("")
        TextBox2.Clear()

        Button17.Visible = False
        Button14.Visible = False
        Button7.Visible = False

        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox17.Clear()
        TextBox18.Clear()
        TextBox19.Clear()





    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick
        Button7.Visible = True
        Button14.Visible = True
        Button17.Visible = True

        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView3.Rows(e.RowIndex)
            TextBox3.Text = row.Cells("Column6").Value.ToString()
            TextBox4.Text = row.Cells("Column7").Value.ToString()
            TextBox5.Text = row.Cells("Column8").Value.ToString()
            TextBox8.Text = row.Cells("Column9").Value.ToString()
            TextBox9.Text = row.Cells("Column10").Value.ToString()

            TextBox10.Text = row.Cells("Column11").Value.ToString()

            TextBox13.Text = row.Cells("Column13").Value.ToString()
            TextBox14.Text = row.Cells("Column12").Value.ToString()
            TextBox15.Text = row.Cells("Column14").Value.ToString()



            TextBox17.Text = row.Cells("Column16").Value.ToString()
            TextBox18.Text = row.Cells("Column17").Value.ToString()
            TextBox19.Text = row.Cells("Column18").Value.ToString()
            TextBox16.Text = row.Cells("Column19").Value.ToString()
        End If




    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Button3.Visible = True
        Button11.Visible = True
        Dim selectedrowindex As Integer
        selectedrowindex = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = DataGridView1.Rows(selectedrowindex)


        TextBox12.Text = selectedrow.Cells(0).Value.ToString()
        TextBox11.Text = selectedrow.Cells(1).Value.ToString()
        TextBox6.Text = selectedrow.Cells(2).Value.ToString()
        TextBox7.Text = selectedrow.Cells(3).Value.ToString()


        If e.RowIndex >= 0 AndAlso e.ColumnIndex = 0 Then
            Dim data As Byte() = CType(DataGridView1.Rows(e.RowIndex).Cells(4).Value, Byte())
            Dim ms As New MemoryStream(data)
            PictureBox1.Image = Image.FromStream(ms)


            Dim originalImage As Image = PictureBox1.Image
            Dim newSize As New Size(217, 177)
            Dim resizedImage As Image = originalImage.GetThumbnailImage(newSize.Width, newSize.Height, Nothing, IntPtr.Zero)
            PictureBox1.Image = resizedImage



        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

        TextBox3.Clear()
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs)


        If TextBox5.Text = "" Then
            MessageBox.Show("select item")
        Else
            ViewVerfied.Show()
        End If


    End Sub





    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Masterlist("")

        TextBox12.Clear()
        TextBox11.Clear()
        TextBox6.Clear()
        TextBox7.Clear()

        Label13.ResetText()
        PictureBox1.Image = Nothing


        TextBox1.Clear()
        ComboBox1.ResetText()

        ComboBox3.ResetText()
        Button11.Visible = False
        Button3.Visible = False
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Masterlist(TextBox1.Text)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Masterlist(ComboBox1.Text)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            If MsgBox("are you sure you want to save this record?", vbYesNo + vbQuestion) = vbYes Then



                Dim mstream As New System.IO.MemoryStream()
                PictureBox1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
                arrImage = mstream.GetBuffer()
                Dim FileSize As UInt32
                FileSize = mstream.Length


                mstream.Close()



                con.Open()
                Dim sql As String = " INSERT INTO masterlist (idno, fullname, course, batch, img) values (@idnumber, @fullname,  @course, @batch, @img) "
                cmd = New MySqlCommand(sql, con)
                With cmd


                    cmd.Parameters.AddWithValue("@idnumber", TextBox12.Text)
                    cmd.Parameters.AddWithValue("@fullname", TextBox11.Text)
                    cmd.Parameters.AddWithValue("@course", ComboBox4.Text)
                    cmd.Parameters.AddWithValue("@batch", ComboBox5.Text)
                    cmd.Parameters.AddWithValue("@img", arrImage)

                    Dim i As Integer = cmd.ExecuteNonQuery
                    If i > 0 Then
                        TextBox12.Clear()
                        TextBox11.Clear()
                        TextBox6.Clear()
                        TextBox7.Clear()
                        ComboBox4.ResetText()
                        ComboBox5.ResetText()
                        Label13.ResetText()
                        PictureBox1.Image = Nothing


                        TextBox6.Visible = True
                        TextBox7.Visible = True
                        Button10.Visible = True
                        Button9.Visible = False
                        Button11.Visible = False

                        Button3.Enabled = True
                        TextBox12.Enabled = False
                        TextBox11.Enabled = False


                    Else
                        MsgBox("FAILED")

                    End If
                End With

                MsgBox("Record has been succesfully saved.", vbInformation)




            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)


        End Try

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            Dim OFD As FileDialog = New OpenFileDialog()

            OFD.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif"

            If OFD.ShowDialog() = DialogResult.OK Then
                imgpath = OFD.FileName
                PictureBox1.ImageLocation = imgpath







            End If

            OFD = Nothing

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try


    End Sub



    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        TextBox12.Clear()
        TextBox11.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox11.Enabled = True
        PictureBox1.Image = Nothing
        TextBox6.Visible = False
        TextBox7.Visible = False
        Button10.Visible = False
        Button9.Visible = True
        Button11.Visible = True
        Button3.Enabled = False
        Button2.Visible = True
        Button7.Visible = False
        Button6.Visible = False
        Button5.Visible = False
        Button4.Visible = False
        Button14.Visible = False
        Button12.Visible = False

    End Sub


    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        TextBox12.Clear()
        TextBox11.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        ComboBox4.ResetText()
        ComboBox5.ResetText()
        Label13.ResetText()
        PictureBox1.Image = Nothing
        TextBox11.Enabled = False
        TextBox6.Visible = True
        TextBox7.Visible = True
        Button10.Visible = True
        Button9.Visible = False
        Button11.Visible = False
        Button3.Enabled = True
        Button2.Visible = True
        Button5.Visible = True
        Button4.Visible = True
        Button12.Visible = True
        Button3.Visible = False

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Masterlist(ComboBox3.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button11.Visible = False
        Button3.Visible = False
        If TextBox12.Text = "" Then
            MessageBox.Show("select item")
        Else

            Try
                con = New MySqlConnection(cnstr)
                con.Open()
                Dim sql1 As String = "DELETE FROM masterlist WHERE idno = @IDNo"
                cmd = New MySqlCommand(sql1, con)
                cmd.Parameters.AddWithValue("@IDNo", TextBox12.Text)
                Dim B As Integer = cmd.ExecuteNonQuery
                If B > 0 Then

                    MsgBox("delete")

                    TextBox12.Clear()
                    TextBox11.Clear()
                    TextBox6.Clear()
                    TextBox7.Clear()
                    Label13.ResetText()
                    PictureBox1.Image = Nothing
                    'mlsearch("")

                Else
                    MsgBox("FAILED")

                End If
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)


            End Try

        End If


    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            If MsgBox("are you sure you want to save this record?", vbYesNo + vbQuestion) = vbYes Then



                con.Open()
                Dim sql As String = " INSERT INTO verified ( id,firstname, middlename, lastname, gender,batch,email,course,contact,idno,section,status1,status) values (@id, @firstname, @middlename, @lastname, @gender,@batch,@email,@course,@contact,@idno,@section,@status1,@status) "
                cmd = New MySqlCommand(sql, con)
                With cmd

                    TextBox16.Text = 1

                    cmd.Parameters.AddWithValue("@id", TextBox3.Text)
                    cmd.Parameters.AddWithValue("@firstname", TextBox4.Text)
                    cmd.Parameters.AddWithValue("@middlename", TextBox5.Text)
                    cmd.Parameters.AddWithValue("@lastname", TextBox8.Text)
                    cmd.Parameters.AddWithValue("@gender", TextBox9.Text)
                    cmd.Parameters.AddWithValue("@batch", TextBox10.Text)
                    cmd.Parameters.AddWithValue("@email", TextBox13.Text)
                    cmd.Parameters.AddWithValue("@course", TextBox14.Text)
                    cmd.Parameters.AddWithValue("@contact", TextBox15.Text)
                    cmd.Parameters.AddWithValue("@idno", TextBox17.Text)
                    cmd.Parameters.AddWithValue("@section", TextBox18.Text)
                    cmd.Parameters.AddWithValue("@status1", TextBox19.Text)
                    cmd.Parameters.AddWithValue("@status", TextBox16.Text)
                    Dim i As Integer = cmd.ExecuteNonQuery
                    If i > 0 Then
                        MsgBox("The Record Was Saved Successfully!")




                        Button12.Visible = True

                        Button4.Visible = True
                        Button5.Visible = True
                        Button7.Visible = False
                        Button2.Visible = True

                        Button17.Visible = False
                        Button14.Visible = False
                        Button1.Visible = True
                        Button3.Visible = True
                        Button11.Visible = True
                        Button10.Visible = True
                        Button8.Visible = True
                        Button9.Visible = True

                    Else
                        MsgBox("FAILED")

                    End If
                End With
                Try
                    con = New MySqlConnection(cnstr)
                    con.Open()
                    Dim sql1 As String = "DELETE FROM alumnus_bio WHERE id = @id"
                    cmd = New MySqlCommand(sql1, con)
                    cmd.Parameters.AddWithValue("@id", TextBox3.Text)
                    Dim B As Integer = cmd.ExecuteNonQuery
                    If B > 0 Then

                        MsgBox("delete")

                        TextBox3.Clear()
                        TextBox4.Clear()
                        TextBox5.Clear()
                        TextBox8.Clear()
                        TextBox9.Clear()
                        TextBox10.Clear()
                        TextBox13.Clear()
                        TextBox14.Clear()
                        TextBox15.Clear()
                        TextBox16.Clear()
                        TextBox17.Clear()
                        TextBox18.Clear()
                        TextBox19.Clear()


                    Else
                        MsgBox("FAILED")

                    End If
                    con.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)


                End Try
                MsgBox("Record has been succesfully saved.", vbInformation)




            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)


        End Try

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox5.Text = "" Then
            MessageBox.Show("Select Item")
        Else
            Try

                con = New MySqlConnection(cnstr)
                con.Open()
                Dim sql As String = "UPDATE  alumnus_bio SET firstname =@firstname,middlename =@middlename,lastname =@lastname,	gender =@gender,batch =@batch,email =@email, course =@course, contact =@contact, password =@password, idno =@idno,section =@section,status =@status Where id = @id"
                cmd = New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@id", TextBox3.Text)
                cmd.Parameters.AddWithValue("@firstname", TextBox4.Text)
                cmd.Parameters.AddWithValue("@middlename", TextBox5.Text)
                cmd.Parameters.AddWithValue("@lastname", TextBox8.Text)
                cmd.Parameters.AddWithValue("@gender", TextBox9.Text)
                cmd.Parameters.AddWithValue("@batch", TextBox10.Text)
                cmd.Parameters.AddWithValue("@email", TextBox13.Text)
                cmd.Parameters.AddWithValue("@course", TextBox14.Text)
                cmd.Parameters.AddWithValue("@contact", TextBox15.Text)
                cmd.Parameters.AddWithValue("@password", TextBox16.Text)
                cmd.Parameters.AddWithValue("@idno", TextBox17.Text)
                cmd.Parameters.AddWithValue("@section", TextBox18.Text)
                cmd.Parameters.AddWithValue("@status", TextBox19.Text)

                Dim B As Integer = cmd.ExecuteNonQuery
                If B > 0 Then
                    MsgBox("The Record Was Updated Successfully!")
                    TextBox3.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()
                    TextBox8.Clear()
                    TextBox9.Clear()
                    TextBox10.Clear()
                    TextBox13.Clear()
                    TextBox14.Clear()
                    TextBox15.Clear()
                    TextBox16.Clear()
                    TextBox17.Clear()
                    TextBox18.Clear()
                    TextBox19.Clear()


                    Button2.Visible = True
                    Button7.Visible = True
                    Button5.Visible = True

                    Button1.Visible = True
                    Button3.Visible = True
                    Button11.Visible = True
                    Button10.Visible = True
                    Button8.Visible = True
                    Button9.Visible = True
                    Button12.Visible = True

                    Button14.Visible = False





                    TextBox3.Enabled = False
                    TextBox4.Enabled = False
                    TextBox5.Enabled = False
                    TextBox8.Enabled = False
                    TextBox9.Enabled = False
                    TextBox10.Enabled = False
                    TextBox13.Enabled = False
                    TextBox14.Enabled = False
                    TextBox15.Enabled = False
                    TextBox16.Enabled = False
                    TextBox17.Enabled = False
                    TextBox18.Enabled = False
                    TextBox19.Enabled = False

                Else
                    MsgBox("The Record Cannot Be Updated!")

                End If
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)


            End Try



        End If


    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click

        Button2.Visible = True
        Button7.Visible = False
        Button5.Visible = False
        Button12.Visible = False
        Button6.Visible = False
        Button14.Visible = True



        Button1.Visible = False
        Button3.Visible = False
        Button11.Visible = False
        Button10.Visible = False
        Button8.Visible = False
        Button9.Visible = False




        TextBox3.Enabled = False
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox8.Enabled = True
        TextBox9.Enabled = True
        TextBox10.Enabled = True
        TextBox13.Enabled = True
        TextBox14.Enabled = True
        TextBox15.Enabled = True
        TextBox16.Enabled = True
        TextBox17.Enabled = True
        TextBox18.Enabled = True
        TextBox19.Enabled = True

    End Sub


    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            If MsgBox("are you sure you want to save this record?", vbYesNo + vbQuestion) = vbYes Then




                con.Open()
                Dim sql As String = " INSERT INTO alumnus_bio ( firstname, middlename, lastname, gender,batch,email,course,contact,password,idno,section,status1) values ( @firstname, @middlename, @lastname, @gender,@batch,@email,@course,@contact,@password,@idno,@section,@status1) "
                cmd = New MySqlCommand(sql, con)
                With cmd


                    cmd.Parameters.AddWithValue("@firstname", TextBox4.Text)
                    cmd.Parameters.AddWithValue("@middlename", TextBox5.Text)
                    cmd.Parameters.AddWithValue("@lastname", TextBox8.Text)
                    cmd.Parameters.AddWithValue("@gender", TextBox9.Text)
                    cmd.Parameters.AddWithValue("@batch", TextBox10.Text)
                    cmd.Parameters.AddWithValue("@email", TextBox13.Text)
                    cmd.Parameters.AddWithValue("@course", TextBox14.Text)
                    cmd.Parameters.AddWithValue("@contact", TextBox15.Text)
                    cmd.Parameters.AddWithValue("@password", TextBox16.Text)
                    cmd.Parameters.AddWithValue("@idno", TextBox17.Text)
                    cmd.Parameters.AddWithValue("@section", TextBox18.Text)
                    cmd.Parameters.AddWithValue("@status1", TextBox19.Text)

                    Dim i As Integer = cmd.ExecuteNonQuery
                    If i > 0 Then
                        MsgBox("The Record Was Saved Successfully!")
                        TextBox3.Clear()
                        TextBox4.Clear()
                        TextBox5.Clear()
                        TextBox8.Clear()
                        TextBox9.Clear()
                        TextBox10.Clear()
                        TextBox13.Clear()
                        TextBox14.Clear()
                        TextBox15.Clear()
                        TextBox16.Clear()
                        TextBox17.Clear()
                        TextBox18.Clear()
                        TextBox19.Clear()



                        Button12.Visible = True
                        Button14.Visible = False
                        Button4.Visible = True
                        Button5.Visible = True
                        Button7.Visible = True
                        Button2.Visible = True
                        Button1.Visible = True
                        Button3.Visible = True
                        Button11.Visible = True
                        Button10.Visible = True
                        Button8.Visible = True
                        Button9.Visible = True
                        TextBox3.Enabled = False
                        TextBox4.Enabled = False
                        TextBox5.Enabled = False
                        TextBox8.Enabled = False
                        TextBox9.Enabled = False
                        TextBox10.Enabled = False
                        TextBox13.Enabled = False
                        TextBox14.Enabled = False
                        TextBox15.Enabled = False
                        TextBox16.Enabled = False
                        TextBox17.Enabled = False
                        TextBox18.Enabled = False
                        TextBox19.Enabled = False

                    Else
                        MsgBox("FAILED")

                    End If
                End With

                MsgBox("Record has been succesfully saved.", vbInformation)




            End If
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)


        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        TextBox6.Visible = True
        Button2.Visible = True
        Button7.Visible = False
        Button6.Visible = True
        Button14.Visible = True
        Button5.Visible = False
        Button4.Visible = False

        Button12.Visible = False



        Button1.Visible = False
        Button3.Visible = False
        Button11.Visible = False
        Button10.Visible = False
        Button8.Visible = False
        Button9.Visible = False


        TextBox3.Enabled = False
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox8.Enabled = True
        TextBox9.Enabled = True
        TextBox10.Enabled = True
        TextBox13.Enabled = True
        TextBox14.Enabled = True
        TextBox15.Enabled = True
        TextBox16.Enabled = True
        TextBox17.Enabled = True
        TextBox18.Enabled = True
        TextBox19.Enabled = True

    End Sub



    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox17.Clear()
        TextBox18.Clear()
        TextBox19.Clear()

        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox8.Enabled = False
        TextBox9.Enabled = False
        TextBox10.Enabled = False
        TextBox13.Enabled = False
        TextBox14.Enabled = False
        TextBox15.Enabled = False
        TextBox16.Enabled = False
        TextBox17.Enabled = False
        TextBox18.Enabled = False
        TextBox19.Enabled = False
        Button2.Visible = True
        Button7.Visible = True
        Button6.Visible = False
        Button5.Visible = True
        Button4.Visible = True
        Button14.Visible = False
        Button12.Visible = True
        Button1.Visible = True
        Button10.Visible = True
        Button8.Visible = True
        Button9.Visible = False
        Button17.Visible = False
        Button7.Visible = False
    End Sub
    Private Sub Button15_Click_1(sender As Object, e As EventArgs) Handles Button15.Click
        VerifiedForm.Show()

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Mode.Show()
        Me.Hide()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Button17.Visible = False
        Button14.Visible = False
        Button7.Visible = False
        If TextBox3.Text = "" Then
            MessageBox.Show("select item")
        Else

            Try
                con = New MySqlConnection(cnstr)
                con.Open()
                Dim sql1 As String = "DELETE FROM alumnus_bio WHERE id = @id"
                cmd = New MySqlCommand(sql1, con)
                cmd.Parameters.AddWithValue("@id", TextBox3.Text)
                Dim B As Integer = cmd.ExecuteNonQuery
                If B > 0 Then

                    MsgBox("delete")

                    TextBox3.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()
                    TextBox8.Clear()
                    TextBox9.Clear()
                    TextBox10.Clear()
                    TextBox13.Clear()
                    TextBox14.Clear()
                    TextBox15.Clear()
                    TextBox16.Clear()
                    TextBox17.Clear()
                    TextBox18.Clear()
                    TextBox19.Clear()
                    Unverified("")

                Else
                    MsgBox("FAILED")

                End If
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)


            End Try

        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        PostingJobs.Show()

    End Sub

    Private Sub Button13_Click_1(sender As Object, e As EventArgs) Handles Button13.Click
        topic.Show()
    End Sub
End Class