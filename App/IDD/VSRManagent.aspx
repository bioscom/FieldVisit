<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VSRManagent.aspx.cs" Inherits="App_IDD_VSRManagent" Title="VSR Manager" %>

<%@ Register Src="~/App/IDD/UserControl/oVSRChange.ascx" TagPrefix="app" TagName="oVSRChange" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <app:oVSRChange runat="server" ID="oVSRChange" />
    </div>
    </form>
</body>
</html>
