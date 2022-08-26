<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BI500.master" AutoEventWireup="true" CodeFile="CorporateReviewers.aspx.cs" Inherits="App_BI500_CorporateReviewers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <table>
        <tr>
            <td>
                <table class="tMainBorder" style="width: 450px">
                    <tr>
                        <td class="cHeadTile" colspan="2">
                            Corporate Users</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label14" runat="server" Text="Corporate Overview"></asp:Label>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlCorporate" ErrorMessage="Please select Corporate Viewers" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCorporate" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="ddlCorporate_SelectedIndexChanged">
                                <asp:ListItem Value="-1">[Select Corporate User]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <table class="tMainBorder" style="width: 450px">
                    <tr>
                        <td class="cHeadTile">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#003366" Text="Business Units"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButtonList ID="rdoBusinessUnit" runat="server">
                            </asp:RadioButtonList>
                            <asp:HiddenField ID="functionIdHF" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Submit" ToolTip="Click to submit this form" ValidationGroup="NewUser" Width="100px" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table class="tMainBorder" style="width: 450px">
                    <tr>
                        <td class="cHeadTile">
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#003366" Text="Corporate Overviewers"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:BulletedList ID="bLstFocalPointBizUnit" runat="server">
                            </asp:BulletedList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

