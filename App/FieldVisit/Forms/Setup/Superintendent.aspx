<%@ Page Language="C#" MasterPageFile="~/MasterPages/configuration.master" AutoEventWireup="true" CodeFile="Superintendent.aspx.cs" Inherits="Setup_Superintendent" Title="" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/UserControls/userFinder/Search4User.ascx" TagName="Search4User" TagPrefix="uc1" %>
<%@ Register Src="~/App/FieldVisit/UserControl/frmSuperintendent.ascx" TagPrefix="uc1" TagName="frmSuperintendent" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightColumn" runat="Server">
    <asp:LinkButton ID="addLinkButton" runat="server">Add New Superintendent</asp:LinkButton>
    <uc1:frmSuperintendent runat="server" ID="frmSuperintendent" />
</asp:Content>