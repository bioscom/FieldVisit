<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Phasing.ascx.cs" Inherits="App_BI500_UserControl_Cost_Phasing" %>
<%@ Register Src="../../../../UserControls/dateControl.ascx" TagName="datecontrol" TagPrefix="uc2" %>

<table class="tMainBorder">
    <tr>
        <td class="cHeadTile" colspan="2">Bright Idea</td>
    </tr>
    <tr>
        <td style="width: 180px">
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Request Number:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblRequestNumber" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label30" runat="server" Font-Bold="True" Text="Title:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Date Submitted:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblDateInit" runat="server"></asp:Label>
        </td>
    </tr>
</table>


<table class="tMainBorder">
    <tr>
        <td class="cHeadTile">Project Phasing</td>
    </tr>
    <tr>
        <td>
            <asp:RadioButtonList ID="rdbPhasing" runat="server" OnSelectedIndexChanged="rdbPhasing_SelectedIndexChanged" AutoPostBack="True">
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblTeamMembers" runat="server" Font-Bold="True" Text="Team Members:"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtTeamMembers" runat="server" Height="100px" TextMode="MultiLine" Width="550px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="pnlSustain" runat="server">
                <table class="tMainBorder" style="width: 99%; border-collapse: separate">
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Improvement Benefit Realised:" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpImprovement" runat="server" Width="250px">
                                <asp:ListItem Value="-1">None</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drpImprovement" ErrorMessage="Select Improvement Benefit Realised" Operator="NotEqual" Type="Integer" ValidationGroup="pnlSustain" ValueToCompare="-1">*</asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="Red" Text="Quantity Benefit:"></asp:Label>
                        </td>
                        <td style="vertical-align: middle">
                            <asp:TextBox ID="txtQtyBenefit" runat="server" Width="250px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQtyBenefit" ErrorMessage="Enter Quantity Benefit" ValidationGroup="pnlSustain">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Replication Potential in SCIN:" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpPotential" runat="server" Width="250px">
                                <asp:ListItem Value="-1">None</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="drpPotential" ErrorMessage="Select Replication potential in SCIN" Operator="NotEqual" Type="Integer" ValidationGroup="pnlSustain" ValueToCompare="-1">*</asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="Actual Project Finish Date:" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            <uc2:datecontrol ID="dtFinishDate" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ValidationGroup="pnlSustain" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Width="100px" />
            &nbsp;<asp:Button ID="btnSubmitSustain" runat="server" Text="Submit" Width="100px" OnClick="btnSubmitSustain_Click" ValidationGroup="pnlSustain" />
            <asp:HiddenField ID="HFRequestId3" runat="server" />
        </td>
    </tr>
</table>

