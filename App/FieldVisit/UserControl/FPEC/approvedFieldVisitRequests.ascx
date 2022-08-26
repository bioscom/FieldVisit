<%@ Control Language="C#" AutoEventWireup="true" CodeFile="approvedFieldVisitRequests.ascx.cs" Inherits="UserControl_approvedFieldVisitRequests" %>

<table class="tSubGray">
    <tr>
        <td class="cHeadTile">My Approved Field Visit Requests</td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                OnPageIndexChanging="grdView_PageIndexChanging" OnRowCommand="grdView_RowCommand" Width="100%">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Activity ID">
                        <ItemTemplate>
                            <asp:Label ID="labelActivityID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIVITYID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fields">
                        <ItemTemplate>
                            <asp:LinkButton ID="fieldDetailsLinkButton" runat="server"
                                CommandArgument="<%# Container.DisplayIndex %>" CommandName="viwFieldDetails" ForeColor="#003366" Font-Bold="True"
                                ID_ACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITIES") %>'
                                Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>' ToolTip="View activity details"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="District">
                        <ItemTemplate>
                            <asp:Label ID="labelDistrict" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DISTRICT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Superintendent">
                        <ItemTemplate>
                            <asp:Label ID="labelSuperintendent" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SUPERINTENDENT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Account to charge">
                        <ItemTemplate>
                            <asp:Label ID="labelAccountToCharge" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACCOUNT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Initiator">
                        <ItemTemplate>
                            <asp:Label ID="labelInitiator" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date From">
                        <ItemTemplate>
                            <asp:Label ID="labelDateFrom" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DATE_FROM") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date To">
                        <ItemTemplate>
                            <asp:Label ID="labelDateTo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DATE_TO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--<asp:TemplateField HeaderText="Status">
            <ItemTemplate>
                <asp:Label ID="labelStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:LinkButton ID="statusLinkButton" runat="server"
                                CommandArgument="<%# Container.DisplayIndex %>" CommandName="viwStatus" Font-Bold="True"
                                ID_ACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITIES") %>'
                                Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>' ToolTip="View Status" ValidationGroup="oGrid"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="...">
                        <ItemTemplate>
                            <asp:LinkButton ID="reportLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                CommandName="report" ID_ACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITIES") %>'
                                ValidationGroup="gridVal">Report</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
            <br />
        </td>
    </tr>
</table>
