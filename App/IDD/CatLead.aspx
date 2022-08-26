<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CatLead.aspx.cs" Inherits="App_IDD_CatLead" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

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


                <%--function checkIDAvailability() {
                    $.ajax({
                        type: "POST",
                        url: "MakeRequest.aspx/checkVendorCode",
                        data: "{IDVal: '" + $("#<% =txtVendorCode.ClientID %>").val() + "' }",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: onSuccess,
                        failure: function (AjaxResponse) {
                            document.getElementById("lblAvailability").innerHTML = "Error Occured";
                        }
                    });

                    function onSuccess(AjaxResponse) {
                        document.getElementById("lblAvailability").innerHTML = AjaxResponse.d;
                    }
                }--%>
            </script>

            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                </Scripts>
            </telerik:RadScriptManager>


            <table>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Category:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCategory" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Category Lead:"></asp:Label>
                    </td>
                    <td>

                        <telerik:RadComboBox RenderMode="Lightweight" ID="ddlCategoryLead" runat="server" Height="200" Width="430px" Font-Size="10pt"
                            DropDownWidth="500" EmptyMessage="Search for Category Lead..." HighlightTemplatedItems="true"
                            EnableLoadOnDemand="true" Filter="Contains" OnItemsRequested="ddlCategoryLead_ItemsRequested"
                            Skin="Office2010Silver">

                            <HeaderTemplate>
                                <table style="width: 475px; font-size: 9pt" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td style="width: 165px;">Name</td>
                                        <td style="width: 220px;">Email Address</td>
                                        <td style="width: 90px;">Ref. Ind.</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>

                            <ItemTemplate>
                                <table style="width: 475px; font-size: 9pt" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td style="width: 165px;"><%# DataBinder.Eval(Container, "Text")%></td>
                                        <td style="width: 220px;"><%# DataBinder.Eval(Container, "Attributes['EMAIL']")%></td>
                                        <td style="width: 90px;"><%# DataBinder.Eval(Container, "Attributes['REFIND']")%></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
