<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewComments.ascx.cs" Inherits="App_ManHour_UserControl_ViewComments" %>

<asp:Label ID="lblMssg" runat="server" Text='Supports and Approvals Comments ' Font-Bold="True"></asp:Label>
<hr />
<asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" OnRowCommand="grdView_RowCommand"
    OnSelectedIndexChanged="grdView_SelectedIndexChanged" AllowPaging="True" OnLoad="grdView_Load"
    OnPageIndexChanging="grdView_PageIndexChanging" PageSize="12" Width="100%">
    <Columns>

        <asp:TemplateField>
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="...">
            <ItemTemplate>
                <asp:CheckBox ID="reminderCheckBox" runat="server"
                    USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>' />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Support" SortExpression="ROLEID">
            <ItemTemplate>
                <asp:Label ID="labelRole" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ROLEID") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="150px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Responsible Support">
            <ItemTemplate>
                <asp:Label ID="labelResponsibleSupport" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Stand" SortExpression="STAND">
            <ItemTemplate>
                <asp:Label ID="labelStand" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STAND") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Comments">
            <ItemTemplate>
                <asp:Label ID="labelComments" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMMENTS") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="280px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Date Received" SortExpression="DATE_RECEIVED">
            <ItemTemplate>
                <asp:Label ID="labelDateReceived" runat="server" Text='<%# dateRoutine.dateShort(DateTime.Parse(DataBinder.Eval(Container.DataItem, "DATE_RECEIVED").ToString())) %>'></asp:Label>

            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Date Reviewed" SortExpression="DATE_REVIEWED">
            <ItemTemplate>
                <asp:Label ID="labelDateReviewed" runat="server" Text='<%# Bind("DATE_REVIEWED", "{0:dd/MM/yyyy}") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>
<hr />
<asp:Button ID="reminderButton" runat="server" Text="Send Reminder" Height="25px" Width="150px" OnClick="reminderButton_Click" />
<asp:HiddenField ID="lInitiativeHF" runat="server" />



