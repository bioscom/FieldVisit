<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ActivityChange.ascx.cs" Inherits="App_Contract_UserControls_ActivityChange" %>
<table class="tMainBorder">
    <tr>
        <td class="cHeadTile">
            <asp:Label ID="lblActivityChanges" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="grdViewActivityChanges" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                OnPageIndexChanging="grdViewActivityChanges_PageIndexChanging" OnRowCommand="grdViewActivityChanges_RowCommand"
                OnRowCancelingEdit="grdViewActivityChanges_RowCancelingEdit"
                OnRowDataBound="grdViewActivityChanges_RowDataBound" OnRowDeleting="grdViewActivityChanges_RowDeleting"
                OnRowEditing="grdViewActivityChanges_RowEditing" OnRowUpdating="grdViewActivityChanges_RowUpdating" DataKeyNames="IDLESSONS"
                Width="100%">
                <Columns>

                    <asp:TemplateField HeaderText="WHAT" HeaderStyle-HorizontalAlign="Center">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtWhat" runat="server" Text='<%# Eval("WHAT") %>' IDLESSONS='<%# DataBinder.Eval(Container.DataItem, "IDLESSONS") %>'
                                TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtWhat" runat="server" Text='<%# Eval("WHAT") %>' TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <%# Eval("WHAT")%>
                        </ItemTemplate>
                        <ItemStyle Width="400px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="WHY" HeaderStyle-HorizontalAlign="Center">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtWhy" runat="server" Text='<%# Eval("WHY") %>' TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtWhy" runat="server" Text='<%# Eval("WHY") %>' TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <%# Eval("WHY")%>
                        </ItemTemplate>
                        <ItemStyle Width="400px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CONSEQUENCES" HeaderStyle-HorizontalAlign="Center">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtConsequences" runat="server" Text='<%# Eval("CONSEQUENCES") %>' TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtConsequences" runat="server" Text='<%# Eval("CONSEQUENCES") %>' TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <%# Eval("CONSEQUENCES")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Center">
                        <EditItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update" OnClientClick="return confirm('Update Activity Change?')" ValidationGroup="activityChangeUpdate"></asp:LinkButton>
                            <asp:ValidationSummary ID="vsUpdate" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="activityChangeUpdate" Enabled="true" HeaderText="Validation Summary..." />
                            <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="True" CommandName="Insert" ValidationGroup="activityChangeInsert" Text="Add"></asp:LinkButton>
                            <asp:ValidationSummary ID="vsInsert" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="activityChangeInsert" Enabled="true" HeaderText="Validation..." />
                        </FooterTemplate>

                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete" ShowHeader="False" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Delete Activity Change?')"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>

                </Columns>
                <EmptyDataTemplate>
                    <table border="0" id="gvEG">
                        <tr>
                            <th scope="col">WHAT</th>
                            <th scope="col">WHY</th>
                            <th scope="col">CONSEQUENCES</th>
                            <th scope="col">...</th>
                            <%--<th scope="col">Delete</th>--%>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtWhat" runat="server" TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvWhat" ValidationGroup="activityChangeUpdate" runat="server"
                                    ControlToValidate="txtWhat" ErrorMessage="Please Enter Activity Changes (What)"
                                    ToolTip="Please Enter Activity Changes (What)" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtWhy" runat="server" TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtConsequences" runat="server" TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="false" CommandName="emptyInsert"
                                    Text="Add" ValidationGroup="activityChangeUpdate"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>

            </asp:GridView>
        </td>
    </tr>
</table>
<asp:HiddenField ID="activityChangePriorityHF" runat="server" />
<asp:HiddenField ID="dtActivityTripStartDateHF" runat="server" />
<asp:HiddenField ID="districtActivityHF" runat="server" />


