Public Class devicehelp

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If devices.SelectedItem = "iPhone 3GS" Then
            deviceVersion("iPhone2,1")
        ElseIf devices.SelectedItem = "iPhone 4 (GSM)" Then
            deviceVersion("iPhone3,1")
        ElseIf devices.SelectedItem = "iPhone 4 (CDMA)" Then
            deviceVersion("iPhone3,3")
        ElseIf devices.SelectedItem = "iPad 1" Then
            deviceVersion("iPad1,1")
        ElseIf devices.SelectedItem = "iPod Touch 3G" Then
            deviceVersion("iPod3,1")
        ElseIf devices.SelectedItem = "iPod Touch 4G" Then
            deviceVersion("iPod4,1")
        Else
            MsgBox("error")
        End If
        hasFixedError = True
        Me.Close()
    End Sub

    Private Sub devices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles devices.SelectedIndexChanged
        Button1.Enabled = True
    End Sub
End Class