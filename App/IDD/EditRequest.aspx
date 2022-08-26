<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditRequest.aspx.cs" Inherits="App_IDD_EditRequest" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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


            function checkIDAvailability() {
                $.ajax({
                    type: "POST",
                    url: "EditRequest.aspx/checkVendorCode",
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
            }

            function checkVendorNameAvailability() {
                $.ajax({
                    type: "POST",
                    url: "EditRequest.aspx/checkVendorName",
                    data: "{IDVal: '" + $("#<% =txtVendorName.ClientID %>").val() + "' }",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: onSuccess,
                    failure: function (AjaxResponse) {
                        document.getElementById("lblAvailable").innerHTML = "Error Occured";
                        document.getElementById("btnSubmit").disabled = true;
                    }
                });

                function onSuccess(AjaxResponse) {
                    document.getElementById("lblAvailable").innerHTML = AjaxResponse.d;
                    document.getElementById("btnSubmit").disabled = false;
                }
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
                        <b style="color: green">Update Vendor Information</b>
                    </legend>
                    <table style="width: 690px">
                        <tr>
                            <td>
                                <asp:Label ID="Label20" runat="server" Text="Vendor's Full Registered Name:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtVendorName" runat="server" Text='<%# Bind("VENDOURCODE") %>' Width="400px">
                                    <ClientEvents OnBlur="checkVendorNameAvailability" />
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Material/Service:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="ddlServices" runat="server" AutoPostBack="true" EmptyMessage="Select Category" Skin="Office2010Silver" ValidationGroup="lll" Width="350px">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 200px">
                                <asp:Label ID="Label8" runat="server" Text="Vendor's Code:"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtVendorCode" ErrorMessage="Vendor Code is required" ValidationGroup="Renewal">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtVendorCode" runat="server" Text='<%# Bind("VENDOURCODE") %>' Width="200px">
                                    <ClientEvents OnBlur="checkIDAvailability" />
                                </telerik:RadTextBox>
                                <asp:Label ID="lblAvailability" runat="server" Font-Bold="True" Font-Size="9pt" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>


                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="Vendor's Address:"></asp:Label>

                            </td>
                            <td style="height: 90px">
                                <telerik:RadTextBox ID="txtVendorAddress" runat="server" Height="80px" Text='<%# Bind("ADDRESS") %>' TextMode="MultiLine" Width="400px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="Company Representative:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtRepresentative" runat="server" Text='<%# Bind("REPRESENTATIVE") %>' Width="400px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" Text="E-mail address:"></asp:Label>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailAddress" Display="Dynamic" ErrorMessage="Please, enter valid e-mail address." ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$" ValidationGroup="Renewal">*</asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtEmailAddress" ErrorMessage="Vendor's Email Address is required" ValidationGroup="Renewal">*</asp:RequiredFieldValidator>

                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtEmailAddress" runat="server" Text='<%# Bind("EMAILADDRESS") %>' Width="400px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label16" runat="server" Text="Telephone(GSM NO):"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMskPhoneNo" ErrorMessage="Phone Number is required" ValidationGroup="Renewal">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <telerik:RadMaskedTextBox ID="txtMskPhoneNo" runat="server" Mask="(####) ###-####" Text='<%# Bind("TELEPHONENO") %>'>
                                </telerik:RadMaskedTextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="Label21" runat="server" Text="Estimated Value of Contract($):"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtContractValue" ErrorMessage="Estimated Value of Contract is required" ValidationGroup="Renewal">*</asp:RequiredFieldValidator>

                            </td>
                            <td>
                                <telerik:RadNumericTextBox ID="txtContractValue" runat="server" Culture="en-US" DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="160px">
                                    <NegativeStyle Resize="None" />
                                    <NumberFormat ZeroPattern="$n" />
                                    <EmptyMessageStyle Resize="None" />
                                    <ReadOnlyStyle Resize="None" />
                                    <FocusedStyle Resize="None" />
                                    <DisabledStyle Resize="None" />
                                    <InvalidStyle Resize="None" />
                                    <HoveredStyle Resize="None" />
                                    <EnabledStyle Resize="None" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label22" runat="server" Text="Does Business Ownership have Government official element?:" Width="250px"></asp:Label>
                            </td>
                            <td style="height: 35px">
                                <telerik:RadRadioButtonList ID="btnLstGO" runat="server" AutoPostBack="False" Columns="2" Direction="Horizontal">
                                </telerik:RadRadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 35px">
                                <asp:Label ID="Label23" runat="server" Text="Will the counterparty be acting as a Government Intermediary (GI)?:" Width="250px"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadRadioButtonList ID="btnLstGI" runat="server" AutoPostBack="False" Columns="2" Direction="Horizontal">
                                </telerik:RadRadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
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
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="float: right">
                                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" ValidationGroup="Renewal" Width="140px" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                <asp:ValidationSummary ID="ValidationSummaryRenewal" ValidationGroup="Renewal" runat="server" ShowMessageBox="True" ShowSummary="False" />
            </div>
        </div>
    </form>
</body>
</html>
