<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oRequestDetails.ascx.cs" Inherits="UserControl_Specific_oRequestDetails" %>

<%--<table style="width: 99%">
    <tr>
        <td>--%>
            <table style="width: 99%" class="tMainBorder">
                <tr>
                    <td class="cHeadTile" colspan="4">Flare Waiver Request Details</td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Request Number:"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:Label ID="lblRequestNumber" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label50" runat="server" Font-Bold="True" Text="Flare (or AG) Volume:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblFlareAgVolume" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label51" runat="server" Font-Bold="True" Text="Associated Oil Production:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAssOilProd" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Date Requested:"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:Label ID="lblDateInit" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label29" runat="server" Font-Bold="True"
                            Text="Category:  "></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:Label ID="lblCategory" runat="server" Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label47" runat="server" Font-Bold="True"
                            Text="Facilities:  "></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:Label ID="lblFacility" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Start Date:"></asp:Label>
                    </td>
                    <td colspan="3">
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
                    <td colspan="3">
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
                    <td colspan="3">
                        <asp:Label ID="lblInitiator" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <table style="width: 99%" class="tMainBorder">
                <thead>
                    <tr class="cHeadTile">
                        <th colspan="2">Gas Flare YTD Actual Vs Annual Flare Limit</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            Total Gas Flared YTD:</td>
                        <td>
                            <asp:Label ID="lblTotalFlared" runat="server"></asp:Label>
                        &nbsp;mscfd</td>
                    </tr>
                    <tr>
                        <td>
                            Annual Gas Flare Limit:</td>
                        <td>
                            <asp:Label ID="lblAnnualFlareLimit" runat="server"></asp:Label>
                        &nbsp;mscfd</td>
                    </tr>
                    <tr>
                        <td>
                            Average Actual Flared YTD :</td>
                        <td>
                            <asp:Label ID="lblYTDActual" runat="server"></asp:Label>
                        &nbsp;mscfd</td>
                    </tr>
                </tbody>
            </table>
            <table style="width: 99%" class="tMainBorder">
                <tr>
                    <td class="cHeadTile">Reason for flaring</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblReason" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <table style="width: 99%" class="tMainBorder">
                <tr>
                    <td class="cHeadTile">Justification for Waiver Request</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblJustification" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <table style="width: 99%" class="tMainBorder">
                <tr>
                    <td class="cHeadTile">Post event action to remain compliant</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPostEvent" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
<%-- </td>
    </tr>
</table>--%>
