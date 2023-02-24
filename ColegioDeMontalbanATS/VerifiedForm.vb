Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing.Imaging

Imports System.Threading.Thread
Imports System.IO.Ports
Public Class VerifiedForm
    Dim cmd As MySqlCommand
    Dim con As MySqlConnection
    Dim cnstr As String = "data source = 172.104.187.153; user = root;password = root; database = alumni_db"
    Dim da As MySqlDataAdapter
    Dim dset As DataSet
    Dim dr As MySqlDataReader
    Dim itemcoll(999) As String


    Sub verified(valuetosearch)
        DataGridView2.Rows.Clear()
        con = New MySqlConnection(cnstr)
        con.Open()
        cmd = New MySqlCommand("select * from verified  WHERE CONCAT (id,firstname,middlename,lastname,batch,course) Like '%" & valuetosearch & "%'", con)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView2.Rows.Add(dr.Item("id").ToString, dr.Item("firstname").ToString, dr.Item("middlename").ToString, dr.Item("lastname").ToString, dr.Item("gender").ToString, dr.Item("batch").ToString, dr.Item("email").ToString, dr.Item("course").ToString, dr.Item("contact").ToString, dr.Item("idno").ToString, dr.Item("section").ToString, dr.Item("status1").ToString, dr.Item("status").ToString)
        End While
        dr.Close()
        con.Close()



    End Sub



    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Button14.Visible = True
        Button17.Visible = True
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("Column1").Value.ToString()
            TextBox2.Text = row.Cells("Column2").Value.ToString()
            TextBox4.Text = row.Cells("Column3").Value.ToString()
            TextBox5.Text = row.Cells("Column4").Value.ToString()
            TextBox6.Text = row.Cells("Column5").Value.ToString()

            TextBox7.Text = row.Cells("Column6").Value.ToString()
            TextBox8.Text = row.Cells("Column7").Value.ToString()

            TextBox9.Text = row.Cells("Column8").Value.ToString()
            TextBox10.Text = row.Cells("Column9").Value.ToString()

            TextBox12.Text = row.Cells("Column10").Value.ToString()

            TextBox13.Text = row.Cells("Column11").Value.ToString()
            TextBox14.Text = row.Cells("Column12").Value.ToString()

            TextBox11.Text = row.Cells("Column13").Value.ToString()

        End If



    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        verified("")



        TextBox1.Clear()
        TextBox2.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox3.Clear()
        TextBox15.Clear()
        ComboBox1.ResetText()
        ComboBox3.ResetText()
        Button17.Visible = False
        Button14.Visible = False



    End Sub



    Private Sub VerifiedForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        verified("")
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        verified(TextBox3.Text)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        verified(ComboBox1.Text)
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        verified(ComboBox3.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            SerialPort1.Open()


            SerialPort1.Write("AT+CMGS=" & """" & TextBox10.Text & """" & vbCrLf)
            Sleep(1000)
            SerialPort1.Write(TextBox15.Text & Chr(26))
            Sleep(1000)
            Dim d As String = SerialPort1.ReadExisting
            If InStr(d, "OK") Then
                MsgBox("Sent", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Sent", MsgBoxStyle.Exclamation)
            End If
            SerialPort1.DtrEnable = False
            SerialPort1.RtsEnable = False
            SerialPort1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SerialPort1.Close()
        End Try
    End Sub


    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Button14.Visible = False
        Button17.Visible = False
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox3.Clear()

        ComboBox1.ResetText()
        ComboBox3.ResetText()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Button17.Visible = False
        Button14.Visible = False
        If TextBox1.Text = "" Then
            MessageBox.Show("select item")
        Else

            Try
                con = New MySqlConnection(cnstr)
                con.Open()
                Dim sql1 As String = "DELETE FROM verified WHERE id = @id"
                cmd = New MySqlCommand(sql1, con)
                cmd.Parameters.AddWithValue("@id", TextBox3.Text)
                Dim B As Integer = cmd.ExecuteNonQuery
                If B > 0 Then

                    MsgBox("delete")

                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()
                    TextBox6.Clear()
                    TextBox7.Clear()
                    TextBox8.Clear()
                    TextBox9.Clear()
                    TextBox10.Clear()
                    TextBox11.Clear()
                    TextBox12.Clear()
                    TextBox13.Clear()
                    TextBox14.Clear()
                    TextBox3.Clear()

                    ComboBox1.ResetText()
                    ComboBox3.ResetText()
                    verified("")

                Else
                    MsgBox("FAILED")

                End If
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)


            End Try

        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TextBox15.Text = "You are now listed in alumni list"
    End Sub
End Class