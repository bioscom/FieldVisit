<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oSavingsBreakDown.ascx.cs" Inherits="App_BONGACCP_UserControl_oSavingsBreakDown" %>

<table style="font-size:9pt;" border=0>
    <tr>
        <td><b>No of Commitments:</b></td>
        <td>
            <asp:Label ID="lblNoCommitment" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td><b>No Pending:</b></td>
        <td>
            <asp:Label ID="lblPending" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td><b>No Approved:</b></td>
        <td>
            <asp:Label ID="lblApproved" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td><b>Commitments:</b></td>
        <td>
            <asp:Label ID="lblCommitments" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td><b>Savings:</b></td>
        <td>
            <asp:Label ID="lblSavings" runat="server" Text=""></asp:Label>
        </td>
    </tr>
</table>
