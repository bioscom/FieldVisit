<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CompetenceAssessment.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="App_FLBM_Register" %>

<%@ Register src="UserControl/MainHeaderControl.ascx" tagname="MainHeaderControl" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="tMainBorder" style="width:100%">
        <tr>
            <td>
                <uc2:MainHeaderControl ID="MainHeaderControl1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" OnRowCommand="grdView_RowCommand" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>" OnClick="btnEdit_Click"
                                    ASSESSID='<%# DataBinder.Eval(Container.DataItem, "ASSESSID") %>' CommandName="EditThis" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Grouping">
                            <ItemTemplate>
                                <asp:Label ID="lblGrouping" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GROUPS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Competence">
                            <ItemTemplate>
                                <asp:Label ID="lblCompetence" runat="server" Font-Bold="true" Text='<%# DataBinder.Eval(Container.DataItem, "COMPETENCE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Proficiency">
                            <ItemTemplate>
                                <asp:Label ID="lblProficiency" runat="server" Font-Bold="true" Text='<%# DataBinder.Eval(Container.DataItem, "PROFICIENCY") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Date Assessed">
                            <ItemTemplate>
                                <asp:Label ID="lblDateAssessed" runat="server" Font-Bold="true" Text='<%# DataBinder.Eval(Container.DataItem, "DATE_ASSESSED") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Assessee">
                            <ItemTemplate>
                                <asp:Label ID="lblAssessee" runat="server" Font-Bold="true" Text='<%# DataBinder.Eval(Container.DataItem, "ASSESSEENAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Assessor">
                            <ItemTemplate>
                                <asp:Label ID="lblAssessor" runat="server" Font-Bold="true" Text='<%# DataBinder.Eval(Container.DataItem, "ASSESSORNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Font-Bold="true" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                <asp:LinkButton ID="ReportLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>" OnClick="btnReport_Click"
                                    ASSESSID='<%# DataBinder.Eval(Container.DataItem, "ASSESSID") %>' CommandName="Report" Text="Report"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
    </table>
</asp:Content>

