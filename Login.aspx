<%@ Page Title="" Language="C#" MasterPageFile="~/CBIDashboard2.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register Src="UserControls/Login.ascx" TagName="Login" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin-left:40em; margin-top:10em; margin-right:auto" class="tab-content no-padding">
        <uc2:Login ID="Login1" runat="server" />
        <div class="chart tab-pane" id="sales-chart" style="position: relative; height: 300px;"></div>
    </div>
</asp:Content>

