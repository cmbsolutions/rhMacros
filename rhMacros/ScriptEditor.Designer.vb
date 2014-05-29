<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScriptEditor
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScriptEditor))
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.ScriptBox = New System.Windows.Forms.RichTextBox()
        Me.AutocompleteMenu1 = New AutocompleteMenuNS.AutocompleteMenu()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Location = New System.Drawing.Point(167, 191)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(58, 23)
        Me.cmdOk.TabIndex = 3
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'ScriptBox
        '
        Me.ScriptBox.AcceptsTab = True
        Me.ScriptBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AutocompleteMenu1.SetAutocompleteMenu(Me.ScriptBox, Me.AutocompleteMenu1)
        Me.ScriptBox.Location = New System.Drawing.Point(1, 1)
        Me.ScriptBox.Name = "ScriptBox"
        Me.ScriptBox.Size = New System.Drawing.Size(290, 186)
        Me.ScriptBox.TabIndex = 2
        Me.ScriptBox.Text = ""
        Me.ScriptBox.WordWrap = False
        '
        'AutocompleteMenu1
        '
        Me.AutocompleteMenu1.AllowsTabKey = True
        Me.AutocompleteMenu1.AppearInterval = 300
        Me.AutocompleteMenu1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutocompleteMenu1.ImageList = Me.ImageList1
        Me.AutocompleteMenu1.Items = New String(-1) {}
        Me.AutocompleteMenu1.MinFragmentLength = 1
        Me.AutocompleteMenu1.TargetControlWrapper = Nothing
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "resources.ico")
        Me.ImageList1.Images.SetKeyName(1, "media-flash-sd-mmc.ico")
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdCancel.Location = New System.Drawing.Point(231, 191)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(58, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'ScriptEditor
        '
        Me.AcceptButton = Me.cmdOk
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(292, 217)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.ScriptBox)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ScriptEditor"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "ScriptEditor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents ScriptBox As System.Windows.Forms.RichTextBox
    Private WithEvents AutocompleteMenu1 As AutocompleteMenuNS.AutocompleteMenu
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
