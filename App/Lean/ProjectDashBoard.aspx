<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/LeanMasterPage.master" AutoEventWireup="true" CodeFile="ProjectDashBoard.aspx.cs" Inherits="App_Lean_ProjectDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table class="tMainBorder" style="width: 99%">
        <tr>
            <td class="cHeadTile">Projects</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Select Year...</asp:ListItem>
                </asp:DropDownList>

                &nbsp;<asp:DropDownList runat="server" Width="250px" ID="ddlFunction" AutoPostBack="True" OnSelectedIndexChanged="ddlFunction_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Select Function...</asp:ListItem>
                </asp:DropDownList>

                &nbsp;<asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Close" Width="100px" Height="22px" />

            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdGridView" runat="server" AllowPaging="True"
                    AutoGenerateColumns="False" OnLoad="grdGridView_Load"
                    OnPageIndexChanging="grdGridView_PageIndexChanging"
                    OnRowCommand="grdGridView_RowCommand"
                    OnSelectedIndexChanged="grdGridView_SelectedIndexChanged" PageSize="40" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="ViewLinkButton" runat="server" CommandName="ViewProject" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>'>View Charter</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Project Name" SortExpression="TITLE">
                            <ItemTemplate>
                                <asp:LinkButton ID="ProjectLinkButton" runat="server" Font-Bold="true" Text='<%# DataBinder.Eval(Container.DataItem, "TITLE") %>'
                                    CommandName="Project" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>' ToolTip="Click on project to drill down">
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="350px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Year" SortExpression="YYEAR">
                            <ItemTemplate>
                                <asp:Label ID="labelYear" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "YYEAR") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Planned End Date" SortExpression="YYEAR">
                            <ItemTemplate>
                                <asp:Label ID="labelPlannedEndDate" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "YYEAR") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Project Sponsor" SortExpression="FULLNAME">
                            <ItemTemplate>
                                <asp:Label ID="lblSponsor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Project Manager" SortExpression="MANAGERFULLNAME">
                            <ItemTemplate>
                                <asp:Label ID="labelManager" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MANAGERFULLNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Champion" SortExpression="CHAMPIONFULLNAME">
                            <ItemTemplate>
                                <asp:Label ID="labelChampion" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CHAMPIONFULLNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Lean Coach/Facilitator">
                            <ItemTemplate>
                                <asp:Label ID="labelCoach" runat="server" Text=''></asp:Label>
                                <%--<asp:Label ID="labelCoach" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COACHFULLNAME") %>'></asp:Label>--%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Department" SortExpression="DEPARTMENT">
                            <ItemTemplate>
                                <asp:Label ID="lblDepartment" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DEPARTMENT") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Function" SortExpression="FUNCTION">
                            <ItemTemplate>
                                <asp:Label ID="labelFunction" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FUNCTION") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Project Type" SortExpression="PROJTYPE">
                            <ItemTemplate>
                                <asp:Label ID="labelType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PROJTYPE") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                        </asp:TemplateField>

                        <%--//, , SPONSOR_APPROVE_REC_V, IMPLEMENT_V, KICK_OFF_MEET_V, --%>

                        <%--<asp:TemplateField HeaderText="Signoff Charters" ShowHeader="False">
                    <ItemTemplate>
                        <asp:TextBox ID="txtSignOff" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SIGNOFF_CHARTER_V") %>' ReadOnly="true" BorderStyle="None" Width="20px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="SIPOV / VOC" ShowHeader="False">
                    <ItemTemplate>
                        <asp:TextBox ID="txtSIPOC" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SPONSOR_APPROVE_REC_V") %>' ReadOnly="true" BorderStyle="None" Width="20px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Process Walk" ShowHeader="False">
                    <ItemTemplate>
                        <asp:TextBox ID="txtProcessWalk" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PROCESS_WALK_V") %>' ReadOnly="true" BorderStyle="None" Width="20px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="VSM & Validation" ShowHeader="False">
                    <ItemTemplate>
                        <asp:TextBox ID="txtVSMValid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VSM_V") %>' ReadOnly="true" BorderStyle="None" Width="20px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Kaizen" ShowHeader="False">
                    <ItemTemplate>
                        <asp:TextBox ID="txtKaizen" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HOLD_KAIZEN_EVENT_V") %>' ReadOnly="true" BorderStyle="None" Width="20px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="DRB Tollgate" ShowHeader="False">
                    <ItemTemplate>
                        <asp:TextBox ID="txtDRB" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IMPLEMENT_V") %>' ReadOnly="true" BorderStyle="None" Width="20px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Pilot Impltn / JDIs /QW" ShowHeader="False">
                    <ItemTemplate>
                        <asp:TextBox ID="txtPilot" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PIP_V") %>' ReadOnly="true" BorderStyle="None" Width="20px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="SOPs" ShowHeader="False">
                    <ItemTemplate>
                        <asp:TextBox ID="txtSOPs" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SOPS_V") %>' ReadOnly="true" BorderStyle="None" Width="20px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Visual Measures" ShowHeader="False">
                    <ItemTemplate>
                        <asp:TextBox ID="txtVisMeasures" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VISUAL_MEASURES_V") %>' ReadOnly="true" BorderStyle="None" Width="20px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Handover" ShowHeader="False">
                    <ItemTemplate>
                        <asp:TextBox ID="txtHandover" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HANDOVER_V") %>' ReadOnly="true" BorderStyle="None" Width="20px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>--%>

                        <%--<asp:TemplateField HeaderText="Comments" ShowHeader="False">
                    <ItemTemplate>
                        <asp:Label ID="lblComments" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMMENTS") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="IESLinkButton" runat="server" CommandName="IES" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>'>Work Done</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="VsmLinkButton" runat="server" CommandName="VSM" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>'>Value Stream Data</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="RecommendationsLinkButton" runat="server" CommandName="Recommendations" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>'>Improvement Recommendations</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="BenefitLinkButton" runat="server" CommandName="Benefit" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>' ValidationGroup="Recommendation">Actual Benefit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="DocsLinkButton" runat="server" CommandName="LoadDocs" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>'>Documents</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

