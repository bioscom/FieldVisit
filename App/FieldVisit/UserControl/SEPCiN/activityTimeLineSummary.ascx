<%@ Control Language="C#" AutoEventWireup="true" CodeFile="activityTimeLineSummary.ascx.cs" Inherits="UserControl_activityTimeLineSummary" %>
<%--<%@ Reference VirtualPath="~/App/FieldVisit/UserControl/SEPCiN/activityHeader.ascx" %>--%>
<%@ Reference VirtualPath="~/UserControls/dateControl.ascx" %>
<%@ Register Src="~/UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc3" %>

Activity Timeline (Summarised plan only) [Not more than 10 lines and 21 days duration per activity]<br /><br />

            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                OnPageIndexChanging="grdView_PageIndexChanging" OnRowCommand="grdView_RowCommand"
                OnRowCancelingEdit="grdView_RowCancelingEdit"
                OnRowDataBound="grdView_RowDataBound" OnRowDeleting="grdView_RowDeleting"
                OnRowEditing="grdView_RowEditing" OnRowUpdating="grdView_RowUpdating" DataKeyNames="ID_TIMELINE"
                Width="100%">
                <Columns>
                    <%--<asp:TemplateField>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Activity Description" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <asp:TextBox ID="activityDescTextBox" runat="server"
                                Text='<%# Eval("ACTIVITY_DESCRIPTION") %>'
                                TextMode="MultiLine" Width="500px" Height="50px"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="activityDescTextBox" runat="server"
                                TextMode="MultiLine" Width="500px" Height="50px"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <%# Eval("ACTIVITY_DESCRIPTION")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Start Date (SD)" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <uc3:dateControl ID="SDdateControl" runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <uc3:dateControl ID="SDdateControl" runat="server" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <%# Eval("START_DATE")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Finish Date(FD = SD + 21Days)" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <uc3:dateControl ID="FDdateControl" runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <uc3:dateControl ID="FDdateControl" runat="server" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <%# Eval("FINISH_DATE")%>
                        </ItemTemplate>
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
                            <th scope="col">Start Date(SD)</th>
                            <th scope="col">Finish Date(FD = SD + 21Days)</th>
                            <th scope="col">Edit</th>
                            <th scope="col">Delete</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="activityDescTextBox" runat="server"
                                    Text='<%# Eval("ACTIVITY_DESCRIPTION") %>'
                                    ID_TIMELINE='<%# DataBinder.Eval(Container.DataItem, "ID_TIMELINE") %>'
                                    TextMode="MultiLine" Width="450px" Height="50px"></asp:TextBox>
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
                            <td colspan="2">
                                <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="false" CommandName="emptyInsert"
                                    Text="Add" ValidationGroup="Update"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>

            </asp:GridView>

                <asp:HiddenField ID="ActivityIDHF" runat="server" />
        

<%--            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" 
                ShowFooter="True" OnRowCancelingEdit="grdView_RowCancelingEdit"
                OnRowCommand="grdView_RowCommand" OnRowDataBound="grdView_RowDataBound" OnRowDeleting="grdView_RowDeleting"
                OnRowEditing="grdView_RowEditing" OnRowUpdating="grdView_RowUpdating" DataKeyNames="ID,DepartmentId">
                <Columns>
                    <asp:TemplateField HeaderText="Employee Code" HeaderStyle-HorizontalAlign="Left"
                        ControlStyle-Width="50px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmployeeCode" runat="server" Text='<%# Bind("EmployeeCode") %>' MaxLength="6" Width="50px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmployeeCode" ValidationGroup="Update" runat="server"
                                ControlToValidate="txtEmployeeCode" ErrorMessage="Please Enter Employee Code"
                                ToolTip="Please Enter Employee Code" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="reEmployeeCode" runat="server" ControlToValidate="txtEmployeeCode"
                                ErrorMessage="Please Enter Only Numbers in Employee Code" ToolTip="Please Enter Only Numbers"
                                SetFocusOnError="true" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="Update">*</asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtEmployeeCode" runat="server" MaxLength="6" Width="50px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmployeeCode" ValidationGroup="Insert" runat="server"
                                ControlToValidate="txtEmployeeCode" ErrorMessage="Please Enter Employee Code"
                                ToolTip="Please Enter Employee Code" SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="reEmployeeCode" runat="server" ControlToValidate="txtEmployeeCode"
                                ErrorMessage="Please Enter Only Numbers in Employee Code" ToolTip="Please Enter Only Numbers"
                                SetFocusOnError="true" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="Insert">*</asp:RegularExpressionValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <%# Eval("EmployeeCode")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Left" ControlStyle-Width="90px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmployeeName" runat="server" Text='<%# Bind("EmployeeName") %>'
                                Width="90px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmployeeName" ValidationGroup="Update" runat="server"
                                ControlToValidate="txtEmployeeName" ErrorMessage="Please Enter Name" ToolTip="Please Enter Name"
                                SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtEmployeeName" runat="server" Width="90px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmployeeName" ValidationGroup="Insert" runat="server"
                                ControlToValidate="txtEmployeeName" ErrorMessage="Please Enter Name" ToolTip="Please Enter Name"
                                SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <%# Eval("EmployeeName") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Department" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlDepartment" runat="server" DataTextField="Name" DataValueField="Id">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%# Eval("DepartmentName")%>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="ddlDepartment" runat="server" DataTextField="Name" DataValueField="Id">
                            </asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Group" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlEmployeeGroup" runat="server" SelectedValue='<%# Eval("EmployeeGroup") %>'>
                                <asp:ListItem Text="User" Value="User"></asp:ListItem>
                                <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                                <asp:ListItem Text="Super User" Value="Super User"></asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%# Eval("EmployeeGroup")%>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="ddlEmployeeGroup" runat="server">
                                <asp:ListItem Text="User" Value="User" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                                <asp:ListItem Text="Super User" Value="Super User"></asp:ListItem>
                            </asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email" HeaderStyle-HorizontalAlign="Left" ControlStyle-Width="100px">
                        <ItemTemplate>
                            <%# Eval("Email")%>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" Width="100px" />
                            <asp:RequiredFieldValidator ID="rfvEmail" ValidationGroup="Insert" runat="server"
                                ControlToValidate="txtEmail" ErrorMessage="Please Enter Email" ToolTip="Please Enter Email"
                                SetFocusOnError="true" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="reEmail" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="Please Enter a Valid Email" ToolTip="Please Enter a Valid Email"
                                SetFocusOnError="true" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="Insert">*</asp:RegularExpressionValidator>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Active">
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkActive" runat="server" Checked='<%# Eval("isActive") %>' />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblActive" runat="server" Text='<%# Eval("isActive") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:CheckBox ID="chkActive" runat="server" />
                        </FooterTemplate>
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
                                ValidationGroup="Insert" Text="Insert"></asp:LinkButton>
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
                    <table class="grid" cellspacing="0" rules="all" border="1" id="gvEG" style="border-collapse: collapse;">
                        <tr>
                            <th align="left" scope="col">Employee Code
                            </th>
                            <th align="left" scope="col">Name
                            </th>
                            <th align="left" scope="col">Department
                            </th>
                            <th align="left" scope="col">Group
                            </th>
                            <th align="left" scope="col">Email
                            </th>
                            <th scope="col">Ative
                            </th>
                            <th align="left" scope="col">Edit
                            </th>
                            <th scope="col">Delete
                            </th>
                        </tr>
                        <tr class="gridRow">
                            <td colspan="8">No Records found...
                            </td>
                        </tr>
                        <tr class="gridFooterRow">
                            <td>
                                <asp:TextBox ID="txtEmployeeCode" runat="server" MaxLength="6"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDepartment" runat="server" DataTextField="Name" DataValueField="Id">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEmployeeGroup" runat="server">
                                    <asp:ListItem Text="User" Value="User" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                                    <asp:ListItem Text="Super User" Value="Super User"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" />
                            </td>
                            <td>
                                <asp:CheckBox ID="chkActive" runat="server" />
                            </td>
                            <td colspan="2" align="justify" valign="middle">
                                <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="false" CommandName="emptyInsert"
                                    Text="emptyInsert"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>--%>
