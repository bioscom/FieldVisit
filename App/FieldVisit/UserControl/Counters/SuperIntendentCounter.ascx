<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SuperIntendentCounter.ascx.cs" Inherits="UserControl_Counters_SuperIntendentCounter" %>

    <table class="tSubGray" style="width:98%">
        <tr>
            <td colspan="2" class="cHeadTile" style="font-weight:bold">
                Superintendent Approval</td>
        </tr>
        <tr>
            <td>
                Approved</td>
            <td>
                
                <asp:LinkButton ID="approvedRequestLinkButton" runat="server" 
                    PostBackUrl="~/App/FieldVisit/Forms/FieldVisit/Approvers/SuperintendentApprovedRequests.aspx" ValidationGroup="tttt"></asp:LinkButton>
                
            </td>
        </tr>
        <tr>
            <td>
                Pending</td>
            <td>
                <asp:LinkButton ID="pendingRequestsLnk" runat="server" 
                    PostBackUrl="~/App/FieldVisit/Forms/FieldVisit/Approvers/SuperintendentPendingRequests.aspx" 
                    ValidationGroup="tttt"></asp:LinkButton>
            </td>
            
        </tr>
        <tr>
            <td>
                Rejected</td>
            <td>
                <asp:LinkButton ID="rejectedLinkButton" runat="server" ValidationGroup="tttt"></asp:LinkButton>
            </td>
        </tr>
    </table>

