<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PDCC.master" AutoEventWireup="true" CodeFile="ViewUsers.aspx.cs" Inherits="App_PDCC_ViewUsers" %>
<%@ Register src="../../UserControls/ViewUsers.ascx" tagname="ViewUsers" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <uc2:ViewUsers ID="ViewUsers1" runat="server" />
</asp:Content>

