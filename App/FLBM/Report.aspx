<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CompetenceAssessment.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="App_FLBM_Report" %>

<%@ Register Src="UserControl/MainHeaderControl.ascx" TagName="MainHeaderControl" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin-left:2em">
        <uc2:MainHeaderControl ID="MainHeaderControl1" runat="server" />
        <hr />
        <div style="text-align: right; width: 99%">
            <asp:Button ID="btnExport" runat="server" Text="Export to PDF" Width="180px" OnClick="btnExport_Click" />
            <br /><br />
        </div>
        <asp:Literal ID="RptLiteral" runat="server"></asp:Literal>
    </div>
</asp:Content>


