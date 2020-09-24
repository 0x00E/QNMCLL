Imports ICSharpCode.SharpZipLib.Zip
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.VisualBasic.Devices
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Win32
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports My

Partial Public Class Form1
    Inherits Form

    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.Form1_Load)
        AddHandler MyBase.MouseDown, New MouseEventHandler(AddressOf Me.Form1_MouseDown)
        AddHandler MyBase.MouseMove, New MouseEventHandler(AddressOf Me.Form1_MouseMove)
        Me.finishrunmc1 = New AsyncCallback(AddressOf Me.finishrunmc)
        Me.InitializeComponent()
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        If File.Exists((Directory.GetCurrentDirectory & "\QNMCLL.cfg")) Then
            If File.ReadAllText((Directory.GetCurrentDirectory & "\QNMCLL.cfg")).Contains("src=") Then
                File.WriteAllText((Directory.GetCurrentDirectory & "\QNMCLL.cfg"), ("name=" & Module1.dname), Encoding.Unicode)
                File.AppendAllText((Directory.GetCurrentDirectory & "\QNMCLL.cfg"), (Environment.NewLine & "meo=" & Module1.dmemory), Encoding.Unicode)
                File.AppendAllText((Directory.GetCurrentDirectory & "\QNMCLL.cfg"), (Environment.NewLine & "src=" & Module1.djavapath), Encoding.Unicode)
                File.AppendAllText((Directory.GetCurrentDirectory & "\QNMCLL.cfg"), (Environment.NewLine & "pro=" & Module1.cmdpre), Encoding.Unicode)
                File.AppendAllText((Directory.GetCurrentDirectory & "\QNMCLL.cfg"), Conversions.ToString(Operators.ConcatenateObject(Environment.NewLine, Operators.AddObject("endver=", Me.ComboBox1.SelectedItem))), Encoding.Unicode)
            Else
                File.WriteAllText((Directory.GetCurrentDirectory & "\QNMCLL.cfg"), ("name=" & Module1.dname), Encoding.Unicode)
                File.AppendAllText((Directory.GetCurrentDirectory & "\QNMCLL.cfg"), Conversions.ToString(Operators.ConcatenateObject(Environment.NewLine, Operators.AddObject("endver=", Me.ComboBox1.SelectedItem))), Encoding.Unicode)
            End If
        Else
            File.WriteAllText((Directory.GetCurrentDirectory & "\QNMCLL.cfg"), ("name=" & Module1.dname), Encoding.Unicode)
            File.AppendAllText((Directory.GetCurrentDirectory & "\QNMCLL.cfg"), Conversions.ToString(Operators.ConcatenateObject(Environment.NewLine, Operators.AddObject("endver=", Me.ComboBox1.SelectedItem))), Encoding.Unicode)
        End If
        If (Module1.dname = "") Then
            MessageBox.Show("名字为空，请前往设置！")
        Else
            Me.Button1.Enabled = False
            Dim mcr As New mrunmc1(AddressOf Me.mrunmc)
            mcr.BeginInvoke(Module1.dname, Module1.dmemory, Conversions.ToString(Me.ComboBox1.SelectedItem), Module1.djavapath, Me.finishrunmc1, Nothing)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("本启动器为QNMCL精简版，详情参见QNMCL", "QNMCL")
    End Sub

    Private Sub Button4_Click_1(ByVal sender As Object, ByVal e As EventArgs)
        MyBase.Close()
    End Sub

    Public Sub downloadlib(ByVal filename As String, ByVal webname As String)
        Try
            Dim network As New Network

            network.DownloadFile(webname, filename, "", "", True, &H2710, True, UICancelOption.ThrowException)
        Catch exception1 As OperationCanceledException
            ProjectData.SetProjectError(exception1)
            Dim exception As OperationCanceledException = exception1
            If (MessageBox.Show("你确认要取消下载吗！", "QNMCL", MessageBoxButtons.YesNo) = DialogResult.No) Then
                Me.downloadlib(filename, webname)
            Else
                File.Delete(filename)
            End If
            ProjectData.ClearProjectError()
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            If webname.Contains("http://bmclapi2.bangbang93.com/libraries") Then
                Me.downloadlib(filename, webname.Replace("http://bmclapi2.bangbang93.com/libraries", "https://libraries.minecraft.net"))
            Else
                MessageBox.Show(("下载文件出错：" & filename & "！" & exception2.Message), "QNMCL")
                File.Delete(filename)
            End If
            If (Not webname.Contains("http://bmclapi2.bangbang93.com/libraries") And Not webname.Contains("https://libraries.minecraft.net")) Then
                Me.downloadlib(filename, ("http://bmclapi2.bangbang93.com/libraries/" & filename.Replace((Directory.GetCurrentDirectory & "\.minecraft\libraries\"), "").Replace("\", "/")))
            End If
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Public Sub finishrunmc(ByVal ar As IAsyncResult)
        MyBase.Invoke(New finishrunmc3(AddressOf Me.finishrunmc2))
    End Sub

    <MethodImpl((MethodImplOptions.NoOptimization Or MethodImplOptions.NoInlining))>
    Public Sub finishrunmc2()
        ProjectData.EndApp()
    End Sub

    <MethodImpl((MethodImplOptions.NoOptimization Or MethodImplOptions.NoInlining))>
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not Directory.Exists((Directory.GetCurrentDirectory & "\.minecraft\versions\")) Then
            MessageBox.Show("没有找到Minecraft版本文件，启动器不能启动！", "QNMCL")
            ProjectData.EndApp()
        End If
        Module1.cmdpre = ""
        Dim random As New Random
        Module1.dname = ""
        random = Nothing
        Module1.dmemory = Conversions.ToString(&H400)
        If (((Marshal.SizeOf(IntPtr.Zero) * 8) = &H40) And (Conversions.ToDouble(Module1.dmemory) > CInt(Math.Round(CDbl((((CDbl(MyProject.Computer.Info.TotalPhysicalMemory) / 1024) / 1024) / 4)))))) Then
            Module1.dmemory = Conversions.ToString(CInt(Math.Round(CDbl((((CDbl(MyProject.Computer.Info.TotalPhysicalMemory) / 1024) / 1024) / 4)))))
        End If
        Module1.djavapath = ""
        Module1.dlastversion = ""
        If File.Exists((Directory.GetCurrentDirectory & "\QNMCLL.cfg")) Then
            Dim separator As String() = New String() {Environment.NewLine}
            Dim str As String
            For Each str In File.ReadAllText((Directory.GetCurrentDirectory & "\QNMCLL.cfg"), Encoding.Unicode).Split(separator, StringSplitOptions.RemoveEmptyEntries)
                Select Case Strings.Left(str, Strings.InStr(str, "=", CompareMethod.Binary))
                    Case "name="
                        Module1.dname = str.Replace("name=", "")
                        Exit Select
                    Case "meo="
                        Module1.dmemory = str.Replace("meo=", "")
                        Exit Select
                    Case "src="
                        Module1.djavapath = str.Replace("src=", "")
                        Exit Select
                    Case "endver="
                        Module1.dlastversion = str.Replace("endver=", "")
                        Exit Select
                    Case "pro="
                        Module1.cmdpre = str.Replace("pro=", "")
                        Exit Select
                End Select
            Next
        End If
        If (Module1.djavapath = "") Then
            Try
                Dim arguments As Object() = New Object() {"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\javaws.exe\Path"}
                Module1.djavapath = (Conversions.ToString(NewLateBinding.LateGet(RuntimeHelpers.GetObjectValue(Interaction.CreateObject("wscript.shell", "")), Nothing, "regread", arguments, Nothing, Nothing, Nothing)) & "\javaw.exe")
            Catch exception1 As NullReferenceException
                ProjectData.SetProjectError(exception1)
                Dim exception As NullReferenceException = exception1
                MessageBox.Show("没有找到java，请点击java按钮下载安装！", "QNMCL")
                ProjectData.ClearProjectError()
            End Try
        End If
        Dim str4 As String
        For Each str4 In MyProject.Computer.FileSystem.GetDirectories((Directory.GetCurrentDirectory & "\.minecraft\versions\"))
            str4 = str4.Replace((Directory.GetCurrentDirectory & "\.minecraft\versions\"), "")
            Me.ComboBox1.Items.Add(str4)
        Next
        If (Me.ComboBox1.Items.Count > 0) Then
            If Me.ComboBox1.Items.Contains(Module1.dlastversion) Then
                Me.ComboBox1.SelectedItem = Module1.dlastversion
            Else
                Me.ComboBox1.SelectedIndex = 0
            End If
        Else
            MessageBox.Show("没有找到Minecraft版本文件，启动器不能启动！", "QNMCL")
            ProjectData.EndApp()
        End If
        If File.Exists((Directory.GetCurrentDirectory & "\background.jpg")) Then
            Dim image As Image = Image.FromFile((Directory.GetCurrentDirectory & "\background.jpg"))
            Graphics.FromImage(image).DrawImage(image, 0, 0, MyBase.Width, MyBase.Height)
            Me.BackgroundImage = image
        End If
    End Sub

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim point As Point = MyBase.PointToScreen(e.Location)
        Me.p = New Point((point.X - MyBase.Location.X), (point.Y - MyBase.Location.Y))
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        If (e.Button = MouseButtons.Left) Then
            Dim point As Point = MyBase.PointToScreen(e.Location)
            MyBase.Location = New Point((point.X - Me.p.X), (point.Y - Me.p.Y))
        End If
    End Sub

    Private Sub Label2_Click(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Public Sub mrunmc(ByVal name As String, ByVal memory As String, ByVal version As String, ByVal javapath As String)
        If Not Directory.Exists((Directory.GetCurrentDirectory & "\.minecraft\natives\")) Then
            Directory.CreateDirectory((Directory.GetCurrentDirectory & "\.minecraft\natives\"))
        End If
        Dim str As String
        For Each str In MyProject.Computer.FileSystem.GetFiles((Directory.GetCurrentDirectory & "\.minecraft\natives\"))
            File.Delete(str)
        Next
        If Not File.Exists((Directory.GetCurrentDirectory & "\.minecraft\launcher_profiles.json")) Then
            File.WriteAllText((Directory.GetCurrentDirectory & "\.minecraft\launcher_profiles.json"), Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("{" & ChrW(9) & """selectedProfile"": ""(Default)""," & ChrW(9) & """profiles"": {" & ChrW(9) & ChrW(9) & "}," & ChrW(9) & ChrW(9) & """clientToken"": """, Me.uuid("launcher_profiles.json")), """"c), "}")))
        End If
        Dim textArray1 As String() = New String() {"-Xmx", memory, "m ", Module1.cmdpre, " -Dfml.ignoreInvalidMinecraftCertificates=true -Dfml.ignorePatchDiscrepancies=true -Djava.library.path="".minecraft\natives"" -cp """}
        Dim arguments As String = String.Concat(textArray1)
        Dim str3 As String = File.ReadAllText(String.Concat(New String() {Directory.GetCurrentDirectory, "\.minecraft\versions\", version, "\", version, ".json"}))
        Dim str4 As String = ""
        Dim num As Integer = 0
        Dim separator As String() = New String() {"""libraries"":"}
        Dim str5 As String = str3.Split(separator, StringSplitOptions.RemoveEmptyEntries)(1)
        Dim i As Integer
        For i = 0 To str5.Length - 1
            Dim str6 As String = Conversions.ToString(str5.Chars(i))
            If (str6 = "]") Then
                num -= 1
                If (num = 0) Then
                    Exit For
                End If
            End If
            If (num > 0) Then
                str4 = (str4 & str6)
            End If
            If (str6 = "[") Then
                num += 1
            End If
        Next i
        Dim str7 As String = ""
        Dim num3 As Integer = 0
        Dim str8 As String = str4
        Dim j As Integer
        For j = 0 To str8.Length - 1
            Dim str9 As String = Conversions.ToString(str8.Chars(j))
            If (str9 = "}") Then
                num3 -= 1
                If (num3 = 0) Then
                    If str7.Contains("rules") Then
                        Dim str10 As String = ""
                        Dim num5 As Integer = 0
                        Dim flag12 As Boolean = True
                        Dim textArray4 As String() = New String() {"""rules"":"}
                        Dim str11 As String = str7.Split(textArray4, StringSplitOptions.RemoveEmptyEntries)(1)
                        Dim k As Integer
                        For k = 0 To str11.Length - 1
                            Dim str12 As String = Conversions.ToString(str11.Chars(k))
                            If (str12 = "]") Then
                                num5 -= 1
                                If (num5 = 0) Then
                                    Exit For
                                End If
                            End If
                            If (num5 > 0) Then
                                str10 = (str10 & str12)
                            End If
                            If (str12 = "[") Then
                                num5 += 1
                            End If
                        Next k
                        Dim num7 As Integer = 0
                        Dim textArray5 As String() = New String() {""""}
                        Dim str13 As String
                        For Each str13 In str10.Split(textArray5, StringSplitOptions.RemoveEmptyEntries)
                            If (num7 > 0) Then
                                num7 += 1
                            End If
                            If (num7 = 3) Then
                                If (str13 = "allow") Then
                                    flag12 = True
                                Else
                                    flag12 = False
                                End If
                            End If
                            If (str13 = "action") Then
                                num7 = 1
                            End If
                        Next
                        Dim str14 As String = ""
                        Dim num9 As Integer = 0
                        Dim textArray6 As String() = New String() {"""os"":"}
                        Dim str15 As String = str10.Split(textArray6, StringSplitOptions.RemoveEmptyEntries)(1)
                        Dim m As Integer
                        For m = 0 To str15.Length - 1
                            Dim str16 As String = Conversions.ToString(str15.Chars(m))
                            If (str16 = "}") Then
                                num9 -= 1
                                If (num9 = 0) Then
                                    Exit For
                                End If
                            End If
                            If (num9 > 0) Then
                                str14 = (str14 & str16)
                            End If
                            If (str16 = "{") Then
                                num9 += 1
                            End If
                        Next m
                        num7 = 0
                        Dim textArray7 As String() = New String() {""""}
                        Dim str17 As String
                        For Each str17 In str10.Split(textArray7, StringSplitOptions.RemoveEmptyEntries)
                            If (num7 > 0) Then
                                num7 += 1
                            End If
                            If ((num7 = 3) AndAlso (Operators.CompareString(str17, "windows", False) > 0)) Then
                                flag12 = Not flag12
                            End If
                            If (str17 = "name") Then
                                num7 = 1
                            End If
                        Next
                        If Not flag12 Then
                            str7 = ""
                            Continue For
                        End If
                    End If
                    Dim path As String = ""
                    Dim num12 As Integer = 0
                    Dim str19 As String = "http://bmclapi2.bangbang93.com/libraries/"
                    Dim num13 As Integer = 0
                    Dim textArray8 As String() = New String() {""""}
                    Dim str20 As String
                    For Each str20 In str7.Split(textArray8, StringSplitOptions.RemoveEmptyEntries)
                        If (num13 > 0) Then
                            num13 += 1
                        End If
                        If (num12 > 0) Then
                            num12 += 1
                        End If
                        If (num12 = 3) Then
                            Dim str21 As String = ""
                            Dim str22 As String = ""
                            Dim num15 As Integer = Strings.InStr(str20, ":", CompareMethod.Binary)
                            str21 = Strings.Left(str20, (num15 - 1))
                            str21 = (Directory.GetCurrentDirectory & "\.minecraft\libraries\" & str21.Replace(".", "\"))
                            str22 = Strings.Right(str20, ((str20.Length - num15) + 1))
                            str21 = (str21 & str22.Replace(":", "\") & "\")
                            str22 = Strings.Right(str20, (str20.Length - num15))
                            If str7.Contains("natives") Then
                                If str7.Contains("twitch") Then
                                    str22 = (str22.Replace(":", "-") & "-natives-windows-" & Conversions.ToString(CInt((Marshal.SizeOf(IntPtr.Zero) * 8))) & ".jar")
                                Else
                                    str22 = (str22.Replace(":", "-") & "-natives-windows.jar")
                                End If
                            Else
                                str22 = (str22.Replace(":", "-") & ".jar")
                            End If
                            path = (str21 & str22)
                            Exit For
                        End If
                        If (num13 = 3) Then
                            str19 = str20
                            num13 = 0
                        End If
                        Select Case str20
                            Case "name"
                                num12 = 1
                                Exit Select
                            Case "url"
                                num13 = 1
                                Exit Select
                        End Select
                    Next
                    If Not File.Exists(path) Then
                        Me.downloadlib(path, (str19 & path.Replace((Directory.GetCurrentDirectory & "\.minecraft\libraries\"), "").Replace("\", "/")))
                    End If
                    Dim zip As New FastZip
                    If str7.Contains("natives") Then
                        zip.ExtractZip(path, (Directory.GetCurrentDirectory & "\.minecraft\natives\"), Nothing)
                    Else
                        arguments = (arguments & path & ";")
                    End If
                    str7 = ""
                End If
            End If
            If (num3 > 0) Then
                str7 = (str7 & str9)
            End If
            If (str9 = "{") Then
                num3 += 1
            End If
        Next j
        Dim textArray9 As String() = New String() {arguments, Directory.GetCurrentDirectory, "\.minecraft\versions\", version, "\", version, ".jar"}
        arguments = String.Concat(textArray9)
        Dim left As String = ""
        Dim num16 As Integer = 0
        Dim newValue As String = ""
        Dim num17 As Integer = 0
        Dim str25 As String = ""
        Dim num18 As Integer = 0
        Dim str26 As String = ""
        Dim num19 As Integer = 0
        Dim textArray10 As String() = New String() {""""}
        Dim str27 As String
        For Each str27 In str3.Split(textArray10, StringSplitOptions.RemoveEmptyEntries)
            If (num19 > 0) Then
                num19 += 1
            End If
            If (num18 > 0) Then
                num18 += 1
            End If
            If (num17 > 0) Then
                num17 += 1
            End If
            If (num16 > 0) Then
                num16 += 1
            End If
            If (num18 = 3) Then
                str25 = str27
                num18 = 0
            End If
            If (num19 = 3) Then
                str26 = str27
                num19 = 0
            End If
            If (num17 = 3) Then
                newValue = str27
                num17 = 0
            End If
            If (num16 = 3) Then
                left = str27
                num16 = 0
            End If
            If (str27 = "mainClass") Then
                num19 = 1
            End If
            If (str27 = "minecraftArguments") Then
                num18 = 1
            End If
            If (str27 = "assets") Then
                num17 = 1
            End If
            If (str27 = "inheritsFrom") Then
                num16 = 1
            End If
        Next
        Dim str28 As String = str3
        If (Operators.CompareString(left, "", False) <= 0) Then
            arguments = (arguments & """")
        Else
            arguments = (arguments & ";")
            str3 = File.ReadAllText(String.Concat(New String() {Directory.GetCurrentDirectory, "\.minecraft\versions\", left, "\", left, ".json"}))
            str4 = ""
            num = 0
            Dim textArray12 As String() = New String() {"""libraries"":"}
            Dim str29 As String = str3.Split(textArray12, StringSplitOptions.RemoveEmptyEntries)(1)
            Dim n As Integer
            For n = 0 To str29.Length - 1
                Dim str30 As String = Conversions.ToString(str29.Chars(n))
                If (str30 = "]") Then
                    num -= 1
                    If (num = 0) Then
                        Exit For
                    End If
                End If
                If (num > 0) Then
                    str4 = (str4 & str30)
                End If
                If (str30 = "[") Then
                    num += 1
                End If
            Next n
            str7 = ""
            num3 = 0
            Dim str31 As String = str4
            Dim num22 As Integer
            For num22 = 0 To str31.Length - 1
                Dim str32 As String = Conversions.ToString(str31.Chars(num22))
                If (str32 = "}") Then
                    num3 -= 1
                    If (num3 = 0) Then
                        If str7.Contains("rules") Then
                            Dim str33 As String = ""
                            Dim num23 As Integer = 0
                            Dim flag70 As Boolean = True
                            Dim textArray13 As String() = New String() {"""rules"":"}
                            Dim str34 As String = str7.Split(textArray13, StringSplitOptions.RemoveEmptyEntries)(1)
                            Dim num24 As Integer
                            For num24 = 0 To str34.Length - 1
                                Dim str35 As String = Conversions.ToString(str34.Chars(num24))
                                If (str35 = "]") Then
                                    num23 -= 1
                                    If (num23 = 0) Then
                                        Exit For
                                    End If
                                End If
                                If (num23 > 0) Then
                                    str33 = (str33 & str35)
                                End If
                                If (str35 = "[") Then
                                    num23 += 1
                                End If
                            Next num24
                            Dim num25 As Integer = 0
                            Dim textArray14 As String() = New String() {""""}
                            Dim str36 As String
                            For Each str36 In str33.Split(textArray14, StringSplitOptions.RemoveEmptyEntries)
                                If (num25 > 0) Then
                                    num25 += 1
                                End If
                                If (num25 = 3) Then
                                    If (str36 = "allow") Then
                                        flag70 = True
                                    Else
                                        flag70 = False
                                    End If
                                End If
                                If (str36 = "action") Then
                                    num25 = 1
                                End If
                            Next
                            Dim str37 As String = ""
                            Dim num27 As Integer = 0
                            Dim textArray15 As String() = New String() {"""os"":"}
                            Dim str38 As String = str33.Split(textArray15, StringSplitOptions.RemoveEmptyEntries)(1)
                            Dim num28 As Integer
                            For num28 = 0 To str38.Length - 1
                                Dim str39 As String = Conversions.ToString(str38.Chars(num28))
                                If (str39 = "}") Then
                                    num27 -= 1
                                    If (num27 = 0) Then
                                        Exit For
                                    End If
                                End If
                                If (num27 > 0) Then
                                    str37 = (str37 & str39)
                                End If
                                If (str39 = "{") Then
                                    num27 += 1
                                End If
                            Next num28
                            num25 = 0
                            Dim textArray16 As String() = New String() {""""}
                            Dim str40 As String
                            For Each str40 In str33.Split(textArray16, StringSplitOptions.RemoveEmptyEntries)
                                If (num25 > 0) Then
                                    num25 += 1
                                End If
                                If ((num25 = 3) AndAlso (Operators.CompareString(str40, "windows", False) > 0)) Then
                                    flag70 = Not flag70
                                End If
                                If (str40 = "name") Then
                                    num25 = 1
                                End If
                            Next
                            If Not flag70 Then
                                str7 = ""
                                Continue For
                            End If
                        End If
                        Dim str41 As String = ""
                        Dim num30 As Integer = 0
                        Dim str42 As String = "http://bmclapi2.bangbang93.com/libraries/"
                        Dim num31 As Integer = 0
                        Dim textArray17 As String() = New String() {""""}
                        Dim str43 As String
                        For Each str43 In str7.Split(textArray17, StringSplitOptions.RemoveEmptyEntries)
                            If (num31 > 0) Then
                                num31 += 1
                            End If
                            If (num30 > 0) Then
                                num30 += 1
                            End If
                            If (num30 = 3) Then
                                Dim str44 As String = ""
                                Dim str45 As String = ""
                                Dim num33 As Integer = Strings.InStr(str43, ":", CompareMethod.Binary)
                                str44 = Strings.Left(str43, (num33 - 1))
                                str44 = (Directory.GetCurrentDirectory & "\.minecraft\libraries\" & str44.Replace(".", "\"))
                                str45 = Strings.Right(str43, ((str43.Length - num33) + 1))
                                str44 = (str44 & str45.Replace(":", "\") & "\")
                                str45 = Strings.Right(str43, (str43.Length - num33))
                                If str7.Contains("natives") Then
                                    If str7.Contains("twitch") Then
                                        str45 = (str45.Replace(":", "-") & "-natives-windows-" & Conversions.ToString(CInt((Marshal.SizeOf(IntPtr.Zero) * 8))) & ".jar")
                                    Else
                                        str45 = (str45.Replace(":", "-") & "-natives-windows.jar")
                                    End If
                                Else
                                    str45 = (str45.Replace(":", "-") & ".jar")
                                End If
                                str41 = (str44 & str45)
                                Exit For
                            End If
                            If (num31 = 3) Then
                                str42 = str43
                                num31 = 0
                            End If
                            Select Case str43
                                Case "name"
                                    num30 = 1
                                    Exit Select
                                Case "url"
                                    num31 = 1
                                    Exit Select
                            End Select
                        Next
                        If Not File.Exists(str41) Then
                            Me.downloadlib(str41, (str42 & str41.Replace((Directory.GetCurrentDirectory & "\.minecraft\libraries\"), "").Replace("\", "/")))
                        End If
                        Dim zip2 As New FastZip
                        If str7.Contains("natives") Then
                            zip2.ExtractZip(str41, (Directory.GetCurrentDirectory & "\.minecraft\natives\"), Nothing)
                        Else
                            arguments = (arguments & str41 & ";")
                        End If
                        str7 = ""
                    End If
                End If
                If (num3 > 0) Then
                    str7 = (str7 & str32)
                End If
                If (str32 = "{") Then
                    num3 += 1
                End If
            Next num22
            Dim textArray18 As String() = New String() {arguments, Directory.GetCurrentDirectory, "\.minecraft\versions\", left, "\", left, ".jar"""}
            arguments = String.Concat(textArray18)
            If (newValue = "") Then
                Dim textArray19 As String() = New String() {""""}
                Dim str46 As String
                For Each str46 In str3.Split(textArray19, StringSplitOptions.RemoveEmptyEntries)
                    If (num17 > 0) Then
                        num17 += 1
                    End If
                    If (num17 = 3) Then
                        newValue = str46
                        num17 = 0
                    End If
                    If (str46 = "assets") Then
                        num17 = 1
                    End If
                Next
            End If
        End If
        str25 = str25.Replace("${game_directory}", ".minecraft").Replace("${assets_root}", ".minecraft\assets").Replace("${game_assets}", ".minecraft\assets").Replace("${user_type}", "legacy").Replace("${user_properties}", "{}").Replace("${auth_player_name}", name).Replace("${version_name}", version).Replace("${auth_uuid}", Conversions.ToString(Me.uuid(name))).Replace("${assets_index_name}", newValue)
        Dim textArray20 As String() = New String() {arguments, " ", str26, " ", str25}
        arguments = String.Concat(textArray20)
        Process.Start(javapath, arguments)
    End Sub

    Public Function uuid(ByVal name As String) As Object
        Dim obj2 As Object
        Dim currentUser As RegistryKey = Registry.CurrentUser
        Try
            currentUser = currentUser.OpenSubKey("SOFTWARE").OpenSubKey("MMCL").OpenSubKey("UUID")
            If Operators.ConditionalCompareObjectNotEqual(currentUser.GetValue(name), Nothing, False) Then
                Return currentUser.GetValue(name)
            End If
            currentUser = Nothing
            Dim key2 As RegistryKey = Registry.CurrentUser
            Dim str As String = Guid.NewGuid.ToString("D")
            key2.CreateSubKey("SOFTWARE").CreateSubKey("MMCL").CreateSubKey("UUID").SetValue(name, str)
            obj2 = str
        Catch exception1 As NullReferenceException
            ProjectData.SetProjectError(exception1)
            Dim exception As NullReferenceException = exception1
            currentUser = Nothing
            Dim key3 As RegistryKey = Registry.CurrentUser
            Dim str2 As String = Guid.NewGuid.ToString("D")
            key3.CreateSubKey("SOFTWARE").CreateSubKey("MMCL").CreateSubKey("UUID").SetValue(name, str2)
            obj2 = str2
            ProjectData.ClearProjectError()
        End Try
        Return obj2
    End Function

    Public finishrunmc1 As AsyncCallback
    Private p As Point

    ' Nested Types
    Public Delegate Sub finishrunmc3()

    Public Delegate Sub mrunmc1(ByVal name As String, ByVal memory As String, ByVal version As String, ByVal javapath As String)
End Class

