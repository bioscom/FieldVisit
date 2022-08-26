<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OthersRequest.ascx.cs" Inherits="UserControl_SEPCiN_OthersRequest" %>

<table class="tSubGray" style="width: 98%">
    <tr>
        <td colspan="2" class="cHeadTile" style="font-weight: bold">PEC Pending my approval</td>
    </tr>
    <tr>
        <td>Approved</td>
        <td>

            <asp:LinkButton ID="approvedRequestLinkButton" runat="server"
                ValidationGroup="rrrr" PostBackUrl="~/App/FieldVisit/Forms/PEC/Approval/Approved.aspx"></asp:LinkButton>

        </td>
    </tr>
    <tr>
        <td>Pending</td>
        <td>
            <asp:LinkButton ID="pendingApprovalLinkButton" runat="server"
                ValidationGroup="rrrr" PostBackUrl="~/App/FieldVisit/Forms/PEC/Approval/Pending.aspx"></asp:LinkButton>
        </td>

    </tr>
    <tr>
        <td>Rejected</td>
        <td>
            <asp:LinkButton ID="rejectedLinkButton" runat="server" ValidationGroup="rrrr"></asp:LinkButton>
        </td>

    </tr>
</table>