<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BusinessImprovement.ascx.cs" Inherits="App_Contract_UserControls_BusinessImprovement" %>
<table class="tMainBorder">
    <tr>
        <td class="cHeadTile">
            <asp:Label ID="lblBusinessImprovement" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="grdViewBusinessImprovement" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                OnPageIndexChanging="grdViewBusinessImprovement_PageIndexChanging" OnRowCommand="grdViewBusinessImprovement_RowCommand"
                OnRowCancelingEdit="grdViewBusinessImprovement_RowCancelingEdit"
                OnRowDataBound="grdViewBusinessImprovement_RowDataBound" OnRowDeleting="grdViewBusinessImprovement_RowDeleting"
                OnRowEditing="grdViewBusinessImprovement_RowEditing" OnRowUpdating="grdViewBusinessImprovement_RowUpdating" DataKeyNames="IDLESSONS"
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

                    <asp:TemplateField HeaderText="MAGNITUDE VALUE/COST" HeaderStyle-HorizontalAlign="Center">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtValueCost" runat="server" Text='<%# Eval("WHY") %>' TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtValueCost" runat="server" Text='<%# Eval("WHY") %>' TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <%# Eval("WHY")%>
                        </ItemTemplate>
                        <ItemStyle Width="400px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="EASE OF IMPLEMENTATION OR DIFFICULTY OF RECTIFICATION (HML)" HeaderStyle-HorizontalAlign="Center">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEase" runat="server" Text='<%# Eval("CONSEQUENCES") %>' TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtEase" runat="server" Text='<%# Eval("CONSEQUENCES") %>' TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <%# Eval("CONSEQUENCES")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Center">
                        <EditItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update" OnClientClick="return confirm('Update Proven Business Improvement?')" ValidationGroup="businessImprovementUpdate"></asp:LinkButton>
                            <asp:ValidationSummary ID="vsUpdate" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="businessImprovementUpdate" Enabled="true" HeaderText="Validation Summary..." />
                            <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="True" CommandName="Insert" ValidationGroup="businessImprovementInsert" Text="Add"></asp:LinkButton>
                            <asp:ValidationSummary ID="vsInsert" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="businessImprovementInsert" Enabled="true" HeaderText="Validation..." />
                        </FooterTemplate>

                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete" ShowHeader="False" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Delete Proven Business Improvement?')"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>



                </Columns>
                <EmptyDataTemplate>
                    <table border="0" id="gvEG0">
                        <tr>
                            <th scope="col">WHAT</th>
                            <th scope="col">MAGNITUDE VALUE/COST</th>
                            <th scope="col">EASE OF IMPLEMENTATION OR DIFFICULTY OF RECTIFICATION (HML)</th>
                            <th scope="col">...</th>
                            <%--<th scope="col">Delete</th>--%>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtWhat" runat="server" TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="businessImprovementUpdate" runat="server"
                                    ControlToValidate="txtWhat" ErrorMessage="Please Enter Proven Business Improvement (What)"
                                    ToolTip="Please Enter Proven Business Improvement (What)" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValueCost" runat="server" TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEase" runat="server" TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="false" CommandName="emptyInsert"
                                    Text="Add" ValidationGroup="businessImprovementUpdate"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>

            </asp:GridView>
        </td>
    </tr>
</table>
<asp:HiddenField ID="businessImprovementPriorityHF" runat="server" />
<asp:HiddenField ID="dtBusinessTripStartDateHF" runat="server" />
<asp:HiddenField ID="districtBusinessHF" runat="server" />

