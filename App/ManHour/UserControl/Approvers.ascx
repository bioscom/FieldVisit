<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Approvers.ascx.cs" Inherits="UserControl_Approvers" %>
<%@ Register Src="~/UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc3" %>

<%@ Register src="../../../UserControls/userFinder/Search4LocalUser.ascx" tagname="Search4LocalUser" tagprefix="uc2" %>

<table class="tSubGray">
    <tr class="cHeadTile">
        <td colspan="2">Activity Sponsors</td>
    </tr>
    <tr>
        <td>Activity Sponsor:<%--<asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="drpSponsor" ErrorMessage="Select Asset Planner" Operator="NotEqual" Type="Integer" ValidationGroup="approver" ValueToCompare="-1">*</asp:CompareValidator>--%>
        </td>
        <td>
            <%--<asp:DropDownList ID="drpSponsor" runat="server" Width="300px">
                <asp:ListItem Value="-1">--Select Activity Sponsor--</asp:ListItem>
            </asp:DropDownList>--%>
            <uc2:Search4LocalUser ID="ddlSponsor" runat="server" />
        </td>
    </tr>
</table>

<table class="tSubGray">
    <tr class="cHeadTile">
        <td>
            Asset/Operation Managers</td>
    </tr>
    <tr>
        <td>
            <asp:CheckBoxList ID="assetMgrCkbLst" runat="server" RepeatColumns="6"></asp:CheckBoxList>
        </td>
    </tr>
</table>

<table class="tSubGray">
    <tr class="cHeadTile">
        <td>
            Functional Leads</td>
    </tr>
    <tr>
        <td>
            <asp:CheckBoxList ID="funcMgrCkbLst" runat="server" RepeatColumns="6"></asp:CheckBoxList>
        </td>
    </tr>
</table>
<asp:Button ID="forwardButton" runat="server" Text="Forward" OnClick="forwardButton_Click" ValidationGroup="approver" />

<asp:HiddenField ID="lInitiativeHF" runat="server" />
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="approver" />
