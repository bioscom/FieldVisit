<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyRequests.ascx.cs" Inherits="UserControl_SEPCiN_MyRequests" %>

    <table class="tSubGray" style="width:98%">
        <tr>
            <td colspan="2" class="cHeadTile" style="font-weight:bold">
                My PEC Requests</td>
        </tr>
        <tr>
            <td>
                Approved</td>
            <td>
                
                <asp:LinkButton ID="approvedRequestLinkButton" runat="server" 
                    ValidationGroup="tttt" PostBackUrl="~/App/FieldVisit/Forms/PEC/MyApprovedPECRequests.aspx"></asp:LinkButton>
                
            </td>
        </tr>
        <tr>
            <td>
                Deleted</td>
            <td>
                <asp:LinkButton ID="deletedLinkButton" runat="server" ValidationGroup="tttt" PostBackUrl="~/App/FieldVisit/Forms/PEC/MyDeletedPECRequests.aspx"></asp:LinkButton>
            </td>
            
        </tr>
        <tr>
            <td>
                Pending</td>
            <td>
                <asp:LinkButton ID="pendingRequestsLnk" runat="server" 
                    PostBackUrl="~/App/FieldVisit/Forms/PEC/MyPecRequests.aspx" ValidationGroup="tttt"></asp:LinkButton>
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

