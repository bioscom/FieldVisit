<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oRequestDetails.ascx.cs" Inherits="UserControl_oRequestDetails" %>


<table style="width: 100%" class="tMainBorder">
    <tr>
        <td class="cHeadTile" colspan="2">Bright Idea Request Details</td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Request Number:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblRequestNumber" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Date Requested:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblDateInit" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label29" runat="server" Font-Bold="True"
                Text="Category:  "></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblCategory" runat="server" Font-Bold="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label47" runat="server" Font-Bold="True"
                Text="Facility:  "></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblFacility" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Start Date:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblStartDate" runat="server"></asp:Label>
            &nbsp;/
                <asp:Label ID="Label48" runat="server" Font-Bold="True" Text="Start Time:"></asp:Label>
            &nbsp;<asp:Label ID="lblStartTime" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label30" runat="server" Font-Bold="True" Text="End Date:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblEndDate" runat="server" Font-Bold="False"></asp:Label>
            &nbsp;/
                <asp:Label ID="Label49" runat="server" Font-Bold="True" Text="End Time:"></asp:Label>
            &nbsp;<asp:Label ID="lblEndTime" runat="server" Font-Bold="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Initiator:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblInitiator" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label50" runat="server" Font-Bold="True" Text="Project Champion:"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label52" runat="server" Font-Bold="True" Text="Project Focal Point:"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label51" runat="server" Font-Bold="True" Text="Project Sponsor:"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
<table style="width: 100%" class="tMainBorder">
    <tr>
        <td class="cHeadTile">Business Case:</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblReason" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Opportunity Statement:</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblReason0" runat="server"></asp:Label>
        </td>
    </tr>
</table>
