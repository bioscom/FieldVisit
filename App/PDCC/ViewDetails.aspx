<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PDCC.master" AutoEventWireup="true" CodeFile="ViewDetails.aspx.cs" Inherits="App_PDCC_ViewDetails" %>

<%@ Register src="UserControl/statusSelectorControl.ascx" tagname="statusSelectorControl" tagprefix="uc3" %>
<%@ Register src="UserControl/Search4LocalUser.ascx" tagname="Search4LocalUser" tagprefix="uc2" %>

<%@ Register src="UserControl/ActivityLogCntl.ascx" tagname="ActivityLogCntl" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <uc4:ActivityLogCntl ID="ActivityLogCntl1" runat="server" />
    <br /><br />
</asp:Content>

