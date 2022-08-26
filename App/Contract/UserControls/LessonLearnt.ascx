<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LessonLearnt.ascx.cs" Inherits="App_Contract_UserControls_LessonLearnt" %>
<table class="tMainBorder">
    <tr>
        <td class="cHeadTile">
            <asp:Label ID="lblLessonLearnt" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="grdViewLessonsLearnt" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                OnPageIndexChanging="grdViewLessonsLearnt_PageIndexChanging" OnRowCommand="grdViewLessonsLearnt_RowCommand"
                OnRowCancelingEdit="grdViewLessonsLearnt_RowCancelingEdit"
                OnRowDataBound="grdViewLessonsLearnt_RowDataBound" OnRowDeleting="grdViewLessonsLearnt_RowDeleting"
                OnRowEditing="grdViewLessonsLearnt_RowEditing" OnRowUpdating="grdViewLessonsLearnt_RowUpdating" DataKeyNames="IDLESSONS"
                Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="WHAT DID YOU LEARN?" HeaderStyle-HorizontalAlign="Center">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtWhat" runat="server" Text='<%# Eval("WHAT") %>' IDLESSONS='<%# DataBinder.Eval(Container.DataItem, "IDLESSONS") %>'
                                TextMode="MultiLine" Width="600px" Height="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtWhat" runat="server"
                                Text='<%# Eval("WHAT") %>'
                                TextMode="MultiLine" Width="600px" Height="100px"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <%# Eval("WHAT")%>
                        </ItemTemplate>
                        <ItemStyle Width="600px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="WHAT IMPROVEMENT ACTIONS HAVE YOU TAKEN?" HeaderStyle-HorizontalAlign="Center">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAction" runat="server" Text='<%# Eval("WHY") %>' TextMode="MultiLine" Width="600px" Height="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAction" runat="server" Text='<%# Eval("WHY") %>' TextMode="MultiLine" Width="600px" Height="100px"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <%# Eval("WHY")%>
                        </ItemTemplate>
                        <ItemStyle Width="600px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Center">
                        <EditItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update" OnClientClick="return confirm('Update?')" ValidationGroup="lessonLearntUpdate"></asp:LinkButton>
                            <asp:ValidationSummary ID="vsUpdate" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="lessonLearntUpdate" Enabled="true" HeaderText="Validation Summary..." />
                            <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="True" CommandName="Insert" ValidationGroup="lessonLearntInsert" Text="Add"></asp:LinkButton>
                            <asp:ValidationSummary ID="vsInsert" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="lessonLearntInsert" Enabled="true" HeaderText="Validation..." />
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete" ShowHeader="False" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Delete?')"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>

                </Columns>
                <EmptyDataTemplate>
                    <table border="0" id="gvEG">
                        <tr>
                            <th scope="col">WHAT DID YOU LEARN?</th>
                            <th scope="col">WHAT IMPROVEMENT ACTIONS HAVE YOU TAKEN?</th>
                            <th scope="col">...</th>
                            <%--<th scope="col">Delete</th>--%>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtWhat" runat="server" TextMode="MultiLine" Width="600px" Height="100px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmployeeCode" ValidationGroup="lessonLearntUpdate" runat="server"
                                    ControlToValidate="txtWhat" ErrorMessage="Please Enter What you learnt"
                                    ToolTip="Please Enter What you learnt" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAction" runat="server" TextMode="MultiLine" Width="600px" Height="100px"></asp:TextBox>
                            </td>

                            <td>
                                <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="false" CommandName="emptyInsert" Text="Add" ValidationGroup="lessonLearntUpdate"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
        </td>
    </tr>
</table>
<asp:HiddenField ID="lessonLearntPriorityHF" runat="server" />
<asp:HiddenField ID="dtLessonTripStartDateHF" runat="server" />
<asp:HiddenField ID="districtLessonHF" runat="server" />
