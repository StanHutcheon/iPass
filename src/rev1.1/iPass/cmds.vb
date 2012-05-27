Imports System.Management
Imports System.Net
Imports System.IO.Compression
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Linq

Module cmds
    Public device As String
    Public board As String
    Public extboard As String
    Public version As String
    Public ramdisk As String
    Public firmwareURL As String
    Public isDFU As Boolean = False
    Public isPwndRecovery As Boolean = False
    Public hasFixedError As Boolean = False

    Public iDev As New MobileDevice.iPhone

    Public iPhone21_sha1 As String = "647e869bd1ba0de616082611131c541bac5bd088"
    Public iPhone31_sha1 As String = "a123b049c7a03cc952c6328de998d4f74d49c18b"
    Public iPhone33_sha1 As String = "81afa9d2079a7153e5d27e30f1f08e7c53074591"
    Public iPad11_sha1 As String = "732fc3ca3f5654e6f0df787c817ca16054dfb8da"
    Public iPod31_sha1 As String = "7e963f3a1775fa4ec9ae5efeb96945d1619d2e26"
    Public iPod41_sha1 As String = "ec4feac81de53459701e4baabb6b4534be3260ca"

    Public Function searchDevice()
        Do Until iDev.IsConnected = True
            Application.DoEvents()
            For i = 0 To 5000000
                Application.DoEvents()
            Next
        Loop
        Return iDev.DeviceProductType
        version = iDev.DeviceFirmwareVersion
    End Function

    Public Function deviceVersion(ByVal devicetype As String)
        Dim devicenow As String = devicetype
        If devicenow = "iPhone2,1" Then
            device = "iPhone2,1"
            board = "n88"
            extboard = "n88ap"
            firmwareURL = "http://appldnld.apple.com/iPhone4/041-3307.20111109.5tGhu/iPhone2,1_5.0.1_9A405_Restore.ipsw"
            ramdisk = Chr(34) + Application.StartupPath & "\files\ramdisks\old.dmg" + Chr(34)
        ElseIf devicenow = "iPhone3,1" Then
            device = "iPhone3,1"
            board = "n90"
            extboard = "n90ap"
            firmwareURL = "http://appldnld.apple.com/iPhone4/041-3309.20111109.64rtg/iPhone3,1_5.0.1_9A405_Restore.ipsw"
            ramdisk = Chr(34) + Application.StartupPath & "\files\ramdisks\a4.dmg" + Chr(34)
        ElseIf devicenow = "iPhone3,3" Then
            device = "iPhone3,3"
            board = "n92"
            extboard = "n92ap"
            firmwareURL = "http://appldnld.apple.com/iPhone4/041-3309.20111109.64rtg/iPhone3,3_5.0.1_9A405_Restore.ipsw"
            ramdisk = Chr(34) + Application.StartupPath & "\files\ramdisks\a4.dmg" + Chr(34)
        ElseIf devicenow = "iPad1,1" Then
            device = "iPad1,1"
            board = "k48"
            extboard = "k48ap"
            firmwareURL = "http://appldnld.apple.com/iPhone4/041-3308.20111109.Fvgtr/iPad1,1_5.0.1_9A405_Restore.ipsw"
            ramdisk = Chr(34) + Application.StartupPath & "\files\ramdisks\a4.dmg" + Chr(34)
        ElseIf devicenow = "iPod3,1" Then
            device = "iPod3,1"
            board = "n18"
            extboard = "n18ap"
            firmwareURL = "http://appldnld.apple.com/iPhone4/041-3308.20111109.Fvgtr/iPad1,1_5.0.1_9A405_Restore.ipsw"
            ramdisk = Chr(34) + Application.StartupPath & "\files\ramdisks\old.dmg" + Chr(34)
        ElseIf devicenow = "iPod4,1" Then
            device = "iPod4,1"
            board = "n81"
            extboard = "n81ap"
            firmwareURL = "http://appldnld.apple.com/iPhone4/041-3313.20111109.Azxe3/iPod4,1_5.0.1_9A405_Restore.ipsw"
            ramdisk = Chr(34) + Application.StartupPath & "\files\ramdisks\a4.dmg" + Chr(34)
        Else
            Return False
            Exit Function
        End If
        Return True
    End Function


    Public Function IPSWVersion(ByVal file As String)
        Dim sha1 As String = Getsha1Hash(file)
        If sha1 = iPhone21_sha1 Then
            device = "iPhone2,1"
            board = "n88"
            extboard = "n88ap"
            version = "5.0.1"
            ramdisk = "files\ramdisks\old.dmg"
        ElseIf sha1 = iPhone31_sha1 Then
            device = "iPhone3,1"
            board = "n90"
            extboard = "n90ap"
            version = "5.0.1"
            ramdisk = "files\ramdisks\a4.dmg"
        ElseIf sha1 = iPad11_sha1 Then
            device = "iPad1,1"
            board = "k48"
            extboard = "k48ap"
            version = "5.0.1"
            ramdisk = "files\ramdisks\a4.dmg"
        ElseIf sha1 = iPod31_sha1 Then
            device = "iPod3,1"
            board = "n18"
            extboard = "n18ap"
            version = "5.0.1"
            ramdisk = "files\ramdisks\old.dmg"
        ElseIf sha1 = iPod41_sha1 Then
            device = "iPod4,1"
            board = "n81"
            extboard = "n81ap"
            version = "5.0.1"
            ramdisk = "files\ramdisks\a4.dmg"
        Else
            Return False
            Exit Function
        End If
        Return True
    End Function

    Public Function downloadfiles()
        'download files to temp
        Dim temp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\ipass"
        If Directory.Exists(temp) Then
            Directory.Delete(temp)
            Directory.CreateDirectory(temp)
        Else
            Directory.CreateDirectory(temp)
        End If

        'kernel
        vbpartial(firmwareURL, "/kernelcache.release." + board, temp + "\kernelcache." + board)
        'ibec
        vbpartial(firmwareURL, "/Firmware/dfu/iBEC." + extboard + ".RELEASE.dfu", temp + "\ibss." + board)
        'ibss
        vbpartial(firmwareURL, "/Firmware/dfu/iBSS." + extboard + ".RELEASE.dfu", temp + "\ibec." + board)
        'devicetree
        vbpartial(firmwareURL, "/Firmware/all_flash/all_flash." + extboard + ".production/DeviceTree." + extboard + ".img3", temp + "\devicetree." + board)
    End Function

    Public Function irec_upload(ByVal file As String)
        Dim irec As Process = New Process
        irec.StartInfo.FileName = Application.StartupPath & "\files\tools\irecovery\irecovery.exe"
        irec.StartInfo.Arguments = " -f " + Chr(34) + file + Chr(34)
        irec.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        irec.Start()
        irec.WaitForExit()
        Return True
    End Function

    Public Function irec_command(ByVal cmd As String)
        Dim irec As Process = New Process
        irec.StartInfo.FileName = Application.StartupPath & "\files\tools\irecovery\irecovery.exe"
        irec.StartInfo.Arguments = " -c " + Chr(34) + cmd + Chr(34)
        irec.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        irec.Start()
        irec.WaitForExit()
        Return True
    End Function

    Sub Delay(ByVal dblSecs As Double)
        Const OneSec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblWaitTil As Date
        Now.AddSeconds(OneSec)
        dblWaitTil = Now.AddSeconds(OneSec).AddSeconds(dblSecs)
        Do Until Now > dblWaitTil
            Application.DoEvents()
        Loop
    End Sub

    Public Function searchDFU() As Boolean
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
        searchDFU = True
    End Function

    Public Function kill(ByVal proc As String)
        Dim processesByName As Process() = Process.GetProcessesByName(proc)
        Dim num3 As Integer = (Enumerable.Count(Of Process)(processesByName) - 1)
        Dim i As Integer = 0
        Do While (i <= num3)
            processesByName(i).Kill()
            i += 1
        Loop
        Return True
    End Function

    Public Function searchRecovery() As Boolean
        Dim StopDisShit As Boolean = False
        Dim out As String = ""
        Do Until StopDisShit = True
            out = " "
            Dim searcher As New  _
                ManagementObjectSearcher( _
                      "root\CIMV2", _
                      "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Recovery (iBoot) USB Driver'")
            For Each queryObj As ManagementObject In searcher.Get()

                out += (queryObj("Description"))
            Next
            If out.Contains("iBoot") Then
                StopDisShit = True
            End If
        Loop
        searchRecovery = True
    End Function

    Public Function searchPwndRecovery() As Boolean
        'Dim StopDisShit As Boolean = False
        Dim out As String = ""
        'Do Until StopDisShit = True
        out = " "
        Dim searcher As New  _
            ManagementObjectSearcher( _
                  "root\CIMV2", _
                  "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Mobile Device USB Driver'")
        For Each queryObj As ManagementObject In searcher.Get()

            out += (queryObj("PNPDeviceID"))
        Next
        If out.Contains("RAMDISK_TOOL_DEC__1_2011_14:40:41") Then
            searchPwndRecovery = True
        Else
            searchPwndRecovery = False
        End If
        'Loop
    End Function

    Public Function searchPwndRecoveryloop() As Boolean
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
            Application.DoEvents()
            For i = 0 To 5000000
                Application.DoEvents()
            Next
        Loop
        searchPwndRecoveryloop = True
    End Function

    Public Function Getsha1Hash(ByVal filepath As String) As String
        Using reader As New System.IO.FileStream(filepath, IO.FileMode.Open, IO.FileAccess.Read)
            Using sha1 As New System.Security.Cryptography.SHA1CryptoServiceProvider
                Dim hash() As Byte = sha1.ComputeHash(reader)
                Return ByteArrayToString(hash)
            End Using
        End Using
    End Function

    Private Function ByteArrayToString(ByVal arrInput() As Byte) As String
        Dim sb As New System.Text.StringBuilder(arrInput.Length * 2)
        For i As Integer = 0 To arrInput.Length - 1
            sb.Append(arrInput(i).ToString("X2"))
        Next
        Return sb.ToString().ToLower
    End Function

    Public Function vbpartial(ByVal zipUrl As String, ByVal filename As String, ByVal destination As String)
        Dim num2 As Integer
        Dim requestUriString As String = zipUrl
        Dim str2 As String = filename
        Dim path As String = destination
        Dim request As HttpWebRequest = DirectCast(WebRequest.Create(requestUriString), HttpWebRequest)
        request.Method = "HEAD"
        Dim response As HttpWebResponse = DirectCast(request.GetResponse, HttpWebResponse)
        Dim contentLength As Integer = CInt(response.ContentLength)
        If (contentLength > &H10015) Then
            num2 = ((contentLength - &HFFFF) - &H16)
        Else
            num2 = 0
        End If
        request = DirectCast(WebRequest.Create(requestUriString), HttpWebRequest)
        request.AddRange(num2, contentLength - 1)
        response = DirectCast(request.GetResponse, HttpWebResponse)
        Dim bytes As Byte() = Encoding.Unicode.GetBytes(New StreamReader(response.GetResponseStream, Encoding.Unicode).ReadToEnd)
        Dim num3 As Integer = FindPattern(bytes, BitConverter.GetBytes(&H6054B50))
        Dim buffer As Byte() = New Byte(&H16 - 1) {}
        Dim i As Integer
        For i = 0 To &H15 - 1
            buffer(i) = bytes((num3 + i))
        Next i
        Dim reader As New BinaryReader(New MemoryStream(buffer), Encoding.Unicode)
        reader.ReadInt32()
        reader.ReadInt16()
        reader.ReadInt16()
        reader.ReadInt16()
        Dim num5 As Integer = reader.ReadInt16
        Dim num6 As Integer = reader.ReadInt32
        Dim from As Integer = reader.ReadInt32
        reader.ReadInt16()
        request = DirectCast(WebRequest.Create(requestUriString), HttpWebRequest)
        request.AddRange(from, ((from + num6) - 1))
        response = DirectCast(request.GetResponse, HttpWebResponse)
        reader = New BinaryReader(New MemoryStream(Encoding.Unicode.GetBytes(New StreamReader(response.GetResponseStream, Encoding.Unicode).ReadToEnd)), Encoding.Unicode)
        Dim numArray As Integer() = New Integer(num5 - 1) {}
        Dim numArray2 As Short() = New Short(num5 - 1) {}
        Dim numArray3 As Short() = New Short(num5 - 1) {}
        Dim numArray4 As Short() = New Short(num5 - 1) {}
        Dim numArray5 As Short() = New Short(num5 - 1) {}
        Dim numArray6 As Short() = New Short(num5 - 1) {}
        Dim numArray7 As Short() = New Short(num5 - 1) {}
        Dim numArray8 As Integer() = New Integer(num5 - 1) {}
        Dim numArray9 As Integer() = New Integer(num5 - 1) {}
        Dim numArray10 As Integer() = New Integer(num5 - 1) {}
        Dim numArray11 As Short() = New Short(num5 - 1) {}
        Dim numArray12 As Short() = New Short(num5 - 1) {}
        Dim numArray13 As Short() = New Short(num5 - 1) {}
        Dim numArray14 As Short() = New Short(num5 - 1) {}
        Dim numArray15 As Short() = New Short(num5 - 1) {}
        Dim numArray16 As Integer() = New Integer(num5 - 1) {}
        Dim numArray17 As Integer() = New Integer(num5 - 1) {}
        Dim strArray As String() = New String(num5 - 1) {}
        Dim strArray2 As String() = New String(num5 - 1) {}
        Dim strArray3 As String() = New String(num5 - 1) {}
        Dim j As Integer
        For j = 0 To num5 - 1
            numArray(j) = reader.ReadInt32
            numArray2(j) = reader.ReadInt16
            numArray3(j) = reader.ReadInt16
            numArray4(j) = reader.ReadInt16
            numArray5(j) = reader.ReadInt16
            numArray6(j) = reader.ReadInt16
            numArray7(j) = reader.ReadInt16
            numArray8(j) = reader.ReadInt32
            numArray9(j) = reader.ReadInt32
            numArray10(j) = reader.ReadInt32
            numArray11(j) = reader.ReadInt16
            numArray12(j) = reader.ReadInt16
            numArray13(j) = reader.ReadInt16
            numArray14(j) = reader.ReadInt16
            numArray15(j) = reader.ReadInt16
            numArray16(j) = reader.ReadInt32
            numArray17(j) = reader.ReadInt32
            Dim buffer3 As Byte() = New Byte(numArray11(j) - 1) {}
            reader.Read(buffer3, 0, numArray11(j))
            strArray(j) = Encoding.ASCII.GetString(buffer3)
            If (numArray12(j) <> 0) Then
                buffer3 = New Byte(numArray12(j) - 1) {}
                reader.Read(buffer3, 0, numArray12(j))
                strArray2(j) = Encoding.ASCII.GetString(buffer3)
            End If
            If (numArray13(j) <> 0) Then
                buffer3 = New Byte(numArray13(j) - 1) {}
                reader.Read(buffer3, 0, numArray13(j))
                strArray3(j) = Encoding.ASCII.GetString(buffer3)
            End If
        Next j
        Dim flag As Boolean = False
        Dim index As Integer = 0
        Dim k As Integer
        For k = 0 To num5 - 1
            If (strArray(k) = str2) Then
                flag = True
                index = k
            End If
        Next k
        If Not flag Then
            Return False
        Else
            num2 = numArray17(index)
            request = DirectCast(WebRequest.Create(requestUriString), HttpWebRequest)
            request.AddRange(num2, ((num2 + 30) - 1))
            response = DirectCast(request.GetResponse, HttpWebResponse)
            reader = New BinaryReader(New MemoryStream(Encoding.Unicode.GetBytes(New StreamReader(response.GetResponseStream, Encoding.Unicode).ReadToEnd)), Encoding.Unicode)
            reader.ReadInt32()
            reader.ReadInt16()
            reader.ReadInt16()
            Dim num11 As Short = reader.ReadInt16
            reader.ReadInt16()
            reader.ReadInt16()
            reader.ReadInt32()
            reader.ReadInt32()
            reader.ReadInt32()
            Dim num12 As Short = reader.ReadInt16
            Dim num13 As Short = reader.ReadInt16
            Dim buffer4 As Byte() = New Byte(numArray9(index) - 1) {}
            num2 = (((numArray17(index) + 30) + num12) + num13)
            request = DirectCast(WebRequest.Create(requestUriString), HttpWebRequest)
            request.AddRange(num2, ((num2 + numArray9(index)) - 1))
            response = DirectCast(request.GetResponse, HttpWebResponse)
            response.GetResponseStream.Read(buffer4, 0, buffer4.Length)
            If (num11 = 8) Then
                Dim stream As New DeflateStream(New MemoryStream(buffer4), CompressionMode.Decompress)
                Dim buffer5 As Byte() = New Byte(numArray10(index) - 1) {}
                stream.Read(buffer5, 0, buffer5.Length)
                File.WriteAllBytes(path, buffer5)
                Return True
            Else
                File.WriteAllBytes(path, buffer4)
                Return True
            End If
        End If
    End Function

    Private Function FindPattern(ByVal data As Byte(), ByVal pattern As Byte()) As Integer
        Dim i As Integer
        For i = 0 To data.Length - 1
            If (data(i) <> pattern(0)) Then
                Continue For
            End If
            Dim flag As Boolean = True
            Dim j As Integer
            For j = 1 To pattern.Length - 1
                If (data((i + j)) <> pattern(j)) Then
                    flag = False
                    Exit For
                End If
            Next j
            If flag Then
                Return i
            End If
        Next i
        Return -1
    End Function
End Module
