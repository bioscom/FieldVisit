<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oHistoricalData.ascx.cs" Inherits="App_IDD_UserControl_oHistoricalData" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<div class="demo-container size-thin">
    <h3>Historical Information</h3>
    <div style="font-size: 90%; border:1px solid silver">
        <telerik:RadTreeView RenderMode="Lightweight" ID="RadTreeView1" runat="server" Height="600px" Width="100%" OnNodeExpand="RadTreeView1_NodeExpand">
        </telerik:RadTreeView>
    </div>
</div>
