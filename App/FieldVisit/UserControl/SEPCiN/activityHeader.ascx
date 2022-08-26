<%@ Control Language="C#" AutoEventWireup="true" CodeFile="activityHeader.ascx.cs" Inherits="UserControl_activityHeader" %>
<%@ Register Src="~/UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>

<%@ Register src="../../../../UserControls/userFinder/Search4LocalUser.ascx" tagname="Search4LocalUser" tagprefix="uc3" %>

<table>
    <tr>
        <td>
            <table style="vertical-align: top">
                <tr>
                    <td style="width: 140px">Activity Type:<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drpActivityType" ErrorMessage="Activity Type is required" Operator="NotEqual" Type="Integer" ValidationGroup="activityInfo" ValueToCompare="-1">*</asp:CompareValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpActivityType" runat="server" Width="230px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Asset / Platform:<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="drpAssets" ErrorMessage="Asset/Facility is required" Operator="NotEqual" Type="Integer" ValidationGroup="activityInfo" ValueToCompare="-1">*</asp:CompareValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpAssets" runat="server" Width="230px" AutoPostBack="True" OnSelectedIndexChanged="drpAssets_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Originator (Name):</td>
                    <td>
                        <asp:Label ID="originatorLabel" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Originator Dept:</td>
                    <td>
                        <asp:Label ID="originatorDeptLabel" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Activity Sponsor:<%--<asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="drpSponsor" ErrorMessage="Activity Sponsor is required" Operator="NotEqual" Type="Integer" ValidationGroup="activityInfo" ValueToCompare="-1">*</asp:CompareValidator>--%>
                    </td>
                    <td>
                        <%--<uc1:Search4User ID="activitySponsor" runat="server" />
                        <asp:DropDownList ID="drpSponsor" runat="server" Width="230px">
                            <asp:ListItem Value="-1">--Select Activity Sponsor--</asp:ListItem>
                        </asp:DropDownList>--%>
                        <uc3:Search4LocalUser ID="drpSponsor" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Activity Description:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtActivityDescription" ErrorMessage="Activity Description is required" ValidationGroup="activityInfo">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="txtActivityDescription" runat="server" TextMode="MultiLine" Width="400px"
                            Height="80px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">Justificatn/Reason 
                                                for
                                                Break-in(Activity Change):<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtJustification" ErrorMessage="Justification is required" ValidationGroup="activityInfo">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="txtJustification" runat="server" TextMode="MultiLine" Width="400px"
                            Height="80px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HiddenField ID="ActivityIdHF" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="activitySponsorHF" runat="server" />
                    </td>
                </tr>
            </table>
        </td>
        <td style="vertical-align: top">
            <table>
                <tr>
                    <td>No of Beds:<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNoOfBeds" ErrorMessage="No of Beds requires numeric value only" ValidationExpression="^\d+$" ValidationGroup="activityInfo">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNoOfBeds" ErrorMessage="No of bed is required" ValidationGroup="activityInfo">*</asp:RequiredFieldValidator>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtNoOfBeds" runat="server" Width="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>First Night:</td>
                    <td colspan="2">
                        <%--<asp:TextBox ID="txtFirstNight" runat="server" Width="70px"></asp:TextBox>--%>
                        <uc2:dateControl ID="dtFirstNight" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Last Night:</td>
                    <td colspan="2">
                        <%--<asp:TextBox ID="txtLastNight" runat="server" Width="70px"></asp:TextBox>--%>
                        <uc2:dateControl ID="dtLastNight" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                        &nbsp;</td>
                    <td colspan="2">&nbsp;
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">Will Activity cause oil deferment?</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:RadioButtonList ID="rdbDeferment" runat="server"
                            RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                            <asp:ListItem Value="2">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtVolume" ErrorMessage="Volume should not be empyty" ValidationGroup="activityInfo">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtVolume" runat="server" Width="50px">0</asp:TextBox>
                        <asp:DropDownList ID="unitDrp" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">Funtional Location:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFunctionLocation" ErrorMessage="Functional Location is required" ValidationGroup="activityInfo">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox ID="txtFunctionLocation" runat="server" Width="255px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <hr />
        </td>
    </tr>
    <tr>
        <td colspan="3" style="text-align: right">
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save"
                Width="100px" ValidationGroup="activityInfo" />
            <asp:Button ID="updateButton" runat="server" OnClick="updateButton_Click"
                Text="Update" Width="100px" ValidationGroup="activityInfo" />
        </td>
    </tr>
    <tr>
        <td colspan="3" style="text-align: right">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="activityInfo" />
        </td>
    </tr>
</table>
