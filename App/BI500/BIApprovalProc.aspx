<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BI500.master" AutoEventWireup="true" CodeFile="BIApprovalProc.aspx.cs" Inherits="BIApprovalProc" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="UserControl/oRequestDetails.ascx" TagName="oRequestDetails" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" ID="ScriptManager1" />
    <table>
        <tr>
            <td style="width:50%">
                <uc1:oRequestDetails ID="oRequestDetails1" runat="server" />
            </td>
            <td>
                <table class="tMainBorder">
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
                <table class="tMainBorder">
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
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
</asp:Content>

