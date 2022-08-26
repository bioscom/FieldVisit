<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oMilestones.ascx.cs" Inherits="App_BI500_UserControl_Cost_oMilestones" %>
<%@ Reference VirtualPath="~/UserControls/dateControl.ascx" %>
<%@ Register Src="~/UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc3" %>

<table class="tMainBorder" style="width: 99%">
    <tr>
        <td class="cHeadTile" colspan="2">Improvement Idea</td>
    </tr>
    <tr>
        <td style="width: 180px">
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Request Number:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblRequestNumber" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label30" runat="server" Font-Bold="True" Text="Title:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Date Submitted:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblDateInit" runat="server"></asp:Label>
        </td>
    </tr>
</table>

<table class="tMainBorder" style="width: 99%">
    <tr>
        <td class="cHeadTile">Bi-weekly Cadence Commitments</td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                OnPageIndexChanging="grdView_PageIndexChanging" OnRowCommand="grdView_RowCommand"
                OnRowCancelingEdit="grdView_RowCancelingEdit"
                OnRowDataBound="grdView_RowDataBound" OnRowDeleting="grdView_RowDeleting"
                OnRowEditing="grdView_RowEditing" OnRowUpdating="grdView_RowUpdating" DataKeyNames="MILESTONEID"
                Width="100%">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Activity Description" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <asp:TextBox ID="activityDescTextBox" runat="server"
                                Text='<%# Eval("ACTIVITY_DESCRIPTION") %>'
                                TextMode="MultiLine" Width="500px" Height="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="activityDescTextBox" runat="server" TextMode="MultiLine" Width="500px" Height="100px"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblActivityDescription" runat="server" Text='<%# Eval("ACTIVITY_DESCRIPTION") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="500px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Start Date" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <uc3:dateControl ID="SDdateControl" runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <uc3:dateControl ID="SDdateControl" runat="server" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="labelStartDate" runat="server" Text='<%# Bind("START_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="130px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Finish Date" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <uc3:dateControl ID="FDdateControl" runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <uc3:dateControl ID="FDdateControl" runat="server" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="labelEndDate" runat="server" Text='<%# Bind("FINISH_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="130px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Amount Saved" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAmountSaved" runat="server" Width="100px" Text='<%# Eval("AMOUNTSAVED") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAmountSaved" runat="server" Width="100px"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <%# Eval("AMOUNTSAVED")%>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
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
                            <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="True" CommandName="Insert"
                                ValidationGroup="Insert" Text="Add"></asp:LinkButton>
                            <asp:ValidationSummary ID="vsInsert" runat="server" ShowMessageBox="true" ShowSummary="false"
                                ValidationGroup="Insert" Enabled="true" HeaderText="Validation..." />
                        </FooterTemplate>

                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="Edit"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete" ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                Text="Delete" OnClientClick="return confirm('Delete?')"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>

                </Columns>
                <EmptyDataTemplate>
                    <table style="width: 100%" border="1" id="gvEG">
                        <tr>
                            <th scope="col">Activity Description</th>
                            <th scope="col">Start Date</th>
                            <th scope="col">Finish Date</th>
                            <th scope="col">Amount Saved</th>
                            <th scope="col">Edit</th>
                            <th scope="col">Delete</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="activityDescTextBox" runat="server" Text='<%# Eval("ACTIVITY_DESCRIPTION") %>' TextMode="MultiLine" 
                                    MILESTONEID='<%# DataBinder.Eval(Container.DataItem, "MILESTONEID") %>' Width="500px" Height="100px">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmployeeCode" ValidationGroup="Update" runat="server"
                                    ControlToValidate="activityDescTextBox" ErrorMessage="Please Enter Activity Description"
                                    ToolTip="Please Enter Activity Description" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <uc3:dateControl ID="SDdateControl" runat="server" />
                            </td>
                            <td>
                                <uc3:dateControl ID="FDdateControl" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtAmountSaved" runat="server" Width="100px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="AmtSaved" ValidationGroup="Update" runat="server"
                                    ControlToValidate="activityDescTextBox" ErrorMessage="Please Enter Amount Saved"
                                    ToolTip="Please Enter Amount Saved" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2">
                                <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="false" CommandName="emptyInsert"
                                    Text="Add" ValidationGroup="Update"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>

            </asp:GridView>

        </td>
    </tr>
</table>


<asp:HiddenField ID="RequestIdHF" runat="server" />
