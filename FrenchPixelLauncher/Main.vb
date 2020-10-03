Public Structure Game
    Dim name As String
    Dim id As Integer
    Dim FullName As String
    Dim downloadURL As String
    Dim downloadSRCUrl As String
End Structure



Public Class Main

    Dim COZDownloaded As Boolean
    Dim DEDownloaded As Boolean
    'Dim CanAskUpdate As Boolean = True

    Dim COZ As Game
    Dim DungeonEditor As Game

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        COZ.name = "COZ"
        COZ.FullName = "ClashOfZombies"
        COZ.id = 0
        COZ.downloadURL = "https://github.com/GCJOJO/COZ/releases/latest/download/COZWindows.zip"
        COZ.downloadSRCUrl = "https://github.com/GCJOJO/COZ/archive/master.zip"

        DungeonEditor.name = "DungeonEditor"
        DungeonEditor.FullName = "DungeonEditor"
        DungeonEditor.id = 1
        DungeonEditor.downloadURL = "https://github.com/GCJOJO/DungeonEditor/releases/latest/download/DungeonEditorWindows.zip"
        DungeonEditor.downloadSRCUrl = "https://github.com/GCJOJO/DungeonEditor/archive/master.zip"

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

    Public Function DownloadGame(GameRef As Game) As Boolean
        Dim url As String = GameRef.downloadURL
        If DownloadPath.ShowDialog() = DialogResult.OK Then

            Dim PathWriter As System.IO.StreamWriter
            PathWriter = My.Computer.FileSystem.OpenTextFileWriter(Application.StartupPath & "\" & GameRef.name & "Path.txt", True)
            PathWriter.Write(DownloadPath.SelectedPath & "\" & GameRef.FullName & "\" & GameRef.name & ".exe")
            PathWriter.Close()

            Process.Start("cmd.exe", "/c title French Pixel Download - " & GameRef.FullName & "& echo [1m[32m[4mBienvenue dans l'interface de téléchargement du French Pixel Launcheur (oui on utilise cmd.exe)[0m & cd " & DownloadPath.SelectedPath & "\ & curl -L " & url & " -o" & DownloadPath.SelectedPath & "\" & GameRef.name & ".zip & tar -xf " & DownloadPath.SelectedPath & "\" & GameRef.name & ".zip -C" & DownloadPath.SelectedPath & " & ren " & DownloadPath.SelectedPath & "\WindowsNoEditor " & GameRef.FullName & " & exit")
            Return True
        End If
        Return False
    End Function

    Public Function LaunchGame(GameRef As Game) As Boolean
        Dim GamePathReader As String
        GamePathReader = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\" & GameRef.name & "Path.txt")
        Process.Start(GamePathReader)
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
        Else
            isDEOptions = True
            DownloadDungeonEditorSrc.Enabled = True
            DownloadDungeonEditorSrc.Visible = True
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
        Else
            isCOZOptions = True
            DownloadCOZSrc.Enabled = True
            DownloadCOZSrc.Visible = True
            COZDownloadServer.Visible = True
            COZDownloadServer.Enabled = True
        End If
    End Sub

    Private Sub BTN_COZ_Src(sender As Object, e As EventArgs) Handles DownloadCOZSrc.Click
        DownloadGameSource(COZ)
    End Sub

    Private Sub BTN_DE_Src(sender As Object, e As EventArgs) Handles DownloadDungeonEditorSrc.Click
        DownloadGameSource(DungeonEditor)
    End Sub

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

End Class
'Shell("cmd.exe /c " + COZDownloadPath.SelectedPath, AppWinStyle.Hide)
'COZPath.Text = COZDownloadPath.SelectedPath