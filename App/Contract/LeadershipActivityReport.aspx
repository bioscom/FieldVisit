<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/14DayContract.master" AutoEventWireup="true" CodeFile="LeadershipActivityReport.aspx.cs" Inherits="App_Contract_LeadershipActivityReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Src="../../UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <table class="tMainBorder" style="width: 98%">
        <tr>
            <td class="cHeadTile">OPERATIONS SUPERINTENDENT 14 DAY CONTRACT</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Trip Start Date:"></asp:Label>
                <br />
                <uc2:dateControl ID="dtTripStart" runat="server" />
            </td>

        </tr>

        <tr>
            <td valign="top">
                <asp:Panel ID="rptViewPanel" runat="server">
                    <rsweb:ReportViewer ID="rptViewer" runat="server" BorderColor="Black"
                        BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt"
                        Height="600px" Width="100%" ZoomMode="Percent">
                    </rsweb:ReportViewer>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

