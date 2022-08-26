<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userHelpGuide.ascx.cs" Inherits="UserControl_userHelpGuide" %>

<table class="tSubGray" style="width:250px">
    <tr>
        <td class="cHeadLeft">
            Application Help &amp; Guides</td>
    </tr>
    <tr>
        <td class="cTextCenta">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align:center">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/i_appHelpEx.gif" />
            <br />
            <asp:LinkButton ID="hlpGuideLinkButton" runat="server" onclick="hlpGuideLinkButton_Click" ValidationGroup="dnlt">Download Help Guide</asp:LinkButton>
        </td>
    </tr>
</table>
                            