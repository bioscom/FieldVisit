<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFlareWaiver.master" AutoEventWireup="true" CodeFile="Reporter.aspx.cs" Inherits="App_FlareWaiver_Reports_Reporter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="tMainBorder" style="width: 700px">
        <tr>
            <td>
                <asp:DropDownList ID="ddlYear" runat="server">
                    <asp:ListItem Value="-1">Select Year</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>From:</td>
            <td>
                <asp:DropDownList ID="ddlMonthFrom" runat="server">
                    <asp:ListItem Value="-1">Select Start Month</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>To:</td>
            <td>
                <asp:DropDownList ID="ddlMonthTo" runat="server">
                    <asp:ListItem Value="-1">Select End Month</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnRpt" runat="server" OnClick="btnRpt_Click" Text="Report" />
            </td>
        </tr>
    </table>

    <table class="tMainBorder" style="width: 700px">
        <tr class="cHeadTile">
            <td style="width: 350px">Flare Waivers Requested</td>
            <td>Month 1</td>
            <td>Month 2</td>
            <td>Month 3</td>
        </tr>
        <tr>
            <td>Approved by GM Prod.</td>
            <td>
                <asp:Label ID="lbAprdMnt1" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbAprdMnt2" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbAprdMnt3" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Not approved</td>
            <td>
                <asp:Label ID="lbNtAprdMnt1" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbNtAprdMnt2" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbNtAprdMnt3" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Pending line support</td>
            <td>
                <asp:Label ID="lbPndgMnt1" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbPndgMnt2" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbPndgMnt3" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Total</td>
            <td>
                <asp:Label ID="lbTotal1" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbTotal2" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbTotal3" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Volumes(Mmscf) approved for Flare</td>
            <td>
                <asp:Label ID="lbVolAppr1" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbVolAppr2" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbVolAppr3" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Flared Volume ( Mmscf/d)annualised</td>
            <td>
                <asp:Label ID="lbVolAnalzd1" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbVolAnalzd2" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbVolAnalzd3" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

