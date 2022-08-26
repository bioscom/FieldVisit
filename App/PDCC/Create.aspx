<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PDCC.master" AutoEventWireup="true" CodeFile="Create.aspx.cs" Inherits="App_PDCC_Create" %>

<%--<%@ Register Src="UserControl/Search4LocalUser.ascx" TagName="Search4LocalUser" TagPrefix="uc2" %>--%>
<%@ Register Src="UserControl/statusSelectorControl.ascx" TagName="statusSelectorControl" TagPrefix="uc3" %>

<%@ Register Src="../../UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc4" %>

<%@ Register Src="../../UserControls/userFinder/Search4LocalUser.ascx" TagName="Search4LocalUser" TagPrefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="MenuContentContentPlaceHolder" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <script type="text/javascript" src="JavaScript/fieldVisit.js"></script>
    <table class="tMainBorder" style="width: 550px">
        <tr>
            <td class="cHeadTile" colspan="2">Create Cost Opportunity</td>
        </tr>
        <tr>
            <td><strong>Asset</strong><asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlAsset" ErrorMessage="Asset is required" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
            </td>
            <td>
                <asp:DropDownList ID="ddlAsset" runat="server" Width="350px">
                    <asp:ListItem Value="-1">--Select Asset--</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><strong>Opportunity:</strong><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOpportunity" ErrorMessage="Opportunity is required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtOpportunity" runat="server" Height="60px" TextMode="MultiLine" Width="350px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td><strong>Sponsor:</strong></td>
            <td>
                <uc5:Search4LocalUser ID="ddlSponsor" runat="server" />
            </td>
        </tr>

        <tr>
            <td>
                <strong>Action Party:</strong></td>
            <td>
                <uc5:Search4LocalUser ID="ddlActionParty" runat="server" />
            </td>
        </tr>

        <tr>
            <td>
                <strong>Accept/Park:<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlAcceptPark" ErrorMessage="Accept/Park is required" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                </strong>
            </td>
            <td>
                <asp:DropDownList ID="ddlAcceptPark" runat="server" Width="120px">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>
                <strong>Priority:</strong><asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlPriority" ErrorMessage="Priority is required" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
            </td>
            <td>
                <asp:DropDownList ID="ddlPriority" runat="server" Width="120px">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>
                <strong>Asset/Support Services:</strong></td>
            <td>
                <uc3:statusSelectorControl ID="ddlAssetSupport" runat="server" />
            </td>
        </tr>

        <tr>
            <td>
                <strong>Start by:</strong></td>
            <td>
                <uc4:dateControl ID="dtStarted" runat="server" />
            </td>
        </tr>

        <tr>
            <td>
                <strong>Complete by:</strong></td>
            <td>
                <uc4:dateControl ID="dtCompleted" runat="server" />
            </td>
        </tr>

        <%--<tr>
            <td>Pot. Savings(F$mln):</td>
            <td>
                <asp:TextBox ID="txtPotSavings" runat="server" Width="110px"></asp:TextBox>
            </td>
            <td>Act. Savings(F$mln):</td>
            <td>
                <asp:TextBox ID="txtActSavings" runat="server" Width="110px"></asp:TextBox>
            </td>
        </tr>--%>
        <tr>
            <td><strong>Cost Centre:</strong></td>
            <td>
                <asp:TextBox ID="txtCostCentre" runat="server" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><strong>Work Scope:</strong></td>
            <td>
                <asp:TextBox ID="txtWorkScope" runat="server" Height="60px" TextMode="MultiLine" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <%--<tr>
            <td>Comment:</td>
            <td colspan="3">
                <asp:TextBox ID="txtComment" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
            </td>
        </tr>--%>
        <tr>
            <td>
                <asp:Label ID="lblOpex" runat="server" Font-Bold="True"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtOpexYear" ErrorMessage="Opex is required">*</asp:RequiredFieldValidator>
                <strong>(F$mln)</strong></td>
            <td>
                <asp:TextBox ID="txtOpexYear" runat="server" Width="120px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <strong>Front End Cost Takeout (F$mln):</strong><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFecto" ErrorMessage="Front End Take Out is required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtFecto" runat="server" Width="120px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><strong>Improvement (F$mln):</strong><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtImprovement" ErrorMessage="Improvement is required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtImprovement" runat="server" Width="120px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <strong>Potential Savings(F$mln):</strong></td>
            <td>
                <asp:TextBox ID="txtPotSavings" runat="server" Width="120px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>

                <strong>Actual Savings(F$mln)</strong>:</td>
            <td>
                <asp:TextBox ID="txtActSavings" runat="server" Width="120px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><strong>Comment:</strong></td>
            <td>
                <asp:TextBox ID="txtComment" runat="server" Height="60px" TextMode="MultiLine" Width="351px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Width="100px" />
                &nbsp;
                <a id="dpeBackLink" href="javascript:history.back()">
                    <asp:Button ID="btnClose" runat="server" Text="Close" ValidationGroup="close" Width="100px" />
                </a>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
    <br />
</asp:Content>

