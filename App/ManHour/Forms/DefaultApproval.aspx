<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterManHour.master" AutoEventWireup="true" CodeFile="DefaultApproval.aspx.cs" Inherits="App_ManHour_Forms_DefaultApproval" %>

<%@ Reference VirtualPath="~/App/ManHour/UserControl/MyInitiatives.ascx" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%--<%@ Register Src="~/App/ManHour/UserControl/oBusinessInitiative.ascx" TagName="oBusinessInitiative" TagPrefix="uc1" %>
<%@ Register Src="~/App/ManHour/UserControl/DistrictFacilitiesOU.ascx" TagName="DistrictFacilitiesOU" TagPrefix="uc2" %>
<%@ Register Src="~/App/ManHour/UserControl/DetailResourceUtilisation.ascx" TagName="DetailResourceUtilisation" TagPrefix="uc3" %>--%>
<%@ Register Src="~/App/ManHour/UserControl/MainReport.ascx" TagName="MainReport" TagPrefix="uc4" %>
<%@ Register Src="~/App/ManHour/UserControl/Report.ascx" TagName="Report" TagPrefix="uc5" %>
<%--<%@ Register Src="~/App/ManHour/UserControl/Approvers.ascx" TagName="Approvers" TagPrefix="uc6" %>--%>
<%@ Register Src="~/App/ManHour/UserControl/ApproveSupport.ascx" TagName="ApproveSupport" TagPrefix="uc7" %>
<%--<%@ Register Src="~/App/ManHour/UserControl/ProjectProgressReport.ascx" TagPrefix="uc1" TagName="ProjectProgressReport" %>--%>
<%@ Register Src="~/App/ManHour/UserControl/StatusMilestoneReport.ascx" TagPrefix="uc1" TagName="StatusMilestoneReport" %>
<%@ Register Src="~/App/ManHour/UserControl/ViewComments.ascx" TagPrefix="uc1" TagName="ViewComments" %>


<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
    <script lang="javascript" type="text/javascript">
        function toggleFade() {
            var behavior = $find('ctl00_SampleContent_MyAccordion_AccordionExtender');
            if (behavior) {
                behavior.set_FadeTransitions(!behavior.get_FadeTransitions());
            }
        }

        function changeAutoSize() {
            var behavior = $find('ctl00_SampleContent_MyAccordion_AccordionExtender');
            var ctrl = $get('autosize');
            if (behavior) {
                var size = 'None';
                switch (ctrl.selectedIndex) {
                    case 0:
                        behavior.get_element().style.height = 'auto';
                        size = Sys.Extended.UI.AutoSize.None;
                        break;
                    case 1:
                        behavior.get_element().style.height = '400px';
                        size = Sys.Extended.UI.AutoSize.Limit;
                        break;
                    case 2:
                        behavior.get_element().style.height = '400px';
                        size = Sys.Extended.UI.AutoSize.Fill;
                        break;
                }
                behavior.set_AutoSize(size);
            }
            if (document.focus) {
                document.focus();
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderCol" runat="Server">
    <ManHr:MyInits ID="MyInitiatives" runat="server" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin-top: 0.2em">
        <div style="width: 60%; float: left">
            <asp:Label ID="lblInitiativeTitle" runat="server" Font-Bold="True" Font-Size="13pt" ForeColor="#003366"></asp:Label>
            <hr />

        </div>
        <div style="width: 35%; float: right; text-align: right; margin-left: 5px">
            <asp:Label runat="server" Font-Bold="True" Font-Size="10pt" ID="lblStatus"></asp:Label>
            <hr />

        </div>
    </div>

    <div style="width: 99%">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="0" Width="100%"
                    HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
                    ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40"
                    TransitionDuration="250" AutoSize="None" RequireOpenedPane="False" SuppressHeaderPostbacks="true">
                    <Panes>
                        <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                            <Header><a href="" class="accordionLink">Approve Initiative</a></Header>
                            <Content>
                                <uc7:ApproveSupport ID="ApproveSupport1" runat="server" />
                            </Content>
                        </ajaxToolkit:AccordionPane>
                        
                        <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                            <Header><a href="" class="accordionLink">View Approval Comments</a></Header>
                            <Content>
                                <uc1:ViewComments runat="server" ID="ViewComments1" />
                            </Content>
                        </ajaxToolkit:AccordionPane>
                        
                        <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                            <Header><a href="" class="accordionLink">Charter Report</a></Header>
                            <Content>
                                <uc4:MainReport ID="MainReport1" runat="server" />
                            </Content>
                        </ajaxToolkit:AccordionPane>
                        
                        <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                            <Header><a href="" class="accordionLink">Utilisation Report</a></Header>
                            <Content>
                                <uc5:Report ID="Report1" runat="server" />
                            </Content>
                        </ajaxToolkit:AccordionPane>
                        
                        <ajaxToolkit:AccordionPane ID="AccordionPane5" runat="server">
                            <Header><a href="" class="accordionLink">Milestone Report</a></Header>
                            <Content>
                                <uc1:StatusMilestoneReport runat="server" ID="StatusMilestoneReport" />
                            </Content>
                        </ajaxToolkit:AccordionPane>
                    </Panes>
                </ajaxToolkit:Accordion>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender" runat="server" Enabled="True" TargetControlID="UpdatePanel1">
    </ajaxToolkit:UpdatePanelAnimationExtender>

    <asp:UpdateProgress ID="upgAjaxBloc" runat="server" DisplayAfter="100" Visible="true" DynamicLayout="true">
        <ProgressTemplate>
            <div id="IMGDIV" align="center" valign="middle" runat="server" style="position: absolute; visibility: visible; left: 50%; top: 70%; vertical-align: middle; border-color: #FFFFFF; background-color: #FFFFFF;">
                <asp:Image ID="imgAjaxWait" runat="server" ImageUrl="~/Images/ajaxRoller.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>





<%--    <div style="color: Black; margin-left: 5px; margin-right: 2px; margin-top: 5px; float: left; width: 98%">
        <asp:UpdatePanel ID="uppAjaxBloc" runat="server">
            <ContentTemplate>
                <ajaxToolkit:TabContainer runat="server" ID="smtAjaxTabs" Width="100%" ActiveTabIndex="0">

                    <ajaxToolkit:TabPanel ID="ApproveSupportTabPanel" runat="server" HeaderText="Awaiting Approval" Width="100%" Visible="true">
                        <HeaderTemplate>Approve Initiative</HeaderTemplate>
                        <ContentTemplate>
                            
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel ID="ViewCommentTabPanel" runat="server" HeaderText="Awaiting Approval" Width="100%" Visible="true">
                        <HeaderTemplate>View Approval Comments</HeaderTemplate>
                        <ContentTemplate>
                            
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="CharterReportTabPanel" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>Charter Report</HeaderTemplate>
                        <ContentTemplate>
                            
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="UtilisationReportTabPanel" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>Utilisation Report</HeaderTemplate>
                        <ContentTemplate>
                            
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel ID="MileStonesTabPanel" runat="server" HeaderText="Project Progress Report" Width="100%" Visible="true">
                        <HeaderTemplate>Milestone Report</HeaderTemplate>
                        <ContentTemplate>
                            
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>



                </ajaxToolkit:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Label runat="server" ID="CurrentTab" />
        <asp:Label runat="server" ID="Messages" />
    </div>--%>
    <br />
    <br />
</asp:Content>


