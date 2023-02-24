Imports MySql.Data.MySqlClient


Imports System.Threading.Thread
Imports System.IO.Ports
Public Class GSM


    Dim cmd As MySqlCommand
    Dim con As MySqlConnection
    Dim cnstr As String = "data source = 172.104.187.153; user = root;password = root; database = alumni_db"
    Dim dr As MySqlDataReader
    Dim itemcoll(999) As String


    Sub Send_To_Many()
        Dim post As String = TextBox1.Text

        con = New MySqlConnection(cnstr)
        con.Open()
        Dim get_verified_users_query As String = " Select contact from verified Where contact != '';"
        cmd = New MySqlCommand(get_verified_users_query, con)
        dr = cmd.ExecuteReader()

        While dr.Read
            If dr.IsDBNull(0) Then
                MessageBox.Show("NO DATA")
            Else
                Dim Status As String = send(portname:="COM3", contact:=dr.Item("contact"), msg:=post)
                If Status = "Sent" Then
                    MessageBox.Show("Message sent to " & dr.Item("contact"))
                Else
                    MessageBox.Show("Message is failed to send.")
                End If
            End If
        End While
        dr.Close()
    End Sub



    Sub send_sms()

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Send_To_Many()
    End Sub


    Private Sub RadioButton1_CheckedChanged_1(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TextBox1.Text = "We have new posted jobs"
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TextBox1.Text = "We have new posted events"
    End Sub

    Private Sub GSM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class