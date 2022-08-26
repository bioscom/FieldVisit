<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/14DayContract.master" AutoEventWireup="true" CodeFile="Start14DayContract.aspx.cs" Inherits="App_Contract_Start14DayContract" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register src="UserControls/KpiInput.ascx" tagname="KpiInput" tagprefix="uc3" %>
<%@ Register src="UserControls/Start14DaysContract.ascx" tagname="Start14DaysContract" tagprefix="uc2" %>

<%@ Register Src="UserControls/ActivityChange.ascx" TagName="ActivityChange" TagPrefix="uc3" %>
<%@ Register Src="UserControls/BusinessImprovement.ascx" TagName="BusinessImprovement" TagPrefix="uc4" %>
<%@ Register Src="UserControls/LessonLearnt.ascx" TagName="LessonLearnt" TagPrefix="uc5" %>
<%@ Register Src="../../UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>
<%@ Register Src="UserControls/DailyDataInputForm.ascx" TagName="DailyDataInputForm" TagPrefix="uc6" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true" ScriptMode="Release"></ajaxToolkit:ToolkitScriptManager>
    <script type="text/javascript" src="JavaScript/fieldVisit.js"></script>
    
    
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc2:Start14DaysContract ID="Start14DaysContract1" runat="server" />
            <uc3:KpiInput ID="KpiInput1" runat="server" />
            <br /><br />
        </ContentTemplate>
    </asp:UpdatePanel>--%>


    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div style="  text-align:center; font: bold; color:RED">
                <asp:LinkButton ID="actionLnk" runat="server">Click here to approve this 14 Days Contract</asp:LinkButton>
            </div> 
            
            <ajaxToolkit:TabContainer ID="smtAjaxTabs" runat="server" ActiveTabIndex="0" Width="99%">

                <ajaxToolkit:TabPanel ID="pnlRequests" runat="server" HeaderText="14 Day Contract Data Input" Visible="true">
                    <HeaderTemplate>
                        Data Input
                    </HeaderTemplate>

                    <ContentTemplate>
                        <uc3:KpiInput ID="KpiInput1" runat="server" />
                    </ContentTemplate>

                </ajaxToolkit:TabPanel>

                <ajaxToolkit:TabPanel ID="pnlApprovedRequests" runat="server" HeaderText="What Why Consequences" Visible="true">
                    <HeaderTemplate>
                        What Why Consequences
                    </HeaderTemplate>

                    <ContentTemplate>
                        <div style="overflow: auto">
                            <table class="tMainBorder" style="width: 100%">
                                <tr>
                                    <td class="cHeadTile" colspan="2">OPERATIONS SUPERINTENDENT 14 DAY CONTRACT</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Trip Start Date:"></asp:Label>
                                    </td>
                                    <td>
                                        <uc2:dateControl ID="dtTripStart2" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <uc3:ActivityChange ID="ActivityChange1" runat="server" />
                                        <uc4:BusinessImprovement ID="BusinessImprovement1" runat="server" />
                                        <uc5:LessonLearnt ID="LessonLearnt1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>

            </ajaxToolkit:TabContainer>

            <asp:Panel ID="pnlModalPanelAffiliate" runat="server" Style="display: none; width: 500px" CssClass="modalPopup">
                <asp:Panel ID="pnlDragPanelAffiliate" runat="server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black">
                    +
                </asp:Panel>

                <table class="tMainBorder" style="width: 490px">
                    <tr>
                        <td class="cHeadTile" colspan="2">Operation Manager&#39;s Approval</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Stand:"></asp:Label>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlStand" ErrorMessage="Your stand is required" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStand" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Comments:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtComments" runat="server" Height="100px" TextMode="MultiLine" Width="350px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="submitApprovalButton" runat="server" Text="Submit" OnClick="txtApprove_Click" ValidationGroup="APPROVAL" Width="100px" />
                            &nbsp;
                <asp:Button ID="approvalClose" runat="server" Text="Close" ValidationGroup="xxxx" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="APPROVAL" ShowMessageBox="True" ShowSummary="False" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>

            <%--The Modal Popup codes ends here--%>

            <ajaxToolkit:ModalPopupExtender ID="AffiliateMPE" runat="server"
                BackgroundCssClass="modalBackground" CancelControlID="affiliateClose"
                DropShadow="true" PopupControlID="pnlModalPanelAffiliate"
                PopupDragHandleControlID="pnlDragPanelAffiliate" TargetControlID="actionLnk" />

        </ContentTemplate>

    </asp:UpdatePanel>

    <ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender" runat="server" Enabled="True" TargetControlID="UpdatePanel1">
    </ajaxToolkit:UpdatePanelAnimationExtender>

    <asp:UpdateProgress ID="upgAjaxBloc" runat="server" DisplayAfter="100" Visible="true" DynamicLayout="true">
        <ProgressTemplate>
            <div id="IMGDIV" align="center" valign="middle" runat="server" style="position: absolute; visibility: visible; left: 50%; top: 55%; vertical-align: middle; border-color: #FFFFFF; background-color: #FFFFFF;">
                <asp:Image ID="imgAjaxWait" runat="server" ImageUrl="~/Images/ajaxRoller.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>

