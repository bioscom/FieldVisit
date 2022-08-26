<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="Reporting.aspx.cs" Inherits="App_FlareWaiver_Reporting" %>
<%@ Register Src="UserControl/oRequests.ascx" TagName="oRequests" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" Width="200px">
        <asp:ListItem Value="-1">Please select area</asp:ListItem>
    </asp:DropDownList>
    <hr />
    <div style="height: 120px; width: 100%; overflow: auto; border: solid 1px silver">
        <asp:CheckBoxList ID="facilitiesCkbLst" runat="server" RepeatColumns="4">
        </asp:CheckBoxList>
    </div>
    <br />
    <asp:Button ID="btnReport" runat="server" OnClick="btnReport_Click" Text="Report" Width="100px" />
    <hr />
    <uc1:oRequests ID="oRequests1" runat="server" />
    <br /><br /><br />
</asp:Content>

