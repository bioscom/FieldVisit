<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/LeanMasterPage.master" AutoEventWireup="true" CodeFile="LeanProjects.aspx.cs" Inherits="App_Lean_Projects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table class="tMainBorder" style="width: 99%">
        <tr>
            <td class="cHeadTile">Project Charters</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Select Year...</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:DropDownList runat="server" Width="250px" ID="ddlFunction" AutoPostBack="True" OnSelectedIndexChanged="ddlFunction_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Select Function...</asp:ListItem>
                </asp:DropDownList>

                &nbsp;<asp:Button ID="btnClose" runat="server" Text="Close" Width="100px" Height="22px" OnClick="btnClose_Click" />

            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdGridView" runat="server" AllowPaging="True"
                    AutoGenerateColumns="False" OnLoad="grdGridView_Load"
                    OnPageIndexChanging="grdGridView_PageIndexChanging"
                    OnRowCommand="grdGridView_RowCommand"
                    OnSelectedIndexChanged="grdGridView_SelectedIndexChanged" PageSize="40"
                    Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditLinkButton" runat="server" CommandName="EditProject" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>'>Update Charter</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="ViewLinkButton" runat="server" CommandName="ViewProject" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>'>View Charter</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--<asp:TemplateField HeaderText="Project Code" SortExpression="PROJECTCODE">
                            <ItemTemplate>
                                <asp:Label ID="labelCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PROJECTCODE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Project Name" SortExpression="TITLE">
                            <ItemTemplate>
                                <asp:LinkButton ID="ProjectLinkButton" runat="server" ForeColor="#003366" Font-Bold="true" Text='<%# DataBinder.Eval(Container.DataItem, "TITLE") %>'
                                    CommandName="Project" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>' ToolTip="Click on project to drill down">
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="250px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Year" SortExpression="YYEAR">
                            <ItemTemplate>
                                <asp:Label ID="labelYear" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "YYEAR") %>'></asp:Label>
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

                        <asp:TemplateField HeaderText="Project Type" SortExpression="PROJTYPE">
                            <ItemTemplate>
                                <asp:Label ID="labelType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PROJTYPE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="IESLinkButton" runat="server" CommandName="IES" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>'>Identify / Eliminate / Sustain</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="VsmLinkButton" runat="server" CommandName="VSM" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>'>Value Stream_Data</asp:LinkButton>
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

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="AssessmentLinkButton" runat="server" CommandName="Assessment" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>'>Assessment</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="deleteLinkButton" runat="server" CommandName="DeleteThis" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>'>Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>

            </td>
        </tr>
    </table>

</asp:Content>

