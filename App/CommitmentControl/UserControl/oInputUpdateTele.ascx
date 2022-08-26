<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oInputUpdateTele.ascx.cs" Inherits="App_BONGACCP_UserControl_oInputUpdateTele" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="~/App/CommitmentControl/UserControl/InputUpdateCommitmentDetails.ascx" TagName="InputUpdateCommitmentDetails" TagPrefix="uc4" %>
<%--<%@ Register Src="~/App/CommitmentControl/UserControl/InputUpdateCommitmentDetailsUpdt.ascx" TagName="InputUpdateCommitmentDetailsUpdt" TagPrefix="uc5" %>--%>


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


<div style="font-size: 11pt">

    <%--<table style="width: 98%">
        <tr>
            <td style="vertical-align: top" colspan="2">
                <h2>Commitment Control Form</h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top" colspan="2">
                <hr />
            </td>
        </tr>
    </table>--%>

    <table style="border: 1px solid silver; width: 98%">
        <tr>
            <td style="vertical-align: top">
                <table>
                    <tr class="EditFormHeader">
                        <td style="width: 250px">Organisation Unit:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="ddlOU"
                                Display="Dynamic" ErrorMessage="Select Organisation Unit" CssClass="validator" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlOU" Font-Size="9pt" runat="server" Width="200px" EmptyMessage="Choose OU" Skin="Office2010Silver">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr class="EditFormHeader">
                        <td>Team:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="ddlteam"
                                Display="Dynamic" ErrorMessage="Select Team" CssClass="validator" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlteam" Font-Size="9pt" runat="server" Width="200px" EmptyMessage="Choose Team" Skin="Office2010Silver">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr class="EditFormHeader">
                        <td>Asset:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator38" ControlToValidate="ddlAsset"
                            Display="Dynamic" ErrorMessage="Select Asset" CssClass="validator" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                            </td>
                        <td>
                            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlAsset" Font-Size="9pt" runat="server" Width="200px" EmptyMessage="Choose Asset" Skin="Office2010Silver">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr class="EditFormHeader">
                        <td>Facility:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator39" ControlToValidate="ddlFacility"
                            Display="Dynamic" ErrorMessage="Select Facility" CssClass="validator" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                            </td>
                        <td>
                            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlFacility" Font-Size="9pt" runat="server" Width="200px" EmptyMessage="Choose Facility" Skin="Office2010Silver">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr class="EditFormHeader">
                        <td>Team Indicator:<asp:RequiredFieldValidator runat="server" ControlToValidate="txtTeamIndicator" ErrorMessage="Team Indicator is required" ForeColor="Red" ID="RequiredFieldValidator24" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <telerik:RadTextBox RenderMode="Lightweight" ID="txtTeamIndicator" runat="server" Text='<%# Bind("CONTRACTNOVENDOR") %>' Width="200px"></telerik:RadTextBox>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr class="EditFormHeader">
                        <td style="width: 250px">Cost Object/WBS:<asp:RequiredFieldValidator runat="server" ControlToValidate="txtCostObject" ErrorMessage="Cost Object is required" ForeColor="Red" ID="RequiredFieldValidator17" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>
                        <td>

                            <telerik:RadTextBox RenderMode="Lightweight" ID="txtCostObject" runat="server" Text='<%# Bind("COSTOBJECT") %>' Width="300px"></telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr class="EditFormHeader">
                        <td>Cost Object Desc.:<asp:RequiredFieldValidator runat="server" ControlToValidate="txtCostObjDesc" ErrorMessage="Cost Object Descrption is required" ForeColor="Red" ID="RequiredFieldValidator25" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>
                        <td>

                            <telerik:RadTextBox RenderMode="Lightweight" ID="txtCostObjDesc" runat="server" Text='<%# Bind("TITLE") %>' Width="300px" Height="60px" TextMode="MultiLine"></telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr class="EditFormHeader">
                        <td>Capex/Opex:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator31" ControlToValidate="ddlCapexOpex"
                            Display="Dynamic" ErrorMessage="Select Capex or Opex" CssClass="validator" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlCapexOpex" Font-Size="9pt" runat="server" Width="200px" EmptyMessage="Choose Capex or Opex" Skin="Office2010Silver">
                            </telerik:RadComboBox>
                        </td>
                    </tr>

                </table>
                <table>
                    <tr class="EditFormHeader">
                        <td style="width: 250px">PR Number:</td>
                        <td>

                            <telerik:RadTextBox RenderMode="Lightweight" ID="txtPRNumber" runat="server" Text='<%# Bind("PRNUMBER") %>' Width="150px"></telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr class="EditFormHeader">
                        <td>PR Value (F$&#39;000):</td>
                        <td>

                            <%--<telerik:RadTextBox RenderMode="Lightweight" ID="txtPRValue" runat="server" Text='<%# Bind("PRVALUE") %>' Width="150px">
                                <ClientEvents OnKeyPress="preventMoreDecimalPlaces" />
                            </telerik:RadTextBox>--%>

                            <telerik:RadNumericTextBox ID="txtPRValue" runat="server" DbValueFactor="1" Font-Size="12px"
                                NumberFormat-DecimalDigits="2" Type="Number" Width="150px" LabelWidth="">
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
                    <tr class="EditFormHeader">
                        <td>PO Number:</td>
                        <td>
                            <telerik:RadTextBox RenderMode="Lightweight" ID="txtPONumber" runat="server" Text='<%# Bind("PONUMBER") %>' Width="150px"></telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr class="EditFormHeader">
                        <td>PO Value (F$&#39;000):</td>
                        <td>

                            <%--<telerik:RadTextBox RenderMode="Lightweight" ID="txtPOValue" runat="server" Text='<%# Bind("POVALUE") %>' Width="150px">
                                <ClientEvents OnKeyPress="preventMoreDecimalPlaces" />
                            </telerik:RadTextBox>--%>

                            <telerik:RadNumericTextBox ID="txtPOValue" runat="server" DbValueFactor="1" Font-Size="12px"
                                NumberFormat-DecimalDigits="2" Type="Number" Width="150px" LabelWidth="">
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
                    <tr class="EditFormHeader">
                        <td>PO/PR Variance (%):</td>
                        <td>
                            <asp:Label ID="lblPOPRVariance" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr class="EditFormHeader">
                        <td>Agreement No:</td>
                        <td>

                            <telerik:RadTextBox RenderMode="Lightweight" ID="txtAgreementNo" runat="server" Text='<%# Bind("COSTOBJECT") %>' Width="150px"></telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr class="EditFormHeader">
                        <td>Actual + Commitment YTD (F$&#39;000):<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCommitment" ErrorMessage="Actual + Commitment YTD is required" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>
                        <td>

                            <%--<telerik:RadTextBox RenderMode="Lightweight" ID="txtCommitment" runat="server" Text='<%# Bind("COMMITMENT") %>' Width="150px">
                                <ClientEvents OnKeyPress="preventMoreDecimalPlaces" />
                            </telerik:RadTextBox>--%>

                            <telerik:RadNumericTextBox ID="txtCommitment" runat="server" DbValueFactor="1" Font-Size="12px"
                                NumberFormat-DecimalDigits="2" Type="Number" Width="150px" LabelWidth="">
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
                </table>
                <table>
                    <tr>
                        <td>Detailed Description of Activity:<%# DataBinder.Eval(Container, "Text")%><asp:RequiredFieldValidator runat="server" ControlToValidate="txtTitle" ErrorMessage="Detailed Description of Activity is required" ForeColor="Red" ID="RequiredFieldValidator16" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadTextBox RenderMode="Lightweight" ID="txtTitle" runat="server" Text='<%# Bind("TITLE") %>' Width="500px" Height="60px" TextMode="MultiLine"></telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Business Justification:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtJustification" ErrorMessage="Business Justification is required" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadTextBox RenderMode="Lightweight" ID="txtJustification" runat="server" Text='<%# Bind("JUSTIFICATION") %>' TextMode="MultiLine" Width="500px" Height="65px"></telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Implication of non approval:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtThreat" ErrorMessage="Regrets/Implication of non approval is required" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadTextBox RenderMode="Lightweight" ID="txtThreat" runat="server" Text='<%# Bind("THREAT") %>' TextMode="MultiLine" Width="500px" Height="65px"></telerik:RadTextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="vertical-align: top">
                <table>
                    <tr>
                        <td style="width: 250px">Contact/Vendor No:<asp:RequiredFieldValidator runat="server" ControlToValidate="txtContractNo" ErrorMessage="Contract No and Vendour is required" ForeColor="Red" ID="RequiredFieldValidator18" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>

                        <td>
                            <telerik:RadTextBox RenderMode="Lightweight" ID="txtContractNo" runat="server" Text='<%# Bind("CONTRACTNOVENDOR") %>' Width="300px"></telerik:RadTextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>Purchasing Group:<%--<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlPurchaseGroup" ErrorMessage="Select Purchase Group" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>--%><asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator40" ControlToValidate="ddlPurchaseGroup"
                            Display="Dynamic" ErrorMessage="Select Purchasing Group" CssClass="validator" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                            </td>
                        <td>
                            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlPurchaseGroup" Font-Size="9pt" runat="server" Width="300px" Skin="Office2010Silver" EmptyMessage="Choose Purchasing Group">
                            </telerik:RadComboBox>
                        </td>
                    </tr>

                    <tr>
                        <td>Planned or Emergency:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator35" ControlToValidate="ddlPlannedEmmergency"
                            Display="Dynamic" ErrorMessage="Select Planned or Emmergency" CssClass="validator" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlPlannedEmmergency" Font-Size="9pt" runat="server" Width="300px" Skin="Office2010Silver" EmptyMessage="Choose Planned or Emmergency">
                            </telerik:RadComboBox>
                        </td>
                    </tr>

                    <tr>
                        <td>New or Represented:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator36" ControlToValidate="ddlStatus"
                            Display="Dynamic" ErrorMessage="Select New Or Represented" CssClass="validator" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlStatus" Font-Size="9pt" runat="server" Width="300px" Skin="Office2010Silver" EmptyMessage="Choose New or Represented">
                            </telerik:RadComboBox>
                        </td>
                    </tr>

                    <tr>
                        <td>Contract/Proc. Vehicle:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator37" ControlToValidate="ddlVehicle"
                            Display="Dynamic" ErrorMessage="Select Contract/Proc. Vehicle" CssClass="validator" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlVehicle" Font-Size="9pt" runat="server" Width="300px" Skin="Office2010Silver" EmptyMessage="Choose Contract/Proc. Vehicle">
                            </telerik:RadComboBox>
                        </td>
                    </tr>

                    <tr>
                        <td>Activity Period:</td>
                        <td>
                            &nbsp;</td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="DateFrom" ErrorMessage="Activity Period [Date From] is required" ForeColor="Red" ID="RequiredFieldValidator26" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                            <telerik:RadDatePicker RenderMode="Lightweight" ID="DateFrom" Width="400px" DbSelectedDate='<%# Bind("PERIOD") %>' runat="server" DateInput-LabelWidth="150px" DateInput-Label="From:" Culture="en-US">
                                <Calendar UseRowHeadersAsSelectors="False" runat="server" UseColumnHeadersAsSelectors="False" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" RenderMode="Lightweight"></Calendar>
                                <DateInput DisplayDateFormat="dd-MMM-yyyy" runat="server" DateFormat="M/d/yyyy" LabelWidth="100px" RenderMode="Lightweight">
                                    <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                                    <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                                    <FocusedStyle Resize="None"></FocusedStyle>
                                    <DisabledStyle Resize="None"></DisabledStyle>
                                    <InvalidStyle Resize="None"></InvalidStyle>
                                    <HoveredStyle Resize="None"></HoveredStyle>
                                    <EnabledStyle Resize="None"></EnabledStyle>
                                </DateInput>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                            <br />
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="DateTo" ErrorMessage="Activity Period [Date To] is required" ForeColor="Red" ID="RequiredFieldValidator27" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                            <telerik:RadDatePicker RenderMode="Lightweight" ID="DateTo" Width="400px" CssClass="toDate" DbSelectedDate='<%# Bind("PERIOD") %>' runat="server" DateInput-LabelWidth="150px" DateInput-Label="To:" Culture="en-US">
                                <Calendar UseRowHeadersAsSelectors="False" runat="server" UseColumnHeadersAsSelectors="False" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" RenderMode="Lightweight"></Calendar>
                                <DateInput DisplayDateFormat="dd-MMM-yyyy" runat="server" DateFormat="M/d/yyyy" LabelWidth="100px" RenderMode="Lightweight">
                                    <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                                    <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                                    <FocusedStyle Resize="None"></FocusedStyle>
                                    <DisabledStyle Resize="None"></DisabledStyle>
                                    <InvalidStyle Resize="None"></InvalidStyle>
                                    <HoveredStyle Resize="None"></HoveredStyle>
                                    <EnabledStyle Resize="None"></EnabledStyle>
                                </DateInput>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        &nbsp;
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="DatePrevious" ErrorMessage="Date Previous Submission is required" ForeColor="Red" ID="RequiredFieldValidator28" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                            <telerik:RadDatePicker RenderMode="Lightweight" ID="DatePrevious" Width="400px" CssClass="toDate" DbSelectedDate='<%# Bind("PERIOD") %>' runat="server" DateInput-Label="Date of Previous Submission:" Culture="en-US">
                                <Calendar UseRowHeadersAsSelectors="False" runat="server" UseColumnHeadersAsSelectors="False" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" RenderMode="Lightweight"></Calendar>

                                <DateInput DisplayDateFormat="dd-MMM-yyyy" runat="server" DateFormat="M/d/yyyy" LabelWidth="" RenderMode="Lightweight">
                                    <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                                    <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                                    <FocusedStyle Resize="None"></FocusedStyle>
                                    <DisabledStyle Resize="None"></DisabledStyle>
                                    <InvalidStyle Resize="None"></InvalidStyle>
                                    <HoveredStyle Resize="None"></HoveredStyle>
                                    <EnabledStyle Resize="None"></EnabledStyle>
                                </DateInput>
                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                    </tr>

                </table>
                <br />
                <table>
                    <tr>
                        <td style="width: 250px">Approved Budget SN&#39;000<asp:RequiredFieldValidator runat="server" ControlToValidate="txtNappimsNaira" ErrorMessage="Approved Budget Naira Value is required" ForeColor="Red" ID="RequiredFieldValidator2" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>

                        <td>
                            <telerik:RadNumericTextBox ID="txtNappimsNaira" runat="server" DbValueFactor="1" Font-Size="12px"
                                NumberFormat-DecimalDigits="2" Type="Number" Width="150px" LabelWidth="">
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
                        <td>Approved Budget S$&#39;000<asp:RequiredFieldValidator runat="server" ControlToValidate="txtNappimsDollar" ErrorMessage="Approved Budget Dollar Value is required" ForeColor="Red" ID="RequiredFieldValidator19" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>

                        <td>
                            <telerik:RadNumericTextBox ID="txtNappimsDollar" runat="server" DbValueFactor="1" Font-Size="12px"
                                NumberFormat-DecimalDigits="2" Type="Number" Width="150px" LabelWidth="">
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
                        <td>Approved Budget F$&#39;000<asp:RequiredFieldValidator runat="server" ControlToValidate="txtContractNo" ErrorMessage="Approved Budget Functional Dollar Value is required" ForeColor="Red" ID="RequiredFieldValidator20" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>

                        <td>
                            <telerik:RadNumericTextBox ID="txtNappimsFuncDollar" runat="server" DbValueFactor="1" Font-Size="12px"
                                NumberFormat-DecimalDigits="2" Type="Number" Width="150px" LabelWidth="">
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
                </table>
                <br />
                <table>
                    <tr>
                        <td style="width: 250px">Week&#39;s Commitment Request SN&#39;000<asp:RequiredFieldValidator runat="server" ControlToValidate="txtContractNo" ErrorMessage="Week's Commitment Naira Value is required" ForeColor="Red" ID="RequiredFieldValidator21" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>

                        <td>
                            <telerik:RadNumericTextBox ID="txtRequestNaira" runat="server" DbValueFactor="1" Font-Size="12px"
                                NumberFormat-DecimalDigits="2" Type="Number" Width="150px" LabelWidth="">
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
                        <td>Week&#39;s Commitment Request S$&#39;000<asp:RequiredFieldValidator runat="server" ControlToValidate="txtContractNo" ErrorMessage="Week's Commitment Dollar Value is required" ForeColor="Red" ID="RequiredFieldValidator29" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>

                        <td>
                            <telerik:RadNumericTextBox ID="txtRequestDollar" runat="server" DbValueFactor="1" Font-Size="12px"
                                NumberFormat-DecimalDigits="2" Type="Number" Width="150px" LabelWidth="">
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
                        <td>Week&#39;s Commitment Request F$&#39;000<asp:RequiredFieldValidator runat="server" ControlToValidate="txtContractNo" ErrorMessage="Week's Commitment Functional Dollar Value is required" ForeColor="Red" ID="RequiredFieldValidator30" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>

                        <td>
                            <telerik:RadNumericTextBox ID="txtRequestFuncDollar" runat="server" DbValueFactor="1" Font-Size="12px"
                                NumberFormat-DecimalDigits="2" Type="Number" Width="150px" LabelWidth="">
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
                </table>
                <br />
                <table style="border: solid 1px silver">
                    <tr>
                        <td colspan="2" style="background-color: #C0C0C0">Approval Work Flow</td>
                    </tr>
                    <tr>
                        <td style="width: 250px">Sponsor:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="ddlSponsor" Display="Dynamic" ErrorMessage="Select Sponsor" CssClass="validator" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlSponsor" runat="server" Height="200" Width="250" Font-Size="10pt"
                                DropDownWidth="500" EmptyMessage="Choose Sponsor" HighlightTemplatedItems="true"
                                EnableLoadOnDemand="true" Filter="Contains" OnItemsRequested="ddlSponsor_ItemsRequested"
                                Skin="Office2010Silver">

                                <HeaderTemplate>
                                    <table style="width: 475px; font-size: 9pt">
                                        <tr>
                                            <td style="width: 165px;">Sponsor Name</td>
                                            <td style="width: 220px;">Email Address</td>
                                            <td style="width: 90px;">Ref. Ind.</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>

                                <ItemTemplate>
                                    <table style="width: 475px; font-size: 9pt">
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
                        <td>Checked By (Finance Advisor):<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator13" ControlToValidate="ddlCheckedBy" Display="Dynamic" ErrorMessage="Select Finance Advisor (FA)" CssClass="validator" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlCheckedBy" runat="server" Height="200" Width="250" Font-Size="10pt"
                                DropDownWidth="500" EmptyMessage="Choose Checked by" HighlightTemplatedItems="true"
                                EnableLoadOnDemand="true" Filter="Contains" OnItemsRequested="ddlCheckedBy_ItemsRequested"
                                Skin="Office2010Silver">

                                <HeaderTemplate>
                                    <table style="width: 475px; font-size: 9pt">
                                        <tr>
                                            <td style="width: 165px;">Checked By</td>
                                            <td style="width: 220px;">Email Address</td>
                                            <td style="width: 90px;">Ref. Ind.</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>

                                <ItemTemplate>
                                    <table style="width: 475px; font-size: 9pt">
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

                    </table>
                <br />
                <table>
                    <tr>
                        <td style="width: 250px; background-color: #C0C0C0;">Material Hot Desk Support Secured?:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator32" ControlToValidate="ddlHotDeskSupport" Display="Dynamic" ErrorMessage="Select Material Hot Desk" CssClass="validator" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="background-color: #C0C0C0;">
                            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlHotDeskSupport" Font-Size="9pt" runat="server" Width="150px" Skin="Office2010Silver" EmptyMessage="Choose Material Hot Desk"></telerik:RadComboBox>
                        </td>
                    </tr>

                    </table>
            </td>
        </tr>
    </table>
    <table style="width: 98%">
        <tr>
            <td>
                <div style="float: right">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="100px" ValidationGroup="MainForm" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <uc4:InputUpdateCommitmentDetails ID="InputUpdateCommitmentDetails1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <div style="float: right">
                    <asp:Button ID="btnSubmit" runat="server" Text="Send for Approval" OnClick="btnSubmit_Click" Width="120px" />
                    &nbsp;
                    <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" Width="100px" ValidationGroup="Close" />
                </div>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="MainForm" />
    <table style="width: 98%">

        <tr>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:HiddenField ID="CommitmentHF" runat="server" />
            </td>
        </tr>
    </table>
    <br /><br /><br />
</div>