<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Report.ascx.cs" Inherits="UserControl_Report" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<div style="text-align:center; width: 100%">
    <asp:LinkButton ID="showReportLinkButton" runat="server" OnClick="showReportLinkButton_Click" ValidationGroup="ResourseUtilRpt">Refresh</asp:LinkButton>
</div>
<asp:Panel ID="rptViewPanel" runat="server" Width="100%">
    <rsweb:ReportViewer ID="rptViewer" runat="server" BorderColor="Black"
        BorderStyle="Solid" BorderWidth="1px" Font-Names="Garamond" Font-Size="8pt"
        Width="100%" ZoomMode="Percent">
    </rsweb:ReportViewer>
</asp:Panel>