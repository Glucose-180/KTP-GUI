Module Display
    Public StepCount As Integer
    Public StepsX(Form1.DSIZE), StepsY(Form1.DSIZE) As Integer
    Public Img As Image
    Public Gra As Graphics

    Public Sub Init()
        Dim BrB As New SolidBrush(Color.FromArgb(&HFF00FFFF))
        StepCount = 1
        Form1.DrawEmptyBoard()
        Img = Form1.PB1.Image
        Gra = Graphics.FromImage(Img)
        Gra.TranslateTransform(0, Form1.PB1.Height)
        Gra.ScaleTransform(1, -1)
        Gra.FillEllipse(BrB, StepsX(0) * Form1.CELLSIZE + Form1.CELLSIZE \ 2 - 10, StepsY(0) * Form1.CELLSIZE + Form1.CELLSIZE \ 2 - 10, 20, 20)
        Gra.Flush()
        Form1.PB1.Image = Img
        Form1.TSLabel1.Text = "正在演示，第 " & StepCount & " 步…"
        Form1.TSPB1.Value = StepCount
    End Sub

    Public Sub DrawStep()
        Dim P As New Pen(Color.FromArgb(&HFF00FF00))
        Dim BrG As New SolidBrush(Color.FromArgb(&HFF00FF00))
        Dim BrR As New SolidBrush(Color.Red)
        Dim hx, hy, tx, ty As Integer
        P.Width = 5
        hx = StepsX(StepCount) * Form1.CELLSIZE + Form1.CELLSIZE \ 2
        hy = StepsY(StepCount) * Form1.CELLSIZE + Form1.CELLSIZE \ 2
        tx = StepsX(StepCount - 1) * Form1.CELLSIZE + Form1.CELLSIZE \ 2
        ty = StepsY(StepCount - 1) * Form1.CELLSIZE + Form1.CELLSIZE \ 2
        Gra.DrawLine(P, tx, ty, hx, hy)
        StepCount += 1
        If StepCount = Form1.DSIZE Then
            Gra.FillEllipse(BrR, hx - 10, hy - 10, 20, 20)
        Else
            Gra.FillEllipse(BrG, hx - 10, hy - 10, 20, 20)
        End If
        Gra.Flush()
        Form1.PB1.Image = Img
    End Sub
End Module
