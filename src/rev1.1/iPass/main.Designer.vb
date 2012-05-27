<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ipswSelect = New System.Windows.Forms.Button()
        Me.ipswName = New System.Windows.Forms.TextBox()
        Me.ipswSelectDialog = New System.Windows.Forms.OpenFileDialog()
        Me.out = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.credits = New System.Windows.Forms.TextBox()
        Me.guifix = New System.Windows.Forms.TextBox()
        Me.dfuDetect = New System.ComponentModel.BackgroundWorker()
        Me.pwnRecoveryDetect = New System.ComponentModel.BackgroundWorker()
        Me.status = New System.Windows.Forms.TextBox()
        Me.finalPasscode = New System.Windows.Forms.TextBox()
        Me.deviceDetect = New System.ComponentModel.BackgroundWorker()
        Me.alreadyPwnd = New System.Windows.Forms.Button()
        Me.fixerror = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 59)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "iPass"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 59)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(351, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Please connect your device in normal mode to begin."
        '
        'ipswSelect
        '
        Me.ipswSelect.Enabled = False
        Me.ipswSelect.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ipswSelect.Location = New System.Drawing.Point(493, 98)
        Me.ipswSelect.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ipswSelect.Name = "ipswSelect"
        Me.ipswSelect.Size = New System.Drawing.Size(12, 10)
        Me.ipswSelect.TabIndex = 2
        Me.ipswSelect.Text = "Select IPSW"
        Me.ipswSelect.UseVisualStyleBackColor = True
        Me.ipswSelect.Visible = False
        '
        'ipswName
        '
        Me.ipswName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ipswName.Cursor = System.Windows.Forms.Cursors.Default
        Me.ipswName.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ipswName.Location = New System.Drawing.Point(137, 97)
        Me.ipswName.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ipswName.Name = "ipswName"
        Me.ipswName.ReadOnly = True
        Me.ipswName.Size = New System.Drawing.Size(120, 17)
        Me.ipswName.TabIndex = 3
        Me.ipswName.Text = "iPhone3,1 selected"
        Me.ipswName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ipswName.Visible = False
        '
        'ipswSelectDialog
        '
        Me.ipswSelectDialog.DefaultExt = "ipsw"
        Me.ipswSelectDialog.Filter = "IPSW files|*.ipsw"
        Me.ipswSelectDialog.Title = "Please select an iOS 5.0.1 IPSW"
        '
        'out
        '
        Me.out.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.out.Cursor = System.Windows.Forms.Cursors.Default
        Me.out.Location = New System.Drawing.Point(510, 24)
        Me.out.Name = "out"
        Me.out.ReadOnly = True
        Me.out.Size = New System.Drawing.Size(493, 127)
        Me.out.TabIndex = 5
        Me.out.Text = ""
        Me.out.Visible = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(12, 85)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 36)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Start"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'credits
        '
        Me.credits.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.credits.Cursor = System.Windows.Forms.Cursors.Default
        Me.credits.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.credits.Location = New System.Drawing.Point(11, 264)
        Me.credits.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.credits.Name = "credits"
        Me.credits.ReadOnly = True
        Me.credits.Size = New System.Drawing.Size(361, 14)
        Me.credits.TabIndex = 7
        Me.credits.Text = "© Stan Hutcheon 2012 - All credit goes to the iPhone Dev Team for redsn0w"
        Me.credits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'guifix
        '
        Me.guifix.Location = New System.Drawing.Point(510, 0)
        Me.guifix.Name = "guifix"
        Me.guifix.Size = New System.Drawing.Size(10, 21)
        Me.guifix.TabIndex = 8
        Me.guifix.Visible = False
        '
        'dfuDetect
        '
        Me.dfuDetect.WorkerSupportsCancellation = True
        '
        'pwnRecoveryDetect
        '
        Me.pwnRecoveryDetect.WorkerSupportsCancellation = True
        '
        'status
        '
        Me.status.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.status.Cursor = System.Windows.Forms.Cursors.Default
        Me.status.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.status.Location = New System.Drawing.Point(376, 264)
        Me.status.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        Me.status.Size = New System.Drawing.Size(130, 14)
        Me.status.TabIndex = 9
        Me.status.Text = "Status: OK"
        Me.status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'finalPasscode
        '
        Me.finalPasscode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.finalPasscode.Cursor = System.Windows.Forms.Cursors.Default
        Me.finalPasscode.Font = New System.Drawing.Font("Calibri", 76.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.finalPasscode.Location = New System.Drawing.Point(12, 127)
        Me.finalPasscode.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.finalPasscode.Name = "finalPasscode"
        Me.finalPasscode.ReadOnly = True
        Me.finalPasscode.Size = New System.Drawing.Size(493, 131)
        Me.finalPasscode.TabIndex = 11
        Me.finalPasscode.Text = "5475"
        Me.finalPasscode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'deviceDetect
        '
        Me.deviceDetect.WorkerSupportsCancellation = True
        '
        'alreadyPwnd
        '
        Me.alreadyPwnd.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.alreadyPwnd.Location = New System.Drawing.Point(12, 85)
        Me.alreadyPwnd.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.alreadyPwnd.Name = "alreadyPwnd"
        Me.alreadyPwnd.Size = New System.Drawing.Size(121, 36)
        Me.alreadyPwnd.TabIndex = 12
        Me.alreadyPwnd.Text = "Start"
        Me.alreadyPwnd.UseVisualStyleBackColor = True
        Me.alreadyPwnd.Visible = False
        '
        'fixerror
        '
        Me.fixerror.AutoSize = True
        Me.fixerror.Location = New System.Drawing.Point(372, 12)
        Me.fixerror.Name = "fixerror"
        Me.fixerror.Size = New System.Drawing.Size(134, 17)
        Me.fixerror.TabIndex = 13
        Me.fixerror.Text = "Select device manually"
        Me.fixerror.UseVisualStyleBackColor = True
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(517, 282)
        Me.Controls.Add(Me.fixerror)
        Me.Controls.Add(Me.alreadyPwnd)
        Me.Controls.Add(Me.finalPasscode)
        Me.Controls.Add(Me.status)
        Me.Controls.Add(Me.guifix)
        Me.Controls.Add(Me.credits)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.out)
        Me.Controls.Add(Me.ipswName)
        Me.Controls.Add(Me.ipswSelect)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.Name = "main"
        Me.Text = "iPass - rev1.1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ipswSelect As System.Windows.Forms.Button
    Friend WithEvents ipswName As System.Windows.Forms.TextBox
    Friend WithEvents ipswSelectDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents out As System.Windows.Forms.RichTextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents credits As System.Windows.Forms.TextBox
    Friend WithEvents guifix As System.Windows.Forms.TextBox
    Friend WithEvents dfuDetect As System.ComponentModel.BackgroundWorker
    Friend WithEvents pwnRecoveryDetect As System.ComponentModel.BackgroundWorker
    Friend WithEvents status As System.Windows.Forms.TextBox
    Friend WithEvents finalPasscode As System.Windows.Forms.TextBox
    Friend WithEvents deviceDetect As System.ComponentModel.BackgroundWorker
    Friend WithEvents alreadyPwnd As System.Windows.Forms.Button
    Friend WithEvents fixerror As System.Windows.Forms.CheckBox

End Class
