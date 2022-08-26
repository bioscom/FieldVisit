<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PriceTracker.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="App_Prices_Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="UserControl/oBCostSavings.ascx" TagName="oCostSaving" TagPrefix="uc6" %>
<%@ Register Src="UserControl/oPerformanceByHub.ascx" TagName="oPerformanceByHub" TagPrefix="uc2" %>
<%@ Register Src="UserControl/oPerformanceGraphs.ascx" TagName="oPerformanceGraphs" TagPrefix="uc2" %>
<%@ Register Src="~/App/Prices/UserControl/oBCostSavingsApproved.ascx" TagPrefix="uc2" TagName="oBCostSavingsApproved" %>


<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">

    <telerik:RadTabStrip RenderMode="Lightweight" runat="server" Skin="Silk" ID="RadTabStrip1" Align="Left" AutoPostBack="true" MultiPageID="RadMultiPage1" SelectedIndex="0">
        <Tabs>
            <%--<telerik:RadTab Text="Dashboard"></telerik:RadTab>--%>
            <telerik:RadTab Text="Cost Red Awaiting Review"></telerik:RadTab>
            <telerik:RadTab Text="Closed Out Red Flags"></telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>

    <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0">
        <%--<telerik:RadPageView runat="server" ID="RadPageView3" CssClass="RadPageView3">
            <div class="contentWrapper">
                <div style="overflow: auto; padding:70px">
                    <div style="float: left">
                        <uc2:oPerformanceGraphs ID="oPerformanceGraphs1" runat="server" />
                    </div>
                    <div style="float: left; margin-left: 1.5em">
                        <uc2:oPerformanceByHub runat="server" ID="oPerformanceByHub" />
                    </div>
                </div>
            </div>
        </telerik:RadPageView>--%>
        <telerik:RadPageView runat="server" ID="RadPageView1">
            <div class="contentWrapper">
                <uc6:oCostSaving ID="Pending" runat="server" />
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView2">
            <div class="contentWrapper">
                <uc2:oBCostSavingsApproved runat="server" ID="Approved" />
            </div>
        </telerik:RadPageView>
        
    </telerik:RadMultiPage>
    <br /><br />
	<br /><br />

    <%--<div style="overflow: auto; border: solid 1px gray">
        <div style="float: left">
            <uc2:oPerformanceGraphs ID="oPerformanceGraphs2" runat="server" />
        </div>
        <div style="float: left; margin-left: 1.5em">
            <uc2:oPerformanceByHub runat="server" ID="oPerformanceByHub1" />
        </div>
    </div>--%>

</asp:Content>






<%-- <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="server" ScriptMode="Release"></ajaxToolkit:ToolkitScriptManager>
    <div>
        <div style="overflow: auto">
            
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div style="overflow: auto">
            <%--<uc6:oCostSaving ID="Approved" runat="server" />
            
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="GraphContentPlaceHolder" runat="Server">--%>
    
