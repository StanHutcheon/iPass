Imports System.Threading
Imports System.IO
Imports System.Linq
Imports System.Management
Imports System.Net
Imports System.IO.Compression
Imports System.Text
Imports System.Collections.Generic

Public Class main

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        finalPasscode.Text = ""
        If searchPwndRecovery() = True Then
            Button1.Visible = False
            alreadyPwnd.Visible = True
            Label2.Text = "As your device is already pwnd, just click start."
            fixerror.Enabled = False
        End If
        guifix.Select()
    End Sub

    Private Sub ipswSelect_Click(sender As Object, e As EventArgs) Handles ipswSelect.Click
        ipswSelect.Enabled = False
        ipswSelectDialog.ShowDialog()
        If ipswSelectDialog.FileName = "" Then
            MsgBox("Please select an iOS 5.0.1 IPSW applicable to your device", MsgBoxStyle.Exclamation, "iPass - Error")
            ipswSelect.Enabled = True
            Exit Sub
        End If
        Dim isValidIPSW = IPSWVersion(ipswSelectDialog.FileName)

        If isValidIPSW = False Then
            MsgBox("The IPSW you selected was invalid, pelase select another.", MsgBoxStyle.Exclamation, "iPass - Error")
            ipswSelect.Enabled = True
            Exit Sub
        End If

        MsgBox("You've selected an " + device + " " + version + " IPSW, this will be used for the rest of the session.", MsgBoxStyle.Information, "iPass - Notification")

        ipswName.Text = device + " " + version + " selected."
        ipswName.Visible = True

        Dim proc As New Process()
        proc.StartInfo.FileName = Application.StartupPath + "\files\redsn0w.exe"
        proc.StartInfo.Arguments = " -r " + ramdisk + " -i " + Chr(34) + ipswSelectDialog.FileName + Chr(34)
        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        proc.Start()
        Dim question = MsgBox("You need to now enter DFU mode, Do you need help in entering DFU Mode?", MsgBoxStyle.YesNo, "iPass - Help")
        If question = MsgBoxResult.Yes Then
            dfu.Show()
        End If
        Do Until isDFU = True
            Application.DoEvents()
            For i = 0 To 5000000
                Application.DoEvents()
            Next
        Loop
        isDFU = False
        dfuDetect.CancelAsync()
        status.Text = "Pwning..."
        Do Until isPwndRecovery = True
            Application.DoEvents()
            For i = 0 To 5000000
                Application.DoEvents()
            Next
        Loop
        isPwndRecovery = False
        pwnRecoveryDetect.CancelAsync()
        status.Text = "Found pwned device."
        proc.Kill()
        Button1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fixerror.Enabled = False
        Button1.Enabled = False
        guifix.Select()
        status.Text = "Waiting for device..."
        If fixerror.Checked = True Then
            devicehelp.Show()
            Do Until hasFixedError = True
                Application.DoEvents()
                For i = 0 To 5000000
                    Application.DoEvents()
                Next
            Loop
        Else
            Dim deviceconnected = searchDevice()
            deviceVersion(deviceconnected)
        End If
        ipswName.Text = device + " selected."
        ipswName.Visible = True
        dfuDetect.RunWorkerAsync()
        status.Text = "Searching for DFU..."
        Dim bootlogo As String = Chr(34) + Application.StartupPath + "\files\boot.png" + Chr(34)
        ChDir(Application.StartupPath)
        Shell("files\tools\redsn0w\redsn0w.exe -b " + bootlogo + " -r " + ramdisk, AppWinStyle.MinimizedNoFocus)
        If isDFU = False Then
            Dim question = MsgBox("You now need enter DFU mode, Do you need help in entering DFU Mode?", MsgBoxStyle.YesNo, "iPass - Help")
            If question = MsgBoxResult.Yes Then
                dfu.Show()
            End If
            Do Until isDFU = True
                Application.DoEvents()
                For i = 0 To 5000000
                    Application.DoEvents()
                Next
            Loop
            isDFU = False
            dfuDetect.CancelAsync()
        End If
        status.Text = "Entering Pwned mode..."
        Dim recoverypwnd = searchPwndRecoveryloop()
        Do Until recoverypwnd = True
            Application.DoEvents()
            For i = 0 To 5000000
                Application.DoEvents()
            Next
        Loop
        status.Text = "Found pwned device."
        Try
            kill("redsn0w")
        Catch ex As Exception

        End Try
        pwn()
        Button1.Enabled = True
    End Sub

    Private Sub alreadyPwnd_Click(sender As Object, e As EventArgs) Handles alreadyPwnd.Click
        alreadyPwnd.Enabled = False
        guifix.Select()
        pwn()
        alreadyPwnd.Enabled = True
    End Sub

    Public Sub pwn()
        Dim tcprelay As New ProcessStartInfo
        tcprelay.FileName = Application.StartupPath & "\files\tools\tcprelay\tcprelay.exe"
        tcprelay.Arguments = " -t 22:2222 1999:1999"
        tcprelay.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(tcprelay)

        Dim bruteforce As New Process
        bruteforce.StartInfo.FileName = "cmd.exe"
        bruteforce.StartInfo.Arguments = " /C cd " + Chr(34) + Application.StartupPath + "\files\tools\bruteforce" + Chr(34) + " && bruteforce.exe > out.txt"
        'bruteforce.StartInfo.RedirectStandardOutput = True
        'bruteforce.StartInfo.UseShellExecute = False
        bruteforce.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        bruteforce.StartInfo.CreateNoWindow = True
        bruteforce.Start()
        status.Text = "Cracking passcode..."
        Do
            Thread.Sleep(&H36B0)
            If bruteforce.HasExited Then
                Dim output As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\files\tools\bruteforce\out.txt")
                'Dim output = bruteforce.StandardOutput.ReadToEnd.ToString
                File.Delete(Application.StartupPath + "\files\tools\bruteforce\out.txt")
                Dim outputSplit = Split(output, "'")
                Dim passcode = outputSplit(9)
                If passcode.Length > 4 Then
                    finalPasscode.Text = "Error"
                    My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\errorlog." + Int((9001 * Rnd()) + 1).ToString + ".log", output, False)
                Else
                    finalPasscode.Text = passcode.ToString
                End If
                kill("tcprelay")
            End If
            Application.DoEvents()
            For i = 0 To 5000000
                Application.DoEvents()
            Next
        Loop While Not bruteforce.HasExited
        status.Text = "Cracked passcode."
        Delay(2)
        status.Text = "Status: OK"
        Exit Sub
    End Sub

    Private Sub ipswName_Click(sender As Object, e As EventArgs) Handles ipswName.Click
        guifix.Select()
    End Sub

    Private Sub credits_Click(sender As Object, e As EventArgs) Handles credits.Click
        guifix.Select()
    End Sub

    Private Sub status_Click(sender As Object, e As EventArgs) Handles status.Click
        guifix.Select()
    End Sub

    Private Sub dfuDetect_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles dfuDetect.DoWork
        Dim StopDisShit As Boolean = False
        Dim out As String = ""
        Do Until StopDisShit = True
            out = " "
            Dim searcher As New  _
                ManagementObjectSearcher( _
                      "root\CIMV2", _
                      "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Recovery (DFU) USB Driver'")
            For Each queryObj As ManagementObject In searcher.Get()

                out += (queryObj("Description"))
            Next
            If out.Contains("DFU") Then
                StopDisShit = True
            End If
        Loop
        isDFU = True
    End Sub

    Private Sub pwnRecoveryDetect_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles pwnRecoveryDetect.DoWork
        Dim StopDisShit As Boolean = False
        Dim out As String = ""
        Do Until StopDisShit = True
            out = " "
            Dim searcher As New  _
                ManagementObjectSearcher( _
                      "root\CIMV2", _
                      "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Mobile Device USB Driver'")
            For Each queryObj As ManagementObject In searcher.Get()

                out += (queryObj("PNPDeviceID"))
            Next
            If out.Contains("RAMDISK_TOOL_DEC__1_2011_14:40:41") Then
                StopDisShit = True
            End If
        Loop
        isPwndRecovery = True
    End Sub

    Private Sub deviceDetect_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles deviceDetect.DoWork
        Do Until iDev.IsConnected = True
            Application.DoEvents()
            For i = 0 To 5000000
                Application.DoEvents()
            Next
        Loop
        deviceVersion(iDev.DeviceProductType.ToString)
        ipswName.Text = device + " " + version + " selected."
        ipswName.Visible = True
    End Sub

    Private Sub main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        kill("redsn0w")
        kill("tcprelay")
        kill("iPass")
        kill("bruteforce")
        Try
            dfuDetect.CancelAsync()
            pwnRecoveryDetect.CancelAsync()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fixerror_CheckedChanged(sender As Object, e As EventArgs) Handles fixerror.CheckedChanged
        MsgBox("Use this method if either your device isn't being recognised by iPass or if you want to skip having to plug your device in when it's in normal mode. This method will apply when 'Start' is pressed.", MsgBoxStyle.Information, "iPass - Information")
    End Sub
End Class
