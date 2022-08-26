<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PDSummaryCostRedn.ascx.cs" Inherits="App_PDCC_UserControl_PDSummaryCostRedn" %>
<asp:GridView ID="grdView" runat="server" AllowPaging="True" RowStyle-BackColor="White"
    AutoGenerateColumns="False" PageSize="20" Width="100%" ShowFooter="true" FooterStyle-BackColor="White">
    <Columns>

        <asp:TemplateField HeaderText="...">
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <ItemStyle Width="10px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Asset">
            <ItemTemplate>
                <asp:Label ID="lblAsset" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "ASSET") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="200px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="OP ($)" HeaderStyle-BackColor="Yellow">
            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblOpex" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "OPEX") %>'></asp:Label>
                </div>
            </ItemTemplate>

            <HeaderStyle BackColor="Yellow"></HeaderStyle>

            <ItemStyle BackColor="Yellow" Width="100px" />
            <FooterStyle BackColor="Yellow" HorizontalAlign="Right" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Deep Dive Banked($)" HeaderStyle-BackColor="Green">
            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblDDBanked" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "DDBANKED") %>'></asp:Label>
                </div>
            </ItemTemplate>

            <HeaderStyle BackColor="Green"></HeaderStyle>

            <ItemStyle BackColor="Green" Width="100px" />
            <FooterStyle BackColor="Green" HorizontalAlign="Right" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Deep Dive Opportunities($)" HeaderStyle-BackColor="SkyBlue">
            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblDDOppor" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "DDOPPOR") %>'></asp:Label>
                </div>
            </ItemTemplate>

            <HeaderStyle BackColor="SkyBlue"></HeaderStyle>

            <ItemStyle BackColor="SkyBlue" Width="100px" />
            <FooterStyle BackColor="SkyBlue" HorizontalAlign="Right" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Deep Dive Opportunities Banked ($)" HeaderStyle-BackColor="SkyBlue">
            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblDDOpporBanked" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "DDOPPORBANKED") %>'></asp:Label>
                </div>
            </ItemTemplate>

            <HeaderStyle BackColor="SkyBlue"></HeaderStyle>

            <ItemStyle BackColor="SkyBlue" Width="100px" />
            <FooterStyle BackColor="SkyBlue" HorizontalAlign="Right" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Total DD Banked" HeaderStyle-BackColor="SkyBlue">
            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblTotalDDBanked" runat="server" ForeColor="Black"></asp:Label>
                </div>
            </ItemTemplate>

            <HeaderStyle BackColor="SkyBlue"></HeaderStyle>

            <ItemStyle BackColor="SkyBlue" Width="100px" />
            <FooterStyle BackColor="SkyBlue" HorizontalAlign="Right" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="% DD Banked" HeaderStyle-BackColor="SkyBlue">
            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblPercDeepDiveBanked" runat="server" ForeColor="Black"></asp:Label>
                </div>
            </ItemTemplate>

            <HeaderStyle BackColor="SkyBlue"></HeaderStyle>

            <ItemStyle BackColor="SkyBlue" Width="100px" />
            <FooterStyle BackColor="SkyBlue" HorizontalAlign="Right" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Efficiency Improvement Opportunities" HeaderStyle-BackColor="Pink">
            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblEIO" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "EIO") %>'></asp:Label>
                </div>
            </ItemTemplate>

            <HeaderStyle BackColor="Pink"></HeaderStyle>

            <ItemStyle BackColor="Pink" Width="100px" />
            <FooterStyle BackColor="Pink" HorizontalAlign="Right" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Effciency Improvement Opportunities Banked" HeaderStyle-BackColor="Pink">
            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblEIOBanked" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "EIOBANKED") %>'></asp:Label>
                </div>
            </ItemTemplate>

            <HeaderStyle BackColor="Pink"></HeaderStyle>

            <ItemStyle BackColor="Pink" Width="100px" />
            <FooterStyle BackColor="Pink" HorizontalAlign="Right" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="%EIO Banked" HeaderStyle-BackColor="Pink">
            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblPercEIOBanked" runat="server" ForeColor="Black"></asp:Label>
                </div>
            </ItemTemplate>

            <HeaderStyle BackColor="Pink"></HeaderStyle>

            <ItemStyle BackColor="Pink" Width="100px" />
            <FooterStyle BackColor="Pink" HorizontalAlign="Right" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="All Savings Banked ($)">
            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblAllSavingsBanked" runat="server" ForeColor="Black"></asp:Label>
                </div>
            </ItemTemplate>
            <ItemStyle Width="100px" />
            <FooterStyle HorizontalAlign="Right" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="%age banked">
            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblPercBanked" runat="server" ForeColor="Black"></asp:Label>
                </div>
            </ItemTemplate>
            <ItemStyle Width="100px" />
            <FooterStyle HorizontalAlign="Right" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="%Savings Target">
            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblSavingTarget" runat="server" ForeColor="Black"></asp:Label>
                </div>
            </ItemTemplate>
            <ItemStyle Width="100px" />
            <FooterStyle HorizontalAlign="Right" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="25% target reduction ($)">
            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblTargetRedctn" runat="server" ForeColor="Black"></asp:Label>
                </div>
            </ItemTemplate>
            <ItemStyle Width="100px" />
            <FooterStyle HorizontalAlign="Right" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Current Gap ($) excluding Oppor" HeaderStyle-BackColor="#ff9933">
            <ItemTemplate>
                <div style="text-align: right">
                    <asp:Label ID="lblCurrentGap" runat="server" ForeColor="Black"></asp:Label>
                </div>
            </ItemTemplate>

            <ItemStyle BackColor="#ff9933" Width="100px" />
            <FooterStyle BackColor="#ff9933"  HorizontalAlign="Right" />
        </asp:TemplateField>

    </Columns>
</asp:GridView>

