<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oIDDProgressReport.ascx.cs" Inherits="App_IDD_UserControl_oIDDProgressReport" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<div style="float: right">
    <table style="color: black">
        <tr>
            <td>Status: </td>
            <td>
                <telerik:RadComboBox ID="ddlStatusFilter" runat="server" EmptyMessage="Select Status..." Width="500px"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>Comment:</td>
            <td>
                <telerik:RadTextBox ID="txtComments" Runat="server" Width="500px" TextMode="MultiLine" Height="100px">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
            </td>
        </tr>
    </table>
</div>
