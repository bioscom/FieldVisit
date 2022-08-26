<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BI500.master" AutoEventWireup="true" CodeFile="YourTeam.aspx.cs" Inherits="App_BI500_YourTeam" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <table class="tMainBorder" style="width: 800px; border-collapse: separate">
        <tr class="cHeadTile">
            <td colspan="2">Please Update your team information</td>
        </tr>
        <tr>
            <td style="width: 250px; background-color: gainsboro">
                <asp:Label ID="Label3" runat="server" Text="Business Unit:" Font-Bold="True"></asp:Label>
                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="drpBuzUnit" ErrorMessage="Please select Business Unit" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
            </td>
            <td style="vertical-align: middle">
                <asp:DropDownList ID="drpBuzUnit" runat="server" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="drpBuzUnit_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Select Business Unit</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="background-color: gainsboro">
                <asp:Label ID="Label13" runat="server" Text="Department:" Font-Bold="True"></asp:Label>
                <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlDepartment" ErrorMessage="Please select Business Unit Department" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
            </td>
            <td style="vertical-align: middle">
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="250px" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Value="-1">Select Department</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="background-color: gainsboro">
                <asp:Label ID="Label14" runat="server" Text="Team:" Font-Bold="True"></asp:Label>
                <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="ddlTeam" ErrorMessage="Please select Your Team" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
            </td>
            <td style="vertical-align: middle">
                <asp:DropDownList ID="ddlTeam" runat="server" Width="250px">
                    <asp:ListItem Value="-1">Select Team</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100px" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
</asp:Content>

