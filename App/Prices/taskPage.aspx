<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PriceTracker.master" AutoEventWireup="true" CodeFile="taskPage.aspx.cs" Inherits="App_Prices_taskPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <center>
    <table class="tSubGray" style="width:600px; margin-top:4.5em">
        <tr>
            <td class="cHeadTileLeft">
                <asp:Label ID="lblHeader" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="cTextCenta">
                <br />
                <br />
                <img src="../../Images/i_keyLock.gif" width="108" />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="cTextCenta">
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
                <br />
                <asp:HyperLink ID="hpkLogin" runat="server" NavigateUrl="~/App/Prices/taskPage.aspx">Close</asp:HyperLink>
            </td>
        </tr>
    </table>
    </center>

</asp:Content>
