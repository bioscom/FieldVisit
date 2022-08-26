<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="FlareApprovalProc.aspx.cs" Inherits="FlareApprovalProc" %>

<%--<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="FlareTarget.aspx.cs" Inherits="App_FlareWaiver_FlareTarget" %>--%>



<%@ Register Src="UserControl/oRequestDetails.ascx" TagName="oRequestDetails" TagPrefix="uc1" %>
<%@ Register Src="WorkOrder.ascx" TagName="WorkOrder" TagPrefix="uc2" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/FlareWaiverStyles.css" type="text/css" rel="stylesheet" media="screen" />
</head>
<body>
    <form id="form1" runat="server">--%>

        <asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

        <div>

            <table style="width: 700px">
                <tr>
                    <td>
                        <table class="tMainBorder" style="width: 99%">
                            <tr>
                                <td class="cHeadTile" colspan="2">
                                    <asp:Label ID="approverLabel" runat="server" Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Stand"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdbSupport" ErrorMessage="Your stand is required">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rdbSupport" runat="server" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                        <table class="tMainBorder" style="width: 99%">
                            <tr>
                                <td class="cHeadTile">
                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Add comments here"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtComment" runat="server" Height="100px" Text=""
                                        TextMode="MultiLine" Width="99%"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div style="float: right">
                                        <asp:Button ID="submitBtn" runat="server" OnClick="submitBtn_Click"
                                            Text="Submit" Width="100px" />

                                        &nbsp;<asp:Button ID="closeButton" runat="server" OnClick="closeButton_Click"
                                            Text="Close" ValidationGroup="close" Width="100px" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <uc1:oRequestDetails ID="oRequestDetails1" runat="server" />
                    </td>
                </tr>
            </table>
            <uc2:WorkOrder ID="WorkOrder1" runat="server" />
            <br />
            <br />
            <br />
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
        </div>

</asp:Content>
    <%--</form>
</body>
</html>--%>
