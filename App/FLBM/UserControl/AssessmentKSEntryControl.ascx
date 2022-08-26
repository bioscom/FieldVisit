<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AssessmentKSEntryControl.ascx.cs" Inherits="App_FLBM_UserControl_AssessmentKSEntryControl" %>

<div style="margin: 2em">
    <table class="tMainBorder">
        <tr>
            <td colspan="2">
                <h3>Add Evidence Criteria</h3>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Level:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLevel" ErrorMessage="Level is required" ValidationGroup="Evidence">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtLevel" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Criteria:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCriteria" ErrorMessage="Criteria is required" ValidationGroup="Evidence">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtCriteria" runat="server" Height="50px" TextMode="MultiLine" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Evidence Description:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEvidence" ErrorMessage="Evidence Description is required" ValidationGroup="Evidence">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtEvidence" runat="server" Height="100px" TextMode="MultiLine" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100px" OnClick="btnSubmit_Click" ValidationGroup="Evidence" />
                &nbsp;
            <asp:Button ID="btnClose" runat="server" Text="Close" ValidationGroup="close" Width="100px" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:HiddenField ID="HFCompetence" runat="server" />
                <asp:HiddenField ID="HFProficiency" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Evidence" />
            </td>
        </tr>
    </table>

</div>
