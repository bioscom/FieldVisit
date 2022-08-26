<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oVMIDDApproval.ascx.cs" Inherits="App_IDD_UserControl_oVMIDDApproval" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    <Scripts>
        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
    </Scripts>
</telerik:RadScriptManager>

<%--<script type="text/javascript">
    function CloseAndRebind(args) {
        GetRadWindow().BrowserWindow.refreshGrid(args);
        GetRadWindow().close();
    }

    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

        return oWindow;
    }

    function CancelEdit() {
        GetRadWindow().close();
    }
</script>--%>

<table style="color: black; width: 600px; font-size: 11pt">
    <tr>
        <td style="width: 200px">
            <asp:Label ID="Label14" runat="server" Text="Select Remarks:"></asp:Label>
        </td>
        <td>
            <telerik:RadComboBox ID="ddlRemarks" runat="server" EmptyMessage="Select Your Remark..." RenderMode="Lightweight" Skin="Office2010Silver" Width="300px"></telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label15" runat="server" Text="Select status:"></asp:Label>
        </td>
        <td>
            <telerik:RadRadioButtonList ID="btnLstStatus" runat="server" AutoPostBack="False" Columns="5" Direction="Horizontal"></telerik:RadRadioButtonList>
        </td>
    </tr>

    <%--<tr>
        <td>
            <asp:Label ID="Label18" runat="server" Text="Completed?:"></asp:Label>
        </td>
        <td>
        <telerik:RadRadioButtonList ID="btnlstCompleted" runat="server" Columns="2" Direction="Horizontal" OnSelectedIndexChanged="btnlstCompleted_SelectedIndexChanged"></telerik:RadRadioButtonList>
        </td>
    </tr>--%>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Panel ID="pnlColour" Height="20px" Width="100%" runat="server">
            </asp:Panel>
        </td>
    </tr>

    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Panel runat="server" ID="Hider" Visible="false">
                <telerik:RadDatePicker RenderMode="Lightweight" ID="ValidityPeriod" Width="250px" DateInput-DisplayDateFormat="dd-MMM-yyyy" runat="server" DateInput-Label="Effective Date:"></telerik:RadDatePicker>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label16" runat="server" Text="IDD Analyst Comments:"></asp:Label>
        </td>
        <td>
            <telerik:RadTextBox ID="txtComment" runat="server" Height="80px" TextMode="MultiLine" Width="400px"></telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <hr />
        </td>
    </tr>
    <tr>
        <td>Move status to VSR?:</td>
        <td>
            <telerik:RadRadioButtonList ID="rdbApproved" runat="server" Columns="2" Direction="Horizontal"></telerik:RadRadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label17" runat="server" Text="VM/IDD Lead Comments:"></asp:Label>
        </td>
        <td>
            <telerik:RadTextBox ID="txtApproverComments" Height="100px" Width="400px" TextMode="MultiLine" runat="server"></telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LabelClose" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" Width="100px" CausesValidation="False" />
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:HiddenField ID="RequestIdHF" runat="server" />
        </td>
    </tr>
</table>









