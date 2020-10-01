Imports Emgu.CV
Imports Emgu.Util
Imports Emgu.CV.Structure
Public Class Form3
    Dim Max_Body_Player1 As Hsv
    Dim Max_Aim_Player1 As Hsv
    Dim Max_Shot_Player1 As Hsv
    Dim Min_Body_Player1 As Hsv
    Dim Min_Aim_Player1 As Hsv
    Dim Min_Shot_Player1 As Hsv

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Max_Body_Player1 = Form1.Hsv_Max_Body_Player2
        Min_Body_Player1 = Form1.Hsv_Min_Body_Player2

        Max_Aim_Player1 = Form1.Hsv_Max_Aim_Player2
        Min_Aim_Player1 = Form1.Hsv_Min_Aim_Player2

        Max_Shot_Player1 = Form1.Hsv_Max_Shot_Player2
        Min_Shot_Player1 = Form1.Hsv_Min_Shot_Player2

        Max_Body_H_Player1.Value = Max_Body_Player1.Hue
        Max_Body_S_Player1.Value = Max_Body_Player1.Satuation
        Max_Body_V_Player1.Value = Max_Body_Player1.Value
        Show_Max_Body_H_Player1.Text = Max_Body_Player1.Hue
        Show_Max_Body_S_Player1.Text = Max_Body_Player1.Satuation
        Show_Max_Body_V_Player1.Text = Max_Body_Player1.Value

        Max_Aim_H_Player1.Value = Max_Aim_Player1.Hue
        Max_Aim_S_Player1.Value = Max_Aim_Player1.Satuation
        Max_Aim_V_Player1.Value = Max_Aim_Player1.Value
        Show_Max_Aim_H_Player1.Text = Max_Aim_Player1.Hue
        Show_Max_Aim_S_Player1.Text = Max_Aim_Player1.Satuation
        Show_Max_Aim_V_Player1.Text = Max_Aim_V_Player1.Value


        Max_Shot_H_Player1.Value = Max_Shot_Player1.Hue
        Max_Shot_S_Player1.Value = Max_Shot_Player1.Satuation
        Max_Shot_V_Player1.Value = Max_Shot_Player1.Value
        Show_Max_Shot_H_Player1.Text = Max_Shot_Player1.Hue
        Show_Max_Shot_S_Player1.Text = Max_Shot_Player1.Satuation
        Show_Max_Shot_V_Player1.Text = Max_Shot_Player1.Value


        Min_Body_H_Player1.Value = Min_Body_Player1.Hue
        Min_Body_S_Player1.Value = Min_Body_Player1.Satuation
        Min_Body_V_Player1.Value = Min_Body_Player1.Value
        Show_Min_Body_H_Player1.Text = Min_Body_Player1.Hue
        Show_Min_Body_S_Player1.Text = Min_Body_Player1.Satuation
        Show_Min_Body_V_Player1.Text = Min_Body_Player1.Value

        Min_Aim_H_Player1.Value = Min_Aim_Player1.Hue
        Min_Aim_S_Player1.Value = Min_Aim_Player1.Satuation
        Min_Aim_V_Player1.Value = Min_Aim_Player1.Value
        Show_Min_Aim_H_Player1.Text = Min_Aim_Player1.Hue
        Show_Min_Aim_S_Player1.Text = Min_Aim_Player1.Satuation
        Show_Min_Aim_V_Player1.Text = Min_Aim_Player1.Value

        Min_Shot_H_Player1.Value = Min_Shot_Player1.Hue
        Min_Shot_S_Player1.Value = Min_Shot_Player1.Satuation
        Min_Shot_V_Player1.Value = Min_Shot_Player1.Value
        Show_Min_Shot_H_Player1.Text = Min_Shot_Player1.Hue
        Show_Min_Shot_S_Player1.Text = Min_Shot_Player1.Satuation
        Show_Min_Shot_V_Player1.Text = Min_Shot_Player1.Value
    End Sub

    '設定裝甲，準心，射擊的hsv
    Private Sub Hsv_Max_Body_Player1_Scroll(sender As Object, e As EventArgs) Handles Max_Body_H_Player1.Scroll, Max_Body_S_Player1.Scroll, Max_Body_V_Player1.Scroll,
        Max_Aim_H_Player1.Scroll, Max_Aim_S_Player1.Scroll, Max_Aim_V_Player1.Scroll,
        Max_Shot_H_Player1.Scroll, Max_Shot_S_Player1.Scroll, Max_Shot_V_Player1.Scroll,
        Min_Body_H_Player1.Scroll, Min_Body_S_Player1.Scroll, Min_Body_V_Player1.Scroll,
        Min_Aim_H_Player1.Scroll, Min_Aim_S_Player1.Scroll, Min_Aim_V_Player1.Scroll,
        Min_Shot_H_Player1.Scroll, Min_Shot_S_Player1.Scroll, Min_Shot_V_Player1.Scroll
        Select Case CType(sender, TrackBar).Name
            Case Max_Body_H_Player1.Name
                Max_Body_Player1.Hue = Max_Body_H_Player1.Value
                Show_Max_Body_H_Player1.Text = Max_Body_H_Player1.Value
            Case Max_Body_S_Player1.Name
                Max_Body_Player1.Satuation = Max_Body_S_Player1.Value
                Show_Max_Body_S_Player1.Text = Max_Body_S_Player1.Value
            Case Max_Body_V_Player1.Name
                Max_Body_Player1.Value = Max_Body_V_Player1.Value
                Show_Max_Body_V_Player1.Text = Max_Body_V_Player1.Value


            Case Max_Aim_H_Player1.Name
                Max_Aim_Player1.Hue = Max_Aim_H_Player1.Value
                Show_Max_Aim_H_Player1.Text = Max_Aim_H_Player1.Value
            Case Max_Aim_S_Player1.Name
                Max_Aim_Player1.Satuation = Max_Aim_S_Player1.Value
                Show_Max_Aim_S_Player1.Text = Max_Aim_S_Player1.Value
            Case Max_Aim_V_Player1.Name
                Max_Aim_Player1.Value = Max_Aim_V_Player1.Value
                Show_Max_Aim_V_Player1.Text = Max_Aim_V_Player1.Value


            Case Max_Shot_H_Player1.Name
                Max_Shot_Player1.Hue = Max_Shot_H_Player1.Value
                Show_Max_Shot_H_Player1.Text = Max_Shot_H_Player1.Value
            Case Max_Shot_S_Player1.Name
                Max_Shot_Player1.Satuation = Max_Shot_S_Player1.Value
                Show_Max_Shot_S_Player1.Text = Max_Shot_S_Player1.Value
            Case Max_Shot_V_Player1.Name
                Max_Shot_Player1.Value = Max_Shot_V_Player1.Value
                Show_Max_Shot_V_Player1.Text = Max_Shot_V_Player1.Value



            Case Min_Body_H_Player1.Name
                Min_Body_Player1.Hue = Min_Body_H_Player1.Value
                Show_Min_Body_H_Player1.Text = Min_Body_H_Player1.Value
            Case Min_Body_S_Player1.Name
                Min_Body_Player1.Satuation = Min_Body_S_Player1.Value
                Show_Min_Body_S_Player1.Text = Min_Body_S_Player1.Value
            Case Min_Body_V_Player1.Name
                Min_Body_Player1.Value = Min_Body_V_Player1.Value
                Show_Min_Body_V_Player1.Text = Min_Body_V_Player1.Value


            Case Min_Aim_H_Player1.Name
                Min_Aim_Player1.Hue = Min_Aim_H_Player1.Value
                Show_Min_Aim_H_Player1.Text = Min_Aim_H_Player1.Value
            Case Min_Aim_S_Player1.Name
                Min_Aim_Player1.Satuation = Min_Aim_S_Player1.Value
                Show_Min_Aim_S_Player1.Text = Min_Aim_S_Player1.Value
            Case Min_Aim_V_Player1.Name
                Min_Aim_Player1.Value = Min_Aim_V_Player1.Value
                Show_Min_Aim_V_Player1.Text = Min_Aim_V_Player1.Value

            Case Min_Shot_H_Player1.Name
                Min_Shot_Player1.Hue = Min_Shot_H_Player1.Value
                Show_Min_Shot_H_Player1.Text = Min_Shot_H_Player1.Value
            Case Min_Shot_S_Player1.Name
                Min_Shot_Player1.Satuation = Min_Shot_S_Player1.Value
                Show_Min_Shot_S_Player1.Text = Min_Shot_S_Player1.Value
            Case Min_Shot_V_Player1.Name
                Min_Shot_Player1.Value = Min_Shot_V_Player1.Value
                Show_Min_Shot_V_Player1.Text = Min_Shot_V_Player1.Value

        End Select
        Form1.Hsv_Max_Body_Player2 = Max_Body_Player1
        Form1.Hsv_Min_Body_Player2 = Min_Body_Player1

        Form1.Hsv_Max_Aim_Player2 = Max_Aim_Player1
        Form1.Hsv_Min_Aim_Player2 = Min_Aim_Player1

        Form1.Hsv_Max_Shot_Player2 = Max_Shot_Player1
        Form1.Hsv_Min_Shot_Player2 = Min_Shot_Player1
    End Sub


End Class