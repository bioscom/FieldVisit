<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ThreePartOpprEstSavings.ascx.cs" Inherits="App_PDCC_UserControl_ThreePartOpprSavings" %>

<asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False"
    ShowFooter="true" Width="100%"
    OnPageIndexChanging="grdView_PageIndexChanging"
    OnRowCancelingEdit="grdView_RowCancelingEdit"
    OnRowUpdating="grdView_RowUpdating"
    OnRowEditing="grdView_RowEditing">

    <%--<FooterStyle BackColor="Tan" />
    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
    <HeaderStyle BackColor="Tan" Font-Bold="True" />
    <AlternatingRowStyle BackColor="PaleGoldenrod" />--%>

    <Columns>
        <asp:TemplateField>
            <HeaderTemplate>
                <th colspan="38">Estimated Savings</th>
                <tr class="gvHeader">
                    <th style="width: 0px"></th>
                    <th></th>
                    <th></th>

                    <th colspan="3">Jan</th>
                    <th colspan="3">Feb</th>
                    <th colspan="3">Mar</th>
                    <th colspan="3">Apr</th>
                    <th colspan="3">May</th>
                    <th colspan="3">Jun</th>
                    <th colspan="3">Jul</th>
                    <th colspan="3">Aug</th>
                    <th colspan="3">Sep</th>
                    <th colspan="3">Oct</th>
                    <th colspan="3">Nov</th>
                    <th colspan="3">Dec</th>
                </tr>

                <tr class="gvHeader">
                    <th style="width: 0px"></th>
                    <th></th>
                    <th></th>

                    <th style="color: blue">DD</th>
                    <th style="color: purple">DDO</th>
                    <th style="color: black">EIO</th>

                    <th style="color: blue">DD</th>
                    <th style="color: purple">DDO</th>
                    <th style="color: black">EIO</th>

                    <th style="color: blue">DD</th>
                    <th style="color: purple">DDO</th>
                    <th style="color: black">EIO</th>

                    <th style="color: blue">DD</th>
                    <th style="color: purple">DDO</th>
                    <th style="color: black">EIO</th>

                    <th style="color: blue">DD</th>
                    <th style="color: purple">DDO</th>
                    <th style="color: black">EIO</th>

                    <th style="color: blue">DD</th>
                    <th style="color: purple">DDO</th>
                    <th style="color: black">EIO</th>

                    <th style="color: blue">DD</th>
                    <th style="color: purple">DDO</th>
                    <th style="color: black">EIO</th>

                    <th style="color: blue">DD</th>
                    <th style="color: purple">DDO</th>
                    <th style="color: black">EIO</th>

                    <th style="color: blue">DD</th>
                    <th style="color: purple">DDO</th>
                    <th style="color: black">EIO</th>

                    <th style="color: blue">DD</th>
                    <th style="color: purple">DDO</th>
                    <th style="color: black">EIO</th>

                    <th style="color: blue">DD</th>
                    <th style="color: purple">DDO</th>
                    <th style="color: black">EIO</th>

                    <th style="color: blue">DD</th>
                    <th style="color: purple">DDO</th>
                    <th style="color: black">EIO</th>

                </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <td>
                    <asp:Label ID="lbAsset" runat="server" Font-Bold="true" Font-Size="9pt" ASSETID='<%# DataBinder.Eval(Container.DataItem, "ASSETID") %>' Text='<%# DataBinder.Eval(Container.DataItem, "ASSET") %>'></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                </td>

                <td>
                    <asp:Label ID="lbJanDD" runat="server" ForeColor="Blue"></asp:Label></td>
                <td>
                    <asp:Label ID="lbJanDDO" runat="server" ForeColor="Purple"></asp:Label></td>
                <td>
                    <asp:Label ID="lbJanEIO" runat="server" ForeColor="Black"></asp:Label></td>

                <td>
                    <asp:Label ID="lbFebDD" runat="server" ForeColor="Blue"></asp:Label></td>
                <td>
                    <asp:Label ID="lbFebDDO" runat="server" ForeColor="Purple"></asp:Label></td>
                <td>
                    <asp:Label ID="lbFebEIO" runat="server" ForeColor="Black"></asp:Label></td>

                <td>
                    <asp:Label ID="lbMarDD" runat="server" ForeColor="Blue"></asp:Label></td>
                <td>
                    <asp:Label ID="lbMarDDO" runat="server" ForeColor="Purple"></asp:Label></td>
                <td>
                    <asp:Label ID="lbMarEIO" runat="server" ForeColor="Black"></asp:Label></td>

                <td>
                    <asp:Label ID="lbAprDD" runat="server" ForeColor="Blue"></asp:Label></td>
                <td>
                    <asp:Label ID="lbAprDDO" runat="server" ForeColor="Purple"></asp:Label></td>
                <td>
                    <asp:Label ID="lbAprEIO" runat="server" ForeColor="Black"></asp:Label></td>

                <td>
                    <asp:Label ID="lbMayDD" runat="server" ForeColor="Blue"></asp:Label></td>
                <td>
                    <asp:Label ID="lbMayDDO" runat="server" ForeColor="Purple"></asp:Label></td>
                <td>
                    <asp:Label ID="lbMayEIO" runat="server" ForeColor="Black"></asp:Label></td>

                <td>
                    <asp:Label ID="lbJunDD" runat="server" ForeColor="Blue"></asp:Label></td>
                <td>
                    <asp:Label ID="lbJunDDO" runat="server" ForeColor="Purple"></asp:Label></td>
                <td>
                    <asp:Label ID="lbJunEIO" runat="server" ForeColor="Black"></asp:Label></td>

                <td>
                    <asp:Label ID="lbJulDD" runat="server" ForeColor="Blue"></asp:Label></td>
                <td>
                    <asp:Label ID="lbJulDDO" runat="server" ForeColor="Purple"></asp:Label></td>
                <td>
                    <asp:Label ID="lbJulEIO" runat="server" ForeColor="Black"></asp:Label></td>

                <td>
                    <asp:Label ID="lbAugDD" runat="server" ForeColor="Blue"></asp:Label></td>
                <td>
                    <asp:Label ID="lbAugDDO" runat="server" ForeColor="Purple"></asp:Label></td>
                <td>
                    <asp:Label ID="lbAugEIO" runat="server" ForeColor="Black"></asp:Label></td>

                <td>
                    <asp:Label ID="lbSepDD" runat="server" ForeColor="Blue"></asp:Label></td>
                <td>
                    <asp:Label ID="lbSepDDO" runat="server" ForeColor="Purple"></asp:Label></td>
                <td>
                    <asp:Label ID="lbSepEIO" runat="server" ForeColor="Black"></asp:Label></td>

                <td>
                    <asp:Label ID="lbOctDD" runat="server" ForeColor="Blue"></asp:Label></td>
                <td>
                    <asp:Label ID="lbOctDDO" runat="server" ForeColor="Purple"></asp:Label></td>
                <td>
                    <asp:Label ID="lbOctEIO" runat="server" ForeColor="Black"></asp:Label></td>

                <td>
                    <asp:Label ID="lbNovDD" runat="server" ForeColor="Blue"></asp:Label></td>
                <td>
                    <asp:Label ID="lbNovDDO" runat="server" ForeColor="Purple"></asp:Label></td>
                <td>
                    <asp:Label ID="lbNovEIO" runat="server" ForeColor="Black"></asp:Label></td>

                <td>
                    <asp:Label ID="lbDecDD" runat="server" ForeColor="Blue"></asp:Label></td>
                <td>
                    <asp:Label ID="lbDecDDO" runat="server" ForeColor="Purple"></asp:Label></td>
                <td>
                    <asp:Label ID="lbDecEIO" runat="server" ForeColor="Black"></asp:Label></td>

            </ItemTemplate>

            <EditItemTemplate>
                <td>
                    <asp:Label ID="lbAsset" runat="server" Font-Bold="true" Font-Size="9pt" ASSETID='<%# DataBinder.Eval(Container.DataItem, "ASSETID") %>' Text='<%# DataBinder.Eval(Container.DataItem, "ASSET") %>'></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update" OnClientClick="return confirm('Update?')" ValidationGroup="Update"></asp:LinkButton>
                    <asp:ValidationSummary ID="vsUpdate" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Update" Enabled="true" HeaderText="Validation Summary..." />
                    <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </td>

                <td>
                    <asp:TextBox ID="txtJanDD" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtJanDDO" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtJanEIO" Width="50px" runat="server"></asp:TextBox></td>

                <td>
                    <asp:TextBox ID="txtFebDD" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtFebDDO" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtFebEIO" Width="50px" runat="server"></asp:TextBox></td>

                <td>
                    <asp:TextBox ID="txtMarDD" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtMarDDO" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtMarEIO" Width="50px" runat="server"></asp:TextBox></td>

                <td>
                    <asp:TextBox ID="txtAprDD" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtAprDDO" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtAprEIO" Width="50px" runat="server"></asp:TextBox></td>

                <td>
                    <asp:TextBox ID="txtMayDD" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtMayDDO" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtMayEIO" Width="50px" runat="server"></asp:TextBox></td>

                <td>
                    <asp:TextBox ID="txtJunDD" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtJunDDO" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtJunEIO" Width="50px" runat="server"></asp:TextBox></td>

                <td>
                    <asp:TextBox ID="txtJulDD" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtJulDDO" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtJulEIO" Width="50px" runat="server"></asp:TextBox></td>

                <td>
                    <asp:TextBox ID="txtAugDD" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtAugDDO" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtAugEIO" Width="50px" runat="server"></asp:TextBox></td>

                <td>
                    <asp:TextBox ID="txtSepDD" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtSepDDO" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtSepEIO" Width="50px" runat="server"></asp:TextBox></td>

                <td>
                    <asp:TextBox ID="txtOctDD" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtOctDDO" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtOctEIO" Width="50px" runat="server"></asp:TextBox></td>

                <td>
                    <asp:TextBox ID="txtNovDD" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtNovDDO" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtNovEIO" Width="50px" runat="server"></asp:TextBox></td>

                <td>
                    <asp:TextBox ID="txtDecDD" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtDecDDO" Width="50px" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtDecEIO" Width="50px" runat="server"></asp:TextBox></td>

            </EditItemTemplate>

            <FooterTemplate>
                <td><asp:Label ID="Label1" runat="server" Text="PD Est. Savings" Font-Bold="true"></asp:Label></td>
                <td></td>
                <td colspan="3">
                    <asp:Label ID="lbJan" runat="server" Font-Bold="true"></asp:Label></td>
                <td colspan="3">
                    <asp:Label ID="lbFeb" runat="server" Font-Bold="true"></asp:Label></td>
                <td colspan="3">
                    <asp:Label ID="lbMar" runat="server" Font-Bold="true"></asp:Label></td>
                <td colspan="3">
                    <asp:Label ID="lbApr" runat="server" Font-Bold="true"></asp:Label></td>
                <td colspan="3">
                    <asp:Label ID="lbMay" runat="server" Font-Bold="true"></asp:Label></td>
                <td colspan="3">
                    <asp:Label ID="lbJun" runat="server" Font-Bold="true"></asp:Label></td>
                <td colspan="3">
                    <asp:Label ID="lbJul" runat="server" Font-Bold="true"></asp:Label></td>
                <td colspan="3">
                    <asp:Label ID="lbAug" runat="server" Font-Bold="true"></asp:Label></td>
                <td colspan="3">
                    <asp:Label ID="lbSep" runat="server" Font-Bold="true"></asp:Label></td>
                <td colspan="3">
                    <asp:Label ID="lbOct" runat="server" Font-Bold="true"></asp:Label></td>
                <td colspan="3">
                    <asp:Label ID="lbNov" runat="server" Font-Bold="true"></asp:Label></td>
                <td colspan="3">
                    <asp:Label ID="lbDec" runat="server" Font-Bold="true"></asp:Label></td>
            </FooterTemplate>

        </asp:TemplateField>
    </Columns>
</asp:GridView>

