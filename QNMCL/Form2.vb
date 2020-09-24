Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Windows.Forms


Partial Public Class Form2
    Inherits Form

    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.Form2_Load)
        Me.InitializeComponent()
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim random As New Random
        random = Nothing
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.TextBox2.Text = Conversions.ToString(&H400)
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim arguments As Object() = New Object() {"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\javaws.exe\Path"}
            Dim str As String = Conversions.ToString(NewLateBinding.LateGet(RuntimeHelpers.GetObjectValue(Interaction.CreateObject("wscript.shell", "")), Nothing, "regread", arguments, Nothing, Nothing, Nothing))
            Me.TextBox3.Text = (str & "\javaw.exe")
        Catch exception1 As NullReferenceException
            ProjectData.SetProjectError(exception1)
            Dim exception As NullReferenceException = exception1
            MessageBox.Show("没有找到java，请点击java按钮下载安装！", "QNMCL")
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs)
        If (Me.OpenFileDialog1.ShowDialog = DialogResult.OK) Then
            Me.TextBox3.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs)
        Module1.dname = Me.TextBox1.Text
        Module1.dmemory = Me.TextBox2.Text
        Module1.djavapath = Me.TextBox3.Text
        Module1.cmdpre = Me.TextBox4.Text
        File.WriteAllText((Directory.GetCurrentDirectory & "\QNMCLL.cfg"), ("name=" & Module1.dname), Encoding.Unicode)
        File.AppendAllText((Directory.GetCurrentDirectory & "\QNMCLL.cfg"), (Environment.NewLine & "meo=" & Module1.dmemory), Encoding.Unicode)
        File.AppendAllText((Directory.GetCurrentDirectory & "\QNMCLL.cfg"), (Environment.NewLine & "src=" & Module1.djavapath), Encoding.Unicode)
        File.AppendAllText((Directory.GetCurrentDirectory & "\QNMCLL.cfg"), (Environment.NewLine & "pro=" & Module1.cmdpre), Encoding.Unicode)
        If (Operators.CompareString(Module1.dlastversion, "", False) > 0) Then
            File.AppendAllText((Directory.GetCurrentDirectory & "\QNMCLL.cfg"), (Environment.NewLine & "endver=" & Module1.dlastversion), Encoding.Unicode)
        End If
        MyBase.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As Object, ByVal e As EventArgs)
        MyBase.Close()
    End Sub

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As EventArgs)
        Me.TextBox1.Text = Module1.dname
        Me.TextBox2.Text = Module1.dmemory
        Me.TextBox3.Text = Module1.djavapath
        Me.TextBox4.Text = Module1.cmdpre
    End Sub

    Private Sub Label2_Click(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

End Class
