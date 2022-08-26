<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/LeanMasterPage.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="App_Lean_AddUser" %>
<%@ Register Src="~/UserControls/userFinder/Search4User.ascx" TagName="Search4User" TagPrefix="uc1" %>

<%@ Register src="../../UserControls/AddUser.ascx" tagname="AddUser" tagprefix="uc2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <uc2:AddUser ID="AddUser1" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</asp:Content>