<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CostReduction.master" AutoEventWireup="true" CodeFile="CostReductionMyIdeas.aspx.cs" Inherits="App_BI500_CostReductionMyIdeas" %>

<%@ Register Src="~/UserControls/userFinder/Search4LocalUser.ascx" TagName="Search4LocalUser" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/userFinder/Search4User.ascx" TagName="Search4User" TagPrefix="uc3" %>


<%@ Register Src="UserControl/Cost/oMyPendingRequests.ascx" TagName="oMyPendingRequests" TagPrefix="uc4" %>
<%@ Register Src="UserControl/Cost/oMyApprovedRequests.ascx" TagName="oMyApprovedRequests" TagPrefix="uc5" %>
<%@ Register Src="UserControl/Cost/oRequestDetails.ascx" TagName="oRequestDetails" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="server" ScriptMode="Release"></ajaxToolkit:ToolkitScriptManager>

    

            <asp:Wizard ID="Wizard1" runat="server" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" DisplaySideBar="false" Width="98%" Height="90%" ActiveStepIndex="0" OnFinishButtonClick="OnFinish">
                <%--<StepStyle Font-Size="1.0em" ForeColor="#333333" />--%>

                <WizardSteps>
                    <asp:WizardStep runat="server" ID="Pending" Title="My Pending Improvement Ideas" StepType="Auto">
                        <fieldset>
                            <legend style="font: bold; font-size: 1.0em">My Pending Cost Reduction Ideas</legend>
                            <div style="height: 70%;" class="content">
                                <div style="height: 100%; overflow: auto;">
                                    <uc4:oMyPendingRequests ID="oMyPendingRequests1" runat="server" />
                                </div>
                            </div>
                        </fieldset>
                    </asp:WizardStep>

                    <asp:WizardStep runat="server" ID="Approved" Title="My Approved Improvement Ideas" StepType="Auto">
                        <fieldset>
                            <legend style="font: bold; font-size: 1.0em">My Approved Cost Reduction Ideas</legend>
                            <div style="height: 100%;" class="content">
                                <div style="height: 95%; overflow: auto;">
                                    <uc5:oMyApprovedRequests ID="oMyApprovedRequests1" runat="server" />
                                </div>
                            </div>
                        </fieldset>
                    </asp:WizardStep>

                    <asp:WizardStep runat="server" ID="Rejected" Title="My Rejected Improvement Ideas" StepType="Auto">
                        <fieldset>
                            <legend style="font: bold; font-size: 1.0em">My Rejected Cost Reduction Ideas</legend>
                            <div style="height: 100%;" class="content">
                                <div style="height: 95%; overflow: auto;">
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

                </WizardSteps>

                <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" ForeColor="White" />
                <SideBarStyle BackColor="#507CD1" Font-Size="1.3em" Width="15%" VerticalAlign="Top" />

                <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="1.0em" ForeColor="#284E98" />
                <HeaderStyle BackColor="#284E98" Font-Bold="True" Font-Size="1.5em" ForeColor="White" HorizontalAlign="Center" />

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

            </asp:Wizard>

    <asp:UpdateProgress ID="upgAjaxBloc" runat="server" DisplayAfter="100" Visible="true" DynamicLayout="true">
        <ProgressTemplate>
            <div id="IMGDIV" align="center" valign="middle" runat="server" style="position: absolute; visibility: visible; left: 50%; top: 70%; vertical-align: middle; border-color: #FFFFFF; background-color: #FFFFFF;">
                <asp:Image ID="imgAjaxWait" runat="server" ImageUrl="~/Images/ajaxRoller.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

