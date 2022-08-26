<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BI500.master" AutoEventWireup="true" CodeFile="Setups.aspx.cs" Inherits="App_BI500_Setups" %>

<%@ Register src="UserControl/OrganisationStructMgr.ascx" tagname="OrganisationStructMgr" tagprefix="uc2" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuContentContentPlaceHolder" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <uc2:OrganisationStructMgr ID="OrganisationStructMgr1" runat="server" />
</asp:Content>

