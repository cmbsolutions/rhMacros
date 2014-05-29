Imports System
Imports System.Collections.Generic

Namespace CodeCompletion

    Partial Public Class CodeCompletions

        Private _entriesField As List(Of CodeCompletionsEntry)

        Public Sub New()
            MyBase.New()
            _entriesField = New List(Of CodeCompletionsEntry)()
        End Sub

        <Xml.Serialization.XmlArrayItemAttribute("Entry", IsNullable:=False)> _
        Public Property Entries() As List(Of CodeCompletionsEntry)
            Get
                Return _entriesField
            End Get
            Set(value As List(Of CodeCompletionsEntry))
                _entriesField = value
            End Set
        End Property
    End Class

    Partial Public Class CodeCompletionsEntry

        Private _codeField As String

        Private _descriptionField As String

        Private _parametersField As String

        Private _iconIdField As Byte

        Public Property Code() As String
            Get
                Return _codeField
            End Get
            Set(value As String)
                _codeField = value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return _descriptionField
            End Get
            Set(value As String)
                _descriptionField = value
            End Set
        End Property

        Public Property Parameters() As String
            Get
                Return _parametersField
            End Get
            Set(value As String)
                _parametersField = value
            End Set
        End Property

        Public Property IconId() As Byte
            Get
                Return _iconIdField
            End Get
            Set(value As Byte)
                _iconIdField = value
            End Set
        End Property
    End Class
End Namespace
