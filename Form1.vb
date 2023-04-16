﻿Imports System.ComponentModel
Imports System.IO.MemoryMappedFiles
Public Class Form1
    Dim CalcTime As Integer
    Dim SmemIsOpen As Boolean
    Dim mmf_cmd, mmf_dat As MemoryMappedFile
    Dim macc_cmd, macc_dat As MemoryMappedViewAccessor
    Dim CLI_Started As Boolean
    Const DSIZE = 64
    Const CELLSIZE = 60

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SmemIsOpen = False
        DrawBoard()
        Start_CLI()
    End Sub

    Public Sub Smem_Open(ByVal Name_cmd As String, ByVal Name_dat As String)
        Try
            mmf_cmd = MemoryMappedFile.OpenExisting(Name_cmd)
            mmf_dat = MemoryMappedFile.OpenExisting(Name_dat)
            macc_cmd = mmf_cmd.CreateViewAccessor
            macc_dat = mmf_dat.CreateViewAccessor
            SmemIsOpen = True
        Catch ex As Exception
            MsgBox("打开内存映射文件失败：" & vbCrLf & ex.ToString, 16, "Error")
            If MsgBox("是否重启计算程序？", vbYesNo + vbQuestion, "") = vbYes Then
                Kill_CLI()
                System.Threading.Thread.Sleep(300)
                Start_CLI()
                System.Threading.Thread.Sleep(1000)
            End If
            SmemIsOpen = False
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If T1.Enabled = False Then
            If CLI_Started = False Then
                Button1.Text = "启动中"
                Button1.Enabled = False
                Start_CLI()
                System.Threading.Thread.Sleep(2000)
                Button1.Enabled = True
                Button1.Text = "开始计算"
            End If
            If SmemIsOpen = False Then
                Call Smem_Open("ktp_cmd_g", "ktp_dat_g")
            End If
            If SmemIsOpen = True Then
                Try
                    WriteCmd("Start " & TextBox1.Text)
                    Button1.Text = "终止"
                    CalcTime = 0
                    T1.Enabled = True
                Catch ex As Exception
                    MsgBox(ex.ToString, 16, "Error")
                End Try
            End If
        Else
            Kill_CLI()
            TSLabel1.Text = "已终止，共运行 " & CalcTime & " s。"
            Button1.Text = "开始计算"
        End If
    End Sub

    Public Sub Smem_Close()
        If SmemIsOpen = True Then
            mmf_cmd.Dispose()
            mmf_dat.Dispose()
            SmemIsOpen = False
        End If
    End Sub

    Public Sub WriteCmd(ByRef cmd As String)
        Dim i As Integer
        For i = 0 To cmd.Length - 1
            macc_cmd.Write(Of Byte)(i, AscW(cmd.ElementAt(i)))
        Next
        macc_cmd.Write(Of Byte)(i + 1, 0)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim data(DSIZE) As Int32
        Dim i As Int32
        If SmemIsOpen = False Then
            MsgBox("错误：内存映射文件未打开！", 48, "Error")
            Exit Sub
        End If
        TextBox1.Text = ReadCmd(DSIZE)
        data = ReadData(DSIZE)
        ListBox1.Items.Clear()
        For i = 0 To DSIZE - 1
            ListBox1.Items.Add(data(i) \ 100 & vbTab & data(i) Mod 100)
        Next
    End Sub

    Public Function ReadCmd(ByVal Size As Integer) As String
        Dim cmd As String
        Dim buf(Size) As Byte
        Dim i As Integer
        cmd = ""
        Try
            macc_cmd.ReadArray(Of Byte)(0, buf, 0, Size)
            For i = 0 To Size - 1
                If buf(i) = 0 Then
                    Exit For
                End If
                cmd &= Chr(buf(i))
            Next
        Catch ex As Exception
            T1.Enabled = False
            MsgBox(ex.ToString, 16, "Error")
        End Try
        Return cmd
    End Function

    Public Function ReadData(ByVal Size As Integer) As Int32()
        Dim data(Size) As Int32
        data(0) = 0
        Try
            macc_dat.ReadArray(Of Int32)(0, data, 0, Size)
        Catch ex As Exception
            MsgBox(ex.ToString, 16, "Error")
        End Try
        Return data
    End Function

    Private Sub T1_Tick(sender As Object, e As EventArgs) Handles T1.Tick
        Dim cmd As String
        Dim data(DSIZE) As Int32
        Dim i As Int32

        cmd = ReadCmd(DSIZE)
        If cmd = "Done" Then
            T1.Enabled = False
            data = ReadData(DSIZE)
            ListBox1.Items.Clear()
            For i = 0 To DSIZE - 1
                ListBox1.Items.Add(data(i) \ 100 & vbTab & data(i) Mod 100)
            Next
            TSLabel1.Text = "计算完成，耗时 " & CalcTime & " s！"
            CalcTime = 0
            Button1.Text = "开始计算"
        ElseIf cmd = "Error" Then
            T1.Enabled = False
            data = ReadData(1)
            If data(0) = -1 Or data(0) = -2 Then
                TSLabel1.Text = "错误：无效输入。"
                MsgBox("错误：无效输入！", 16, "Error")
            ElseIf data(0) = 1 Then
                TSLabel1.Text = "计算完成，无解。"
                MsgBox("计算完成，无解！", 64, "")
            Else
                TSLabel1.Text = "错误：" & data(0)
                MsgBox("错误：代码为 " & data(0), 16, "Error")
            End If
            Button1.Text = "开始计算"
        Else
            CalcTime += 1
            TSLabel1.Text = "计算中，已耗时 " & CalcTime & " s……"
        End If
    End Sub

    Public Sub Start_CLI()
        Dim Path As String
        Try
            Path = Application.StartupPath
            If Path(Path.Length - 1) <> "\" Then
                Path &= "\"
            End If
            Path &= "KTP-CLI.bat"
            Shell(Path, vbMinimizedNoFocus)
            CLI_Started = True
        Catch ex As Exception
            MsgBox(ex.ToString, 16, "Error")
        End Try
    End Sub

    Public Sub Kill_CLI()
        T1.Enabled = False
        Smem_Close()
        Shell("cmd /c taskkill /f /im KTP-CLI.exe", vbMinimizedNoFocus)
        CLI_Started = False
        SmemIsOpen = False
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        Kill_CLI()
    End Sub

    Private Sub DrawBoard()
        Dim I As Image
        Dim G As Graphics
        Dim P As New Pen(Color.Black)
        Dim Br As New SolidBrush(Color.Black)
        Dim k As Integer
        Dim x, y As Integer

        I = PB1.Image
        G = Graphics.FromImage(I)
        G.TranslateTransform(0, PB1.Height)
        G.ScaleTransform(1, -1)
        ' Draw Lines
        For k = 1 To 7
            G.DrawLine(P, 0, k * CELLSIZE, 8 * CELLSIZE, k * CELLSIZE)
            G.DrawLine(P, k * CELLSIZE, 0, k * CELLSIZE, 8 * CELLSIZE)
        Next
        ' Fill Cells
        For y = 0 To 7
            For x = 0 To 7
                If (x + y) Mod 2 = 0 Then
                    G.FillRectangle(Br, x * CELLSIZE, y * CELLSIZE, CELLSIZE, CELLSIZE)
                End If
            Next
        Next
        G.Dispose()
        PB1.Image = I
    End Sub
End Class
