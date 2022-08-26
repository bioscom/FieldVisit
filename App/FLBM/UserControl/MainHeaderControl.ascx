<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MainHeaderControl.ascx.cs" Inherits="App_FLBM_UserControl_MainHeaderControl" %>
<table class="tMainBorder" style="width: 100%; margin-left: auto; margin-right: auto">
    <tr>
        <td>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ShellLogo.png" />
        </td>
        <td style="vertical-align: middle; font-size: 14pt">
           <b>Assessment Record &amp; Assessor Guide:</b>  <asp:Label ID="lblHeader" runat="server" Text="Monitor and Control Hydrocarbon Process Activities"></asp:Label>
        </td>
        <td>
            <asp:Image ID="Image2" runat="server" Height="55px" ImageUrl="~/Images/i_Assessment.png" Width="57px" />
        </td>
    </tr>
</table>
<%--<hr style="width: 80%; margin-left: auto; margin-right: auto;" />--%>
