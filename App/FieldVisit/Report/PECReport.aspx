<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master" AutoEventWireup="true" CodeFile="PECReport.aspx.cs" Inherits="Report_PECReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tSubGray" style="width: 99%">
        <tr>
            <td class="cHeadTile">SEPCiN (Offshore/Onshore Assets) Plan Execution Criteria &amp; Change Control Form Report</td>
        </tr>
        <tr>
            <td valign="top">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Panel ID="rptViewPanel" runat="server">
                    <rsweb:ReportViewer ID="rptViewer" runat="server" bordercolor="Black" 
                                borderstyle="Solid" borderwidth="1px" font-names="Verdana" font-size="8pt" 
                                height="900px" width="100%" zoommode="Percent">
                    </rsweb:ReportViewer>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

