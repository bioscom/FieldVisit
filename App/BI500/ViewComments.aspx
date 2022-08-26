<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BI500.master" AutoEventWireup="true" CodeFile="ViewComments.aspx.cs" Inherits="App_BI500_ViewComments" %>

<%@ Register Src="UserControl/oRequestDetails.ascx" TagName="oRequestDetails" TagPrefix="uc2" %>

<%@ Register src="UserControl/oApprovalComment.ascx" tagname="oApprovalComment" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">

    <table>
        <tr>
            <td style="width: 450px">
                <uc2:oRequestDetails ID="oRequestDetails1" runat="server" />
            </td>
            <td>
                <uc3:oApprovalComment ID="oApprovalCommentProjectChampion" runat="server" />
                <uc3:oApprovalComment ID="oApprovalCommentBITeam" runat="server" />
                <uc3:oApprovalComment ID="oApprovalCommentProjectSponsor" runat="server" />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

