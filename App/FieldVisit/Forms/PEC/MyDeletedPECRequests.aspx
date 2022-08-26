<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master" AutoEventWireup="true" CodeFile="MyDeletedPECRequests.aspx.cs" Inherits="Forms_SEPCiN_MyDeletedPECRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tSubGray" style="width: 100%">
        <tr>
            <td class="cHeadTile">Deleted Requests - SEPCiN PEC Change Control</td>
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
                        <asp:TemplateField HeaderText="Activity Type">
                            <ItemTemplate>
                                <asp:Label ID="labelActivityType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIVITY_TYPE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Activity ID">
                            <ItemTemplate>
                                <asp:Label ID="labelActivityID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIVITYID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Asset/Platform">
                            <ItemTemplate>
                                <asp:LinkButton ID="fieldDetailsLinkButton" runat="server"
                                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="viwFieldDetails" ForeColor="#003366" Font-Bold="True"
                                    ID_ACTIVITYINFO='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITYINFO") %>'
                                    Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>' ToolTip="View activity details"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Originator">
                            <ItemTemplate>
                                <asp:Label ID="labelInitiator" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Raised">
                            <ItemTemplate>
                                <asp:Label ID="labelDatePECraised" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DATE_SUMBITTED") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Functional Location">
                            <ItemTemplate>
                                <asp:Label ID="labelLocation" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FUNCTION_LOCATION") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:LinkButton ID="statusLinkButton" runat="server"
                                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="viwStatus" Font-Bold="True"
                                    ID_ACTIVITYINFO='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITYINFO") %>'
                                    Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>' ToolTip="View Status"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                <asp:LinkButton ID="reportLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                    CommandName="report" ID_ACTIVITYINFO='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITYINFO") %>'
                                    ValidationGroup="gridVal">Report</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="..." ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument="<%# Container.DisplayIndex %>" CausesValidation="False" 
                                    CommandName="thisDelete" ID_ACTIVITYINFO='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITYINFO") %>'
                                    Text="Delete" OnClientClick="return confirm('This is final, you will not be able to recover this item again. Delete?')"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="..." ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkUnDelete" runat="server" CommandArgument="<%# Container.DisplayIndex %>" CausesValidation="False" 
                                    CommandName="UnDelete" ID_ACTIVITYINFO='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITYINFO") %>'
                                    Text="Undelete" OnClientClick="return confirm('Un Delete?')"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

