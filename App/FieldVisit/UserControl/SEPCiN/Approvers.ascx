<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Approvers.ascx.cs" Inherits="UserControl_SEPCiN_Approvers" %>
<%@ Reference VirtualPath="~/App/FieldVisit/UserControl/SEPCiN/activityHeader.ascx" %>
<%@ Register Src="~/App/FieldVisit/UserControl/dateControl.ascx" TagName="dateControl" TagPrefix="uc3" %>

<table style="width: 98%">
    <tr>
        <td style="width: 160px;">Functional Lead:<asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="drpFunctionalLead" ErrorMessage="Select Functional Lead" Operator="NotEqual" Type="Integer" ValidationGroup="approver" ValueToCompare="-1">*</asp:CompareValidator>
        </td>
        <td>
            <asp:DropDownList ID="drpFunctionalLead" runat="server" Width="300px">
                <asp:ListItem Value="-1">--Select Functional Lead--</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Asset Planner:<asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="drpPlanner" ErrorMessage="Select Asset Planner" Operator="NotEqual" Type="Integer" ValidationGroup="approver" ValueToCompare="-1">*</asp:CompareValidator>
        </td>
        <td>
            <asp:DropDownList ID="drpPlanner" runat="server" Width="300px">
                <asp:ListItem Value="-1">--Select Planner--</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Asset/Operations Manager:<asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="drpAssetManager" ErrorMessage="Select Asset Manager" Operator="NotEqual" Type="Integer" ValidationGroup="approver" ValueToCompare="-1">*</asp:CompareValidator>
                    &nbsp;</td>
        <td>
            <asp:DropDownList ID="drpAssetManager" runat="server" Width="300px">
                <asp:ListItem Value="-1">--Select Asset Manager--</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="forwardButton" runat="server" Text="Forward" OnClick="forwardButton_Click" ValidationGroup="approver" />
        </td>
    </tr>
</table>

                <asp:HiddenField ID="ActivityIDHF" runat="server" />
        

<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="approver" />
