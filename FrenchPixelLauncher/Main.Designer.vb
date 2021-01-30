<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.COZBanner = New System.Windows.Forms.PictureBox()
        Me.COZBtn = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DownloadPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.COZPath = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_COZ_Options = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.UpdatedTimer = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BTN_DungeonEditor = New System.Windows.Forms.Button()
        Me.OptionDE = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DownloadDungeonEditorSrc = New System.Windows.Forms.Button()
        Me.DownloadCOZSrc = New System.Windows.Forms.Button()
        Me.COZDownloadServer = New System.Windows.Forms.Button()
        Me.UpdateLauncher = New System.Windows.Forms.Button()
        Me.UpdateDE = New System.Windows.Forms.Button()
        Me.UpdateCOZ = New System.Windows.Forms.Button()
        CType(Me.COZBanner, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'COZBanner
        '
        Me.COZBanner.Image = CType(resources.GetObject("COZBanner.Image"), System.Drawing.Image)
        Me.COZBanner.Location = New System.Drawing.Point(6, 27)
        Me.COZBanner.Name = "COZBanner"
        Me.COZBanner.Size = New System.Drawing.Size(256, 226)
        Me.COZBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.COZBanner.TabIndex = 0
        Me.COZBanner.TabStop = False
        '
        'COZBtn
        '
        Me.COZBtn.Location = New System.Drawing.Point(6, 216)
        Me.COZBtn.Name = "COZBtn"
        Me.COZBtn.Size = New System.Drawing.Size(218, 37)
        Me.COZBtn.TabIndex = 1
        Me.COZBtn.Text = "Télécharger"
        Me.COZBtn.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Test Image")
        Me.ImageList1.Images.SetKeyName(1, "Icon.png")
        '
        'COZPath
        '
        Me.COZPath.AutoSize = True
        Me.COZPath.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.COZPath.Location = New System.Drawing.Point(116, 256)
        Me.COZPath.Name = "COZPath"
        Me.COZPath.Size = New System.Drawing.Size(29, 13)
        Me.COZPath.TabIndex = 2
        Me.COZPath.Text = "Path"
        Me.COZPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.COZPath.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label1.Location = New System.Drawing.Point(1, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(261, 26)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Project Clash Of Zombies"
        '
        'Btn_COZ_Options
        '
        Me.Btn_COZ_Options.Location = New System.Drawing.Point(221, 216)
        Me.Btn_COZ_Options.Name = "Btn_COZ_Options"
        Me.Btn_COZ_Options.Size = New System.Drawing.Size(41, 37)
        Me.Btn_COZ_Options.TabIndex = 4
        Me.Btn_COZ_Options.Text = "..."
        Me.Btn_COZ_Options.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'UpdatedTimer
        '
        Me.UpdatedTimer.Enabled = True
        Me.UpdatedTimer.Interval = 5000
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(405, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(218, 226)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'BTN_DungeonEditor
        '
        Me.BTN_DungeonEditor.Location = New System.Drawing.Point(380, 216)
        Me.BTN_DungeonEditor.Name = "BTN_DungeonEditor"
        Me.BTN_DungeonEditor.Size = New System.Drawing.Size(218, 37)
        Me.BTN_DungeonEditor.TabIndex = 6
        Me.BTN_DungeonEditor.Text = "Télécharger"
        Me.BTN_DungeonEditor.UseVisualStyleBackColor = True
        '
        'OptionDE
        '
        Me.OptionDE.Location = New System.Drawing.Point(595, 216)
        Me.OptionDE.Name = "OptionDE"
        Me.OptionDE.Size = New System.Drawing.Size(41, 37)
        Me.OptionDE.TabIndex = 7
        Me.OptionDE.Text = "..."
        Me.OptionDE.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label2.Location = New System.Drawing.Point(435, -2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 26)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Dungeon Editor"
        '
        'DownloadDungeonEditorSrc
        '
        Me.DownloadDungeonEditorSrc.Enabled = False
        Me.DownloadDungeonEditorSrc.Location = New System.Drawing.Point(405, 256)
        Me.DownloadDungeonEditorSrc.Name = "DownloadDungeonEditorSrc"
        Me.DownloadDungeonEditorSrc.Size = New System.Drawing.Size(231, 32)
        Me.DownloadDungeonEditorSrc.TabIndex = 9
        Me.DownloadDungeonEditorSrc.Text = "Télécharger le code source"
        Me.DownloadDungeonEditorSrc.UseVisualStyleBackColor = True
        Me.DownloadDungeonEditorSrc.Visible = False
        '
        'DownloadCOZSrc
        '
        Me.DownloadCOZSrc.Enabled = False
        Me.DownloadCOZSrc.Location = New System.Drawing.Point(31, 256)
        Me.DownloadCOZSrc.Name = "DownloadCOZSrc"
        Me.DownloadCOZSrc.Size = New System.Drawing.Size(231, 32)
        Me.DownloadCOZSrc.TabIndex = 10
        Me.DownloadCOZSrc.Text = "Télécharger le code source"
        Me.DownloadCOZSrc.UseVisualStyleBackColor = True
        Me.DownloadCOZSrc.Visible = False
        '
        'COZDownloadServer
        '
        Me.COZDownloadServer.Enabled = False
        Me.COZDownloadServer.Location = New System.Drawing.Point(31, 294)
        Me.COZDownloadServer.Name = "COZDownloadServer"
        Me.COZDownloadServer.Size = New System.Drawing.Size(231, 32)
        Me.COZDownloadServer.TabIndex = 11
        Me.COZDownloadServer.Text = "Télécharger le server"
        Me.COZDownloadServer.UseVisualStyleBackColor = True
        Me.COZDownloadServer.Visible = False
        '
        'UpdateLauncher
        '
        Me.UpdateLauncher.Location = New System.Drawing.Point(1077, 620)
        Me.UpdateLauncher.Name = "UpdateLauncher"
        Me.UpdateLauncher.Size = New System.Drawing.Size(175, 49)
        Me.UpdateLauncher.TabIndex = 12
        Me.UpdateLauncher.Text = "Chercher une mise à jour"
        Me.UpdateLauncher.UseVisualStyleBackColor = True
        '
        'UpdateDE
        '
        Me.UpdateDE.Enabled = False
        Me.UpdateDE.Location = New System.Drawing.Point(405, 294)
        Me.UpdateDE.Name = "UpdateDE"
        Me.UpdateDE.Size = New System.Drawing.Size(231, 32)
        Me.UpdateDE.TabIndex = 13
        Me.UpdateDE.Text = "Mettre à jour"
        Me.UpdateDE.UseVisualStyleBackColor = True
        Me.UpdateDE.Visible = False
        '
        'UpdateCOZ
        '
        Me.UpdateCOZ.Enabled = False
        Me.UpdateCOZ.Location = New System.Drawing.Point(31, 332)
        Me.UpdateCOZ.Name = "UpdateCOZ"
        Me.UpdateCOZ.Size = New System.Drawing.Size(231, 32)
        Me.UpdateCOZ.TabIndex = 14
        Me.UpdateCOZ.Text = "Mettre à jour"
        Me.UpdateCOZ.UseVisualStyleBackColor = True
        Me.UpdateCOZ.Visible = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.UpdateCOZ)
        Me.Controls.Add(Me.UpdateDE)
        Me.Controls.Add(Me.UpdateLauncher)
        Me.Controls.Add(Me.COZDownloadServer)
        Me.Controls.Add(Me.DownloadCOZSrc)
        Me.Controls.Add(Me.DownloadDungeonEditorSrc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BTN_DungeonEditor)
        Me.Controls.Add(Me.OptionDE)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.COZBtn)
        Me.Controls.Add(Me.Btn_COZ_Options)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.COZPath)
        Me.Controls.Add(Me.COZBanner)
        Me.Name = "Main"
        Me.Text = "FrenchPixelLauncher"
        CType(Me.COZBanner, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents COZBanner As PictureBox
    Friend WithEvents COZBtn As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents DownloadPath As FolderBrowserDialog
    Friend WithEvents COZPath As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Btn_COZ_Options As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents UpdatedTimer As Timer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BTN_DungeonEditor As Button
    Friend WithEvents OptionDE As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents DownloadDungeonEditorSrc As Button
    Friend WithEvents DownloadCOZSrc As Button
    Friend WithEvents COZDownloadServer As Button
    Friend WithEvents UpdateLauncher As Button
    Friend WithEvents UpdateDE As Button
    Friend WithEvents UpdateCOZ As Button
End Class
