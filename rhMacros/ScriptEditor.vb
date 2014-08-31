Imports System.Drawing
Imports AutocompleteMenuNS
Imports System.Windows.Forms

Public Class ScriptEditor
    Public Property Contents() As String
        Get
            Return String.Join(Environment.NewLine, ScriptBox.Lines)
        End Get
        Set(value As String)
            ScriptBox.Lines = value.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
        End Set
    End Property

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub ScriptEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        AutocompleteMenu1.MaximumSize = New Size(650, 200)
        Dim columnWidth As Integer() = {50, 300, 300}

        Dim cc As New CodeCompletion.CodeCompletions
        If RhMacrosFileHandler(Of CodeCompletion.CodeCompletions).LoadObject(cc, My.Resources.CodeCompletion) Then

            For Each c In cc.Entries
                AutocompleteMenu1.AddItem(New MulticolumnAutocompleteItem({c.Code, c.Description, c.Parameters}, c.Code) With {.ColumnWidth = columnWidth, .ImageIndex = c.IconId})
            Next
        End If
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
End Class
