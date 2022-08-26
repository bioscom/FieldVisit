<%@ Page Language="C#" MasterPageFile="~/MasterPages/configuration.master" AutoEventWireup="true" CodeFile="Districts.aspx.cs" Inherits="Setup_Districts" Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightColumn" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <table class="tSubGray" style="width:450px">
                            <tr>
                                <td colspan="2" class="cHeadTile">Districts</td>
                            </tr>
                            <tr>
                                <td>Superintendent:<asp:CompareValidator ID="CompareValidator1" runat="server"
                                    ControlToValidate="drpSuperintendents"
                                    ErrorMessage="Please Select Superintendent" Type="Integer"
                                    ValueToCompare="-1" ValidationGroup="district" Operator="NotEqual">*</asp:CompareValidator>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpSuperintendents" runat="server" Width="300px"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="drpSuperintendents_SelectedIndexChanged">
                                        <asp:ListItem Value="-1">Select Superintendent...</asp:ListItem>
                                        <asp:ListItem Value="0">Show all Districts</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>District:<asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                    runat="server" ControlToValidate="districtTextBox"
                                    ErrorMessage="District is required" ValidationGroup="district">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="districtTextBox" runat="server" Width="301px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="submitButton" runat="server" Text="Submit"
                                        ValidationGroup="district" OnClick="submitButton_Click" />
                                    <asp:HiddenField ID="idDistrictHF" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="district" />
                    </td>
                    <td>
                        <asp:GridView ID="grdView" runat="server" AllowPaging="True"
                            AutoGenerateColumns="False"
                            OnPageIndexChanging="grdView_PageIndexChanging"
                            OnRowCommand="grdView_RowCommand" PageSize="20" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="...">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="editLinkButton" runat="server"
                                            CommandArgument="<%# Container.DisplayIndex %>" CommandName="editThis"
                                            ID_DISTRICT='<%# DataBinder.Eval(Container.DataItem, "ID_DISTRICT") %>'>Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Superintendent">
                                    <ItemTemplate>
                                        <asp:Label ID="labelSuperintendent" runat="server" Font-Bold="True"
                                            ForeColor="#003366"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "SUPERINTENDENT") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="District">
                                    <ItemTemplate>
                                        <asp:Label ID="labelDistrict" runat="server"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "DISTRICT") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

