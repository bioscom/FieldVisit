<%@ Control Language="C#" AutoEventWireup="true" CodeFile="statusSelectorControl.ascx.cs" Inherits="UserControls_statusSelectorControl" %>
<asp:DropDownList ID="statusDrp" runat="server" Width="150px">
    <asp:ListItem Value="-1">Status</asp:ListItem>
</asp:DropDownList>
<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="statusDrp" ErrorMessage="Please Select Status" Operator="NotEqual" Type="Integer" ValidationGroup="PEC" ValueToCompare="-1">*</asp:CompareValidator>

