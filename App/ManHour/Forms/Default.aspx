<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterManHour.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Forms_Default" %>

<%@ Reference VirtualPath="~/App/ManHour/UserControl/MyInitiatives.ascx" %>
<%@ Register Src="~/App/ManHour/UserControl/oBusinessInitiative.ascx" TagName="oBusinessInitiative" TagPrefix="uc1" %>
<%@ Register Src="~/App/ManHour/UserControl/DistrictFacilitiesOU.ascx" TagName="DistrictFacilitiesOU" TagPrefix="uc2" %>
<%@ Register Src="~/App/ManHour/UserControl/DetailResourceUtilisation.ascx" TagName="DetailResourceUtilisation" TagPrefix="uc3" %>
<%@ Register Src="~/App/ManHour/UserControl/MainReport.ascx" TagName="MainReport" TagPrefix="uc4" %>
<%@ Register Src="~/App/ManHour/UserControl/Report.ascx" TagName="Report" TagPrefix="uc5" %>
<%@ Register Src="~/App/ManHour/UserControl/Approvers.ascx" TagName="Approvers" TagPrefix="uc6" %>
<%@ Register Src="~/App/ManHour/UserControl/ApproveSupport.ascx" TagName="ApproveSupport" TagPrefix="uc7" %>
<%@ Register Src="~/App/ManHour/UserControl/ProjectProgressReport.ascx" TagPrefix="uc1" TagName="ProjectProgressReport" %>
<%@ Register Src="~/App/ManHour/UserControl/StatusMilestoneReport.ascx" TagPrefix="uc1" TagName="StatusMilestoneReport" %>
<%@ Register Src="~/App/ManHour/UserControl/ViewComments.ascx" TagPrefix="uc1" TagName="ViewComments" %>

<%--<asp:Content ID="Content3" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderCol" runat="Server">
    <%--<ajaxToolkit:ToolkitScriptManager ID="AjxMgr" runat="Server" ScriptMode="Release" CombineScripts="true">
    </ajaxToolkit:ToolkitScriptManager>--%>
    <ManHr:MyInits ID="MyInitiatives" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin-top: 0.2em; margin-left: 1.5em">
        <div style="width: 60%; float: left">
            <asp:Label ID="lblInitiativeTitle" runat="server" Font-Bold="True" Font-Size="13pt" ForeColor="#003366"></asp:Label>
            <hr />
        </div>
        <div style="width: 35%; float: right; text-align: right; margin-left: 5px">
            <asp:Label runat="server" Font-Bold="True" Font-Size="10pt" ID="lblStatus"></asp:Label>
            <hr />
        </div>
    </div>
    
    <div style="color: Black; margin-left: 1.5em; margin-right: 2px; margin-top: 5px; float: left; width: 98%">
        <asp:UpdatePanel ID="uppAjaxBloc" runat="server">
            <ContentTemplate>
                <ajaxToolkit:TabContainer runat="server" ID="smtAjaxTabs" Width="100%" ActiveTabIndex="0">
                    <ajaxToolkit:TabPanel runat="server" ID="pnlBusinessInitiative" HeaderText="Awaiting Approval" Width="100%" Visible="true">
                        <HeaderTemplate>Project Charter</HeaderTemplate>
                        <ContentTemplate>
                            <div>
                                <uc1:oBusinessInitiative ID="oBusinessInitiative1" runat="server"></uc1:oBusinessInitiative>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="pnlDistrict" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>Assets Impacted</HeaderTemplate>
                        <ContentTemplate>
                            <uc2:DistrictFacilitiesOU ID="DistrictFacilitiesOU1" runat="server" >
                            </uc2:DistrictFacilitiesOU>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="pnlResourceUtilisation" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>Resource Utilisation</HeaderTemplate>
                        <ContentTemplate>
                            <uc3:DetailResourceUtilisation ID="DetailResourceUtilisation" runat="server" />
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel ID="progressTabPanel" runat="server" HeaderText="Project Status" Width="100%" Visible="true">
                        <HeaderTemplate>Status/Milestone</HeaderTemplate>
                        <ContentTemplate>
                            <uc1:ProjectProgressReport runat="server" ID="ProjectProgressReport" />
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="BITabPanel" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>Charter Report</HeaderTemplate>
                        <ContentTemplate>
                            <uc4:MainReport ID="MainReport1" runat="server" />
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="grapReportTabPanel" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>Utilisation Report</HeaderTemplate>
                        <ContentTemplate>
                            <uc5:Report ID="Report1" runat="server" />
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Project Progress Report" Width="100%" Visible="true">
                        <HeaderTemplate>Milestone Report</HeaderTemplate>
                        <ContentTemplate>
                            <uc1:StatusMilestoneReport runat="server" ID="StatusMilestoneReport" />
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel ID="approvalTabPanel" runat="server" HeaderText="Awaiting Approval" Width="100%" Visible="true">
                        <HeaderTemplate>Send for Approval</HeaderTemplate>
                        <ContentTemplate>
                            <uc6:Approvers runat="server" ID="Approvers"></uc6:Approvers>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel ID="ApproveSupportTabPanel" runat="server" HeaderText="Awaiting Approval" Width="100%" Visible="true">
                        <HeaderTemplate>Approve Initiative</HeaderTemplate>
                        <ContentTemplate>
                            <uc7:ApproveSupport ID="ApproveSupport1" runat="server" />
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Awaiting Approval" Width="100%" Visible="true">
                        <HeaderTemplate>View Approval Comments</HeaderTemplate>
                        <ContentTemplate>
                            <uc1:ViewComments runat="server" ID="ViewComments1" />
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                </ajaxToolkit:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Label runat="server" ID="CurrentTab" />
        <asp:Label runat="server" ID="Messages" />
    </div>
    <br />
    <br />
    <br />
    <br />
</asp:Content>
