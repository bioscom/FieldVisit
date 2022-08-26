<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewDetails.aspx.cs" Inherits="App_BONGACCP_ViewDetails" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/App/CommitmentControl/UserControl/DetailView.ascx" TagPrefix="app" TagName="DetailView" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font: 14px/1.4 Helvetica, Arial, sans-serif;
        }

        button.RadButton span.rbIcon {
            vertical-align: sub;
        }

        .rdfLabel.rdfBlock {
            margin-top: 6px;
        }
    </style>
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
            <div style="width: 100%">
                <table style="width: 99%">
                    <tr>
                        <td style="vertical-align:top">
                            <app:DetailView runat="server" ID="DetailView1" />
                        </td>
                        <td style="vertical-align:top">
                            <asp:Panel ID="Isaac" runat="server" Visible="false">
                                <app:DetailView runat="server" ID="DetailView2" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
