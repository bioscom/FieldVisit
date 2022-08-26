<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search4User.ascx.cs" Inherits="UserControl_Search_Search4User" %>

<asp:DropDownList ID="drpUserx" runat="server" Width="200px">
    <asp:ListItem Selected="True" Value="0">[Select GID User Name]</asp:ListItem>
</asp:DropDownList>
<asp:TextBox ID="txtUserx" runat="server" MaxLength="25" TextMode="SingleLine" Width="200px" ToolTip="Enter First Name or Last Name of the User to search"></asp:TextBox>
<asp:ImageButton runat="Server" ID="imbEdit"
    ImageUrl="~/UserControl/Search/btnEdit.png" Width="20"
    Height="20" CausesValidation="False" OnClick="imbEdit_Click" ToolTip="Reset" />
<asp:ImageButton runat="Server" ID="imbFind"
    ImageUrl="~/UserControl/Search/btnFind.png" Width="20"
    Height="20" CausesValidation="False" OnClick="imbFind_Click" ToolTip="Click to search for user" />
