<%@ Control Language="C#" AutoEventWireup="true" CodeFile="fieldVisitInformation.ascx.cs" Inherits="UserControl_fieldVisitInformation" %>

<table style="width:100%">
    <tr>
        <td style="width:50%">
            <table class="tSubGray">
                <tr>
                    <td class="cHeadLeft" colspan="2">
                        Field Visit Detail Information</td>
                </tr>
                <tr>
                    <td style="width:150px">
                        Activity ID:</td>
                    <td>
                        <asp:Label ID="activityIDLabel" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Planned Dates:</td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label31" runat="server" Text="From:"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                        <asp:Label ID="fromDateLabel" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label32" runat="server" Text="To:"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                        <asp:Label ID="toDateLabel" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        Field:</td>
                    <td>
                        <asp:Label ID="fieldLabel" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        District:</td>
                    <td>
                        <asp:Label ID="districtLabel" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Superintendent:</td>
                    <td>
                        <asp:Label ID="superintendentLabel" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Account to Charge:</td>
                    <td>
                        <asp:Label ID="acctToChargeLabel" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
            </table>
        </td>
        <td style="width:50%">
            <table class="tSubGray" style="width:100%">
                <tr>
                    <td class="cHeadLeft">
                        Task Description</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="taskDescriptionLabel" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            
            <table class="tSubGray" style="width:100%">
                <tr>
                    <td class="cHeadLeft">
                        General Comments <asp:Label ID="lblNew" runat="server" CssClass="Warning" Font-Italic="True" Text="*New"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="generalCommentsLabel" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>