<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/ActionTracker.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="App_PPMS_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <table class="tMainBorder" style="Width:140%">
        <tr>
            <td class="cHeadTile">Projects Action Tracking Register</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdGridView" runat="server" AllowPaging="True"
                    AutoGenerateColumns="False" OnLoad="grdGridView_Load"
                    OnPageIndexChanging="grdGridView_PageIndexChanging"
                    OnRowCommand="grdGridView_RowCommand"
                    OnSelectedIndexChanged="grdGridView_SelectedIndexChanged" PageSize="50"
                    Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditLinkButton" runat="server"
                                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="EditThisRequest"
                                    ACTIONID='<%# DataBinder.Eval(Container.DataItem, "ACTIONID") %>'>Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <asp:Label ID="lblcategory" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "CATEGORY") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Theme">
                            <ItemTemplate>
                                <asp:Label ID="lblTheme" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "THEMES") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Asset/Function">
                            <ItemTemplate>
                                <asp:Label ID="lblAsset" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ASSET") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:Label ID="lblAction" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTION") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="300px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Importance">
                            <ItemTemplate>
                                <asp:Label ID="lblImportance" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IMPORTANCE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Urgency">
                            <ItemTemplate>
                                <asp:Label ID="lblUrgency" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "URGENCY") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Font-Bold="true" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action Party">
                            <ItemTemplate>
                                <asp:Label ID="lblActionParty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIONPARTYFULLNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Focal Point">
                            <ItemTemplate>
                                <asp:Label ID="lblFocalPoint" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FOCALPOINTFULLNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Close Out">
                            <ItemTemplate>
                                <asp:Label ID="lblDateCloseOut" runat="server" Text='<%# Bind("DATECLOSEDOUT", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Submitted">
                            <ItemTemplate>
                                <asp:Label ID="lblDateSubmitted" runat="server" Text='<%# Bind("DATESUBMITTED", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Last Updated">
                            <ItemTemplate>
                                <asp:Label ID="lblDateLastUpdated" runat="server" Text='<%# Bind("DATELASTACTIONED", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Underlining Activities">
                            <ItemTemplate>
                                <asp:Label ID="lblActivities" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIVITIES") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comments">
                            <ItemTemplate>
                                <asp:Label ID="lblComments" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMMENTS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Next Steps">
                            <ItemTemplate>
                                <asp:Label ID="lblNextSteps" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NEXTSTEPS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="ViewDetailsLinkButton" runat="server"
                                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="ViewDetails"
                                    ACTIONID='<%# DataBinder.Eval(Container.DataItem, "ACTIONID") %>'>View Details</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

