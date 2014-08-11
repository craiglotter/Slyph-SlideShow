Imports System.IO


Public Class Main_Screen

   
    '  Private progresslabel As String = ""
  

    Private busyworking As Boolean = False
    Private AutoUpdate As Boolean = False


    Protected OptionsCurrentFolder As String = ""
    Protected OptionsRecursive As Boolean = True
    Protected OptionsFileTypes As String = "jpg;bmp;gif;png"
    Protected OptionsCurrentImage As String = ""
    Protected OptionsCurrentImageIndex As Integer = 0
    Protected OptionsSpeed As Long = 1000

    Private SlideShowCurrentlyRunning As Boolean = False


    Private ImageList As ArrayList



    Private Sub Error_Handler(ByVal ex As Exception, Optional ByVal identifier_msg As String = "")
        Try
            If ex.Message.IndexOf("Thread was being aborted") < 0 Then
                Dim Display_Message1 As New Display_Message()
                Display_Message1.Message_Textbox.Text = "The Application encountered the following problem: " & vbCrLf & identifier_msg & ": " & ex.ToString
                Display_Message1.Timer1.Interval = 1000
                Display_Message1.ShowDialog()
                Dim dir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs")
                If dir.Exists = False Then
                    dir.Create()
                End If
                dir = Nothing
                Dim filewriter As System.IO.StreamWriter = New System.IO.StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs\" & Format(Now(), "yyyyMMdd") & "_Error_Log.txt", True)
                filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & identifier_msg & ": " & ex.ToString)
                filewriter.WriteLine("")
                filewriter.Flush()
                filewriter.Close()
                filewriter = Nothing
            End If
        Catch exc As Exception
            MsgBox("An error occurred in the application's error handling routine. The application will try to recover from this serious error." & vbCrLf & vbCrLf & exc.ToString, MsgBoxStyle.Critical, "Critical Error Encountered")
        End Try
    End Sub

    Private Sub Activity_Handler(ByVal message As String)
        Try
            Dim dir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Activity Logs")
            If dir.Exists = False Then
                dir.Create()
            End If
            dir = Nothing
            Dim filewriter As System.IO.StreamWriter = New System.IO.StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Activity Logs\" & Format(Now(), "yyyyMMdd") & "_Activity_Log.txt", True)
            filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & message)
            filewriter.WriteLine("")
            filewriter.Flush()
            filewriter.Close()
            filewriter = Nothing
        Catch ex As Exception
            Error_Handler(ex, "Activity Handler")
        End Try
    End Sub


  

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Control.CheckForIllegalCrossThreadCalls = False
            Me.Text = My.Application.Info.ProductName & " (" & Format(My.Application.Info.Version.Major, "0000") & Format(My.Application.Info.Version.Minor, "00") & Format(My.Application.Info.Version.Build, "00") & "." & Format(My.Application.Info.Version.Revision, "00") & ")"
            loadSettings()
            AboutToolStripMenuItem1.Text = "About " & My.Application.Info.ProductName
            NotifyIcon1.BalloonTipText = "You have chosen to hide " & My.Application.Info.ProductName & ". To bring it back up, simply click here."
            NotifyIcon1.BalloonTipTitle = My.Application.Info.ProductName
            NotifyIcon1.Text = "Click to bring up " & My.Application.Info.ProductName

            ImageList = New ArrayList
            ImageList.Clear()

            PopulateImageList()
            pbOverlay.Focus()
            SetSpeed(OptionsSpeed)
        Catch ex As Exception
            Error_Handler(ex, "Form Load")
        End Try
    End Sub



    Private Sub Control_Enabler(ByVal IsEnabled As Boolean)
        Try
            Select Case IsEnabled
                Case True
                  
                    MenuStrip1.Enabled = True
                    Me.ControlBox = True
                   
                Case False
                  
                    MenuStrip1.Enabled = False
                    Me.ControlBox = False
                 
            End Select
        Catch ex As Exception
            Error_Handler(ex, "Control Enabler")
        End Try
    End Sub

   

    

    Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem.Click
        Try
            HelpBox1.ShowDialog()
        Catch ex As Exception
            Error_Handler(ex, "Display Help Screen")
        End Try
    End Sub



    Private Sub loadSettings()
        Try

            Dim configfile As String = (Application.StartupPath & "\config.sav").Replace("\\", "\")
            If My.Computer.FileSystem.FileExists(configfile) Then
                Dim reader As StreamReader = New StreamReader(configfile)
                Dim lineread As String
                Dim variablevalue As String
                While reader.Peek <> -1
                    lineread = reader.ReadLine
                    If lineread.IndexOf("=") <> -1 Then
                        variablevalue = lineread.Remove(0, lineread.IndexOf("=") + 1)
                        If lineread.StartsWith("OptionsCurrentFolder=") Then
                            If My.Computer.FileSystem.DirectoryExists(variablevalue) = True Then
                                OptionsCurrentFolder = variablevalue
                            End If
                        End If
                        If lineread.StartsWith("OptionsRecursive=") Then
                            OptionsRecursive = variablevalue
                        End If
                        If lineread.StartsWith("OptionsFileTypes=") Then
                            OptionsFileTypes = variablevalue
                        End If
                        If lineread.StartsWith("OptionsCurrentImage=") Then
                            OptionsCurrentImage = variablevalue
                        End If
                        If lineread.StartsWith("OptionsCurrentImageIndex=") Then
                            OptionsCurrentImageIndex = Integer.Parse(variablevalue)
                        End If
                        If lineread.StartsWith("OptionsSpeed=") Then
                            OptionsSpeed = Long.Parse(variablevalue)
                        End If
                    End If
                End While
                reader.Close()
                reader = Nothing
            End If

        Catch ex As Exception
            Error_Handler(ex, "Load Settings")
        End Try
    End Sub

    Private Sub SaveSettings()
        Try

            Dim configfile As String = (Application.StartupPath & "\config.sav").Replace("\\", "\")
            Dim writer As StreamWriter = New StreamWriter(configfile, False)
            writer.WriteLine("OptionsCurrentFolder=" & OptionsCurrentFolder)
            writer.WriteLine("OptionsRecursive=" & OptionsRecursive)
            writer.WriteLine("OptionsFileTypes=" & OptionsFileTypes)
            writer.WriteLine("OptionsSpeed=" & OptionsSpeed)
            writer.WriteLine("OptionsCurrentImageIndex=" & OptionsCurrentImageIndex)
            writer.WriteLine("OptionsCurrentImage=" & OptionsCurrentImage)
            writer.Flush()
            writer.Close()
            writer = Nothing

        Catch ex As Exception
            Error_Handler(ex, "Save Settings")
        End Try
    End Sub

    Private Sub Main_Screen_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            SaveSettings()
            If AutoUpdate = True Then
                If My.Computer.FileSystem.FileExists((Application.StartupPath & "\AutoUpdate.exe").Replace("\\", "\")) = True Then
                    Dim startinfo As ProcessStartInfo = New ProcessStartInfo
                    startinfo.FileName = (Application.StartupPath & "\AutoUpdate.exe").Replace("\\", "\")
                    startinfo.Arguments = "force"
                    startinfo.CreateNoWindow = False
                    Process.Start(startinfo)
                End If
            End If
        Catch ex As Exception
            Error_Handler(ex, "Closing Application")
        End Try
    End Sub



    Private Sub NotifyIcon1_BalloonTipClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon1.BalloonTipClicked
        Try
            Me.WindowState = FormWindowState.Normal
            Me.ShowInTaskbar = True
            NotifyIcon1.Visible = False
            Me.Refresh()
        Catch ex As Exception
            Error_Handler(ex, "Click on NotifyIcon")
        End Try
    End Sub


    Private Sub NotifyIcon1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseClick
        Try
            Me.WindowState = FormWindowState.Normal
            Me.ShowInTaskbar = True
            NotifyIcon1.Visible = False
            Me.Refresh()
        Catch ex As Exception
            Error_Handler(ex, "Click on NotifyIcon")
        End Try
    End Sub


    Private Sub NotifyIcon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click
        Try
            Me.WindowState = FormWindowState.Normal
            Me.ShowInTaskbar = True
            NotifyIcon1.Visible = False
            Me.Refresh()
        Catch ex As Exception
            Error_Handler(ex, "Click on NotifyIcon")
        End Try
    End Sub

    Private Sub Main_Screen_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Try
            If Me.WindowState = FormWindowState.Minimized Then
                Me.ShowInTaskbar = False
                NotifyIcon1.Visible = True
                '  If shownminimizetip = False Then
                NotifyIcon1.ShowBalloonTip(1)
                'shownminimizetip = True
            End If
            ' End If
        Catch ex As Exception
            Error_Handler(ex, "Change Window State")
        End Try
    End Sub



    Private Sub AutoUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoUpdateToolStripMenuItem.Click
        Try
            AutoUpdate = True
            Me.Close()
        Catch ex As Exception
            Error_Handler(ex, "AutoUpdate")
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem1.Click
        Try

            AboutBox1.ShowDialog()
        Catch ex As Exception
            Error_Handler(ex, "Display About Screen")
        End Try
    End Sub

   



    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.WindowState = FormWindowState.Minimized
        Catch ex As Exception
            Error_Handler(ex, "Minimize Label Clicked")
        End Try
    End Sub

    Private Sub pbOverlay_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbOverlay.DoubleClick
        Try
            Dim pbox As PictureBox = sender
            If Not pbox.Image Is Nothing Then
                If (OptionsCurrentImage).Length > 0 Then
                    Process.Start("""" & OptionsCurrentImage & """")
                End If
            End If
            pbox = Nothing
        Catch ex As Exception
            Error_Handler(ex, "Image Clicked")
        End Try
    End Sub



    Private Sub Main_Screen_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Try
            If Me.WindowState = FormWindowState.Normal Or Me.WindowState = FormWindowState.Maximized Then
                '  MsgBox(OptionsCurrentImage & " - " & OptionsCurrentImageIndex & " - Size Changes")
                DisplayImage()
            End If
        Catch ex As Exception
            Error_Handler(ex, "Main Screen Resized")
        End Try

    End Sub

    Private Sub LoadImages(ByVal basedir As String)
        Try
            Dim filelist As ArrayList = New ArrayList
            Dim folderlist As ArrayList = New ArrayList
            Dim dinfo As DirectoryInfo = New DirectoryInfo(basedir)
            If dinfo.Exists Then
                For Each finfo As FileInfo In dinfo.GetFiles
                    For Each type As String In OptionsFileTypes.Split(";")
                        If finfo.Extension.ToLower.EndsWith(type.ToLower) = True Then
                            filelist.Add(finfo.FullName)
                        End If
                    Next
                    finfo = Nothing
                Next
                filelist.Sort()
                For Each finfo As String In filelist
                    ImageList.Add(finfo)
                Next
                filelist.Clear()
                filelist = Nothing

                If OptionsRecursive = True Then
                    For Each subinfo As DirectoryInfo In dinfo.GetDirectories
                        folderlist.Add(subinfo.FullName)
                        subinfo = Nothing
                    Next
                End If
                folderlist.Sort()
                For Each subinfo As String In folderlist
                    LoadImages(subinfo)
                Next
                folderlist.Clear()
                folderlist = Nothing
                dinfo = Nothing
            End If
        Catch ex As Exception
            Error_Handler(ex, "Load Images")
        End Try
    End Sub

    Private Sub PopulateImageList()
        Try
            If My.Computer.FileSystem.DirectoryExists(OptionsCurrentFolder) = True Then
                ImageList.Clear()
                LoadImages(OptionsCurrentFolder)
                If ImageList.Count > 0 Then
                    If OptionsCurrentImageIndex = Nothing Then
                        OptionsCurrentImage = ImageList.Item(0)
                        OptionsCurrentImageIndex = 0
                        DisplayImage()
                    End If
                    'MsgBox(OptionsCurrentImage & " - " & OptionsCurrentImageIndex & " - Populate Image List")


                End If
            End If
            If ImageList.Count > 0 Then
                If ImageList.Count <> 1 Then
                    ToolStripMenuItem1.Text = "Showing " & OptionsCurrentImageIndex + 1 & " of " & ImageList.Count & " images"
                Else
                    ToolStripMenuItem1.Text = "Showing " & OptionsCurrentImageIndex + 1 & " of " & ImageList.Count & " image"
                End If
            Else
                ToolStripMenuItem1.Text = "Showing 0 of 0 images"
            End If
            Dim pickeduppic As Boolean = False
            For i As Integer = 0 To ImageList.Count - 1
                If ImageList.Item(i) = OptionsCurrentImage Then
                    OptionsCurrentImageIndex = i
                    OptionsCurrentImage = ImageList.Item(i)
                    ' MsgBox(OptionsCurrentImage & " - " & OptionsCurrentImageIndex & " - Populate Image List 2")
                    DisplayImage()
                    pickeduppic = True
                    Exit For
                End If
            Next
            If pickeduppic = False Then
                If ImageList.Count > 0 Then
                    OptionsCurrentImage = ImageList.Item(0)
                    OptionsCurrentImageIndex = 0
                    DisplayImage()
                End If
            End If

        Catch ex As Exception
            Error_Handler(ex, "Populate Image List")
        End Try
    End Sub

    Private Sub DisplayImage()
        Try
            ' MsgBox(OptionsCurrentImage & " - " & OptionsCurrentImageIndex)
            If My.Computer.FileSystem.FileExists(OptionsCurrentImage) Then
                Dim img As Image = Image.FromFile(OptionsCurrentImage)
                If img.Width > 0 AndAlso img.Height > 0 Then
                    ' assign to the "original" image
                    If Not Me.pbOverlay.Image Is Nothing Then
                        pbOverlay.Image.Dispose()
                    End If

                    Me.pbOverlay.Image = Image.FromFile(OptionsCurrentImage)
                    Dim whichisbigger As String = "width"

                    pbOverlay.Height = Math.Round(img.Height * (Panel1.Width / img.Width), 0, System.MidpointRounding.AwayFromZero)
                    pbOverlay.Width = Math.Round(img.Width * (Panel1.Width / img.Width), 0, System.MidpointRounding.AwayFromZero)
                    If pbOverlay.Height > Panel1.Height Then
                        pbOverlay.Width = Math.Round(pbOverlay.Width * (Panel1.Height / pbOverlay.Height), 0, System.MidpointRounding.AwayFromZero)
                        pbOverlay.Height = Math.Round(pbOverlay.Height * (Panel1.Height / pbOverlay.Height), 0, System.MidpointRounding.AwayFromZero)
                    End If

                    pbOverlay.Top = Math.Round(((Panel1.Height - pbOverlay.Height) / 2), 0, System.MidpointRounding.AwayFromZero)
                    pbOverlay.Left = Math.Round(((Panel1.Width - pbOverlay.Width) / 2), 0, System.MidpointRounding.AwayFromZero)
                    ' MsgBox("width: " & pbOverlay.Width.ToString & " - height: " & pbOverlay.Height.ToString)
                End If
                Label1.Text = OptionsCurrentImage
                img.Dispose()
                img = Nothing
                pbOverlay.Focus()
                If ImageList.Count > 0 Then
                    If ImageList.Count <> 1 Then
                        ToolStripMenuItem1.Text = "Showing " & OptionsCurrentImageIndex + 1 & " of " & ImageList.Count & " images"
                    Else
                        ToolStripMenuItem1.Text = "Showing " & OptionsCurrentImageIndex + 1 & " of " & ImageList.Count & " image"
                    End If
                Else
                    ToolStripMenuItem1.Text = "Showing 0 of 0 images"
                End If

            End If
        Catch ex As Exception
            Error_Handler(ex, "Display Image")
        End Try
    End Sub

    Private Sub LoadImageFolder()
        Try
            Dim lifdialog As LoadImageFolderDialog = New LoadImageFolderDialog
            If OptionsCurrentFolder.Length > 0 Then
                If My.Computer.FileSystem.DirectoryExists(OptionsCurrentFolder) Then
                    lifdialog.OptionsCurrentFolder.SelectedPath = OptionsCurrentFolder
                End If
            End If
            lifdialog.OptionsFileTypes.Text = OptionsFileTypes
            lifdialog.OptionsRecursive.Checked = OptionsRecursive
            lifdialog.OptionsCurrentFolderDisplay.Text = OptionsCurrentFolder
            If lifdialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                pbOverlay.Image = Nothing
                pbOverlay.Width = Panel1.Width
                pbOverlay.Left = 0
                pbOverlay.Height = Panel1.Height
                pbOverlay.Top = 0
                Label1.Text = ""
                OptionsCurrentImage = ""
                OptionsCurrentImageIndex = 0

                OptionsCurrentFolder = lifdialog.OptionsCurrentFolder.SelectedPath
                OptionsRecursive = lifdialog.OptionsRecursive.Checked
                OptionsFileTypes = lifdialog.OptionsFileTypes.Text
                PopulateImageList()
            End If
            lifdialog.Dispose()
            lifdialog = Nothing
        Catch ex As Exception
            Error_Handler(ex, "Load Slideshow Image Folder")
        End Try
    End Sub

    Private Sub RefreshImageFolder()
        Try
            PopulateImageList()
        Catch ex As Exception
            Error_Handler(ex, "Load Slideshow Image Folder")
        End Try
    End Sub

    Private Sub LoadImageFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadImageFolderToolStripMenuItem.Click
        Try
            LoadImageFolder()
        Catch ex As Exception
            Error_Handler(ex, "Menu Click")
        End Try
    End Sub

    Private Sub RefreshImageFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshImageFolderToolStripMenuItem.Click
        Try
            PopulateImageList()
        Catch ex As Exception
            Error_Handler(ex, "Menu Click")
        End Try
    End Sub

    Private Sub DisplayNextImage()
        Try
            If ImageList.Count > 0 Then
                OptionsCurrentImageIndex = OptionsCurrentImageIndex + 1
                If OptionsCurrentImageIndex >= ImageList.Count Then
                    OptionsCurrentImageIndex = 0
                End If
                OptionsCurrentImage = ImageList.Item(OptionsCurrentImageIndex)
                'MsgBox(OptionsCurrentImage & " - " & OptionsCurrentImageIndex & " - Display Next")
                DisplayImage()
            End If
        Catch ex As Exception
            Error_Handler(ex, "Display Next Image")
        End Try
    End Sub

    Private Sub NextImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextImageToolStripMenuItem.Click
        Try
            DisplayNextImage()
        Catch ex As Exception
            Error_Handler(ex, "Menu Click")
        End Try
    End Sub

    Private Sub DisplayPreviousImage()
        Try
            If ImageList.Count > 0 Then
                OptionsCurrentImageIndex = OptionsCurrentImageIndex - 1
                If OptionsCurrentImageIndex < 0 Then
                    OptionsCurrentImageIndex = ImageList.Count - 1
                End If
                OptionsCurrentImage = ImageList.Item(OptionsCurrentImageIndex)
                'MsgBox(OptionsCurrentImage & " - " & OptionsCurrentImageIndex & " - Display Previous")
                DisplayImage()
            End If
        Catch ex As Exception
            Error_Handler(ex, "Display Previous Image")
        End Try
    End Sub

    Private Sub PreviousImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviousImageToolStripMenuItem.Click
        Try
            DisplayPreviousImage()
        Catch ex As Exception
            Error_Handler(ex, "Menu Click")
        End Try
    End Sub

    Private Sub PrintOutImageList()
        Try
            If PrintOutImageListSaveFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim writer As StreamWriter = New StreamWriter(PrintOutImageListSaveFileDialog.FileName, False, System.Text.Encoding.UTF8)
                For Each item As String In ImageList
                    writer.WriteLine(item)
                Next
                writer.Flush()
                writer.Close()
                writer = Nothing
            End If
        Catch ex As Exception
            Error_Handler(ex, "Print Out Image List")
        End Try
    End Sub

    Private Sub RestartSlideShow()
        Try
            If ImageList.Count > 0 Then
                OptionsCurrentImageIndex = 0
                OptionsCurrentImage = ImageList.Item(0)
                '  MsgBox(OptionsCurrentImage & " - " & OptionsCurrentImageIndex & " - Restart")
                DisplayImage()
            End If
        Catch ex As Exception
            Error_Handler(ex, "Restart Slide Show")
        End Try
    End Sub

    Private Sub PrintOutImageListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintOutImageListToolStripMenuItem.Click
        Try
            PrintOutImageList()
        Catch ex As Exception
            Error_Handler(ex, "Menu Click")
        End Try
    End Sub

    Private Sub pbOverlay_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles pbOverlay.PreviewKeyDown
        Try
            If e.KeyCode = Keys.Right Then
                DisplayNextImage()
            End If
            If e.KeyCode = Keys.Left Then
                DisplayPreviousImage()
            End If
            If e.KeyCode = Keys.P Then
                PrintOutImageList()
            End If
            If e.KeyCode = Keys.Add Then
                Quicker()
            End If
            If e.KeyCode = Keys.Subtract Then
                Slower()
            End If
            If e.KeyCode = Keys.Q Then
                SetSpeed()
            End If
            If e.KeyCode = Keys.S Then
                If SlideShowCurrentlyRunning = True Then
                    StopSlideShow()
                Else
                    StartSlideShow()
                End If
            End If
            If e.KeyCode = Keys.L Then
                LoadImageFolder()
            End If
            If e.KeyCode = Keys.I Then
                RefreshImageFolder()
            End If
            If e.KeyCode = Keys.R Then
                RestartSlideShow()
            End If

        Catch ex As Exception
            Error_Handler(ex, "Key Press Identified")
        End Try
    End Sub

    Private Sub FocusSet_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FocusSet.Tick
        Try
            pbOverlay.Focus()
            SlideShowController.Interval = OptionsSpeed
        Catch ex As Exception
            Error_Handler(ex, "Focus Timer Tick")
        End Try
    End Sub

    Private Sub Quicker()
        Try
            OptionsSpeed = OptionsSpeed - 1000
            If OptionsSpeed = 0 Then
                OptionsSpeed = 1000
            End If
            Dim nextspeed As Long = OptionsSpeed
            nextspeed = nextspeed - 1000
            If nextspeed = 0 Then
                nextspeed = 1000
            End If
            Dim prevspeed As Long = OptionsSpeed
            prevspeed = prevspeed + 1000
            If prevspeed > 86400000 Then
                prevspeed = 86400000
            End If
            QuickerToolStripMenuItem.Text = "Quicker (+) [" & (nextspeed / 1000) & " s]"
            SlowerToolStripMenuItem.Text = "Slower (-) [" & (prevspeed / 1000) & " s]"
            SetSpeedToolStripMenuItem.Text = "Set Speed (Q) [" & (OptionsSpeed / 1000) & " s]"
            If SlideShowCurrentlyRunning = True Then
                SlideShowStatus.Text = "Slideshow is Running (" & OptionsSpeed / 1000 & "s interval)"
            End If
        Catch ex As Exception
            Error_Handler(ex, "Quicker")
        End Try
    End Sub

    Private Sub Slower()
        Try
            OptionsSpeed = OptionsSpeed + 1000
            If OptionsSpeed > 86400000 Then
                OptionsSpeed = 86400000
            End If
            Dim nextspeed As Long = OptionsSpeed
            nextspeed = nextspeed - 1000
            If nextspeed = 0 Then
                nextspeed = 1000
            End If
            Dim prevspeed As Long = OptionsSpeed
            prevspeed = prevspeed + 1000
            If prevspeed > 86400000 Then
                prevspeed = 86400000
            End If
            QuickerToolStripMenuItem.Text = "Quicker (+) [" & (nextspeed / 1000) & " s]"
            SlowerToolStripMenuItem.Text = "Slower (-) [" & (prevspeed / 1000) & " s]"
            SetSpeedToolStripMenuItem.Text = "Set Speed (Q) [" & (OptionsSpeed / 1000) & " s]"
            If SlideShowCurrentlyRunning = True Then
                SlideShowStatus.Text = "Slideshow is Running (" & OptionsSpeed / 1000 & "s interval)"
            End If
        Catch ex As Exception
            Error_Handler(ex, "Quicker")
        End Try
    End Sub

    Private Sub SetSpeed(Optional ByVal definedSpeed As Long = 0)
        Try
            If definedSpeed > 0 And definedSpeed <= 86400000 Then
                OptionsSpeed = definedSpeed
            Else
                Dim speeddialog As SetSpeedDialog = New SetSpeedDialog
                speeddialog.OptionsSpeed.Value = OptionsSpeed / 1000
                If speeddialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                    OptionsSpeed = speeddialog.OptionsSpeed.Value * 1000
                End If
                speeddialog.Dispose()
                speeddialog = Nothing
            End If

            Dim nextspeed As Long = OptionsSpeed
            nextspeed = nextspeed - 1000
            If nextspeed = 0 Then
                nextspeed = 1000
            End If
            Dim prevspeed As Long = OptionsSpeed
            prevspeed = prevspeed + 1000
            If prevspeed > 86400000 Then
                prevspeed = 8640000
            End If
            QuickerToolStripMenuItem.Text = "Quicker (+) [" & (nextspeed / 1000) & " s]"
            SlowerToolStripMenuItem.Text = "Slower (-) [" & (prevspeed / 1000) & " s]"
            SetSpeedToolStripMenuItem.Text = "Set Speed (Q) [" & (OptionsSpeed / 1000) & " s]"
            If SlideShowCurrentlyRunning = True Then
                SlideShowStatus.Text = "Slideshow is Running (" & OptionsSpeed / 1000 & "s interval)"
            End If
        Catch ex As Exception
            Error_Handler(ex, "Quicker")
        End Try
    End Sub

    Private Sub QuickerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuickerToolStripMenuItem.Click
        Try
            Quicker()
        Catch ex As Exception
            Error_Handler(ex, "Menu Click")
        End Try
    End Sub

    Private Sub SlowerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SlowerToolStripMenuItem.Click
        Try
            Slower()
        Catch ex As Exception
            Error_Handler(ex, "Menu Click")
        End Try
    End Sub

    Private Sub SetSpeedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetSpeedToolStripMenuItem.Click
        Try
            SetSpeed()
        Catch ex As Exception
            Error_Handler(ex, "Menu Click")
        End Try
    End Sub

    Private Sub SlideShowController_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SlideShowController.Tick
        Try
            DisplayNextImage()
        Catch ex As Exception
            Error_Handler(ex, "Slideshow Controller Tick")
        End Try
    End Sub

    Private Sub StartSlideShow()
        Try
            SlideShowController.Start()
            SlideShowCurrentlyRunning = True
            SlideShowStatus.Text = "Slideshow is Running (" & OptionsSpeed / 1000 & "s interval)"
            SlideShowStatus.ForeColor = Color.Green
        Catch ex As Exception
            Error_Handler(ex, "Start Slideshow")
        End Try
    End Sub

    Private Sub StopSlideShow()
        Try
            SlideShowController.Stop()
            SlideShowCurrentlyRunning = False
            SlideShowStatus.Text = "Slideshow is Stopped"
            SlideShowStatus.ForeColor = Color.Red
        Catch ex As Exception
            Error_Handler(ex, "Start Slideshow")
        End Try
    End Sub

    Private Sub StartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartToolStripMenuItem.Click
        Try
            StartSlideShow()
        Catch ex As Exception
            Error_Handler(ex, "Menu Click")
        End Try
    End Sub

    Private Sub StopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopToolStripMenuItem.Click
        Try
            StopSlideShow()
        Catch ex As Exception
            Error_Handler(ex, "Menu Click")
        End Try
    End Sub

    Private Sub RestartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem.Click
        Try
            RestartSlideShow()
        Catch ex As Exception
            Error_Handler(ex, "Menu Click")
        End Try
    End Sub
End Class
