<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="ECFlareAnalyser.aspx.cs" Inherits="App_FlareWaiver_ECFlareAnalyser" %>

<%@ Register src="UserControl/oFlareECAnalyser.ascx" tagname="oFlareECAnalyser" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc2:oFlareECAnalyser ID="oFlareECAnalyser1" runat="server" />
    <br /><br /><br /><br />
</asp:Content>

