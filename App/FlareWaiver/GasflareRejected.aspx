<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="GasflareRejected.aspx.cs" Inherits="App_FlareWaiver_GasflareRejected" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="UserControl/oRequests.ascx" TagName="oRequests" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tMainBorder" style="width: 100%">
        <tr class="cHeadTile">
            <td>Rejected Requests</td>
        </tr>
        <tr>
            <td>
                <uc1:oRequests ID="oRequestsRejected" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>