<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PartsOpportunities.ascx.cs" Inherits="App_PDCC_UserControl_PartsOpportunities" %>

<table class="tSubGray" style="width: 70%">
    <tr>
        <td class="cHeadTile">Three Parts Opportunities</td>
    </tr>
    <tr>
        <td>&nbsp;<asp:DropDownList ID="ddlYear" runat="server" ValidationGroup="Filter" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Value="-1">Select Year...</asp:ListItem>
        </asp:DropDownList>

            &nbsp;<asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export to Excel" Height="27px" Width="170px" ValidationGroup="PPO" />

            <asp:Label ID="lblPercSavings" runat="server"></asp:Label>

        </td>
    </tr>
    <tr>
        <td>
            <hr />
            <asp:Literal ID="ViewLiteral" runat="server"></asp:Literal>
        </td>
    </tr>
</table>
