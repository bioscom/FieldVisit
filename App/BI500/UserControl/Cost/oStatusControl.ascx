<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oStatusControl.ascx.cs" Inherits="App_BI500_UserControl_Cost_oStatusControl" %>
<asp:DropDownList ID="ddlStatus" runat="server" Width="120px">
    <%--<asp:ListItem Value="-1">Status</asp:ListItem>
    <asp:ListItem Value="0">N/A</asp:ListItem>
    <asp:ListItem Value="0">Not Started</asp:ListItem>
    <asp:ListItem Value="50">Ongoing</asp:ListItem>
    <asp:ListItem Value="100">Completed</asp:ListItem>--%>
</asp:DropDownList>
<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlStatus" ErrorMessage="Please Select Status" Operator="NotEqual" Type="Integer" ValidationGroup="PEC" ValueToCompare="-1">*</asp:CompareValidator>

