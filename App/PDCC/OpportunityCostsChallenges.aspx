<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PDCC.master" AutoEventWireup="true" CodeFile="OpportunityCostsChallenges.aspx.cs" Inherits="App_PDCC_OpportunityCostsChallenges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="MenuContentContentPlaceHolder" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <table class="tMainBorder" style="width: 140%">
        <tr>
            <td class="cHeadTile">PD Cost Challenges</td>
        </tr>
        <tr>
            <td>
                <div>
                    <div style="float: left">
                        <%--<asp:DropDownList ID="ddlDept" runat="server" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="-1">--Select Department--</asp:ListItem>
                        </asp:DropDownList>--%>
                        <asp:DropDownList ID="ddlAsset" OnSelectedIndexChanged="ddlAsset_SelectedIndexChanged" AutoPostBack="True" runat="server">
                            <asp:ListItem Value="-1">--Select Asset--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlAsset" ErrorMessage="Please select Department" Operator="NotEqual" Type="Integer" ValidationGroup="List" ValueToCompare="-1">*</asp:CompareValidator>
                        &nbsp;<%--<asp:DropDownList ID="ddlMonth" runat="server">
                        <asp:ListItem Value="-1">[Select Month]</asp:ListItem>
                    </asp:DropDownList>
                        &nbsp;<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlMonth" ErrorMessage="Please Select Month" Operator="NotEqual" Type="Integer" ValidationGroup="List" ValueToCompare="-1">*</asp:CompareValidator>--%>
&nbsp;<%--<asp:Button ID="btnList" runat="server" Text="List" OnClick="btnList_Click" Width="100px" ValidationGroup="List" />--%>
                        <%--<asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add New PD Cost Opportunity" Width="240px" />--%>
                        &nbsp;
                    </div>
                    <div style="float: right; margin-right: 0.3em">
                        <%--<asp:Button ID="btnExport" runat="server" Text="Export Report to Excel" OnClick="btnExport_Click" />
                        <asp:Label ID="lblMonth" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Red"></asp:Label>--%>
                    </div>

                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdGridView" runat="server" AllowPaging="True"
                    AutoGenerateColumns="False" OnLoad="grdGridView_Load"
                    OnPageIndexChanging="grdGridView_PageIndexChanging"
                    OnRowCommand="grdGridView_RowCommand"
                    OnSelectedIndexChanged="grdGridView_SelectedIndexChanged" PageSize="40"
                    Width="99%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditLinkButton" runat="server" CommandName="UpdateOpportunity" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDOPCOST='<%# DataBinder.Eval(Container.DataItem, "IDOPCOST") %>'>Update</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--<asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                <asp:LinkButton ID="UpdateLinkButton" runat="server" CommandName="UpdatePerformance" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDOPCOST='<%# DataBinder.Eval(Container.DataItem, "IDOPCOST") %>'>Update Performance</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <%--<asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                <asp:LinkButton ID="ViewLinkButton" runat="server" CommandName="ViewDetails" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDOPCOST='<%# DataBinder.Eval(Container.DataItem, "IDOPCOST") %>'>View Details</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="ID No">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SERIALNO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--<asp:TemplateField HeaderText="Asset">
                            <ItemTemplate>
                                <asp:Label ID="lblDepartment" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ASSET") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Opportunities">
                            <ItemTemplate>
                                <asp:LinkButton ID="ViewLinkButton" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OPPORTUNITY") %>' CommandName="ViewDetails" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDOPCOST='<%# DataBinder.Eval(Container.DataItem, "IDOPCOST") %>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="250px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Sponsor">
                            <ItemTemplate>
                                <asp:Label ID="lblSponsor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SPONSORNAME") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action Party">
                            <ItemTemplate>
                                <asp:Label ID="lblActionParty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIONPARTYNAME") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                        </asp:TemplateField>

                        <%--<asp:TemplateField HeaderText="Cost Bucket">
                            <ItemTemplate>
                                <asp:Label ID="lblCostBucket" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ASSET") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Cost Object">
                            <ItemTemplate>
                                <asp:Label ID="lblCostObject" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COSTCENTRE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Accept/Park">
                            <ItemTemplate>
                                <asp:Label ID="lblAcceptPark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACCEPTPARK") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Priority">
                            <ItemTemplate>
                                <asp:Label ID="lblPriority" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PRIORITY") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Asset/Support Services">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetSupport" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ASSERV") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="OPEX (F$mln)">
                            <ItemTemplate>
                                <div style="text-align: right">
                                    <asp:Label ID="lblOpex" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OPEX") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="FECT/O (F$mln)">
                            <ItemTemplate>
                                <div style="text-align: right">
                                    <asp:Label ID="lblFecto" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FECTO") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Improvement (F$mln)">
                            <ItemTemplate>
                                <div style="text-align: right">
                                    <asp:Label ID="lblImprovement" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IMPROVEMENT") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Potential Saving (F$mln)">
                            <ItemTemplate>
                                <div style="text-align: right">
                                    <asp:Label ID="lblPotSavings" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "POTSAVINGS") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Actual Saving (F$mln)">
                            <ItemTemplate>
                                <div style="text-align: right">
                                    <asp:Label ID="lblActualSaving" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTSAVINGS") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Start By">
                            <ItemTemplate>
                                <asp:Label ID="lblStartedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STARTEDBY") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Complete By">
                            <ItemTemplate>
                                <asp:Label ID="lblCompletedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMPLETEDBY") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Focal Point">
                            <ItemTemplate>
                                <asp:Label ID="lblFocalPoint" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FOCALPOINTNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--<asp:TemplateField HeaderText="Work Scope">
                            <ItemTemplate>
                                <asp:Label ID="lblWorkScope" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WORKSCOPE") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="300px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Comments">
                            <ItemTemplate>
                                <asp:Label ID="lblComments" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMMENTS") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="300px" />
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="List" />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

