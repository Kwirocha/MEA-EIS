Imports System.Net
Imports System.IO
Imports System.Security.Cryptography
Imports System.Data.SqlClient

Namespace EISUpdate

    Partial Public Class inFunction
        Public Class EmailParam
            Public IOC As String
            Public UserName As String
            Public Password As String
            Public FullName As String
            Public FirstName As String
            Public LastName As String
            Public MiddleName As String
            Public his_her As String
        End Class

#Region " Get Value "

        Private Shared _getConnectionString As Object

        Shared Property getConnectionString(p1 As Boolean) As Object
            Get
                Return _getConnectionString
            End Get
            Set(value As Object)
                _getConnectionString = value
            End Set
        End Property

        Public Shared Function getQueryString(ByVal Include_Exclude As String, ByVal queryStringKeys As String) As String
            Include_Exclude = Include_Exclude.ToLower
            If Not "include, exclude".Contains(Include_Exclude) Then 'only acceptable values for this parameter
                Return ""
            End If

            Dim qryStr As String = ""
            Dim keyname, keyvalue As String
            Dim isTheSpecificKey As Boolean
            queryStringKeys = queryStringKeys.ToLower

            For i As Integer = 0 To HttpContext.Current.Request.QueryString.Count - 1
                keyname = CString(HttpContext.Current.Request.QueryString.Keys(i)).ToLower
                keyvalue = HttpContext.Current.Request.QueryString(i)

                isTheSpecificKey = queryStringKeys.Contains(keyname)

                If (Include_Exclude = "include" And isTheSpecificKey) _
                OrElse (Include_Exclude = "exclude" And Not isTheSpecificKey) Then
                    qryStr += keyname + "=" + keyvalue + "&"
                End If
            Next
            qryStr = qryStr.TrimEnd("&")

            Return qryStr
        End Function
#End Region



#Region "Save Merge Log"
        Public Shared Sub UpdateLogIDChanged(ByVal cmd As SqlCommand, ByVal newID As String, ByVal oldID As String, ByVal tableName As String, Optional ByVal remark As String = "")
            Try
                cmd.CommandText = " insert into LOG_ID_CHANGED (" & _
                                " id,change_date,table_name,old_id,new_id,remark)" & _
                                " values ( " & _
                                "  newid(),getdate()," & getTxt(tableName) & "," & _
                                getTxt(oldID) & "," & getTxt(newID) & "," & getTxt(remark) & ")"
                cmd.ExecuteScalar()
            Catch ex As Exception
                'Ignore Error
            End Try
        End Sub
#End Region

        Public Shared Function md5Encrypt(ByVal text As String) As String
            Dim md5 As MD5 = New MD5CryptoServiceProvider
            'compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text))
            'get hash result after compute it
            Dim result() As Byte = md5.Hash
            Dim strBuilder As StringBuilder = New StringBuilder
            Dim i As Integer = 0

            Do While (i < result.Length)
                'change it into 2 hexadecimal digits
                'for each byte
                strBuilder.Append(result(i).ToString("x2"))
                i = (i + 1)
            Loop
            Return strBuilder.ToString
        End Function

        Private Shared Function getTxt(oldID As String) As Object
            Throw New NotImplementedException
        End Function

        Private Shared Function CString(p1 As String) As Object
            Throw New NotImplementedException
        End Function

    End Class
End Namespace
