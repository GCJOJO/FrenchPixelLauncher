Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System
Imports System.Diagnostics

Public Structure Game
    Dim name As String
    Dim FullName As String
    Dim downloadURL As String
    Dim versionURL As String
End Structure

Class MainWindow
    Private WithEvents wClient As WebClient
    Dim Launcher As Game
    Dim directoryPath As String = My.Application.Info.DirectoryPath

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        wClient = New WebClient
        Launcher.name = "Launcher"
        Launcher.FullName = "Launcher"
        Launcher.downloadURL = "https://github.com/GCJOJO/FrenchPixelLauncher/releases/latest/download/FrenchPixelLauncher.exe"
        Launcher.versionURL = "https://github.com/GCJOJO/FrenchPixelLauncher/releases/latest/download/FPL_WebVersion"
        Try
            wClient.DownloadFileAsync(New Uri(Launcher.downloadURL), directoryPath + "\FPL_Update")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub wClient_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles wClient.DownloadProgressChanged
        DownloadProgressBar.Maximum = e.TotalBytesToReceive
        DownloadProgressBar.Value = e.BytesReceived
    End Sub

    Private Sub wClient_DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles wClient.DownloadFileCompleted
        DownloadProgressBar.Maximum = 100
        DownloadProgressBar.Value = 100
        DownloadText.Content = "Téléchargé !"
        MsgBox("La mise à jour à été télécharger. Lancement du Launcher", MsgBoxStyle.Information)
        Dim CMD As Process = Process.Start("cmd", "/c cd " + directoryPath + " & del FrenchPixelLauncher.exe & ren FPL_Update FrenchPixelLauncher.exe & del CurrentVersion & ren FPL_WebVersion CurrentVersion")
        Dim HasNotToExit As Boolean = True
        While HasNotToExit
            If CMD.HasExited Then
                Process.Start(directoryPath + "\FrenchPixelLauncher.exe")
                Close()
                HasNotToExit = False
            End If
        End While
    End Sub
End Class
