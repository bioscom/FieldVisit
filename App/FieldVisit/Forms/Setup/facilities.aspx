<%@ Page Language="C#" MasterPageFile="~/MasterPages/configuration.master" AutoEventWireup="true" CodeFile="facilities.aspx.cs" Inherits="Setup_facilities" Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightColumn" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <table>
                <tr>
                    <td>
                        <table class="tSubGray">
                            <tr>
                                <td colspan="2" class="cHeadTile">Facilities</td>
                            </tr>
                            <tr>
                                <td>Superintendent:<asp:CompareValidator ID="CompareValidator1" runat="server"
                                    ControlToValidate="drpSuperintendents"
                                    ErrorMessage="Please Select Superintendent" Type="Integer"
                                    ValueToCompare="-1" Operator="NotEqual" ValidationGroup="facility">*</asp:CompareValidator>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpSuperintendents" runat="server" Width="300px"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="drpSuperintendents_SelectedIndexChanged">
                                        <asp:ListItem Value="-1">Select Superintendent...</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>District:<asp:CompareValidator ID="CompareValidator2" runat="server"
                                    ControlToValidate="drpDistrict"
                                    ErrorMessage="Please Select District" Type="Integer" ValueToCompare="-1"
                                    Operator="NotEqual" ValidationGroup="facility">*</asp:CompareValidator>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpDistrict" runat="server" Width="300px"
                                        AutoPostBack="True" OnSelectedIndexChanged="drpDistrict_SelectedIndexChanged">
                                        <asp:ListItem Value="-1">Select District...</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Facility:<asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                    runat="server" ControlToValidate="facilitiesTextBox"
                                    ErrorMessage="Facility is required" ValidationGroup="facility">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="facilitiesTextBox" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click"
                                        ValidationGroup="facility" />
                                    <asp:HiddenField ID="idFacilityHF" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="facility" />
                    </td>
                    <td>
                        <asp:GridView ID="grdView" runat="server" AllowPaging="True"
                            AutoGenerateColumns="False" OnPageIndexChanging="grdView_PageIndexChanging"
                            OnRowCommand="grdView_RowCommand" PageSize="50" Width="100%">
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
                                            ID_FACILITIES='<%# DataBinder.Eval(Container.DataItem, "ID_FACILITIES") %>'>Edit</asp:LinkButton>
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

                                <asp:TemplateField HeaderText="Facility">
                                    <ItemTemplate>
                                        <asp:Label ID="labelFacility" runat="server"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <br />
            <br />

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

