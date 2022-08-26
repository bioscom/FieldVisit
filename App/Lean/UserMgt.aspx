<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/LeanMasterPage.master" AutoEventWireup="true" CodeFile="UserMgt.aspx.cs" Inherits="App_Lean_UserMgt" %>

<%@ Register src="../../UserControls/ViewUsers.ascx" tagname="ViewUsers" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <uc2:ViewUsers ID="ViewUsers1" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--<div style="margin-left: 5em; width: 80%">

                <table class="tSubGray">
                    <tr>
                        <td class="cHeadTile" colspan="2">Users List
                        </td>
                    </tr>
                    <tr style="background-color: White">
                        <td>
                            <asp:DropDownList ID="ddlUserRole" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlUserRole_SelectedIndexChanged">
                                <asp:ListItem Value="-1">--Select User Role--</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <div style="float: right">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Find User"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="userTextBox" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="searchButton" runat="server"
                                                ImageUrl="~/Images/gosearch.gif" OnClick="searchButton_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div style="background-color: White">
                                <asp:GridView ID="grdView" runat="server" AllowPaging="True"
                                    AllowSorting="True" AutoGenerateColumns="False"
                                    OnPageIndexChanged="grdView_PageIndexChanged"
                                    OnPageIndexChanging="grdView_PageIndexChanging"
                                    OnSorted="grdView_Sorted" OnSorting="grdView_Sorting" PageSize="40"
                                    Width="100%">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="...">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="editLinkButton" runat="server"
                                                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="EditThis"
                                                    OnClick="btnSelect_Click"
                                                    USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>'
                                                    USERMAIL='<%# DataBinder.Eval(Container.DataItem, "EMAIL") %>'
                                                    USERNAME='<%# DataBinder.Eval(Container.DataItem, "USERNAME") %>'>Edit</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Full Name" SortExpression="FULLNAME">
                                            <ItemTemplate>
                                                <asp:Label ID="labelFullName" runat="server"
                                                    Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User Role(s)" SortExpression="ROLES">
                                            <ItemTemplate>
                                                <asp:Label ID="labelRole" runat="server"
                                                    Text='<%# DataBinder.Eval(Container.DataItem, "ROLEID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email Address" SortExpression="EMAIL">
                                            <ItemTemplate>
                                                <a href='mailto:%20<%# DataBinder.Eval(Container.DataItem, "EMAIL") %>'>
                                                    <%# DataBinder.Eval(Container.DataItem, "EMAIL")%></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="...">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="deleteLinkButton" runat="server"
                                                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="DeleteThis"
                                                    OnClick="btnDelete_Click"
                                                    USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>'
                                                    USERROLESID='<%# DataBinder.Eval(Container.DataItem, "ROLEID") %>'>Delete</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>

            </div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

