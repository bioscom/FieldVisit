<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/14DayContract.master" AutoEventWireup="true" CodeFile="Priority.aspx.cs" Inherits="Contract_Setup_Priority" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <table class="tMainBorder">
        <tr>
            <td class="cHeadTile" colspan="2">
                Add New Priority</td>
        </tr>
        <tr>
            <td>
                Priority:</td>
            <td>
                <asp:TextBox ID="txtPriority" runat="server" Width="400px" Height="50px" TextMode="MultiLine"></asp:TextBox>
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
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="addNewBtn" runat="server" onclick="addNewBtn_Click" 
                    Text="Add Priority" />
&nbsp;<asp:Button ID="cancelBtn" runat="server" Text="Cancel" onclick="cancelBtn_Click" />
            </td>
        </tr>
        </table>
</asp:Content>

