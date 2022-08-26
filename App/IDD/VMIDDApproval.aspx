<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VMIDDApproval.aspx.cs" Inherits="App_IDD_VMIDDApproval" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <%--<script type="text/javascript">
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
        </script>--%>

        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>

        <div>
            <table>
                <tr>
                    <td>Approved?:
                    </td>
                    <td>
                        <telerik:RadRadioButtonList ID="rdbApproved" runat="server" Columns="2" Direction="Horizontal"></telerik:RadRadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>Comments:
                    </td>
                    <td>
                        <telerik:RadTextBox ID="txtComments" Height="100px" Width="500px" TextMode="MultiLine" runat="server"></telerik:RadTextBox>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        &nbsp;
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" Width="100px" CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
