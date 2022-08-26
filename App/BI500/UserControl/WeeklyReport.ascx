<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WeeklyReport.ascx.cs" Inherits="App_BI500_UserControl_WeeklyReport" %>

<%@ Register src="GraphicalReports.ascx" tagname="GraphicalReports" tagprefix="uc2" %>

<table class="tMainBorder" style="width: 98%">
    <tr>
        <td class="cHeadTile">Bright Ideas Weekly Report
        </td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="ddlYear" runat="server" Width="150px">
                <asp:ListItem Value="-1">Select Year...</asp:ListItem>
            </asp:DropDownList>
            &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlYear" ErrorMessage="Please select Year" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
            <b>
                <asp:DropDownList ID="ddlFunction" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlFunction_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Select Business Unit..</asp:ListItem>
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlFunction" ErrorMessage="Please select Business Unit" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                <asp:ListItem Value="-1">Select Department</asp:ListItem>
            </asp:DropDownList>
            &nbsp; <asp:DropDownList ID="ddlTeam" runat="server" Width="250px">
                <asp:ListItem Value="-1">Select Team</asp:ListItem>
            </asp:DropDownList>
            </b>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <b>
                Weekly Report:</b><asp:Repeater ID="WeeklyRepeater" runat="server" OnItemCommand="WeeklyRepeater_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkWeek" runat="server" NOID='<%# DataBinder.Eval(Container.DataItem, "NOID") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "NOID") %>' />&nbsp;                                        
                </ItemTemplate>
            </asp:Repeater>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblMessage" runat="server" CssClass="Warning" Font-Size="Large"></asp:Label>
            <asp:HiddenField ID="HF" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="grdView" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="grdView_PageIndexChanging"
                OnRowCommand="grdView_RowCommand" OnSelectedIndexChanged="grdView_SelectedIndexChanged" PageSize="8" Width="100%">
                <Columns>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--<asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:LinkButton ID="ActionLinkButton" runat="server" Text="Action Request" CommandName="Action" CommandArgument="<%# Container.DisplayIndex %>"
                    STATUS='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'
                    IDREQUEST='<%# DataBinder.Eval(Container.DataItem, "IDREQUEST") %>' ToolTip="Approve/Support Bright Idea">
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>--%>

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
                            <asp:Label ID="labelInitiator" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
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

                    <asp:TemplateField HeaderText="Team Focal Point" SortExpression="FOCALPOINTFULLNAME">
                        <ItemTemplate>
                            <asp:Label ID="lblFocalPoint" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FOCALPOINTFULLNAME") %>'></asp:Label>
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

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="ViewStatusLinkButton" runat="server"
                                CommandArgument="<%# Container.DisplayIndex %>"
                                CommandName="ViewStatus"
                                STATUS='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'
                                IDREQUEST='<%# DataBinder.Eval(Container.DataItem, "IDREQUEST") %>'>View Comments</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--<asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:LinkButton ID="EditLinkButton" runat="server"
                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="EditThisRequest"
                    IDREQUEST='<%# DataBinder.Eval(Container.DataItem, "IDREQUEST") %>'>Edit Request</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>--%>

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
        </td>
    </tr>

</table>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
<hr />
<hr />
<uc2:GraphicalReports ID="GraphicalReports1" runat="server" />

