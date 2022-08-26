<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Forms_SEPCiN_Approval_Default" %>

<%@ Register Src="~/App/FieldVisit/UserControl/FPEC/fieldVisitInformation.ascx" TagName="fieldVisitInformation" TagPrefix="uc2" %>

<%@ Register Src="~/App/FieldVisit/UserControl/SEPCiN/PecRequestInfo.ascx" TagName="PecRequestInfo" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td style="width: 50%">
                <uc3:PecRequestInfo ID="PecRequestInfo1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <table class="tMainBorder">
                    <%-- style="width:550px"--%>
                    <tr>
                        <td class="cHeadTile" colspan="2">&nbsp;
                <asp:Label ID="SupportLabel" runat="server" Font-Bold="True"
                    ForeColor="#003366"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Stand:"></asp:Label>
                            <asp:CompareValidator ID="CompareValidator1" runat="server"
                                ControlToValidate="drpStand" ErrorMessage="Please select your stand"
                                Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpStand" runat="server" Width="200px">
                                <asp:ListItem Value="-1">Select Stand</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Comments:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="CommentTextBox" runat="server" Height="100px" Text=""
                                TextMode="MultiLine" Width="400px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click"
                                Text="Submit" Width="100px" />

                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                    ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
    </table>

</asp:Content>

