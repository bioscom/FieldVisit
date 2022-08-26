<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PDCC.master" AutoEventWireup="true" CodeFile="UpdateMonthyPerformance.aspx.cs" Inherits="App_PDCC_UpdateMonthyPerformance" %>

<%@ Register Src="../../UserControls/userFinder/Search4LocalUser2.ascx" TagName="Search4LocalUser2" TagPrefix="uc5" %>
<%@ Register Src="../../UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc4" %>
<%@ Register Src="UserControl/statusSelectorControl.ascx" TagName="statusSelectorControl" TagPrefix="uc3" %>

<%@ Register Src="UserControl/ActivityLogCntl.ascx" TagName="ActivityLogCntl" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <script lang="javascript" type="text/javascript" src="../../JavaScript/fieldVisit.js"></script>
    <%--<div>--%>
        <div style="float: left; ">
            <uc2:ActivityLogCntl ID="ActivityLogCntl1" runat="server" />
            <table class="tMainBorder" style="width: 700px">
                <tr>
                    <td class="cHeadTile" colspan="2">Update
                Cost Opportunity Performance</td>
                </tr>
                <tr>
                    <td>Pot. Savings(F$mln):</td>
                    <td>
                        <asp:TextBox ID="txtPotSavings" runat="server" Width="110px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Act. Savings(F$mln):</td>
                    <td>
                        <asp:TextBox ID="txtActSavings" runat="server" Width="110px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Comment:</td>
                    <td>
                        <asp:TextBox ID="txtComment" runat="server" Height="100px" TextMode="MultiLine" Width="450px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                        &nbsp;<asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Close" ValidationGroup="close" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                    </td>
                </tr>
            </table>
        </div>
        <%--<div style="float: left">
            
        </div>
    </div>--%>

</asp:Content>

