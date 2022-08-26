<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search4LocalUser.ascx.cs" Inherits="UserControl_userFinder_Search4LocalUser" %>

<div style="width: auto; border: none">
    <div style="float: left">
        <asp:DropDownList ID="drpUserx" runat="server" Width="200px">
            <asp:ListItem Selected="True" Value="-1">[Select User]</asp:ListItem>
        </asp:DropDownList>
        <asp:CompareValidator ID="valdtUserRequired" runat="server" ErrorMessage="User is required" ControlToValidate="drpUserx" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
        <asp:TextBox ID="txtUserx" runat="server" MaxLength="25" TextMode="SingleLine" Width="200px" ToolTip="Enter First Name or Last Name of the User to search"></asp:TextBox>
    </div>
    <div style="float: left">
        <asp:ImageButton runat="Server" ID="imbEdit"
            ImageUrl="~/UserControls/btnEdit.png" Width="22px"
            Height="22px" CausesValidation="False" OnClick="imbEdit_Click" ToolTip="Reset" />
        <asp:ImageButton runat="Server" ID="imbFind"
            ImageUrl="~/UserControls/btnFind.png" Width="22px"
            Height="22px" CausesValidation="False" OnClick="imbFind_Click" ToolTip="Click to search for user" />
    </div>
</div>

