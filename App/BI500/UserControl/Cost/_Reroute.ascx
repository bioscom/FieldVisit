<%@ Control Language="C#" AutoEventWireup="true" CodeFile="_Reroute.ascx.cs" Inherits="App_BI500_UserControl_Cost_Reroute" %>

<%@ Register Src="~/UserControls/userFinder/Search4LocalUser.ascx" TagName="Search4LocalUser" TagPrefix="uc1" %>


<asp:Panel ID="pnlInformation" runat="server">

</asp:Panel>

<asp:Panel ID="pnlShow" runat="server">
    <table class="tMainBorder" style="width: 750px; margin-top: 0.5em; border-collapse: separate">
        <tr>
            <td style="width: 150px">
                <asp:Label ID="Label18" runat="server" Font-Bold="true" Text="Request No:"></asp:Label>
            </td>
            <td style="vertical-align: middle">
                <asp:Label ID="lblRequestNo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label13" runat="server" Font-Bold="true" Text="Project Title:"></asp:Label>
            </td>
            <td style="vertical-align: middle">
                <asp:Label ID="lblProjectTitle" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label19" runat="server" Text="Status:"></asp:Label>
            </td>
            <td style="vertical-align: middle">
                <asp:Label ID="lblStatus" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField runat="server" ID="HFRequestId"></asp:HiddenField>
            </td>
            <td>
                <asp:HiddenField runat="server" ID="HFRequestStatus"></asp:HiddenField>
            </td>
        </tr>
        <tr>
            <td colspan="2">

                <table class="tMainBorder" style="width: 98%">
                    <tr class="cHeadTile">
                        <td>&nbsp;</td>
                        <td>Assigned To</td>
                        <td>Reassign To</td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Function/Department Focal Point:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblFocalPoint" runat="server"></asp:Label>

                            <asp:HiddenField runat="server" ID="HFFocalPointId"></asp:HiddenField>

                        </td>
                        <td>
                            <uc1:Search4LocalUser ID="FocalPoint" runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Font-Bold="true" Text="Initiative Lead:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInitiativeLead" runat="server"></asp:Label>

                            <asp:HiddenField runat="server" ID="HFInitLeadId"></asp:HiddenField>

                        </td>
                        <td>
                            <uc1:Search4LocalUser ID="InitiativeLead" runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="Work Stream Owner:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblWorkStreamOwner" runat="server"></asp:Label>

                            <asp:HiddenField runat="server" ID="HFChampionId"></asp:HiddenField>

                        </td>
                        <td>
                            <uc1:Search4LocalUser ID="champion" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="Work Stream Sponsor:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblWorkStreamSponsor" runat="server"></asp:Label>

                            <asp:HiddenField runat="server" ID="HFSponsorId"></asp:HiddenField>

                        </td>
                        <td>
                            <uc1:Search4LocalUser ID="Sponsor" runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <td>

                            <asp:HiddenField runat="server" ID="HFInitiator"></asp:HiddenField>

                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="RerouteUsers" runat="server" OnClick="Reroute_Click" Text="Reroute" />
                            &nbsp;<asp:Button ID="btnClose" runat="server" Text="Close" ValidationGroup="close" OnClick="btnClose_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>
