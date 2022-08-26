<%@ Page Title="" Language="C#" MasterPageFile="~/CBIDashboard2.master" AutoEventWireup="true" CodeFile="LPswReset.aspx.cs" Inherits="LPswReset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tSubGray" style="width: 500px; margin-left: 5em">
        <tr>
            <td colspan="2" class="cHeadTile">Reset Password</td>
        </tr>
        <tr>
            <td bgcolor="#CCCCCC" colspan="2">
                <asp:Label ID="mssgLabel" runat="server" Font-Bold="False" ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label21" runat="server" Text="Password:" ForeColor="Black"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtGuidPassword" ErrorMessage="Password is required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtGuidPassword" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label19" runat="server" Text="New Password:" ForeColor="Black"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label20" runat="server" Text="Confirm New Password:" ForeColor="Black"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRetryPassword" ErrorMessage="Please retry password">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtRetryPassword" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="saveButton" runat="server" Text="Submit" OnClick="saveButton_Click" />
                <asp:Button ID="loginButton" runat="server" OnClick="loginButton_Click" Text="Login" ValidationGroup="Login" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" />
            </td>
        </tr>
    </table>
</asp:Content>

