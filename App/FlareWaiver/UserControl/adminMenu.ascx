<%@ Control Language="C#" AutoEventWireup="true" CodeFile="adminMenu.ascx.cs" Inherits="UserControl_adminMenu" %>

<div id="navigationM">
    <ul>
        <asp:Repeater runat="server" ID="menu" DataSourceID="MyDataSource" EnableViewState="False">
            <ItemTemplate>
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Url") %>'><%# Eval("Title") %></asp:HyperLink>

                    <asp:Repeater ID="Repeater1" runat="server" DataSource='<%# ((SiteMapNode) Container.DataItem).ChildNodes %>'>
                        <HeaderTemplate>
                            <ul>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <li>
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("Url") %>'><%# Eval("Title") %></asp:HyperLink>
                                <asp:Repeater ID="Repeater3" runat="server" DataSource='<%# ((SiteMapNode) Container.DataItem).ChildNodes %>'>

                                    <HeaderTemplate>
                                        <ul>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <li>
                                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# Eval("Url") %>'><%# Eval("Title") %></asp:HyperLink>
                                        </li>
                                    </ItemTemplate>

                                    <FooterTemplate>
                                        </ul>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </li>
                        </ItemTemplate>

                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>

                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <asp:SiteMapDataSource ID="MyDataSource" runat="server" ShowStartingNode="false" />
</div>

<%--<asp:Menu ID="UserMenu" DataSourceID="MyDataSource" runat="server" DynamicHorizontalOffset="0"
    StaticMenuItemStyle-BorderWidth="1px" DynamicMenuItemStyle-BorderWidth="1px"
    StaticMenuItemStyle-VerticalPadding="3px" DynamicMenuItemStyle-VerticalPadding="3px"
    StaticMenuItemStyle-BorderStyle="Solid" DynamicMenuItemStyle-BorderStyle="Solid"
    StaticMenuItemStyle-BorderColor="Silver" DynamicMenuItemStyle-BorderColor="Silver"
    Font-Names="Arial" StaticSubMenuIndent="10px" Font-Size="12px" StaticDisplayLevels="2" Width="230px">
    <DataBindings>
        <asp:MenuItemBinding DataMember="MenuItem" NavigateUrlField="NavigateUrl" TextField="Title" ToolTipField="ToolTip" />
    </DataBindings>
    <LevelMenuItemStyles>
        <asp:MenuItemStyle CssClass="level1" />
        <asp:MenuItemStyle CssClass="level2" />
        <asp:MenuItemStyle CssClass="level3" />
        <asp:MenuItemStyle CssClass="level4" />
    </LevelMenuItemStyles>

    <StaticHoverStyle CssClass="hoverstylestatic" />
    <DynamicHoverStyle CssClass="hoverstyledynamic" />
</asp:Menu>
<asp:SiteMapDataSource ID="MyDataSource" runat="server" ShowStartingNode="false" />--%>
