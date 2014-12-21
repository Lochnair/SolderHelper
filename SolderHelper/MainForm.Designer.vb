<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.btn_browseMods = New System.Windows.Forms.Button()
        Me.txt_mods = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_browseOutput = New System.Windows.Forms.Button()
        Me.txt_output = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_run = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_browseMods
        '
        Me.btn_browseMods.Location = New System.Drawing.Point(349, 9)
        Me.btn_browseMods.Name = "btn_browseMods"
        Me.btn_browseMods.Size = New System.Drawing.Size(57, 20)
        Me.btn_browseMods.TabIndex = 0
        Me.btn_browseMods.Text = "Browse"
        Me.btn_browseMods.UseVisualStyleBackColor = True
        '
        'txt_mods
        '
        Me.txt_mods.BackColor = System.Drawing.Color.White
        Me.txt_mods.Location = New System.Drawing.Point(89, 9)
        Me.txt_mods.Name = "txt_mods"
        Me.txt_mods.ReadOnly = True
        Me.txt_mods.Size = New System.Drawing.Size(254, 20)
        Me.txt_mods.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Mods folder:"
        '
        'btn_browseOutput
        '
        Me.btn_browseOutput.Location = New System.Drawing.Point(349, 39)
        Me.btn_browseOutput.Name = "btn_browseOutput"
        Me.btn_browseOutput.Size = New System.Drawing.Size(57, 20)
        Me.btn_browseOutput.TabIndex = 3
        Me.btn_browseOutput.Text = "Browse"
        Me.btn_browseOutput.UseVisualStyleBackColor = True
        '
        'txt_output
        '
        Me.txt_output.BackColor = System.Drawing.Color.White
        Me.txt_output.Location = New System.Drawing.Point(89, 39)
        Me.txt_output.Name = "txt_output"
        Me.txt_output.ReadOnly = True
        Me.txt_output.Size = New System.Drawing.Size(254, 20)
        Me.txt_output.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Output folder:"
        '
        'btn_run
        '
        Me.btn_run.Location = New System.Drawing.Point(349, 65)
        Me.btn_run.Name = "btn_run"
        Me.btn_run.Size = New System.Drawing.Size(57, 20)
        Me.btn_run.TabIndex = 6
        Me.btn_run.Text = "Run"
        Me.btn_run.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 95)
        Me.Controls.Add(Me.btn_run)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_output)
        Me.Controls.Add(Me.btn_browseOutput)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_mods)
        Me.Controls.Add(Me.btn_browseMods)
        Me.Name = "MainForm"
        Me.Text = "SolderHelper v0.1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_browseMods As System.Windows.Forms.Button
    Friend WithEvents txt_mods As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_browseOutput As System.Windows.Forms.Button
    Friend WithEvents txt_output As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_run As System.Windows.Forms.Button

End Class
