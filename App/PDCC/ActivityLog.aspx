<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PDCC.master" AutoEventWireup="true" CodeFile="ActivityLog.aspx.cs" Inherits="App_PDCC_ActivityLog" %>

<%@ Register src="UserControl/ActivityLogCntl.ascx" tagname="ActivityLogCntl" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <div>
        <div style="float:left; width:30%">
            <uc2:ActivityLogCntl ID="ActivityLogCntl1" runat="server" />
        </div>
        <div style="float:left">

        </div>
    </div>

    
</asp:Content>

