<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Action.aspx.cs" Inherits="App_Prices_Action" %>

<%@ Register Src="~/App/Prices/UserControl/oReviewerReport.ascx" TagPrefix="app" TagName="oReviewerReport" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <app:oReviewerReport runat="server" ID="oReviewerReport" />
    </div>
    </form>
</body>
</html>
