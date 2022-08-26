<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/ActionTracker.master" AutoEventWireup="true" CodeFile="ActionTrackerForm.aspx.cs" Inherits="App_PPMS_ActionTrackerForm" %>

<%@ Register Src="../../UserControls/userFinder/Search4LocalUser.ascx" TagName="Search4LocalUser" TagPrefix="uc2" %>
<%@ Register Src="../../UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/statusSelectorControl.ascx" TagName="statusSelectorControl" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" ID="smtAjaxManager" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <table class="tMainBorder" style="width: 670px; margin-left: auto; margin-right: auto">
                <tr class="cHeadTile">
                    <td colspan="2">Action Tracking Register</td>
                </tr>
                <tr>
                    <td style="width: 150px">
                        <asp:Label ID="Label2" runat="server" Text="Category:"></asp:Label>
                        <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlCategory" ErrorMessage="Please select Category" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server" Width="350px" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                            <asp:ListItem Value="-1">Select Category</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr runat="server" id="tr2">
                    <td style="width: 200px">&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtCategory" runat="server" Width="350px"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label14" runat="server" CssClass="Warning" Text="*** Enter other category ***"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Theme:"></asp:Label>
                        <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="ddlTheme" ErrorMessage="Please select Theme" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTheme" runat="server" Width="350px" AutoPostBack="True" OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged">
                            <asp:ListItem Value="-1">Select Theme</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr runat="server" id="tr4">
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtTheme" runat="server" Width="350px"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label1" runat="server" CssClass="Warning" Text="*** Enter other theme ***"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Funtion/Asset:"></asp:Label>
                        <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="ddlAsset" ErrorMessage="Please select Function/Asset" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAsset" runat="server" Width="350px" AutoPostBack="True" OnSelectedIndexChanged="ddlAsset_SelectedIndexChanged">
                            <asp:ListItem Value="-1">Select Function/Asset</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr runat="server" id="tr6">
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtFuncAsset" runat="server" Width="350px"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label15" runat="server" CssClass="Warning" Text="*** Enter other Function/Asset ***"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Importance:"></asp:Label>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddlImportance" ErrorMessage="Please select importance" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlImportance" runat="server" Width="200px">
                            <asp:ListItem Value="-1">Select Importance</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Urgency:"></asp:Label>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlUrgency" ErrorMessage="Please select urgency" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUrgency" runat="server" Width="200px">
                            <asp:ListItem Value="-1">Select Urgency</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Action Party:"></asp:Label>
                    </td>
                    <td>
                        <uc2:Search4LocalUser ID="ddlActionParty" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Close Out Date:"></asp:Label>
                    </td>
                    <td>
                        <uc3:dateControl ID="dtCloseOutDate" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="Status:"></asp:Label>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlStatus" ErrorMessage="Please select status" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" runat="server" Width="200px">
                            <asp:ListItem Value="-1">Select Status</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Action:"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAction" ErrorMessage="Action is required">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAction" runat="server" Height="80px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="Comments:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtComments" runat="server" Width="500px" Height="80px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="Underlining Activities:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtActivities" runat="server" Height="80px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="Next Steps:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNextSteps" runat="server" Height="80px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ValidationSummary ID="ValidationSummary1"  runat="server" ShowMessageBox="True" ShowSummary="False" />
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="150px" OnClick="btnSubmit_Click" />
                        &nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" ValidationGroup="yyy" Width="150px" OnClick="btnReset_Click" />
                        &nbsp;<asp:Button ID="btnClose" runat="server" Text="Close" ValidationGroup="xxx" Width="150px" OnClick="btnClose_Click" />
                    </td>
                </tr>
            </table>

        </ContentTemplate>
    </asp:UpdatePanel>
    

    <ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender"
        runat="server" Enabled="True" TargetControlID="UpdatePanel1">
    </ajaxToolkit:UpdatePanelAnimationExtender>

    <asp:UpdateProgress ID="upgAjaxBloc" runat="server" DisplayAfter="100" Visible="true"
        DynamicLayout="true">
        <ProgressTemplate>
            <div id="IMGDIV" align="center" valign="middle" runat="server" style="position: absolute; visibility: visible; left: 50%; top: 70%; vertical-align: middle; border-color: #FFFFFF; background-color: #FFFFFF;">
                <asp:Image ID="imgAjaxWait" runat="server" ImageUrl="~/Images/ajaxRoller.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

