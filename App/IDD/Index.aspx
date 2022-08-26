<%@ Page Title="" Language="C#" MasterPageFile="~/IDD.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="App_IDD_Index" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%--<%@ Register Src="~/App/IDD/UserControl/oHistoricalData.ascx" TagPrefix="app" TagName="oHistoricalData" %>
<%@ Register Src="~/App/IDD/UserControl/oCHCLMgt.ascx" TagPrefix="app" TagName="oCHCLMgt" %>--%>
<%@ Register Src="~/App/IDD/UserControl/oDepartments.ascx" TagPrefix="app" TagName="oDepartments" %>
<%@ Register Src="~/App/IDD/UserControl/oCatServices.ascx" TagPrefix="app" TagName="oCatServices" %>
<%@ Register Src="~/App/IDD/UserControl/oAdmin.ascx" TagPrefix="app" TagName="oAdmin" %>
<%@ Register Src="~/App/IDD/UserControl/oIDDLeadFocalPoint.ascx" TagPrefix="app" TagName="oIDDLeadFocalPoint" %>
<%@ Register Src="~/App/IDD/UserControl/oIDDAnalyst.ascx" TagPrefix="app" TagName="oIDDAnalyst" %>
<%@ Register Src="~/App/IDD/UserControl/oCorporate.ascx" TagPrefix="app" TagName="oCorporate" %>
<%@ Register Src="~/App/IDD/UserControl/VendorsInformationMgt.ascx" TagPrefix="app" TagName="VendorsInformationMgt" %>


<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="HistoryContentPlaceHolder" runat="Server">
    <app:oHistoricalData runat="server" ID="oHistoricalData" />
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div style="margin-left: 1.0em; margin-right: 1.0em; border: 1px solid silver">
        <h2 style="color: black">Administrative Data Management</h2>
        <telerik:RadTabStrip RenderMode="Lightweight" runat="server" Skin="Silk" ID="RadTabStrip1" Align="Left" AutoPostBack="true" MultiPageID="RadMultiPage1" SelectedIndex="0">
            <Tabs>
                <telerik:RadTab Text="Administrators Management"></telerik:RadTab>
                <telerik:RadTab Text="Corporate Database Viewers"></telerik:RadTab>
                <telerik:RadTab Text="CP IDD Focal Points"></telerik:RadTab>
                <telerik:RadTab Text="IDD Analysts"></telerik:RadTab>

                <%--<telerik:RadTab Text="Request initiators/Requestor by Locations"></telerik:RadTab>--%>
                <telerik:RadTab Text="Department"></telerik:RadTab>
                <telerik:RadTab Text="Category / Services"></telerik:RadTab>
                <telerik:RadTab Text="Vendors Information Management" TabIndex="0"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>

        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0">

            <telerik:RadPageView runat="server" ID="RadPageView2">
                <app:oAdmin runat="server" ID="oAdmin" />
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView3">
                <app:oCorporate runat="server" ID="oCorporate" />
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView4">
                <app:oIDDLeadFocalPoint runat="server" ID="oIDDLeadFocalPoint" />
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView5">
                <app:oIDDAnalyst runat="server" ID="oIDDAnalyst" />
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView6">
                <app:oDepartments runat="server" ID="oDepartments" />
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView7">
                <app:oCatServices runat="server" ID="oCatServices" />
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView1">
                <app:VendorsInformationMgt runat="server" ID="VendorsInformationMgt" />
            </telerik:RadPageView>

        </telerik:RadMultiPage>
    </div>
    <br />
</asp:Content>
