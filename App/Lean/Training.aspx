<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/LeanMasterPage.master" AutoEventWireup="true" CodeFile="Training.aspx.cs" Inherits="App_Lean_Training" %>

<%@ Register Src="../../UserControls/userFinder/Search4LocalUser2.ascx" TagName="Search4LocalUser2" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <center>
    <h3>Capability – Training & Certifications</h3>
    <table class="tSubGray" style="width: 60%">
        <tr>
            <td class="cHeadTile">
                Training and Certification</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" Width="200px">
                    <asp:ListItem Value="-1">Select Year...</asp:ListItem>
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="ddlYear" ErrorMessage="Please select year" Operator="NotEqual" Type="Integer" ValueToCompare="-1" ValidationGroup="Personnel">*</asp:CompareValidator>
                <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Close" Width="100px" />
                <br />
                <asp:LinkButton ID="addLinkButton" ValidationGroup="oooo" runat="server" OnClick="addLinkButton_Click">Add New Person Trained</asp:LinkButton>
                <br /><br />
        <asp:Panel ID="infoPanel" runat="server">
                    <table class="tSubGray" style="width: 60%">
                        <tr>
                            <td style="width:150px">Person Trained:</td>
                            <td>
                                <uc2:Search4LocalUser2 ID="PersonTrained" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Trainers:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTrainers" ErrorMessage="Enter names of trainers" ValidationGroup="Personnel">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTrainers" runat="server" Height="70px" TextMode="MultiLine"
                                    Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Type of Training:<asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddlTrainingType" ErrorMessage="Training Type is required" Operator="NotEqual" Type="Integer" ValueToCompare="-1" ValidationGroup="Personnel">*</asp:CompareValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTrainingType" runat="server" Width="200px">
                                    <asp:ListItem Value="-1">Select Training Type...</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Department:<asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlDept" ErrorMessage="Department is required" Operator="NotEqual" Type="Integer" ValueToCompare="-1" ValidationGroup="Personnel">*</asp:CompareValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDept" runat="server" Width="200px">
                                    <asp:ListItem Value="-1">Select Department...</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Function:<asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="ddlFunction" ErrorMessage="Function is required" Operator="NotEqual" Type="Integer" ValueToCompare="-1" ValidationGroup="Personnel">*</asp:CompareValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFunction" runat="server" Width="200px">
                                    <asp:ListItem Value="-1">Select Function...</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="Add"
                                    Width="100px" ValidationGroup="Personnel" />
                                &nbsp;<asp:Button ID="cancleButton" runat="server" Text="Cancel" Width="100px" OnClick="cancleButton_Click" ValidationGroup="cancel" />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Personnel" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <br />
                <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                    OnPageIndexChanging="grdView_PageIndexChanging" OnRowCommand="grdView_RowCommand"
                    OnRowCancelingEdit="grdView_RowCancelingEdit" AllowPaging="True"
                    OnRowDataBound="grdView_RowDataBound" OnRowDeleting="grdView_RowDeleting" PageSize="25"
                    OnRowEditing="grdView_RowEditing" OnRowUpdating="grdView_RowUpdating" DataKeyNames="IDTRAINING"
                    Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="..." ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                            <EditItemTemplate>
                                <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                    Text="Update" OnClientClick="return confirm('Update?')" ValidationGroup="iPersonnel"></asp:LinkButton>
                                <asp:ValidationSummary ID="vsUpdate" runat="server" ShowMessageBox="true" ShowSummary="false"
                                    ValidationGroup="iPersonnel" Enabled="true" HeaderText="Validation Summary..." />
                                <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                    ValidationGroup="iPersonnel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                    Text="Edit" ValidationGroup="iPersonnel"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Person Trained">
                            <EditItemTemplate>
                                <uc2:Search4LocalUser2 ID="ddlPersonTrained" runat="server" />
                                <%--<asp:TextBox ID="txtName" runat="server" Text='<%# Eval("FULLNAME") %>'></asp:TextBox>--%>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="labelPersonTrained" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Training Type">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlTrainingType" runat="server"></asp:DropDownList>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblTrainingType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TYPE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Department">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlDept" runat="server"></asp:DropDownList>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblDept" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DEPARTMENT") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Function">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlFunction" runat="server"></asp:DropDownList>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblFunction" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "FUNCTION") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Trainers">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTrainers" runat="server" TextMode="MultiLine" Height="70px" Width="250px" Text='<%# Eval("TRAINERS") %>'></asp:TextBox>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblTrainers" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TRAINERS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="..." ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                    ValidationGroup="iPersonnel" Text="Delete" OnClientClick="return confirm('Delete?')"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>

                

                
            </td>
        </tr>
    </table>
        </center>
</asp:Content>

