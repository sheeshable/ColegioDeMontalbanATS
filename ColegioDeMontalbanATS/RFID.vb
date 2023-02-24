Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Imaging
Public Class RFID
    Dim cmd As MySqlCommand
    Dim con As MySqlConnection
    Dim dr As MySqlDataReader
    Dim cnstr As String = "data source = 172.104.187.153; user = root;password = root; database = alumni_db"
    Dim da As MySqlDataAdapter
    Dim dset As DataSet
    Dim itemcoll(999) As String
    Dim sql As String
    Dim result As Integer
    Dim imgpath As String
    Dim arrImage() As Byte


    Sub ReaderRecord()
        DataGridView1.Rows.Clear()
        con = New MySqlConnection(cnstr)
        con.Open()
        cmd = New MySqlCommand("select * from rfid ", con)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr.Item("AdminNo").ToString, dr.Item("Name").ToString, dr.Item("Age").ToString, dr.Item("Sex").ToString, dr.Item("Contact").ToString, dr.Item("RFID").ToString, dr.Item("Image").ToString)
        End While
        dr.Close()
        con.Close()



        For i = 0 To DataGridView1.Rows.Count - 1
            Dim r As DataGridViewRow = DataGridView1.Rows(i)
            r.Height = 100

        Next

    End Sub


    Private Sub RFID_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ReaderRecord()


        Dim rm As Integer
        Randomize()

        rm = Int(Rnd() * 8556) * 3
        TextBox1.Text = "adm-" & rm
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If TextBox6.Text.Length >= 10 Then







            con = New MySqlConnection(cnstr)
            con.Open()
            cmd = New MySqlCommand("select * from rfid where RFID like '" & TextBox6.Text & "'", con)
            dr = cmd.ExecuteReader
            While dr.Read()
                TextBox4.Text = dr.Item("Name").ToString
                TextBox5.Text = dr.Item("Age").ToString
                ComboBox1.Text = dr.Item("Sex").ToString
                TextBox7.Text = dr.Item("Contact").ToString
                TextBox1.Text = dr.Item("AdminNo").ToString
                Label3.Text = dr.Item("Image").ToString
                PictureBox1.ImageLocation = Label3.Text
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                TextBox9.Enabled = True


            End While
            dr.Close()
            con.Close()


            TextBox6.SelectionStart = 0
            TextBox6.SelectionLength = Len(TextBox6.Text)
            TextBox6.Focus()
        Else
            TextBox4.Clear()
            TextBox5.Clear()
            ComboBox1.ResetText()
            TextBox7.Clear()
            TextBox9.Clear()
            PictureBox1.Refresh()






        End If
    End Sub

    Sub Clear()
        TextBox1.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        ComboBox1.ResetText()
        TextBox7.Clear()
        TextBox6.Clear()
        TextBox9.Clear()
        PictureBox1.Image = Nothing
        TextBox6.Focus()
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        If Val(TextBox5.Text) >= 110 Then
            MessageBox.Show("select appropriate age")
        ElseIf Val(TextBox5.Text) <= 18 Then
            MessageBox.Show("select appropriate age")

        Else
            If TextBox7.TextLength = 10 Then
                Try
                    If MsgBox("are you sure you want to save this record?", vbYesNo + vbQuestion) = vbYes Then






                        con.Open()
                        Dim sql As String = " INSERT INTO rfid (AdminNo, Name, Age, Sex, Contact, RFID, Pin, Image) values (@AdminNo, @Name, @Age, @Sex, @Contact, @RFID, @Pin, @Image) "
                        cmd = New MySqlCommand(sql, con)
                        With cmd
                            cmd.Parameters.AddWithValue("@AdminNo", TextBox1.Text)
                            cmd.Parameters.AddWithValue("@Name", TextBox4.Text)
                            cmd.Parameters.AddWithValue("@Age", TextBox5.Text)
                            cmd.Parameters.AddWithValue("@Sex", ComboBox1.Text)
                            cmd.Parameters.AddWithValue("@Contact", TextBox7.Text)
                            cmd.Parameters.AddWithValue("@RFID", TextBox6.Text)
                            cmd.Parameters.AddWithValue("@Pin", TextBox9.Text)
                            cmd.Parameters.AddWithValue("@Image", Label3.Text)

                            Dim i As Integer = cmd.ExecuteNonQuery
                            If i > 0 Then
                                MsgBox("Add Successful")
                                Button3.Visible = False
                                Button2.Visible = True










                            Else
                                MsgBox("FAILED")

                            End If
                        End With

                        MsgBox("Record has been succesfully saved.", vbInformation)
                        Clear()
                        ReaderRecord()


                    End If
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message, vbCritical)


                End Try

            Else
                MessageBox.Show("re-enter contact number")
            End If
        End If



    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        OpenFileDialog1.Filter = "*.jpg|"
        OpenFileDialog1.ShowDialog()
        Label3.Text = OpenFileDialog1.FileName
        PictureBox1.ImageLocation = Label3.Text
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            con = New MySqlConnection(cnstr)
            con.Open()
            sql = "SELECT * FROM rfid where RFID='" & TextBox6.Text & "' and pin = '" & TextBox9.Text & "' and AdminNo = '" & TextBox1.Text & "'"
            cmd = New MySqlCommand(Sql, con)
            dr = cmd.ExecuteReader

            Dim a As Integer
            a = 0
            While dr.Read
                a = a + 1
            End While

            If a = 1 Then
                Me.Hide()
                Dashboard.Show()
                MessageBox.Show("Welcome To Admin")




            ElseIf a < 1 Then

                MessageBox.Show("TRY AGAIN")
            End If


            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Visible = False
        Button3.Visible = True
        TextBox9.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox7.Enabled = True
        ComboBox1.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Mode.Show()

    End Sub

End Class