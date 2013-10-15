Imports System.Windows.Forms

Public Class ModInfoDialog

    Private modSlug As String
    Private modVersion As String

    Private Sub ModInfoDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Me.Slug
        Me.txt_modSlug.Text = Me.Slug
        Me.txt_version.Text = Me.Version
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If String.IsNullOrEmpty(txt_modSlug.Text) Then
            MsgBox("Mod Slug can't be empty")
            Exit Sub
        End If

        If String.IsNullOrEmpty(txt_version.Text) Then
            MsgBox("Version can't be empty")
            Exit Sub
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Slug = txt_modSlug.Text
        Me.Version = txt_version.Text
        Me.Close()
    End Sub

    Public Property Slug As String
        Get
            Return modSlug
        End Get
        Set(value As String)
            modSlug = value
        End Set
    End Property

    Public Property Version As String
        Get
            Return modVersion
        End Get
        Set(value As String)
            modVersion = value
        End Set
    End Property
End Class
