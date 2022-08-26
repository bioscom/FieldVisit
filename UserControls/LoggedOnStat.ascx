<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoggedOnStat.ascx.cs" Inherits="UserControls_LoggedOnStat" %>

<table style="width: 100%">
    <tr>
        <td><strong>Usage Stats:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</strong></td>
        <td>Currently logged on:</td>
        <td>&nbsp;&nbsp;
            <asp:Label ID="lblOnline" runat="server"></asp:Label>
        </td>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Logged on Today:</td>
        <td>&nbsp;&nbsp;
            <asp:Label ID="lblVisitedToday" runat="server"></asp:Label>
        </td>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Current Number of Users:</td>
        <td>&nbsp;&nbsp;
            <asp:Label ID="lblVisited" runat="server"></asp:Label>
        </td>
    </tr>
</table>