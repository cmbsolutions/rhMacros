Imports System.Windows.Forms
Imports System.IO
Imports RepetierHostExtender.interfaces
Imports rhMacros.My.Resources

Public Class MacrosUi
    Implements IHostComponent

    Public Property Host As IHost
    Public Property Macros As MacrosCollection
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
            Return 8001 'TODO: figure out how to get order from Repetier Host
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
                    LoadMacroSets()
                End If
            End If

            Return True
        Catch ex As Exception
            MessageBox.Show(MacrosUi_Connect_Error_Message, MacrosUi_Connect_Error_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub LoadMacroSets()
        Try
            'TODO: Add loader code
        Catch ex As Exception
            MessageBox.Show(MacrosUi_LoadMacroSets_Error_Message, MacrosUi_LoadMacroSets_Error_title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
