<%@ Page Title="" Language="C#" MasterPageFile="~/CBIDashboard2.master" AutoEventWireup="true" CodeFile="AuditTrailPDCC.aspx.cs" Inherits="AuditTrailPDCC" %>

<%@ Register src="App/PDCC/UserControl/AuditTrailCostChallenge.ascx" tagname="AuditTrailCostChallenge" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc2:AuditTrailCostChallenge ID="AuditTrailCostChallenge1" runat="server" />
</asp:Content>

