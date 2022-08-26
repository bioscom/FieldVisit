<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="rptReport.aspx.cs" Inherits="Reports_rptReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tMainBorder" style="width: 100%">
        <tr class="cHeadTile">
            <td colspan="8">Report</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlReportType" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server">
                    <asp:ListItem Value="-1">Select Category</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlFacilities" runat="server">
                    <asp:ListItem Value="-1">Select Facility</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="From:"></asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker RenderMode="Lightweight" ID="txtFrom" Width="200px" runat="server"></telerik:RadDatePicker>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="To:"></asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker RenderMode="Lightweight" ID="txtTo" Width="200px" runat="server"></telerik:RadDatePicker>
            </td>
            <td>
                <asp:Button ID="viewButton" runat="server" OnClick="viewButton_Click" Text="Report" />
            </td>
        </tr>
    </table>

    <table class="tMainBorder" style="width: 100%">
        <tr>
            <td>
                <rsweb:ReportViewer ID="rptViewer" runat="server" BorderColor="Black"
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt"
                    Height="650px" Width="99%" ZoomMode="Percent">
                </rsweb:ReportViewer>
            </td>
        </tr>
    </table>
    <br /><br /><br />
</asp:Content>
