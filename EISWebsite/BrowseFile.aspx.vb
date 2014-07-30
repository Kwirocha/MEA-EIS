Imports EISUpdate
Imports fn = EISUpdate.inFunction

Partial Class BrowseFile
    Inherits System.Web.UI.Page

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Response.Clear()
        Response.Write("<script type=""text/javascript"">window.parent.closeUpload(); window.parent.refreshFile();</script>")
        Response.End()
    End Sub



    'Private Function StoreImageToDB(ByVal DocData() As Byte, ByVal MimeType As String) As String
    '    StoreImageToDB = Nothing
    '    Dim order As String
    '    Dim newID As String
    '    Dim filenameUpload As String
    '    Dim personID As String = Me.CurrentUserName
    '    Dim sql As New StringBuilder

    '    filenameUpload = FileUpload1.FileName

    '    Try
    '        newID = fn.getNewGUID()

    '        With SQLCmd
    '            .CommandText = "SELECT MAX(NUM_ORDER) FROM ATTACHMENT WHERE MASTER_RECORD_ID =" & fn.getTxt(_keyID)
    '            order = fn.CString(.ExecuteScalar)

    '            If order = "" Then order = "0" Else order = CInt(order) + 1
    '            sql.Append("INSERT INTO ATTACHMENT ")
    '            sql.Append(" (ID, MASTER_RECORD_ID, TABLE_NAME, ATTACHMENT_NAME, MIME_TYPE, CREATED_DATE, NUM_ORDER, PERSON_ID) ")
    '            sql.Append(" VALUES ")
    '            sql.Append(" (").Append(fn.getTxt(newID)).Append(",").Append(fn.getTxt(_keyID))
    '            sql.Append(",'ITA_RESOURCE',").Append(fn.getTxt(filenameUpload)).Append(",").Append(fn.getTxt(MimeType)).Append(",getdate(),")
    '            sql.Append(fn.getTxt(order)).Append(",").Append(fn.getTxt(personID)).Append(") ")

    '            .CommandText = sql.ToString
    '            .Parameters.Clear()
    '            .ExecuteNonQuery()

    '            .CommandText = "exec SaveAttachmentToDB " & fn.getTxt(newID) & ",@ImageDta"
    '            .Parameters.Clear()
    '            .Parameters.Add("@ImageDta", SqlDbType.Image).Value = DocData
    '            .ExecuteNonQuery()
    '            .Parameters.Clear()
    '        End With
    '        Journal.markJournal(SQLCmd, "ATTACHMENT", newID, Journal.SQLTypes.Insert)
    '    Catch ex As Exception
    '        fn.LogError("Upload failed", ex)
    '        fn.generateErrorPage("Upload failed")
    '    End Try

    'End Function
End Class
