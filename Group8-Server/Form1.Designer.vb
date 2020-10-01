<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Btn_StartRun = New System.Windows.Forms.Button()
        Me.List_NowIP = New System.Windows.Forms.ComboBox()
        Me.Text_NowIP = New System.Windows.Forms.Label()
        Me.Show_ServerStatus = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Show_Status = New System.Windows.Forms.Label()
        Me.Btn_RsetServer = New System.Windows.Forms.Button()
        Me.Img_Player1 = New Emgu.CV.UI.ImageBox()
        Me.Img_Player2 = New Emgu.CV.UI.ImageBox()
        Me.Play1_Body_Hsv = New Emgu.CV.UI.ImageBox()
        Me.Play2_Body_Hsv = New Emgu.CV.UI.ImageBox()
        Me.Play1_Aim_Hsv = New Emgu.CV.UI.ImageBox()
        Me.Play2_Aim_Hsv = New Emgu.CV.UI.ImageBox()
        Me.Play1_Shot_Hsv = New Emgu.CV.UI.ImageBox()
        Me.Play2_Shot_Hsv = New Emgu.CV.UI.ImageBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Btn_Player1_Hsv_Setting = New System.Windows.Forms.Button()
        Me.Round_Time = New System.Windows.Forms.Timer(Me.components)
        Me.Btn_Player2_Hsv_Setting = New System.Windows.Forms.Button()
        CType(Me.Img_Player1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Img_Player2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Play1_Body_Hsv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Play2_Body_Hsv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Play1_Aim_Hsv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Play2_Aim_Hsv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Play1_Shot_Hsv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Play2_Shot_Hsv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_StartRun
        '
        Me.Btn_StartRun.Location = New System.Drawing.Point(16, 628)
        Me.Btn_StartRun.Name = "Btn_StartRun"
        Me.Btn_StartRun.Size = New System.Drawing.Size(122, 44)
        Me.Btn_StartRun.TabIndex = 0
        Me.Btn_StartRun.Text = "StartRun"
        Me.Btn_StartRun.UseVisualStyleBackColor = True
        '
        'List_NowIP
        '
        Me.List_NowIP.FormattingEnabled = True
        Me.List_NowIP.Location = New System.Drawing.Point(73, 10)
        Me.List_NowIP.Name = "List_NowIP"
        Me.List_NowIP.Size = New System.Drawing.Size(163, 23)
        Me.List_NowIP.TabIndex = 1
        '
        'Text_NowIP
        '
        Me.Text_NowIP.AutoSize = True
        Me.Text_NowIP.Location = New System.Drawing.Point(13, 13)
        Me.Text_NowIP.Name = "Text_NowIP"
        Me.Text_NowIP.Size = New System.Drawing.Size(54, 15)
        Me.Text_NowIP.TabIndex = 2
        Me.Text_NowIP.Text = "當前IP:"
        '
        'Show_ServerStatus
        '
        Me.Show_ServerStatus.Location = New System.Drawing.Point(787, 29)
        Me.Show_ServerStatus.Multiline = True
        Me.Show_ServerStatus.Name = "Show_ServerStatus"
        Me.Show_ServerStatus.Size = New System.Drawing.Size(429, 454)
        Me.Show_ServerStatus.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(512, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "當前狀態"
        '
        'Show_Status
        '
        Me.Show_Status.AutoSize = True
        Me.Show_Status.Location = New System.Drawing.Point(145, 641)
        Me.Show_Status.Name = "Show_Status"
        Me.Show_Status.Size = New System.Drawing.Size(127, 15)
        Me.Show_Status.TabIndex = 5
        Me.Show_Status.Text = "當前狀態：未開啟"
        '
        'Btn_RsetServer
        '
        Me.Btn_RsetServer.Enabled = False
        Me.Btn_RsetServer.Location = New System.Drawing.Point(16, 678)
        Me.Btn_RsetServer.Name = "Btn_RsetServer"
        Me.Btn_RsetServer.Size = New System.Drawing.Size(82, 40)
        Me.Btn_RsetServer.TabIndex = 7
        Me.Btn_RsetServer.Text = "RsetServer"
        Me.Btn_RsetServer.UseVisualStyleBackColor = True
        '
        'Img_Player1
        '
        Me.Img_Player1.Location = New System.Drawing.Point(16, 61)
        Me.Img_Player1.Name = "Img_Player1"
        Me.Img_Player1.Size = New System.Drawing.Size(305, 134)
        Me.Img_Player1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Img_Player1.TabIndex = 2
        Me.Img_Player1.TabStop = False
        '
        'Img_Player2
        '
        Me.Img_Player2.Location = New System.Drawing.Point(461, 61)
        Me.Img_Player2.Name = "Img_Player2"
        Me.Img_Player2.Size = New System.Drawing.Size(305, 134)
        Me.Img_Player2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Img_Player2.TabIndex = 2
        Me.Img_Player2.TabStop = False
        '
        'Play1_Body_Hsv
        '
        Me.Play1_Body_Hsv.Location = New System.Drawing.Point(16, 201)
        Me.Play1_Body_Hsv.Name = "Play1_Body_Hsv"
        Me.Play1_Body_Hsv.Size = New System.Drawing.Size(305, 125)
        Me.Play1_Body_Hsv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Play1_Body_Hsv.TabIndex = 2
        Me.Play1_Body_Hsv.TabStop = False
        '
        'Play2_Body_Hsv
        '
        Me.Play2_Body_Hsv.Location = New System.Drawing.Point(461, 201)
        Me.Play2_Body_Hsv.Name = "Play2_Body_Hsv"
        Me.Play2_Body_Hsv.Size = New System.Drawing.Size(305, 125)
        Me.Play2_Body_Hsv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Play2_Body_Hsv.TabIndex = 2
        Me.Play2_Body_Hsv.TabStop = False
        '
        'Play1_Aim_Hsv
        '
        Me.Play1_Aim_Hsv.Location = New System.Drawing.Point(16, 332)
        Me.Play1_Aim_Hsv.Name = "Play1_Aim_Hsv"
        Me.Play1_Aim_Hsv.Size = New System.Drawing.Size(305, 125)
        Me.Play1_Aim_Hsv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Play1_Aim_Hsv.TabIndex = 2
        Me.Play1_Aim_Hsv.TabStop = False
        '
        'Play2_Aim_Hsv
        '
        Me.Play2_Aim_Hsv.Location = New System.Drawing.Point(461, 332)
        Me.Play2_Aim_Hsv.Name = "Play2_Aim_Hsv"
        Me.Play2_Aim_Hsv.Size = New System.Drawing.Size(305, 125)
        Me.Play2_Aim_Hsv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Play2_Aim_Hsv.TabIndex = 2
        Me.Play2_Aim_Hsv.TabStop = False
        '
        'Play1_Shot_Hsv
        '
        Me.Play1_Shot_Hsv.Location = New System.Drawing.Point(16, 463)
        Me.Play1_Shot_Hsv.Name = "Play1_Shot_Hsv"
        Me.Play1_Shot_Hsv.Size = New System.Drawing.Size(305, 125)
        Me.Play1_Shot_Hsv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Play1_Shot_Hsv.TabIndex = 2
        Me.Play1_Shot_Hsv.TabStop = False
        '
        'Play2_Shot_Hsv
        '
        Me.Play2_Shot_Hsv.Location = New System.Drawing.Point(461, 463)
        Me.Play2_Shot_Hsv.Name = "Play2_Shot_Hsv"
        Me.Play2_Shot_Hsv.Size = New System.Drawing.Size(305, 125)
        Me.Play2_Shot_Hsv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Play2_Shot_Hsv.TabIndex = 2
        Me.Play2_Shot_Hsv.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Btn_Player1_Hsv_Setting
        '
        Me.Btn_Player1_Hsv_Setting.Location = New System.Drawing.Point(1025, 678)
        Me.Btn_Player1_Hsv_Setting.Name = "Btn_Player1_Hsv_Setting"
        Me.Btn_Player1_Hsv_Setting.Size = New System.Drawing.Size(92, 40)
        Me.Btn_Player1_Hsv_Setting.TabIndex = 8
        Me.Btn_Player1_Hsv_Setting.Text = "玩家1Hsv"
        Me.Btn_Player1_Hsv_Setting.UseVisualStyleBackColor = True
        '
        'Btn_Player2_Hsv_Setting
        '
        Me.Btn_Player2_Hsv_Setting.Location = New System.Drawing.Point(1133, 678)
        Me.Btn_Player2_Hsv_Setting.Name = "Btn_Player2_Hsv_Setting"
        Me.Btn_Player2_Hsv_Setting.Size = New System.Drawing.Size(92, 40)
        Me.Btn_Player2_Hsv_Setting.TabIndex = 8
        Me.Btn_Player2_Hsv_Setting.Text = "玩家2Hsv"
        Me.Btn_Player2_Hsv_Setting.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1237, 728)
        Me.Controls.Add(Me.Btn_Player2_Hsv_Setting)
        Me.Controls.Add(Me.Btn_Player1_Hsv_Setting)
        Me.Controls.Add(Me.Play2_Shot_Hsv)
        Me.Controls.Add(Me.Play2_Aim_Hsv)
        Me.Controls.Add(Me.Play2_Body_Hsv)
        Me.Controls.Add(Me.Play1_Shot_Hsv)
        Me.Controls.Add(Me.Play1_Aim_Hsv)
        Me.Controls.Add(Me.Play1_Body_Hsv)
        Me.Controls.Add(Me.Img_Player2)
        Me.Controls.Add(Me.Img_Player1)
        Me.Controls.Add(Me.Btn_RsetServer)
        Me.Controls.Add(Me.Show_Status)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Show_ServerStatus)
        Me.Controls.Add(Me.Text_NowIP)
        Me.Controls.Add(Me.List_NowIP)
        Me.Controls.Add(Me.Btn_StartRun)
        Me.Name = "Form1"
        CType(Me.Img_Player1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Img_Player2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Play1_Body_Hsv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Play2_Body_Hsv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Play1_Aim_Hsv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Play2_Aim_Hsv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Play1_Shot_Hsv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Play2_Shot_Hsv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_StartRun As Button
    Friend WithEvents List_NowIP As ComboBox
    Friend WithEvents Text_NowIP As Label
    Friend WithEvents Show_ServerStatus As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Show_Status As Label
    Friend WithEvents Btn_RsetServer As Button
    Friend WithEvents Img_Player1 As Emgu.CV.UI.ImageBox
    Friend WithEvents Img_Player2 As Emgu.CV.UI.ImageBox
    Friend WithEvents Play1_Body_Hsv As Emgu.CV.UI.ImageBox
    Friend WithEvents Play2_Body_Hsv As Emgu.CV.UI.ImageBox
    Friend WithEvents Play1_Aim_Hsv As Emgu.CV.UI.ImageBox
    Friend WithEvents Play2_Aim_Hsv As Emgu.CV.UI.ImageBox
    Friend WithEvents Play1_Shot_Hsv As Emgu.CV.UI.ImageBox
    Friend WithEvents Play2_Shot_Hsv As Emgu.CV.UI.ImageBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Btn_Player1_Hsv_Setting As Button
    Friend WithEvents Round_Time As Timer
    Friend WithEvents Btn_Player2_Hsv_Setting As Button
End Class
