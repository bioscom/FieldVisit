<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FlareTargetFrm.aspx.cs" Inherits="App_FlareWaiver_FlareTargetFrm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>Add New Flare Target</h4>
            <table style="width: 100%; background-color: white; border-collapse: separate; padding: 7px 4px 12px 4px" border="0" id="gvEG">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>Facility:</td>
                    <td>
                        <asp:DropDownList ID="ddlFacility" runat="server" Width="250px">
                            <asp:ListItem Value="-1">Select Facility</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Code:</td>
                    <td>
                        <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>January:</td>
                    <td>
                        <asp:TextBox ID="txtJan" runat="server"></asp:TextBox>
                        (mscfd)</td>
                </tr>
                <tr>
                    <td>February:</td>
                    <td>
                        <asp:TextBox ID="txtFeb" runat="server"></asp:TextBox>
                        (mscfd)</td>
                </tr>
                <tr>
                    <td>March:</td>
                    <td>
                        <asp:TextBox ID="txtMar" runat="server"></asp:TextBox>
                        (mscfd)</td>
                </tr>
                <tr>
                    <td>April:</td>
                    <td>
                        <asp:TextBox ID="txtApr" runat="server"></asp:TextBox>
                        (mscfd)</td>
                </tr>
                <tr>
                    <td>May:</td>
                    <td>
                        <asp:TextBox ID="txtMay" runat="server"></asp:TextBox>
                        (mscfd)</td>
                </tr>
                <tr>
                    <td>June:</td>
                    <td>
                        <asp:TextBox ID="txtJun" runat="server"></asp:TextBox>
                        (mscfd)</td>
                </tr>
                <tr>
                    <td>July:</td>
                    <td>
                        <asp:TextBox ID="txtJul" runat="server"></asp:TextBox>
                        (mscfd)</td>
                </tr>
                <tr>
                    <td>August:</td>
                    <td>
                        <asp:TextBox ID="txtAug" runat="server"></asp:TextBox>
                        (mscfd)</td>
                </tr>
                <tr>
                    <td>September:</td>
                    <td>
                        <asp:TextBox ID="txtSep" runat="server"></asp:TextBox>
                        (mscfd)</td>
                </tr>
                <tr>
                    <td>October:</td>
                    <td>
                        <asp:TextBox ID="txtOct" runat="server"></asp:TextBox>
                        (mscfd)</td>
                </tr>
                <tr>
                    <td>November:</td>
                    <td>
                        <asp:TextBox ID="txtNov" runat="server"></asp:TextBox>
                        (mscfd)</td>
                </tr>
                <tr>
                    <td>December:</td>
                    <td>
                        <asp:TextBox ID="txtDec" runat="server"></asp:TextBox>
                        (mscfd)</td>
                </tr>
                <tr>
                    <td>YTD:</td>
                    <td>
                        <asp:TextBox ID="txtYTD" runat="server"></asp:TextBox>
                        (mscfd)</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="lnkAdd" runat="server" Text="Submit" ValidationGroup="Add" Width="100px" OnClick="lnkAdd_Click" />&nbsp;&nbsp;
                <asp:Button ID="closeButton" runat="server" Text="Close" ValidationGroup="xxxx" Width="100px" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
