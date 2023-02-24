<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GSM
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GSM))
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM3"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Location = New System.Drawing.Point(90, 307)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 50)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "SEND"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(49, 186)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(224, 115)
        Me.TextBox1.TabIndex = 1
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton1.Location = New System.Drawing.Point(49, 163)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(45, 17)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "JOB"
        Me.RadioButton1.UseVisualStyleBackColor = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton2.Location = New System.Drawing.Point(228, 163)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(58, 17)
        Me.RadioButton2.TabIndex = 3
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Events"
        Me.RadioButton2.UseVisualStyleBackColor = False
        '
        'GSM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(314, 369)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "GSM"
        Me.Text = "GSM"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
End Class
