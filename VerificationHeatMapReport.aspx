<%@ Page Title="" Language="C#" MasterPageFile="~/CBIDashboard2.master" AutoEventWireup="true" CodeFile="VerificationHeatMapReport.aspx.cs" Inherits="VerificationHeatMapReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin-left: 0.5em; margin-top: 0.5em;">
        <table class="tSubGray" style="width: 99%">
            <tr>
                <td class="cHeadTile" colspan="5">RPI Verification Heat Map</td>
            </tr>
            <tr>
                <td>From:</td>
                <td>To:</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>

            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlMonth" runat="server" ValidationGroup="Filter">
                        <asp:ListItem Value="-1">Select Month...</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                <asp:DropDownList ID="ddlYear" runat="server" ValidationGroup="Filter">
                    <asp:ListItem Value="-1">Select Year...</asp:ListItem>
                </asp:DropDownList>

                </td>
                <td>
                    <asp:DropDownList ID="ddlMonthTo" runat="server" ValidationGroup="Filter">
                        <asp:ListItem Value="-1">Select Month...</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                <asp:DropDownList ID="ddlYearTo" runat="server" ValidationGroup="Filter">
                    <asp:ListItem Value="-1">Select Year...</asp:ListItem>
                </asp:DropDownList>

                </td>
                <td>
                    <asp:Button ID="btnFilter" runat="server" OnClick="btnFilter_Click" Text="Report" ValidationGroup="Filter" />

                    &nbsp;
                <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export to Excel" />

                </td>

                <td>

                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="RPI Verification Update" />

                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <hr />
                    <asp:Literal ID="ViewLiteral" runat="server"></asp:Literal>

                </td>
            </tr>
            <tr>
                <td colspan="5">&nbsp;</td>
            </tr>
        </table>
    </div>

</asp:Content>

