<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oDataExportMgr.ascx.cs" Inherits="App_BONGACCP_UserControl_oDataExportMgr" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table style="width: 250px; border: 1px solid silver; border-bottom: 3px solid silver">
    <tr>
        <td>
            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlOU" Font-Size="9pt" EmptyMessage="Choose OU" runat="server" Width="150px" Skin="Office2010Silver">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlAsset" Font-Size="9pt" EmptyMessage="Choose Asset" runat="server" Width="150px" Skin="Office2010Silver">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlFacility" EmptyMessage="Choose Facility" Font-Size="9pt" runat="server" Width="150px" Skin="Office2010Silver">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlteam" EmptyMessage="Choose Team" Font-Size="9pt" runat="server" Width="150px" Skin="Office2010Silver">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlCapexOpex" Font-Size="9pt" runat="server" Width="150px" EmptyMessage="Choose Capex or Opex" Skin="Office2010Silver">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadDatePicker DateInput-DisplayDateFormat="dd-MMM-yyyy" RenderMode="Lightweight" ID="dtFrom" Width="150px" runat="server" DateInput-LabelWidth="100px" DateInput-Label="From:"></telerik:RadDatePicker>
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadDatePicker DateInput-DisplayDateFormat="dd-MMM-yyyy" RenderMode="Lightweight" ID="dtTo" Width="150px" runat="server" DateInput-LabelWidth="100px" DateInput-Label="To:"></telerik:RadDatePicker>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnExport" runat="server" Height="27px" Text="Export to Excel..." OnClick="btnExport_Click" />
        </td>
    </tr>
</table>
