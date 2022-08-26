<%@ Control Language="C#" AutoEventWireup="true" CodeFile="supportContact.ascx.cs" Inherits="UserControl_supportContact" %>

<%--<table style="width:13.5em; margin-top:0.3em" class="tSubGray">--%>
<table class="tSubGray" style="width: 180px">
    <tr>
        <td class="cHeadTile">Support Contacts</td>
    </tr>
    <tr>
        <td class="cTextLeft">
            <asp:BulletedList ID="supportBlst" runat="server" BulletStyle="CustomImage" BulletImageUrl="~/Images/i_winPeople2.gif" BorderStyle="None" Font-Bold="True"></asp:BulletedList>
        </td>
    </tr>
</table>
