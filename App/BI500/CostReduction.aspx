<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CostReduction.master" AutoEventWireup="true" CodeFile="CostReduction.aspx.cs" Inherits="App_BI500_CostReduction" %>

<%@ Register Src="~/UserControls/userFinder/Search4LocalUser.ascx" TagName="Search4LocalUser" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/userFinder/Search4User.ascx" TagName="Search4User" TagPrefix="uc3" %>

<%@ Register Src="UserControl/Cost/oPendingRequest.ascx" TagName="oPendingRequest" TagPrefix="uc4" %>
<%@ Register Src="UserControl/Cost/oApprovedRequest.ascx" TagName="oApprovedRequest" TagPrefix="uc5" %>
<%@ Register Src="UserControl/Cost/oRequestDetails.ascx" TagName="oRequestDetails" TagPrefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="server" ScriptMode="Release"></ajaxToolkit:ToolkitScriptManager>

    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>

            <asp:Wizard ID="Wizard1" runat="server" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" DisplaySideBar="false"
                Width="100%" Height="90%" ActiveStepIndex="0" Font-Size="80%" OnFinishButtonClick="OnFinish">
                <%--<StepStyle Font-Size="1.0em" ForeColor="#333333" />--%>

                <HeaderTemplate>
                    <ul id="wizHeader">
                        <asp:Repeater ID="SideBarList" runat="server">
                            <ItemTemplate>
                                <li>
                                    <%--<a class="<%# GetClassForWizardStep(Container.DataItem) %>" title="<%#Eval("Name")%>"><%# Eval("Name")%></a>--%>
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
                    <asp:WizardStep runat="server" ID="Pending" Title="Pending Improvement Ideas" StepType="Auto">
                        <fieldset>
                            <%--<legend style="font: bold; font-size: 1.0em">Pending Cost Improvement Ideas</legend>--%>
                            <div style="height: 70%;" >
                                <div style="height: 100%; overflow: auto;">
                                    <uc4:oPendingRequest ID="oPendingRequest1" runat="server" />
                                </div>
                            </div>
                        </fieldset>
                    </asp:WizardStep>

                    <asp:WizardStep runat="server" ID="Approved" Title="Approved Improvement Ideas" StepType="Auto">
                        <fieldset>
                            <%--<legend style="font: bold; font-size: 1.0em">Approved Cost Reduction Ideas</legend>--%>
                            <div style="height: 100%;" class="content">
                                <div style="height: 95%; overflow: auto;">
                                    <uc5:oApprovedRequest ID="oApprovedRequest1" runat="server" />
                                </div>
                            </div>
                        </fieldset>
                    </asp:WizardStep>

                    <asp:WizardStep runat="server" ID="Rejected" Title="Rejected Improvement Ideas" StepType="Auto">
                        <fieldset>
                            <%--<legend style="font: bold; font-size: 1.0em">Rejected Cost Reduction Ideas</legend>--%>
                            <div style="height: 100%;" class="content">
                                <div style="height: 95%; overflow: auto;">
                                </div>
                            </div>
                        </fieldset>
                    </asp:WizardStep>

                    <asp:WizardStep runat="server" Title="Project Progress" ID="RequestDetails" StepType="Auto">
                        <fieldset>
                            <%--<legend style="font: bold; font-size: 1.0em">Cost Reduction Idea Progress...</legend>--%>
                            <div style="height: 100%; font-size: 1.5em" class="content">
                                <div style="height: 95%; overflow: auto;">
                                    <uc1:oRequestDetails runat="server" ID="oRequestDetails1" />
                                </div>
                            </div>
                        </fieldset>
                    </asp:WizardStep>

                    <%--<asp:WizardStep runat="server" Title="Assign Focal Point" ID="WizFocalPoint" StepType="Auto">
                        <fieldset>
                            <%--<legend style="font: bold; font-size: 1.0em">Assign Project to Function/Department Focal Point</legend>
                            <hr />
                            <div style="height: 70%;" class="content">
                                <div style="height: 100%; overflow: auto;">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="Function/Department Focal Point:"></asp:Label>
                                            </td>
                                            <td>
                                                <uc1:Search4LocalUser ID="FocalPoint" runat="server" />
                                            </td>

                                            <td>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="Label10" runat="server" Text="Comments:"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtCommentFP" TextMode="MultiLine" Height="100px" runat="server" Width="600px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:HiddenField ID="HFRequestIdFP" runat="server" />
                                            </td>
                                            <td colspan="4">
                                                <asp:Button ID="AssignFocalPoint" runat="server" OnClick="AssignFocalPoint_Click" Text="Assign Focal Point" Width="165px" />
                                            </td>
                                        </tr>
                                    </table>
                                    <hr />
                                    <div style="font-size: 1.5em">
                                        <uc1:oRequestDetails runat="server" ID="oRequestDetails3" />
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </asp:WizardStep>

                    <asp:WizardStep runat="server" Title="Assign Project Champion and Sponsor" ID="AssignApprovers" StepType="Auto">
                        <fieldset>
                            <%--<legend style="font: bold; font-size: 1.0em">Assign Project Champion and Sponsor</legend>
                            <hr />
                            <div style="height: 70%;" class="content">
                                <div style="height: 100%; overflow: auto;">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="Project Champion:"></asp:Label>
                                            </td>
                                            <td>
                                                <uc1:Search4LocalUser ID="champion" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Text="Project Sponsor:"></asp:Label>
                                            </td>
                                            <td>
                                                <uc1:Search4LocalUser ID="Sponsor" runat="server" />
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="Comments:"></asp:Label>
                                            </td>
                                            <td colspan="4">
                                                <asp:TextBox ID="txtComments" TextMode="MultiLine" Height="100px" runat="server" Width="600px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:HiddenField ID="HFRequestId2" runat="server" />
                                            </td>
                                            <td colspan="4">
                                                <asp:Button ID="Assign" runat="server" OnClick="Assign_Click" Text="Assign Approvers" Width="165px" />
                                            </td>
                                        </tr>
                                    </table>
                                    <hr />
                                    <div style="font-size: 1.5em">
                                        <uc1:oRequestDetails runat="server" ID="oRequestDetails2" />
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </asp:WizardStep>--%>
                </WizardSteps>

                <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" ForeColor="White" />
                <SideBarStyle BackColor="#507CD1" Font-Size="1.3em" Width="15%" VerticalAlign="Top" />

                <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="1.0em" ForeColor="#284E98" />
                <HeaderStyle BackColor="#284E98" Font-Bold="True" Font-Size="1.8em" ForeColor="White" HorizontalAlign="Center" />

            </asp:Wizard>

        <%--</ContentTemplate>
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
    </asp:UpdateProgress>--%>

</asp:Content>

