<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ApproveSupport.ascx.cs" Inherits="UserControl_ApproveSupport" %>
<table class="tMainBorder">
    <%-- style="width:550px"--%>
        <tr>
            <td class="cHeadTile" colspan="2">&nbsp;
                <asp:Label ID="SupportLabel" runat="server" Font-Bold="True" ForeColor="#003366"></asp:Label>
            </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Stand:"></asp:Label>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drpStand" ErrorMessage="Please select your stand" Operator="NotEqual" Type="Integer" ValueToCompare="-1" ValidationGroup="ApproveInitiative">*</asp:CompareValidator>
        </td>
        <td>
            <asp:DropDownList ID="drpStand" runat="server" Width="200px">
                <asp:ListItem Value="-1">Select Stand</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Comments:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="CommentTextBox" runat="server" Height="100px" Text="" TextMode="MultiLine" Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="submitButton" runat="server" onclick="submitButton_Click" Text="Submit" Width="100px" ValidationGroup="ApproveInitiative" />
        </td>
    </tr>
</table>

<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="ApproveInitiative" />
<asp:HiddenField ID="lInitiativeHF" runat="server" />
<asp:HiddenField ID="lApprovalHF" runat="server" />