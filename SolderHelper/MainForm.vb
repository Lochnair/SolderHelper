Imports System.IO
Imports Ionic.Zip

Public Class MainForm

    Private Sub BrowseFolder(ByRef textBox As TextBox)
        Dim dialog As New FolderBrowserDialog

        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            textBox.Text = dialog.SelectedPath
        End If
    End Sub

    Private Sub btn_browseMods_Click(sender As Object, e As EventArgs) Handles btn_browseMods.Click
        BrowseFolder(txt_mods)
    End Sub

    Private Sub btn_browseOutput_Click(sender As Object, e As EventArgs) Handles btn_browseOutput.Click
        BrowseFolder(txt_output)
    End Sub

    Private Sub btn_run_Click(sender As Object, e As EventArgs) Handles btn_run.Click
        If String.IsNullOrEmpty(txt_mods.Text) Or Not Directory.Exists(txt_mods.Text) Then
            MsgBox("Choose a mods folder first!")
            Exit Sub
        End If

        If String.IsNullOrEmpty(txt_output.Text) Or Not Directory.Exists(txt_output.Text) Then
            MsgBox("Choose a output folder first!")
            Exit Sub
        End If

        Dim mods() As String = GetFiles(txt_mods.Text, "*.jar|*.zip", SearchOption.TopDirectoryOnly)
        Dim output As String = txt_output.Text

        For Each path As String In mods
            Dim fInfo As FileInfo = My.Computer.FileSystem.GetFileInfo(path)
            Dim dialog As New ModInfoDialog
            Dim name As String = fInfo.Name.Replace(fInfo.Extension, "").ToLower()

            Try
                Dim versionStart = name.LastIndexOf("-") + 1
                dialog.Slug = name.Substring(0, versionStart - 1)
                dialog.Version = name.Substring(versionStart, name.Length - versionStart)
            Catch ex As Exception
                dialog.Slug = name
            End Try

            dialog.ShowDialog()

            Using zip As ZipFile = New ZipFile()
                Dim entry As ZipEntry = zip.AddFile(path, "/mods/")
                My.Computer.FileSystem.CreateDirectory(output & "\" & dialog.Slug)
                zip.AddDirectoryByName("/config")
                zip.Save(output & "\" & dialog.Slug & "\" & dialog.Slug & "-" & dialog.Version & ".zip")
            End Using
        Next
    End Sub

    Private Function GetFiles(ByVal directory As String, ByVal searchPattern As String, ByVal searchOption As SearchOption) As String()
        Dim searchPatterns() = searchPattern.Split("|")
        Dim files As New List(Of String)

        For Each pattern As String In searchPatterns
            files.AddRange(System.IO.Directory.GetFiles(directory, pattern, searchOption))
        Next

        files.Sort()

        Return files.ToArray()
    End Function
End Class
