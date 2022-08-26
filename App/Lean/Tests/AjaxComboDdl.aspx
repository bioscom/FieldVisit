<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/LeanMasterPage.master" AutoEventWireup="true" CodeFile="AjaxComboDdl.aspx.cs" Inherits="App_Lean_Tests_AjaxComboDdl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>

    <hr />

    <ajaxToolkit:ComboBox ID="ComboBox2" runat="server"
        DropDownStyle="DropDownList"
        AutoCompleteMode="None"
        CaseSensitive="false"
        RenderMode="Inline"
        ItemInsertLocation="Append"
        ListItemHoverCssClass="ComboBoxListItemHover" AutoPostBack="True">
    </ajaxToolkit:ComboBox>

    <br />
    <br />

    <ajaxToolkit:ComboBox ID="ComboBox1" runat="server" 
    DropDownStyle="DropDown" 
    AutoCompleteMode="None"
    CaseSensitive="false"
    RenderMode="Inline"
    ItemInsertLocation="Append"
    ListItemHoverCssClass="ComboBoxListItemHover">
      
</ajaxToolkit:ComboBox>

</asp:Content>

