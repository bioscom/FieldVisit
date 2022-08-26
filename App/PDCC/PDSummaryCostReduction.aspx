<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PDCC.master" AutoEventWireup="true" CodeFile="PDSummaryCostReduction.aspx.cs" Inherits="App_PDCC_PDSummaryCostReduction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/App/PDCC/UserControl/PartsOpportunities.ascx" TagPrefix="app" TagName="PartsOpportunities" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <%--<ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" EnablePartialRendering="true" ScriptMode="Release" />--%>
    <script type="text/javascript" src="JavaScript/fieldVisit.js"></script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tMainBorder" style="width: 58%">
                <tr>
                    <td class="cHeadTile" colspan="2">PD Summary Cost Reduction</td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <b>Asset</b><asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlAsset" ErrorMessage="Asset is required" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAsset" runat="server" Width="320px" AutoPostBack="True" OnSelectedIndexChanged="ddlAsset_SelectedIndexChanged">
                            <asp:ListItem Value="-1">--Select Asset--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblOpex" runat="server"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtOpexYear" ErrorMessage="Opex is required">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOpexYear" runat="server" Width="150px"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <table class="tMainBorder" style="width: 58%">
                <tr>
                    <td>
                        <table border="1">
                            <tr>
                                <td style="background-color:ActiveCaption; border:none" colspan="2">
                                    <asp:Label ID="Label14" runat="server" ForeColor="#000066" Text="Deep Dive" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" ForeColor="#000066" Text="Bankable($):"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDDBanked" ErrorMessage="Front End Take Out is required">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDDBanked" runat="server" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label15" runat="server" ForeColor="#000066" Text="Bankable as at ($):"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDDBankableAsAt" runat="server" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label16" runat="server" ForeColor="#000066" Text="Expected ($):"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDDExpected" runat="server" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="#000066" Text="Total Banked ($):"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTotalDDBanked" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Font-Bold="True" ForeColor="#000066" Text="% Banked:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPerDDBanked" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table border="1">
                            <tr>
                                <td style="background-color:ActiveCaption; border:none" colspan="2">
                                    <asp:Label ID="Label17" runat="server" Font-Bold="True" ForeColor="#000066" Text="Deep Dive Opportunity"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" ForeColor="#000066" Text="Est. Savings($):"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDDOpportunity" ErrorMessage="Improvement is required">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDDOpportunity" runat="server" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" ForeColor="#000066" Text="Banked as at($):"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDDOpporBanked" ErrorMessage="Improvement is required">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDDOpporBanked" runat="server" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label18" runat="server" ForeColor="#000066" Text="Expected ($):"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDDOpporExpected" runat="server" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table border="1">
                            <tr>
                                <td style="background-color:ActiveCaption; border:none" colspan="2">
                                    <asp:Label ID="Label19" runat="server" ForeColor="Green" Text="Efficiency Improvement Opportunity" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" ForeColor="Green" Text="Est. Savings ($):"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEffImprovement" ErrorMessage="Improvement is required">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEffImprovement" runat="server" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label22" runat="server" ForeColor="Green" Text="Actual Savings ($):"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEffImprovementActual" runat="server" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label20" runat="server" ForeColor="Green" Text="Banked ($):"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEffImprovementBanked" ErrorMessage="Improvement is required">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEffImprovementBanked" runat="server" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label21" runat="server" ForeColor="Green" Text="Cost Avoidance ($):"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEIOAvoidance" runat="server" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" ForeColor="Green" Font-Bold="True" Text="% Banked:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPerEIOBanked" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>

            <table class="tMainBorder" style="width: 58%">
                <tr>
                    <td colspan="2">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="All Savings Banked($):"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAllSavingsBanked" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="25% Target Reduction($):" ForeColor="Green"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPercTargetReduction" runat="server" Font-Bold="True" ForeColor="Green"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td><b>%Savings Banked:</b></td>
                                <td>
                                    <asp:Label ID="lblPerSavingsBanked" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Current Gap($) Excluding Oppor.:" ForeColor="Red"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCurrentGap" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="%Savings target:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblPerSavingsTarget" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>


                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label11" runat="server" Font-Bold="true" Text="Cost Savings Comments:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerfDescription" runat="server" Height="100px" TextMode="MultiLine" Width="510px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td><a id="dpeBackLink" href="javascript:history.back()">
                        <asp:HiddenField ID="lCostIdHF" runat="server" />
                    </a></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Width="100px" />
                        &nbsp;&nbsp; <a id="dpeBackLink" href="javascript:history.back()">
                            <asp:Button ID="btnClose" runat="server" Text="Close" ValidationGroup="close" Width="100px" />
                        </a></td>
                </tr>
            </table>
            <app:PartsOpportunities runat="server" ID="PartsOpportunities" />

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>

    <ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender" runat="server" Enabled="True" TargetControlID="UpdatePanel1">
    </ajaxToolkit:UpdatePanelAnimationExtender>

    <asp:UpdateProgress ID="upgAjaxBloc" runat="server" DisplayAfter="100" Visible="true" DynamicLayout="true">
        <ProgressTemplate>
            <div id="IMGDIV" align="center" valign="middle" runat="server" style="position: absolute; visibility: visible; left: 50%; top: 70%; vertical-align: middle; border-color: #FFFFFF; background-color: #FFFFFF;">
                <asp:Image ID="imgAjaxWait" runat="server" ImageUrl="~/Images/ajaxRoller.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

