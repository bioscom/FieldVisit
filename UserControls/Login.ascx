<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="UserControls_Login" %>
<asp:Panel ID="msgPanel" runat="server">
    <table class="tSubGray" style="width: 450px">
        <%--<table class="tSubGray" style="width: 250px">--%>
        <tr>
            <td style="width: 27px; vertical-align: middle">
                <asp:Image ID="mssgImg" runat="server" Width="25px" Height="25px" />
            </td>
            <td style="vertical-align: middle; text-align: center; background-color: #ff99cc">
                <asp:Label ID="mssgLabel" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Panel>
<div>
    <table>
        <tr>
            <td colspan="2">
                <h5 style="color:red">
                    <b>Note: Login is only for C4C users. </b>
                </h5>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="User Name:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="Username is required" ValidationGroup="Login">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="Password:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required" ValidationGroup="Login">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/LForgotPsw.aspx">Forgot Password?</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">&nbsp;</td>
            <td>
                &nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">&nbsp;</td>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="100px" ValidationGroup="Login" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/LRegister.aspx">Register</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Login" />
            </td>
        </tr>
    </table>

</div>
