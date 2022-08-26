<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CostReduction.master" AutoEventWireup="true" CodeFile="CostReductionForMyAction.aspx.cs" Inherits="App_BI500_CostReductionForMyAction" %>

<%@ Register Src="~/UserControls/userFinder/Search4LocalUser.ascx" TagName="Search4LocalUser" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/userFinder/Search4User.ascx" TagName="Search4User" TagPrefix="uc3" %>


<%@ Register Src="UserControl/Cost/oRequestsPendingMyAction.ascx" TagName="oRequestsPendingMyAction" TagPrefix="uc4" %>
<%@ Register Src="UserControl/Cost/oRequestsIApproved.ascx" TagName="oRequestsIApproved" TagPrefix="uc5" %>
<%@ Register Src="UserControl/Cost/oRequestDetails.ascx" TagName="oRequestDetails" TagPrefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="server" ScriptMode="Release"></ajaxToolkit:ToolkitScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:Wizard ID="Wizard1" runat="server" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" DisplaySideBar="false" Width="99%" Height="90%" ActiveStepIndex="0" OnFinishButtonClick="OnFinish">

                 <HeaderTemplate>
                    <ul id="wizHeader">
                        <asp:Repeater ID="SideBarList" runat="server">
                            <ItemTemplate>
                                <li>
                                    <asp:LinkButton runat="server" ID="SideBarButton" Font-Bold="true" OnClick="Step_Click"
                                        CssClass='<%# GetClassForWizardStep(Container.DataItem) %>' Text='<%# Eval("Name")%>'><%# Eval("Name")%></asp:LinkButton>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </HeaderTemplate>

                <StartNavigationTemplate>
                    <asp:LinkButton CommandName="MoveNext" ID="StartNextButton" runat="server" Text="Next" />
                </StartNavigationTemplate>

                <StepNavigationTemplate>
                    <asp:LinkButton CausesValidation="False" CommandName="MovePrevious" ID="StepPreviousButton" runat="server" Text="Previous" />
                    <asp:LinkButton CommandName="MoveNext" ID="StepNextButton" runat="server" Text="Next" />
                </StepNavigationTemplate>

                <FinishNavigationTemplate>
                    <asp:LinkButton CausesValidation="False" CommandName="Finish" ID="FinishButton" runat="server" Text="Finish" />
                </FinishNavigationTemplate>

                <WizardSteps>
                    <asp:WizardStep runat="server" ID="Pending" Title="Pending My Action" StepType="Auto">
                        <fieldset>
                            <legend style="font: bold; font-size: 1.0em">Cost Reduction Ideas For My Action</legend>
                            <div style="height: 70%;" class="content">
                                <div style="height: 100%; overflow: auto;">
                                    <uc4:oRequestsPendingMyAction ID="oRequestsPendingMyAction1" runat="server" />
                                </div>
                            </div>
                        </fieldset>
                    </asp:WizardStep>

                    <asp:WizardStep runat="server" ID="Supported" Title="Supported" StepType="Auto">
                        <fieldset>
                            <legend style="font: bold; font-size: 1.0em">Approved Cost Reduction Ideas</legend>
                            <div style="height: 100%;" class="content">
                                <div style="height: 95%; overflow: auto;">
                                    <uc5:oRequestsIApproved ID="oRequestsIApproved1" runat="server" />
                                </div>
                            </div>
                        </fieldset>
                    </asp:WizardStep>

                    <asp:WizardStep runat="server" ID="Rejected" Title="Rejected" StepType="Auto">
                        <fieldset>
                            <legend style="font: bold; font-size: 1.0em">Rejected Cost Reduction Ideas</legend>
                            <div style="height: 100%;" class="content">
                                <div style="height: 95%; overflow: auto;">
                                    ....
                                </div>
                            </div>
                        </fieldset>
                    </asp:WizardStep>

                    <asp:WizardStep runat="server" Title="Project Progress" ID="RequestDetails" StepType="Auto">
                        <fieldset>
                            <legend style="font: bold; font-size: 1.0em">Cost Reduction Idea Progress...</legend>
                            <div style="height: 100%; font-size: 1.5em" class="content">
                                <div style="height: 95%; overflow: auto;">
                                    <uc1:oRequestDetails runat="server" ID="oRequestDetails1" />
                                </div>
                            </div>
                        </fieldset>
                    </asp:WizardStep>

                    <asp:WizardStep runat="server" Title="Assign Focal Point" ID="WizFocalPoint" StepType="Auto">
                        <fieldset>
                            <legend style="font: bold; font-size: 1.0em">Assign Project to Function/Department Focal Point</legend>
                            <hr />
                            <div style="height: 70%;" class="content">
                                <div style="height: 100%; overflow: auto;">
                                    <table class="tMainBorder" style="width:80%; margin-left:5em">
                                        <tr>
                                            <td class="cHeadTile" colspan="2">
                                                <asp:Label ID="Label4" runat="server" ForeColor="Red" Font-Bold="true" Text="Click Yes or No button to move project to focal point"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:300px"><strong>Push to Focal Point?</strong></td>
                                            <td>
                                                <asp:RadioButtonList ID="rblPushYesNo" RepeatDirection="Horizontal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblPushYesNo_SelectedIndexChanged">
                                                </asp:RadioButtonList>
                                                <asp:HiddenField ID="HFRequestIdFP" runat="server" />
                                            </td>

                                        </tr>
                                    </table>
                                    <asp:Panel ID="PnlNo" runat="server">
                                        <table class="tMainBorder" style="width:80%; margin-left:5em">
                                            <tr>
                                                <td style="width:300px"><strong>Reason why not going forward:<br />
                                                </strong>
                                                    <span class="auto-style1"><em>(Note: an email notification
                                                    <br />
                                                        will go to the Initiator why this<br />
                                                        Cost Reduction Idea can not be
                                                    <br />
                                                        progressed.)</em></span></td>
                                                <td>
                                                    <asp:TextBox ID="txtMaintainInDatabase" runat="server" Height="100px" TextMode="MultiLine" Width="602px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="maintain" />
                                                    &nbsp;<asp:Button ID="btnClose0" runat="server" OnClick="btnClose_Click" Text="Close" ValidationGroup="maintain" />
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="PnlYes" runat="server">
                                        <table class="tMainBorder" style="width:80%; margin-left:5em">
                                            <tr>
                                                <td style="width:300px">
                                                    <asp:Label ID="Label2" runat="server" Text="Function/Department Focal Point:"></asp:Label>
                                                </td>
                                                <td>
                                                    <uc1:Search4LocalUser ID="FocalPoint" runat="server" />
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" Text="Comments:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCommentFP" runat="server" Height="100px" TextMode="MultiLine" Width="602px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">&nbsp;&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="AssignFocalPoint" runat="server" OnClick="AssignFocalPoint_Click" Text="Assign Focal Point" Width="165px" />
                                                    &nbsp;<asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Close" ValidationGroup="close" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <hr />
                                    <div style="font-size: 1.5em">
                                        <uc1:oRequestDetails runat="server" ID="oRequestDetails3" />
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </asp:WizardStep>

                    <asp:WizardStep runat="server" Title="Assign Approvers" ID="AssignApprovers" StepType="Auto">
                        <fieldset>
                            <legend style="font: bold; font-size: 1.0em">Assign Initiative Lead, Work Stream Owner and Work Stream Sponsor</legend>
                            <div style="height: 70%;" class="content">
                                <div style="height: 100%; overflow: auto;">

                                    <table class="tMainBorder" style="width:80%">
                                        <tr>
                                            <td class="cHeadTile" colspan="2">
                                                <asp:Label ID="Label7" runat="server" ForeColor="Red" Font-Bold="true" Text="Click Yes or No button to progress..."></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:300px"><strong>Approved at cadence review meeting?</strong></td>
                                            <td>
                                                <asp:RadioButtonList ID="rblApprovedYesNo" RepeatDirection="Horizontal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblApprovedYesNo_SelectedIndexChanged">
                                                </asp:RadioButtonList>
                                                <asp:HiddenField ID="HFRequestId2" runat="server" />
                                            </td>
                                        </tr>
                                    </table>

                                    <asp:Panel ID="PnlCadenceNo" runat="server">
                                        <table class="tMainBorder" style="width:80%">
                                            <tr>
                                                <td style="width:300px"><strong>Reason why not going forward:<br />
                                                </strong>
                                                    <span class="auto-style1"><em>(Note: an email notification
                                                    <br />
                                                        will go to the Initiator why this<br />
                                                        Cost Reduction Idea can not be
                                                    <br />
                                                        progressed.)</em></span></td>
                                                <td>
                                                    <asp:TextBox ID="txtCadenceComment" runat="server" Height="100px" TextMode="MultiLine" Width="602px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="btnCadence" runat="server" Text="Submit" OnClick="btnCadence_Click" ValidationGroup="cadence" />
                                                    &nbsp;<asp:Button ID="btnCloseCadence" runat="server" OnClick="btnClose_Click" Text="Close" ValidationGroup="cadence" />
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="PnlCadenceYes" runat="server">
                                        <table class="tMainBorder" style="width:80%">
                                            <tr>
                                                <td style="width:300px">
                                                    <asp:Label ID="Label11" runat="server" Text="Initiative Lead:"></asp:Label>
                                                </td>
                                                <td>
                                                    <uc1:Search4LocalUser ID="InitiativeLead" runat="server" />
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width:300px">
                                                    <asp:Label ID="Label5" runat="server" Text="Work Stream Owner:"></asp:Label>
                                                </td>
                                                <td>
                                                    <uc1:Search4LocalUser ID="champion" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width:300px">
                                                    <asp:Label ID="Label6" runat="server" Text="Work Stream Sponsor:"></asp:Label>
                                                </td>
                                                <td>
                                                    <uc1:Search4LocalUser ID="Sponsor" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Comments:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtComments" runat="server" Height="100px" TextMode="MultiLine" Width="600px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <asp:Button ID="Assign" runat="server" OnClick="Assign_Click" Text="Assign Approvers" Width="165px" />
                                                    &nbsp;<asp:Button ID="Close2" runat="server" OnClick="btnClose_Click" Text="Close" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <hr />
                                    <div style="font-size: 1.5em">
                                        <uc1:oRequestDetails runat="server" ID="oRequestDetails2" />
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </asp:WizardStep>

                    <asp:WizardStep runat="server" Title="Commitment Form" ID="ProjMgrsCommitment" StepType="Auto">
                        <fieldset>
                            <legend style="font: bold; font-size: 1.0em">WorkStream Sponsor&#39;s/Champion&#39;s Commitment Form</legend>
                            <div style="height: 100%; font-size: 1.5em" class="content">
                                <div style="height: 95%; overflow: auto;">
                                    <table class="tMainBorder" style="width:80%; margin-left:5em">
                                        <tr>
                                            <td class="cHeadTile" colspan="2">
                                                <asp:Label ID="Label8" runat="server" ForeColor="Red" Font-Bold="true" Text="Click Yes or No button to progress..."></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:300px">
                                                <asp:Label ID="lblCommitYesNo" runat="server" Text="Committed?:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rblToProjectChampionYesNo" RepeatDirection="Horizontal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblToProjectChampion_SelectedIndexChanged">
                                                </asp:RadioButtonList>
                                                <asp:HiddenField ID="HFRequestIdProjCommitment" runat="server" />
                                            </td>

                                        </tr>
                                    </table>
                                    <asp:Panel ID="PnlSponsorCommitNo" runat="server">
                                        <table class="tMainBorder" style="width:80%; margin-left:5em">
                                            <tr>
                                                <td style="width:300px"><strong>Reason why not going forward:<br />
                                                </strong>
                                                    <span class="auto-style1"><em>(Note: an email notification
                                                    <br />
                                                        will go to the Initiator why this<br />
                                                        Cost Reduction Idea can not be
                                                    <br />
                                                        progressed.)</em></span></td>
                                                <td>
                                                    <asp:TextBox ID="txtSponsorMaintain" runat="server" Height="100px" TextMode="MultiLine" Width="602px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <td colspan="2"></td>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="btnSponsorMaintain" runat="server" Text="Submit" OnClick="btnSponsorMaintain_Click" ValidationGroup="maintain" />
                                                    &nbsp;<asp:Button ID="Button2" runat="server" OnClick="btnClose_Click" Text="Close" ValidationGroup="maintain" />
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>

                                    <asp:Panel ID="PnlSponsorCommitYes" runat="server">
                                        <table class="tMainBorder" style="width:80%; margin-left:5em">
                                            <tr>
                                                <td style="width:300px">&nbsp;</td>
                                                <td colspan="4">&nbsp;&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width:300px">
                                                    <asp:Label ID="Label3" runat="server" Text="Comments:"></asp:Label>
                                                </td>
                                                <td colspan="4">
                                                    <asp:TextBox ID="txtSponsorComments" runat="server" Height="100px" TextMode="MultiLine" Width="600px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td colspan="4">
                                                    <asp:Button ID="btnSendToChampion" runat="server" OnClick="btnSendToChampion_Click" Text="Submit" />
                                                    &nbsp;<asp:Button ID="Button4" runat="server" OnClick="btnClose_Click" Text="Close" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>

                                    <hr />
                                    <div style="font-size: 1.5em">
                                        <uc1:oRequestDetails runat="server" ID="oRequestDetailsProjCommit" />
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </asp:WizardStep>
                </WizardSteps>

                <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" ForeColor="White" />
                <SideBarStyle BackColor="#507CD1" Font-Size="1.3em" Width="15%" VerticalAlign="Top" />

                <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="1.0em" ForeColor="#284E98" />
                <HeaderStyle BackColor="#284E98" Font-Bold="True" Font-Size="1.5em" ForeColor="White" HorizontalAlign="Center" />

            </asp:Wizard>

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

<asp:Content ID="Content4" runat="server" ContentPlaceHolderID="headId">
    <style type="text/css">
        .auto-style1 {
            color: red;
        }
    </style>
</asp:Content>


