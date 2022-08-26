<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IDDApproval.aspx.cs" Inherits="App_IDD_IDDApproval" Title="Approve IDD" %>

<%@ Register Src="~/App/IDD/UserControl/oVMIDDApproval.ascx" TagPrefix="app" TagName="oVMIDDApproval" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <app:oVMIDDApproval runat="server" ID="oVMIDDApproval" />
    </div>
    </form>
</body>
</html>
