<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MakeRequestNew.aspx.cs" Inherits="App_IDD_MakeRequestNew" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="UserControl/oDetails.ascx" TagName="oDetails" TagPrefix="uc2" %>
<%@ Register Src="~/App/IDD/UserControl/oAddVendor.ascx" TagPrefix="uc2" TagName="oAddVendor" %>
<%@ Register Src="~/App/IDD/UserControl/oEditVendor.ascx" TagName="oEditVendor" TagPrefix="uc3" %>


<%@ Register Src="UserControl/oDocumentLoader.ascx" TagName="oDocumentLoader" TagPrefix="uc4" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

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


            (function (global, undefined) {
                var demo = {};

                function alertCallBackFn(arg) {
                    radalert("<strong>radalert</strong> returned the following result: <h3 style='color: #ff0000;'>" + arg + "</h3>", 350, 250, "Result");
                }

                function confirmCallBackFn(arg) {
                    radalert("<strong>radconfirm</strong> returned the following result: <h3 style='color: #ff0000;'>" + arg + "</h3>", 350, 250, "Result");
                }

                function promptCallBackFn(arg) {
                    radalert("After 7.5 million years, <strong>Deep Thought</strong> answers:<h3 style='color: #ff0000;'>" + arg + "</h3>", 350, 250, "Deep Thought");
                }

                Sys.Application.add_load(function () {
                    //attach a handler to radio buttons to update global variable holding image url
                    $telerik.$('input:radio').bind('click', function () {
                        demo.imgUrl = $telerik.$(this).val();
                    });
                });


                global.alertCallBackFn = alertCallBackFn;
                global.confirmCallBackFn = confirmCallBackFn;
                global.promptCallBackFn = promptCallBackFn;

                global.$dialogsDemo = demo;

            })(window);
        </script>

        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>

        <div>
            <div style="font-size: 11pt">
                <fieldset>
                    <legend>
                        <b style="color: green">Select Nature of Request</b>
                    </legend>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 250px">
                                <asp:Label ID="Label15" runat="server" Text="Nature of Request:"></asp:Label>
                            </td>
                            <td>

                                <telerik:RadComboBox ID="ddlNature" runat="server" EmptyMessage="Select Nature of Request" RenderMode="Lightweight"
                                    Skin="Office2010Silver" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlNature_SelectedIndexChanged" ValidationGroup="ooo">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Text="New" Value="1" />
                                        <telerik:RadComboBoxItem runat="server" Text="Renewal" Value="2" />
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <%--<br />--%>
                <asp:Panel ID="pnlNewRequest" runat="server" Visible="false">
                    <div style="font-size: 11pt; width: 700px">
                        <uc2:oAddVendor runat="server" ID="oAddVendor" />
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlSearchVendor" runat="server" Visible="false">
                    <fieldset>
                        <legend>
                            <b style="color: green">Search for Vendor</b>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 250px">
                                    <asp:Label ID="Label20" Font-Bold="true" runat="server" Text="Enter Vendor's Registered Name:"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddlVendor" runat="server" AutoPostBack="True" ValidationGroup="vali" EmptyMessage="Enter Vendor name..." Skin="Office2010Silver" Width="400px" DropDownWidth="600" EnableLoadOnDemand="true" Filter="Contains" Font-Size="10pt" Height="200" HighlightTemplatedItems="true" OnItemsRequested="ddlVendor_ItemsRequested" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged" RenderMode="Lightweight">
                                        <HeaderTemplate>
                                            <table cellpadding="0" cellspacing="0" style="width: 550px; font-size: 9pt">
                                                <tr>
                                                    <td style="width: 240px;">Registered Name</td>
                                                    <td style="width: 220px;">Email Address</td>
                                                    <td style="width: 90px;">Phone No</td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0" style="width: 550px; font-size: 9pt">
                                                <tr>
                                                    <td style="width: 240px;"><%# DataBinder.Eval(Container, "Text")%></td>
                                                    <td style="width: 220px;"><%# DataBinder.Eval(Container, "Attributes['EMAILADDRESS']")%></td>
                                                    <td style="width: 90px;"><%# DataBinder.Eval(Container, "Attributes['TELEPHONENO']")%></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:Panel>
                <%--<br />--%>
                <asp:Panel runat="server" ID="pnlHider">
                    <fieldset>
                        <legend>
                            <span style="color: #FF0000"><b>Request for Renewal:</b></span>
                        </legend>

                        <div style="font-size: 11pt; width: 700px; overflow-x: scroll">
                            <uc3:oEditVendor ID="oEditVendor1" runat="server" />
                        </div>
                    </fieldset>
                </asp:Panel>

                <%--<asp:Panel runat="server" ID="pnlRenewal">
                    <fieldset>
                        <legend>
                            <b style="color: green">Upload Documents</b>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2" style="height: 35px">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="background-color: silver; border: solid 1px silver">
                                                            <asp:Label ID="Label13" runat="server" Text="Upload Documents:"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div style="height: 150px; overflow: auto; border: solid 1px silver">
                                                                <div id="DemoContainer1" runat="server" class="demo-container size-narrow">
                                                                    <telerik:RadAsyncUpload ID="AsyncUpload1" runat="server" ChunkSize="1048576" RenderMode="Lightweight" />
                                                                    <telerik:RadProgressArea ID="RadProgressArea1" runat="server" RenderMode="Lightweight" />
                                                                </div>
                                                                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
                                                                    <AjaxSettings>
                                                                        <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                                                                            <UpdatedControls>
                                                                                <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1" />
                                                                                <telerik:AjaxUpdatedControl ControlID="DemoContainer1" />
                                                                            </UpdatedControls>
                                                                        </telerik:AjaxSetting>
                                                                    </AjaxSettings>
                                                                </telerik:RadAjaxManager>
                                                                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div style="float: right">
                                                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Renew Request" Width="120px" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </fieldset>

                </asp:Panel>

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                <asp:ValidationSummary ID="ValidationSummaryRenewal" ValidationGroup="Renewal" runat="server" ShowMessageBox="True" ShowSummary="False" />--%>
            </div>
        </div>

        <asp:Panel runat="server" ID="pnlLoadDocs">
            <uc4:oDocumentLoader ID="oDocumentLoader1" runat="server" />
        </asp:Panel>

    </form>

</body>
</html>
