<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InputEdit.aspx.cs" Inherits="App_BONGACCP_InputEdit" MaintainScrollPositionOnPostback="true" %>
<%--<%@ Register Src="~/App/CommitmentControl/UserControl/oInputUpdateTele.ascx" TagPrefix="app" TagName="oInputUpdateTele" %>--%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/App/CommitmentControl/UserControl/actForm.ascx" TagPrefix="app" TagName="actForm" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <script type="text/javascript">
                function CloseAndRebind(args) {
                    GetRadWindow().BrowserWindow.refreshGrid(args);
                    GetRadWindow().close();
                }

                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

                    return oWindow;
                }

                function CancelEdit() {
                    GetRadWindow().close();
                }
            </script>

            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                </Scripts>
            </telerik:RadScriptManager>

            <app:actForm runat="server" ID="actForm" />
            <%--<app:oInputUpdateTele runat="server" ID="oInputUpdateTele" />--%>
        </div>
    </form>
</body>
</html>
