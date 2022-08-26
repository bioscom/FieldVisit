<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MakeRequest.aspx.cs" Inherits="App_Prices_MakeRequest" %>

<%@ Register Src="~/App/Prices/UserControl/oRequestForm.ascx" TagPrefix="app" TagName="oRequestForm" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <app:oRequestForm runat="server" ID="oRequestForm" />
    </div>
    </form>
</body>
</html>
