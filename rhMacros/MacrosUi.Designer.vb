<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MacrosUi
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.tsRhMacrosMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbNewMacro = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditMacro = New System.Windows.Forms.ToolStripButton()
        Me.tsbDeleteMacro = New System.Windows.Forms.ToolStripButton()
        Me.tsbSaveMacro = New System.Windows.Forms.ToolStripButton()
        Me.tsbHelp = New System.Windows.Forms.ToolStripButton()
        Me.flpMacros = New System.Windows.Forms.FlowLayoutPanel()
        Me.ttMacroButtons = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmsMacroButtons = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditPropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExecuteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DdToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me.tsRhMacrosMenu.SuspendLayout()
        Me.cmsMacroButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsRhMacrosMenu
        '
        Me.tsRhMacrosMenu.AllowMerge = False
        Me.tsRhMacrosMenu.BackgroundImage = Global.rhMacros.My.Resources.Resources.MenuBarBG
        Me.tsRhMacrosMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tsRhMacrosMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsRhMacrosMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNewMacro, Me.tsbEditMacro, Me.tsbDeleteMacro, Me.tsbSaveMacro, Me.tsbHelp})
        Me.tsRhMacrosMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.tsRhMacrosMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsRhMacrosMenu.Name = "tsRhMacrosMenu"
        Me.tsRhMacrosMenu.Size = New System.Drawing.Size(402, 38)
        Me.tsRhMacrosMenu.TabIndex = 1
        '
        'tsbNewMacro
        '
        Me.tsbNewMacro.Image = Global.rhMacros.My.Resources.Resources.brick_add
        Me.tsbNewMacro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNewMacro.Name = "tsbNewMacro"
        Me.tsbNewMacro.Size = New System.Drawing.Size(44, 35)
        Me.tsbNewMacro.Text = "New..."
        Me.tsbNewMacro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbNewMacro.ToolTipText = "Create new macro"
        '
        'tsbEditMacro
        '
        Me.tsbEditMacro.Image = Global.rhMacros.My.Resources.Resources.brick_edit
        Me.tsbEditMacro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditMacro.Name = "tsbEditMacro"
        Me.tsbEditMacro.Size = New System.Drawing.Size(40, 35)
        Me.tsbEditMacro.Text = "Edit..."
        Me.tsbEditMacro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbEditMacro.ToolTipText = "Edit selected macro"
        '
        'tsbDeleteMacro
        '
        Me.tsbDeleteMacro.Image = Global.rhMacros.My.Resources.Resources.brick_delete
        Me.tsbDeleteMacro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDeleteMacro.Name = "tsbDeleteMacro"
        Me.tsbDeleteMacro.Size = New System.Drawing.Size(53, 35)
        Me.tsbDeleteMacro.Text = "Delete..."
        Me.tsbDeleteMacro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbDeleteMacro.ToolTipText = "Delete selected macro"
        '
        'tsbSaveMacro
        '
        Me.tsbSaveMacro.Image = Global.rhMacros.My.Resources.Resources.disk
        Me.tsbSaveMacro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSaveMacro.Name = "tsbSaveMacro"
        Me.tsbSaveMacro.Size = New System.Drawing.Size(44, 35)
        Me.tsbSaveMacro.Text = "Save..."
        Me.tsbSaveMacro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbSaveMacro.ToolTipText = "Save macro's to disk"
        '
        'tsbHelp
        '
        Me.tsbHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbHelp.Image = Global.rhMacros.My.Resources.Resources.help
        Me.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbHelp.Name = "tsbHelp"
        Me.tsbHelp.Size = New System.Drawing.Size(45, 35)
        Me.tsbHelp.Text = "Help..."
        Me.tsbHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbHelp.ToolTipText = "Show help"
        '
        'flpMacros
        '
        Me.flpMacros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpMacros.Location = New System.Drawing.Point(0, 38)
        Me.flpMacros.Name = "flpMacros"
        Me.flpMacros.Size = New System.Drawing.Size(402, 304)
        Me.flpMacros.TabIndex = 2
        '
        'cmsMacroButtons
        '
        Me.cmsMacroButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditPropertiesToolStripMenuItem, Me.ExecuteToolStripMenuItem, Me.DdToolStripMenuItem, Me.RemoveToolStripMenuItem})
        Me.cmsMacroButtons.Name = "cmsMacroButtons"
        Me.cmsMacroButtons.Size = New System.Drawing.Size(153, 98)
        '
        'EditPropertiesToolStripMenuItem
        '
        Me.EditPropertiesToolStripMenuItem.Image = Global.rhMacros.My.Resources.Resources.brick_edit
        Me.EditPropertiesToolStripMenuItem.Name = "EditPropertiesToolStripMenuItem"
        Me.EditPropertiesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EditPropertiesToolStripMenuItem.Text = "Edit properties"
        '
        'ExecuteToolStripMenuItem
        '
        Me.ExecuteToolStripMenuItem.Image = Global.rhMacros.My.Resources.Resources.brick_go
        Me.ExecuteToolStripMenuItem.Name = "ExecuteToolStripMenuItem"
        Me.ExecuteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExecuteToolStripMenuItem.Text = "Execute"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Image = Global.rhMacros.My.Resources.Resources.brick_delete
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'DdToolStripMenuItem
        '
        Me.DdToolStripMenuItem.Name = "DdToolStripMenuItem"
        Me.DdToolStripMenuItem.Size = New System.Drawing.Size(149, 6)
        '
        'MacrosUi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.flpMacros)
        Me.Controls.Add(Me.tsRhMacrosMenu)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "MacrosUi"
        Me.Size = New System.Drawing.Size(402, 342)
        Me.tsRhMacrosMenu.ResumeLayout(False)
        Me.tsRhMacrosMenu.PerformLayout()
        Me.cmsMacroButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsRhMacrosMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNewMacro As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditMacro As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDeleteMacro As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSaveMacro As System.Windows.Forms.ToolStripButton
    Friend WithEvents flpMacros As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tsbHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents ttMacroButtons As System.Windows.Forms.ToolTip
    Friend WithEvents cmsMacroButtons As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditPropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExecuteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DdToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
