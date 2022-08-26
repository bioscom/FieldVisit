<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PDCC.master" AutoEventWireup="true" CodeFile="PartsOpportunities.aspx.cs" Inherits="App_PDCC_PartsOpportunities" %>

<%@ Register Src="~/App/PDCC/UserControl/PartsOpportunities.ascx" TagPrefix="app" TagName="PartsOpportunities" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <app:PartsOpportunities runat="server" ID="PartsOpportunities" />
</asp:Content>

