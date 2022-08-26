<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oAnalystAction.ascx.cs" Inherits="App_IDD_UserControl_oAnalystAction" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<script type="text/javascript">
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

</script>



<table style="color: black; width: 570px; font-size: 12pt">
    <tr>
        <td style="width: 150px">
            <asp:Label ID="Label14" runat="server" Text="Select Decision:"></asp:Label>
        </td>
        <td>
            <telerik:RadComboBox ID="ddlAction" runat="server" EmptyMessage="Select Your Decision..." RenderMode="Lightweight" Skin="Office2010Silver" Width="300px"></telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td style="width: 150px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label15" runat="server" Text="Select status:"></asp:Label>
        </td>
        <td>
            <telerik:RadRadioButtonList ID="btnLstStatus" runat="server" AutoPostBack="true" Columns="5" Direction="Horizontal" OnSelectedIndexChanged="btnlstCompleted_SelectedIndexChanged"></telerik:RadRadioButtonList>
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
        <td>&nbsp;</td>
        <td>
            <asp:Panel ID="pnlColour" Height="20px" Width="100%" runat="server">
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Panel runat="server" ID="Hider" Visible="false">
                <telerik:RadDatePicker RenderMode="Lightweight" ID="ValidityPeriod" Width="250px" runat="server" DateInput-Label="Effective Date:"></telerik:RadDatePicker>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label16" runat="server" Text="Comments:"></asp:Label>
        </td>
        <td>
            <telerik:RadTextBox ID="txtComment" runat="server" Height="80px" TextMode="MultiLine" Width="400px"></telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LabelClose" runat="server"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        </td>
    </tr>
</table>
