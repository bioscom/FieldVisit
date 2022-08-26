<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PriceTracker.master" AutoEventWireup="true" CodeFile="DashBoard.aspx.cs" Inherits="App_Prices_DashBoard" %>

<%@ Register Src="UserControl/oPerformanceByHub.ascx" TagName="oPerformanceByHub" TagPrefix="uc2" %>
<%@ Register Src="UserControl/oPerformanceGraphs.ascx" TagName="oPerformanceGraphs" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div style="overflow: auto; padding: 70px">
        <div style="float: left">
            <uc2:oPerformanceGraphs ID="oPerformanceGraphs1" runat="server" />
        </div>
        <div style="float: left; margin-left: 1.5em">
            <uc2:oPerformanceByHub runat="server" ID="oPerformanceByHub" />
        </div>
    </div>
</asp:Content>

