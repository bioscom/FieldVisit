<%@ Control Language="C#" AutoEventWireup="true" CodeFile="adminMenu.ascx.cs" Inherits="UserControl_adminMenu" %>

<div style="width: 200px" id="navigationM">
    <%--<ul>
        <li><asp:HyperLink runat="server" ID="lnkHome" NavigateUrl="~/Default.aspx">Home</asp:HyperLink></li>--%>
        <%--<asp:Repeater runat="server" ID="menu" EnableViewState="False">
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
                    </asp:Repeater>--%>
        <asp:Menu ID="Menu1" runat="server" Orientation="Vertical">
            <Items>
                <asp:MenuItem NavigateUrl="AppGatePass.aspx?sAppToken=pdcc" Text="Production Cost Challenge"></asp:MenuItem>
            </Items>
            <Items>
                <asp:MenuItem NavigateUrl="AppGatePass.aspx?sAppToken=pec" Text="Field Visit / PEC"></asp:MenuItem>
            </Items>
            <Items>
                <asp:MenuItem NavigateUrl="AppGatePass.aspx?sAppToken=IMF" Text="Initiative Mngt Framework"></asp:MenuItem>
            </Items>
            <Items>
                <asp:MenuItem NavigateUrl="AppGatePass.aspx?sAppToken=flr" Text="Flare Waiver"></asp:MenuItem>
            </Items>
            <Items>
                <asp:MenuItem NavigateUrl="AppGatePass.aspx?sAppToken=BI" Text="BI 500"></asp:MenuItem>
            </Items>
            <Items>
                <asp:MenuItem NavigateUrl="AppGatePass.aspx?sAppToken=Lean" Text="CI Projects Dashboard"></asp:MenuItem>
            </Items>
            <Items>
                <asp:MenuItem NavigateUrl="http://sww.scin.cpdms.shell.com/iap/Default.aspx" Text="IAP Change Control Form"></asp:MenuItem>
            </Items>

        </asp:Menu>
    <%--</ul>--%>
</div>
