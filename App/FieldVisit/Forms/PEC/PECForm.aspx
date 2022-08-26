<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master" AutoEventWireup="true" CodeFile="PECForm.aspx.cs" Inherits="SEPCiN_PECForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/App/FieldVisit/UserControl/SEPCiN/personnelInfoDetails.ascx" TagName="personnelInfoDetails" TagPrefix="uc2" %>
<%@ Register Src="~/App/FieldVisit/UserControl/SEPCiN/statusSelectorControl.ascx" TagName="statusSelectorControl" TagPrefix="uc4" %>
<%@ Register Src="~/App/FieldVisit/UserControl/SEPCiN/vendorCallOutInfo.ascx" TagName="vendorCallOutInfo" TagPrefix="uc5" %>
<%@ Register Src="~/App/FieldVisit/UserControl/SEPCiN/personnelInformationList.ascx" TagName="personnelInformationList" TagPrefix="uc6" %>
<%@ Register Src="~/App/FieldVisit/UserControl/SEPCiN/locFieldLocations.ascx" TagName="locFieldLocations" TagPrefix="uc8" %>
<%@ Register Src="~/App/FieldVisit/UserControl/SEPCiN/activityTimeLineSummary.ascx" TagName="activityTimeLineSummary" TagPrefix="uc11" %>
<%@ Register Src="~/App/FieldVisit/UserControl/SEPCiN/activityHeader.ascx" TagName="activityHeader" TagPrefix="uc12" %>
<%@ Register Src="~/App/FieldVisit/UserControl/SEPCiN/Approvers.ascx" TagName="Approvers" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 78px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" />
    <table class="tSubGray" style="width: 100%">
        <tr>
            <td class="cHeadTile">SEPCiN (Offshore/Onshore Assets) Plan Execution Criteria and Change Control Form
            </td>
        </tr>
        <tr>
            <td>
                <div style="color: Black; width: 100%; text-align: left">

                    <asp:UpdatePanel ID="uppAjaxBloc" runat="server">
                        <ContentTemplate>
                            <ajaxToolkit:TabContainer ID="smtAjaxTabs" runat="server" ActiveTabIndex="0" Width="100%">
                                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Awaiting Approval" Visible="true">
                                    <HeaderTemplate>
                                        Activity Information
                                    </HeaderTemplate>

                                    <ContentTemplate>
                                        <uc12:activityHeader ID="activityHeader1" runat="server"></uc12:activityHeader>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>

                                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Awaiting Approval" Visible="true">
                                    <HeaderTemplate>
                                        Plan Execution Criteria
                                    </HeaderTemplate>

                                    <ContentTemplate>
                                        <uc8:locFieldLocations ID="locFieldLocations1" runat="server"></uc8:locFieldLocations>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>

                                <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Awaiting Approval" Visible="true">
                                    <HeaderTemplate>
                                        Vendor Call Out
                                    </HeaderTemplate>

                                    <ContentTemplate>
                                        <uc5:vendorCallOutInfo ID="vendorCallOutInfo1" runat="server"></uc5:vendorCallOutInfo>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>

                                <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="Awaiting Approval" Visible="true">
                                    <HeaderTemplate>
                                        Personnel Information
                                    </HeaderTemplate>

                                    <ContentTemplate>
                                        <uc6:personnelInformationList ID="personnelInformationList1" runat="server"></uc6:personnelInformationList>
                                        <uc2:personnelInfoDetails ID="personnelInfoDetails1" runat="server"></uc2:personnelInfoDetails>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>

                                <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="Awaiting Approval" Visible="true">
                                    <HeaderTemplate>
                                        Activity Timeline
                                    </HeaderTemplate>

                                    <ContentTemplate>
                                        <uc11:activityTimeLineSummary ID="activityTimeLineSummary1" runat="server"></uc11:activityTimeLineSummary>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>

                                <ajaxToolkit:TabPanel ID="TabPanel6" runat="server" HeaderText="Awaiting Approval" Visible="true">
                                    <HeaderTemplate>
                                        Plan Entry Approval
                                    </HeaderTemplate>

                                    <ContentTemplate>
                                        <uc3:Approvers ID="Approvers1" runat="server"></uc3:Approvers>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>

                            </ajaxToolkit:TabContainer>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:Label runat="server" ID="CurrentTab" />
                    <asp:Label runat="server" ID="Messages" />
                </div>

            </td>
        </tr>
    </table>
    <asp:HiddenField ID="ActivityIDHF" runat="server" />
</asp:Content>
