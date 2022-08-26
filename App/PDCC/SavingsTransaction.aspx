<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/configuration.master" AutoEventWireup="true" CodeFile="SavingsTransaction.aspx.cs" Inherits="App_PDCC_SavingsTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightColumn" Runat="Server">
    <table class="tMainBorder">
        <tr>
            <td colspan="2" class="cHeadTile">Select Year Savings Transactions</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Select Year:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlYear" runat="server">
                    <asp:ListItem Value="-1">Select Year...</asp:ListItem>
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
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </td>
        </tr>
        </table>
</asp:Content>

