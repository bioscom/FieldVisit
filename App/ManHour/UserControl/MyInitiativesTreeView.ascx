<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyInitiativesTreeView.ascx.cs" Inherits="UserControl_MyInitiativesTreeView" %>

<table class="tSubGray" style="width: 200px;">
    <tr>
        <td class="cHeadTileCenta">
            <asp:LinkButton ID="BusinessInitLinkButton" runat="server" OnClick="BusinessInitLinkButton_Click">Business Initiatives</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td>
            <asp:TreeView ID="BITreeView" runat="server" DataSourceID="BIXmlDS">
            </asp:TreeView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="newInitBtn" runat="server" OnClick="newInitBtn_Click" Text="Create New Initiative" Width="100%" />
            <asp:XmlDataSource ID="BIXmlDS" runat="server" EnableCaching="False" TransformFile="~/CSS/TransformXSLT.xslt" XPath="MenuItems/MenuItem" />
        </td>
    </tr>
</table>


