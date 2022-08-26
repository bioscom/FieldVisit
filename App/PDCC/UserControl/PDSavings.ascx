<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PDSavings.ascx.cs" Inherits="App_PDCC_UserControl_PDSavings" %>

<table style="border-style:none">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="9pt" ForeColor="Navy" Text="Deep Dive:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtDeepDive" runat="server" Width="120px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Font-Bold="true" Font-Size="9pt" ForeColor="Purple" Text="Deep Dive Opportunity:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtDeepDiveOppor" runat="server" Width="120px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Font-Bold="true" Font-Size="9pt" Text="Efficiency Impr. Oppo.:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtEIO" runat="server" Width="120px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btnSaveEstimate" runat="server" Text="Save Est." OnClick="btnSaveEstimate_Click" />
            <asp:Button ID="btnSaveActual" runat="server" Text="Save Act." OnClick="btnSaveActual_Click" />
            <asp:Button ID="btnSaveLE" runat="server" OnClick="btnSaveLE_Click" Text="Save LE" />
        </td>
    </tr>
</table>

<asp:HiddenField ID="HFAsset" runat="server" />
<asp:HiddenField ID="HFMonth" runat="server" />
<asp:HiddenField ID="HFYear" runat="server" />
<asp:HiddenField ID="HFActual" runat="server" />
<asp:HiddenField ID="HFEstimated" runat="server" />
<asp:HiddenField ID="HFLE" runat="server" />