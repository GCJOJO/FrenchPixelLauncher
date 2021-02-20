Imports System.ComponentModel
Imports System.IO
Imports System.Net

Public Structure Game
    Dim name As String
    Dim id As Integer
    Dim FullName As String
    Dim downloadURL As String
    Dim downloadSRCUrl As String
    Dim versionURL As String
    Dim DownloadBarRef As ProgressBar
End Structure

Public Class Main

    Dim COZDownloaded As Boolean
    Dim DEDownloaded As Boolean
    Dim CanDownload As Boolean = True
    Dim WithEvents wClient As New System.Net.WebClient

    Dim directoryPath As String = My.Application.Info.DirectoryPath

    Dim COZ As Game
    Dim DungeonEditor As Game
    Dim Launcher As Game

    Dim DownloadedGame As Game

    Dim CurrentDownloadBar As ProgressBar
    Dim DLUpdate As Boolean = False
    Dim UpdatePath As String

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        COZ.name = "COZ"
        COZ.FullName = "ClashOfZombies"
        COZ.id = 1
        COZ.downloadURL = "https://github.com/GCJOJO/COZ/releases/latest/download/COZWindows.zip"
        COZ.downloadSRCUrl = "https://github.com/GCJOJO/COZ/archive/master.zip"
        COZ.DownloadBarRef = COZDownloadBar

        DungeonEditor.name = "DungeonEditor"
        DungeonEditor.FullName = "DungeonEditor"
        DungeonEditor.id = 2
        DungeonEditor.downloadURL = "https://github.com/GCJOJO/DungeonEditor/releases/latest/download/DungeonEditorWindows.zip"
        DungeonEditor.downloadSRCUrl = "https://github.com/GCJOJO/DungeonEditor/archive/master.zip"
        DungeonEditor.versionURL = "https://gcjojo.github.io/DungeonEditor/WebVersion"
        DungeonEditor.DownloadBarRef = DEDownloadBar

        Launcher.name = "French Pixel Launcher"
        Launcher.FullName = "French Pixel Launcher"
        Launcher.id = 0
        Launcher.downloadURL = "https://github.com/GCJOJO/FrenchPixelLauncher/releases/latest/download/FrenchPixelLauncher.exe"
        Launcher.versionURL = "https://github.com/GCJOJO/FrenchPixelLauncher/releases/latest/download/FPL_WebVersion"

        Try
            Dim COZPathReader As String
            COZPathReader = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\" & COZ.name & "Path.txt")
            'MsgBox(COZPathReader, MsgBoxStyle.MsgBoxHelp)

            Process.Start(COZPathReader).Kill()
            COZDownloaded = True
            COZBtn.Text = "Lancer"
            'COZPath.Visible = True
            COZPath.Text = COZPathReader
            COZBtn.Width = 218
            'checkCOZUpdated()
        Catch ex As Exception
            COZDownloaded = False
            COZBtn.Text = "Télécharger"
            COZPath.Visible = False
            COZBtn.Width = 256
            Process.Start("cmd.exe", "/c del COZPath.txt")

            'MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Try
            Dim DungeonEditorPathReader As String
            DungeonEditorPathReader = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\" & DungeonEditor.name & "Path.txt")
            'MsgBox(COZPathReader, MsgBoxStyle.MsgBoxHelp)

            Process.Start(DungeonEditorPathReader).Kill()
            DEDownloaded = True
            BTN_DungeonEditor.Text = "Lancer"
            BTN_DungeonEditor.Width = 218
        Catch ex As Exception
            DEDownloaded = False
            BTN_DungeonEditor.Text = "Télécharger"
            BTN_DungeonEditor.Width = 256
            Process.Start("cmd.exe", "/c del DungeonEditorPath.txt")

            'MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        If Not System.IO.File.Exists(directoryPath + "\AutoUpdater.exe") Then
            wClient.DownloadFile(New Uri("https://github.com/GCJOJO/FrenchPixelLauncher/releases/latest/download/AutoUpdater.exe"), directoryPath + "\AutoUpdater.exe")
        End If
        If System.IO.File.Exists(directoryPath + "\CurrentVersion") Then
            CheckLauncherVersion(Launcher, False)
        Else
            System.IO.File.Create(directoryPath + "\CurrentVersion")
            System.IO.File.WriteAllText(directoryPath + "\CurrentVersion", "1.0.0")
            CheckLauncherVersion(Launcher, True)
        End If
    End Sub



    Private Sub COZBtn_Click(sender As Object, e As EventArgs) Handles COZBtn.Click
        '    Try
        '        Shell(Application.ExecutablePath & "\Games\COZ\Binaries\COZ.exe")
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical)
        '    End Try
        '    If COZDownloaded Then
        '        Dim COZPathReader As String
        '        COZPathReader = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\COZPath.txt")
        '        Process.Start(COZPathReader)
        '    Else
        '        If COZDownloadPath.ShowDialog() = DialogResult.OK Then
        '            Shell("cmd.exe /c" & "curl file:///D:/repos/GCLauncher/GCLauncher/DownloadCOZ.exe -o " & COZDownloadPath.SelectedPath & "\COZ.Downloader.exe", AppWinStyle.Hide)
        '            Shell("cmd.exe /c" & "echo " & COZDownloadPath.SelectedPath & "\ClashOfZombies\COZ.exe> COZPath.txt", AppWinStyle.Hide)

        '            Dim COZPathWriter As System.IO.StreamWriter
        '            COZPathWriter = My.Computer.FileSystem.OpenTextFileWriter(Application.StartupPath & "\COZPath.txt", True)
        '            COZPathWriter.Write(COZDownloadPath.SelectedPath & "\ClashOfZombies\COZ.exe")
        '            COZPathWriter.Close()

        '            Process.Start("cmd.exe", "/c cd " & COZDownloadPath.SelectedPath & "\ & curl -L https://github.com/GCJOJO/COZ/releases/latest/download/COZWindows.zip -o" & COZDownloadPath.SelectedPath & "\COZ.zip & tar -xf " & COZDownloadPath.SelectedPath & "\COZ.zip -C" & COZDownloadPath.SelectedPath & "& exit")
        '            Shell("cmd.exe /c" & COZDownloadPath.SelectedPath & "\COZ.Downloader.exe", AppWinStyle.hide)

        '            Download Game
        '            Shell("cmd.exe /k " & "curl file:///D:/repos/COZLauncher/COZ.zip -o " & COZDownloadPath.SelectedPath & "\COZ.zip")

        '            COZPath.Text = COZDownloadPath.SelectedPath
        '            COZPath.Visible = True
        '            COZDownloaded = True
        '            COZBtn.Text = "Lancer"
        '            COZBtn.Width = 218
        '            If checkCOZUpdated() = 2 Then
        '            ElseIf checkCOZUpdated() = 1 Then
        '            ElseIf checkCOZUpdated() = 0 Then
        '                COZDownloaded = False
        '                COZBtn.Text = "Mettre à jour"
        '            End If
        '        End If
        '    End If
        If COZDownloaded Then
            LaunchGame(COZ)
        Else
            DownloadGame(COZ)
            COZDownloaded = True
            COZBtn.Text = "Lancer"
            COZBtn.Width = 218
        End If
    End Sub

    Private Sub BTN_DungeonEditor_Click(sender As Object, e As EventArgs) Handles BTN_DungeonEditor.Click
        If DEDownloaded Then
            LaunchGame(DungeonEditor)
        Else
            DownloadGame(DungeonEditor)
            DEDownloaded = True
            BTN_DungeonEditor.Text = "Lancer"
            BTN_DungeonEditor.Width = 218
        End If
    End Sub


    Public Function CheckLauncherVersion(LauncherRef As Game, AutoUpdate As Boolean) As Boolean
        'Process.Start("cmd.exe", "cd /d " & Application.StartupPath & " & pause")
        'Process.Start("cmd.exe", "title French Pixel Download & cd /d " & Application.StartupPath & " & pause")
        'Process.Start("cmd.exe", "cd " & directoryPath & " & del FrenchPixelLauncher.exe & ren FPL_Update FrenchPixelLauncher.exe & del CurrentVersion & ren FPL_WebVersion CurrentVersion & pause")
        'Process.Start("cmd.exe", "/c title FPL Updater & cd " & directoryPath & " & update.bat")
        'Process.Start("cmd.exe", "title French Pixel Download & cd /d " & Application.StartupPath & "\ & curl -L " & LauncherRef.versionURL & " -o " & Application.StartupPath & "\latest_version.txt & pause")
        'Dim Cmd As Process = Process.Start("cmd.exe", "cd " & directoryPath & " & del FrenchPixelLauncher.exe & ren FPL_Update FrenchPixelLauncher.exe & del CurrentVersion & ren FPL_WebVersion CurrentVersion & pause")
        'Cmd.WaitForExit(0)
        'Process.Start("cmd.exe", "title French Pixel Download & cd /d " & Application.StartupPath & "\ & curl -L " & LauncherRef.downloadURL & " -o " & Application.ExecutablePath & " & pause")
        wClient.DownloadFile(New Uri(LauncherRef.versionURL), directoryPath + "\FPL_WebVersion")
        If CompareFiles(directoryPath & "\CurrentVersion", directoryPath & "\FPL_WebVersion") Then
            Return True
        Else
            If AutoUpdate Then
                'wClient.DownloadFile(New Uri(LauncherRef.downloadURL), directoryPath + "\FPL_Update")
                Process.Start(directoryPath + "\AutoUpdater.exe")
                Close()
                Return True
            End If
            Return False
        End If
        Return False
    End Function

    Public Function DownloadGame(GameRef As Game) As Boolean
        If CanDownload Then
            CanDownload = False
            Dim url As String = GameRef.downloadURL
            If DownloadPath.ShowDialog() = DialogResult.OK Then

                wClient.DownloadFileTaskAsync(New Uri(GameRef.downloadURL), DownloadPath.SelectedPath + "\" + GameRef.name + ".zip")
                Dim PathWriter As System.IO.StreamWriter
                PathWriter = My.Computer.FileSystem.OpenTextFileWriter(Application.StartupPath & "\" & GameRef.name & "Path.txt", True)
                PathWriter.Write(DownloadPath.SelectedPath & "\" & GameRef.FullName & "\" & GameRef.name & ".exe")
                PathWriter.Close()

                DLUpdate = False
                CurrentDownloadBar = GameRef.DownloadBarRef
                DownloadedGame = GameRef

                Return True
            End If
            Return False
        Else
            Return False
        End If
    End Function

    Public Function UpdateGame(GameRef As Game) As Boolean
        Dim GameProcess = Process.GetProcessesByName(GameRef.FullName)
        If GameProcess.Count > 0 Then
            MsgBox(GameRef.FullName + " est ouvert ! Veuillez fermer le jeu pour le mettre à jour.", MsgBoxStyle.Critical)
            Return False
        End If

        Dim VersionURL = GameRef.versionURL
        Dim GameDirectory As String
        Dim PathReader As System.IO.StreamReader

        PathReader = My.Computer.FileSystem.OpenTextFileReader(directoryPath + "\" + GameRef.name + "Path.txt")
        GameDirectory = PathReader.ReadLine().Replace(GameRef.FullName + ".exe", "")

        wClient.DownloadFile(New Uri(GameRef.versionURL), GameDirectory + "\WebVersion")
        If CompareFiles(GameDirectory & "\CurrentVersion", GameDirectory & "\WebVersion") Then
            MsgBox(GameRef.FullName + " est déjà à jour.", MsgBoxStyle.Information)
            Return True
        Else
            'wClient.DownloadFile(New Uri(GameRef.downloadURL), GameDirectory + "\" + GameRef.name + "_Update")
            'Dim DLCmd = Process.Start("cmd.exe", "/c title " + GameRef.FullName + " Updater & cd " + GameDirectory + " & curl -L " & GameRef.downloadURL & " -o " + GameDirectory + "\" + GameRef.name + "_update & ren " + GameRef.name + "_update " + GameRef.name + "_update.zip & pause")
            'Process.Start("cmd.exe", "cd " & directoryPath & " & del FrenchPixelLauncher.exe & ren FPL_Update FrenchPixelLauncher.exe & del CurrentVersion & ren FPL_WebVersion CurrentVersion & pause")
            'Process.Start("cmd.exe", "/c title FPL Updater & cd " & GameDirectory & " & update.bat")
            'Dim Cmd As Process = Process.Start("cmd.exe", "cd " & directoryPath & " & del FrenchPixelLauncher.exe & ren FPL_Update FrenchPixelLauncher.exe & del CurrentVersion & ren FPL_WebVersion CurrentVersion & pause")
            'Cmd.WaitForExit(0)
            'Process.Start("cmd.exe", "title French Pixel Download & cd /d " & Application.StartupPath & "\ & curl -L " & LauncherRef.downloadURL & " -o " & Application.ExecutablePath & " & pause")

            Dim GameExePath As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\" & GameRef.name & "Path.txt")
            Dim GamePathReader As String = Replace(GameExePath, GameRef.name + ".exe", "")
            Dim CMD As Process = Process.Start("cmd.exe", "/c del /q /f /s " & GamePathReader)

            Dim AsNotExited As Boolean = True
            While AsNotExited
                If CMD.HasExited Then
                    AsNotExited = False
                    If CanDownload Then
                        CanDownload = False
                        Dim url As String = GameRef.downloadURL
                        wClient.DownloadFileTaskAsync(New Uri(GameRef.downloadURL), GamePathReader + ".zip")

                        UpdatePath = GamePathReader
                        DLUpdate = True
                        CurrentDownloadBar = GameRef.DownloadBarRef
                        DownloadedGame = GameRef

                        Return True
                    Else
                        Return False
                    End If
                End If
            End While
            'Process.Start("cmd.exe", "/c title " & GamePathReader & " & pause")

            Return False
        End If
    End Function

    Public Function LaunchGame(GameRef As Game) As Boolean
        Dim GamePathReader As String
        GamePathReader = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\" & GameRef.name & "Path.txt")

        Try
            Process.Start(GamePathReader)
            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return True
    End Function

    Public Function DownloadGameSource(GameRef As Game) As Boolean
        Dim url As String = GameRef.downloadSRCUrl
        If DownloadPath.ShowDialog() = DialogResult.OK Then
            Process.Start("cmd.exe", "/c title French Pixel Download - " & GameRef.FullName & " (Game source) & echo [1m[32m[4mBienvenue dans l'interface de téléchargement du French Pixel Launcheur (oui on utilise cmd.exe)[0m & cd " & DownloadPath.SelectedPath & "\ & curl -L " & url & " -o" & DownloadPath.SelectedPath & "\" & GameRef.name & "_src.zip & tar -xf " & DownloadPath.SelectedPath & "\" & GameRef.name & ".zip -C" & DownloadPath.SelectedPath & " & ren " & DownloadPath.SelectedPath & "\WindowsNoEditor " & GameRef.FullName & "Source & exit")
            Return True
        End If
        Return False
    End Function


    Private Sub UpdatedTimer_Tick(sender As Object, e As EventArgs) Handles UpdatedTimer.Tick
        'checkCOZUpdated()
    End Sub

    Dim isDEOptions As Boolean

    Private Sub OptionDE_Click(sender As Object, e As EventArgs) Handles OptionDE.Click
        If isDEOptions Then
            isDEOptions = False
            DownloadDungeonEditorSrc.Enabled = False
            DownloadDungeonEditorSrc.Visible = False
            UpdateDE.Visible = False
            UpdateDE.Enabled = False
        Else
            isDEOptions = True
            DownloadDungeonEditorSrc.Enabled = True
            DownloadDungeonEditorSrc.Visible = True
            UpdateDE.Visible = True
            UpdateDE.Enabled = True
        End If
    End Sub

    Dim isCOZOptions As Boolean
    Private Sub Btn_COZ_Options_Click(sender As Object, e As EventArgs) Handles Btn_COZ_Options.Click
        If isCOZOptions Then
            isCOZOptions = False
            DownloadCOZSrc.Enabled = False
            DownloadCOZSrc.Visible = False
            COZDownloadServer.Visible = False
            COZDownloadServer.Enabled = False
            UpdateCOZ.Visible = False
            UpdateCOZ.Enabled = False
        Else
            isCOZOptions = True
            DownloadCOZSrc.Enabled = True
            DownloadCOZSrc.Visible = True
            COZDownloadServer.Visible = True
            COZDownloadServer.Enabled = True
            UpdateCOZ.Visible = True
            UpdateCOZ.Enabled = True
        End If
    End Sub

    Private Sub BTN_COZ_Src(sender As Object, e As EventArgs) Handles DownloadCOZSrc.Click
        DownloadGameSource(COZ)
    End Sub

    Private Sub BTN_DE_Src(sender As Object, e As EventArgs) Handles DownloadDungeonEditorSrc.Click
        DownloadGameSource(DungeonEditor)
    End Sub

    Private Sub UpdateLauncher_Click(sender As Object, e As EventArgs) Handles UpdateLauncher.Click
        CheckLauncherVersion(Launcher, True)
    End Sub

    Private Sub BTNUpdateDE(sender As Object, e As EventArgs) Handles UpdateDE.Click
        UpdateGame(DungeonEditor)
    End Sub

    Private Sub UpdateCOZ_Click(sender As Object, e As EventArgs) Handles UpdateCOZ.Click
        UpdateGame(COZ)
    End Sub

    'Private Sub UpdateDE(sender As Object, e As EventArgs)
    '    UpdateGame(DungeonEditor)
    'End Sub

    'Public Function checkCOZUpdated() As Integer
    '    If COZDownloaded Then
    '        If CanAskUpdate Then
    '            CanAskUpdate = False
    '            'Shell("cmd.exe /c curl -L https://github.com/GCJOJO/COZ/releases/latest/download/latest.json -o coz.latest.json", AppWinStyle.Hide)
    '            'Dim newLatest As FileInfo = New FileInfo(Application.StartupPath & "\coz.latest.json")
    '            'Dim oldLatest As FileInfo = New FileInfo(COZPath.Text & "\latest.json")

    '            'If FilesContentsAreEqual(newLatest, oldLatest) Then
    '            'End If
    '            'If MsgBox("Mettre à jour COZ?", MsgBoxStyle.YesNo) = DialogResult.OK Then
    '            Return 0
    '            'End If
    '        End If
    '        Return 1
    '    End If
    '    Return 2
    'End Function

    'CTRL + K + C = Comment
    'CTRL + K + U = Uncomment

    'Public Shared Function filescontentsareequal(fileinfo1 As FileInfo, fileinfo2 As FileInfo) As Boolean
    '    Dim result As Boolean

    '    If fileinfo1.Length <> fileinfo2.Length Then
    '        Return False
    '    End If
    '    Using file1 = fileinfo1.OpenRead()
    '        Using file2 = fileinfo2.OpenRead()
    '            result = streamscontentsareequal(file1, file2)
    '        End Using
    '    End Using
    '    Return result
    'End Function

    'Public Shared Function streamscontentsareequal(stream1 As Stream, stream2 As Stream) As Boolean
    '    Const buffersize As Integer = 2048 * 2
    '    Dim buffer1 = New Byte(buffersize - 1) {}
    '    Dim buffer2 = New Byte(buffersize - 1) {}

    '    While True
    '        Dim count1 = stream1.Read(buffer1, 0, buffersize)
    '        Dim count2 = stream2.Read(buffer2, 0, buffersize)

    '        If count1 <> count2 Then
    '            Return False
    '        End If

    '        If count1 = 0 Then
    '            Return True
    '        End If

    '        Dim iterations = CInt(Math.Ceiling(CDbl(count1) / sizeof(Int64)))
    '        For i As var = 0 To iterations - 1
    '            If BitConverter.ToInt64(buffer1, i * sizeof(Int64)) <> BitConverter.ToInt64(buffer2, i * sizeof(Int64)) Then
    '                Return False
    '            End If
    '        Next
    '    End While
    'End Function


    Public Function CompareFiles(ByVal file1FullPath As String, ByVal file2FullPath As String) As Boolean

        If Not File.Exists(file1FullPath) Or Not File.Exists(file2FullPath) Then
            'One or both of the files does not exist.
            Return False
        End If

        If file1FullPath = file2FullPath Then
            ' fileFullPath1 and fileFullPath2 points to the same file...
            Return True
        End If

        Try
            Dim file1Hash As String = hashFile(file1FullPath)
            Dim file2Hash As String = hashFile(file2FullPath)

            If file1Hash = file2Hash Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function hashFile(ByVal filepath As String) As String
        Using reader As New System.IO.FileStream(filepath, IO.FileMode.Open, IO.FileAccess.Read)
            Using md5 As New System.Security.Cryptography.MD5CryptoServiceProvider
                Dim hash() As Byte = md5.ComputeHash(reader)
                Return System.Text.Encoding.Unicode.GetString(hash)
            End Using
        End Using
    End Function

    Private Sub wClient_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles wClient.DownloadProgressChanged
        CurrentDownloadBar.Maximum = e.TotalBytesToReceive
        CurrentDownloadBar.Value = e.BytesReceived
    End Sub

    Private Sub wClient_DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles wClient.DownloadFileCompleted
        If DLUpdate Then
            CurrentDownloadBar.Maximum = 100
            CurrentDownloadBar.Value = 0
            MsgBox("Le jeu à été télécharger !", MsgBoxStyle.Information)
            'Process.Start("cmd.exe", "/c title French Pixel Download - " & DownloadedGame.FullName & "& echo [1m[32m[4mBienvenue dans l'interface de téléchargement du French Pixel Launcheur (oui on utilise cmd.exe)[0m & cd /d " & DownloadPath.SelectedPath & "\ & curl -L " & DownloadedGame.url & " -o" & DownloadPath.SelectedPath & "\" & DownloadedGame.name & ".zip & tar -xf " & DownloadPath.SelectedPath & "\" & DownloadedGame.name & ".zip -C" & DownloadPath.SelectedPath & " & ren " & DownloadPath.SelectedPath & "\WindowsNoEditor " & GameRef.FullName & " & exit")
            Process.Start("cmd.exe", "/c title French Pixel Download - " & DownloadedGame.FullName & "& echo [1m[32m[4mBienvenue dans l'interface de téléchargement du French Pixel Launcheur (oui on utilise cmd.exe)[0m & cd /d " & UpdatePath & "\ & tar -xf " & UpdatePath & "\" & DownloadedGame.name & ".zip -C" & UpdatePath & " & ren " & UpdatePath & "\WindowsNoEditor " & DownloadedGame.FullName)
            CanDownload = True
        Else
            CurrentDownloadBar.Maximum = 100
            CurrentDownloadBar.Value = 0
            MsgBox("Le jeu à été télécharger !", MsgBoxStyle.Information)
            'Process.Start("cmd.exe", "/c title French Pixel Download - " & DownloadedGame.FullName & "& echo [1m[32m[4mBienvenue dans l'interface de téléchargement du French Pixel Launcheur (oui on utilise cmd.exe)[0m & cd /d " & DownloadPath.SelectedPath & "\ & curl -L " & DownloadedGame.url & " -o" & DownloadPath.SelectedPath & "\" & DownloadedGame.name & ".zip & tar -xf " & DownloadPath.SelectedPath & "\" & DownloadedGame.name & ".zip -C" & DownloadPath.SelectedPath & " & ren " & DownloadPath.SelectedPath & "\WindowsNoEditor " & GameRef.FullName & " & exit")
            Process.Start("cmd.exe", "/c title French Pixel Download - " & DownloadedGame.FullName & "& echo [1m[32m[4mBienvenue dans l'interface de téléchargement du French Pixel Launcheur (oui on utilise cmd.exe)[0m & cd /d " & DownloadPath.SelectedPath & "\ & tar -xf " & DownloadPath.SelectedPath & "\" & DownloadedGame.name & ".zip -C" & DownloadPath.SelectedPath & " & ren " & DownloadPath.SelectedPath & "\WindowsNoEditor " & DownloadedGame.FullName)
            CanDownload = True
        End If

    End Sub

    Private Sub DEImage_Click(sender As Object, e As EventArgs) Handles DEImage.Click
        Dim webAddress As String = "https://gcjojo.github.io/DungeonEditor"
        Process.Start(webAddress)
    End Sub

    Private Sub COZImage_Click(sender As Object, e As EventArgs) Handles COZBanner.Click
        Dim webAddress As String = "https://gcjojo.github.io/"
        Process.Start(webAddress)
    End Sub
End Class
'Shell("cmd.exe /c " + COZDownloadPath.SelectedPath, AppWinStyle.Hide)
'COZPath.Text = COZDownloadPath.SelectedPath