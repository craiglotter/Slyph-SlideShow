<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_Screen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main_Screen))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AutoUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pbOverlay = New System.Windows.Forms.PictureBox
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SlideShowStatus = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.LoadImageFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RefreshImageFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RestartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NextImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PreviousImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.QuickerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SlowerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SetSpeedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.PrintOutImageListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FocusSet = New System.Windows.Forms.Timer(Me.components)
        Me.PrintOutImageListSaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.SlideShowController = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.MenuStrip1.SuspendLayout()
        CType(Me.pbOverlay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Gray
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(313, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem1, Me.AutoUpdateToolStripMenuItem})
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(143, 22)
        Me.AboutToolStripMenuItem1.Text = "About"
        '
        'AutoUpdateToolStripMenuItem
        '
        Me.AutoUpdateToolStripMenuItem.Name = "AutoUpdateToolStripMenuItem"
        Me.AutoUpdateToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.AutoUpdateToolStripMenuItem.Text = "AutoUpdate"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.BalloonTipText = "You have chosen to hide Brazzers Ripper. To bring it back up, simply click here."
        Me.NotifyIcon1.BalloonTipTitle = "Brazzers Ripper"
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Click to bring up Brazzers Ripper"
        '
        'pbOverlay
        '
        Me.pbOverlay.BackColor = System.Drawing.Color.Black
        Me.pbOverlay.ContextMenuStrip = Me.ContextMenuStrip1
        Me.pbOverlay.Location = New System.Drawing.Point(43, 19)
        Me.pbOverlay.Margin = New System.Windows.Forms.Padding(0)
        Me.pbOverlay.Name = "pbOverlay"
        Me.pbOverlay.Size = New System.Drawing.Size(228, 196)
        Me.pbOverlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbOverlay.TabIndex = 3
        Me.pbOverlay.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SlideShowStatus, Me.ToolStripMenuItem1, Me.ToolStripSeparator4, Me.LoadImageFolderToolStripMenuItem, Me.RefreshImageFolderToolStripMenuItem, Me.ToolStripSeparator1, Me.StartToolStripMenuItem, Me.StopToolStripMenuItem, Me.RestartToolStripMenuItem, Me.NextImageToolStripMenuItem, Me.PreviousImageToolStripMenuItem, Me.ToolStripSeparator2, Me.QuickerToolStripMenuItem, Me.SlowerToolStripMenuItem, Me.SetSpeedToolStripMenuItem, Me.ToolStripSeparator3, Me.PrintOutImageListToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(201, 314)
        '
        'SlideShowStatus
        '
        Me.SlideShowStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SlideShowStatus.Name = "SlideShowStatus"
        Me.SlideShowStatus.Size = New System.Drawing.Size(200, 22)
        Me.SlideShowStatus.Text = "Slideshow is Stopped"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.Gray
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(200, 22)
        Me.ToolStripMenuItem1.Text = "Showing 0 of 0 images"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(197, 6)
        '
        'LoadImageFolderToolStripMenuItem
        '
        Me.LoadImageFolderToolStripMenuItem.Name = "LoadImageFolderToolStripMenuItem"
        Me.LoadImageFolderToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.LoadImageFolderToolStripMenuItem.Text = "Load Image Folder (L)"
        '
        'RefreshImageFolderToolStripMenuItem
        '
        Me.RefreshImageFolderToolStripMenuItem.Name = "RefreshImageFolderToolStripMenuItem"
        Me.RefreshImageFolderToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.RefreshImageFolderToolStripMenuItem.Text = "Refesh Image Folder (I)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(197, 6)
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.StartToolStripMenuItem.Text = "Start Slideshow (S)"
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.StopToolStripMenuItem.Text = "Stop Slideshow (S)"
        '
        'RestartToolStripMenuItem
        '
        Me.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem"
        Me.RestartToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.RestartToolStripMenuItem.Text = "Restart Slideshow (R)"
        '
        'NextImageToolStripMenuItem
        '
        Me.NextImageToolStripMenuItem.Name = "NextImageToolStripMenuItem"
        Me.NextImageToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.NextImageToolStripMenuItem.Text = "Next Image (Right)"
        '
        'PreviousImageToolStripMenuItem
        '
        Me.PreviousImageToolStripMenuItem.Name = "PreviousImageToolStripMenuItem"
        Me.PreviousImageToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.PreviousImageToolStripMenuItem.Text = "Previous Image (Left)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(197, 6)
        '
        'QuickerToolStripMenuItem
        '
        Me.QuickerToolStripMenuItem.Name = "QuickerToolStripMenuItem"
        Me.QuickerToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.QuickerToolStripMenuItem.Text = "Quicker (+)"
        '
        'SlowerToolStripMenuItem
        '
        Me.SlowerToolStripMenuItem.Name = "SlowerToolStripMenuItem"
        Me.SlowerToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.SlowerToolStripMenuItem.Text = "Slower (-)"
        '
        'SetSpeedToolStripMenuItem
        '
        Me.SetSpeedToolStripMenuItem.Name = "SetSpeedToolStripMenuItem"
        Me.SetSpeedToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.SetSpeedToolStripMenuItem.Text = "Set Speed (Q)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(197, 6)
        '
        'PrintOutImageListToolStripMenuItem
        '
        Me.PrintOutImageListToolStripMenuItem.Name = "PrintOutImageListToolStripMenuItem"
        Me.PrintOutImageListToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.PrintOutImageListToolStripMenuItem.Text = "Print Out Image List (P)"
        '
        'FocusSet
        '
        Me.FocusSet.Enabled = True
        Me.FocusSet.Interval = 500
        '
        'PrintOutImageListSaveFileDialog
        '
        Me.PrintOutImageListSaveFileDialog.DefaultExt = "txt"
        Me.PrintOutImageListSaveFileDialog.FileName = "Image List"
        Me.PrintOutImageListSaveFileDialog.Filter = "Text files|*.txt"
        Me.PrintOutImageListSaveFileDialog.Title = "Save the image list as:"
        '
        'SlideShowController
        '
        Me.SlideShowController.Interval = 1000
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.pbOverlay)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(313, 238)
        Me.Panel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoEllipsis = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(313, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Black
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2MinSize = 13
        Me.SplitContainer1.Size = New System.Drawing.Size(313, 252)
        Me.SplitContainer1.SplitterDistance = 238
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 6
        '
        'Main_Screen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(313, 276)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(321, 310)
        Me.Name = "Main_Screen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.pbOverlay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents AutoUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pbOverlay As System.Windows.Forms.PictureBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents LoadImageFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshImageFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NextImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreviousImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents QuickerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SlowerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetSpeedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FocusSet As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintOutImageListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintOutImageListSaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SlideShowController As System.Windows.Forms.Timer
    Friend WithEvents SlideShowStatus As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer

End Class
