<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="FlareRequestRouter.aspx.cs" Inherits="FlareRequestRouter" %>

<%@ Register Src="UserControl/oRequestDetails.ascx" TagName="oRequestDetails" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/FlareWaiverStyles.css" type="text/css" rel="stylesheet" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="width:98%">
        <tr>
            <td style="width: 40%">
                <uc1:oRequestDetails ID="oRequestDetails1" runat="server" />
            </td>
            <td>
                <table style="width: 99%" class="tMainBorder">
                    <tr class="cHeadTile">
                        <td>&nbsp;</td>
                        <td colspan="2">Pending with...</td>
                        <td colspan="2">Re-route to...</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Font-Bold="True"
                                Text="Line Manager:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblLineMgr" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblLineMgrStand" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLineMgr" runat="server" Height="20px" Width="200px">
                                <asp:ListItem Value="-1">Select Line Manager</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="lineMgrBtn" runat="server" Text="Forward" Width="80px" OnClick="lineMgrBtn_Click" Font-Underline="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Font-Bold="True"
                                Text="GM Asset:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblAssetGM" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblAssetGMgrStand" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAssetGM" runat="server" Height="20px" Width="200px">
                                <asp:ListItem Value="-1">Select Asset GM</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="assetGMBtn" runat="server" Text="Forward" Width="80px" OnClick="assetGMBtn_Click" Font-Underline="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Manager Flared Gas:"  Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblProdServMgr" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblProdServStand" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProdServMgr" runat="server" Height="20px" Width="200px">
                                <asp:ListItem Value="-1">Select Production Serv. Mgr</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="prodServMgrBtn" runat="server" Text="Forward" Width="80px" OnClick="prodServMgrBtn_Click" Font-Underline="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="GM Production:" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblGMProd" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblGMProdStand" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGMProd" runat="server" Height="20px" Width="200px">
                                <asp:ListItem Value="-1">Select GM Production</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="GMprodBtn" runat="server" Text="Forward" Width="80px" OnClick="GMprodBtn_Click" Font-Underline="True" />
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>