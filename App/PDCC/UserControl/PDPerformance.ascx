<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PDPerformance.ascx.cs" Inherits="App_PDCC_UserControl_PDPerformance" %>
<div style="font-size:120%;color:navy; font-weight:bold; margin-left:0.3em">Production</div>
    <asp:GridView ID="grdView" runat="server" AllowPaging="True"
        AutoGenerateColumns="False" OnLoad="grdView_Load"
        OnPageIndexChanging="grdView_PageIndexChanging" BackColor="White"
        OnRowCommand="grdView_RowCommand" PageSize="20" Width="100%"
        OnSelectedIndexChanged="grdView_SelectedIndexChanged" ShowFooter="true">
        <Columns>

            <asp:TemplateField HeaderText="...">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
		<ItemStyle Width="10px" />
                </asp:TemplateField>

            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Label ID="lblAsset" runat="server" ForeColor="Black" Text='PD Performance'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="200px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="OP ($)" HeaderStyle-BackColor="Yellow">
                <ItemTemplate>
                    <div style="text-align: right">
                        <asp:Label ID="lblOpex" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "OPEX") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle BackColor="Yellow" Width="100px" />
                <FooterStyle BackColor="Yellow"/>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Banked ($)" HeaderStyle-BackColor="Green">
                <ItemTemplate>
                    <div style="text-align: right">
                        <asp:Label ID="lblActualSaving" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "ACTSAVINGS") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle BackColor="Green" Width="100px" />
                <FooterStyle BackColor="Green"/>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="%age Banked">
                <ItemTemplate>
                    <div style="text-align: right">
                        <asp:Label ID="lblPercentageBanked" ForeColor="Black" runat="server" Text=''></asp:Label>
                    </div>
                </ItemTemplate>
		<ItemStyle Width="100px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Opportunities ($)" HeaderStyle-BackColor="SkyBlue">
                <ItemTemplate>
                    <div style="text-align: right">
                        <asp:Label ID="lblImprovement" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "IMPROVEMENT") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle BackColor="SkyBlue" Width="100px"/>
                <FooterStyle BackColor="SkyBlue"/>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="B&O ($)">
                <ItemTemplate>
                    <div style="text-align: right">
                        <asp:Label ID="lblBO" runat="server" ForeColor="Black" Text=''></asp:Label>
                    </div>
                </ItemTemplate>
		<ItemStyle Width="100px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="25% Target Reduction($)">
                <ItemTemplate>
                    <div style="text-align: right">
                        <asp:Label ID="lblReduction" runat="server" ForeColor="Black" Text=''></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Current Gap($) excl. Oppor." HeaderStyle-BackColor="#ff9933">
                <ItemTemplate>
                    <div style="text-align: right">
                        <asp:Label ID="lblCurrentGap" runat="server" ForeColor="Black" Text=''></asp:Label>
                    </div>
                </ItemTemplate>
                <ItemStyle BackColor="#ff9933" Width="100px" />
                <FooterStyle BackColor="#ff9933"/>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

