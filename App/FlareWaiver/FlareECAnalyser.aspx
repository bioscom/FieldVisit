<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FlareECAnalyser.aspx.cs" Inherits="App_FlareWaiver_FlareECAnalyser" %>

<%@ Register Src="~/App/FlareWaiver/UserControl/oFlareECAnalyser.ascx" TagPrefix="app" TagName="oFlareECAnalyser" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/FlareWaiverStyles.css" type="text/css" rel="stylesheet" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <app:oFlareECAnalyser runat="server" ID="oFlareECAnalyser" />
    </div>
    </form>
</body>
</html>
