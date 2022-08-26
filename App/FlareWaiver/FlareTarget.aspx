<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="FlareTarget.aspx.cs" Inherits="App_FlareWaiver_FlareTarget" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/App/FlareWaiver/UserControl/oFlareTarget.ascx" TagPrefix="app" TagName="oFlareTarget" %>


<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <app:oFlareTarget runat="server" ID="oFlareTarget" />
</asp:Content>

