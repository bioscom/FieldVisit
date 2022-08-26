<%@ Page Title="" Language="C#" MasterPageFile="~/CBIDashboard2.master" AutoEventWireup="true" CodeFile="WeeklyHighlight.aspx.cs" Inherits="WeeklyHighlight" %>

<%@ Register Src="UserControls/WeeklyHighLight.ascx" TagName="WeeklyHighLight" TagPrefix="uc2" %>

<%@ Register Src="UserControls/WeeklyHighlightLoader.ascx" TagName="WeeklyHighlightLoader" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" EnablePartialRendering="true" ScriptMode="Release" />
    <div style="width: 800px; margin: 2em">
        <asp:Label ID="Label1" runat="server" Text="Note, convert file to PDF before uploading. Only PDF is allowed. To update input, select the week you want to update, enter dates, select the file and click upload." CssClass="Warning"></asp:Label>
        <br />
        <br />
        <uc2:WeeklyHighLight ID="WeeklyHighLight1" runat="server" />
        <uc3:WeeklyHighlightLoader ID="WeeklyHighlightLoader1" runat="server" />
    </div>
</asp:Content>

