<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddUser.ascx.cs" Inherits="UserControl_AddUser" %>
<%@ Register src="~/UserControls/userFinder/Search4User.ascx" TagName="Search4User" TagPrefix="app" %>

    <table class="tMainBorder">
        <tr>
            <td class="cHeadTile" colspan="2">Add New Users</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="User Name:"></asp:Label>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="User Name is required" ControlToValidate="txtUserName">*</asp:RequiredFieldValidator>--%>
            </td>
            <td>
                <app:Search4User ID="Search4User1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="User Role:"></asp:Label>
                <asp:CompareValidator ID="CompareValidator1" runat="server"
                    ErrorMessage="User Role is required" ControlToValidate="ddlUserRole"
                    Operator="NotEqual" Type="Integer" ValueToCompare="-1" ValidationGroup="addUser">*</asp:CompareValidator>
            </td>
            <td>
                <asp:DropDownList ID="ddlUserRole" runat="server" Width="200px">
                    <asp:ListItem Value="-1">[Select User Role]</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click"
                    Text="Submit" Width="100px" ValidationGroup="addUser" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" ValidationGroup="xxxxaddUser" Width="100px" OnClick="btnReset_Click" />
                
                <asp:HiddenField ID="appHF" runat="server" />
                
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
        ShowMessageBox="True" ShowSummary="False" ValidationGroup="addUser" />

