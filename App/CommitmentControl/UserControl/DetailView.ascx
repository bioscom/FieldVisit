<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DetailView.ascx.cs" Inherits="App_BONGACCP_UserControl_DetailView" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="~/App/CommitmentControl/UserControl/activityDescription.ascx" TagPrefix="uc5" TagName="activityDescription" %>
<%@ Register Src="~/App/CommitmentControl/UserControl/oDocsUpload.ascx" TagPrefix="uc5" TagName="oDocsUpload" %>


<%@ Register Src="oDocsUploaded.ascx" TagName="oDocsUploaded" TagPrefix="uc2" %>


<style>
    #parent {
        height: 200px;
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
</style>

<div style="font-size: 85%">
    <table style="width: 100%; border: 1px solid silver">
        <tr>
            <td style="width: 150px">
                <asp:CheckBox ID="ckbCompare" Text="Compare" runat="server" AutoPostBack="True" OnCheckedChanged="ckbCompare_CheckedChanged"></asp:CheckBox>
            </td>
            <td colspan="3">

                <div style="float: left">
                    <telerik:RadComboBox RenderMode="Lightweight" ID="ddlCommitment" runat="server" Height="200" Width="600px" Font-Size="10pt"
                        DropDownWidth="600" EmptyMessage="Search for Commitment by Activity description..." AutoPostBack="true"
                        EnableLoadOnDemand="true" Filter="Contains" OnItemsRequested="ddlCommitment_ItemsRequested"
                        Skin="Office2010Silver" OnSelectedIndexChanged="ddlCommitment_SelectedIndexChanged">

                        <HeaderTemplate>
                            <table style="width: 600px; font-size: 9pt" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="width: 350px;">Title</td>
                                    <td style="width: 150px;">Commitment No.</td>
                                    <td style="width: 100px;">Date Submitted</td>
                                </tr>
                            </table>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <table style="width: 600px; font-size: 9pt" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="width: 350px;"><%# DataBinder.Eval(Container, "Text")%></td>
                                    <td style="width: 150px;"><%# DataBinder.Eval(Container, "Attributes['COMITMNTNO']")%></td>
                                    <td style="width: 100px;"><%# DataBinder.Eval(Container, "Attributes['DATE_SUBMITTED']")%></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </telerik:RadComboBox>

                    <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Excel_XLSX.png" OnClick="ImageButton_Click" AlternateText="Html" ToolTip="Export to Excel" />--%>
                </div>





            </td>
        </tr>
        <tr>
            <td colspan="4">
                <hr />
            </td>
        </tr>
        <tr>
            <td><strong>Title:</strong></td>
            <td colspan="3">
                <asp:Label ID="lblTitle" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><strong>Cost Object:</strong></td>
            <td colspan="3">
                <asp:Label ID="lblCostObject" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><strong>Purchasing Group:</strong></td>
            <td colspan="3">
                <asp:Label ID="lblGroup" runat="server"></asp:Label>
            </td>
        </tr>
        <%--<tr>
        <td style="width:150px">&nbsp;</td>
        <td colspan="3">
            &nbsp;</td>
    </tr>--%>
        <tr>
            <td><strong>Team:</strong></td>
            <td colspan="3">
                <asp:Label ID="lblTeam" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <hr />
            </td>
        </tr>
        <tr>
            <td><strong>Sponsor:</strong></td>
            <td colspan="3">
                <asp:Label ID="lblSponsor" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><strong>Qty/Duration 
                <br />
                Checked By?:</strong></td>
            <td colspan="3">
                <asp:Label ID="lblCheckedBy" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><strong>Focal Point:</strong></td>
            <td colspan="3">
                <asp:Label ID="lblFocalPoint" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><strong>Approver:</strong></td>
            <td colspan="3">
                <asp:Label ID="lblApprover" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><strong>Initiator/Requestor:</strong></td>
            <td colspan="3">
                <asp:Label ID="lblInitiator" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <hr />
            </td>
        </tr>
        <tr>
            <td><strong>Planned or Emergency:</strong></td>
            <td colspan="3">
                <asp:Label ID="lblPlannedEmmergency" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><strong>New or Represented:</strong></td>
            <td colspan="3">
                <asp:Label ID="lblNewRepresented" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><strong>Activity Period:</strong></td>
            <td colspan="3">
                <strong>From:</strong>
                <asp:Label ID="lblPeriodFrom" runat="server"></asp:Label>
                &nbsp; <strong>To:</strong>
                <asp:Label ID="lblPeriodTo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><strong>Contract/Procurement 
                <br />
                Vehicle:</strong></td>
            <td colspan="3">
                <asp:Label ID="lblVehicle" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><strong>Contract No. &amp; Vendor:</strong></td>
            <td colspan="3">
                <asp:Label ID="lblContractNo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <div id="parent">
                    <div id="child">
                        <table style="width: 100%; border: 1px solid silver">
                            <tr>
                                <td style="width: 150px"><strong>Business Justification:</strong></td>
                                <td colspan="3">
                                    <asp:Label ID="lblBuzJustification" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;&nbsp;&nbsp; &nbsp;</td>
                                <td colspan="3">&nbsp;&nbsp;&nbsp; &nbsp;</td>
                            </tr>
                            <tr>
                                <td><strong>Regrets/Implication 
                            <br />
                                    of non approval:</strong></td>
                                <td colspan="3">
                                    <asp:Label ID="lblThreat" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>

        <tr>
            <td colspan="4">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table style="width: 500px">
                    <tr>
                        <td><strong>PR Number:</strong></td>
                        <td>
                            <asp:Label ID="lblPRNo" runat="server"></asp:Label>
                        </td>
                        <td><strong>PR Value (F$):</strong></td>
                        <td>
                            <asp:Label ID="lblPRValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>PO Number:</strong></td>
                        <td>
                            <asp:Label ID="lblPONo" runat="server"></asp:Label>
                        </td>
                        <td><strong>PO Value (F$):</strong></td>
                        <td>
                            <asp:Label ID="lblPOValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>Commitment (F$):</strong></td>
                        <td>
                            <asp:Label ID="lblCommitment" runat="server"></asp:Label>
                        </td>
                        <td><strong>Savings:</strong></td>
                        <td>
                            <asp:Label ID="lblSavings" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>PO/PR Variance (%):</strong></td>
                        <td colspan="3">
                            <asp:Label ID="lblPOPRVariance" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <tr>
                <td colspan="4">
                    <hr />
                </td>
            </tr>
        <tr>
            <td colspan="4" style="border: 1px solid silver">
                <fieldset style="width: 99%; margin-top: 0.2em">
                    <legend>
                        <b style="color: green">Cost Breakdown</b>
                    </legend>
                    <div id="parent">
                        <div id="child">
                            <uc5:activityDescription runat="server" ID="activityDescription1" />
                        </div>
                    </div>
                </fieldset>
            </td>
        </tr>

        <tr>
            <td colspan="4">
                <fieldset style="width: 99%; margin-top: 0.2em">
                    <legend>
                        <b style="color: green">Uploaded Documents</b>
                    </legend>
                    <div id="parent">
                        <div id="child">
                            <uc2:oDocsUploaded ID="oDocsUploaded1" runat="server" />
                        </div>
                    </div>
                </fieldset>
            </td>
        </tr>

        <tr>
            <td colspan="4" style="border: 1px solid silver">
                <fieldset style="width: 99%; margin-top: 0.2em">
                    <legend>
                        <b style="color: green">Approval Decision</b>
                    </legend>
                    <table>
                        <tr>
                            <td>Approved By:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator15" ControlToValidate="ddlApprover" Display="Dynamic" ErrorMessage="Please, select approver" CssClass="validator" ValidationGroup="dtl">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <telerik:RadComboBox RenderMode="Lightweight" ID="ddlApprover" runat="server" Height="200" Width="300px" Font-Size="10pt"
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
                        </tr>
                        <tr>
                            <td>Decision:<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlApprovalDecision" ErrorMessage="Select Approval decision" Operator="NotEqual" Type="Integer" ValueToCompare="-1" ValidationGroup="dtl">*</asp:CompareValidator>
                            </td>
                            <td colspan="3">
                                <asp:DropDownList ID="ddlApprovalDecision" runat="server" Width="300px">
                                    <asp:ListItem Value="-1">Select Approval Decision...</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Decision Comment:</td>
                            <td colspan="3">
                                <asp:TextBox ID="txtDecisionComments" runat="server" Width="400px" Height="70px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Savings:</td>
                            <td colspan="3">
                                <telerik:RadNumericTextBox ID="txtSavings" runat="server" DbValueFactor="1" Font-Size="12px"
                                    NumberFormat-DecimalDigits="2" Type="Number" Width="140px" LabelWidth="">
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
                            <td>&nbsp;</td>
                            <td colspan="3">
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" ValidationGroup="dtl" Width="100px" />
                                <asp:HiddenField ID="CommitmentHF" runat="server" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>

    </table>
</div>

<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="dtl" />
