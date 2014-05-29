Namespace PropertyEditors
    Public Class ScriptPropertyEditor
        Inherits PropertyEditorBase

        Private WithEvents _ctrl As ScriptEditor

        Protected Overrides Function GetEditForm(propertyName As String, currentValue As Object) As Windows.Forms.Form
            _ctrl = New ScriptEditor

            If currentValue IsNot Nothing Then
                _ctrl.Contents = currentValue.ToString
            Else
                _ctrl.Contents = ""
            End If
            Return _ctrl
        End Function

        Protected Overrides Function GetEditedValue(editControl As Windows.Forms.Form, propertyName As String, oldValue As Object) As Object
            Return _ctrl.Contents
        End Function
    End Class
End Namespace