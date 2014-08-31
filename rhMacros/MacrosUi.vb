Imports System.Windows.Forms
Imports System.IO
Imports RepetierHostExtender.interfaces
Imports rhMacros.My.Resources

Public Class MacrosUi
	Implements IHostComponent

	Private Delegate Sub PerformUiUpdateEventHandlerDelegate(sender As Object, e As EventArgs)

	Public Property Host As IHost
	Public Property Macros As MacroCollection
	Public Property SettingsFile As FileInfo

	Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.

	End Sub

#Region "IHostComponent procedures"
	Public ReadOnly Property ComponentControl As Windows.Forms.Control Implements IHostComponent.ComponentControl
		Get
			Return Me
		End Get
	End Property

	Public ReadOnly Property ComponentDescription As String Implements IHostComponent.ComponentDescription
		Get
			Return "rhMacro's"
		End Get
	End Property

	Public ReadOnly Property ComponentName As String Implements IHostComponent.ComponentName
		Get
			Return "rhMacros"
		End Get
	End Property

	Public ReadOnly Property ComponentOrder As Integer Implements IHostComponent.ComponentOrder
		Get
			Return 8001	'TODO: figure out how to get order from Repetier Host
		End Get
	End Property

	Public ReadOnly Property PreferredPosition As PreferredComponentPositions Implements IHostComponent.PreferredPosition
		Get
			Return PreferredComponentPositions.SIDEBAR
		End Get
	End Property
#End Region

	Public Function Connect(ByRef paramHost As IHost) As Boolean
		Try
			' Set the host so we can use RepetierHosts functions
			Host = paramHost

			' Try to get the plugins registry folder managed by RepetierHost
			Dim regMemFolder As IRegMemoryFolder = Host.GetRegistryFolder("rhMacros")

			' if no folder found, only connect, load nothing
			If regMemFolder IsNot Nothing Then
				' Try to get the xml file with the defined macros
				SettingsFile = New FileInfo(regMemFolder.GetString("SettingsFile", Path.Combine(Host.WorkingDirectory, "plugins\rhMacros\default.xml")))

				' No folder? exit the connect, probably not installed correctly
				If Not SettingsFile.Directory.Exists Then
					MessageBox.Show(MacrosUi_Connect_PathNotFound_Message, MacrosUi_Connect_PathNotFound_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
					Return False
				Else
					' All is good, load the xml file
					LoadMacros()
				End If
			End If

			Return True
		Catch ex As Exception
			MessageBox.Show(MacrosUi_Connect_Error_Message, MacrosUi_Connect_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return False
		End Try
	End Function

	Private Sub LoadMacros()
		Try
			' extra check if file exists
			If Not SettingsFile.Exists OrElse (SettingsFile.Exists AndAlso SettingsFile.Length = 0) Then Exit Sub
			' Check if local var is initialized, oif not, create new
			If Macros Is Nothing Then Macros = New MacroCollection
			' Try to load settingsfile into local var
			If RhMacrosFileHandler(Of MacroCollection).LoadObject(Macros, SettingsFile) Then
				' Render the macro buttons onto the control
				ShowMacroButtons()
			End If
		Catch ex As Exception
			MessageBox.Show(MacrosUi_LoadMacroSets_Error_Message, MacrosUi_LoadMacroSets_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub SaveMacros()
		Try
			If Macros Is Nothing Then Exit Sub ' nothing to save

			' extra check if file exists, if not, create it
			If Not SettingsFile.Exists Then
				Using fs As FileStream = SettingsFile.Create()
					fs.Unlock(0, fs.Length)
				End Using
			End If

			' Try to save settingsfile from local var
			If RhMacrosFileHandler(Of MacroCollection).SaveObject(Macros, SettingsFile) Then
				' Render the macro buttons onto the control
				ShowMacroButtons()
			End If
		Catch ex As Exception
			MessageBox.Show(MacrosUi_LoadMacroSets_Error_Message, MacrosUi_LoadMacroSets_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub ShowMacroButtons()
		Try
			' If there are buttons on the flowpanel remove the handlers
			For Each b As Button In (From ctl As Object In flpMacros.Controls Where ctl.GetType Is GetType(Button)).OfType(Of Button)()
				RemoveHandler b.Click, AddressOf MacroButtonClickHandler
			Next

			flpMacros.Controls.Clear()

			For Each mcr In From m In Macros.Macros Select New With {.button = m.RenderButton, .macro = m}
				AddHandler mcr.button.Click, AddressOf MacroButtonClickHandler
				ttMacroButtons.SetToolTip(mcr.button, mcr.macro.ToolTip)
				mcr.button.ContextMenuStrip = cmsMacroButtons
				flpMacros.Controls.Add(mcr.button)
			Next
		Catch ex As Exception
			MessageBox.Show(MacrosUi_ShowMacroButtons_Error_Message, MacrosUi_ShowMacroButtons_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub MacroButtonClickHandler(sender As Object, e As EventArgs)
		Try
			Dim b As Button = TryCast(sender, Button)

			If b IsNot Nothing Then
				ExecuteMacro(Macros.MacroByName(b.Name))
			End If
		Catch ex As Exception
			MessageBox.Show(Format(MacrosUI_CommandErrorMessage_Template, MacrosUI_Command_Execute), Format(MacrosUI_CommandErrorTitle_Template, MacrosUI_Command_Execute), MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub ExecuteMacro(m As Macro)
		Try
			If m.Script Is Nothing Then Exit Sub
			If m.ShowConfirm Then
				If m.ConfirmMessage.Length > 0 Then
					If MessageBox.Show(m.ConfirmMessage, MacrosUi_ExecuteMacro_Macro_confirmation_message_Title, m.ConfirmButtons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = m.ConfirmButton Then
						For Each ln As String In m.Script.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
							Host.Connection.injectManualCommand(ln)
							Host.LogMessage(String.Format("Macrocommand: {0} sent.", ln))
						Next
					End If
				End If
			Else
				For Each ln As String In m.Script.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
					Host.Connection.injectManualCommand(ln)
					Host.LogMessage(String.Format("Macrocommand: {0} sent.", ln))
				Next
			End If
		Catch ex As Exception
			Throw
		End Try
	End Sub

	Private Sub tsbNewMacro_Click(sender As Object, e As EventArgs) Handles tsbNewMacro.Click
		Try
			If Macros Is Nothing Then Macros = New MacroCollection()

			Macros.Macros.Add(New Macro)
			SaveMacros()
			ShowMacroButtons()
		Catch ex As Exception
			MessageBox.Show(Format(MacrosUI_CommandErrorMessage_Template, MacrosUI_Command_Add), Format(MacrosUI_CommandErrorTitle_Template, MacrosUI_Command_Add), MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub EditPropertiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditPropertiesToolStripMenuItem.Click
		Try
			Dim b As Button = TryCast(DirectCast(DirectCast(sender, ToolStripMenuItem).Owner, ContextMenuStrip).SourceControl, Button)

			If b IsNot Nothing Then
				Dim mcr As Macro = Macros.Macros.Where(Function(m) m.Name = b.Name).FirstOrDefault
				Dim frx As New MacroPropertiesDialog

				frx.LocalMacro = mcr
				AddHandler frx.PerformUiUpdateEvent, AddressOf PerformUiUpdateEventHandler

				frx.Show()
			End If

			ShowMacroButtons()
		Catch ex As Exception
			MessageBox.Show(Format(MacrosUI_CommandErrorMessage_Template, MacrosUI_Command_Edit), Format(MacrosUI_CommandErrorTitle_Template, MacrosUI_Command_Edit), MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub ExecuteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExecuteToolStripMenuItem.Click
		Try
			Dim b As Button = TryCast(DirectCast(DirectCast(sender, ToolStripMenuItem).Owner, ContextMenuStrip).SourceControl, Button)

			If b IsNot Nothing Then b.PerformClick()

		Catch ex As Exception
			MessageBox.Show(Format(MacrosUI_CommandErrorMessage_Template, MacrosUI_Command_Execute), Format(MacrosUI_CommandErrorTitle_Template, MacrosUI_Command_Execute), MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
		Try
			Dim b As Button = TryCast(DirectCast(DirectCast(sender, ToolStripMenuItem).Owner, ContextMenuStrip).SourceControl, Button)

			If b IsNot Nothing Then
				If MessageBox.Show(MacrosUI_Command_Delete_Question, Format(MacrosUI_CommandErrorTitle_Template, MacrosUI_Command_Delete), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
					For Each m In From m1 In Macros.Macros Where m1.Name = b.Name
						Macros.Macros.Remove(m)
						Exit For
					Next
				End If
				SaveMacros()

				ShowMacroButtons()
			End If
		Catch ex As Exception
			MessageBox.Show(Format(MacrosUI_CommandErrorMessage_Template, MacrosUI_Command_Delete), Format(MacrosUI_CommandErrorTitle_Template, MacrosUI_Command_Delete), MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub PerformUiUpdateEventHandler(sender As Object, e As EventArgs)
		If InvokeRequired Then
			Dim d As New PerformUiUpdateEventHandlerDelegate(AddressOf PerformUiUpdateEventHandler)

			Invoke(d, Me, e)
		Else
			SaveMacros()
			ShowMacroButtons()
		End If
	End Sub

	Private Sub tsbSaveMacro_Click(sender As Object, e As EventArgs) Handles tsbSaveMacro.Click
		SaveMacros()
		MessageBox.Show("Macro's saved")
	End Sub

	Public ReadOnly Property Associated3DView As RepetierHostExtender.geom.ThreeDView Implements IHostComponent.Associated3DView
		Get
			Return Nothing
		End Get
	End Property

	Public Sub ComponentActivated() Implements IHostComponent.ComponentActivated
		Debug.Print("M'kay")
	End Sub
End Class
