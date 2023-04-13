Imports System.IO.MemoryMappedFiles
Public Class Form1
    Dim SmemIsOpen As Boolean
    Dim mmf_cmd, mmf_dat As MemoryMappedFile
    Dim macc_cmd, macc_dat As MemoryMappedViewAccessor
    Const DSIZE = 64

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SmemIsOpen = False
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
            SmemIsOpen = False
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If SmemIsOpen = False Then
            Call Smem_Open("ktp_cmd_g", "ktp_dat_g")
        End If
        If SmemIsOpen = True Then
            WriteCmd(TextBox1.Text)
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
End Class
