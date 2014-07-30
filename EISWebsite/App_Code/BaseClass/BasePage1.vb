'Page with built-in Database Connection and Commmand
'Also use client culture

Imports fn = EISUpdate.inFunction
Imports GlobalUpdate
Imports System.Data
Imports System.Data.SqlClient

Namespace EISUpdate
    ''' <summary>
    ''' Base Page that built-in SQLConnection and SQLCommand 
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class BasePage1
        Inherits Web.UI.Page

        Private Const sqlUrlAccess As String = "INSERT INTO AUDIT_URL_ACCESS_2014 (USER_ID, URL, IP_ADDRESS) VALUES ({0}, {1}, {2})"

#Region " Friend Variable "
        Friend conn As SqlConnection
        Friend cmd As SqlCommand
        Friend cUser As String
        Friend cIOC As String
        Friend IsStaff As Boolean
        Friend IsCustomer As Boolean
        Friend allChapter As Boolean
        Friend language_FormName As String
        Friend language_ioc As String
        Friend language_name As String
        Friend ReadOnly RequireLogin As Boolean = False
        Friend ReadOnly AutoTranslatePage As Boolean = False
        Friend ReadOnly AutoUseDetectedCulture As Boolean = True 'automatically change current thread's culture to language send from web browser
#End Region

#Region " Protected Property "
        Private _p1 As Boolean
        Private _p2 As Boolean
        Private _translateFormName As String

        Protected Sub New(p1 As Boolean, p2 As Boolean)
            ' TODO: Complete member initialization 
            _p1 = p1
            _p2 = p2
        End Sub

        Protected Sub New(p1 As Boolean, p2 As Boolean, TranslateFormName As String)
            ' TODO: Complete member initialization 
            _p1 = p1
            _p2 = p2
            _translateFormName = TranslateFormName
        End Sub

        Protected ReadOnly Property SQLConn() As SqlConnection
            Get
                Return conn
            End Get
        End Property

        Protected ReadOnly Property SQLCmd() As SqlCommand
            Get
                Return cmd
            End Get
        End Property

        Protected ReadOnly Property CurrentUserName() As String
            Get
                Return cUser
            End Get
        End Property

        Protected ReadOnly Property CurrentUserIOC() As String
            Get
                Return cIOC
            End Get
        End Property

        Protected ReadOnly Property CurrentUserIsCustomer() As Boolean
            Get
                Return IsCustomer
            End Get
        End Property

        Protected ReadOnly Property CurrentUserIsStaff() As Boolean
            Get
                Return IsStaff
            End Get
        End Property

#End Region

#Region " Private Method "
        Private Function getDBConnectionString() As String
            Try
                Return System.Web.Configuration.WebConfigurationManager.ConnectionStrings(GlobalConst.ConnectString).ConnectionString
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Private Sub openDBConnection()
            Try
                conn.Open()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub closeDBConnection()
            Try
                If cmd IsNot Nothing Then
                    cmd.Dispose()
                    cmd = Nothing
                End If

                If conn IsNot Nothing Then
                    If conn.State <> ConnectionState.Closed Then conn.Close()
                    conn.Dispose()
                    conn = Nothing
                End If
            Catch ex As Exception

            End Try
        End Sub

#End Region

    End Class

    ''' <summary>
    ''' BasePage1 with Native UI enabled
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class BasePage1N
        Inherits BasePage1

        Public Sub New()
            MyBase.New(False, True)
        End Sub

        Public Sub New(ByVal TranslateFormName As String)
            MyBase.New(False, True, TranslateFormName)
        End Sub
    End Class

    ''' <summary>
    ''' BasePage1 that check session expire and log page visit
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class BasePage1_S
        Inherits BasePage1

        Public Sub New()
            MyBase.New(True, False)
        End Sub
    End Class
End Namespace

