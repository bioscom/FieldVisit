<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oMyApprovedRequests.ascx.cs" Inherits="App_BI500_UserControl_oApprovedRequests" %>

<asp:GridView ID="grdGridView" runat="server" AllowPaging="True"
    AutoGenerateColumns="False" OnLoad="grdGridView_Load"
    OnPageIndexChanging="grdGridView_PageIndexChanging"
    OnRowCommand="grdGridView_RowCommand"
    OnSelectedIndexChanged="grdGridView_SelectedIndexChanged" PageSize="20"
    Width="100%">
    <Columns>

        <asp:TemplateField>
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Request No" SortExpression="REQUESTNO">
            <ItemTemplate>
                <asp:Label ID="labelWaiverNumber" runat="server"
                    Text='<%# DataBinder.Eval(Container.DataItem, "REQUESTNO") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Date Request" SortExpression="DATE_SUBMITTED">
            <ItemTemplate>
                <asp:Label ID="lblDateRequest" runat="server" Text='<%# Bind("DATE_SUBMITTED", "{0:dd/MM/yyyy}") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Title" SortExpression="TITLE">
            <ItemTemplate>
                <asp:Label ID="labelTitle" runat="server" ForeColor="#003366"
                    Text='<%# DataBinder.Eval(Container.DataItem, "TITLE") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="250px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Business Unit" SortExpression="FUNCTION">
            <ItemTemplate>
                <asp:Label ID="labelFunction" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FUNCTION") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Department" SortExpression="DEPARTMENT">
            <ItemTemplate>
                <asp:Label ID="labelDepartment" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DEPARTMENT") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Team" SortExpression="TEAM">
            <ItemTemplate>
                <asp:Label ID="labelTeam" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TEAM") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Initiator" SortExpression="FULLNAME">
            <ItemTemplate>
                <asp:Label ID="labelInitiator" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'
                    USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Project Champion" SortExpression="CHAMPIONFULLNAME">
            <ItemTemplate>
                <asp:Label ID="labelChampion" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CHAMPIONFULLNAME") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Project Sponsor" SortExpression="SPONSORFULLNAME">
            <ItemTemplate>
                <asp:Label ID="lblSponsor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SPONSORFULLNAME") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Impacted Area" SortExpression="BENEFIT">
            <ItemTemplate>
                <asp:Label ID="lblAssOilProd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BENEFIT") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Plan Completion Date" SortExpression="DATE_COMPLETION">
            <ItemTemplate>
                <asp:Label ID="labelCompletionDate" runat="server" Text='<%# Bind("DATE_COMPLETION", "{0:dd/MM/yyyy}") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Status">
            <ItemTemplate>
                <asp:Label ID="labelStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Project Phase">
            <ItemTemplate>
                <asp:LinkButton ID="PhaseLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                    CommandName="Phasing" Font-Bold="True" Text='<%# DataBinder.Eval(Container.DataItem, "PHASE") %>'
                    IDREQUEST='<%# DataBinder.Eval(Container.DataItem, "IDREQUEST") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:LinkButton ID="ViewStatusLinkButton" runat="server"
                    CommandArgument="<%# Container.DisplayIndex %>"
                    CommandName="ViewStatus"
                    STATUS='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'
                    IDREQUEST='<%# DataBinder.Eval(Container.DataItem, "IDREQUEST") %>'>View Comments</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:LinkButton ID="ReportLinkButton" runat="server"
                    CommandArgument="<%# Container.DisplayIndex %>"
                    CommandName="Report"
                    IDREQUEST='<%# DataBinder.Eval(Container.DataItem, "IDREQUEST") %>'>View Report</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="handover" />
