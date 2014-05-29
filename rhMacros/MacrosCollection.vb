Imports System.Xml.Serialization
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

<Serializable()>
Public Class MacroCollection
    Sub New()
        MyBase.New()

        Macros = New List(Of Macro)
    End Sub

    <XmlArray("Macros")> _
    Public Property Macros() As List(Of Macro)

    Public Property MacroByName(name As String) As Macro
        Get
            Return Macros.FirstOrDefault(Function(m) m.Name.Equals(name))
        End Get
        Set(val As Macro)
            Dim mcr As Macro = Macros.FirstOrDefault(Function(m) m.Name.Equals(name))
            ' ReSharper disable RedundantAssignment
            If mcr IsNot Nothing Then mcr = val
            ' ReSharper restore RedundantAssignment
        End Set
    End Property
End Class

<Serializable()>
Public Class Macro
    ' name property is not editable or browsable, you can however call it in code
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Property Name() As String

    <Description("The text of the macrobutton.")> _
    Public Property Text() As String

    <Description("The sequence of GCodes that will be executed with this macro."), Editor(GetType(PropertyEditors.ScriptPropertyEditor), GetType(Drawing.Design.UITypeEditor))> _
    Public Property Script() As String

    <Description("The tooltiptext of the macrobutton. This will be displayed when you hover the macrobutton.")> _
    Public Property ToolTip() As String = "Test"
    <Description("Turn a confirmationmessage on or off.")> _
    Public Property ShowConfirm() As Boolean
    <Description("The confirmationmessage to be displayed when the macrobutton is pressed.")> _
    Public Property ConfirmMessage() As String
    <Description("The buttons to be displayed when the confirmationmessage is displayed.")> _
    Public Property ConfirmButtons() As MessageBoxButtons
    <Description("The confirmbutton that will execute the script. This should be a button that is displayed on the confirmationmessage.")> _
    Public Property ConfirmButton() As DialogResult

    ' ignore the color types in xml, use the converters below for that
    <XmlIgnore()>
    Public Property BackColor() As Color = SystemColors.Control
    <XmlIgnore()>
    Public Property ForeColor() As Color = SystemColors.WindowText
    ', Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    ' Colorconverter from and to html colors so xml can manage it
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Property BackColorString() As String
        Get
            Return ColorTranslator.ToHtml(BackColor)
        End Get
        Set(ByVal value As String)
            BackColor = ColorTranslator.FromHtml(value)
        End Set
    End Property

    ' Colorconverter from and to html colors so xml can manage it
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Property ForeColorString() As String
        Get
            Return ColorTranslator.ToHtml(ForeColor)
        End Get
        Set(ByVal value As String)
            ForeColor = ColorTranslator.FromHtml(value)
        End Set
    End Property

    Sub New()
        MyBase.New()

        ' generate unique name
        Name = String.Format("mcr{0}", Guid.NewGuid.ToString())
        Text = "My new macro"
    End Sub

    Public Function RenderButton() As Button
        Try
            ' Setup the defualt button for this macro
            Dim b As New Button

            b.Name = Name
            b.Text = Text
            b.TextAlign = ContentAlignment.MiddleCenter
            b.AutoSizeMode = AutoSizeMode.GrowAndShrink
            b.AutoSize = True
            b.AutoEllipsis = True
            ' Set forecolor to transparent so we can draw our own text and textcolor in the paint event
            b.ForeColor = Color.FromKnownColor(KnownColor.Transparent)
            b.Font = New Font("SegoeUI", 9, FontStyle.Regular)

            ' The link to the paint event
            AddHandler b.Paint, AddressOf ButtonPaintHandler

            Return b
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Sub ButtonPaintHandler(sender As Object, e As PaintEventArgs)
        Try
            ' cast the sender to button
            Dim but As Button = TryCast(sender, Button)

            Dim g As Graphics = e.Graphics

            ' Set drawing properties
            g.CompositingMode = CompositingMode.SourceOver
            g.CompositingQuality = CompositingQuality.HighQuality
            g.InterpolationMode = InterpolationMode.HighQualityBilinear
            g.SmoothingMode = SmoothingMode.HighQuality

            ' get the button drawing rectangle
            Dim bound As RectangleF = e.ClipRectangle
            ' Deflate by -1
            bound.Inflate(-1, -1)
            ' Define a brush with the user backcolor and set Alpha channel to 100
            Dim b As New SolidBrush(Color.FromArgb(100, BackColor))
            ' Fill the button with the user color, 
            g.FillRectangle(b, bound)

            ' Setup a stringformatter
            Dim sf As New StringFormat
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center
            sf.FormatFlags = StringFormatFlags.NoWrap

            ' Draw the buttontext again, but now with the usercolor and since its the last layer it will be clearly visible (unless you choose the same color as back ;))
            g.DrawString(but.Text, but.Font, New SolidBrush(ForeColor), e.ClipRectangle, sf)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
