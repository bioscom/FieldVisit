<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="DefineUsers.aspx.cs" Inherits="UsersManagement_DefineUsers" %>

<%@ Register Src="../../../UserControls/AddUser.ascx" TagName="AddUser" TagPrefix="ectr" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ectr:AddUser ID="AddUser1" runat="server" />
</asp:Content>