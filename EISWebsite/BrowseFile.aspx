<%@ Page Language="VB" AutoEventWireup="false" CodeFile="BrowseFile.aspx.vb" Inherits="BrowseFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

.bttn 
{
	background: #0d8de8 repeat-x left center;
	vertical-align: middle;
	color:#FFFFFF;
	padding:4px 8px 4px 8px;
	text-decoration:none; 
	font-family: Arial, Helvetica, sans-serif; 
	font-size: 12px; 
	font-weight: bold; 
	border-right: solid 1px #0d8de8;
    border-bottom : solid 1px #0d8de8;
   	border-top: solid 1px #4ea3e4;
   	border-left: solid 1px #4ea3e4;
	font-style: normal; 
	/*line-height: 12px; */
	white-space: nowrap; 
	margin: auto auto; 
	cursor: pointer;
	/*background-image: url(../Image/btn_bg_blue.gif);*/
	overflow: visible;
	}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Button ID="btnUpload" runat="server" class="bttn" Text="Upload" />
        &nbsp;
        <button class="bttn" onclick="self.parent.closeUpload();" type="button">
            Cancel
        </button>
    </form>
</body>
</html>
