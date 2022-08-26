<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/configuration.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" %>

<%@ Register Src="~/UserControls/AddUser.ascx" TagPrefix="app" TagName="AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RightColumn" Runat="Server">
    <app:AddUser runat="server" ID="AddUser1" />
</asp:Content>

