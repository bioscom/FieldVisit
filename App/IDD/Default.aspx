<%@ Page Title="" Language="C#" MasterPageFile="~/IDD.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="App_IDD_Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/App/IDD/UserControl/oPendingApproval.ascx" TagPrefix="app" TagName="oPendingApproval" %>
<%@ Register Src="~/App/IDD/UserControl/oAssignedToAnalyst.ascx" TagPrefix="app" TagName="oAssignedToAnalyst" %>
<%@ Register Src="~/App/IDD/UserControl/oRejected.ascx" TagPrefix="app" TagName="oRejected" %>
<%@ Register Src="UserControl/oHistoricalData.ascx" TagName="oHistoricalData" TagPrefix="uc2" %>
<%@ Register Src="~/App/IDD/UserControl/oCompleted.ascx" TagPrefix="app" TagName="oCompleted" %>




<%--<asp:Content ID="Content1" ContentPlaceHolderID="HistoryContentPlaceHolder" runat="Server">
    <uc2:oHistoricalData ID="oHistoricalData1" runat="server" />
</asp:Content>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div style="margin-left:1.0em; border:1px solid silver">
        <h2 style="color: black">Vendor Integrity Due Diligence Management (VM/IDD Lead)</h2>
        <telerik:RadTabStrip RenderMode="Lightweight" runat="server" Skin="Silk" ID="RadTabStrip1" Align="Left" AutoPostBack="true" MultiPageID="RadMultiPage1" SelectedIndex="0">
            <Tabs>
                <telerik:RadTab Text="IDD Awaiting Review"></telerik:RadTab>
                <telerik:RadTab Text="IDD Assigned to Analyst"></telerik:RadTab>
                <%--<telerik:RadTab Text="Completed"></telerik:RadTab>--%>
                <telerik:RadTab Text="Rejected"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>

        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0">

            <telerik:RadPageView runat="server" ID="RadPageView1">
                <%--<div class="contentWrapper">--%>
                    <app:oPendingApproval runat="server" ID="oPendingApproval" />
                <%--</div>--%>
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView2">
                <div class="contentWrapper">
                    <app:oAssignedToAnalyst runat="server" ID="oAssignedToAnalyst" />
                </div>
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView3" CssClass="RadPageView3">
                <div class="contentWrapper">
                    <app:oRejected runat="server" ID="oRejected" />
                </div>
            </telerik:RadPageView>

        </telerik:RadMultiPage>

    </div>
    <br /><br /><br /><br /><br />
</asp:Content>

