<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search4User.ascx.cs" Inherits="UserControl_userFinder_Search4User" %>

<table>
    <tr>
        <td>
            <asp:DropDownList ID="drpUserx" runat="server" Width="200px">
                <asp:ListItem Selected="True" Value="0">[Select GID User Name]</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtUserx" runat="server" MaxLength="25" Height="22px" Width="200px" ToolTip="Enter First Name or Last Name of the User to search"></asp:TextBox>
        </td>
        <td>
            <asp:ImageButton runat="Server" ID="imbEdit" ImageUrl="~/UserControls/btnEdit.png" Width="22px" Height="22px" CausesValidation="False" OnClick="imbEdit_Click" ToolTip="Reset" />
            <asp:ImageButton runat="Server" ID="imbFind" ImageUrl="~/UserControls/btnFind.png" Width="22px" Height="22px" CausesValidation="False" OnClick="imbFind_Click" ToolTip="Click to search for user" />
        </td>
    </tr>
</table>

<%--<div style="width:auto">
            <div style="float:left">
                <asp:DropDownList ID="drpUserx" runat="server" Width="200px">
                    <asp:ListItem Selected="True" Value="0">[Select GID User Name]</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtUserx" runat="server" MaxLength="25" TextMode="SingleLine" Height="22px" Width="200px" ToolTip="Enter First Name or Last Name of the User to search"></asp:TextBox>
            </div>
            <div style="float:left">
                <asp:ImageButton runat="Server" ID="imbEdit"
                    ImageUrl="~/UserControls/btnEdit.png" Width="22px"
                    Height="22px" CausesValidation="False" OnClick="imbEdit_Click" ToolTip="Reset" />
                <asp:ImageButton runat="Server" ID="imbFind"
                    ImageUrl="~/UserControls/btnFind.png" Width="22px"
                    Height="22px" CausesValidation="False" OnClick="imbFind_Click" ToolTip="Click to search for user" />
            </div>
        </div>--%>
