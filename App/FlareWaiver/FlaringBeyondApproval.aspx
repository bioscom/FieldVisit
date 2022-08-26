<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="FlaringBeyondApproval.aspx.cs" Inherits="App_FlareWaiver_FlaringBeyondApproval" %>
<%@ Register Src="UserControl/oFlaringBeyondEndDate.ascx" TagName="oFlaringBeyondEndDate" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tMainBorder" style="width: 100%">
        <tr>
            <td class="cHeadTile">Facilities Flaring Beyond Approval Date</td>
        </tr>
        <tr>
            <td>
                <uc3:oFlaringBeyondEndDate ID="oFlaringBeyondEndDate1" runat="server" />
            </td>
        </tr>
    </table>
    <br /><br /><br />
</asp:Content>

