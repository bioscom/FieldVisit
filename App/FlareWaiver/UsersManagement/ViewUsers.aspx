<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="ViewUsers.aspx.cs" Inherits="UsersManagement_ViewUsers" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register src="../../../UserControls/ViewUsers.ascx" tagname="ViewUsers" tagprefix="uc2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" ScriptMode="Release" />--%>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" Width="98%">
        <ContentTemplate>
            <uc2:ViewUsers ID="ViewUsers1" runat="server" />

            <%--<table class="tMainBorder" style="width: 98%">
                <tr>
                    <td class="cHeadTile">Users List</td>
                </tr>
                <tr>
                    <td>
                        <div style="width: 100%">
                            <div style="width: 200px; float: left">

                                <asp:DropDownList ID="ddlUserRole" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlUserRole_SelectedIndexChanged">
                                    <asp:ListItem Value="-1">--Select User Role--</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                            <div style="width: 260px; float: right">
                                <div style="float: left">
                                    <asp:Label ID="Label2" runat="server" Text="Find User:"></asp:Label>
                                </div>
                                <div style="float: left; margin-left: 0.5em">
                                    <asp:TextBox ID="userTextBox" runat="server" ToolTip="Enter First Name or Last Name"></asp:TextBox>
                                </div>
                                <div style="float: left">
                                    <asp:ImageButton ID="searchButton" runat="server" ImageUrl="~/Images/gosearch.gif" OnClick="searchButton_Click" />
                                </div>
                            </div>
                            <center>
                                <asp:LinkButton ID="AddUserLinkButton" runat="server" PostBackUrl="~/App/FlareWaiver/UsersManagement/DefineUsers.aspx">Add New User</asp:LinkButton>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
                            </center>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="tMainBorder" style="width: 98%">
                <asp:GridView ID="UsersGridView" runat="server" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False"
                    OnPageIndexChanged="UsersGridView_PageIndexChanged"
                    OnPageIndexChanging="UsersGridView_PageIndexChanging"
                    OnRowCommand="UsersGridView_RowCommand" OnSorted="UsersGridView_Sorted"
                    OnSorting="UsersGridView_Sorting" PageSize="40" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                <asp:Button ID="editUserLinkButton" runat="server"
                                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="EditThisUser"
                                    Height="20px" Text="Edit"
                                    USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>'
                                    EMAIL='<%# DataBinder.Eval(Container.DataItem, "EMAIL") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Full Name" SortExpression="FULLNAME">
                            <ItemTemplate>
                                <asp:Label ID="labelFullName" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-Width="150px" HeaderText="User Role"
                            SortExpression="ROLEID">
                            <ItemTemplate>
                                <asp:Label ID="labelUserRole" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "ROLEID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                <asp:LinkButton ID="PendingApprovalsLinkButton" runat="server"
                                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="ViewPendingApprovals"
                                    USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>'>Pending Requests</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                <asp:LinkButton ID="ViewCTRInvolvedLinkButton" runat="server"
                                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="ViewCTRInvolved"
                                    USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>'>Approved Requests</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Email Address" SortExpression="EMAIL">
                            <ItemTemplate>
                                <a href='mailto:<%# DataBinder.Eval(Container.DataItem, "EMAIL")%>'>
                                    <%# DataBinder.Eval(Container.DataItem, "EMAIL")%></a>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                <asp:Button ID="deleteLinkButton" runat="server"
                                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="DeleteThisUser"
                                    Height="20px" Text="Delete"
                                    USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>--%>

        </ContentTemplate>
    </asp:UpdatePanel>

    <ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender" runat="server" Enabled="True" TargetControlID="UpdatePanel1">
    </ajaxToolkit:UpdatePanelAnimationExtender>

    <asp:UpdateProgress ID="upgAjaxBloc" runat="server" DisplayAfter="100" Visible="true" DynamicLayout="true">
        <ProgressTemplate>
            <div id="IMGDIV" align="center" valign="middle" runat="server" style="position: absolute; visibility: visible; left: 50%; top: 70%; vertical-align: middle; border-color: #FFFFFF; background-color: #FFFFFF;">
                <asp:Image ID="imgAjaxWait" runat="server" ImageUrl="~/Images/ajaxRoller.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    
    <br />
    <br />
</asp:Content>
