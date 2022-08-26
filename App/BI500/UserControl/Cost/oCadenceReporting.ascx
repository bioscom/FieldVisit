<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oCadenceReporting.ascx.cs" Inherits="App_BI500_UserControl_Cost_oCadenceReporting" %>

<%@ Reference VirtualPath="~/UserControls/dateControl.ascx" %>
<%@ Reference VirtualPath="~/App/BI500/UserControl/Cost/oStatusControl.ascx" %>

<%@ Register Src="~/UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc3" %>
<%@ Register Src="~/App/BI500/UserControl/Cost/oStatusControl.ascx" TagPrefix="uc3" TagName="oStatusControl" %>


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
        <td class="cHeadTile">
            <div>
                <div style="float: left">
                    Bi-weekly Cadence Commitments
                </div>
                <div style="float: right">
                    <asp:ImageButton ID="exportExcel" runat="server" ImageUrl="~/Images/excel.png" ToolTip="Download Bi-weekly Cadence Commitments" Height="30px" Width="30px" OnClick="exportExcel_Click" />
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                OnPageIndexChanging="grdView_PageIndexChanging" OnRowCommand="grdView_RowCommand"
                OnRowCancelingEdit="grdView_RowCancelingEdit"
                OnRowDataBound="grdView_RowDataBound" OnRowDeleting="grdView_RowDeleting"
                OnRowEditing="grdView_RowEditing" OnRowUpdating="grdView_RowUpdating" DataKeyNames="CADENCEID"
                Width="100%">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAction" runat="server"
                                Text='<%# Eval("ACTION") %>'
                                TextMode="MultiLine" Width="300px" Height="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAction" runat="server" TextMode="MultiLine" Width="300px" Height="100px"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAction" runat="server" Text='<%# Eval("ACTION") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="300px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Action Party" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtActionParty" runat="server"
                                Text='<%# Eval("ACTIONPARTY") %>'
                                TextMode="MultiLine" Width="200px" Height="50px"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtActionParty" runat="server" TextMode="MultiLine" Width="200px" Height="50px"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblActionParty" runat="server" Text='<%# Eval("ACTIONPARTY") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="200px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Threat" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtThreat" runat="server"
                                Text='<%# Eval("THREAT") %>'
                                TextMode="MultiLine" Width="300px" Height="100px">
                            </asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtThreat" runat="server" TextMode="MultiLine" Width="300px" Height="100px"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblThreat" runat="server" Text='<%# Eval("THREAT") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="300px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date Due" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <uc3:dateControl ID="FDdateControl" runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <uc3:dateControl ID="FDdateControl" runat="server" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="labelEndDate" runat="server" Text='<%# Bind("DUEDATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="130px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <uc3:oStatusControl runat="server" ID="oStatusControl" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <uc3:oStatusControl runat="server" ID="oStatusControl" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="labelStatus" runat="server" Text='<%# Bind("STATUS") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="130px" />
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
                            <th scope="col">Action</th>
                            <th scope="col">Action Party</th>
                            <th scope="col">Threat</th>
                            <th scope="col">Due Date</th>
                            <th scope="col">Status</th>
                            <th scope="col">Edit</th>
                            <th scope="col">Delete</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtAction" runat="server" Text='<%# Eval("ACTION") %>' TextMode="MultiLine"
                                    CADENCEID='<%# DataBinder.Eval(Container.DataItem, "CADENCEID") %>' Width="300px" Height="100px">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmployeeCode" ValidationGroup="Update" runat="server"
                                    ControlToValidate="txtAction" ErrorMessage="Please Enter Action"
                                    ToolTip="Please Enter Action" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtActionParty" runat="server" Text='<%# Eval("ACTIONPARTY") %>' TextMode="MultiLine" Width="200px" Height="50px">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Update" runat="server"
                                    ControlToValidate="txtActionParty" ErrorMessage="Please Enter Action Party"
                                    ToolTip="Please Enter Action Party" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>

                            <td>
                                <asp:TextBox ID="txtThreat" runat="server" Text='<%# Eval("THREAT") %>' TextMode="MultiLine" Width="300px" Height="100px">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Update" runat="server"
                                    ControlToValidate="txtThreat" ErrorMessage="Please Enter Threat"
                                    ToolTip="Please Enter Threat" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>

                            <td>
                                <uc3:dateControl ID="FDdateControl" runat="server" />
                            </td>

                            <td>
                                <uc3:oStatusControl runat="server" ID="oStatusControl" />
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
