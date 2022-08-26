<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master" AutoEventWireup="true" CodeFile="PECForm.aspx.cs" Inherits="SEPCiN_edt_PECForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" />
    <table class="tSubGray" style="width: 99%">
        <tr>
            <td class="cHeadTile">SEPCiN (Offshore/Onshore Assets) Plan Execution Criteria and Change Control Form
            </td>
        </tr>
        <tr>
            <td>
                <div style="color: Black; width: 100%; text-align: left">
                    <asp:UpdatePanel ID="uppAjaxBloc" runat="server">
                        <ContentTemplate>
                            <ajaxToolkit:TabContainer ID="smtAjaxTabs" runat="server" ActiveTabIndex="0" Width="99%">
                                <ajaxToolkit:TabPanel ID="pnlAwaiting" runat="server" HeaderText="Awaiting Approval"
                                    Visible="true"><HeaderTemplate>Activity Information</HeaderTemplate><ContentTemplate><fldVst:activityHeader ID="activityHeader1" runat="server" >
                                    </fldVst:activityHeader>
                                    </ContentTemplate></ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="Awaiting Approval"
                                    Visible="true"><HeaderTemplate>Plan Execution Criteria</HeaderTemplate><ContentTemplate><fldVst:locFieldLocations ID="locFieldLocations1" runat="server" /></ContentTemplate></ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Awaiting Approval"
                                    Visible="true"><HeaderTemplate>Vendor Call Out</HeaderTemplate><ContentTemplate><fldVst:vendorCallOutInfo ID="vendorCallOutInfo1" runat="server" /></ContentTemplate></ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Awaiting Approval"
                                    Visible="true"><HeaderTemplate>Personnel Information</HeaderTemplate><ContentTemplate><fldVst:personnelInformationList ID="personnelInformationList1" runat="server" /><fldVst:personnelInfoDetails ID="personnelInfoDetails1" runat="server" /></ContentTemplate></ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="Awaiting Approval"
                                    Visible="true"><HeaderTemplate>Activity Timeline</HeaderTemplate><ContentTemplate><fldVst:activityTimeLineSummary ID="activityTimeLineSummary1" runat="server" /></ContentTemplate></ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Awaiting Approval"
                                    Visible="true"><HeaderTemplate>Plan Entry Approval</HeaderTemplate><ContentTemplate><fldVst:Approvers ID="Approvers1" runat="server" /></ContentTemplate></ajaxToolkit:TabPanel>
                            </ajaxToolkit:TabContainer>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Label runat="server" ID="CurrentTab" />
                    <asp:Label runat="server" ID="Messages" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
