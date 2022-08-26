<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master" AutoEventWireup="true" CodeFile="MyRequets.aspx.cs" Inherits="App_FieldVisit_Forms_MyRequets" %>

<%@ Register src="../UserControl/FPEC/pendingFieldVisitRequests.ascx" tagname="pendingFieldVisitRequests" tagprefix="uc2" %>
<%@ Register src="../UserControl/FPEC/approvedFieldVisitRequests.ascx" tagname="approvedFieldVisitRequests" tagprefix="uc3" %>
<%@ Register src="../UserControl/SEPCiN/MyApprovedPECRequests.ascx" tagname="MyApprovedPECRequests" tagprefix="uc4" %>
<%@ Register src="../UserControl/SEPCiN/MyPecRequests.ascx" tagname="MyPecRequests" tagprefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" ScriptMode="Release">
    </ajaxToolkit:ToolkitScriptManager>
        <%--<div style="color: Black; margin-left: 5px; margin-right: 2px; margin-top: 5px; float: left; width: 98%">--%>
        <asp:UpdatePanel ID="uppAjaxBloc" runat="server">
            <ContentTemplate>
                <ajaxToolkit:TabContainer runat="server" ID="smtAjaxTabs" ActiveTabIndex="0" Width="100%">
                    <ajaxToolkit:TabPanel runat="server" ID="pnlBusinessInitiative" HeaderText="Awaiting Approval" Width="100%" Visible="true">
                        <HeaderTemplate>My Field Visit Requests Pending Approval</HeaderTemplate>
                        <ContentTemplate>
                            
                            <uc2:pendingFieldVisitRequests ID="pendingFieldVisitRequests1" runat="server" />
                            
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="pnlDistrict" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>My Field Visit Requests Approved</HeaderTemplate>
                        <ContentTemplate>
                            
                            <uc3:approvedFieldVisitRequests ID="approvedFieldVisitRequests1" runat="server" />
                            
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="pnlResourceUtilisation" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>My PEC Requests Pending Approval</HeaderTemplate>
                        <ContentTemplate>
                            
                            <uc5:MyPecRequests ID="MyPecRequests1" runat="server" />
                            
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="BITabPanel" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>My PEC Requests Approved</HeaderTemplate>
                        <ContentTemplate>
                            
                            <uc4:MyApprovedPECRequests ID="MyApprovedPECRequests1" runat="server" />
                            
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    

                </ajaxToolkit:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Label runat="server" ID="CurrentTab" />
        <asp:Label runat="server" ID="Messages" />
    <%--</div>--%>

</asp:Content>

