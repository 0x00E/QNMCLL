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

    <DebuggerNonUserCode>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If (disposing AndAlso (Me.components Is Nothing)) Then
                Me.components.Dispose()
            End If
        Finally
            Me.Dispose(disposing)
        End Try
    End Sub

    <DebuggerStepThrough>
    Private Sub InitializeComponent()
        Dim resources As New ComponentResourceManager(GetType(Form2))
        Me.Label1 = New Label
        Me.TextBox1 = New TextBox
        Me.Label2 = New Label
        Me.TextBox2 = New TextBox
        Me.Button2 = New Button
        Me.OpenFileDialog1 = New OpenFileDialog
        Me.GroupBox1 = New GroupBox
        Me.TextBox3 = New TextBox
        Me.Button4 = New Button
        Me.Button3 = New Button
        Me.Label4 = New Label
        Me.TextBox4 = New TextBox
        Me.Button5 = New Button
        Me.Button6 = New Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        Me.Label1.AutoSize = True
        Me.Label1.Location = New Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(&H29, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "用户名"
        Me.TextBox1.Location = New Point(&H47, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Size(160, &H15)
        Me.TextBox1.TabIndex = 1
        Me.Label2.AutoSize = True
        Me.Label2.Location = New Point(11, &H22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(&H35, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "最大内存"
        Me.TextBox2.Location = New Point(&H47, &H1F)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Size(160, &H15)
        Me.TextBox2.TabIndex = 4
        Me.Button2.Location = New Point(13, &H3A)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New Size(&HDA, &H15)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "点击自动设置内存"
        Me.Button2.UseVisualStyleBackColor = True
        Me.OpenFileDialog1.Filter = "java主程序|*.exe"
        Me.OpenFileDialog1.Title = "选择java主程序"
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Location = New Point(&H153, &H81)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New Size(&HEB, &H31)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "javaw.exe目录"
        Me.TextBox3.Location = New Point(4, &H12)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Size(&HD7, &H15)
        Me.TextBox3.TabIndex = 0
        Me.Button4.Location = New Point(580, &H93)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New Size(&H4F, &H17)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "选择"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button3.Location = New Point(&H153, &HB8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New Size(&HDB, &H18)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "java自动"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Label4.AutoSize = True
        Me.Label4.Location = New Point(11, &H62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(&H35, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "附加参数"
        Me.TextBox4.Location = New Point(&H47, &H5E)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Size(160, &H15)
        Me.TextBox4.TabIndex = 9
        Me.Button5.Location = New Point(12, &H86)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New Size(&H65, &H22)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "确认"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button6.Location = New Point(&H7F, &H86)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New Size(&H65, &H22)
        Me.Button6.TabIndex = 11
        Me.Button6.Text = "返回"
        Me.Button6.UseVisualStyleBackColor = True
        Me.AutoScaleDimensions = New SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(&HF6, &HBB)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = DirectCast(resources.GetObject("$this.Icon"), Icon)
        Me.Name = "Form2"
        Me.Text = "设置"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub


    ' Properties
    Friend WithEvents Button2 As Button

    Friend WithEvents Button3 As Button


    Friend WithEvents Button4 As Button

    Friend WithEvents Button5 As Button


    Friend WithEvents Button6 As Button


    Friend WithEvents GroupBox1 As GroupBox

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label

    Friend WithEvents Label4 As Label


    Friend WithEvents OpenFileDialog1 As OpenFileDialog


    Friend WithEvents TextBox1 As TextBox

    Friend WithEvents TextBox2 As TextBox


    Friend WithEvents TextBox3 As TextBox


    Friend WithEvents TextBox4 As TextBox


    Private components As IContainer
End Class
