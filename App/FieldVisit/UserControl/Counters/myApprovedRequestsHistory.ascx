<%@ Control Language="C#" AutoEventWireup="true" CodeFile="myApprovedRequestsHistory.ascx.cs" Inherits="UserControl_Counters_myApprovedRequestsHistory" %>
<%--<%@ Register src="approvedFieldVisitRequests.ascx" tagname="approvedFieldVisitRequests" tagprefix="uc2" %>--%>
<table class="tSubGray" style="width: 98%">
    <tr>
        <td colspan="2" class="cHeadTile" style="font-weight: bold">Field Visit Request</td>
    </tr>
    <tr>
        <td colspan="2" class="cHeadTile" style="font-weight: bold">Pending my approval</td>
    </tr>
    <tr>
        <td>Approved</td>
        <td>

            <asp:LinkButton ID="approvedRequestLinkButton" runat="server"
                PostBackUrl="~/App/FieldVisit/Forms/FieldVisit/Approvers/oApprovedFieldVisitRequest.aspx" ValidationGroup="rrrr"></asp:LinkButton>

        </td>
    </tr>
    <tr>
        <td>Pending</td>
        <td>
            <asp:LinkButton ID="pendingApprovalLinkButton" runat="server"
                PostBackUrl="~/App/FieldVisit/Forms/FieldVisit/Approvers/oPendingFieldVisitRequest.aspx" ValidationGroup="rrrr"></asp:LinkButton>
        </td>

    </tr>
    <tr>
        <td>Rejected</td>
        <td>
            <asp:LinkButton ID="rejectedLinkButton" runat="server" ValidationGroup="rrrr" PostBackUrl="~/App/FieldVisit/Forms/FieldVisit/Approvers/oRejectedFieldVisitRequest.aspx"></asp:LinkButton>
        </td>

    </tr>
</table>

