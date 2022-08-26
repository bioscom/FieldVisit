<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master" AutoEventWireup="true" CodeFile="FieldEntryRpt.aspx.cs" Inherits="Report_FieldEntryRpt" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tSubGray" style="width:98%">
        <tr>
            <td class="cHeadTile">
                Planned Entry Criteria Checklist Report</td>
        </tr>
        <tr>
            <td valign="top">
    
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" />

            </td>
        </tr>
        <tr>
            <td valign="top">
                        <asp:Panel ID="rptViewPanel" runat="server">
                            <rsweb:reportviewer id="rptViewer" runat="server" bordercolor="Black" 
                                borderstyle="Solid" borderwidth="1px" font-names="Verdana" font-size="8pt" 
                                height="700px" width="100%" zoommode="Percent">
                            </rsweb:reportviewer>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

