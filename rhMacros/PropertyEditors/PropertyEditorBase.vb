Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
Imports System.ComponentModel

Namespace PropertyEditors
    Public MustInherit Class PropertyEditorBase
        Inherits Drawing.Design.UITypeEditor

        Protected MustOverride Function GetEditForm(ByVal propertyName As String, ByVal currentValue As Object) As Form
        Protected MustOverride Function GetEditedValue(ByVal editForm As Form, ByVal propertyName As String, ByVal oldValue As Object) As Object
        Protected EditorService As IWindowsFormsEditorService
        Private WithEvents _mEditForm As Form
        Private _mEscapePressed As Boolean

        Public Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle
            Try
                Dim c As Form
                c = GetEditForm(context.PropertyDescriptor.Name, context.PropertyDescriptor.GetValue(context.Instance))
                If TypeOf c Is Form Then
                    Return UITypeEditorEditStyle.Modal
                End If
            Catch
            End Try
            Return UITypeEditorEditStyle.DropDown
        End Function

        Public Overrides Function EditValue(ByVal context As ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object
            Try
                If context IsNot Nothing AndAlso provider IsNot Nothing Then
                    EditorService = DirectCast(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
                    If EditorService IsNot Nothing Then
                        Dim propName As String = context.PropertyDescriptor.Name
                        _mEditForm = GetEditForm(propName, value)
                        If _mEditForm IsNot Nothing Then
                            _mEscapePressed = False
                            If TypeOf _mEditForm Is Form Then
                                EditorService.ShowDialog(_mEditForm)
                            Else
                                EditorService.DropDownControl(_mEditForm)
                            End If

                            If _mEscapePressed Then
                                Return value
                            Else
                                Return GetEditedValue(_mEditForm, propName, value)
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw
            End Try
            Return MyBase.EditValue(context, provider, value)
        End Function

        Public Function GetIWindowsFormsEditorService() As IWindowsFormsEditorService
            Return EditorService
        End Function

        Private Sub m_EditControl_PreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs) Handles _mEditForm.PreviewKeyDown
            If e.KeyCode = Keys.Escape Then _mEscapePressed = True
        End Sub
    End Class
End Namespace