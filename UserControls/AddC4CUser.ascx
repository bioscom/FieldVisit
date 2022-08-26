<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddC4CUser.ascx.cs" Inherits="UserControls_AddC4CUser" %>

    <table style="width: 600px" class="tMainBorder">
        <tr>
            <td class="cHeadTile" colspan="2">
                <asp:Label ID="Label13" runat="server" Font-Bold="True" ForeColor="#003366" Text="Create C4C User"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 150px">
                <asp:Label ID="Label15" runat="server" Text="Full Name:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullName" ErrorMessage="Full Name is required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtFullName" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label16" runat="server" Text="User Name:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserName" ErrorMessage="User Name is required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label17" runat="server" Text="Email Address:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmailAddress" ErrorMessage="Email Address is required">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailAddress" ErrorMessage="Invalid Email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:TextBox ID="txtEmailAddress" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label18" runat="server" Text="Ref Ind.:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRefInd" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:RadioButtonList ID="appRdb" runat="server" AutoPostBack="True" OnSelectedIndexChanged="appRdb_SelectedIndexChanged" RepeatColumns="2" RepeatDirection="Horizontal">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label14" runat="server" Text="Role:"></asp:Label>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlUserRole"
                    ErrorMessage="Select user's role." Type="Integer" ValueToCompare="-1" Operator="NotEqual">*</asp:CompareValidator>
            </td>
            <td>
                <asp:DropDownList ID="ddlUserRole" runat="server" Width="300px">
                    <asp:ListItem Value="-1">[Select Role]</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Submit"
                    ToolTip="Click to submit this form" Width="100px" />
                &nbsp;
                <asp:Button ID="closeButton" runat="server" OnClick="closeButton_Click" Text="Close"
                    ValidationGroup="xxxx" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" />