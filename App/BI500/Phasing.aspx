<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BI500.master" AutoEventWireup="true" CodeFile="Phasing.aspx.cs" Inherits="App_BI500_Phasing" %>

<%@ Register Src="UserControl/oRequestDetails.ascx" TagName="oRequestDetails" TagPrefix="uc2" %>

<%@ Register Src="../../UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>

<asp:Content ID="Content3" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <%--<ajaxToolkit:ToolkitScriptManager runat="Server" ID="ScriptManager1" />--%>

    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" CombineScripts="false" EnablePartialRendering="true" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <table style="width: 80%">
                <tr>
                    <td style="width: 45%">
                        <uc2:oRequestDetails ID="oRequestDetails1" runat="server" />
                    </td>
                    <td>
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
                                                <td style="width: 250px; background-color: gainsboro">
                                                    <asp:Label ID="Label3" runat="server" Text="Improvement Benefit Realised:" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td style="vertical-align: middle">
                                                    <asp:DropDownList ID="drpImprovement" runat="server" Width="250px">
                                                        <asp:ListItem Value="-1">None</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drpImprovement" ErrorMessage="Select Improvement Benefit Realised" Operator="NotEqual" Type="Integer" ValidationGroup="pnlSustain" ValueToCompare="-1">*</asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background-color: gainsboro">
                                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="Red" Text="Quantity Benefit:"></asp:Label>
                                                </td>
                                                <td style="vertical-align: middle">
                                                    <asp:TextBox ID="txtQtyBenefit" runat="server" Width="250px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQtyBenefit" ErrorMessage="Enter Quantity Benefit" ValidationGroup="pnlSustain">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background-color: gainsboro">
                                                    <asp:Label ID="Label9" runat="server" Text="Replication Potential in SCIN:" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td style="vertical-align: middle">
                                                    <asp:DropDownList ID="drpPotential" runat="server" Width="250px">
                                                        <asp:ListItem Value="-1">None</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="drpPotential" ErrorMessage="Select Replication potential in SCIN" Operator="NotEqual" Type="Integer" ValidationGroup="pnlSustain" ValueToCompare="-1">*</asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background-color: gainsboro">
                                                    <asp:Label ID="Label11" runat="server" Text="Actual Project Finish Date:" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td style="vertical-align: middle">
                                                    <uc2:dateControl ID="dtFinishDate" runat="server" />
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
                                    &nbsp;<asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Close" Width="100px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" />
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

    <br />
    <br />
</asp:Content>
