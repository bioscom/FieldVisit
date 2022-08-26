<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BrightIdeasFormEdt.ascx.cs" Inherits="App_BI500_UserControl_Cost_BrightIdeasFormEdt" %>
<script type="text/javascript" src="../../../../JavaScript/fieldVisit.js"></script>

<style type="text/css">
    .label {
        font-family: Verdana, Arial, Helvetica, sans-serif;
        font-style: normal;
        font-variant: normal;
        color: black;
    }
</style>

<%--<%@ Register Src="~/UserControls/userFinder/Search4User.ascx" TagName="Search4User" TagPrefix="uc1" %>--%>
<%@ Register Src="~/UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>

<table class="tMainBorder" style="width: 750px; margin-top: 0.5em; border-collapse: separate">
    <tr>
        <td style="width: 200px;">
            <asp:Label ID="Label18" runat="server" Text="Expected benefit:"></asp:Label>
            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="drpBenefit" ErrorMessage="Impacted Area is Required" Operator="NotEqual" Type="Integer" ValueToCompare="-1" ValidationGroup="pop">*</asp:CompareValidator>
        </td>
        <td>
            <asp:DropDownList ID="drpBenefit" runat="server" Width="550px">
                <asp:ListItem Value="-1">Select Impacted Area</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server" Text="Impacted Team:" ID="Label14"></asp:Label>

            <asp:CompareValidator runat="server" Operator="NotEqual" ValueToCompare="-1" Type="Integer" ControlToValidate="ddlTeam" ErrorMessage="Please select Your Team" ValidationGroup="pop" ID="CompareValidator5">*</asp:CompareValidator>

            <asp:Image runat="server" ImageUrl="~/Images/globalheader_help.gif" ToolTip="Select Impacted team" ID="img3"></asp:Image>

        </td>
        <td style="vertical-align: middle">
            <asp:DropDownList runat="server" Width="550px" ID="ddlTeam">
                <asp:ListItem Value="-1">Select Team</asp:ListItem>
            </asp:DropDownList>

        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label13" runat="server" Text="Project Title:"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProjectTitle" ErrorMessage="Enter Project Improvement Title" ValidationGroup="pop">*</asp:RequiredFieldValidator>
        </td>
        <td style="vertical-align: middle">
            <asp:TextBox ID="txtProjectTitle" runat="server" Width="550px" Height="50px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label16" runat="server" Text="Description of cost reduction idea:"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBizCase" ErrorMessage="Business Case is required" ValidationGroup="pop">*</asp:RequiredFieldValidator>

            <asp:Image runat="server" ImageUrl="~/Images/globalheader_help.gif" ToolTip="Enter your business case" ID="img1"></asp:Image>

        </td>
        <td style="vertical-align: middle">
            <asp:TextBox ID="txtBizCase" runat="server" Height="100px" TextMode="MultiLine" Width="550px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label17" runat="server" Text="Business Value:"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOpportunityStmt" ErrorMessage="Opportunity Statement is required" ValidationGroup="pop">*</asp:RequiredFieldValidator>

            <asp:Image runat="server" ImageUrl="~/Images/globalheader_help.gif" ToolTip="Enter your opportunity statement" ID="img2"></asp:Image>

        </td>
        <td style="vertical-align: middle">
            <asp:TextBox ID="txtOpportunityStmt" runat="server" Height="100px" TextMode="MultiLine" Width="550px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Target Savings:($)<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTargetSavings" ErrorMessage="Invalid entry!!! Decimal number only is allowed" ValidationExpression="[-]?\d{1,18}(?:[,.]\d{1,2})?$" ValidationGroup="pop">*</asp:RegularExpressionValidator></td>
        <td style="vertical-align: middle">
            <asp:TextBox ID="txtTargetSavings" runat="server"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td>Actual Savings:($)<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtActualSavings" ErrorMessage="Invalid entry!!! Decimal number only is allowed" ValidationExpression="[-]?\d{1,18}(?:[,.]\d{1,2})?$" ValidationGroup="pop">*</asp:RegularExpressionValidator></td>
        <td style="vertical-align: middle">
            <asp:TextBox ID="txtActualSavings" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td style="vertical-align: middle">

            <asp:HiddenField runat="server" ID="HFRequestId"></asp:HiddenField>

        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td style="vertical-align: middle">
            <asp:Button ID="btnDraft" runat="server" Text="Save as Draft" OnClick="btnDraft_Click" ValidationGroup="pop" />
            &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100px" OnClick="btnSubmit_Click" ValidationGroup="pop" />
        </td>
    </tr>
</table>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="pop" />