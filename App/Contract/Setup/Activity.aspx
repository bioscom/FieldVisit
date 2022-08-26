<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/14DayContract.master" AutoEventWireup="true" CodeFile="Activity.aspx.cs" Inherits="Contract_Setup_Activity" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <table class="tSubGray" style="width: 450px">
        <tr>
            <td class="cHeadTile" colspan="2">Add Activity</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Priority:"></asp:Label>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drpPriority" ErrorMessage="Please Select Corporate Priority" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
            </td>
            <td>
                <asp:DropDownList ID="drpPriority" runat="server" AutoPostBack="True" Width="300px">
                    <asp:ListItem Value="-1">--Select Priority--</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Activity:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtKPI" ErrorMessage="Key Performance Index is required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtKPI" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Measure:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUnit" ErrorMessage="Unit is required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtUnit" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Order</td>
            <td>
                <asp:TextBox ID="txtOrder" runat="server" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                &nbsp;<asp:Button ID="closeButton" runat="server" OnClick="closeButton_Click" Text="Close" ValidationGroup="close" />
            </td>
        </tr>
    </table>
</asp:Content>

