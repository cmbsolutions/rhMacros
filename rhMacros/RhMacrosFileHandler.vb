Imports System.IO
Imports System.Xml.Serialization

Public Class RhMacrosFileHandler(Of T)
    Public Shared Function SaveObject(data As T, f As FileInfo) As Boolean
        Try
            Using sr As New StreamWriter(f.FullName)
                Dim xr As New XmlSerializer(data.GetType)
                xr.Serialize(sr, data)
                sr.Close()
            End Using

            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Shared Function LoadObject(ByRef data As T, f As FileInfo) As Boolean
        Try
            Using sr As New StreamReader(f.FullName)
                Dim xr As New XmlSerializer(data.GetType)
                data = CType(xr.Deserialize(sr), T)
                sr.Close()
            End Using

            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
