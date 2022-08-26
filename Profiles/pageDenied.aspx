<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/init.master" AutoEventWireup="true" CodeFile="pageDenied.aspx.cs" Inherits="Profiles_pageDenied" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tSubFree">
        <tr>
            <td style="width: 40%">
                <table class="tSubGray">
                    <tr>
                        <td class="cHeadTile">Resource Access Denied</td>
                    </tr>
                    <tr>
                        <td class="cTextCenta">
                            <br />
                            <br />
                            <img src="../Images/i_passwordKey.gif" width="108" />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="cTextCenta">
                            <strong>You do not have the Required User Account Priviledge to View this Page or your session has timed out. Please,
                                contact Your Administrator for Help.</strong></td>
                    </tr>
                    <tr>
                        <td class="cTextCenta">
                            <br />
                            <%--<a id="dpeBackLink" href="javascript:history.back()">
                                <asp:ImageButton ID="ImageButton2" runat="server" Style="border: 0" ImageUrl="~/Images/bullet_back.gif" />
                                Back</a>--%>
                            <asp:Button ID="cmdCancel" runat="server" CausesValidation="False" PostBackUrl="~/Default.aspx"
                                Text="Goto Taskpage" Height="25px" Width="150px" /><br />
                        </td>
                    </tr>
                </table>
            </td>
            <td></td>
        </tr>

    </table>
</asp:Content>

