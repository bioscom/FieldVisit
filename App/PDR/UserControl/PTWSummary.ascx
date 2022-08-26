<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PTWSummary.ascx.cs" Inherits="App_PDR_UserControl_PTWSummary" %>
<asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowFooter="True" Width="600px">
    <Columns>

        <asp:TemplateField>
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="ACTIVE">
            <ItemTemplate>
                <asp:TextBox ID="txtActive" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIVE") %>'
                    IDPTW='<%# DataBinder.Eval(Container.DataItem, "IDPTW") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="SUSPENDED">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtSuspended" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SUSPENDED") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="CLOSED">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtClosed" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CLOSED") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="EPI">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtEPI" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EPI") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="AUTHORIZED">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtAuthorised" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AUTHORIZED") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>
                						
        <asp:TemplateField HeaderText="EXPIRED">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtExpired" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EXPIRED") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="CANCELLED">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtCancelled" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CANCELLED") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="TOTAL">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>
<asp:HiddenField ID="lReportIdHF" runat="server" />