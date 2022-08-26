<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search4LocalUser.ascx.cs" Inherits="UserControl_userFinder_Search4LocalUser" %>

<%--<div class="row">
    <div class="col-md-4">--%>
<table>
    <tr>
        <td>
            <asp:DropDownList ID="drpUserx" runat="server" Width="200px">
                <asp:ListItem Selected="True" Value="-1">[Select User]</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtUserx" runat="server" MaxLength="25" Height="22px" Width="200px" ToolTip="Enter First Name or Last Name of the User to search"></asp:TextBox>

        </td>
        <td>
            <asp:ImageButton runat="Server" ID="imbEdit" ImageUrl="~/UserControls/btnEdit.png" CausesValidation="False" OnClick="imbEdit_Click" ToolTip="Reset" />
            <asp:ImageButton runat="Server" ID="imbFind" ImageUrl="~/UserControls/btnFind.png" CausesValidation="False" OnClick="imbFind_Click" ToolTip="Click to search for user" />
            <asp:CompareValidator ID="valdtUserRequired" runat="server" ErrorMessage="User is required" ControlToValidate="drpUserx" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>

        </td>
    </tr>
</table>


<%--</div>
    <div class="col-md-8">--%>
<%--</div>
</div>--%>
