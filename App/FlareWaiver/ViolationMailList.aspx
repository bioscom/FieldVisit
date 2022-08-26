<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="ViolationMailList.aspx.cs" Inherits="App_FlareWaiver_ViolationMailList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tSubGray" style="width:98%">
    <tr>
        <td class="cHeadTile">Users List
                        
                </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Width="100px" />
        </td>
    </tr>
    <tr>
        <td>
            <div style="background-color: White">
                <asp:GridView ID="grdView" runat="server" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False"
                    OnPageIndexChanged="grdView_PageIndexChanged"
                    OnPageIndexChanging="grdView_PageIndexChanging"
                    OnSorted="grdView_Sorted" OnSorting="grdView_Sorting" PageSize="25"
                    Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkUser" runat="server" USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>' />
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
                    </Columns>
                </asp:GridView>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnSubmit0" runat="server" OnClick="btnSubmit_Click" Text="Submit" Width="100px" />
        </td>
    </tr>
</table>
<br /><br /><br />
</asp:Content>

