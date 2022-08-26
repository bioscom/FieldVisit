<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CPFocalPointAction.aspx.cs" Inherits="App_IDD_CPFocalPointAction" Title="Assign IDD to Analyst" %>

<%@ Register Src="UserControl/oCPFocalPoint.ascx" TagName="oCPFocalPoint" TagPrefix="uc2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function GetRadWindow() {
            var oWindow = null;

            if (window.radWindow)
                oWindow = window.RadWindow; //Will work in Moz in all cases, including clasic dialog      
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;//IE (and Moz as well)      
            return oWindow;
        }

        function Close() {
            GetRadWindow().Close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                </Scripts>
            </telerik:RadScriptManager>

            <uc2:oCPFocalPoint ID="oCPFocalPoint1" runat="server" />

        </div>
    </form>
</body>
</html>
