<%@ Control Language="C#" AutoEventWireup="true" CodeFile="statusSelectorControl.ascx.cs" Inherits="UserControl_statusSelectorControl" %>
<asp:DropDownList ID="statusDrp" runat="server" Width="120px">
    <%--<asp:ListItem Value="-1">Status</asp:ListItem>
    <asp:ListItem Value="0">N/A</asp:ListItem>
    <asp:ListItem Value="0">Not Started</asp:ListItem>
    <asp:ListItem Value="50">Ongoing</asp:ListItem>
    <asp:ListItem Value="100">Completed</asp:ListItem>--%>
</asp:DropDownList>
<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="statusDrp" ErrorMessage="Please Select Status" Operator="NotEqual" Type="Integer" ValidationGroup="PEC" ValueToCompare="-1">*</asp:CompareValidator>

