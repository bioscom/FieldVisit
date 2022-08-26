<%@ Page Title="" Language="C#" MasterPageFile="~/CBIDashboard2.master" AutoEventWireup="true" CodeFile="LForgotPsw.aspx.cs" Inherits="LForgotPsw" %>


<%--<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CBIDashboard.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="margin-top: 1.0em; margin-left:40em">
        <asp:Panel ID="msgPanel" runat="server">
            <table style="margin-top: 5em">
                <tr>
                    <td style="width: 27px; vertical-align: middle">
                        <asp:Image ID="mssgImg" runat="server" Width="25px" Height="25px" />
                    </td>
                    <td style="vertical-align: middle; background-color: #ff99cc">
                        <asp:Label ID="mssgLabel" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <table style="width: 550px; margin-bottom: 5em" cellpadding="7">
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>
                    <%--<asp:Label ID="Label3" runat="server" Text="Please enter your email address to help us locate your account."></asp:Label>--%>
                    <h2>Forgot Password?</h2><br />
                    <br />
                    Use the form below to recover your password.
                    <br />
                    <br />
                    An email with instructions on how to recover password will be sent to your email address. If this is not the email address you registered with, you will not receive an email. 
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtEmailAddress" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmailAddress" ErrorMessage="Email Address is required">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailAddress" ErrorMessage="Invalid Email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnLogin" runat="server" Text="Send Password Change Request" OnClick="btnLogin_Click" Width="250px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>

