<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WorkOrder.ascx.cs" Inherits="UserControl_WorkOrder" %>
<table style="width: 700px">
    <tr>
        <td>
            <table class="tMainBorder" style="width: 99%">
                <tr>
                    <td class="cHeadTile" colspan="2">Work Plan</td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="OpenPDFHyperLink" runat="server" NavigateUrl="../../WorkOrder.pdf" Target="_blank">Open PDF into New Page</asp:HyperLink>
                    </td>
                    <td>Click
                            <asp:ImageButton ID="refreshPageImageButton" runat="server" ImageUrl="~/Images/Refresh.jpg" Width="20px" />
                        &nbsp;to refresh</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <iframe id="fileLoader" name="fileLoader" style="width: 99%; height: 436px" runat="server" scrolling="auto"></iframe>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

<asp:HiddenField ID="workOrderFileNameHF" runat="server" />
