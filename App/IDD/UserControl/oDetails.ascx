<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oDetails.ascx.cs" Inherits="App_IDD_UserControl_oDetails" %>

<table style="color: black; width: 99%">
    <tr>
        <td style="width: 450px">
            <asp:Label ID="Label1" runat="server" Text="Vendor's Full Registered Name:" Font-Bold="true"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblRegisteredName" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <hr />
        </td>
    </tr>
    <tr>
        <td>
            <table style="color: black">
                <tr>
                    <td style="width: 200px">
                        <asp:Label ID="Label100" runat="server" Text="IDD Number:" Font-Bold="true"></asp:Label>
                        <%--<asp:HiddenField runat="server" ID="REQUESTIDHF" Value='<%# Eval("REQUESTID") %>' />--%>
                    </td>
                    <td>
                        <asp:Label ID="lblIDDNo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <asp:Label ID="Label18" runat="server" Text="Nature of Request:" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblNatureOfRequest" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="width: 200px">
                        <asp:Label ID="Label2" runat="server" Text="Vendor's Code:" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblVendorCode" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="Material/Services:" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCategory" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Vendor's Address:" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Company Representative:" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblRepresentative" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="E-mail address:" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEmailAddress" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Telephone(GSM NO):" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbltelephoneNumber" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </td>
        <td>
            <table style="color: black">
                <tr>
                    <td>
                        <asp:Label ID="Label17" runat="server" Text="Value of Contract (if any) in US$:" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAmount" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label20" runat="server" Text="Does Business Ownership have Government official element?:" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGO" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label21" runat="server" Text="Will the counterparty be acting as a Government Intermediary (GI)?:" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblGI" runat="server"></asp:Label>
                    </td>
                </tr>

            </table>

        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table style="width: 100%">
                <tr>
                    <td colspan="6">
            <hr />
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <asp:Label ID="Label9" runat="server" Font-Bold="true" Text="Request initiator:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblContractHolder" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label10" runat="server" Font-Bold="true" Text="CP IDD Focal Point:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblFocalPoint" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Font-Bold="true" Text="IDD Analyst:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAnalyst" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
