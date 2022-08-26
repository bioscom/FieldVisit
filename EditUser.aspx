<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="Forms_EditUser" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        body {
            font: 14px/1.4 Helvetica, Arial, sans-serif;
        }

        button.RadButton span.rbIcon {
            vertical-align: sub;
        }

        .rdfLabel.rdfBlock {
            margin-top: 6px;
        }
    </style>

</head>
<body>

    <form id="form1" runat="server">
        <table style="width: 60%" class="tMainBorder">
            <tr>
                <td class="cHeadTile">
                    <asp:Label ID="Label13" runat="server" Font-Bold="True" ForeColor="#003366" Text="Edit User"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="ckbAbsoluteRight" runat="server" AutoPostBack="True" OnCheckedChanged="ckbAbsoluteRight_CheckedChanged" Text="Enable/Disable Right to view Cost Saving  absolute Values" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" Width="100%" ShowHeader="false">
                        <Columns>

                            <asp:TemplateField>
                                <ItemTemplate>

                                    <table style="border: none">
                                        <tr>
                                            <td colspan="2">
                                                <b>
                                                    <asp:Label ID="labelFullName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label></b>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td><b>Field Visit:</b></td>
                                            <td>
                                                <asp:DropDownList ID="ddlUserRoleFieldVisit" Width="300px" runat="server">
                                                    <asp:ListItem Value="-1">[Select Role]</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td><b>Cost Transparency:</b></td>
                                            <td>
                                                <asp:DropDownList ID="ddlUserRoleCostTrans" Width="300px" runat="server">
                                                    <asp:ListItem Value="-1">[Select Role]</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td><b>Bright Ideas:</b></td>
                                            <td>
                                                <asp:DropDownList ID="ddlUserRoleBI" Width="300px" runat="server">
                                                    <asp:ListItem Value="-1">[Select Role]</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td><b>Flare Waiver:</b></td>
                                            <td>
                                                <asp:DropDownList ID="ddlUserRoleFlare" Width="300px" runat="server">
                                                    <asp:ListItem Value="-1">[Select Role]</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td><b>Initiative Mgt:</b></td>
                                            <td>
                                                <asp:DropDownList ID="ddlUserRoleInitMgt" Width="300px" runat="server">
                                                    <asp:ListItem Value="-1">[Select Role]</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td><b>Lean Mgt:</b></td>
                                            <td>
                                                <asp:DropDownList ID="ddlUserRoleLean" Width="300px" runat="server">
                                                    <asp:ListItem Value="-1">[Select Role]</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>

                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float:right">
                        <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Submit"
                            ToolTip="Click to submit this form" Width="100px" ValidationGroup="NewUser" />
                        
                <%--&nbsp;<asp:Button ID="closeButton" runat="server" OnClick="closeButton_Click" Text="Close"
                    ValidationGroup="xxxx" />--%>
                    </div>

                </td>
            </tr>
        </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="NewUser" />
    </form>
</body>
</html>



<%--<asp:Content ID="Content2" ContentPlaceHolderID="RightColumn" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>








</asp:Content>--%>

