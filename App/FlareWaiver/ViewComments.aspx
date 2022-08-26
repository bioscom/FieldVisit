<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="ViewComments.aspx.cs" Inherits="ViewComments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/FlareWaiverStyles.css" type="text/css" rel="stylesheet" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 99%" class="tMainBorder">
                <tr class="cHeadTile">
                    <td>&nbsp;</td>
                    <td style="width: 150px">
                        <asp:Label ID="Label9" runat="server" Text="Approver"></asp:Label>
                    </td>
                    <td style="width: 150px">
                        <asp:Label ID="Label34" runat="server" Text="..."></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="Stand"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="Comment"></asp:Label>
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="Label12" runat="server" Text="Received on"></asp:Label>
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="Label45" runat="server" Text="Reviewed on"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color: #FFFFCC">
                    <td colspan="7">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="lineMgrCkb" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="Line Manager" Font-Bold="True" ForeColor="#003366"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblLineMgr" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblLineMgrStand" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblLineMgrComments" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblLineMgrDateRcd" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblLineMgrDateRvd" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="background-color: #FFFFCC">
                    <td>
                        <asp:CheckBox ID="PSMgrCkb" runat="server" />
                    </td>

                    <td>
                        <asp:Label ID="Label32" runat="server" Text="Assurance (PS Mgr)"
                            Font-Bold="True" ForeColor="#003366"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPSMgr" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPSMgrStand" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPSMgrComment" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPSMgrDateRcd" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPSMgrDateRvd" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="AssuranceCkb" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="#003366"
                            Text="Assurance (SPDC/SNEPCo)"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAssuranceGM" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAssuranceStand" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAssuranceComments" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAssuranceDateRcd" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAssuranceDateRvd" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="background-color: #FFFFCC">
                    <td>
                        <asp:CheckBox ID="ApprovalCkb" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="Label17" runat="server" Text="Approval" Font-Bold="True" ForeColor="#003366"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblApproval" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblApprovalStand" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblApprovalComment" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblApprovalDateRcd" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblApprvalDateRvd" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr style="background-color: white">
                    <td colspan="7">
                        <asp:Button ID="forwardReminderButton" runat="server" Text="Send Reminder"
                            OnClick="forwardReminderButton_Click" Width="120px" />
                    </td>
                </tr>
            </table>
            <br />
            <app:oRequestDetails ID="oRequestDetails1" runat="server" />
        </div>
    </form>
</body>
</html>
