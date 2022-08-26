<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CostStoryDetails.aspx.cs" Inherits="CostStoryDetails" %>
<%@ Register src="~/App/PDCC/UserControl/ActivityLogCntl.ascx" tagname="ActivityLogCntl" tagprefix="uc4" %>

<link href="../CSS/styles.css" type="text/css" rel="stylesheet" media="screen" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc4:ActivityLogCntl ID="ActivityLogCntl1" runat="server" />
    </div>
    </form>
</body>
</html>
