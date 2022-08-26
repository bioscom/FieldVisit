<%@ Control Language="C#" AutoEventWireup="true" CodeFile="activityDescription.ascx.cs" Inherits="App_BONGACCP_UserControl_activityDescription" %>
<asp:GridView ID="detailsGrdView" runat="server" ShowFooter="true" AutoGenerateColumns="False" DataKeyNames="DETAILSID" Width="100%" OnRowDataBound="detailsGrdView_RowDataBound">
    <Columns>

        <asp:TemplateField>
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <ItemStyle Width="15px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Description">
            <ItemTemplate>
                <asp:Label ID="lblDescription" runat="server"
                    Text='<%# DataBinder.Eval(Container.DataItem, "DESCRIPTION") %>'></asp:Label>
            </ItemTemplate>

            <FooterTemplate>
                <asp:Label ID="lbGrdTotal" runat="server" Text="Total"></asp:Label>
            </FooterTemplate>

            <ItemStyle Width="60%" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Quantity">
            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("QUANTITY","{0:N2}") %>'></asp:Label>
                </div>
            </ItemTemplate>

            <FooterTemplate>
                <div style="text-align: right">
                    <%--<asp:Label ID="lblTotalQty" runat="server" Text=""></asp:Label>--%>
                </div>
            </FooterTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="Rate($)">
            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblRate" runat="server" Text='<%# Eval("RATE","{0:N2}") %>'></asp:Label>
                </div>
            </ItemTemplate>

            <FooterTemplate>
                <div style="text-align: right">
                    <%--<asp:Label ID="lblTotalRate" runat="server" Text=""></asp:Label>--%>
                </div>
            </FooterTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="Amount($)">
            <ItemTemplate>
                <div style="text-align: right">                    
                    <asp:Label ID="lblAmount" runat="server" Text=''></asp:Label>
                </div>
            </ItemTemplate>

            <FooterTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                </div>
            </FooterTemplate>

        </asp:TemplateField>

    </Columns>

    <FooterStyle BackColor="Gold" Font-Bold="True" Font-Size="11pt" ForeColor="Black" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />

</asp:GridView>
