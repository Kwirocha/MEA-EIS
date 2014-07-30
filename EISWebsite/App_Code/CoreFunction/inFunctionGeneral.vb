Imports System.Data.SqlClient

'This file contains rarely change general function from inFunction.vb file

Namespace GlobalUpdate
    Partial Public Class inFunction
        Public Enum AffiliationType
            Staff = 0
            Volunteer = 1
            Customer = 2
        End Enum

        Public Shared Function CString(ByVal obj As Object, Optional ByVal DateFormat As String = Nothing, _
        Optional ByVal NumFormat As String = Nothing) As String
            If IsDBNull(obj) OrElse obj Is Nothing Then
                If NumFormat = Nothing Then
                    Return ""
                Else
                    Return Format(0, NumFormat)
                End If
            Else
                If TypeOf (obj) Is Guid Then
                    Dim s As String = Convert.ToString(obj)
                    If s <> Nothing Then s = s.ToUpper
                    Return s
                ElseIf obj.GetType.Equals(GetType(System.Byte())) Then
                    Return Convert.ToBase64String(obj)
                ElseIf obj.GetType.Equals(GetType(System.DateTime)) Then
                    If DateFormat = Nothing Then
                        Return CDate(obj).ToShortDateString
                    Else
                        Return CDate(obj).ToString(DateFormat, System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    End If
                ElseIf NumFormat <> Nothing Then
                    Try
                        Dim n As Double = CDbl(obj)
                        Return Format(n, NumFormat)
                    Catch ex As Exception
                        Return Format(0, NumFormat)
                    End Try
                Else
                    Return CStr(obj)
                End If
            End If

            Return ""
        End Function

        Public Shared Function getJavaScriptTxt(ByVal txtValue As String, Optional ByVal withQuote As Boolean = True) As String
            If txtValue <> Nothing Then txtValue = txtValue.Trim()
            txtValue = txtValue.Replace("\", "\\")
            txtValue = txtValue.Replace("'", "\'")
            txtValue = txtValue.Replace("""", "\""")
            txtValue = txtValue.Replace(Environment.NewLine, "\n")
            txtValue = txtValue.Replace(vbCr, "\r")
            txtValue = txtValue.Replace(vbTab, "\t")
            txtValue = txtValue.Replace("</p>", "\n") 'by bank 27 May 2013 // 13-05638
            If withQuote Then
                txtValue = "'" & txtValue & "'"
            End If
            Return txtValue
        End Function



        Public Shared Function EncodeBase64String(ByVal Str As String) As String
            Dim enc As System.Text.Encoding = System.Text.Encoding.ASCII
            Dim ByteArray As Byte()
            ByteArray = enc.GetBytes(Str)
            Return System.Convert.ToBase64String(ByteArray)
        End Function

        Public Shared Function DecodeBase64String(ByVal Str As String) As String
            Dim enc As System.Text.Encoding = System.Text.Encoding.ASCII
            Dim ByteArray As Byte()
            ByteArray = System.Convert.FromBase64String(Str)
            Return enc.GetString(ByteArray)
        End Function

        Public Shared Function checkEmailFormat(ByVal emailNames As String, Optional ByRef errMessage As String = "") As Boolean
            Dim validFormat As Boolean
            Dim i, j As Integer
            Dim emailArray As String()
            Dim email As String
            errMessage = ""

            emailNames = emailNames.Trim
            emailNames = emailNames.Trim(",")
            emailArray = emailNames.Split(",")

            If emailArray.Length = 0 Then
                validFormat = False
                errMessage += IIf(Not validFormat, "E-mail cannot be blank", "")

            Else
                For i = 0 To emailArray.Length - 1
                    email = emailArray(i)
                    email = email.Trim

                    If Left(email, 1) = "<" AndAlso Right(email, 1) = ">" Then 'Bank add condition in -> Sirada 08/10/12 Req ID: RWER-8L2PWP
                        j = email.IndexOf("<")

                        If j > -1 Then
                            email = email.Substring(j + 1, email.Length - j - 1)
                        End If

                        email = email.Replace(">", "")
                        email = email.Trim

                    End If

                    validFormat = (email <> "")
                    errMessage += IIf(Not validFormat, "E-mail account cannot be blank", "")

                    If validFormat Then
                        validFormat = Not email.Contains("~") AndAlso Not email.Contains("`") AndAlso Not email.Contains("!") _
                            AndAlso Not email.Contains("#") AndAlso Not email.Contains("$") AndAlso Not email.Contains("%") _
                            AndAlso Not email.Contains("^") AndAlso Not email.Contains("&") AndAlso Not email.Contains("*") _
                            AndAlso Not email.Contains("(") AndAlso Not email.Contains(")") AndAlso Not email.Contains("+") _
                            AndAlso Not email.Contains("=") AndAlso Not email.Contains("{") AndAlso Not email.Contains("}") _
                            AndAlso Not email.Contains("[") AndAlso Not email.Contains("]") AndAlso Not email.Contains("|") _
                            AndAlso Not email.Contains("\") AndAlso Not email.Contains(":") AndAlso Not email.Contains(";") _
                            AndAlso Not email.Contains("""") AndAlso Not email.Contains("'") AndAlso Not email.Contains("<") _
                            AndAlso Not email.Contains(">") AndAlso Not email.Contains("?") AndAlso Not email.Contains("/") _
                            AndAlso Not email.Contains(".@")
                        errMessage += IIf(Not validFormat, "Invalid character(s) in e-mail account ", "")
                    End If

                    If validFormat Then
                        'ref: http://www.regular-expressions.info/email.html
                        validFormat = Regex.IsMatch(email, "^[^@.]+(?:\.[^@]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$", RegexOptions.IgnoreCase)
                        errMessage += IIf(Not validFormat, "Invalid format in e-mail account ", "")
                    End If

                    If validFormat = False Then
                        Exit For
                    End If
                Next
            End If

            Return validFormat
        End Function

        Public Shared Function checkFormatEmail(ByVal emailNames As String) As Boolean

            Return checkEmailFormat(emailNames)

        End Function

#Region " Configuration Setting "
        Public Shared Function getConfigVal(ByVal key As String) As String
            Return System.Web.Configuration.WebConfigurationManager.AppSettings(key)
        End Function

        Public Shared Function getConnectionString(Optional ByVal oldASP As Boolean = False) As String
            Return IIf(oldASP, "Provider=SQLOLEDB.1;", "") & System.Web.Configuration.WebConfigurationManager.ConnectionStrings(GlobalConst.ConnectString).ConnectionString
        End Function
        Public Shared Function isPreproUSA() As Boolean
            Try
                Return CBool(getConfigVal("isPreproUSASite") = "1") 'OrElse getConfigVal("isTrainSite") = "1")
            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Shared Function isTestSite() As Boolean
            Try
                Return CBool(getConfigVal("isTestSite") = "1") 'OrElse getConfigVal("isTrainSite") = "1")
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function isTrainSite() As Boolean
            Try
                Return CBool(getConfigVal("isTrainSite") = "1")
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function isProductionSite() As Boolean
            Return Not isTestSite() And Not isTrainSite()
        End Function
#End Region

#Region " Generate SQL statement "
        Public Shared Function genNullReplace(ByVal field As String) As String
            Return " (CASE WHEN LTRIM(RTRIM(" & field & ")) = '' THEN '-' WHEN " & field & " IS NULL THEN '-' ELSE " & field & " END) "
        End Function

        ''' <summary>
        ''' Build SQL search condition - for text field
        ''' </summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="FValue">Value</param>
        ''' <param name="isExact">If true, search with equal, otherwise search the beginning of the text using like</param>
        ''' <param name="isNative">is NVarchar or NText data type</param>
        ''' <param name="DefaultVal">search condition to use if no search condition needed eg. when search All</param>
        ''' <param name="isMemo">is Memo data type</param>
        ''' <param name="prefix">default = prefix with "And"</param>
        ''' <param name="isUnique">is Uniqueidentifier data type</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GenSearchCond(ByVal FieldName As String, ByVal FValue As String, Optional ByVal isExact As Boolean = False, _
                Optional ByVal isNative As Boolean = False, Optional ByVal DefaultVal As String = "", Optional ByVal isMemo As Boolean = False, _
                Optional ByVal prefix As String = " and ", Optional ByVal isUnique As Boolean = False, Optional ByVal isAccentSearch As Boolean = True) As String
            Dim nl As String = vbCrLf
            If FieldName = Nothing Then FieldName = "" : If FValue = Nothing Then FValue = ""
            FieldName = Trim(FieldName) : FValue = Trim(FValue)
            prefix = " " + prefix + " "
            If FieldName = "" OrElse FValue = "" OrElse (isExact AndAlso FValue.ToLower.Trim = "all") Then
                Return DefaultVal + IIf(DefaultVal <> "", nl, "")
            Else
                If FValue = "_blank" Then
                    If isUnique Then
                        Return prefix & " (" & FieldName & " is Null ) " + nl
                    Else
                        Return prefix & " (" & FieldName & " is Null or " & FieldName & " = '') " + nl
                    End If
                Else
                    If isExact Then
                        'legacy Memo data type cannot use equal (=), use like instead
                        Return prefix & FieldName & IIf(isMemo, " like ", " = ") & getTxt(FValue, isNative) & " " + nl
                    Else
                        If isAccentSearch Then
                            'if search for person English name using like, try to compare with accent-insensitive by using special fields
                            If String.Compare(FieldName, "ENGLISH_LASTNAME", True) = 0 Then
                                FieldName = "CI_E_L_NAME"
                            ElseIf FieldName.EndsWith(".ENGLISH_LASTNAME", StringComparison.InvariantCultureIgnoreCase) Then
                                FieldName = Replace(FieldName, ".ENGLISH_LASTNAME", ".CI_E_L_NAME", , , CompareMethod.Text)
                            ElseIf String.Compare(FieldName, "ENGLISH_FIRSTNAME", True) = 0 Then
                                FieldName = "CI_E_F_NAME"
                            ElseIf FieldName.EndsWith(".ENGLISH_FIRSTNAME", StringComparison.InvariantCultureIgnoreCase) Then
                                FieldName = Replace(FieldName, ".ENGLISH_FIRSTNAME", ".CI_E_F_NAME", , , CompareMethod.Text)
                            ElseIf String.Compare(FieldName, "ENGLISH_MIDDLENAME", True) = 0 Then
                                FieldName = "CI_E_MI_NAME"
                            ElseIf FieldName.EndsWith(".ENGLISH_MIDDLENAME", StringComparison.InvariantCultureIgnoreCase) Then
                                FieldName = Replace(FieldName, ".ENGLISH_MIDDLENAME", ".CI_E_MI_NAME", , , CompareMethod.Text)
                            ElseIf String.Compare(FieldName, "ENGLISH_MAIDENNAME", True) = 0 Then
                                FieldName = "CI_E_MA_NAME"
                            ElseIf FieldName.EndsWith(".ENGLISH_MAIDENNAME", StringComparison.InvariantCultureIgnoreCase) Then
                                FieldName = Replace(FieldName, ".ENGLISH_MAIDENNAME", ".CI_E_MA_NAME", , , CompareMethod.Text)
                            End If
                        End If

                        Return prefix & FieldName & " like " & getTxt(FValue & "%", isNative) & nl
                    End If
                End If
            End If
        End Function

        Public Shared Function GenSearchNumber(ByVal FieldName As String, ByVal FValue As String, Optional ByVal [Operator] As String = "=") As String
            If FValue = "" Then Return ""

            FValue = CStr(CDbl(FValue))
            Return " and " & FieldName & [Operator] & FValue
        End Function

        ''' <summary>
        ''' Build SQL Search condition - for text field - when search for the same value on multiple field. eg. and (FieldName1 = FValue or FieldName2 = FValue or FieldName3 = FValue ...)
        ''' </summary>
        ''' <param name="FieldName">Field Name to search</param>
        ''' <param name="FValue">Value to search</param>
        ''' <param name="isExact">If true, use equal, otherwise search the beginning of the field using like</param>
        ''' <param name="isNative">is NVarchar data type</param>
        ''' <param name="DefaultVal">search condition to use if no search condition needed eg. when search All</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GenSearchCondOr(ByVal FieldName() As String, ByVal FValue As String, Optional ByVal isExact As Boolean = False, Optional ByVal isNative As Boolean = False, Optional ByVal DefaultVal As String = "") As String
            Dim tmp As String = ""

            If FieldName.Length = 0 Then Return ""
            If FieldName.Length = 1 Then Return inFunction.GenSearchCond(FieldName(0), FValue, isExact, isNative, DefaultVal)

            If FValue = Nothing Then FValue = ""
            If FValue <> "" AndAlso FValue.ToLower <> "all" Then
                Dim tmpStr As New StringBuilder
                Dim addOr As String = ""
                If FValue = "_blank" Then
                    tmpStr.Append(" and (")
                    For Each fn As String In FieldName
                        tmpStr.Append(addOr).Append("(").Append(fn).Append(" is Null or ").Append(fn).Append(" = '')")
                        addOr = " or "
                    Next
                    tmpStr.Append(") ")

                    Return tmpStr.ToString
                Else
                    Dim opr As String = " = "
                    If Not isExact Then
                        opr = " like "
                        FValue += "%"
                    End If
                    tmpStr.Append(" and (")
                    For Each fn As String In FieldName
                        tmpStr.Append(addOr).Append("(").Append(fn).Append(opr).Append(getTxt(FValue, isNative)).Append(")")
                        addOr = " or "
                    Next
                    tmpStr.Append(") ")
                End If
                Return tmpStr.ToString
            Else
                Return DefaultVal
            End If
        End Function

        ''' <summary>
        ''' Build SQL Search condition - for date field
        ''' </summary>
        ''' <param name="FieldName"></param>
        ''' <param name="FValue"></param>
        ''' <param name="Operator"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GenSearchDate(ByVal FieldName As String, ByVal FValue As String, Optional ByVal [Operator] As String = "=") As String
            If FValue = "" Then Return ""

            FValue = getDateTxt(FValue)
            Return " and " & FieldName & [Operator] & FValue
        End Function

        ''' <summary>
        ''' get text constant for use with SQL statement
        ''' Blank is treat as Null
        ''' </summary>
        ''' <param name="txtValue">text value</param>
        ''' <param name="isNative">is NVarchar data type</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getTxt(ByVal txtValue As String, Optional ByVal isNative As Boolean = False) As String
            If txtValue <> Nothing Then txtValue = txtValue.Trim()
            If txtValue = "" Then
                Return "null"
            Else
                Return IIf(isNative, "N", "") & "'" & txtValue.Replace("'", "''") & "'"
            End If
        End Function

        Public Shared Function getTxtLen(ByVal txtValue As String, ByVal maxLen As Integer, Optional ByVal isNative As Boolean = False) As String
            Dim str As String
            If txtValue <> Nothing Then txtValue = txtValue.Trim()
            If txtValue = "" Then
                Return "null"
            Else
                str = txtValue
                If str.Length > maxLen Then str = str.Substring(0, maxLen)
                str = str.Replace("'", "''")
                Return IIf(isNative, "N", "") & "'" & str & "'"
            End If
        End Function

        ''' <summary>
        ''' get text constant (for use with sql statement), Blank is treat as Null
        ''' </summary>
        ''' <param name="txt">TextBox</param>
        ''' <param name="isNative">Is non-latin text</param>
        ''' <returns>sql text</returns>
        ''' <remarks></remarks>
        Public Shared Function getTxt(ByVal txt As TextBox, Optional ByVal isNative As Boolean = False) As String
            Return getTxt(txt.Text, isNative)
        End Function

        ''' <summary>
        ''' get text constant (for use with sql statement), Blank is treat as Null
        ''' </summary>
        ''' <param name="obj">Object</param>
        ''' <param name="isNative">Is non-latin text</param>
        ''' <returns>sql text</returns>
        ''' <remarks></remarks>
        Public Shared Function getTxt(ByVal obj As Object, Optional ByVal isNative As Boolean = False) As String
            Return getTxt(CString(obj), isNative)
        End Function

        ''' <summary>
        ''' get text constant (for use with sql statement) from multiple value, eg. 'val1', 'val2' 
        ''' </summary>
        ''' <param name="txts">Array of Text Value</param>
        ''' <param name="isNative">Is non-latin text</param>
        ''' <returns>sql text</returns>
        ''' <remarks></remarks>
        Public Shared Function getTxts(ByVal txts As String(), Optional ByVal isNative As Boolean = False, Optional ByVal excludeBlank As Boolean = True) As String
            Dim res As New StringBuilder
            For Each s As String In txts
                If s <> Nothing Then s = s.Trim()
                If s = "" Then
                    If Not excludeBlank Then
                        res.Append("'',")
                    End If
                Else
                    res.Append(getTxt(s, isNative)).Append(",")
                End If
            Next

            If res.Length > 0 Then
                res.Remove(res.Length - 1, 1)
            End If
            Return res.ToString
        End Function

        ''' <summary>
        ''' get text constant (for use with sql statement) from multiple value, eg. 'val1', 'val2' 
        ''' </summary>
        ''' <param name="txts">List of Text Value</param>
        ''' <param name="isNative">Is non-latin text</param>
        ''' <returns>sql text</returns>
        ''' <remarks></remarks>
        Public Shared Function getTxts(ByVal txts As Generic.List(Of String), Optional ByVal isNative As Boolean = False, Optional ByVal excludeBlank As Boolean = True) As String
            Dim res As New StringBuilder
            For Each s As String In txts
                If s <> Nothing Then s = s.Trim()
                If s = "" Then
                    If Not excludeBlank Then
                        res.Append("'',")
                    End If
                Else
                    res.Append(getTxt(s, isNative)).Append(",")
                End If
            Next

            If res.Length > 0 Then
                res.Remove(res.Length - 1, 1)
            End If
            Return res.ToString
        End Function

        'get date constant without time (for use with sql statement)
        '--*Blank is treat as Null--
        Public Shared Function getDateTxt(ByVal _dateString As String, Optional ByVal dateformat As String = "") As String
            If _dateString.Trim = "" Then
                Return "null"
            Else
                Try
                    If dateformat = "" Then
                        Return "'" & CDate("#" & _dateString & "#").ToString("yyyyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo) & "'"
                    Else
                        Return "'" & Date.ParseExact(_dateString, dateformat, System.Globalization.DateTimeFormatInfo.CurrentInfo).ToString("yyyyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo) & "'"
                    End If
                Catch ex As Exception
                    Return "'" & _dateString & "'"
                End Try
            End If
        End Function


        'get date constant without time (for use with sql statement)
        '--*Blank is treat as Null--
        Public Shared Function getDateTxt(ByVal _date As Date) As String
            If _date = Nothing Then
                Return "null"
            Else
                Return "'" & _date.ToString("yyyyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo) & "'"
            End If
        End Function

        'get number constant without comma (for use with sql statement)
        '--*Blank is treat as Null--
        Public Shared Function getDoubleTxt(ByVal numberString As String) As String
            If numberString.Trim = "" Then
                Return "null"
            Else
                Try
                    Return CDbl(numberString)
                Catch ex As Exception
                    Return "null" 'Return numberString 'If there is an error when convert it should return Null to prevent error when save. Pusit P. 2007-Nov-12
                End Try
            End If
        End Function

        ''' <summary>
        ''' Get Sql Money constant
        ''' </summary>
        ''' <param name="moneyString"></param>
        ''' <returns></returns>
        ''' <remarks>not for local partner number format</remarks>
        Public Shared Function getSqlMoneyTxt(ByVal moneyString As String) As String
            If moneyString = Nothing OrElse moneyString.Trim = "" Then
                Return "null"
            Else
                Return CType(moneyString, Decimal).ToString("f4")
            End If
        End Function

        'get checkbox value (for use with sql statement)
        Public Shared Function getChkVal(ByVal isChk As Boolean, _
          Optional ByVal chkVal As Char = "Y"c, Optional ByVal unchkVal As Char = "N"c) As String
            Return "'" & IIf(isChk, chkVal, unchkVal) & "'"
        End Function

        ''' <summary>
        ''' Generate a person name by using Name Format Setting of current user
        ''' </summary>
        ''' <param name="firstName">the person 's first name string</param>
        ''' <param name="lastName">the person 's last name string</param>
        ''' <param name="middleName">the person 's middle name string</param>
        ''' <param name="spaceChar">string use as space</param>
        ''' <param name="formatString">Name Format, if not specific, use current user setting</param>
        ''' <returns>the person's FULL NAME</returns>
        ''' <remarks></remarks>
        Public Shared Function genPersonNameByFormat( _
            ByVal firstName As String, ByVal lastName As String, _
            Optional ByVal formatString As String = "", _
            Optional ByVal middleName As String = "", _
            Optional ByVal spaceChar As String = "&nbsp;&nbsp;" _
           , Optional ByVal maidenName As String = "" _
            ) As String

            Dim namestr As String = ""

            If formatString = "" Then formatString = HttpContext.Current.Session("NameFormat")
            If formatString = "" Then formatString = "F L"

            For Each ch As Char In formatString
                Select Case ch
                    Case "F"c
                        namestr += firstName
                    Case "M"c
                        namestr += middleName
                    Case "L"c
                        namestr += lastName
                    Case "A"c
                        namestr += maidenName
                    Case " "c
                        namestr += spaceChar
                    Case Else
                        namestr += ch
                End Select
            Next

            Return namestr

        End Function

        ''' <summary>
        ''' Get SQL Column Expression for get English Person Name based-on Name Format Setting of current user
        ''' </summary>
        ''' <param name="prefix">field name's prefix (tablename. eg. "p.")</param>
        ''' <param name="space">string use as space</param>
        ''' <param name="format">Name Format, if not specific, use current user setting</param>
        ''' <returns>SQL Column Expression</returns>
        ''' <remarks></remarks>
        Public Shared Function getPersonInEnglish(Optional ByVal prefix As String = "", _
          Optional ByVal space As String = " ", _
          Optional ByVal format As String = "") As String
            Dim fname As String = "isNull(" & prefix & "[ENGLISH_FIRSTNAME], '')"
            Dim mname As String = "isNull(" & prefix & "[ENGLISH_MIDDLENAME], '')"
            Dim lname As String = "isNull(" & prefix & "[ENGLISH_LASTNAME], '')"
            Dim pname As String = "isNull(" & prefix & "[ENGLISH_NICKNAME], '')"
            Dim maidenName As String = "isNull(" & prefix & "[ENGLISH_MAIDENNAME], '')"
            Dim namesql As String = ""


            If format = "" Then format = HttpContext.Current.Session("NameFormat")
            If format = "" Then format = "F L"

            For Each ch As Char In format
                Select Case ch
                    Case "F"c
                        namesql += fname
                    Case "M"c
                        namesql += mname
                    Case "L"c
                        namesql += lname
                    Case "N"c
                        namesql += pname
                    Case "A"c
                        namesql += maidenName
                    Case " "c
                        namesql += "'" & space & "'"
                    Case Else
                        namesql += "'" & ch & "'"
                End Select
                namesql += "+"
            Next
            namesql = namesql.TrimEnd("+")
            Return namesql
            'Return "isNull(" & prefix & "English_FirstName + '" & space & "','') + IsNull(" & prefix & "English_LastName, '')"
        End Function

        ''' <summary>
        ''' Get SQL Column Expression for get Native Person Name based-on Name Format Setting of current user
        ''' </summary>
        ''' <param name="prefix">field name's prefix (tablename. eg. "p.")</param>
        ''' <param name="space">string use as space</param>
        ''' <param name="format">Name Format, if not specific, use current user setting</param>
        ''' <returns>SQL Column Expression</returns>
        ''' <remarks></remarks>
        Public Shared Function getPersonInNative(Optional ByVal prefix As String = "", _
          Optional ByVal space As String = " ", _
          Optional ByVal format As String = "", Optional ByVal IOC_CODE As String = "") As String
            Dim fname As String = "isNull(" & prefix & "[NATIVE_FIRSTNAME], '')"
            Dim mname As String = "isNull(" & prefix & "[NATIVE_MIDDLENAME], '')"
            Dim lname As String = "isNull(" & prefix & "[NATIVE_LASTNAME], '')"
            Dim pname As String = "isNull(" & prefix & "[NATIVE_NICKNAME], '')"
            Dim maidenName As String = "isNull(" & prefix & "[NATIVE_MAIDENNAME], '')"
            Dim namesql As String = ""

            If format = "" Then format = HttpContext.Current.Session("NameFormat")

            If IOC_CODE = "USA" Then
                format = "F L"
            End If

            If format = "" Then format = "F L"

            For Each ch As Char In format
                Select Case ch
                    Case "F"c
                        namesql += fname
                    Case "M"c
                        namesql += mname
                    Case "L"c

                        namesql += lname

                    Case "N"c
                        namesql += pname
                    Case "A"c
                        namesql += maidenName
                    Case " "c
                        namesql += "'" & space & "'"
                    Case Else
                        namesql += "'" & ch & "'"
                End Select
                namesql += "+"
            Next
            namesql = namesql.TrimEnd("+")
            Return namesql
            'Return "isNull(" & prefix & "English_FirstName + '" & space & "','') + IsNull(" & prefix & "English_LastName, '')"
        End Function

        Public Shared Function getPersonInNativeOrEnglish(Optional ByVal prefix As String = "", _
          Optional ByVal space As String = "&nbsp;&nbsp;", _
          Optional ByVal format As String = "") As String
            Dim n_fname As String = "isNull(" & prefix & "[NATIVE_FIRSTNAME], '')"
            Dim n_mname As String = "isNull(" & prefix & "[NATIVE_MIDDLENAME], '')"
            Dim n_lname As String = "isNull(" & prefix & "[NATIVE_LASTNAME], '')"
            Dim e_fname As String = "isNull(" & prefix & "[ENGLISH_FIRSTNAME], '')"
            Dim e_mname As String = "isNull(" & prefix & "[ENGLISH_MIDDLENAME], '')"
            Dim e_lname As String = "isNull(" & prefix & "[ENGLISH_LASTNAME], '')"

            Dim n_maidenName As String = "isNull(" & prefix & "[NATIVE_MAIDENNAME], '')"
            Dim e_maidenName As String = "isNull(" & prefix & "[ENGLISH_MAIDENNAME], '')"

            Dim nformat As String
            Dim n_namesql As String = ""
            Dim e_namesql As String = ""

            If format = "" Then format = HttpContext.Current.Session("NameFormat")
            If format = "" Then format = "F L"

            For Each ch As Char In format
                Select Case ch
                    Case "F"c
                        n_namesql += n_fname
                        e_namesql += e_fname
                    Case "M"c
                        n_namesql += n_mname
                        e_namesql += e_mname
                    Case "L"c
                        n_namesql += n_lname
                        e_namesql += e_lname
                    Case "A"c
                        n_namesql += n_maidenName
                        e_namesql += e_maidenName
                    Case " "c
                        n_namesql += "'" & space & "'"
                        e_namesql += "'" & space & "'"
                    Case Else
                        n_namesql += "'" & ch & "'"
                        e_namesql += "'" & ch & "'"
                End Select
                n_namesql += "+"
                e_namesql += "+"
            Next
            n_namesql = n_namesql.TrimEnd("+")
            e_namesql = e_namesql.TrimEnd("+")
            nformat = "Case Len(" & n_fname & " + " & n_lname & ") When 0 Then " & e_namesql & " else " & n_namesql & " end"
            Return nformat
            'Return "isNull(isnull(" & prefix & "Native_FirstName," & prefix & "English_FirstName) + '" & space & "','') + IsNull(isnull(" & prefix & "Native_LastName," & prefix & "English_LastName), '')"
        End Function

        ''' <summary>
        ''' Get SQL Column Expression for get Person Name based-on Name Format Setting of current user
        ''' </summary>
        ''' <param name="FirstNameField">Field Name of English First Name</param>
        ''' <param name="MiddleNameField">Field Name of Middle First Name</param>
        ''' <param name="LastNameField">Field Name of English Last Name</param>
        ''' <param name="prefix">field name's prefix (tablename. eg. "p.")</param>
        ''' <param name="space">string use as space</param>
        ''' <param name="format">Name Format, if not specific, use current user setting</param>
        ''' <returns>SQL Column Expression</returns>
        ''' <remarks></remarks>
        Public Shared Function getPersonNameColumn( _
          ByVal FirstNameField As String, _
          ByVal MiddleNameField As String, _
          ByVal LastNameField As String, _
          Optional ByVal prefix As String = "", _
          Optional ByVal space As String = "  ", _
          Optional ByVal format As String = "") As String

            Dim fname As String = "isNull(" & prefix & FirstNameField & ", '')"
            Dim mname As String = "isNull(" & prefix & MiddleNameField & ", '')"
            Dim lname As String = "isNull(" & prefix & LastNameField & ", '')"
            Dim namesql As String = ""

            If format = "" Then format = HttpContext.Current.Session("NameFormat")
            If format = "" Then format = "F L"

            For Each ch As Char In format
                Select Case ch
                    Case "F"c
                        namesql += fname
                    Case "M"c
                        namesql += mname
                    Case "L"c
                        namesql += lname
                    Case " "c
                        namesql += "'" & space & "'"
                    Case Else
                        namesql += "'" & ch & "'"
                End Select
                namesql += "+"
            Next
            namesql = namesql.TrimEnd("+"c)
            Return namesql
            'Return "isNull(" & prefix & "English_FirstName + '" & space & "','') + IsNull(" & prefix & "English_LastName, '')"
        End Function


        ''' <summary>
        ''' Build SQL search condition for simple person name search feature
        ''' *** design for search name in PERSON table only ***
        ''' </summary>
        ''' <param name="personPrefix">eg. use "p." if the alias name of person table is "p"</param>
        ''' <param name="val"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' Created on December 18, 2013
        ''' Require index on table person -- IX_PERSON_GENERAL
        ''' </remarks>
        Public Shared Function GenSearchPersonName(ByVal personPrefix As String, ByVal val As String) As String
            If val = "" Then Return ""

            Dim sql As New StringBuilder
            'split search keyword by space or comma character
            Dim valArray As String() = val.Split(New Char() {" "c, ","c}, StringSplitOptions.RemoveEmptyEntries)

            If valArray.Length > 0 Then
                'one search keyword
                If valArray.Length = 1 Then
                    Dim e, n As String
                    e = getTxt(valArray(0) & "%")
                    n = getTxt(valArray(0) & "%", True)
                    sql.AppendLine(" AND (")
                    sql.AppendFormat("  {0}ENGLISH_FIRSTNAME like {1} OR {0}ENGLISH_LASTNAME like {1} ", personPrefix, e).AppendLine()
                    sql.AppendFormat("  OR {0}NATIVE_FIRSTNAME like {1} OR {0}NATIVE_LASTNAME like {1} ", personPrefix, n).AppendLine()
                    sql.AppendLine(" ) ")
                Else
                    Dim name1 As New Generic.List(Of String)
                    Dim name2 As New Generic.List(Of String)
                    Dim foo1, foo2 As String
                    Dim y As Integer

                    'multiple words (slower)
                    sql.AppendLine(" AND (")
                    foo1 = String.Join(" ", valArray)
                    sql.AppendFormat("  {0}ENGLISH_FIRSTNAME like {1} OR {0}ENGLISH_LASTNAME like {1} ", personPrefix, getTxt(foo1)).AppendLine()
                    sql.AppendFormat("  OR {0}NATIVE_FIRSTNAME like {1} OR {0}NATIVE_LASTNAME like {1} ", personPrefix, getTxt(foo1, True)).AppendLine()

                    'group search keywords into 2 groups, one for first name, another one for last name
                    'eg. if there are 3 words (A B C) -- search 2 rounds
                    'round 1 -- group 1 = A; group 2 = B C
                    'round 2 -- group 1 = A B; group 2 = C
                    For i As Integer = 0 To valArray.Length - 2
                        name1.Clear()
                        name2.Clear()
                        For y = 0 To valArray.Length - 1
                            If y <= i Then
                                name1.Add(valArray(y))
                            Else
                                name2.Add(valArray(y))
                            End If
                        Next

                        foo1 = String.Join(" ", name1.ToArray) + "%"
                        foo2 = String.Join(" ", name2.ToArray) + "%"

                        sql.AppendFormat("  OR ({0}ENGLISH_FIRSTNAME like {1} AND {0}ENGLISH_LASTNAME like {2}) ", personPrefix, getTxt(foo1), getTxt(foo2)).AppendLine()
                        sql.AppendFormat("  OR ({0}NATIVE_FIRSTNAME like {1} AND {0}NATIVE_LASTNAME like {2}) ", personPrefix, getTxt(foo1, True), getTxt(foo2, True)).AppendLine()
                        sql.AppendFormat("  OR ({0}ENGLISH_LASTNAME like {1} AND {0}ENGLISH_FIRSTNAME like {2}) ", personPrefix, getTxt(foo1), getTxt(foo2)).AppendLine()
                        sql.AppendFormat("  OR ({0}NATIVE_LASTNAME like {1} AND {0}NATIVE_FIRSTNAME like {2}) ", personPrefix, getTxt(foo1, True), getTxt(foo2, True)).AppendLine()
                    Next
                    sql.AppendLine(" ) ")
                End If
            End If

            Return sql.ToString
        End Function
#End Region

#Region " Set/Read Control's Property "
        'Enable/Disable all given controls
        Public Shared Sub setEnableControls(ByVal ctrls As ControlCollection, Optional ByVal Enabled As Boolean = False, _
                                            Optional ByVal includeButton As Boolean = False, Optional ByVal includeHyperLink As Boolean = True)
            Dim obj As Control
            For Each obj In ctrls
                Select Case obj.GetType.Name
                    Case "HtmlForm", "Panel", "HtmlTable", "HtmlTableRow", "HtmlTableCell", "GridView", "UpdatePanel", "Control", "HtmlGenericControl"
                        setEnableControls(obj.Controls, Enabled, includeButton, includeHyperLink)
                    Case "TextBox", "DateTextBox"
                        CType(obj, TextBox).ReadOnly = Not Enabled
                        ' CType(obj, TextBox).ForeColor = Color.Gray
                    Case "DropDownList"
                        CType(obj, DropDownList).Enabled = Enabled
                    Case "CheckBox"
                        CType(obj, CheckBox).Enabled = Enabled
                    Case "CheckBoxList"
                        CType(obj, CheckBoxList).Enabled = Enabled
                    Case "HyperLink"
                        If includeHyperLink Then CType(obj, HyperLink).Visible = Enabled
                    Case "RadioButton"
                        CType(obj, RadioButton).Enabled = Enabled
                    Case "RadioButtonList"
                        CType(obj, RadioButtonList).Enabled = Enabled
                    Case "Button"
                        If includeButton Then CType(obj, Button).Enabled = Enabled
                    Case "LinkButton"
                        If includeButton Then CType(obj, LinkButton).Enabled = Enabled
                    Case "HtmlButton"
                        If includeButton Then CType(obj, HtmlButton).Disabled = Not Enabled
                    Case "HtmlInputButton"
                        If includeButton Then CType(obj, HtmlInputButton).Disabled = Not Enabled
                End Select
            Next
        End Sub

        'Get check status for CheckBox
        Public Shared Function getCheckStatus(ByVal chk As Object, Optional ByVal TrueVal As String = "") As Boolean
            If IsDBNull(chk) Then
                Return False
            ElseIf chk = TrueVal Then
                Return True
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' Set DropDownList's selected item, if specific item not exists, add new one.
        ''' </summary>
        ''' <param name="dObject">DropDownList object to be set</param>
        ''' <param name="itemValue">value of item that you want to be selected</param>
        ''' <param name="DisplayText">if not specific, use itemValue.
        ''' when specific itemValue not exists in DropDownList, 
        ''' new ListItem will be created with specificed DisplayText and itemValue</param>
        ''' <param name="optFind">0: find by value; 1: find by display text; else: find both value and display text</param>
        ''' <remarks></remarks>
        Public Shared Sub setValueToDropDown(ByVal dObject As DropDownList, ByVal itemValue As String, _
          Optional ByVal DisplayText As String = Nothing, Optional ByVal optFind As Integer = 0)

            itemValue = Trim(itemValue)
            If DisplayText = Nothing Then
                DisplayText = itemValue
                optFind = 0
            End If
            DisplayText = DisplayText.Trim

            Dim selectedLI As ListItem
            Select Case optFind
                Case 0
                    'selectedLI = dObject.Items.FindByValue(itemValue)
                    For i As Integer = 0 To dObject.Items.Count - 1
                        If String.Compare(dObject.Items(i).Value, CString(itemValue), True) = 0 Then
                            selectedLI = dObject.Items(i)
                            Exit For
                        End If
                    Next
                Case 1
                    'selectedLI = dObject.Items.FindByText(DisplayText)
                    For i As Integer = 0 To dObject.Items.Count - 1
                        If String.Compare(dObject.Items(i).Text, CString(DisplayText), True) = 0 Then
                            selectedLI = dObject.Items(i)
                            Exit For
                        End If
                    Next
                Case Else
                    For i As Integer = 0 To dObject.Items.Count - 1
                        If String.Compare(dObject.Items(i).Value, CString(itemValue), True) = 0 AndAlso _
                           String.Compare(dObject.Items(i).Text, CString(DisplayText), True) = 0 Then
                            selectedLI = dObject.Items(i)
                            Exit For
                        End If
                    Next
            End Select
            'Add if not exists
            If selectedLI Is Nothing Then
                selectedLI = New ListItem(DisplayText, itemValue)
                dObject.Items.Add(selectedLI)
            End If
            dObject.SelectedIndex = dObject.Items.IndexOf(selectedLI)
        End Sub

        ''' <summary>
        ''' Set DropDownList's value. if specific value not exists, just ignore it
        ''' </summary>
        ''' <param name="dObject">DropDownList object to be set</param>
        ''' <param name="itemValue">value of item that you want to be selected</param>
        ''' <param name="optFind">0 = Find By Value, else = Find By Text</param>
        ''' <remarks></remarks>
        Public Shared Sub setValueToDropDownNoAdd(ByVal dObject As DropDownList, ByVal itemValue As String, _
          Optional ByVal optFind As Integer = 0)
            'built-in function is case-sensitive, I want case-insensitive
            If itemValue = Nothing Then itemValue = ""
            If optFind = 0 Then
                For Each LI As ListItem In dObject.Items
                    If LI.Value.ToLower = itemValue.ToLower Then
                        dObject.SelectedIndex = dObject.Items.IndexOf(LI)
                        Exit For
                    End If
                Next
            Else
                For Each LI As ListItem In dObject.Items
                    If LI.Text.ToLower = itemValue.ToLower Then
                        dObject.SelectedIndex = dObject.Items.IndexOf(LI)
                        Exit For
                    End If
                Next
            End If
        End Sub

        Public Shared Sub setValueToCheckBox(ByVal cObject As CheckBox, ByVal givenVal As Char, _
          Optional ByVal chkVal As Char = "Y"c)
            cObject.Checked = (givenVal = chkVal)
        End Sub

        Public Shared Sub setValueToRadioButtonList(ByVal rObject As RadioButtonList, ByVal givenVal As Object, Optional ByVal defaultIndex As Integer = -1)
            Try
                If IsDBNull(givenVal) Then
                    rObject.SelectedIndex = defaultIndex
                Else
                    rObject.SelectedIndex = defaultIndex
                    For i As Integer = 0 To rObject.Items.Count - 1
                        If String.Compare(rObject.Items(i).Value, CString(givenVal), True) = 0 Then
                            rObject.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception
                rObject.SelectedIndex = defaultIndex
            End Try
        End Sub

        Public Shared Sub setValueToCheckBoxList(ByVal cblObject As CheckBoxList, ByVal givenVals() As String)
            Dim cbx As ListItem
            Try
                If givenVals.Length > 0 Then
                    For Each val As String In givenVals
                        val = val.ToLower
                        For Each cbx In cblObject.Items
                            If cbx.Value.ToLower = val Then
                                cbx.Selected = True
                                Exit For
                            End If
                        Next
                    Next
                End If
            Catch ex As Exception

            End Try
        End Sub

        Public Shared Function GetTextValue(ByVal obj As Object) As String
            If IsDBNull(obj) Then
                Return ""
            Else
                Return obj
            End If
        End Function

        Public Shared Function getValuesFromCheckBoxList(ByVal cbl As CheckBoxList) As String()
            Dim vals As New Generic.List(Of String)
            Dim i As Integer = 0
            For Each cbx As ListItem In cbl.Items
                If cbx.Selected Then
                    vals.Add(cbx.Value)
                    i += 1
                End If
            Next

            Return vals.ToArray
        End Function

        Public Shared Sub ResetList(ByVal dList As ListControl, Optional ByVal inCludeBlank As Boolean = True)
            dList.Items.Clear()
            dList.Items.Add(New ListItem("All", ""))
            If inCludeBlank Then
                dList.Items.Add("_blank")
            End If
        End Sub

        Public Shared Function AddList(ByVal dList As ListControl, ByVal cmd As SqlCommand, Optional ByVal CurValue As String = "") As String
            If cmd.CommandText <> "" Then
                Dim myReader As SqlDataReader
                Try
                    myReader = cmd.ExecuteReader()
                    If myReader.FieldCount > 1 Then
                        'the first field as value, the second as display text
                        Do While (myReader.Read())
                            dList.Items.Add(New ListItem(CString(myReader(1)), CString(myReader(0))))
                        Loop
                    Else
                        'both value and display text is the same
                        Do While (myReader.Read())
                            dList.Items.Add(CString(myReader(0)))
                        Loop
                    End If
                    myReader.Close()
                Catch ex As Exception
                    If Not myReader Is Nothing Then myReader.Close()
                    AddList = getErrorMsg(ex)
                End Try
            End If

            If CurValue <> "" Then
                Try
                    dList.SelectedValue = CurValue
                Catch ex As Exception

                End Try
            End If
        End Function

        Public Shared Function TryAddList(ByVal dList As ListControl, ByVal cmd As SqlCommand, Optional ByVal CurValue As String = "") As Exception
            If cmd.CommandText <> "" Then
                Dim myReader As SqlDataReader
                Try
                    myReader = cmd.ExecuteReader()
                    If myReader.FieldCount > 1 Then
                        'the first field as value, the second as display text
                        Do While (myReader.Read())
                            dList.Items.Add(New ListItem(CString(myReader(1)), CString(myReader(0))))
                        Loop
                    Else
                        'both value and display text is the same
                        Do While (myReader.Read())
                            dList.Items.Add(CString(myReader(0)))
                        Loop
                    End If
                    myReader.Close()
                Catch ex As Exception
                    If Not myReader Is Nothing Then myReader.Close()
                    Return ex
                End Try
            End If

            If CurValue <> "" Then
                Try
                    dList.SelectedValue = CurValue
                Catch ex As Exception

                End Try
            End If

            Return Nothing
        End Function

        Public Shared Sub FillList(ByVal dList As ListControl, ByVal cmd As SqlCommand, Optional ByVal CurValue As String = "")
            If cmd.CommandText <> "" Then
                Dim myReader As SqlDataReader
                Try
                    myReader = cmd.ExecuteReader()
                    If myReader.FieldCount > 1 Then
                        'the first field as value, the second as display text
                        Do While (myReader.Read())
                            dList.Items.Add(New ListItem(CString(myReader(1)), CString(myReader(0))))
                        Loop
                    Else
                        'both value and display text is the same
                        Do While (myReader.Read())
                            dList.Items.Add(CString(myReader(0)))
                        Loop
                    End If
                    myReader.Close()
                Finally
                    If Not myReader Is Nothing Then myReader.Close()
                End Try
            End If

            If CurValue <> "" Then
                Try
                    dList.SelectedValue = CurValue
                Catch ex As Exception

                End Try
            End If
        End Sub

        Public Shared Sub CloneDropDown(ByVal MasterDDL As DropDownList, ByVal CloneDDL As DropDownList)
            CloneDDL.Items.Clear()
            For Each li As ListItem In MasterDDL.Items
                CloneDDL.Items.Add(New ListItem(li.Text, li.Value))
            Next
        End Sub

        Public Shared Sub CloneListItem(ByVal MasterList As DropDownList, ByVal CloneList As DropDownList)
            CloneList.Items.Clear()
            For Each li As ListItem In MasterList.Items
                CloneList.Items.Add(New ListItem(li.Text, li.Value))
            Next
        End Sub

        Public Shared Sub CloneListItem(ByVal MasterList As ListBox, ByVal CloneList As ListBox)
            CloneList.Items.Clear()
            For Each li As ListItem In MasterList.Items
                CloneList.Items.Add(New ListItem(li.Text, li.Value))
            Next
        End Sub

        Public Shared Sub CloneListItem(ByVal MasterList As ListBox, ByVal CloneList As DropDownList)
            CloneList.Items.Clear()
            For Each li As ListItem In MasterList.Items
                CloneList.Items.Add(New ListItem(li.Text, li.Value))
            Next
        End Sub

        Public Shared Sub CloneListItem(ByVal MasterList As DropDownList, ByVal CloneList As ListBox)
            CloneList.Items.Clear()
            For Each li As ListItem In MasterList.Items
                CloneList.Items.Add(New ListItem(li.Text, li.Value))
            Next
        End Sub

        Public Shared Sub setCancelBtn(ByVal onPage As Page, ByVal btnCancel As HtmlInputButton)
            Const backURL As String = "backURL"
            Const backQuery As String = "goto"
            Try
                With onPage
                    With onPage
                        If .Request.QueryString(backQuery) <> "" Then
                            'Dim dest As String = getBackDestination(New System.Uri(.Request.Url.AbsoluteUri, .Request.QueryString(backQuery)))
                            Dim dest As String = .Request.QueryString(backQuery)
                            Dim opr As String = "?"
                            If dest.IndexOf("?") >= 0 Then opr = "&"
                            Dim bScript As String
                            'If dest = "" Then
                            '    bScript = "history.back();"
                            'Else
                            bScript = "self.location='" & dest & opr & "result=cancel';"
                            If Not .Request.UrlReferrer Is Nothing Then
                                If dest = .Request.UrlReferrer.PathAndQuery Then
                                    bScript = "history.back();"
                                End If
                            End If
                            'End If
                            btnCancel.Attributes.Add("onClick", bScript)
                        Else
                            If .Session(backURL) = "" Then
                                btnCancel.Visible = False
                            Else
                                Dim bScript2 As String
                                If .IsPostBack Then
                                    bScript2 = "self.location = '" & .Session(backURL) & "';"
                                Else
                                    bScript2 = "history.back();"
                                End If
                                btnCancel.Attributes.Add("onClick", bScript2)
                            End If
                        End If
                    End With
                End With
            Catch ex As Exception
                btnCancel.Visible = False
            End Try
        End Sub
#End Region

#Region " GridView "
        'Get display text for DataGrid
        Public Shared Function getGridText(ByVal obj As Object) As String
            If IsDBNull(obj) Then
                Return "&lt;null&gt;"
            ElseIf obj = "" Then
                Return "&lt;null&gt;"
            Else
                Return obj
            End If
        End Function

        Public Shared Sub addGridRowNumber(ByVal grid As DataGrid, Optional ByVal colNum As Integer = 0, Optional ByVal srtNum As Integer = 1)
            Dim rowCount As Integer = (srtNum - 1)
            Dim rowGrid As DataGridItem
            For Each rowGrid In grid.Items
                rowCount = rowCount + 1
                rowGrid.Cells(colNum).Text = rowCount
            Next
        End Sub

        Public Shared Sub addGridRowNumber(ByVal grid As GridView, Optional ByVal colNum As Integer = 0, Optional ByVal srtNum As Integer = 1)
            Dim rowCount As Integer = (srtNum - 1)
            Dim rowGrid As GridViewRow
            For Each rowGrid In grid.Rows
                rowCount = rowCount + 1
                rowGrid.Cells(colNum).Text = rowCount
            Next

        End Sub

        Public Shared Sub addGridConfirmDelete(ByVal grid As DataGrid, ByVal colnum As Integer, _
          Optional ByVal script As String = "return confirm('Are you sure you want delete this item?');")
            Dim rowGrid As DataGridItem
            Dim obj As LinkButton

            For Each rowGrid In grid.Items
                Try
                    obj = rowGrid.Cells(colnum).Controls(0)
                    obj.Attributes.Add("onclick", script)
                Catch ex As Exception

                End Try
            Next
        End Sub

        Public Shared Sub addGridConfirmDelete(ByVal grid As GridView, ByVal colnum As Integer, _
        Optional ByVal script As String = "return confirm('Are you sure you want delete this item?');")
            Dim rowGrid As GridViewRow
            Dim obj As WebControl

            For Each rowGrid In grid.Rows
                Try
                    obj = rowGrid.Cells(colnum).Controls(0)
                    obj.Attributes.Add("onclick", script)
                Catch ex As Exception

                End Try
            Next
        End Sub

        Public Shared Function findGridColumnByCSS(ByVal grid As GridView, ByVal cssClassName As String, _
        Optional ByVal throwError As Boolean = True, Optional ByVal errMessage As String = "Error in grid view: Column disappeared.") As Integer
            Dim i As Integer
            Dim cssClass As String

            For i = 0 To grid.Columns.Count - 1
                cssClass = grid.Columns(i).ItemStyle.CssClass.ToLower
                If cssClass <> "" AndAlso cssClass.Contains(cssClassName.ToLower) Then
                    Return i
                End If
            Next

            'if cannot find in ItemStyle, try FooterStyle
            For i = 0 To grid.Columns.Count - 1
                cssClass = grid.Columns(i).FooterStyle.CssClass.ToLower
                If cssClass <> "" AndAlso cssClass.Contains(cssClassName.ToLower) Then
                    Return i
                End If
            Next

            If (throwError = True) Then Throw New Exception(errMessage)
            Return -1
        End Function

        Public Shared Function findGridColumnByCSS(ByVal grid As DataGrid, ByVal cssClassName As String, _
        Optional ByVal throwError As Boolean = True, Optional ByVal errMessage As String = "Error in data grid: Column disappeared.") As Integer
            Dim i As Integer
            Dim cssClass As String

            For i = 0 To grid.Columns.Count - 1
                cssClass = grid.Columns(i).ItemStyle.CssClass.ToLower
                If cssClass <> "" AndAlso cssClass.Contains(cssClassName.ToLower) Then
                    Return i
                End If
            Next

            'if cannot find in ItemStyle, try FooterStyle
            For i = 0 To grid.Columns.Count - 1
                cssClass = grid.Columns(i).FooterStyle.CssClass.ToLower
                If cssClass <> "" AndAlso cssClass.Contains(cssClassName.ToLower) Then
                    Return i
                End If
            Next

            If (throwError = True) Then Throw New Exception(errMessage)

            Return -1
        End Function
#End Region

#Region " Get Data "
        Public Shared Function getAppRoot() As String
            Return HttpContext.Current.Request.ApplicationPath.TrimEnd("/")
        End Function

        Public Shared Function getNewGUID() As String
            Return Guid.NewGuid.ToString("D").ToUpper
        End Function

        Public Shared Function getRefNumber(ByVal tableName As String, Optional ByVal IOC As String = Nothing) As String
            If tableName Is Nothing Then Return "00001"

            Dim strSQL As String = ""
            Dim returnVal As String
            Dim sqlParam As SqlParameter

            Try
                strSQL = String.Format("Exec getNewRef {0}, {1}", getTxt(IOC), getTxt(tableName))

                Using conSQL As New SqlConnection(getConnectionString())
                    conSQL.Open()
                    Using cmdSQL As New SqlCommand(strSQL, conSQL)
                        cmdSQL.CommandTimeout = 120
                        returnVal = CString(cmdSQL.ExecuteScalar)
                    End Using
                    conSQL.Close()
                End Using
            Catch ex As Exception
                returnVal = Right(CStr(Today.Year), 2) & "-00001"
            End Try

            Return returnVal
        End Function

        Public Shared Function getRefNumberByYear(ByVal tableName As String, ByVal year As String, Optional ByVal IOC As String = Nothing) As String
            If tableName Is Nothing Then Return "00001"

            If year Is Nothing Then year = CString(Now.Year)

            Dim strSQL As String = ""
            Dim returnVal As String
            Dim sqlParam As SqlParameter

            Try
                strSQL = String.Format("Exec getNewRefByYear {0}, {1}, {2}", getTxt(IOC), getTxt(tableName), getTxt(year))

                Using conSQL As New SqlConnection(getConnectionString())
                    conSQL.Open()
                    Using cmdSQL As New SqlCommand(strSQL, conSQL)
                        cmdSQL.CommandTimeout = 120
                        returnVal = CString(cmdSQL.ExecuteScalar)
                    End Using
                    conSQL.Close()
                End Using
            Catch ex As Exception
                returnVal = Right(CStr(Today.Year), 2) & "-00001"
            End Try

            Return returnVal
        End Function

        Public Shared Function getRegistryValue(ByVal cmd As SqlCommand, ByVal ioc As String, ByVal Value_Name As String) As String
            Dim res As String
            cmd.CommandText = "Select Value_Data From Registry Where Owner_IOC = " & getTxt(ioc) & " " & _
                              "And Value_Name = " & getTxt(Value_Name)
            res = CString(cmd.ExecuteScalar)
            Return res
        End Function

        Public Shared Function getRegistryValue(ByVal ioc As String, ByVal Value_Name As String) As String
            Dim res As String

            Using conn As New SqlConnection(getConnectionString())
                conn.Open()
                Using cmd As New SqlCommand(Nothing, conn)
                    cmd.CommandTimeout = 300
                    cmd.CommandText = "Select Value_Data From Registry Where Owner_IOC = " & getTxt(ioc) & " " & _
                                      "And Value_Name = " & getTxt(Value_Name)
                    res = CString(cmd.ExecuteScalar)
                End Using
                conn.Close()
            End Using

            Return res
        End Function

        Public Shared Function getDefaultLanguageCode(ByVal cmdSQL As SqlCommand, ByVal IOC_CODE As String) As String
            Dim result As String = ""
            Try
                cmdSQL.CommandText = "select language_code from partner_language where ioc_code = " & _
                        getTxt(IOC_CODE) & " and default_ind = 'Y'"
                result = CString(cmdSQL.ExecuteScalar)
            Catch ex As Exception
            End Try
            If result = "" Then result = "en-Default"
            Return result
        End Function

        Public Shared Function getDefaultNativeLanguage(ByVal cmd As SqlCommand, ByVal ioc_code As String) As String
            Return getDefaultNativeLanguage(ioc_code)
        End Function

        Public Shared Function getDefaultCommLanguage(ByVal cmd As SqlCommand, ByVal ioc_code As String) As String
            Return getDefaultCommLanguage(ioc_code)
        End Function

        Public Shared Function getDefaultCommLanguage(ByVal iocCode As String) As String
            Dim strSQL As String = ""
            Dim cName As String = ""

            strSQL = "select language from partner where ioc_code =" & getTxt(iocCode)
            Using conSQL As New SqlConnection(getConnectionString())
                conSQL.Open()
                Using cmdSQL As New SqlCommand(strSQL, conSQL)
                    cName = CString(cmdSQL.ExecuteScalar)
                End Using
                conSQL.Close()
            End Using
            Return cName
        End Function

        Public Shared Function getDefaultNativeLanguage(ByVal iocCode As String) As String
            Dim strSQL As String = ""
            Dim cName As String = ""

            Try
                strSQL = "select language from partner where ioc_code =" & getTxt(iocCode)
                Using conSQL As New SqlConnection(getConnectionString())
                    conSQL.Open()
                    Using cmdSQL As New SqlCommand(strSQL, conSQL)
                        cName = CString(cmdSQL.ExecuteScalar)
                    End Using
                    conSQL.Close()
                End Using
            Catch ex As Exception
                cName = ""
            End Try
            Return cName
        End Function

        Public Shared Function getFieldValue(ByVal ID_Value As String, ByVal tableName As String, ByVal fieldName As String, _
            Optional ByVal ID_fieldName As String = "ID") As String

            Dim fieldValue As String = ""

            Try
                Using conSQL As New SqlConnection(getConnectionString())
                    conSQL.Open()
                    Using cmdSQL As New SqlCommand(Nothing, conSQL)
                        fieldValue = getFieldValue(cmdSQL, ID_Value, tableName, fieldName, ID_fieldName)
                    End Using
                    conSQL.Close()
                End Using
            Catch ex As Exception
                fieldValue = ""
            End Try
            Return fieldValue
        End Function

        Public Shared Function getFieldValue(ByVal cmdSQL As SqlCommand, ByVal ID_Value As String, ByVal tableName As String, _
        ByVal fieldName As String, Optional ByVal ID_fieldName As String = "ID", Optional ByVal ReturnBlankIfError As Boolean = True, _
        Optional ByVal returnType As String = "string") As String
            '-- Technical note: when select with "isnull" function, the SQL server will return the following value to web application:
            '-- '  ' for null string, '0' for null number and '1/1/1900' for null date

            Dim fieldValue As String = ""
            Dim sql As New StringBuilder
            Try
                If fieldName.IndexOf("[") = -1 Then fieldName = "[" & fieldName & "]"
                sql.Append("SELECT Top 1 ").Append(fieldName)
                sql.Append(" FROM ").Append(tableName)
                sql.Append(" WHERE ").Append(ID_fieldName).Append(" = ").Append(getTxt(ID_Value))

                cmdSQL.CommandText = sql.ToString
                fieldValue = CString(cmdSQL.ExecuteScalar).Trim

                If returnType.ToLower = "integer" Then
                    Try : fieldValue = CString(CInt(fieldValue)) : Catch ex As Exception : fieldValue = "0" : End Try
                End If
                If fieldValue = "1/1/1900" Then 'Change null date value to blank. Pusit 2011-05-20
                    fieldValue = ""
                End If

            Catch ex As Exception
                If ReturnBlankIfError Then
                    If returnType.ToLower = "integer" Then
                        fieldValue = "0"
                    Else
                        fieldValue = ""
                    End If
                Else
                    Throw
                End If
            End Try

            Return fieldValue
        End Function

        Public Shared Function isNonPL(ByRef ioc As String) As Boolean
            Dim strSQL As String = ""
            Dim isNPL As Boolean

            strSQL = "SELECT PL_USER FROM PARTNER WHERE IOC_CODE='" & ioc & "'"
            Using conSQL As New SqlConnection(getConnectionString())
                conSQL.Open()
                Using cmdSQL As New SqlCommand(strSQL, conSQL)
                    isNPL = (CType(cmdSQL.ExecuteScalar(), String) <> "Y")
                End Using
                conSQL.Close()
            End Using

            Return isNPL
        End Function

        Public Shared Function isGLPartner(ByRef ioc As String) As Boolean
            Dim strSQL As String = ""
            Dim isGL As Boolean

            strSQL = "SELECT PL_VERSION FROM PARTNER WHERE IOC_CODE='" & ioc & "'"
            Using conSQL As New SqlConnection(getConnectionString())
                conSQL.Open()
                Using cmdSQL As New SqlCommand(strSQL, conSQL)
                    isGL = (CType(cmdSQL.ExecuteScalar(), String) = "GL3.0")
                End Using
                conSQL.Close()
            End Using
            Return isGL
        End Function

        Public Shared Function isNonPL(ByVal Cmd As SqlCommand, ByVal ioc As String) As Boolean
            Dim isNPL As Boolean
            Dim sqlR As SqlDataReader
            Cmd.CommandText = "SELECT isNull(PL_USER, 'N') FROM PARTNER WHERE IOC_CODE='" & ioc & "'"
            Try
                sqlR = Cmd.ExecuteReader
                If sqlR.Read Then
                    isNPL = (sqlR.GetString(0) <> "Y")
                Else
                    isNPL = True
                End If
                sqlR.Close()
            Finally
                If sqlR IsNot Nothing Then sqlR.Close()
            End Try

            Return isNPL
        End Function

        Public Enum getName
            FullName = 0
            FirstName
            LastName
            MiddelName
            NickName
            PreferredName
        End Enum

#End Region

#Region " Transliterate "
        'this procedure name is misspelling
        Public Shared Sub addTransliterte(ByVal origin As TextBox, ByVal target As TextBox, ByVal tGroup As String, Optional ByVal MaxLength As Integer = 50)
            addTransliterate(origin, target, tGroup, MaxLength)
        End Sub

        ''' <summary>
        ''' add Transliterate function (javascript) to html object
        ''' </summary>
        ''' <param name="origin">Source object</param>
        ''' <param name="target">Target object</param>
        ''' <param name="tGroup">Transliterate group</param>
        ''' <param name="MaxLength">Maximum character length; For memo data type use 0</param>
        ''' <remarks></remarks>
        Public Shared Sub addTransliterate(ByVal origin As TextBox, ByVal target As TextBox, ByVal tGroup As String, Optional ByVal MaxLength As Integer = 50, Optional ByVal targetCssClass As String = "")
            origin.Attributes.Add("onkeyup", "strTrans(this.value, '" & target.ClientID & "', " & tGroup & ", " & MaxLength & ")")
            origin.Attributes.Add("onkeydown", "strTrans(this.value, '" & target.ClientID & "', " & tGroup & ", " & MaxLength & ")")
            origin.Attributes.Add("onblur", "strTrans(this.value, '" & target.ClientID & "', " & tGroup & ", " & MaxLength & ")")

            target.ReadOnly = True
            If targetCssClass = "" Then
                target.CssClass = "OAFieldBackRO"
            Else
                target.CssClass = targetCssClass
            End If
        End Sub

        Public Shared Sub addTransliterateByTargetID(ByVal origin As TextBox, ByVal targetUniqueID As String, ByVal tGroup As String, Optional ByVal MaxLength As Integer = 50)
            origin.Attributes.Add("onkeyup", "strTrans(this.value, '" & targetUniqueID & "', " & tGroup & ", " & MaxLength & ")")
            origin.Attributes.Add("onkeydown", "strTrans(this.value, '" & targetUniqueID & "', " & tGroup & ", " & MaxLength & ")")
            origin.Attributes.Add("onblur", "strTrans(this.value, '" & targetUniqueID & "', " & tGroup & ", " & MaxLength & ")")
        End Sub

        ''' <summary>
        ''' add Transliterate function (javascript) to html object
        ''' </summary>
        ''' <param name="origin">Source object</param>
        ''' <param name="target">Target object</param>
        ''' <param name="tGroup">Transliterate group</param>
        ''' <param name="MaxLength">Maximum character length; For memo data type use 0</param>
        ''' <remarks></remarks>
        Public Shared Sub addTransliterate(ByVal origin As TextBox, ByVal target As Control, ByVal tGroup As String, Optional ByVal MaxLength As Integer = 50)
            origin.Attributes.Add("onkeyup", "strTrans(this.value, '" & target.UniqueID & "', " & tGroup & ", " & MaxLength & ")")
            origin.Attributes.Add("onkeydown", "strTrans(this.value, '" & target.UniqueID & "', " & tGroup & ", " & MaxLength & ")")
            origin.Attributes.Add("onblur", "strTrans(this.value, '" & target.UniqueID & "', " & tGroup & ", " & MaxLength & ")")
        End Sub
#End Region

#Region " List Field in specify Table "
        Public Shared Function getFieldsList(ByVal cmdSQL As SqlCommand, ByVal tableName As String, Optional ByVal includeField As String = "", Optional ByVal excludeField As String = "", Optional ByVal order As Boolean = False) As String
            Dim readSQL As SqlDataReader
            Dim strSQL As String = ""
            Dim iFields As String = ""
            Dim eFields As String = ""
            Dim fList As New StringBuilder
            Dim ord As String = ""

            Try
                If includeField <> "" Then iFields = " AND [name] IN (" & includeField & ") "
                If excludeField <> "" Then eFields = " AND [name] NOT IN (" & excludeField & ")"
                If order Then ord = " order by 1 "

                strSQL = "SELECT [name] FROM sys.columns " & _
                         "WHERE	[Object_ID] = OBJECT_ID('" & tableName & "') " & _
                         iFields & eFields & _
                         ord
                cmdSQL.CommandText = strSQL
                readSQL = cmdSQL.ExecuteReader
                '1st
                If readSQL.Read Then
                    fList.Append("[").Append(readSQL.GetString(0)).Append("]")
                End If
                '2+
                While readSQL.Read
                    fList.Append(",[").Append(readSQL.GetString(0)).Append("]")
                End While
                readSQL.Close()

                Return fList.ToString
            Finally
                If readSQL IsNot Nothing Then readSQL.Close()
            End Try
        End Function

        Public Shared Function getFieldsList(ByVal tableName As String, Optional ByVal includeField As String = "", Optional ByVal excludeField As String = "", Optional ByVal order As Boolean = False) As String
            Using conn As New SqlConnection(getConnectionString)
                conn.Open()
                Using cmd As New SqlCommand(Nothing, conn)
                    Return getFieldsList(cmd, tableName, includeField, excludeField, order)
                End Using
            End Using
        End Function

        Public Shared Function listField(ByVal tableName As String, Optional ByVal includeField As String = "", Optional ByVal excludeField As String = "", Optional ByVal order As Boolean = False) As String
            Return getFieldsList(tableName, includeField, excludeField, order)
        End Function
#End Region


#Region " Database Connection "
        Public Shared Function openDB(ByVal conn As SqlConnection, ByVal lblErr As Label) As Boolean
            Try
                conn.Open()
            Catch ex As Exception
                lblErr.Text += "Cannot open database: " & getErrorMsg(ex) & "<BR>"
                Return False
            End Try
            Return True
        End Function

        Public Shared Function openDB(ByVal conn As SqlConnection, ByRef Err As String) As Boolean
            Try
                conn.Open()
            Catch ex As Exception
                Err += "Cannot open database: " & getErrorMsg(ex) & "<BR>"
                Return False
            End Try
            Return True
        End Function

        Public Shared Sub closeDB(ByVal conn As SqlConnection)
            Try
                conn.Close()
            Catch ex As Exception

            End Try
        End Sub
#End Region

#Region " Build Error Message "
        Public Class MyException
            Inherits System.Exception

            Public Sub New(ByVal msg As String)
                MyBase.New(msg)
            End Sub

            Public Sub New(ByVal msg As String, ByVal innerEx As Exception)
                MyBase.New(msg, innerEx)
            End Sub
        End Class

        Friend Shared Function ShouldIgnoreError(ByVal ex As Exception) As Boolean
            If TypeOf (ex) Is System.Threading.ThreadAbortException AndAlso _
               ex.StackTrace.IndexOf("System.Web.HttpResponse.End()", StringComparison.InvariantCultureIgnoreCase) > -1 Then
                Return True
            Else
                Return False
            End If
        End Function

        Private Shared Function getErrorLogConnectionString() As String
            Try
                Return System.Web.Configuration.WebConfigurationManager.ConnectionStrings("ConnStrLog").ConnectionString
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        ''' <summary>
        ''' Obsoleted
        ''' </summary>
        ''' <param name="errPage"></param>
        ''' <param name="ErrorTitle"></param>
        ''' <param name="ErrMessage"></param>
        ''' <remarks></remarks>
        Public Shared Sub generateErrorPage(ByVal errPage As Page, ByVal ErrorTitle As String, Optional ByVal ErrMessage As String = "")
            With errPage
                .Response.Clear()
                .Response.Write("<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">" & vbCrLf)
                .Response.Write("<html>" & vbCrLf)
                .Response.Write("<head><title>Error</title></head>" & vbCrLf)
                .Response.Write("<body>" & vbCrLf)
                .Response.Write("<table border=0 width=100% height=100%>" & vbCrLf)
                .Response.Write("<tr valign=middle>" & vbCrLf)
                .Response.Write("	<td align=center><font color=red size=+3>" & ErrorTitle & "</font><br>" & vbCrLf)
                .Response.Write("		<font size=+1>" & ErrMessage & "</font>" & vbCrLf)
                If Not .Request.UrlReferrer Is Nothing Then
                    .Response.Write("		<br><br><input type='button' value='back' onClick='history.back();'>" & vbCrLf)
                End If
                .Response.Write("	</td>" & vbCrLf)
                .Response.Write("</tr>" & vbCrLf)
                .Response.Write("</table>" & vbCrLf)
                .Response.Write("</body>" & vbCrLf)
                .Response.Write("</html>")
                .Response.End()
            End With
        End Sub

        ''' <summary>
        ''' Display error and also keep error in the error log
        ''' </summary>
        ''' <param name="ErrorTitle"></param>
        ''' <param name="ex"></param>
        ''' <param name="back"></param>
        ''' <remarks></remarks>
        

        

        

        Public Shared Function getErrorMsg(ByVal ex As Exception) As String
            If ex.GetType Is GetType(MyException) Then
                If ex.InnerException Is Nothing Then
                    Return ex.Message
                Else
                    Return ex.Message & ":: " & getErrorMsg(ex.InnerException)
                End If
            ElseIf isTestSite() Then
                If ex.GetType Is GetType(System.FormatException) AndAlso _
                   My.Request.UserLanguages IsNot Nothing AndAlso _
                   My.Request.UserLanguages.Length > 0 Then
                    Return ex.ToString & "<br />[" & String.Join(", ", My.Request.UserLanguages) & "]"
                Else
                    Return ex.ToString
                End If
            Else
                Return ex.GetType.ToString & ": " & ex.Message
            End If
        End Function

        Public Shared Sub generateSuccessPage(ByVal curPage As Page, Optional ByVal winTitle As String = "Success", _
          Optional ByVal cssPath As String = "", _
          Optional ByVal winMessage As String = "Successfully done.", _
          Optional ByVal backCaption As String = "Return to Previous Page", _
          Optional ByVal backScript As String = "history.back();")
            With curPage.Response
                .Clear()
                .Write("<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">" & vbCrLf)
                .Write("<html>" & vbCrLf)
                .Write("<head>" & vbCrLf)
                .Write("<title>" & winTitle & "</title>" & vbCrLf)
                .Write("<meta http-equiv='Pragma' content='no-cache'>" & vbCrLf)
                .Write("<meta http-equiv='expires' content='0'>" & vbCrLf)
                .Write("<LINK href='" & curPage.ResolveUrl("~").TrimEnd("/") & "/CoreFunction/guStyle.css' type='text/css' rel='stylesheet'>" & vbCrLf)
                .Write("</head>" & vbCrLf)
                .Write("<body style='overflow:hidden'>" & vbCrLf)
                .Write("<table width=100% height=100% border=0 style='border: solid 1px black'>" & vbCrLf)
                .Write("<tr valign=middle>" & vbCrLf)
                .Write("	<td align=center><font class='Success'>" & winMessage & "</font>" & vbCrLf)
                If Not backScript Is Nothing Then
                    If backScript <> "" Then
                        backScript = backScript.Replace("'", """")
                        .Write("	<br><br><input type='button' class=bttn value='" & backCaption & "' onClick='" & backScript & "'>" & vbCrLf)
                    End If
                End If
                .Write("	</td>" & vbCrLf)
                .Write("</tr>" & vbCrLf)
                .Write("</table>" & vbCrLf)
                .Write("</body>" & vbCrLf)
                .Write("</html>")
                .End()
            End With
        End Sub

        Public Shared Sub generateSuccessPage(Optional ByVal winTitle As String = "Success", _
          Optional ByVal winMessage As String = "Successfully done.", _
          Optional ByVal backCaption As String = "Return to Previous Page", _
          Optional ByVal backScript As String = "history.back();")
            With HttpContext.Current.Response
                .Clear()
                .Write("<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">" & vbCrLf)
                .Write("<html xmlns=""http://www.w3.org/1999/xhtml"" style=""height: 99%;"" >" & vbCrLf)
                .Write("<head>" & vbCrLf)
                .Write("<title>" & winTitle & "</title>" & vbCrLf)
                .Write("<meta http-equiv='Pragma' content='no-cache' />" & vbCrLf)
                .Write("<meta http-equiv='expires' content='0' />" & vbCrLf)
                .Write("<link href='" & HttpContext.Current.Request.ApplicationPath.TrimEnd("/") & "/CoreFunction/guStyle.css' type='text/css' rel='stylesheet' />" & vbCrLf)
                .Write("</head>" & vbCrLf)
                .Write("<body style=""overflow: hidden; height: 99%;"">" & vbCrLf)
                .Write("<table border=""0"" style=""border: solid 1px black; height:95%; width:100%;"">" & vbCrLf)
                .Write("<tr valign=""middle"">" & vbCrLf)
                .Write("	<td align=""center"" class=""text""><div class=""Success"">" & winMessage & "</div>" & vbCrLf)
                If backScript IsNot Nothing AndAlso backScript <> "" Then
                    backScript = backScript.Replace("'", """")
                    .Write("	<br /><input type=""button"" class=""bttn"" value=""" & backCaption & """ onClick='" & backScript & "' />" & vbCrLf)
                End If
                .Write("	</td>" & vbCrLf)
                .Write("</tr>" & vbCrLf)
                .Write("</table>" & vbCrLf)
                .Write("</body>" & vbCrLf)
                .Write("</html>")
                .End()
            End With
        End Sub
#End Region

#Region " New Record Wizard "
        'Call this function build QueryString need for call New Service Wizard
        Public Shared Function buildQueryStringForNewService(Optional ByVal defaultIOC As String = "", _
          Optional ByVal defaultProgram As String = "", Optional ByVal gobackWhenDone As Boolean = False, _
          Optional ByVal forceParticipation As Boolean = False) As String
            Dim gotoUrl As String
            With HttpContext.Current
                gotoUrl = .Request.Url.PathAndQuery
                If .Request.QueryString("result") = "" Then
                    gotoUrl = gotoUrl.Replace("?result=", "")
                    gotoUrl = gotoUrl.Replace("&result=", "")
                Else
                    gotoUrl = gotoUrl.Replace("?result=" & .Request.QueryString("result"), "")
                    gotoUrl = gotoUrl.Replace("&result=" & .Request.QueryString("result"), "")
                End If
                Return "?goto=" & .Server.UrlEncode(gotoUrl) & IIf(defaultIOC <> "", "&ioc=" & defaultIOC, "") & IIf(defaultProgram <> "", "&program=" & defaultProgram, "") & IIf(gobackWhenDone, "&return=1", "") & IIf(forceParticipation, "&toParticipation=1", "")
            End With
        End Function

        'Call this function build QueryString need for call New Service Wizard (For Online Inquiry)
        Public Shared Function buildQueryStringForNewServiceFromOnlineInquiry(ByVal inquiryID As String) As String
            Dim gotoUrl As String
            With HttpContext.Current
                gotoUrl = .Request.Url.PathAndQuery
                If .Request.QueryString("result") = "" Then
                    gotoUrl = gotoUrl.Replace("?result=", "")
                    gotoUrl = gotoUrl.Replace("&result=", "")
                Else
                    gotoUrl = gotoUrl.Replace("?result=" & .Request.QueryString("result"), "")
                    gotoUrl = gotoUrl.Replace("&result=" & .Request.QueryString("result"), "")
                End If
                Return "?inqID=" & inquiryID & "&goto=" & .Server.UrlEncode(gotoUrl)
            End With
        End Function

        'Clear Data About New Person Wizard from Session
        Public Shared Sub NPW_ClearSessionData()
            With HttpContext.Current.Session
                .Remove("N_IOC")
                .Remove("N_NTitle")
                .Remove("N_Title")
                .Remove("N_NFName")
                .Remove("N_EFName")
                .Remove("N_NLName")
                .Remove("N_ELName")
                .Remove("N_Gender")
                .Remove("N_DOB")
                .Remove("N_NMidName")
                .Remove("N_EMidName")
            End With
        End Sub

        Public Shared Function NPW_getIOC() As String
            Return HttpContext.Current.Session("N_IOC")
        End Function

        Public Shared Function NPW_getNativeTitle() As String
            Return HttpContext.Current.Session("N_NTitle")
        End Function

        Public Shared Function NPW_getEnglishTitle() As String
            Return HttpContext.Current.Session("N_Title")
        End Function

        Public Shared Function NPW_getNativeFirstName() As String
            Return HttpContext.Current.Session("N_NFName")
        End Function

        Public Shared Function NPW_getEnglishFirstName() As String
            Return HttpContext.Current.Session("N_EFName")
        End Function

        Public Shared Function NPW_getNativeLastName() As String
            Return HttpContext.Current.Session("N_NLName")
        End Function

        Public Shared Function NPW_getEnglishLastName() As String
            Return HttpContext.Current.Session("N_ELName")
        End Function

        Public Shared Function NPW_getGender() As String
            Return HttpContext.Current.Session("N_Gender")
        End Function

        Public Shared Function NPW_getLanguageCommunication() As String
            Return HttpContext.Current.Session("Language")
        End Function

        Public Shared Function NPW_getBirthDate() As Date
            If HttpContext.Current.Session("N_DOB") = Nothing Then
                Return Nothing
            Else
                Return CDate(HttpContext.Current.Session("N_DOB"))
            End If

        End Function
        Public Shared Function NPW_getNativeMiddleName() As String
            Return HttpContext.Current.Session("N_NMidName")
        End Function

        Public Shared Function NPW_getEnglishMiddleName() As String
            Return HttpContext.Current.Session("N_EMidName")
        End Function

        'Call this function build QueryString need for call New Person Wizard (For New Person)
        Public Shared Function buildQueryStringForNewPerson(Optional ByVal defaultIOC As String = "") As String
            Dim gotoUrl As String
            With HttpContext.Current
                gotoUrl = .Request.Url.PathAndQuery
                If .Request.QueryString("result") = "" Then
                    gotoUrl = gotoUrl.Replace("?result=", "")
                    gotoUrl = gotoUrl.Replace("&result=", "")
                Else
                    gotoUrl = gotoUrl.Replace("?result=" & .Request.QueryString("result"), "")
                    gotoUrl = gotoUrl.Replace("&result=" & .Request.QueryString("result"), "")
                End If
                Return "?goto=" & .Server.UrlEncode(gotoUrl) & IIf(defaultIOC <> "", "&ioc=" & defaultIOC, "")
            End With
        End Function

        'Call this function build QueryString need for call New Person Wizard (For New Family Member)
        Public Shared Function buildQueryStringForNewFamilyMember(ByVal familyID As String) As String
            Dim gotoUrl As String
            With HttpContext.Current
                gotoUrl = .Request.Url.PathAndQuery
                If .Request.QueryString("result") = "" Then
                    gotoUrl = gotoUrl.Replace("?result=", "")
                    gotoUrl = gotoUrl.Replace("&result=", "")
                Else
                    gotoUrl = gotoUrl.Replace("?result=" & .Request.QueryString("result"), "")
                    gotoUrl = gotoUrl.Replace("&result=" & .Request.QueryString("result"), "")
                End If
                Return "?fID=" & familyID & "&goto=" & .Server.UrlEncode(gotoUrl)
            End With
        End Function

        'Call this function build QueryString need for call New Person Wizard (For New Family Member)
        Public Shared Function buildQueryStringForNewFamilyMemberByPersonID(ByVal personID As String) As String
            Dim gotoUrl As String
            With HttpContext.Current
                gotoUrl = .Request.Url.PathAndQuery
                If .Request.QueryString("result") = "" Then
                    gotoUrl = gotoUrl.Replace("?result=", "")
                    gotoUrl = gotoUrl.Replace("&result=", "")
                Else
                    gotoUrl = gotoUrl.Replace("?result=" & .Request.QueryString("result"), "")
                    gotoUrl = gotoUrl.Replace("&result=" & .Request.QueryString("result"), "")
                End If
                Return "?pID=" & personID & "&goto=" & .Server.UrlEncode(gotoUrl)
            End With
        End Function

        'Call this function build QueryString need for call New Person Wizard (For New Person)
        Public Shared Function buildQueryStringForNewPersonFromOnlineInquiry(ByVal inquiryID As String) As String
            Dim gotoUrl As String
            With HttpContext.Current
                gotoUrl = .Request.Url.PathAndQuery
                If .Request.QueryString("result") = "" Then
                    gotoUrl = gotoUrl.Replace("?result=", "")
                    gotoUrl = gotoUrl.Replace("&result=", "")
                Else
                    gotoUrl = gotoUrl.Replace("?result=" & .Request.QueryString("result"), "")
                    gotoUrl = gotoUrl.Replace("&result=" & .Request.QueryString("result"), "")
                End If
                Return "?inqID=" & inquiryID & "&goto=" & .Server.UrlEncode(gotoUrl)
            End With
        End Function

        'Call this function build QueryString need for call New Person Wizard (For New Person)
        Public Shared Function buildQueryStringForNewPersonFromFINUserRegistration(ByVal finID As String) As String
            Dim gotoUrl As String
            With HttpContext.Current
                gotoUrl = .Request.Url.PathAndQuery
                If .Request.QueryString("result") = "" Then
                    gotoUrl = gotoUrl.Replace("?result=", "")
                    gotoUrl = gotoUrl.Replace("&result=", "")
                Else
                    gotoUrl = gotoUrl.Replace("?result=" & .Request.QueryString("result"), "")
                    gotoUrl = gotoUrl.Replace("&result=" & .Request.QueryString("result"), "")
                End If
                Return "?finID=" & finID & "&goto=" & .Server.UrlEncode(gotoUrl)
            End With
        End Function

        ''' <summary>
        ''' Redirect To New Person Wizard From User Account Registration
        ''' </summary>
        ''' <param name="regID">User Account registration ID</param>
        ''' <remarks></remarks>
        Public Shared Sub redirectToNewPersonFromUserRegistration(ByVal regID As String)
            Dim gotoUrl As String
            With HttpContext.Current
                gotoUrl = .Request.Url.PathAndQuery
                If .Request.QueryString("result") = "" Then
                    gotoUrl = gotoUrl.Replace("?result=", "")
                    gotoUrl = gotoUrl.Replace("&result=", "")
                Else
                    gotoUrl = gotoUrl.Replace("?result=" & .Request.QueryString("result"), "")
                    gotoUrl = gotoUrl.Replace("&result=" & .Request.QueryString("result"), "")
                End If
                .Response.Redirect("~/GlobalLink/Service/NewRecord/newPersonWizard.aspx?regID=" & regID & "&goto=" & .Server.UrlEncode(gotoUrl))
            End With
        End Sub
#End Region

#Region " Monthly Contact "
        Public Shared Function recordOwner(ByVal mID As String, ByVal sess As SessionState.HttpSessionState) As Boolean
            Dim strsql As String = ""
            Dim res As Integer

            Using sqlConn As New SqlConnection(getConnectionString())
                sqlConn.Open()
                Using sqlCmd As New SqlCommand(strsql, sqlConn)
                    sqlCmd.CommandTimeout = 360

                    strsql = "SELECT COUNT(*) " & _
                             "FROM  MONTHLY_CONTACT " & _
                             "WHERE ID = '" & mID & "' AND " & _
                             "      CREATED_BY = '" & sess("MM_UserName") & "'"
                    '"      (CONTACT_BY = '" & Session("MM_FULL_NAME") & "' OR CREATED_BY = '" & Session("MM_UserName") & "')"
                    sqlCmd.CommandText = strsql
                    res = CType(sqlCmd.ExecuteScalar, Integer)
                End Using
                sqlConn.Close()
            End Using

            If res > 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        
#End Region

#Region " Send Email "
        ''' <summary>
        ''' Send email only
        ''' </summary>
        ''' <param name="AFS_EMail"></param>
        ''' <param name="eFrom"></param>
        ''' <param name="eTo"></param>
        ''' <param name="eCC"></param>
        ''' <param name="eSubject"></param>
        ''' <param name="eBody"></param>
        ''' <param name="fromModule"></param>
        ''' <param name="emailFormat"></param>
        ''' <param name="senderDisplayName"></param>
        ''' <remarks></remarks>
        Public Shared Sub sendEmail(ByVal AFS_EMail As System.Net.Mail.MailMessage, ByVal eFrom As String, ByVal eTo As String, _
                                    ByVal eCC As String, ByVal eSubject As String, ByVal eBody As String, _
                                    Optional ByVal fromModule As String = "", Optional ByVal emailFormat As Byte = 0, _
                                    Optional ByVal senderDisplayName As String = Nothing)

            Dim mailClient As System.Net.Mail.SmtpClient
            Dim ccEmail As String = ""
            Dim bccEmail As String = getConfigVal("Bcc")

            'eFrom = getSendBy(eFrom)
            eFrom = GetSenderEmailAddress(eFrom, False)

            If eFrom.IndexOf("<"c) < 0 Then
                If senderDisplayName = "" Then
                    senderDisplayName = "AFS Intercultural Programs"
                End If
            Else
                senderDisplayName = ""
            End If

            ccEmail = IIf(eCC.Trim <> "", eCC, eFrom)
            If isProductionSite() Then
                If senderDisplayName = Nothing Then
                    AFS_EMail.From = New System.Net.Mail.MailAddress(eFrom)
                Else
                    AFS_EMail.From = New System.Net.Mail.MailAddress(eFrom, senderDisplayName)
                End If
                AFS_EMail.To.Add(eTo)
                If ccEmail.Trim <> "" Then AFS_EMail.CC.Add(ccEmail)
                If bccEmail <> "" Then AFS_EMail.Bcc.Add(bccEmail)
                AFS_EMail.SubjectEncoding = Encoding.UTF8
                AFS_EMail.BodyEncoding = Encoding.UTF8
                AFS_EMail.Subject = eSubject
                AFS_EMail.Body = eBody
                AFS_EMail.IsBodyHtml = (emailFormat = 1)

                mailClient = New Net.Mail.SmtpClient("localhost")
                mailClient.UseDefaultCredentials = True
                mailClient.Send(AFS_EMail)

                AFS_EMail.Dispose()
            Else

            End If
        End Sub

        Public Shared Function getSendBy(ByVal sendBy As String) As String
            Dim sby As String = sendBy
            If sendBy.IndexOfAny("AFSCustomerAccess@afs.org") < 0 AndAlso sendBy.IndexOfAny("AFS Intercultural Programs") < 0 Then
                If sendBy = "" Then
                    sby = "AFSCustomerAccess@afs.org"
                Else
                    If sendBy.IndexOf(",") < 0 Then sby = "AFS Intercultural Programs <" & sendBy & ">"
                End If
            End If
            Return sby
        End Function

        Public Shared Function GetSenderEmailAddress(ByVal sendBy As String, ByVal AddDefaultSenderName As Boolean) As String
            If sendBy <> "" Then
                sendBy = sendBy.Trim()
                sendBy = sendBy.Trim(",")
            End If

            If sendBy = "" Then
                If AddDefaultSenderName Then
                    Return "AFS Intercultural Programs <glnotify@afs.org>"
                Else
                    Return "glnotify@afs.org"
                End If
            Else
                Dim addr As String() = sendBy.Split(New Char() {"<", ">"}, 3)
                Dim emailaddr As String

                If addr.Length > 1 Then
                    emailaddr = addr(1)
                Else
                    emailaddr = addr(0)
                End If

                If emailaddr.Contains(",") Then
                    emailaddr = emailaddr.Substring(0, emailaddr.IndexOf(","))
                End If

                If AddDefaultSenderName AndAlso addr.Length < 2 Then
                    sendBy = "AFS Intercultural Programs <" & emailaddr & ">"
                Else
                    If addr.Length > 1 Then
                        sendBy = addr(0) & "<" & emailaddr
                    Else
                        sendBy = emailaddr
                    End If
                    If addr.Length > 2 Then
                        sendBy &= ">" & addr(2)
                    End If
                    If sendBy.Contains("<") AndAlso Not sendBy.Contains(">") Then
                        sendBy &= ">"
                    End If
                End If

                Return sendBy
            End If
        End Function
#End Region

        Private Shared Function ResourceText() As Object
            Throw New NotImplementedException
        End Function

    End Class
End Namespace
