<%@ Page Title="" Language="C#" MasterPageFile="~/CBIDashboard2.master" AutoEventWireup="true" CodeFile="UserManagementSearch.aspx.cs" Inherits="UserManagementSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tSubGray" style="width:99%">
                <tr>
                    <td class="cHeadTile">
                        User Search Result</td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdView" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                            OnSorted="grdView_Sorted" OnSorting="grdView_Sorting" PageSize="40" RowStyle-CssClass="RowStyle" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="...">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="editLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>" CommandName="EditThis" OnClick="btnSelect_Click" USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>' USERMAIL='<%# DataBinder.Eval(Container.DataItem, "EMAIL") %>' USERNAME='<%# DataBinder.Eval(Container.DataItem, "USERNAME") %>'>Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Full Name" SortExpression="FULLNAME">
                                    <ItemTemplate>
                                        <asp:Label ID="labelFullName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Field Visit">
                                    <ItemTemplate>
                                        <asp:Label ID="labelRole" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ROLEID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cost Transparency">
                                    <ItemTemplate>
                                        <asp:Label ID="labelRoleCostTransparency" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ROLEIDPDCC") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bright Ideas">
                                    <ItemTemplate>
                                        <asp:Label ID="labelRoleBI" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ROLEIDBI") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Flare Waiver">
                                    <ItemTemplate>
                                        <asp:Label ID="labelRoleFlareWaiver" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ROLEIDFLR") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Initiative Mgt">
                                    <ItemTemplate>
                                        <asp:Label ID="labelRoleInitiative" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ROLEIDMANHR") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lean Mgt">
                                    <ItemTemplate>
                                        <asp:Label ID="labelRoleLean" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ROLEIDLEAN") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email Address" SortExpression="EMAIL">
                                    <ItemTemplate>
                                        <a href='mailto:%20<%# DataBinder.Eval(Container.DataItem, "EMAIL") %>'><%# DataBinder.Eval(Container.DataItem, "EMAIL")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="...">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="deleteLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>" CommandName="DeleteThis" OnClick="btnDelete_Click" USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>' USERROLESID='<%# DataBinder.Eval(Container.DataItem, "ROLEID") %>'>Delete</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

