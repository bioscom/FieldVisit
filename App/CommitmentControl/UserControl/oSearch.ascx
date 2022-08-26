<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oSearch.ascx.cs" Inherits="App_CommitmentControl_UserControl_oSearch" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadAjaxPanel ID="AjaxPanel1" runat="server">
    <div class="demo-container no-bg">
        <telerik:RadSearchBox RenderMode="Lightweight" runat="server" ID="RadSearch"
            CssClass="searchBox" Skin="Silk"
            ShowSearchButton="true"
            EmptyMessage="Search for commitment"
            Width="500"
            OnSearch="RadSearch_Search">
            <DropDownSettings Height="300" Width="500" />
        </telerik:RadSearchBox>

    </div>
</telerik:RadAjaxPanel>

<%--Width="460" DropDownSettings-Height="300"
            DataSourceID="SqlDataSource1"
            DataTextField="fullName"
            DataValueField="id"
            DataKeyNames="sport,birthday,country"
            EmptyMessage="Search"
            Filter="Contains"
            MaxResultCount="20"
            OnDataSourceSelect="RadSearch_DataSourceSelect"
            OnSearch="RadSearch_Search"
            OnButtonCommand="RadSearch_ButtonCommand">--%>