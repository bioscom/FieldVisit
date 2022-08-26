<%@ Page Title="" Language="C#" MasterPageFile="~/IDD.master" AutoEventWireup="true" CodeFile="Initiators.aspx.cs" Inherits="App_IDD_Initiators" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/App/IDD/UserControl/oMyPendingRequests.ascx" TagPrefix="app" TagName="oMyPendingRequests" %>
<%@ Register Src="~/App/IDD/UserControl/oMyRequestsAssignedToAnalyst.ascx" TagPrefix="app" TagName="oMyRequestsAssignedToAnalyst" %>
<%@ Register Src="~/App/IDD/UserControl/oMyCompletedRequests.ascx" TagPrefix="app" TagName="oMyCompletedRequests" %>
<%@ Register Src="~/App/IDD/UserControl/oMyRejectedRequests.ascx" TagPrefix="app" TagName="oMyRejectedRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div style="margin-left: 1.0em; border: 1px solid silver">
        <h2 style="color: black">My Integrity Due Diligence Requests (Requests I Initiated)</h2>
        <telerik:RadTabStrip RenderMode="Lightweight" runat="server" Skin="Silk" ID="RadTabStrip1" Align="Left" AutoPostBack="true" MultiPageID="RadMultiPage1" SelectedIndex="0">
            <Tabs>
                <telerik:RadTab Text="My Pending Requests"></telerik:RadTab>
                <telerik:RadTab Text="My Requests Assigned to IDD Analyst"></telerik:RadTab>
                <%--<telerik:RadTab Text="My Requests Completed"></telerik:RadTab>--%>
                <telerik:RadTab Text="My Requests Rejected"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>

        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0">
            <telerik:RadPageView runat="server" ID="RadPageView1">
                <%--<div class="contentWrapper">--%>
                    <app:oMyPendingRequests runat="server" ID="oMyPendingRequests" />
                <%--</div>--%>
            </telerik:RadPageView>
            <telerik:RadPageView runat="server" ID="RadPageView2">
                <%--<div class="contentWrapper">--%>
                    <app:oMyRequestsAssignedToAnalyst runat="server" ID="oMyRequestsAssignedToAnalyst" />
                <%--</div>--%>
            </telerik:RadPageView>
            <%--<telerik:RadPageView runat="server" ID="RadPageView4">
                <div class="contentWrapper">
                    <app:oMyCompletedRequests runat="server" ID="oMyCompletedRequests" />
                </div>
            </telerik:RadPageView>--%>
            <telerik:RadPageView runat="server" ID="RadPageView3" CssClass="RadPageView3">
                <%--<div class="contentWrapper">--%>
                    <app:oMyRejectedRequests runat="server" ID="oMyRejectedRequests" />
                <%--</div>--%>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
</asp:Content>

