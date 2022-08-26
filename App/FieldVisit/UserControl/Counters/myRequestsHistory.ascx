<%@ Control Language="C#" AutoEventWireup="true" CodeFile="myRequestsHistory.ascx.cs" Inherits="UserControl_Counters_myRequestsHistory" %>
<table class="tSubGray" style="width:98%">
    <tr>
        <td colspan="2" class="cHeadTile" style="font-weight: bold">My Field Visit Requests</td>
    </tr>
    <tr>
        <td>Approved</td>
        <td>

            <asp:LinkButton ID="approvedRequestLinkButton" runat="server"
                PostBackUrl="~/App/FieldVisit/Forms/FieldVisit/RequestOwners/myApprovedFieldVisitRequest.aspx" ValidationGroup="tttt"></asp:LinkButton>

        </td>
    </tr>
    <tr>
        <td>Deleted</td>
        <td>
            <asp:LinkButton ID="deletedLinkButton" runat="server" ValidationGroup="tttt"></asp:LinkButton>
        </td>

    </tr>
    <tr>
        <td>Pending</td>
        <td>
            <asp:LinkButton ID="pendingRequestsLnk" runat="server"
                PostBackUrl="~/App/FieldVisit/Forms/FieldVisit/RequestOwners/myPendingFieldVisitRequest.aspx" ValidationGroup="tttt"></asp:LinkButton>
        </td>

    </tr>
    <tr>
        <td>Rejected</td>
        <td>
            <asp:LinkButton ID="rejectedLinkButton" runat="server" ValidationGroup="tttt"></asp:LinkButton>
        </td>
    </tr>
</table>

