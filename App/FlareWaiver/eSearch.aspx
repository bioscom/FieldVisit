<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="eSearch.aspx.cs" Inherits="eSearch" %>

<%@ Register src="UserControl/oRequests.ascx" tagname="oRequests" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tMainBorder" style="width:98%">
    <tr class="cHeadTile">
        <td>
            Search Result</td>
    </tr>
    <tr>
        <td>
            <uc1:oRequests ID="oRequests1" runat="server" />
        </td>
    </tr>
    </table>
</asp:Content>

