<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dfu
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.startDFU = New System.Windows.Forms.Button()
        Me.one = New System.Windows.Forms.Label()
        Me.two = New System.Windows.Forms.Label()
        Me.three = New System.Windows.Forms.Label()
        Me.count = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 59)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(426, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Please Power off your device and click start to begin countdown."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 59)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "DFU Help"
        '
        'startDFU
        '
        Me.startDFU.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.startDFU.Location = New System.Drawing.Point(21, 85)
        Me.startDFU.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.startDFU.Name = "startDFU"
        Me.startDFU.Size = New System.Drawing.Size(121, 36)
        Me.startDFU.TabIndex = 4
        Me.startDFU.Text = "Start"
        Me.startDFU.UseVisualStyleBackColor = True
        '
        'one
        '
        Me.one.AutoSize = True
        Me.one.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.one.ForeColor = System.Drawing.Color.Gray
        Me.one.Location = New System.Drawing.Point(17, 131)
        Me.one.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.one.Name = "one"
        Me.one.Size = New System.Drawing.Size(197, 19)
        Me.one.TabIndex = 5
        Me.one.Text = "Hold down the power button."
        '
        'two
        '
        Me.two.AutoSize = True
        Me.two.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.two.ForeColor = System.Drawing.Color.Gray
        Me.two.Location = New System.Drawing.Point(17, 170)
        Me.two.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.two.Name = "two"
        Me.two.Size = New System.Drawing.Size(431, 19)
        Me.two.TabIndex = 6
        Me.two.Text = "Hold down the home button whilst kept hold of the power button."
        '
        'three
        '
        Me.three.AutoSize = True
        Me.three.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.three.ForeColor = System.Drawing.Color.Gray
        Me.three.Location = New System.Drawing.Point(17, 210)
        Me.three.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.three.Name = "three"
        Me.three.Size = New System.Drawing.Size(310, 19)
        Me.three.TabIndex = 7
        Me.three.Text = "Release the power button, keep holding home."
        '
        'count
        '
        Me.count.AutoSize = True
        Me.count.Font = New System.Drawing.Font("Calibri", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.count.Location = New System.Drawing.Point(342, 85)
        Me.count.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.count.Name = "count"
        Me.count.Size = New System.Drawing.Size(65, 78)
        Me.count.TabIndex = 8
        Me.count.Text = "3"
        Me.count.Visible = False
        '
        'dfu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 248)
        Me.Controls.Add(Me.count)
        Me.Controls.Add(Me.three)
        Me.Controls.Add(Me.two)
        Me.Controls.Add(Me.one)
        Me.Controls.Add(Me.startDFU)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dfu"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "DFU Help"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents startDFU As System.Windows.Forms.Button
    Friend WithEvents one As System.Windows.Forms.Label
    Friend WithEvents two As System.Windows.Forms.Label
    Friend WithEvents three As System.Windows.Forms.Label
    Friend WithEvents count As System.Windows.Forms.Label
End Class
