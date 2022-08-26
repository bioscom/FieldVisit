<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProjectProgressReport.ascx.cs" Inherits="App_ManHour_UserControl_ProjectProgressReport" %>

<%@ Register Src="dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>


<table>
    <tr>
        <td style="vertical-align: top">
            <table style="width:400px" class="tMainBorder">
                <tr>
                    <td style="background-color: #CCCCCC">
                        <asp:Label ID="Label1" runat="server" Text="Current Status:" Font-Bold="True"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCurrentStatus" ErrorMessage="Current Status is required" ValidationGroup="CurrentStatus">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCurrentStatus" runat="server" Height="135px" TextMode="MultiLine" Width="99%"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
        <td style="vertical-align: top">
            <table style="width:400px" class="tMainBorder">
                <tr>
                    <td style="background-color: #CCCCCC"><strong>LEC</strong></td>
                    <td style="background-color: #CCCCCC"><strong>Challenges</strong></td>
                </tr>
                <tr>
                    <td style="vertical-align: top">
                        <asp:TextBox ID="txtLEC" runat="server" Width="180px"></asp:TextBox>
                        <div style="vertical-align:bottom;margin-top:1.0em">
                            <b>Comments:</b>
                        </div>
                    </td>
                    <td style="vertical-align: top">
                        <asp:TextBox ID="txtChallenges" runat="server" Height="50px" TextMode="MultiLine" Width="290px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="txtComments" runat="server" Height="77px" TextMode="MultiLine" Width="483px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
            <div style="float: right">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100px" OnClick="btnSubmit_Click" ValidationGroup="CurrentStatus" />
            </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top" colspan="2">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="CurrentStatus" />
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top" colspan="2">
            <div style="margin-top: 0.2em">
                <b>Project Milestones</b><hr />
                <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                    OnPageIndexChanging="grdView_PageIndexChanging" OnRowCommand="grdView_RowCommand"
                    OnRowCancelingEdit="grdView_RowCancelingEdit"
                    OnRowDataBound="grdView_RowDataBound" OnRowDeleting="grdView_RowDeleting"
                    OnRowEditing="grdView_RowEditing" OnRowUpdating="grdView_RowUpdating" DataKeyNames="IDMILESTONE"
                    Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Milestones" HeaderStyle-HorizontalAlign="Left">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtMileStone" runat="server"
                                    Text='<%# Eval("MILESTONES") %>'
                                    IDMILESTONE='<%# DataBinder.Eval(Container.DataItem, "IDMILESTONE") %>'
                                    TextMode="MultiLine" Width="200px" Height="50px"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtMileStone" runat="server"
                                    Text='<%# Eval("MILESTONES") %>'
                                    TextMode="MultiLine" Width="200px" Height="50px"></asp:TextBox>
                            </FooterTemplate>
                            <ItemTemplate>
                                <%# Eval("MILESTONES")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtStatus" runat="server" Text='<%# Eval("STATUS") %>'
                                    TextMode="MultiLine" Width="200px" Height="50px"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtStatus" runat="server" Text='<%# Eval("STATUS") %>'
                                    TextMode="MultiLine" Width="200px" Height="50px"></asp:TextBox>
                            </FooterTemplate>
                            <ItemTemplate>
                                <%# Eval("STATUS")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Target Completion Date" HeaderStyle-HorizontalAlign="Left">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTargetDate" runat="server" Text='<%# Eval("TARGET_DATE") %>' Width="200px"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtTargetDate" runat="server" Text='<%# Eval("TARGET_DATE") %>' Width="200px"></asp:TextBox>
                            </FooterTemplate>
                            <ItemTemplate>
                                <%# Eval("TARGET_DATE")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Left">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Eval("REMARKS") %>'
                                    TextMode="MultiLine" Width="200px" Height="50px"></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Eval("REMARKS") %>'
                                    TextMode="MultiLine" Width="200px" Height="50px"></asp:TextBox>
                            </FooterTemplate>
                            <ItemTemplate>
                                <%# Eval("REMARKS")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                            <EditItemTemplate>
                                <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                    Text="Update" OnClientClick="return confirm('Update?')" ValidationGroup="milestoneUpdate"></asp:LinkButton>
                                <asp:ValidationSummary ID="vsUpdate" runat="server" ShowMessageBox="true" ShowSummary="false"
                                    ValidationGroup="milestoneUpdate" Enabled="true" HeaderText="Validation Summary..." />
                                <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="True" CommandName="Insert"
                                    ValidationGroup="milestoneInsert" Text="Add"></asp:LinkButton>
                                <asp:ValidationSummary ID="vsInsert" runat="server" ShowMessageBox="true" ShowSummary="false"
                                    ValidationGroup="milestoneInsert" Enabled="true" HeaderText="Validation..." />
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
                        <table style="width: 99%" border="0" id="gvEG">
                            <tr>
                                <th scope="col">Milestones</th>
                                <th scope="col">Status</th>
                                <th scope="col">Target Completion Date</th>
                                <th scope="col">Remarks</th>
                                <th scope="col">Edit</th>
                                <th scope="col">Delete</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtMileStone" runat="server" TextMode="MultiLine" Width="200px" Height="50px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmployeeCode" ValidationGroup="milestoneUpdate" runat="server"
                                        ControlToValidate="txtMileStone" ErrorMessage="Please Enter Milestone"
                                        ToolTip="Please Enter Milestone" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStatus" runat="server" TextMode="MultiLine" Width="200px" Height="50px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTargetDate" runat="server" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="200px" Height="50px"></asp:TextBox>
                                </td>
                                <td colspan="2">
                                    <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="false" CommandName="emptyInsert"
                                        Text="Add" ValidationGroup="milestoneUpdate"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>

                </asp:GridView>
            </div>

        </td>
    </tr>
    <tr>
        <td style="vertical-align: top" colspan="2">&nbsp;</td>
    </tr>
</table>

<asp:HiddenField ID="InitiativeIDHF" runat="server" />
