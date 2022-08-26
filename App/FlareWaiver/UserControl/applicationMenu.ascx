<%@ Control Language="C#" AutoEventWireup="true" CodeFile="applicationMenu.ascx.cs" Inherits="UserControl_applicationMenu" %>

<table style="width:200px" class="tSubGray">
    <tr>
        <td>
            <div id="navigationM">
                <ul>
                    <%--<li><asp:HyperLink runat="server" ID="lnkHome" NavigateUrl="~/Default.aspx">Home</asp:HyperLink></li>--%>
                    <asp:Repeater runat="server" ID="menu" DataSourceID="SiteMapDataSource1" EnableViewState="False">
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
                <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="false" />
            </div>
        </td>
    </tr>
</table>