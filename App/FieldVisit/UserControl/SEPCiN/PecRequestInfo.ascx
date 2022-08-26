<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PecRequestInfo.ascx.cs" Inherits="UserControl_SEPCiN_PecRequestInfo" %>

<table style="width:100%">
    <tr>
        <td style="width:33%">
            <table class="tSubGray">
                <tr>
                    <td class="cHeadLeft" colspan="2">
                        PEC Request Detail Information</td>
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
                        Initiator:</td>
                    <td>
                        <asp:Label ID="initiatorLabel" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
        <td style="width:34%">
            <table class="tSubGray">
                <tr>
                    <td class="cHeadLeft">
                        Activity Description</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="taskDescriptionLabel" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <table class="tSubGray">
                <tr>
                    <td class="cHeadLeft">
                        Justification</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="justificationLabel" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
