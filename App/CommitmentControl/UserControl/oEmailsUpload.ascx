<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oEmailsUpload.ascx.cs" Inherits="App_CommitmentControl_UserControl_oEmailsUpload" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div id="DemoContainer1" runat="server" class="demo-container size-narrow">
    <telerik:RadAsyncUpload ID="AsyncUpload1" runat="server" ChunkSize="1048576" RenderMode="Lightweight" />
    <telerik:RadProgressArea ID="RadProgressArea1" runat="server" RenderMode="Lightweight" />
</div>
<%--<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1" />
                <telerik:AjaxUpdatedControl ControlID="DemoContainer1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>--%>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
