<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/14DayContract.master" AutoEventWireup="true" CodeFile="viewPriorities.aspx.cs" Inherits="Contract_Setup_viewPriorities" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <table cellpadding="3" cellspacing="0" class="tSubGray">
        <tr>
            <td class="cHeadLeft" colspan="3">
                Corporate Priorities</td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lbAddNew" runat="server" 
                    PostBackUrl="~/App/Contract/Setup/Priority.aspx">Add New Priority</asp:LinkButton>
            </td>
            <td>
                <asp:Label ID="LblTaskRetMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
            <td>
                            <asp:Button ID="closeBtn" runat="server" OnClick="closeBtn_Click" Text="Close" />
            </td>
        </tr>
        <tr>
            <td class="cTextCenta" colspan="3">
                <asp:Label ID="LblRecCount" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="cTextLeft" colspan="3">
                <asp:GridView ID="GdVRepot" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" PageSize="20" Width="100%" 
                    onpageindexchanging="GdVRepot_PageIndexChanging" 
                    onrowcommand="GdVRepot_RowCommand" 
                    onrowediting="GdVRepot_RowEditing" 
                    onrowcancelingedit="GdVRepot_RowCancelingEdit" 
                    onrowupdating="GdVRepot_RowUpdating" 
                    DataKeyNames="CORPORATE_PRIORITY_PRIORITYID">
                    <Columns>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField ShowEditButton="True" ItemStyle-Font-Size="Small" ItemStyle-Font-Bold="true" /> 

                        <asp:TemplateField HeaderText="Corporate Priority">
                            <EditItemTemplate>
                                <asp:TextBox ID="corpPriorityTextBox" TextMode ="MultiLine" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CORPORATE_PRIORITY_PRIORITY") %>' Width="300px" Height="70px" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCorpPriority" runat="server" Text='<%# Eval("CORPORATE_PRIORITY_PRIORITY") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="450px" />
                        </asp:TemplateField>

                        <%--<asp:TemplateField HeaderText="Description">
                            <EditItemTemplate>
                                <asp:TextBox ID="descriptionTextBox" TextMode ="MultiLine" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CORPORATE_PRIORITY_DESCRIPTION") %>' Width="300px" Height="70px" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("CORPORATE_PRIORITY_DESCRIPTION") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="350px" />
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Created By">
                            <ItemTemplate>
                                <asp:Label ID="lblCreatedBy" runat="server" Text='<%# Eval("USERMGT_FULLNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Date Created">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("CORPORATE_PRIORITY_TIMESTAMP") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="cTextLeft" colspan="3">
            </td>
        </tr>
    </table>
    <br />
</asp:Content>