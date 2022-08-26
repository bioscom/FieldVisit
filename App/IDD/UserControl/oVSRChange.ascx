<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oVSRChange.ascx.cs" Inherits="App_IDD_UserControl_oVSRChange" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    <Scripts>
        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
    </Scripts>
</telerik:RadScriptManager>

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

<table style="color: black; width: 600px; font-size: 11pt">
    <tr>
        <td colspan="2">
            <fieldset>
                <legend>
                    <b style="color: green">Approvals</b>
                </legend>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 200px">
                            <asp:Label ID="Label14" runat="server" Text="Select Remarks:"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="ddlRemarks" runat="server" EmptyMessage="Select Your Remark..." RenderMode="Lightweight" Skin="Office2010Silver" Width="300px"></telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label15" runat="server" Text="Select status:"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadRadioButtonList ID="btnLstStatus" runat="server" AutoPostBack="true" ValidationGroup="status" Columns="5" OnSelectedIndexChanged="btnlstCompleted_SelectedIndexChanged" Direction="Horizontal"></telerik:RadRadioButtonList>
                            <asp:Panel runat="server" ID="Hider" Visible="false">
                                <telerik:RadDatePicker RenderMode="Lightweight" ID="ValidityPeriod" Width="250px" runat="server" DateInput-DisplayDateFormat="dd-MMM-yyyy" DateInput-Label="Effective Date:"></telerik:RadDatePicker>
                            </asp:Panel>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label16" runat="server" Text="IDD Analyst Comments:"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtComment" runat="server" Height="60px" TextMode="MultiLine" Width="400px"></telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label17" runat="server" Text="VM/IDD Lead Comments:"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtApproverComments" Height="60px" Width="400px" TextMode="MultiLine" runat="server"></telerik:RadTextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>






        </td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <fieldset>
                <legend>
                    <b style="color: green">Vendor Information Management</b>
                </legend>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 250px">
                            <asp:Label ID="Label22" runat="server" Text="Vendor's Full Registered Name:"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtVendorName" runat="server" Width="400px" Height="50px" TextMode="MultiLine"></telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="Material/Service:"></asp:Label>

                        </td>
                        <td>
                            <telerik:RadComboBox ID="ddlServices" runat="server" AutoPostBack="true" EmptyMessage="Select Category" Skin="Office2010Silver" ValidationGroup="lll" Width="400px">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 250px">
                            <asp:Label ID="Label18" runat="server" Text="Vendor Code:"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtVendorCode" runat="server" Width="200px">
                                <%--<ClientEvents OnBlur="checkIDAvailability" />--%>
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Vendor's Address:"></asp:Label>

                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtVendorAddress" runat="server" Height="80px" TextMode="MultiLine" Width="400px">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="Company Representative:"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtRepresentative" runat="server" Width="400px">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label19" runat="server" Text="E-mail address:"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailAddress" Display="Dynamic" ErrorMessage="Please, enter valid e-mail address." ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$">*</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtEmailAddress" ErrorMessage="Vendor's Email Address is required">*</asp:RequiredFieldValidator>

                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtEmailAddress" runat="server" Width="400px">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label20" runat="server" Text="Telephone(GSM NO):"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMskPhoneNo" ErrorMessage="Phone Number is required">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <telerik:RadMaskedTextBox ID="txtMskPhoneNo" runat="server" Mask="(####) ###-####">
                            </telerik:RadMaskedTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label21" runat="server" Text="Est. Value of Contract($):"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtContractValue" ErrorMessage="Estimated Value of Contract is required">*</asp:RequiredFieldValidator>

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
                            <asp:Label ID="Label1" runat="server" Text="Does Business Ownership have Government official element?:" Width="250px"></asp:Label>
                        </td>
                        <td style="height: 35px">
                            <telerik:RadRadioButtonList ID="btnLstGO" runat="server" AutoPostBack="False" Columns="2" Direction="Horizontal">
                            </telerik:RadRadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 35px">
                            <asp:Label ID="Label2" runat="server" Text="Will the counterparty be acting as a Government Intermediary (GI)?:" Width="250px"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadRadioButtonList ID="btnLstGI" runat="server" AutoPostBack="False" Columns="2" Direction="Horizontal">
                            </telerik:RadRadioButtonList>
                        </td>
                    </tr>
                </table>
            </fieldset>


        </td>
    </tr>

    <tr>
        <td colspan="2">
            <table style="width: 100%">
                <tr>
                    <td style="width: 180px">
                        <asp:Label ID="LabelClose" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" Width="100px" CausesValidation="False" />
                        <asp:HiddenField ID="RequestIdHF" runat="server" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

