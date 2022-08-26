<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DetailResourceUtilisation.ascx.cs" Inherits="UserControl_DetailResourceUtilisation" %>

<asp:GridView ID="ChildGrdView" runat="server" AutoGenerateColumns="False" ShowFooter="true"
    OnPageIndexChanging="ChildGrdView_PageIndexChanging" OnRowCommand="ChildGrdView_RowCommand"
    OnRowCancelingEdit="ChildGrdView_RowCancelingEdit"
    OnRowDataBound="ChildGrdView_RowDataBound" OnRowDeleting="ChildGrdView_RowDeleting"
    OnRowEditing="ChildGrdView_RowEditing" OnRowUpdating="ChildGrdView_RowUpdating" DataKeyNames="IDRESOURCE"
    Width="100%" OnRowCreated="ChildGrdView_RowCreated">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Discipline" HeaderStyle-HorizontalAlign="Left">
            <EditItemTemplate>
                <asp:DropDownList ID="drpDiscipline" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDiscipline_SelectedIndexChanged"></asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drpDiscipline" ErrorMessage="Select Discipline" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
            </EditItemTemplate>

            <FooterTemplate>
                <asp:DropDownList ID="drpDiscipline" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDiscipline_SelectedIndexChanged"></asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drpDiscipline" ErrorMessage="Select Discipline" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
            </FooterTemplate>

            <ItemTemplate>
                <%# Eval("DISCIPLINE")%>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="No of Staff" HeaderStyle-HorizontalAlign="Left">
            <EditItemTemplate>
                <asp:TextBox ID="txtNoOfStaff" runat="server" Text='<%# Eval("NOOFSTAFF") %>' Width="50px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNoOfStaff" runat="server" ControlToValidate="txtNoOfStaff"
                    ErrorMessage="Please Enter No of Staff" ForeColor="Red" SetFocusOnError="true" ToolTip="Please Enter No of Staff" ValidationGroup="Update">*</asp:RequiredFieldValidator>
            </EditItemTemplate>

            <FooterTemplate>
                <asp:TextBox ID="txtNoOfStaff" runat="server" Text='<%# Eval("NOOFSTAFF") %>' Width="50px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNoOfStaff" runat="server" ControlToValidate="txtNoOfStaff"
                    ErrorMessage="Please Enter No of Staff" ForeColor="Red" SetFocusOnError="true" ToolTip="Please Enter No of Staff" ValidationGroup="Insert">*</asp:RequiredFieldValidator>
            </FooterTemplate>

            <ItemTemplate>
                <%# Eval("NOOFSTAFF")%>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Max. Work Hours/Staff" HeaderStyle-HorizontalAlign="Left">
            <EditItemTemplate>
                <asp:Label ID="lblMaxWrkHr" runat="server" Text='<%# Eval("MAXWRHR") %>'></asp:Label>
            </EditItemTemplate>

            <FooterTemplate>
                <asp:Label ID="lblMaxWrkHr" runat="server" Text='<%# Eval("MAXWRHR") %>'></asp:Label>
            </FooterTemplate>

            <ItemTemplate>
                <%# Eval("MAXWRHR")%>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Staff Hour Utilisation" HeaderStyle-HorizontalAlign="Left">
            <EditItemTemplate>
                <asp:TextBox ID="txtWrkHrUtil" runat="server" Text='<%# Eval("STAFFHRUTIL") %>' Width="50px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtWrkHrUtil" ErrorMessage="Please Enter Staff Hour Utilisation" ForeColor="Red" SetFocusOnError="true" ToolTip="Please Enter Staff Hour Utilisation" ValidationGroup="Update">*</asp:RequiredFieldValidator>
            </EditItemTemplate>

            <FooterTemplate>
                <asp:TextBox ID="txtWrkHrUtil" runat="server" Text='<%# Eval("STAFFHRUTIL") %>' Width="50px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtWrkHrUtil" ErrorMessage="Please Enter Staff Hour Utilisation" ForeColor="Red" SetFocusOnError="true" ToolTip="Please Enter Staff Hour Utilisation" ValidationGroup="Insert">*</asp:RequiredFieldValidator>
            </FooterTemplate>

            <ItemTemplate>
                <%# Eval("STAFFHRUTIL")%>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="..." ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
            <EditItemTemplate>
                <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update" OnClientClick="return confirm('Update?')" ValidationGroup="Update"></asp:LinkButton>
                <asp:ValidationSummary ID="vsUpdate" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Update" Enabled="true" HeaderText="Validation Summary..." />
                <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
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

        <asp:TemplateField HeaderText="..." ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Delete?')"></asp:LinkButton>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left" />
        </asp:TemplateField>

    </Columns>
    <EmptyDataTemplate>
        <table style="width: 100%" border="1" id="gvEG">
            <tr>
                <td>
                    Discipline</td>
                <td>
                    No of Staff</td>
                <td>
                    Max. Work Hours/Staff</td>
                <td>
                    Staff Hour Utilisation</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="drpDiscipline" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDiscipline_SelectedIndexChanged">
                        <asp:ListItem Value="-1">Select Discipline</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drpDiscipline" ErrorMessage="Discipline is required" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                </td>
                <td>
                    <%--<asp:Label ID="lblNoOfStaff" runat="server"></asp:Label>--%>
                    <asp:TextBox ID="txtNoOfStaff" runat="server" Width="50px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNoOfStaff" ErrorMessage="Please Enter Staff Hour Utilisation" ForeColor="Red" SetFocusOnError="true" ToolTip="Please Enter Staff Hour Utilisation" ValidationGroup="Update">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="lblMaxWrkHr" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtWrkHrUtil" runat="server" Text='<%# Eval("STAFFHRUTIL") %>' Width="50px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtWrkHrUtil" ErrorMessage="Please Enter Staff Hour Utilisation" ForeColor="Red" SetFocusOnError="true" ToolTip="Please Enter Staff Hour Utilisation" ValidationGroup="Update">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="false" CommandName="emptyInsert" Text="Add" ValidationGroup="Update"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </EmptyDataTemplate>
</asp:GridView>

<asp:HiddenField ID="lInitiativeHF" runat="server" />
