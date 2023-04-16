<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        TextBox1 = New TextBox()
        Button1 = New Button()
        Button2 = New Button()
        ListBox1 = New ListBox()
        Label1 = New Label()
        T1 = New Timer(components)
        StatusStrip1 = New StatusStrip()
        TSLabel1 = New ToolStripStatusLabel()
        PB1 = New PictureBox()
        StatusStrip1.SuspendLayout()
        CType(PB1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(153, 49)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(244, 30)
        TextBox1.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.FlatStyle = FlatStyle.System
        Button1.Location = New Point(425, 40)
        Button1.Name = "Button1"
        Button1.Size = New Size(145, 48)
        Button1.TabIndex = 1
        Button1.Text = "开始计算"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.FlatStyle = FlatStyle.System
        Button2.Location = New Point(425, 187)
        Button2.Name = "Button2"
        Button2.Size = New Size(145, 48)
        Button2.TabIndex = 3
        Button2.Text = "r"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' ListBox1
        ' 
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 24
        ListBox1.Location = New Point(50, 168)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(347, 292)
        ListBox1.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(47, 52)
        Label1.Name = "Label1"
        Label1.Size = New Size(100, 24)
        Label1.TabIndex = 5
        Label1.Text = "起始坐标："
        ' 
        ' T1
        ' 
        T1.Interval = 1000
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(24, 24)
        StatusStrip1.Items.AddRange(New ToolStripItem() {TSLabel1})
        StatusStrip1.Location = New Point(0, 490)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(1270, 31)
        StatusStrip1.TabIndex = 6
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' TSLabel1
        ' 
        TSLabel1.Name = "TSLabel1"
        TSLabel1.Size = New Size(82, 24)
        TSLabel1.Text = "等待开始"
        ' 
        ' PB1
        ' 
        PB1.Image = My.Resources.Resources.bac
        PB1.Location = New Point(619, 7)
        PB1.Name = "PB1"
        PB1.Size = New Size(480, 480)
        PB1.TabIndex = 7
        PB1.TabStop = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(11F, 24F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1270, 521)
        Controls.Add(PB1)
        Controls.Add(StatusStrip1)
        Controls.Add(Label1)
        Controls.Add(ListBox1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(TextBox1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "马踏棋盘"
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        CType(PB1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents T1 As Timer
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents TSLabel1 As ToolStripStatusLabel
    Friend WithEvents PB1 As PictureBox
End Class
