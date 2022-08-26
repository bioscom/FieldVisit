<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PDCC.master" AutoEventWireup="true" CodeFile="EditPdcc.aspx.cs" Inherits="App_PDCC_EditPdcc" %>

<%@ Register Src="UserControl/Search4LocalUser.ascx" TagName="Search4LocalUser" TagPrefix="uc2" %>
<%@ Register Src="UserControl/statusSelectorControl.ascx" TagName="statusSelectorControl" TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc4" %>


<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <script type="text/javascript" src="JavaScript/fieldVisit.js"></script>
    <table class="tMainBorder" style="width: 550px">
        <tr>
            <td class="cHeadTile" colspan="2">Cost Opportunity</td>
        </tr>
        <tr>
            <td>Asset<asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlAsset" ErrorMessage="Asset is required" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
            </td>
            <td>
                <asp:DropDownList ID="ddlAsset" runat="server" Width="350px">
                    <asp:ListItem Value="-1">--Select Asset--</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Opportunity:</td>
            <td>
                <asp:TextBox ID="txtOpportunity" runat="server" Height="50px" TextMode="MultiLine" Width="350px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Sponsor:</td>
            <td>
                <uc2:Search4LocalUser ID="ddlSponsor" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Action Party:</td>
            <td>
                <uc2:Search4LocalUser ID="ddlActionParty" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Accept/Park:<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlAcceptPark" ErrorMessage="Accept/Park is required" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
            </td>
            <td>
                <asp:DropDownList ID="ddlAcceptPark" runat="server" Width="120px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Priority:<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlPriority" ErrorMessage="Priority is required" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
            </td>
            <td>
                <asp:DropDownList ID="ddlPriority" runat="server" Width="120px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Asset/Support Services:</td>
            <td>
                <uc3:statusSelectorControl ID="ddlAssetSupport" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Start by:</td>
            <td>
                <%--<uc2:search4localuser ID="ddlStartBy" runat="server" />--%>
                <uc4:dateControl ID="dtStarted" runat="server" />
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
        </tr>
        
        <tr>
            <td>Comment:</td>
            <td colspan="3">
                <asp:TextBox ID="txtComment" runat="server" Height="50px" TextMode="MultiLine" Width="450px"></asp:TextBox>
            </td>
        </tr>--%>

        <tr>
            <td>Complete by:</td>
            <td>
                <uc4:dateControl ID="dtCompleted" runat="server" />
            </td>
        </tr>

        <tr>
            <td>Cost Centre:</td>
            <td>
                <asp:TextBox ID="txtCostCentre" runat="server" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Work Scope:</td>
            <td>
                <asp:TextBox ID="txtWorkScope" runat="server" Height="80px" TextMode="MultiLine" Width="350px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td colspan="2"><hr /></td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblOpex" runat="server"></asp:Label>
                &nbsp;(F$mln)<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOpexYear" ErrorMessage="Opex is required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtOpexYear" runat="server" Width="120px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Front End Cost Takeout (F$mln):<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFecto" ErrorMessage="Front End Take Out is required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtFecto" runat="server" Width="120px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Improvement (F$mln):<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtImprovement" ErrorMessage="Improvement is required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtImprovement" runat="server" Width="120px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Bankable Savings (F$mln):</td>
            <td>
                <asp:TextBox ID="txtPotSavings" runat="server" Width="110px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Banked Savings (F$mln):</td>
            <td>
                <asp:TextBox ID="txtActSavings" runat="server" Width="110px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Comment:</td>
            <td>
                <asp:TextBox ID="txtComment" runat="server" Height="80px" TextMode="MultiLine" Width="350px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Width="100px" />
                &nbsp;
                <%--<a id="dpeBackLink" href="javascript:history.back()">--%>
                    <asp:Button ID="btnClose" runat="server" Text="Close" Width="100px" CausesValidation="false" OnClick="btnClose_Click" ValidationGroup="close" />
                <%--</a>--%>
                <%--OnClick="btnClose_Click"--%>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
    </table><br /><br />
</asp:Content>

