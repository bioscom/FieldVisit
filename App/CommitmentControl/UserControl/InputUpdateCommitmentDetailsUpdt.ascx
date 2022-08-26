<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InputUpdateCommitmentDetailsUpdt.ascx.cs" Inherits="App_BONGACCP_UserControl_InputUpdateCommitmentDetailsUpdt" %>


<asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowFooter="true"
    OnPageIndexChanging="grdView_PageIndexChanging" OnRowCommand="grdView_RowCommand"
    OnRowCancelingEdit="grdView_RowCancelingEdit"
    OnRowDataBound="grdView_RowDataBound" OnRowDeleting="grdView_RowDeleting"
    OnRowEditing="grdView_RowEditing" OnRowUpdating="grdView_RowUpdating" DataKeyNames="DETAILSID"
    Width="100%">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Activity" HeaderStyle-HorizontalAlign="Left">
            <EditItemTemplate>
                <asp:TextBox ID="txtActivity" runat="server" Text='<%# Eval("DESCRIPTION") %>' TextMode="MultiLine" Width="400px" Height="70px"></asp:TextBox>
            </EditItemTemplate>

            <FooterTemplate>
                <asp:TextBox ID="txtActivity" runat="server" TextMode="MultiLine" Width="400px" Height="70px"></asp:TextBox>
            </FooterTemplate>

            <ItemTemplate>
                <asp:Label ID="lblActivity" runat="server" Text='<%# Eval("DESCRIPTION") %>'></asp:Label>
            </ItemTemplate>

            <ItemStyle Width="400px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Qty" HeaderStyle-HorizontalAlign="Left">
            <EditItemTemplate>
                <asp:TextBox ID="txtQty" Width="50px" runat="server" Text='<%# Eval("QUANTITY") %>'></asp:TextBox>
            </EditItemTemplate>

            <FooterTemplate>
                <asp:TextBox ID="txtQty" Width="50px" runat="server"></asp:TextBox>
            </FooterTemplate>

            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblQty" runat="server" Text='<%# Eval("QUANTITY") %>'></asp:Label>
                </div>
            </ItemTemplate>
            <ItemStyle Width="150px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Rate" HeaderStyle-HorizontalAlign="Left">
            <EditItemTemplate>
                <asp:TextBox ID="txtRate" Width="50px" runat="server" Text='<%# Eval("RATE") %>'></asp:TextBox>
            </EditItemTemplate>

            <FooterTemplate>
                <asp:TextBox ID="txtRate" Width="50px" runat="server"></asp:TextBox>
            </FooterTemplate>

            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblRate" runat="server" Text='<%# Eval("RATE") %>'></asp:Label>
                </div>
            </ItemTemplate>
            <ItemStyle Width="70px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Amount" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblAmount" runat="server" Text=''></asp:Label>
                </div>
            </ItemTemplate>
            <ItemStyle Width="150px" />
        </asp:TemplateField>


        <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
            <EditItemTemplate>
                <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                    Text="Update" OnClientClick="return confirm('Update?')" ValidationGroup="Update"></asp:LinkButton>
                <asp:ValidationSummary ID="vsUpdate" runat="server" ShowMessageBox="true" ShowSummary="false"
                    ValidationGroup="Update" Enabled="true" HeaderText="Validation Summary..." />
                <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="Cancel"></asp:LinkButton>
            </EditItemTemplate>

            <FooterTemplate>
                <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="True" CommandName="Insert" ValidationGroup="Insert" Text="Add"></asp:LinkButton>
                <asp:ValidationSummary ID="vsInsert" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Insert" Enabled="true" HeaderText="Validation..." />
            </FooterTemplate>

            <ItemTemplate>
                <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Delete" ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Delete?')"></asp:LinkButton>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left" />
        </asp:TemplateField>

    </Columns>
    <EmptyDataTemplate>
        <table style="width: 100%" id="gvEG">
            <tr class="cHeadTile">
                <th scope="col">Activity</th>
                <th scope="col">Qty</th>
                <th scope="col">Rate</th>
                <th scope="col">Amount</th>
                <th scope="col">...</th>
                <th scope="col">...</th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtActivity" runat="server" Text='<%# Eval("DESCRIPTION") %>' TextMode="MultiLine"
                        DETAILSID='<%# DataBinder.Eval(Container.DataItem, "DETAILSID") %>' Width="450px" Height="70px">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator ID="rfvEmployeeCode" ValidationGroup="Update" runat="server"
                        ControlToValidate="txtActivity" ErrorMessage="Please Enter Activity Description"
                        ToolTip="Please Enter Activity Description" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>

                <td>
                    <asp:TextBox ID="txtQty" runat="server" Width="50px" Text='<%# Eval("QUANTITY") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Update" runat="server"
                        ControlToValidate="txtQty" ErrorMessage="Please Enter Quantity"
                        ToolTip="Please Enter Quantity" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>

                <td>
                    <asp:TextBox ID="txtRate" runat="server" Width="50px" Text='<%# Eval("RATE") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Update" runat="server"
                        ControlToValidate="txtRate" ErrorMessage="Please Enter Amount"
                        ToolTip="Please Enter Amount" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>

                <td>
                    
                </td>

                <td colspan="2">
                    <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="false" CommandName="emptyInsert"
                        Text="Add" ValidationGroup="Update"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </EmptyDataTemplate>

</asp:GridView>
<asp:HiddenField ID="CommitmentHF" runat="server" />