<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="FlareAnalyDashBoard.aspx.cs" Inherits="App_FlareWaiver_FlareAnalyDashBoard" %>

<%@ Register Src="UserControl/oFlareTargetDashBoard.ascx" TagName="oFlareTargetDashBoard" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="server" ScriptMode="Release"></ajaxToolkit:ToolkitScriptManager>--%>
    <table class="tMainBorder" style="width: 99%">
        <tr>
            <td class="cHeadTile">Gas Flare Dashboard</td>
        </tr>
        <tr>
            <td>
                <uc2:oFlareTargetDashBoard ID="oFlareTargetDashBoard1" runat="server" />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

