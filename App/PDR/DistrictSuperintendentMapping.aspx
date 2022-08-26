<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPagePDR.master" AutoEventWireup="true" CodeFile="DistrictSuperintendentMapping.aspx.cs" Inherits="App_PDR_DistrictSuperintendentMapping" %>

<%@ Register src="UserControl/DistrictSuperintendents.ascx" tagname="DistrictSuperintendents" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightColumn" Runat="Server">
    <uc2:DistrictSuperintendents ID="DistrictSuperintendents1" runat="server" />
</asp:Content>

