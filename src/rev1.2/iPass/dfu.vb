Public Class dfu

    Private Sub startDFU_Click(sender As Object, e As EventArgs) Handles startDFU.Click
        startDFU.Enabled = False
        count.Visible = True
        Delay(1)
        count.Text = "2"
        Delay(1)
        count.Text = "1"
        Delay(1)
        one.ForeColor = Color.Black
        count.Text = "3"
        Delay(1)
        count.Text = "2"
        Delay(1)
        count.Text = "1"
        Delay(1)
        one.ForeColor = Color.Gray
        two.ForeColor = Color.Black
        If isDFU = True Then
            endDFUSearch()
            Exit Sub
        End If
        count.Text = "10"
        Delay(1)
        count.Text = "9"
        Delay(1)
        count.Text = "8"
        Delay(1)
        count.Text = "7"
        Delay(1)
        count.Text = "6"
        Delay(1)
        count.Text = "5"
        Delay(1)
        If isDFU = True Then
            endDFUSearch()
            Exit Sub
        End If
        count.Text = "4"
        Delay(1)
        count.Text = "3"
        Delay(1)
        count.Text = "2"
        Delay(1)
        count.Text = "1"
        Delay(1)
        two.ForeColor = Color.Gray
        three.ForeColor = Color.Black
        If isDFU = True Then
            endDFUSearch()
            Exit Sub
        End If
        count.Text = "15"
        Delay(1)
        count.Text = "14"
        Delay(1)
        count.Text = "13"
        Delay(1)
        count.Text = "12"
        Delay(1)
        count.Text = "11"
        Delay(1)
        count.Text = "10"
        Delay(1)
        If isDFU = True Then
            endDFUSearch()
            Exit Sub
        End If
        count.Text = "9"
        Delay(1)
        count.Text = "8"
        Delay(1)
        count.Text = "7"
        Delay(1)
        count.Text = "6"
        Delay(1)
        count.Text = "5"
        Delay(1)
        count.Text = "4"
        Delay(1)
        count.Text = "3"
        Delay(1)
        count.Text = "2"
        Delay(1)
        count.Text = "1"
        Delay(3)
        If isDFU = False Then
            MsgBox("No device detected in DFU mode, please try again.", MsgBoxStyle.Exclamation, "iPass - Error")
            resetDFUSearch()
            Exit Sub
        Else
            endDFUSearch()
            Exit Sub
        End If
    End Sub

    Private Sub endDFUSearch()
        one.ForeColor = Color.Gray
        two.ForeColor = Color.Gray
        three.ForeColor = Color.Gray
        count.Text = "3"
        count.Visible = False
        startDFU.Enabled = True
        Me.Close()
    End Sub

    Private Sub resetDFUSearch()
        one.ForeColor = Color.Gray
        two.ForeColor = Color.Gray
        three.ForeColor = Color.Gray
        count.Text = "3"
        count.Visible = False
        startDFU.Enabled = True
    End Sub
End Class