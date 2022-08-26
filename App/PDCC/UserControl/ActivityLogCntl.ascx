<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ActivityLogCntl.ascx.cs" Inherits="App_PDCC_UserControl_ActivityLogCntl" %>

<script type="text/javascript" src="../../../FusionCharts/fusioncharts.js"></script>
<script type="text/javascript" src="../../../fusioncharts/themes/fusioncharts.theme.fint.js"></script>

<table class="tMainBorder" style="width: 99%">
    <tr>
        <td class="cHeadTile" colspan="2">
                        <asp:Label ID="lblOpportunityTitle" runat="server"></asp:Label>
                    </td>
    </tr>
    <tr>
        <td style="width: 45%">
            <table class="tMainBorder" style="width: 99%">
                <%--<tr>
                    <td style="width:180px">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Department:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td style="width:180px">
                        <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="Asset:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAssett" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Opportunity:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblOpportunity" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Sponsor:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSponsor" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="Cost Bucket(Asset):"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAsset" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Action Party:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblActionParty" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Accept/Park:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAcceptPark" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Priority:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPriority" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Asset/Support Services:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAserv" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Cost Centre:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCostCentre" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Start by:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblStartBy" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Complete by:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCompleteBy" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp; &nbsp;</td>
                </tr>
                                <tr>
                    <td>
                        <asp:Label ID="lblOpex" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblOpexValue" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Improvement ($mln):"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblImprovement" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="FEC/TO ($mln):"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblFecto" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Pot. Savings ($mln):"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPotSavings" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Act. Savings ($mln):"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblActSavings" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <center>
                <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" Width="100px" />
            </center>
        </td>
        <td>
            <table class="tMainBorder" style="width: 99%">
                <tr>
                    <td colspan="2">
                        <%--<asp:PlaceHolder ID="cReport" runat="server"></asp:PlaceHolder>--%>
                        <asp:Literal ID="FCLiteral" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="Work Scope:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblWorkScope" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label17" runat="server" Font-Bold="True" Text="Comments:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblComments" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    </table>