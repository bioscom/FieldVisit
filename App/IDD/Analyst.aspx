<%@ Page Title="" Language="C#" MasterPageFile="~/IDD.master" AutoEventWireup="true" CodeFile="Analyst.aspx.cs" Inherits="App_IDD_Analyst" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/App/IDD/UserControl/oUndergoingAnalystprocess.ascx" TagPrefix="app" TagName="oUndergoingAnalystprocess" %>
<%@ Register Src="~/App/IDD/UserControl/oInVSR.ascx" TagPrefix="app" TagName="oInVSR" %>



<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div style="margin-left: 1.0em; border: 1px solid silver">
        <h2 style="color: black">Integrity Due Diligence Requests For My Actions (IDD Analyst Workbench)</h2>
        <telerik:RadTabStrip RenderMode="Lightweight" runat="server" Skin="Silk" ID="RadTabStrip1" Align="Left" AutoPostBack="true" MultiPageID="RadMultiPage1" SelectedIndex="0">
            <Tabs>
                <telerik:RadTab Text="Undergoing Analyst Review"></telerik:RadTab>
                <telerik:RadTab Text="In Vendor Status Report"></telerik:RadTab>
                <%--<telerik:RadTab Text="Rejected"></telerik:RadTab>--%>
            </Tabs>
        </telerik:RadTabStrip>

        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0">

            <telerik:RadPageView runat="server" ID="RadPageView1">
                <app:oUndergoingAnalystprocess runat="server" ID="oUndergoingAnalystprocess" />
            </telerik:RadPageView>

            <telerik:RadPageView runat="server" ID="RadPageView2">
                <app:oInVSR runat="server" ID="oInVSR" />
            </telerik:RadPageView>
            <%--<telerik:RadPageView runat="server" ID="RadPageView3" CssClass="RadPageView3">
                
            </telerik:RadPageView>--%>
        </telerik:RadMultiPage>
    </div>
</asp:Content>

