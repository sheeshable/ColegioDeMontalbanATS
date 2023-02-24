<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class topic
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(topic))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(117, 104)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 0
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(117, 155)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 1
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(117, 204)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 2
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(117, 255)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 20)
        Me.TextBox4.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Constantia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(96, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Constantia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(96, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Title"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Constantia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(96, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Description"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Constantia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(97, 236)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "NO."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Constantia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(93, 287)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Date"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.DataGridView1.Location = New System.Drawing.Point(235, 104)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(541, 222)
        Me.DataGridView1.TabIndex = 10
        '
        'Column1
        '
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Title"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Description"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "No."
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "Date"
        Me.Column5.Name = "Column5"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(29, 306)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 12
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Location = New System.Drawing.Point(12, 255)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 45)
        Me.Button2.TabIndex = 13
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(235, 34)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(175, 20)
        Me.TextBox5.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Constantia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(141, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 15)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Search Topic:"
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(406, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(50, 26)
        Me.Button1.TabIndex = 16
        Me.Button1.UseVisualStyleBackColor = True
        '
        'topic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 352)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "topic"
        Me.Text = "topic"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
End Class
