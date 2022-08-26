<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/configuration.master" AutoEventWireup="true" CodeFile="AddC4CUser.aspx.cs" Inherits="AddC4CUser" %>

<%@ Register src="UserControls/AddC4CUser.ascx" tagname="AddC4CUser" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RightColumn" Runat="Server">

    <uc2:AddC4CUser ID="AddC4CUser1" runat="server" />

</asp:Content>

