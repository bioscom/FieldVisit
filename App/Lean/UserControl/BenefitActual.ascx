<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BenefitActual.ascx.cs" Inherits="App_Lean_UserControl_BenefitActual" %>

<style type="text/css">

        .auto-style1 {
            color: red;
        }
    </style>

<table>
    <tr>
        <td>
            <asp:Panel runat="server" ID="bntActual">
                <table class="tSubGray" style="width: 500px">
                    <tr>
                        <td class="cHeadTile" colspan="2">Benefit Actual</td>
                    </tr>
                    <tr>
                        <td>Year Benefits Derived:<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlYear" ErrorMessage="Please select year Benefit derived" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlYear" runat="server">
                                <asp:ListItem Value="-1">Select Year...</asp:ListItem>
                            </asp:DropDownList>
                        </td>

                    </tr>
                    <tr>
                        <td>Cycle Time Savings(Days):<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCTSavings" ErrorMessage="Invalid entry!!!" ValidationExpression="^\-{0,1}\d+(.\d+){0,1}$">*</asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCTSavings" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Cost Savings($) (Abs. Value):<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCostSavings" ErrorMessage="Invalid entry!!!" ValidationExpression="^\-{0,1}\d+(.\d+){0,1}$">*</asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCostSavings" runat="server"></asp:TextBox>
                            <span class="auto-style1">**Please, enter absolute values</span></td>
                    </tr>
                    <tr>
                        <td>Production Enhancement (Barrel):<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtProdBarrel" ErrorMessage="Invalid entry!!!" ValidationExpression="^\-{0,1}\d+(.\d+){0,1}$">*</asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtProdBarrel" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Number:<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtNumber" ErrorMessage="Invalid entry!!!" ValidationExpression="^\-{0,1}\d+(.\d+){0,1}$">*</asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Other Benefits:</td>
                        <td>
                            <asp:TextBox ID="txtBenefit" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Comments:</td>
                        <td>
                            <asp:TextBox ID="txtComments" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%--<asp:HiddenField ID="ActualIdHF" runat="server" />--%>
                            <asp:HiddenField ID="ProjectIdHF" runat="server" />
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Width="100px" />
                            &nbsp;<asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Close" Width="100px" ValidationGroup="xxxx" />
                        </td>

                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td style="vertical-align: top">
            <div style="vertical-align: top; margin-left: 1.5em">
                <asp:GridView ID="grdViewProjectBenefit" runat="server" AutoGenerateColumns="False"
                    OnPageIndexChanging="grdViewProjectBenefit_PageIndexChanging" OnRowCommand="grdViewProjectBenefit_RowCommand"
                    OnRowCancelingEdit="grdViewProjectBenefit_RowCancelingEdit"
                    OnRowDataBound="grdViewProjectBenefit_RowDataBound" OnRowDeleting="grdViewProjectBenefit_RowDeleting"
                    OnRowEditing="grdViewProjectBenefit_RowEditing" OnRowUpdating="grdViewProjectBenefit_RowUpdating" Width="98%">
                    <Columns>

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

                        <asp:TemplateField HeaderText="Year">
                            <%--<EditItemTemplate>
                            <asp:DropDownList ID="ddlYear" runat="server">
                                <asp:ListItem Value="-1">Select Year...</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>--%>

                            <ItemTemplate>
                                <asp:Label ID="lbYear" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "YYEAR") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Cycle Time Savings">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCTSavings" runat="server" Text='<%# Eval("CT_SAINGS") %>' Width="50px"></asp:TextBox>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lbBenefit" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CT_SAINGS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Cost Savings">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCostSavings" runat="server" Text='<%# Eval("COST_SAVINGS") %>' Width="50px"></asp:TextBox>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lbCostSavings" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COST_SAVINGS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Prod. Barrel">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtProdBarrel" runat="server" Text='<%# Eval("PRODUCTION_BARREL") %>' Width="50px"></asp:TextBox>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lbProdBarrel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PRODUCTION_BARREL") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Number*">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNumber" runat="server" Text='<%# Eval("NUMBERR") %>' Width="50px"></asp:TextBox>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lbNumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NUMBERR") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Other Benefits">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtBenefit" runat="server" Height="50px" TextMode="MultiLine" Width="300px" Text='<%# Eval("OTHER_BENEFITS") %>'></asp:TextBox>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lbOtherBenefits" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OTHER_BENEFITS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Comments">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtComments" runat="server" Height="50px" TextMode="MultiLine" Width="300px" Text='<%# Eval("COMMENTS") %>'></asp:TextBox>
                            </EditItemTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lbComments" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMMENTS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="..." ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" OnClick="btnSelect_Click"
                                    ACTUALID='<%# DataBinder.Eval(Container.DataItem, "ACTUALID") %>'
                                    IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>'
                                    OnClientClick="return confirm('Delete this benefit Actual?')" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
        </td>
    </tr>
    </table>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        

<%--<asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowFooter="True" Width="700px">
    <Columns>

        <asp:TemplateField HeaderText="Year Benefit Derived">
            <ItemTemplate>
                <asp:Label ID="lbYear" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "YYEAR") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Cycle Time Savings">
            <ItemTemplate>
                <asp:Label ID="lbCostReduction" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CT_SAVINGS") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Cost Savings">
            <ItemTemplate>
                <asp:Label ID="lbCostSavings" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COST_SAVINGS") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Production Barrels">
            <ItemTemplate>
                <asp:Label ID="lbProductionBarrels" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PRODUCTIONBARREL") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Other Benefits">
            <ItemTemplate>
                <asp:Label ID="lbOtherBenefits" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OTHER_BENEFITS") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Comments">
            <ItemTemplate>
                <asp:Label ID="lbComments" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMMENTS") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>--%>




