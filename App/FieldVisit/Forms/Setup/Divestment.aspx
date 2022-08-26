<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/configuration.master" AutoEventWireup="true" CodeFile="Divestment.aspx.cs" Inherits="App_FieldVisit_Forms_Setup_Divestment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightColumn" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tSubGray" style="width: 70%">
                <tr>
                    <td colspan="2" class="cHeadTile">Facility Divestment Management</td>
                </tr>
                <tr>
                    <td style="width:150px">Superintendent:<asp:CompareValidator ID="CompareValidator1" runat="server"
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
                    <td colspan="2">
                        <asp:GridView ID="grdView" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
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
                                        <asp:CheckBox ID="ckbDivestment" runat="server" FACILITYID='<%# DataBinder.Eval(Container.DataItem, "ID_FACILITIES")%>' DIVESTED='<%# DataBinder.Eval(Container.DataItem, "DIVESTED") %>'></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            
                                <asp:TemplateField HeaderText="Superintendent">
                                    <ItemTemplate>
                                        <asp:Label ID="labelSuperintendent" runat="server" Font-Bold="True" ForeColor="#003366" Text='<%# DataBinder.Eval(Container.DataItem, "SUPERINTENDENT") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="District">
                                    <ItemTemplate>
                                        <asp:Label ID="labelDistrict" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DISTRICT") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Facility">
                                    <ItemTemplate>
                                        <asp:Label ID="labelFacility" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Divestment">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDivestment" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DIVESTED") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="submitButton" runat="server" Width="100px" Text="Submit" OnClick="submitButton_Click"
                            ValidationGroup="facility" />
                        <asp:HiddenField ID="idFacilityHF" runat="server" />
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                ShowMessageBox="True" ShowSummary="False" ValidationGroup="facility" />
            <br />
            <br />

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

