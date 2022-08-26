<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oRequestDetails.ascx.cs" Inherits="UserControl_Cost_oRequestDetails" %>

<%@ Register Src="../../../../UserControls/dateControl.ascx" TagName="datecontrol" TagPrefix="uc3" %>

<%@ Register Src="oStatusControl.ascx" TagName="ostatuscontrol" TagPrefix="uc3" %>

<table style="width: 100%">
    <tr>
        <td>
            <table style="width: 99%" class="tMainBorder">
                <tr>
                    <td class="cHeadTile" colspan="2">Improvement Idea</td>
                </tr>
                <tr>
                    <td style="width: 50%; border-right: solid 1px silver">
                        <table class="tMainBorder" style="width: 99%">
                            <tr>
                                <td style="width: 180px">
                                    <asp:Label ID="Label29" runat="server" Font-Bold="True"
                                        Text="Expected Benefit:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblImpactArea" runat="server" Font-Bold="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 180px">
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Request Number:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRequestNumber" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label30" runat="server" Font-Bold="True" Text="Title:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label43" runat="server" Font-Bold="True" Text="Business Case:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblBuzCase" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label44" runat="server" Font-Bold="True" Text="Opportunity Statement:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblOpportunityStmt" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Date Submitted:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDateInit" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label45" runat="server" Font-Bold="True" Text="Target Savings ($):"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTargetSavings" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label46" runat="server" Font-Bold="True" Text="Actual Savings ($):"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblActualSavings" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table class="tMainBorder">
                                        <tr>
                                            <td class="cHeadTile" colspan="2">Business Area</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label36" runat="server" Font-Bold="True" Text="Function:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBusinessArea" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label41" runat="server" Font-Bold="True" Text="Department:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label42" runat="server" Font-Bold="True" Text="Team:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTeam" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 50%">
                        <table class="tMainBorder" style="width: 99%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Initiator:"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblInitiator" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label33" runat="server" Font-Bold="True" Text="Project Focal Point:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFocalPoint" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="btnFP" runat="server" OnClick="btnFP_Click" Text="Reminder" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label47" runat="server" Font-Bold="True" Text="Initiative Lead:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblInitiativeLead" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="btnIL" runat="server" OnClick="btnIL_Click" Text="Reminder" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label31" runat="server" Font-Bold="True" Text="Work Stream Owner:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblProjectChampion" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="btnWSO" runat="server" OnClick="btnWSO_Click" Text="Reminder" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label32" runat="server" Font-Bold="True" Text="Work Stream Sponsor:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblProjectSponsor" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="btnWSS" runat="server" OnClick="btnWSS_Click" Text="Reminder" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label34" runat="server" Font-Bold="True" Text="Status:"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblStatus" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table class="tMainBorder" style="width: 99%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label35" runat="server" Font-Bold="True" Text="Project Phase Status:"></asp:Label>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkPhase" runat="server" Font-Bold="True"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label37" runat="server" Font-Bold="True" Text="Improvement Benefit Realised:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblImprovementBenefit" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label38" runat="server" Font-Bold="True" Text="Quantity Benefit:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblQtyBenefit" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label39" runat="server" Font-Bold="True" Text="Replication Potential in SCIN:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblReplicationPotential" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label40" runat="server" Font-Bold="True" Text="Actual Project Finish Date:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFinishedDate" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 99%" class="tMainBorder">
                            <tr>
                                <td class="cHeadTile">Raised on behalf of:</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFullName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEmailAddress" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 99%" class="tMainBorder">
                            <tr>
                                <td class="cHeadTile">Project Team Members</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblTeamMembers" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table style="width: 99%" class="tMainBorder">
                <tr>
                    <td class="cHeadTile">Comments</td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="..." SortExpression="FULLNAME">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApprover" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Role">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRole" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IDROLE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStand" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STAND") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date Received" SortExpression="DATE_RECEIVED">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDateReceived" runat="server" Text='<%# Bind("DATE_RECEIVED", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date Reviewed" SortExpression="DATE_REVIEWED">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDateReviewed" runat="server" Text='<%# Bind("DATE_REVIEWED", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Comments">
                                    <ItemTemplate>
                                        <asp:Label ID="lblComments" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMMENTS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="cHeadTile">
                        <div>
                            <div style="float: left">
                                Bi-weekly Cadence Commitments
                            </div>
                            <div style="float: right">
                                <asp:ImageButton ID="exportExcel" runat="server" ImageUrl="~/Images/excel.png" ToolTip="Download Bi-weekly Cadence Commitments" Height="30px" Width="30px" OnClick="exportExcel_Click" />
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdViewCadence" runat="server" AutoGenerateColumns="False" DataKeyNames="CADENCEID" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Width="10px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAction" runat="server" Text='<%# Eval("ACTION") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action Party" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblActionParty" runat="server" Text='<%# Eval("ACTIONPARTY") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="200px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Threat" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblThreat" runat="server" Text='<%# Eval("THREAT") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date Due" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="labelEndDate0" runat="server" Text='<%# Bind("DUEDATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="130px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="labelStatus" runat="server" Text='<%# Bind("STATUS") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="130px" />
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>

                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>


<asp:HiddenField ID="RequestIdHF" runat="server" />

