Imports System.Windows.Forms

Public Class LoadImageFolderDialog

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


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            If My.Computer.FileSystem.DirectoryExists(OptionsCurrentFolder.SelectedPath) = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox("Please ensure you select a valid folder to load", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "No Image Folder Selected")
            End If
        Catch ex As Exception
            Error_Handler(ex, "Image Folder Selected")
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Try
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            Error_Handler(ex, "Image Folder Selection Cancelled")
        End Try
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Try
            OptionsFileTypes.Text = "jpg;bmp;gif;png"
        Catch ex As Exception
            Error_Handler(ex, "Reset Image Types")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If OptionsCurrentFolder.ShowDialog = Windows.Forms.DialogResult.OK Then
                OptionsCurrentFolderDisplay.Text = OptionsCurrentFolder.SelectedPath
            End If
        Catch ex As Exception
            Error_Handler(ex, "Select Image Folder")
        End Try
    End Sub
End Class
