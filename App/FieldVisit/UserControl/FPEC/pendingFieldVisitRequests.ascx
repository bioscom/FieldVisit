<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pendingFieldVisitRequests.ascx.cs"
    Inherits="UserControl_pendingFieldVisitRequests" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="FieldVisitQuestionaire.ascx" TagName="FieldVisitQuestionaire" TagPrefix="uc2" %>
<table class="tSubGray" style="width: 100%">
    <tr>
        <td class="cHeadTile">My Field Visit Requests Pending Approval
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="grdView_PageIndexChanging"
                OnRowCommand="grdView_RowCommand" Width="100%">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="...">
                        <ItemTemplate>
                            <asp:LinkButton ID="editLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                CommandName="editThis" ID_ACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITIES") %>'
                                ValidationGroup="gridVal">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Activity ID">
                        <ItemTemplate>
                            <asp:Label ID="labelActivityID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIVITYID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fields">
                        <ItemTemplate>
                            <asp:LinkButton ID="fieldDetailsLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                CommandName="viwFieldDetails" ForeColor="#003366" Font-Bold="True" ID_ACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITIES") %>'
                                Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>' ToolTip="View activity details"
                                ValidationGroup="gridVal"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Task">
                        <ItemTemplate>
                            <asp:Label ID="labelTask" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TASK_DESCRIPTION") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:LinkButton ID="statusLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                CommandName="viwStatus" Font-Bold="True" ID_ACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITIES") %>'
                                Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>' ToolTip="View Status"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="...">
                        <ItemTemplate>
                            <asp:LinkButton ID="deleteLinkButton" runat="server"
                                CommandArgument="<%# Container.DisplayIndex %>" CommandName="DeleteThis"
                                OnClick="btnDelete_Click"
                                ID_ACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITIES") %>'
                                STATUS='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'>Delete</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="...">
                        <ItemTemplate>
                            <asp:LinkButton ID="reportLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                CommandName="report" ID_ACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITIES") %>'
                                ValidationGroup="gridVal">Report</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Panel ID="detailsPanel" runat="server">
                <table class="tSubGray" style="width: 100%">
                    <tr>
                        <td class="cHeadLeft" colspan="2">Field Visit Detail Information
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                            <asp:Label ID="activityIDLabel0" runat="server" Font-Bold="True">Activity ID:</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="activityIDLabel" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            &nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="activityIDLabel1" runat="server" Font-Bold="True">Task Description: </asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="taskDescriptionLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="activityIDLabel2" runat="server" Font-Bold="True">Planned Dates:</asp:Label>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label31" runat="server" Font-Bold="True" Text="From:"></asp:Label>
                                    </td>
                                    <td>&nbsp; </td>
                                    <td>
                                        <asp:Label ID="fromDateLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label32" runat="server" Font-Bold="True" Text="To:"></asp:Label>
                                    </td>
                                    <td>&nbsp; </td>
                                    <td>
                                        <asp:Label ID="toDateLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="activityIDLabel3" runat="server" Font-Bold="True">Field:</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="fieldLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="activityIDLabel4" runat="server" Font-Bold="True">District:</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="districtLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="activityIDLabel5" runat="server" Font-Bold="True">Superintendent:</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="superintendentLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="activityIDLabel6" runat="server" Font-Bold="True">Account to Charge: </asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="acctToChargeLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;
                        </td>
                    </tr>
                </table>
                <uc2:FieldVisitQuestionaire ID="FieldVisitQuestionaire1" runat="server" />
            </asp:Panel>
        </td>
    </tr>
</table>
