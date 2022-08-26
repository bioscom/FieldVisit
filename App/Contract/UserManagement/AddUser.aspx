<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/14DayContract.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="App_BI500_UserManagement_AddUser" %>

<%@ Register src="../../../UserControls/AddUser.ascx" tagname="AddUser" tagprefix="uc2" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <uc2:AddUser ID="AddUser1" runat="server" />
</asp:Content>

