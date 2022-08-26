<%@ Page Title="" Language="C#" MasterPageFile="~/CBIDashboard2.master" AutoEventWireup="true" CodeFile="LRegister.aspx.cs" Inherits="LRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 500px; margin-left: 5em; margin-top: 5em">
        <tr>
            <td colspan="2" class="cHeadTile"><h2>Register</h2></td>
        </tr>
        <tr style="border:solid 1px gray">
            <td bgcolor="#CCCCCC" colspan="2">
                <asp:Label ID="mssgLabel" runat="server" Font-Bold="False" ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
         <tr style="border:solid 1px silver">
            <td>
                <asp:Label ID="Label15" runat="server" Text="Full Name:" ForeColor="Black"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullName" ErrorMessage="Full Name is required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtFullName" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr style="border:solid 1px silver">
            <td>
                <asp:Label ID="Label17" runat="server" Text="Email Address:" ForeColor="Black"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmailAddress" ErrorMessage="Email Address is required">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailAddress" ErrorMessage="Invalid Email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:TextBox ID="txtEmailAddress" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr style="border:solid 1px silver">
            <td>
                <asp:Label ID="Label16" runat="server" Text="User Name:" ForeColor="Black"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserName" ErrorMessage="User Name is required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr style="border:solid 1px silver">
            <td>
                <asp:Label ID="Label18" runat="server" Text="Ref Ind.:" ForeColor="Black"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRefInd" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
       
        <tr style="border:solid 1px silver">
            <td>
                <asp:Label ID="Label19" runat="server" Text="Password:" ForeColor="Black"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword" ErrorMessage="Pass word is required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr style="border:solid 1px silver">
            <td>
                <asp:Label ID="Label20" runat="server" Text="Confirm Password:" ForeColor="Black"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRetryPassword" ErrorMessage="Please retry password">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtRetryPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        
        <tr style="border:solid 1px silver; padding:4px 7px 2px 4px">
            <td>
                <asp:Label ID="Label14" runat="server" Text="Role:" ForeColor="Black"></asp:Label>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="userRoleDropDownList"
                    ErrorMessage="Select user's role." Type="Integer" ValueToCompare="-1" Operator="NotEqual">*</asp:CompareValidator>
            </td>
            <td>
                <asp:DropDownList ID="userRoleDropDownList" runat="server" Width="300px">
                    <asp:ListItem Value="-1">[Select Role]</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="saveButton" runat="server" Text="Submit" Width="100px" OnClick="saveButton_Click" />
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

