Imports System.Windows.Forms

Public Class MacroPropertiesDialog
    Public Property LocalMacro As Macro
    Public Event PerformUiUpdateEvent(sender As Object, e As EventArgs)

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles OK_Button.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub MacroPropertiesDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If LocalMacro IsNot Nothing Then
                pgMacro.SelectedObject = LocalMacro
            End If
        Catch ex As Exception
            MessageBox.Show("Something went wrong while loading the propertydialog.", "Error loading propertydialog", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pgMacro_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles pgMacro.PropertyValueChanged
        RaiseEvent PerformUiUpdateEvent(Me, Nothing)
    End Sub
End Class
