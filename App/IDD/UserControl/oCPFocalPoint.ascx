<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oCPFocalPoint.ascx.cs" Inherits="App_IDD_UserControl_oCPFocalPoint" %>

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

<table style="color: black">
    <tr>
        <td>
            <asp:Label ID="Label14" runat="server" Text="Select Your Decision:"></asp:Label>
        </td>
        <td>
            <telerik:RadComboBox ID="ddlAction" runat="server" EmptyMessage="Select Your Decision..." RenderMode="Lightweight" Skin="Office2010Silver" Width="300px">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label15" runat="server" Text="Search for Analyst:"></asp:Label>
        </td>
        <td>
            <telerik:RadComboBox ID="ddlAnalyst" runat="server" EmptyMessage="Select IDD Analyst..." RenderMode="Lightweight" Skin="Office2010Silver" Width="300px">
            </telerik:RadComboBox>


            <%--<telerik:RadComboBox ID="ddlAnalyst" runat="server" DropDownWidth="500" EmptyMessage="Search for IDD Analyst..." EnableLoadOnDemand="true" Filter="Contains" Font-Size="10pt" Height="200" HighlightTemplatedItems="true" OnItemsRequested="ddlAnalyst_ItemsRequested" RenderMode="Lightweight" Skin="Office2010Silver" Width="300px">
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" style="width: 475px; font-size: 9pt">
                        <tr>
                            <td style="width: 165px;">Name</td>
                            <td style="width: 220px;">Email Address</td>
                            <td style="width: 90px;">Ref. Ind.</td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" style="width: 475px; font-size: 9pt">
                        <tr>
                            <td style="width: 165px;"><%# DataBinder.Eval(Container, "Text")%></td>
                            <td style="width: 220px;"><%# DataBinder.Eval(Container, "Attributes['EMAIL']")%></td>
                            <td style="width: 90px;"><%# DataBinder.Eval(Container, "Attributes['REFIND']")%></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </telerik:RadComboBox>--%>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label16" runat="server" Text="Comments:"></asp:Label>
        </td>
        <td>
            <telerik:RadTextBox ID="txtComment" runat="server" Height="80px" TextMode="MultiLine" Width="500px">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LabelClose" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
            <%--&nbsp;<asp:Button ID="btnRejected" runat="server" OnClick="btnRejected_Click" Text="Request Rejected" />--%>
        </td>
    </tr>
</table>
