Imports RepetierHostExtender.interfaces

' rhMacros/rhMacrosPlugin/2014-05-23
' Copyright (C) 2014 CMB Solutions
' 
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
' 
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program. If not, see <http://www.gnu.org/licenses/>.


' ReSharper disable InconsistentNaming
Public Class rhMacros
    ' ReSharper restore InconsistentNaming
    Implements IHostPlugin

    Public Property Host As IHost
    Public Property MacroUi As MacrosUi

    Public Sub FinializeInitialize() Implements IHostPlugin.FinializeInitialize
        ' Nothing to do here....
    End Sub

    Public Sub PostInitialize() Implements IHostPlugin.PostInitialize
        Try
            ' Set the UI
            MacroUi = New MacrosUi()
            ' Connect UI to Host
            MacroUi.Connect(Host)
            ' Register UI to Host
            Host.RegisterHostComponent(MacroUi)

            ' Set message in hosts about dialog
            Host.AboutDialog.RegisterThirdParty("rhMacros", String.Format("{0}{0}{0} rhMacro's plugin created by CMB Solutions © 2014", Environment.NewLine))
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub PreInitalize(paramHost As IHost) Implements IHostPlugin.PreInitalize
        Host = paramHost
    End Sub
End Class
