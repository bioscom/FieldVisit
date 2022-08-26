<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Snepco.ascx.cs" Inherits="App_CommitmentControl_UserControl_Snepco" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="~/App/CommitmentControl/UserControl/InputUpdateCommitmentDetails.ascx" TagName="InputUpdateCommitmentDetails" TagPrefix="uc4" %>
<%@ Register Src="~/App/CommitmentControl/UserControl/InputUpdateCommitmentDetailsUpdt.ascx" TagName="InputUpdateCommitmentDetailsUpdt" TagPrefix="uc5" %>


<script type="text/javascript">
    function preventMoreDecimalPlaces(sender, args) {
        var separatorPos = sender._textBoxElement.value.indexOf(sender.get_numberFormat().DecimalSeparator);
        if (args.get_keyCharacter().match(/[0-9]/) &&
            separatorPos != -1 &&
            sender.get_caretPosition() > separatorPos + sender.get_numberFormat().DecimalDigits) {
            args.set_cancel(true);
        }
    }

</script>


<%--<style>
    #parent {
        height: 500px;
        width: 100%;
        overflow: hidden;
        position: relative;
    }

    #child {
        position: absolute;
        top: 0;
        bottom: 0;
        left: 0;
        right: -17px; /* Increase/Decrease this value for cross-browser compatibility */
        overflow-y: scroll;
    }
</style>--%>


<div id="parent">
    <div id="child">
        <table>
            <tr class="EditFormHeader">
                <td style="width:180px">Title:<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtTitle" ErrorMessage="Cost Object is required">*</asp:RequiredFieldValidator>--%>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTitle" ErrorMessage="Title is required" ForeColor="Red" ID="RequiredFieldValidator16" ValidationGroup="SubForm">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <%--<asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("TITLE") %>' Width="500px"></asp:TextBox>--%>
                    <telerik:RadTextBox RenderMode="Lightweight" ID="txtTitle" runat="server" Text='<%# Bind("TITLE") %>' Width="500px"></telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>Cost Object:<asp:RequiredFieldValidator runat="server" ControlToValidate="txtCostObject" ErrorMessage="Cost Object is required" ForeColor="Red" ID="RequiredFieldValidator17" ValidationGroup="SubForm">*</asp:RequiredFieldValidator>
                </td>

                <td>
                    <telerik:RadTextBox RenderMode="Lightweight" ID="txtCostObject" runat="server" Text='<%# Bind("COSTOBJECT") %>' Width="500px"></telerik:RadTextBox>
                </td>
            </tr>

            <tr>
                <td>Purchasing Group:<%--<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlPurchaseGroup" ErrorMessage="Select Purchase Group" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>--%><asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator22" ControlToValidate="ddlPurchaseGroup" Display="Dynamic" ErrorMessage="Please select Purchasing Group" CssClass="validator" ValidationGroup="SubForm">*</asp:RequiredFieldValidator>
                &nbsp;</td>
                <td>
                    <%--<asp:DropDownList ID="ddlPurchaseGroup" runat="server" Width="200px">
                <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
            </asp:DropDownList>--%>

                    <telerik:RadComboBox RenderMode="Lightweight" ID="ddlPurchaseGroup" Font-Size="9pt" runat="server" Width="200px" Skin="Office2010Silver" EmptyMessage="Choose Purchasing Group"></telerik:RadComboBox>
                </td>
            </tr>

            <tr>
                <td>Team:<%--<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlteam" ErrorMessage="Select Team" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>--%><asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator23" ControlToValidate="ddlteam" Display="Dynamic" ErrorMessage="Please select team" CssClass="validator" ValidationGroup="SubForm">*</asp:RequiredFieldValidator>
                &nbsp;</td>
                <td>
                    <%--<asp:DropDownList ID="ddlteam" runat="server" Width="200px">
                <asp:ListItem Selected="True" Text="Select" Value=""></asp:ListItem>
            </asp:DropDownList>--%>

                    <telerik:RadComboBox RenderMode="Lightweight" ID="ddlteam" Font-Size="9pt" runat="server" Width="200px" Skin="Office2010Silver" EmptyMessage="Choose Team"></telerik:RadComboBox>
                </td>
            </tr>

            <tr>
                <td>Planned or Emergency:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator19" ControlToValidate="ddlPlannedEmmergency" Display="Dynamic" ErrorMessage="Please select planned or Emmergency" CssClass="validator" ValidationGroup="SubForm">*</asp:RequiredFieldValidator>
                </td>
                <td>

                    <telerik:RadComboBox RenderMode="Lightweight" ID="ddlPlannedEmmergency" Font-Size="9pt" runat="server" Width="300px" Skin="Office2010Silver" EmptyMessage="Choose Planned or Emmergency"></telerik:RadComboBox>
                </td>
            </tr>

            <tr>
                <td>New or Represented:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator20" ControlToValidate="ddlStatus" Display="Dynamic" ErrorMessage="Please select New or Represented" CssClass="validator" ValidationGroup="SubForm">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <telerik:RadComboBox RenderMode="Lightweight" ID="ddlStatus" Font-Size="9pt" runat="server" Width="300px" Skin="Office2010Silver" EmptyMessage="Choose New or Represented"></telerik:RadComboBox>
                </td>
            </tr>

            <tr>
                <td>Contract/Proc. Vehicle:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator21" ControlToValidate="ddlVehicle" Display="Dynamic" ErrorMessage="Please select Contract/proc. vehicle" CssClass="validator" ValidationGroup="SubForm">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <telerik:RadComboBox RenderMode="Lightweight" ID="ddlVehicle" Font-Size="9pt" runat="server" Width="300px" Skin="Office2010Silver" EmptyMessage="Choose Contract/Proc. Vehicle"></telerik:RadComboBox>
                </td>
            </tr>

            <tr>
                <td>Vendor &amp; CP Focal Point:<asp:RequiredFieldValidator runat="server" ControlToValidate="txtContractNo" ErrorMessage="Contract No and Vendour is required" ForeColor="Red" ID="RequiredFieldValidator18" ValidationGroup="SubForm">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <telerik:RadTextBox RenderMode="Lightweight" ID="txtContractNo" runat="server" Text='<%# Bind("CONTRACTNOVENDOR") %>' Width="250px"></telerik:RadTextBox>
                </td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td><strong>Activity Period:</strong></td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td>From:</td>
                <td>
                    <telerik:RadDatePicker RenderMode="Lightweight" ID="DateFrom" DbSelectedDate='<%# Bind("PERIOD") %>' runat="server" DateInput-Label=""></telerik:RadDatePicker>
                </td>
            </tr>

            <tr>
                <td>To:</td>
                <td>
                    <telerik:RadDatePicker RenderMode="Lightweight" ID="DateTo" CssClass="toDate" DbSelectedDate='<%# Bind("PERIOD") %>' runat="server" DateInput-Label=""></telerik:RadDatePicker>
                </td>
            </tr>

        </table>
        <br />
        <table>
            <tr>
                <td style="width: 180px">Sponsor:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="ddlSponsor" Display="Dynamic" ErrorMessage="Please select sponsor" CssClass="validator" ValidationGroup="SubForm">*</asp:RequiredFieldValidator>
                </td>
                <td colspan="3">
                    <telerik:RadComboBox RenderMode="Lightweight" ID="ddlSponsor" runat="server" Height="200" Width="250" Font-Size="10pt"
                        DropDownWidth="500" EmptyMessage="Select a Sponsor" HighlightTemplatedItems="true"
                        EnableLoadOnDemand="true" Filter="Contains" OnItemsRequested="ddlSponsor_ItemsRequested"
                        Skin="Office2010Silver">

                        <HeaderTemplate>
                            <table style="width: 475px; font-size: 9pt" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="width: 165px;">Sponsor Name</td>
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
            <%--<tr>
                <td>Requestor:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator12" ControlToValidate="ddlRequestor" Display="Dynamic" ErrorMessage="Please select Requestor" CssClass="validator" ValidationGroup="SubForm">*</asp:RequiredFieldValidator>
                </td>
                <td colspan="3">
                    <telerik:RadComboBox RenderMode="Lightweight" ID="ddlRequestor" runat="server" Height="200" Width="250" Font-Size="10pt"
                        DropDownWidth="500" EmptyMessage="Select a Requestor" HighlightTemplatedItems="true"
                        EnableLoadOnDemand="true" Filter="Contains" OnItemsRequested="ddlRequestor_ItemsRequested"
                        Skin="Office2010Silver">

                        <HeaderTemplate>
                            <table style="width: 475px; font-size: 9pt" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="width: 165px;">Requestor Name</td>
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
            </tr>--%>
            <tr>
                <td>Checked By:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator13" ControlToValidate="ddlCheckedBy" Display="Dynamic" ErrorMessage="Please Select Checked by" CssClass="validator" ValidationGroup="SubForm">*</asp:RequiredFieldValidator>
                </td>
                <td colspan="3">
                    <telerik:RadComboBox RenderMode="Lightweight" ID="ddlCheckedBy" runat="server" Height="200" Width="250" Font-Size="10pt"
                        DropDownWidth="500" EmptyMessage="Select Checked by" HighlightTemplatedItems="true"
                        EnableLoadOnDemand="true" Filter="Contains" OnItemsRequested="ddlCheckedBy_ItemsRequested"
                        Skin="Office2010Silver">

                        <HeaderTemplate>
                            <table style="width: 475px; font-size: 9pt" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="width: 165px;">Checked By</td>
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
                <td>Focal Point:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="ddlFocalPoint" Display="Dynamic" ErrorMessage="Please select Focal Point" CssClass="validator" ValidationGroup="SubForm">*</asp:RequiredFieldValidator>
                </td>
                <td colspan="3">
                    <telerik:RadComboBox RenderMode="Lightweight" ID="ddlFocalPoint" runat="server" Height="200" Width="250" Font-Size="10pt"
                        DropDownWidth="500" EmptyMessage="Select a Focal Point" HighlightTemplatedItems="true"
                        EnableLoadOnDemand="true" Filter="Contains" OnItemsRequested="ddlFocalPoint_ItemsRequested"
                        Skin="Office2010Silver">

                        <HeaderTemplate>
                            <table style="width: 475px; font-size: 9pt" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="width: 165px;">Focal Point</td>
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

            <%--<tr>
        <td>Approved By:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator15" ControlToValidate="ddlApprover" Display="Dynamic" ErrorMessage="!" CssClass="validator">
        </asp:RequiredFieldValidator>
        </td>
        <td>
            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlApprover" runat="server" Height="200" Width="250" Font-Size="10pt"
                DropDownWidth="500" EmptyMessage="Select an Approver" HighlightTemplatedItems="true"
                EnableLoadOnDemand="true" Filter="Contains" OnItemsRequested="ddlApprover_ItemsRequested"
                Skin="Office2010Silver">

                <HeaderTemplate>
                    <table style="width: 475px; font-size: 9pt" cellspacing="0" cellpadding="0">
                        <tr>
                            <td style="width: 165px;">Checked By</td>
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
    </tr>--%>

            <tr>
                <td>&nbsp;</td>
                <td colspan="3">&nbsp;</td>
            </tr>

            <tr>
                <td>PR Number:</td>
                <td>
                    <telerik:RadTextBox RenderMode="Lightweight" ID="txtPRNumber" runat="server" Text='<%# Bind("PRNUMBER") %>' Width="250px"></telerik:RadTextBox>
                </td>
                <td>PR Value (F$):<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPRValue" ErrorMessage="PR Value is required" ValidationGroup="SubForm">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <%--<telerik:RadTextBox RenderMode="Lightweight" ID="txtPRValue" runat="server" Text='<%# Bind("PRVALUE") %>' Width="150px" oncopy="return false" onpaste="return false" oncut="return false">
                        <ClientEvents OnKeyPress="preventMoreDecimalPlaces" />
                    </telerik:RadTextBox>--%>

                    <telerik:RadNumericTextBox ID="txtPRValue" runat="server" DbValueFactor="1" Font-Size="12px"
                        NumberFormat-DecimalDigits="2" Type="Number" Width="140px" LabelWidth="" OnTextChanged="txtPRValue_TextChanged">
                        <NegativeStyle Resize="None" />
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
                <td>PO Number:</td>
                <td>
                    <telerik:RadTextBox RenderMode="Lightweight" ID="txtPONumber" runat="server" Text='<%# Bind("PONUMBER") %>' Width="250px"></telerik:RadTextBox>
                </td>
                <td>PO Value (F$):</td>
                <td>
                    <%--<telerik:RadTextBox RenderMode="Lightweight" ID="txtPOValue" runat="server" Text='<%# Bind("POVALUE") %>' Width="150px" oncopy="return false" onpaste="return false" oncut="return false">
                        <ClientEvents OnKeyPress="preventMoreDecimalPlaces" />
                    </telerik:RadTextBox>--%>

                    <telerik:RadNumericTextBox ID="txtPOValue" runat="server" DbValueFactor="1" Font-Size="12px"
                        NumberFormat-DecimalDigits="2" Type="Number" Width="140px" LabelWidth="" OnTextChanged="txtPOValue_TextChanged">
                        <NegativeStyle Resize="None" />
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
                <td>Commitment (F$):</td>
                <td>
                    <%--<telerik:RadTextBox RenderMode="Lightweight" ID="txtCommitment" runat="server" Text='<%# Bind("COMMITMENT") %>' Width="150px" oncopy="return false" onpaste="return false" oncut="return false">
                        <ClientEvents OnKeyPress="preventMoreDecimalPlaces" />
                    </telerik:RadTextBox>--%>

                    <telerik:RadNumericTextBox ID="txtCommitment" runat="server" DbValueFactor="1" Font-Size="12px"
                        NumberFormat-DecimalDigits="2" Type="Number" Width="150px" LabelWidth="" BackColor="#CCCCCC" ReadOnly="True">
                        <NegativeStyle Resize="None" />
                        <EmptyMessageStyle Resize="None" />
                        <ReadOnlyStyle Resize="None" />
                        <FocusedStyle Resize="None" />
                        <DisabledStyle Resize="None" />
                        <InvalidStyle Resize="None" />
                        <HoveredStyle Resize="None" />
                        <EnabledStyle Resize="None" />
                    </telerik:RadNumericTextBox>

                </td>
                <td>PO/PR Var. (%):</td>
                <td>
                    <asp:Label ID="lblPOPRVariance" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                </td>
            </tr>

        </table>
        <br />
        <table>
            <tr>
                <td style="width: 180px">Business Justification:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtJustification" ErrorMessage="Business Justification is required" ValidationGroup="SubForm">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <telerik:RadTextBox RenderMode="Lightweight" ID="txtJustification" runat="server" Text='<%# Bind("JUSTIFICATION") %>' TextMode="MultiLine" Width="500px" Height="100px"></telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>Implication of 
            <br />
                    non approval:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtThreat" ErrorMessage="Regrets/Implacation of non approval is required" ValidationGroup="SubForm">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <telerik:RadTextBox RenderMode="Lightweight" ID="txtThreat" runat="server" Text='<%# Bind("THREAT") %>' TextMode="MultiLine" Width="500px" Height="100px"></telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <div style="float: right">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Width="100px" ValidationGroup="SubForm" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>

<asp:HiddenField ID="CommitmentHF" runat="server" />
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="SubForm" />
