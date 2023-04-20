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
        TSPB1 = New ToolStripProgressBar()
        PB1 = New PictureBox()
        T2 = New Timer(components)
        TrackBar1 = New TrackBar()
        ToolTip1 = New ToolTip(components)
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        StatusStrip1.SuspendLayout()
        CType(PB1, ComponentModel.ISupportInitialize).BeginInit()
        CType(TrackBar1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(122, 19)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(122, 30)
        TextBox1.TabIndex = 0
        ToolTip1.SetToolTip(TextBox1, "可直接点击棋盘。")
        ' 
        ' Button1
        ' 
        Button1.FlatStyle = FlatStyle.System
        Button1.Location = New Point(137, 64)
        Button1.Name = "Button1"
        Button1.Size = New Size(107, 39)
        Button1.TabIndex = 1
        Button1.Text = "开始计算"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Enabled = False
        Button2.FlatStyle = FlatStyle.System
        Button2.Location = New Point(655, 42)
        Button2.Name = "Button2"
        Button2.Size = New Size(107, 39)
        Button2.TabIndex = 3
        Button2.Text = "演示"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' ListBox1
        ' 
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 24
        ListBox1.Location = New Point(34, 138)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(208, 436)
        ListBox1.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(34, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(82, 24)
        Label1.TabIndex = 5
        Label1.Text = "起始坐标"
        ' 
        ' T1
        ' 
        T1.Interval = 1000
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(24, 24)
        StatusStrip1.Items.AddRange(New ToolStripItem() {TSLabel1, TSPB1})
        StatusStrip1.Location = New Point(0, 592)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(806, 31)
        StatusStrip1.TabIndex = 6
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' TSLabel1
        ' 
        TSLabel1.Name = "TSLabel1"
        TSLabel1.Size = New Size(82, 24)
        TSLabel1.Text = "等待开始"
        ' 
        ' TSPB1
        ' 
        TSPB1.Maximum = 64
        TSPB1.Name = "TSPB1"
        TSPB1.Size = New Size(150, 23)
        TSPB1.Step = 1
        TSPB1.Style = ProgressBarStyle.Continuous
        ' 
        ' PB1
        ' 
        PB1.Image = My.Resources.Resources.bac
        PB1.Location = New Point(282, 94)
        PB1.Name = "PB1"
        PB1.Size = New Size(480, 480)
        PB1.TabIndex = 7
        PB1.TabStop = False
        ' 
        ' T2
        ' 
        T2.Interval = 200
        ' 
        ' TrackBar1
        ' 
        TrackBar1.Location = New Point(370, 42)
        TrackBar1.Maximum = 20
        TrackBar1.Minimum = 1
        TrackBar1.Name = "TrackBar1"
        TrackBar1.Size = New Size(188, 69)
        TrackBar1.TabIndex = 8
        TrackBar1.Value = 6
        ' 
        ' ToolTip1
        ' 
        ToolTip1.AutoPopDelay = 5000
        ToolTip1.InitialDelay = 150
        ToolTip1.ReshowDelay = 100
        ToolTip1.ToolTipIcon = ToolTipIcon.Info
        ToolTip1.ToolTipTitle = "提示"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(34, 106)
        Label2.Name = "Label2"
        Label2.Size = New Size(46, 24)
        Label2.TabIndex = 9
        Label2.Text = "路径"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(282, 49)
        Label3.Name = "Label3"
        Label3.Size = New Size(82, 24)
        Label3.TabIndex = 10
        Label3.Text = "演示速率"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(564, 49)
        Label4.Name = "Label4"
        Label4.Size = New Size(70, 24)
        Label4.TabIndex = 11
        Label4.Text = "3 步/秒"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(11F, 24F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(806, 623)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(PB1)
        Controls.Add(StatusStrip1)
        Controls.Add(Label1)
        Controls.Add(ListBox1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(TextBox1)
        Controls.Add(TrackBar1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "马踏棋盘"
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        CType(PB1, ComponentModel.ISupportInitialize).EndInit()
        CType(TrackBar1, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents T2 As Timer
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents TSPB1 As ToolStripProgressBar
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
