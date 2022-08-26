﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BrightIdeasForm.ascx.cs" Inherits="App_BI500_UserControl_BrightIdeasForm" %>

<%@ Register Src="~/UserControls/userFinder/Search4LocalUser.ascx" TagName="Search4LocalUser" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>

<%@ Register Src="~/UserControls/userFinder/Search4User.ascx" TagName="Search4User" TagPrefix="uc3" %>
<%--<%@ Register Src="Search4LocalUser.ascx" TagName="Search4LocalUser" TagPrefix="uc3" %>--%>

<table class="tMainBorder" style="width: 800px">
    <tr>
        <td class="cHeadTile" colspan="2">Business Improvement Registration</td>
    </tr>
    <tr>
        <td colspan="2">
            <div>
                This is the Bright Ideas Project Registration form used to manage the storage, request an approval process for idea generated by SCIN staff in the various areas of business. 
                    <br />
                <br />
                Thanks - Bright Idea Process Owners.<br />
            </div>
        </td>
    </tr>
</table>

<table class="tMainBorder" style="width: 800px; margin-top: 0.5em; border-collapse: separate">
    <tr>
        <td style="width: 250px; background-color: gainsboro">
            <asp:Label ID="Label4" runat="server" Text="Project Improvement Title:" Font-Bold="True"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProjectTitle" ErrorMessage="Enter Project Improvement Title">*</asp:RequiredFieldValidator>
        </td>
        <td style="vertical-align: middle">
            <asp:TextBox ID="txtProjectTitle" runat="server" TextMode="MultiLine" Height="50px" Width="530px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="background-color: gainsboro">
            <asp:Label ID="Label5" runat="server" Text="Project Champion:" Font-Bold="True"></asp:Label>
            <br />
            </td>
        <td style="vertical-align: middle">
            <uc1:Search4LocalUser ID="champion" runat="server" />
            <em>(This is your immediate supervisor)</em></td>
    </tr>
    <tr>
        <td style="background-color: gainsboro">
            <asp:Label ID="Label6" runat="server" Text="Project Sponsor:" Font-Bold="True"></asp:Label>
            <br />
            </td>
        <td style="vertical-align: middle">
            
            <uc1:Search4LocalUser ID="Sponsor" runat="server" />
            (S<em>upervisor to your immediate supervisor)</em></td>
    </tr>
    
</table>

<table class="tMainBorder" style="width: 800px; margin-top: 0.5em; border-collapse: separate">
    <tr>
        <td style="width: 250px; background-color: gainsboro">
            <asp:Label ID="Label7" runat="server" Text="Business Case:" Font-Bold="True"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBizCase" ErrorMessage="Business Case is required">*</asp:RequiredFieldValidator>
        </td>
        <td style="vertical-align: middle">
            <asp:TextBox ID="txtBizCase" runat="server" Height="100px" TextMode="MultiLine" Width="530px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="background-color: gainsboro">
            <asp:Label ID="Label8" runat="server" Text="Opportunity Statement:" Font-Bold="True"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOpportunityStmt" ErrorMessage="Opportunity Statement is required">*</asp:RequiredFieldValidator>
        </td>
        <td style="vertical-align: middle">
            <asp:TextBox ID="txtOpportunityStmt" runat="server" Height="100px" TextMode="MultiLine" Width="530px"></asp:TextBox>
        </td>
    </tr>
</table>

<table class="tMainBorder" style="width: 800px; margin-top: 0.5em; border-collapse: separate">
    <tr>
        <td style="width: 250px; background-color: gainsboro">
            <asp:Label ID="Label9" runat="server" Text="Expected benefit/Impacted Area:" Font-Bold="True"></asp:Label>
            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="drpBenefit" ErrorMessage="Impacted Area is Required" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
        </td>
        <td style="vertical-align: middle">
            <asp:DropDownList ID="drpBenefit" runat="server" Width="250px">
                <asp:ListItem Value="-1">Select Impacted Area</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="background-color: gainsboro">
            <asp:Label ID="Label11" runat="server" Text="Project Plan Completion Date:" Font-Bold="True"></asp:Label>
        </td>
        <td style="vertical-align: middle">
            <uc2:dateControl ID="dtCompletion" runat="server" />
        </td>
    </tr>
    <%--<tr>
            <td style="background-color: gainsboro">
                <asp:Label ID="Label12" runat="server" Text="Project Team Members:" Font-Bold="True"></asp:Label>
                <br />
                <em>(List the proposed project team members)</em></td>
            <td style="vertical-align:middle">
                <asp:TextBox ID="txtMembers" runat="server" Height="100px" TextMode="MultiLine" Width="400px"></asp:TextBox>
            </td>
        </tr>
    <tr>
        <td style="background-color: gainsboro">
            <asp:Label ID="Label12" runat="server" Text="Amount Saved:" Font-Bold="True"></asp:Label>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAmountSaved" ErrorMessage="Invalid Input in Amount Saved. Enter decimal number with 2 places of decimal." ValidationExpression="^[0-9]*\.[0-9]{2}$">*</asp:RegularExpressionValidator>
        </td>
        <td>
            <asp:TextBox ID="txtAmountSaved" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>--%>
    <tr>
        <td style="background-color: gainsboro">
            <asp:HiddenField ID="HFRequestId" runat="server" />
        </td>
        <td style="vertical-align: middle">
            <asp:Button ID="btnDraft" runat="server" Text="Save as Draft" OnClick="btnDraft_Click" />
            &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100px" OnClick="btnSubmit_Click" OnClientClick="return confirm('Are you sure you want to send for approval?')" />
            &nbsp;<%--<asp:Button ID="btnReset" runat="server" Text="Reset" Width="100px" ValidationGroup="Reset" />--%><asp:Button ID="btnClose" runat="server" Text="Close" Width="100px" OnClick="btnClose_Click" ValidationGroup="Close" />
        </td>
    </tr>
</table>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />