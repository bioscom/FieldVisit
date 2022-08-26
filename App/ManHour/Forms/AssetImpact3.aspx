<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterManHour.master" AutoEventWireup="true" CodeFile="AssetImpact3.aspx.cs" Inherits="Forms_AssetImpact3" %>
<%@ Reference VirtualPath="~/App/ManHour/UserControl/MyInitiatives.ascx" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register src="../UserControl/dateControl.ascx" tagname="dateControl" tagprefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="headId" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" ScriptMode="Release">
    </ajaxToolkit:ToolkitScriptManager>--%>
    <table class="tSubGray" style="width: 98%">
        <tr>
            <td class="cHeadTile">View(3) Impact on Assets</td>
        </tr>
        <tr>
            <td valign="top">
                <div>
                    <div style="float:left">
                        <table>
                            <tr>
                                <td>Year One:</td>
                                <td><uc1:dateControl ID="dtYearOne" runat="server" /></td>
                                <td>Year Three:</td>
                                <td><uc1:dateControl ID="dtYearTwo" runat="server" /></td>
                            </tr>
                        </table>
                    </div>
                    <div style="float:left; margin-left:0.5em">
                        <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click" Text="View" Width="100px" />
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Panel ID="rptViewPanel" runat="server">
                    <rsweb:ReportViewer ID="rptViewer" runat="server" BorderColor="Black"
                        BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt"
                        Height="500px" Width="100%" ZoomMode="Percent">
                    </rsweb:ReportViewer>
                </asp:Panel>
            </td>
        </tr>
    </table>

</asp:Content>