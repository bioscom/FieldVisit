<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WhatWhyConsequences.ascx.cs" Inherits="App_Contract_UserControls_WhatWhyConsequences" %>

<%@ Register Src="~/UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>

<table class="tMainBorder" style="width: 98%">
    <tr>
        <td class="cHeadTile">OPERATIONS SUPERINTENDENT 14 DAY CONTRACT</td>
    </tr>
    <tr>
        <td>
            <div>
                <div style="float: left">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Trip Start Date:"></asp:Label>
                </div>
                <div style="float: left">
                    <uc2:dateControl ID="dtTripStart" runat="server" />
                </div>
            </div>
        </td>
    </tr>

    <tr>
        <td valign="top">
            <%--<asp:Panel ID="rptViewPanel" runat="server">
                <rsweb:reportviewer id="rptViewer" runat="server" bordercolor="Black"
                    borderstyle="Solid" borderwidth="1px" font-names="Verdana" font-size="8pt"
                    height="600px" width="100%" waitmessagefont-names="Verdana" waitmessagefont-size="14pt">
                                        </rsweb:reportviewer>
            </asp:Panel>--%>
        </td>
    </tr>
</table>


<table style="width: 810px" class="tMainBorder">
    <tr>
        <td class="cHeadTile">Report</td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnExportPDF" runat="server" OnClick="btnExportPDF_Click" Text="Export to PDF" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="ViewLiteral" runat="server"></asp:Literal>
        </td>
    </tr>
</table>
