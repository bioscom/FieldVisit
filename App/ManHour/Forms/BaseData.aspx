<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterManHour.master" AutoEventWireup="true" CodeFile="BaseData.aspx.cs" Inherits="Forms_BaseData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tMainBorder">
        <tr>
            <td class="cHeadTile">Base Data</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdView" runat="server" AllowSorting="True"
                    AutoGenerateColumns="False" OnPageIndexChanged="grdView_PageIndexChanged"
                    OnPageIndexChanging="grdView_PageIndexChanging"
                    ShowFooter="true"
                    OnRowEditing="grdView_RowEditing" OnRowCancelingEdit="grdView_RowCancelingEdit"
                    OnRowUpdating="grdView_RowUpdating"
                    DataKeyNames="IDBASE" FooterStyle-Height="20px"
                    Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField ShowEditButton="True" />

                        <asp:TemplateField HeaderText="Discipline">
                            <ItemTemplate>
                                <asp:Label ID="lblDiscipline" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DISCIPLINE") %>'
                                     IDDISCIPLINE='<%# DataBinder.Eval(Container.DataItem, "IDDISCIPLINE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="No of Personnel" HeaderStyle-HorizontalAlign="Left">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNoOfPersonnel" runat="server" Text='<%# Eval("NOOFPERSONNEL") %>' Width="50px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNoOfPersonnel" runat="server" ControlToValidate="txtNoOfPersonnel"
                                    ErrorMessage="Please Enter No of personnel" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Update">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblNoOfPersonnel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NOOFPERSONNEL") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Current Base Load / Month" HeaderStyle-HorizontalAlign="Left">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtBaseLoad" runat="server" Text='<%# Eval("BASELOADMNT") %>' Width="50px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorBaseLoad" runat="server" ControlToValidate="txtBaseLoad"
                                    ErrorMessage="Please Enter Current Base Load/Month" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Update">*</asp:RequiredFieldValidator>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblBaseLoad" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BASELOADMNT") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

