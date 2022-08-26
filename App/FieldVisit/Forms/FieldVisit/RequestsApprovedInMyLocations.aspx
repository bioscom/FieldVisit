<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master" AutoEventWireup="true" CodeFile="RequestsApprovedInMyLocations.aspx.cs" Inherits="App_FieldVisit_Forms_FieldVisit_RequestsApprovedInMyLocations" %>

<%@ Register src="../../UserControl/FPEC/allRequestsApproved.ascx" tagname="allRequestsApproved" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tMainBorder" style="width:98%">
        <tr>
            <td class="cHeadTile">Requests Approved in My Facilities</td>
        </tr>
        <tr>
            <td>
    <uc3:allRequestsApproved runat="server" ID="allRequestsApproved1"></uc3:allRequestsApproved>
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
    </table>
    </asp:Content>

