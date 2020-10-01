Imports Emgu.CV
Imports Emgu.Util
Imports Emgu.CV.Structure
Imports System.Threading
Imports System.Text
Imports System.Net
Imports System.Net.Sockets
Imports System.ComponentModel
Imports System.IO

Public Class Form1
    Dim TcpServe As TcpListener
    '存放玩家服務的執行緒
    Dim Array_PlayThread As New ArrayList
    '存放玩家的物件
    Public Array_Client As New ArrayList
    Dim AcceptThread As Thread

    Dim ProcessImageThread As Thread

    '要濾掉的HSV值
    Public Hsv_Max_Body_Player1 As New Hsv(180, 256, 256)
    Public Hsv_Max_Aim_Player1 As New Hsv(92.9, 256, 256)
    Public Hsv_Max_Shot_Player1 As New Hsv(18.6, 255, 255)

    Public Hsv_Min_Body_Player1 As New Hsv(102.2, 156.5, 67.7)
    Public Hsv_Min_Aim_Player1 As New Hsv(60.4, 94.1, 67.7)
    Public Hsv_Min_Shot_Player1 As New Hsv(0, 145, 135)

    Public Hsv_Max_Body_Player2 As New Hsv(180, 256, 256)
    Public Hsv_Max_Aim_Player2 As New Hsv(92.9, 256, 256)
    Public Hsv_Max_Shot_Player2 As New Hsv(18.6, 255, 255)

    Public Hsv_Min_Body_Player2 As New Hsv(102.2, 156.5, 67.7)
    Public Hsv_Min_Aim_Player2 As New Hsv(60.4, 94.1, 67.7)
    Public Hsv_Min_Shot_Player2 As New Hsv(0, 145, 135)

    Delegate Sub SetServerStatusDel(tmpStr As String)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim LocalAdd() As IPAddress
        LocalAdd = Dns.GetHostAddresses(Dns.GetHostName)
        For i As Integer = 0 To UBound(LocalAdd)
            If (LocalAdd(i).ToString.IndexOf(".") <> -1) Then
                List_NowIP.Items.Add(LocalAdd(i))
            End If
        Next
        List_NowIP.SelectedIndex = List_NowIP.Items.Count - 1
        AddHandler Application.Idle, New EventHandler(AddressOf ProcessImage)
    End Sub

    Private Sub Btn_StartRun_Click(sender As Object, e As EventArgs) Handles Btn_StartRun.Click
        Try
            '建立Serve的IP
            Dim ServerIP As New IPEndPoint(IPAddress.Parse(List_NowIP.Text), "59487")
            TcpServe = New TcpListener(ServerIP) '開啟Server
            TcpServe.Start(2)
            Show_Status.Text = "當前狀態：已開啟"
            Show_ServerStatus.Text &= "伺服器已啟動　位置：" & TcpServe.LocalEndpoint.ToString & ControlChars.NewLine
            AcceptThread = New Thread(AddressOf ServerAcceptClient)
            AcceptThread.Start()
            Btn_StartRun.Enabled = False
            Btn_RsetServer.Enabled = True
        Catch ex As Exception
            'MessageBox.Show("Opps!出現狀況，無法架設伺服器" & ex.ToString, "Opps!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Console.WriteLine(ex.ToString)
        End Try
    End Sub





    '將接收到的圖片做處理並且做出相對應的回應
    Private Sub ProcessImage()
        'While True
        Dim Player1 As Player
        Dim Player2 As Player
        If (Array_Client.Count = 2) Then
            Player1 = Array_Client(0)
            Player2 = Array_Client(1)
            Player1.SendImage(Player1.Index)
            Player2.SendImage(Player2.Index)
            If (Array_Client(0).Ready <> True And Array_Client(1).Ready <> True) Then
                Exit Sub
            End If
        Else
            Exit Sub
        End If

        Try
            '存放玩家護甲的位置 以及開槍的位置及有無開槍
            Dim Player1_Armor() As Integer = {0, 0, 0, 0, 0, 0} 'min(0x,1y) max(2x,3y)
            Dim Player1_Aim As Point
            Dim Player1_Shot As New Point(-1, -1)
            Dim Player1_Rect As Rectangle '在玩家護甲上面貼上判定方塊
            Dim Player2_Armor() As Integer = {0, 0, 0, 0, 0, 0}
            Dim Player2_Aim As Point
            Dim Player2_Shot As New Point(-1, -1)
            Dim Player2_Rect As Rectangle


            '尋找玩家1的護甲、準心、開槍
            Player1_Armor = SerachPlayer(Array_Client(0), Hsv_Min_Body_Player1, Hsv_Max_Body_Player1, "Body")
            Player1_Aim = SerachPlayer(Array_Client(0), Hsv_Min_Aim_Player1, Hsv_Max_Aim_Player1, "Aim")
            Player1_Shot = SerachPlayer(Array_Client(0), Hsv_Min_Shot_Player1, Hsv_Max_Shot_Player1, "Shot")

            Player2_Armor = SerachPlayer(Array_Client(1), Hsv_Min_Body_Player2, Hsv_Max_Body_Player2, "Body")
            Player2_Aim = SerachPlayer(Array_Client(1), Hsv_Min_Aim_Player2, Hsv_Max_Aim_Player2, "Aim")
            Player2_Shot = SerachPlayer(Array_Client(1), Hsv_Min_Shot_Player2, Hsv_Max_Shot_Player2, "Shot")


            '有開槍且之前沒開過槍才做傷害判定
            '避免連續射擊
            If Player1_Aim.X = -1 And Player1_Shot.X <> -1 And Player1.Fire = False Then
                Dim msg() As Byte = Encoding.Default.GetBytes("SHOT")
                Player1.DataStream.Write(msg, 0, msg.Length)
                If Player1_Shot.X > Player2_Armor(0) And Player1_Shot.X < Player2_Armor(2) Then
                    If Player1_Shot.Y > Player2_Armor(1) And Player1_Shot.Y < Player2_Armor(3) Then
                        msg = Encoding.Default.GetBytes("HITS")
                        Player1.DataStream.Write(msg, 0, msg.Length)
                        msg = Encoding.Default.GetBytes("BHIT")
                        Player2.DataStream.Write(msg, 0, msg.Length)
                        Player2.Hp = Player2.Hp - 1
                    End If
                End If
                Player1.Fire = True
            End If

            If Player2_Aim.X = -1 And Player2_Shot.X <> -1 And Player2.Fire = False Then
                Dim msg() As Byte = Encoding.Default.GetBytes("SHOT")
                Player2.DataStream.Write(msg, 0, msg.Length)
                If Player2_Shot.X > Player1_Armor(0) And Player2_Shot.X < Player1_Armor(2) Then
                    If Player2_Shot.Y > Player1_Armor(1) And Player2_Shot.Y < Player1_Armor(3) Then
                        msg = Encoding.Default.GetBytes("HITS")
                        Player2.DataStream.Write(msg, 0, msg.Length)
                        msg = Encoding.Default.GetBytes("BHIT")
                        Player1.DataStream.Write(msg, 0, msg.Length)
                        Player1.Hp = Player1.Hp - 1
                    End If
                End If
                Player2.Fire = True
            End If
            '輸贏判斷
            If Player1.Hp = 0 And Player2.Hp = 0 Then
                Dim msg() As Byte = Encoding.Default.GetBytes("DRAW")
                Player1.DataStream.Write(msg, 0, msg.Length)
                Player2.DataStream.Write(msg, 0, msg.Length)
                RsetGame()
            ElseIf Player1.Hp = 0 Then
                Dim msg() As Byte = Encoding.Default.GetBytes("LOSE")
                Player1.DataStream.Write(msg, 0, msg.Length)
                msg = Encoding.Default.GetBytes("WINS")
                Player2.DataStream.Write(msg, 0, msg.Length)
                RsetGame()
            ElseIf Player2.Hp = 0 Then
                Dim msg() As Byte = Encoding.Default.GetBytes("WINS")
                Player1.DataStream.Write(msg, 0, msg.Length)
                msg = Encoding.Default.GetBytes("LOSE")
                Player2.DataStream.Write(msg, 0, msg.Length)
                RsetGame()
            End If

            'Console.WriteLine("X," & Player1_Armor(0) & " Y," & Player1_Armor(1) & " W," & Player1_Armor(2) & " B," & Player1_Armor(3))
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
        ' End While

    End Sub


    'Hsv(102.2, 140, 158), New Hsv(110, 256, 256) 身體區塊需要的數字
    Private Function SerachPlayer(TmpPlayer As Player, TmpHsvMin As Hsv, TmpHsvMax As Hsv, TmpStr As String)
        Try

            '尋找身體區塊
            Dim Player_Armor() As Integer = {99999, 99999, 0, 0}
            Dim Player_Contours As Emgu.CV.Util.VectorOfVectorOfPoint = New Emgu.CV.Util.VectorOfVectorOfPoint()
            Dim Player_AreaMax As Integer = Img_Player1.Width * Img_Player1.Height
            Dim Player_Center As New Point(-1, -1)
            Dim Player_Gray As Image(Of Gray, Byte)
            Player_Gray = TmpPlayer.Player_Image.InRange(TmpHsvMin, TmpHsvMax)
            Player_Gray._Erode(2)
            Player_Gray._Dilate(1)


            CvInvoke.FindContours(Player_Gray, Player_Contours, Nothing, CvEnum.RetrType.Ccomp, CvEnum.ChainApproxMethod.ChainApproxSimple)
            For i = 0 To Player_Contours.Size - 1
                Dim area As Integer = CvInvoke.ContourArea(Player_Contours(i))
                If area < Player_AreaMax / 30 Then
                    Continue For
                End If
                Dim r As New Rectangle
                r = CvInvoke.BoundingRectangle(Player_Contours(i))
                Player_Center = New Point((r.X + r.Right) / 2, (r.Y + r.Bottom) / 2)
                If (TmpStr <> "Body") Then
                    CvInvoke.Rectangle(TmpPlayer.Player_Image, r, New MCvScalar(0, 0, 255), 2)
                    CvInvoke.Circle(TmpPlayer.Player_Image, Player_Center, 1, New MCvScalar(255, 0, 0), 3)
                Else
                    r = New Rectangle(Player_Center.X - 150, Player_Center.Y - 150, 300, 300)
                    CvInvoke.Rectangle(TmpPlayer.Player_Image, r, New MCvScalar(0, 0, 255), 2)
                    Player_Armor(0) = r.X
                    Player_Armor(1) = r.Y
                    Player_Armor(2) = r.X + r.Width
                    Player_Armor(3) = r.Y + r.Height
                End If
            Next
            If (TmpPlayer.Index = 1) Then
                Img_Player1.Image = TmpPlayer.Player_Image
            ElseIf TmpPlayer.Index = 2 Then
                Img_Player2.Image = TmpPlayer.Player_Image
            End If


            '依據不同部位的判定回傳相關要求
            '護甲-回傳左上角點和右下角點
            '瞄準-回傳中心點
            '射擊-回傳true 或false表示有無開槍
            Select Case TmpStr
                Case "Body"
                    If TmpPlayer.Index = 1 Then
                        Play1_Body_Hsv.Image = Player_Gray
                    ElseIf TmpPlayer.Index = 2 Then
                        Play2_Body_Hsv.Image = Player_Gray
                    End If
                    Return Player_Armor
                Case "Aim"
                    If TmpPlayer.Index = 1 Then
                        Play1_Aim_Hsv.Image = Player_Gray
                    ElseIf TmpPlayer.Index = 2 Then
                        Play2_Aim_Hsv.Image = Player_Gray
                    End If
                    '有在瞄準則可以繼續攻擊
                    If Player_Center.X <> -1 Then
                        TmpPlayer.Fire = False
                    End If
                    Return Player_Center
                Case "Shot"
                    If TmpPlayer.Index = 1 Then
                        Play1_Shot_Hsv.Image = Player_Gray
                    ElseIf TmpPlayer.Index = 2 Then
                        Play2_Shot_Hsv.Image = Player_Gray
                    End If
                    '不等於-1則代表開槍
                    If Player_Center.X <> -1 Then
                        Return Player_Center
                    Else
                        Return New Point(-1, -1)
                    End If

            End Select

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Function


    '接受客戶端
    Private Sub ServerAcceptClient()
        Dim TcpPlayer As TcpClient
        Dim Play As Player
        Dim PlayerThread As Thread
        While True
            Try
                '將玩家資料接受，並且創造一個玩家物件
                TcpPlayer = TcpServe.AcceptTcpClient
                Play = New Player(TcpPlayer, Me)
                Play.DataStream = TcpPlayer.GetStream
                Play.Player_ID = "Player" & Array_Client.Count + 1
                Play.Index = Array_Client.Count + 1
                Array_Client.Add(Play)

                '建立玩家接收訊息的執行緒
                PlayerThread = New Thread(AddressOf Play.Player_Receive)
                PlayerThread.Start()
                Array_PlayThread.Add(PlayerThread)

                SetServerStatus(Play.Player_ID & " 以連線")
                If (Array_Client.Count = 2) Then
                    Exit While
                End If

            Catch ex As Exception
                'MessageBox.Show("Opps!出現狀況，無法接受玩家連線" & ex.ToString, "Opps!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Console.WriteLine(ex.ToString)
                Exit While
            End Try
        End While
    End Sub

    '顯示連線相關訊息
    Public Sub SetServerStatus(tmpStr As String)
        If Show_ServerStatus.InvokeRequired = True Then
            Dim d As New SetServerStatusDel(AddressOf SetServerStatus)
            Show_ServerStatus.Invoke(d, tmpStr)
        Else
            Show_ServerStatus.Text &= tmpStr & ControlChars.NewLine
        End If
    End Sub

    '重新設定遊戲
    Private Sub RsetGame()
        For i As Integer = 0 To Array_Client.Count - 1
            Dim TmpPlayer As Player = Array_Client(i)
            TmpPlayer.Hp = 10
            TmpPlayer.Ready = False
            TmpPlayer.Fire = True
            Timer1.Enabled = True
        Next
    End Sub

    '重新啟動伺服器
    Private Sub Btn_RestServer_Click(sender As Object, e As EventArgs) Handles Btn_RsetServer.Click
        For i As Integer = 0 To Array_Client.Count - 1
            CType(Array_Client(0), Player).TcpPlayer.Close()
            Array_PlayThread(0).Abort()
            Array_Client.RemoveAt(0)
            Array_PlayThread.RemoveAt(0)
        Next
        If Not TcpServe Is Nothing Then
            AcceptThread.Abort()
            TcpServe.Stop()
        End If
        Btn_StartRun_Click(sender, e)
        Timer1.Enabled = True
        Show_ServerStatus.Text &= "伺服器已經重新啟動了" & ControlChars.NewLine
    End Sub

    '伺服器關閉的處理
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        For i As Integer = 0 To Array_Client.Count - 1
            CType(Array_Client(i), Player).TcpPlayer.Close()
            Array_PlayThread(0).Abort()
            Array_Client.RemoveAt(0)
            Array_PlayThread.RemoveAt(0)
        Next

        If Not TcpServe Is Nothing Then
            TcpServe.Stop()
        End If

    End Sub

    '判斷兩邊玩家準備了沒
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If (Array_Client.Count = 2) Then
            If Array_Client(0).Ready = True And Array_Client(1).Ready = True Then
                Dim msg() As Byte = Encoding.Default.GetBytes("STAR")
                CType(Array_Client(0), Player).DataStream.Write(msg, 0, msg.Length)
                CType(Array_Client(1), Player).DataStream.Write(msg, 0, msg.Length)
                'ProcessImageThread = New Thread(AddressOf ProcessImage)
                'ProcessImageThread.Start()
                Timer1.Enabled = False
            End If
        End If
    End Sub

    '開啟Hsv設定視窗
    Private Sub Btn_Player1_Hsv_Setting_Click(sender As Object, e As EventArgs) Handles Btn_Player1_Hsv_Setting.Click
        Dim f As New Form2
        f.Owner = Me
        f.Show()
    End Sub

    Private Sub Btn_Player2_Hsv_Setting_Click(sender As Object, e As EventArgs) Handles Btn_Player2_Hsv_Setting.Click
        Dim f As New Form3
        f.Owner = Me
        f.Show()
    End Sub
End Class

Class Player
    Private f As Form1
    Public TcpPlayer As TcpClient
    Public DataStream As NetworkStream
    Public Player_ID As String
    Public Index As Integer
    Public Ready As Boolean
    Public Fire As Boolean = True '是否有開槍
    Public Hp As Integer = 10
    'Public Player_Image As Image(Of Bgr, Byte)
    Public Player_Camera As VideoCapture
    Public Player_Image As New Image(Of Hsv, Byte)(1024, 1024)
    Sub New(ByVal TmpPlayer As TcpClient, ByVal TmpForm As Form1)
        f = TmpForm
        TcpPlayer = TmpPlayer
    End Sub

    Public Sub Player_Receive()
        Try
            Dim tmpStr As String
            Dim bytes(4096) As Byte
            Dim rcvByte As Integer
            Do
                Try
                    rcvByte = DataStream.Read(bytes, 0, bytes.Length)
                    tmpStr = Encoding.Default.GetString(bytes, 0, rcvByte)
                    Select Case tmpStr.Substring(0, 4)
                    '接收圖片
                        Case "IMAG"
                            ReciveImage(bytes, rcvByte)
                        Case "IMOK"
                            Ready = True
                            f.SetServerStatus(Player_ID + "已經準備好惹!可以上戰場了")
                    End Select
                Catch ex As Exception

                End Try

                Thread.Sleep(1)
            Loop While DataStream.DataAvailable <> 0 Or rcvByte <> 0
        Catch ex As Exception
            'MessageBox.Show("Opps!出現狀況，無法接收到玩家封包" & ex.ToString, "Opps!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Console.WriteLine(ex.ToString)
        End Try

    End Sub
    '接受玩家圖像
    Private Sub ReciveImage(bytes() As Byte, rcvByte As Integer)
        Dim tmpStr As String
        'Dim bytes(4096) As Byte
        'Dim rcvByte As Integer
        Dim ImageFileStream As FileStream
        Try
            ImageFileStream = New FileStream(Player_ID + "Image.jpg", FileMode.OpenOrCreate)
        Catch ex As Exception
            Console.WriteLine("Opps!需求的圖檔正在被使用中!" & ex.ToString, "Opps!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ReciveImage(bytes, rcvByte)
        End Try


        '處理Imag後面串著圖片資訊的可能
        tmpStr = Encoding.Default.GetString(bytes, 0, 4)
        If (tmpStr = "IMAG") Then
            ImageFileStream.Write(bytes, 4, rcvByte - 4)
            rcvByte = DataStream.Read(bytes, 0, bytes.Length)
        End If

        While True
            If (rcvByte >= 4) Then
                'tmpStr = Encoding.Default.GetString(bytes, 0, rcvByte)
                'If (tmpStr.IndexOf("IMAG") <> -1) Then
                '    Dim tmpidx As Integer = tmpStr.IndexOf("ENDS")
                '    If (tmpidx <> -1) Then
                '        ImageFileStream.Write(bytes, 0, rcvByte - tmpidx)
                '    Else
                '        Exit While
                '    End If
                '    Exit While
                '    Else
                tmpStr = Encoding.Default.GetString(bytes, rcvByte - 4, 4)
                    If (tmpStr = "ENDS") Then
                        ImageFileStream.Write(bytes, 0, rcvByte - 4)
                        Exit While
                    Else
                        ImageFileStream.Write(bytes, 0, rcvByte)
                    End If
                'End If
            Else
                ImageFileStream.Write(bytes, 0, rcvByte)
            End If
            rcvByte = DataStream.Read(bytes, 0, bytes.Length)
            tmpStr = Encoding.Default.GetString(bytes, 0, rcvByte)
            If (tmpStr.IndexOf("IMOK") <> -1) Then
                '濾掉IMOK之後再寫進圖檔裡面
                tmpStr = tmpStr.Substring(0, tmpStr.IndexOf("IMOK") - 1) & tmpStr.Substring(tmpStr.IndexOf("IMOK") + 4, tmpStr.Length - tmpStr.IndexOf("IMOK") - 4 - 1)
                bytes = Encoding.Default.GetBytes(tmpStr)
                Ready = True
                f.SetServerStatus(Player_ID + "已經準備好惹!可以上戰場了")
            End If
        End While
        ImageFileStream.Close()
        'f.Img_Player1.ImageLocation = Player_ID & "Image.jpg"
        '先將圖檔傳給videocaptue確保順暢
        '再由try_catch來新建圖檔
        '不然有時會有不明原因導致傳圖失敗,使圖檔建立失敗導致程式死掉
        Player_Camera = New VideoCapture(Player_ID & "Image.jpg")
        Try
            Player_Image = New Image(Of Hsv, Byte)(Player_ID & "Image.jpg")
        Catch ex As Exception

        End Try

        Thread.Sleep(1)

    End Sub
    Public Sub SendImage(tmpIndex As Integer)
        Dim m As New MemoryStream
        Player_Image.Bitmap.Save(m, Drawing.Imaging.ImageFormat.Jpeg)
        Dim pre() As Byte
        pre = Encoding.Default.GetBytes("IMAG")
        If (Index = 1) Then
            CType(f.Array_Client(1), Player).DataStream.Write(pre, 0, pre.Length)
            CType(f.Array_Client(1), Player).DataStream.Write(m.ToArray, 0, m.Length)
            pre = Encoding.Default.GetBytes("ENDS")
            CType(f.Array_Client(1), Player).DataStream.Write(pre, 0, pre.Length)
        ElseIf (Index = 2) Then
            CType(f.Array_Client(0), Player).DataStream.Write(pre, 0, pre.Length)
            CType(f.Array_Client(0), Player).DataStream.Write(m.ToArray, 0, m.Length)
            pre = Encoding.Default.GetBytes("ENDS")
            CType(f.Array_Client(0), Player).DataStream.Write(pre, 0, pre.Length)
        End If

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class

