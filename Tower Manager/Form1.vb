Imports System.IO
Public Class Form1

    Function FilePick(FileType As String, FileTypeDesc As String)
        Dim Picker As New OpenFileDialog()
        Picker.Filter = FileTypeDesc + "|*." + FileType
        If Picker.ShowDialog() = DialogResult.OK Then
            Return Picker.FileName
        End If
        Return False
    End Function

    Function FolderPick()
        Dim Picker As New OpenFileDialog()
        Picker.ValidateNames = False
        Picker.CheckFileExists = False
        Picker.CheckPathExists = True
        Picker.FileName = "Resources"

        If Picker.ShowDialog() = DialogResult.OK Then
            Return Path.GetDirectoryName(Picker.FileName)
        End If
        Return False
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Folder = FolderPick()
        If Not Directory.Exists(Path.Combine(Folder, "levels")) Then
            MsgBox("This is not a valid Resources directory. Make sure that you use a 2.2 Resource directory!")
            Return
        End If
        TextBox1.Text = Folder
        Dim BackupFolder = Path.Combine(Folder, "bcp")
        If Not Directory.Exists(BackupFolder) Then
            Directory.CreateDirectory(BackupFolder)
            My.Computer.FileSystem.CopyDirectory(Path.Combine(Folder, "levels"), Path.Combine(BackupFolder, "levels"), True)
            My.Computer.FileSystem.CopyDirectory(Path.Combine(Folder, "songs"), Path.Combine(BackupFolder, "songs"), True)
            MsgBox("A backup directory has been successfully created at" + Environment.NewLine + Environment.NewLine + BackupFolder)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Level = FilePick("*", "Raw or encoded Geometry Dash level")
        TextBox2.Text = Level
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Level = FilePick("ogg", "OGG Song File")
        TextBox3.Text = Level
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://dsc.gg/dimisaio")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Lvl = ComboBox1.Text
        Dim levels = Path.Combine(TextBox1.Text, "levels")
        Dim songs = Path.Combine(TextBox1.Text, "songs")
        Dim Lvl1File = Path.Combine(levels, "5001.txt")
        Dim Lvl1Song = Path.Combine(songs, "10003039.ogg")

        Dim Lvl2File = Path.Combine(levels, "5002.txt")
        Dim Lvl2Song = Path.Combine(songs, "10003129.ogg")

        Dim Lvl3File = Path.Combine(levels, "5003.txt")
        Dim Lvl3Song = Path.Combine(songs, "10002875.ogg")

        Dim Lvl4File = Path.Combine(levels, "5004.txt")
        Dim Lvl4Song = Path.Combine(songs, "10006086.ogg")

        Dim NewLevel = TextBox2.Text
        Dim NewLevelSong = TextBox3.Text

        If Lvl = "Lvl1" Then
            File.Copy(NewLevel, Lvl1File, True)
            File.Copy(NewLevelSong, Lvl1Song, True)
        ElseIf Lvl = "Lvl2" Then
            File.Copy(NewLevel, Lvl2File, True)
            File.Copy(NewLevelSong, Lvl2Song, True)
        ElseIf Lvl = "Lvl3" Then
            File.Copy(NewLevel, Lvl3File, True)
            File.Copy(NewLevelSong, Lvl3Song, True)
        ElseIf Lvl = "Lvl4" Then
            File.Copy(NewLevel, Lvl4File, True)
            File.Copy(NewLevelSong, Lvl4Song, True)
        End If
        MsgBox("Done :D")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("explorer.exe", Path.Combine(TextBox1.Text, "bcp"))
    End Sub
End Class
