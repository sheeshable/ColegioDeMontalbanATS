Imports System.IO.Ports
Imports System.Threading.Thread
Module SMS

    Public No As String

    Public Function send(portname As String, contact As String, msg As String) As String

        Dim serial = New SerialPort()
        Dim Response As String

        serial.PortName = portname
        serial.BaudRate = 9600
        serial.DtrEnable = True
        serial.RtsEnable = True

        serial.Open()
        serial.Write("AT+CMGF=1" & vbCrLf)
        Sleep(1000)
        serial.Write("AT+CMGS=" & """" & contact & """" & vbCrLf)
        Sleep(2000)
        serial.Write(msg & Chr(26))
        Sleep(3000)

        Dim ansr As String = serial.ReadExisting

        If InStr(ansr, "OK") Then
            Response = "SENT"
        Else
            Response = "FAILED"
        End If
        serial.DtrEnable = False
        serial.RtsEnable = False
        serial.Close()

        Return Response


    End Function

End Module
