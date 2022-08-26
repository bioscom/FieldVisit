<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="taskPage.aspx.cs" Inherits="taskPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<table class="tSubFree">
        <tr>
            <td align="center" class="cTextLeft" colspan="2" rowspan="1" valign="top">
                <table class="tSubFree">
                    <tr>
                        <td class="cTextLeft" colspan="2" valign="middle">
                            <asp:Label ID="LblTaskRetMsg" runat="server" Font-Bold="True" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" width="60%">
                <table cellpadding="0" cellspacing="2" class="tSubFree">
                    <tr>
                        <td>
                            <table class="tSubGray" cellpadding="2" cellspacing="0">
                                <tr>
                                    <td class="cHeadLeft" colspan="3" valign="top">
                                        JV OPEX Common Tasks
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cTextCenta" valign="top" width="33%">
                                        <asp:ImageButton ID="imbAddOpex" runat="server" CssClass="iIconSize64" Height="64px"
                                            ImageUrl="~/Images/i_dirSave.gif" PostBackUrl="~/Planning/axNewOpexItem.aspx" Width="64px" />
                                        <br />
                                        
                                        <asp:HyperLink ID="hpkAddOpex" runat="server" NavigateUrl="~/Planning/axNewOpexItem.aspx">Add New/Edit OPEX Cost Element</asp:HyperLink>
                                    </td>
                                    <td class="cTextCenta" valign="top" width="33%">
                                        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="iIconSize64" Height="64px"
                                            ImageUrl="~/Images/i_dirView.gif" PostBackUrl="~/Planning/listOpexItem.aspx"
                                            Width="64px" />
                                        <br />
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Planning/listOpexItem.aspx">View My OPEX Cost Element Entries</asp:HyperLink>
                                    </td>
                                    <td class="cTextCenta" valign="top" width="33%">
                                        <asp:ImageButton ID="ImageButton2" runat="server" CssClass="iIconSize64" Height="64px"
                                            ImageUrl="~/Images/i_dirSearch.gif" PostBackUrl="~/Planning/findOpexItem.aspx"
                                            Width="64px" />
                                        <br />
                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Planning/findOpexItem.aspx">Search My OPEX Cost Element Entries</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cTextCenta" valign="top" width="33%">
                                        <asp:ImageButton ID="ImageButton6" runat="server" CssClass="iIconSize64" Height="64px"
                                            ImageUrl="~/Images/i_dirMaths.gif" PostBackUrl="~/Planning/listOpexItemOnEdit.aspx?Idx=xPh"
                                            Width="64px" />
                                        <br />
                                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Planning/listOpexItemOnEdit.aspx?Idx=xPh">View My Un-Phased OPEX Cost Element Entries</asp:HyperLink>
                                    </td>
                                    <td class="cTextCenta" valign="top" width="33%">
                                        <asp:ImageButton ID="ImageButton7" runat="server" CssClass="iIconSize64" Height="64px"
                                            ImageUrl="~/Images/i_dirPublic.gif" PostBackUrl="~/Planning/axBulkOpexProductn.aspx"
                                            Width="64px" />
                                        <br />
                                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Planning/axBulkOpexProductn.aspx">OPEX Data Bulk Upload Utility</asp:HyperLink>
                                    </td>
                                    <td class="cTextCenta" valign="top" width="33%">
                                        <asp:ImageButton ID="ImageButton8" runat="server" CssClass="iIconSize64" Height="64px"
                                            ImageUrl="~/Images/i_dirExchange.gif" PostBackUrl="~/Planning/viewExchangeRate.aspx"
                                            Width="64px" />
                                        <br />
                                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Planning/viewExchangeRate.aspx">View Current Exchange Rate Values</asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="2" class="tSubFree">
                                <tr>
                                    <td>
                                        <table class="tSubGray" cellpadding="2" cellspacing="0">
                                            <tr>
                                                <td class="cHeadLeft" colspan="3" valign="top">
                                                    JV OPEX Report Tasks
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cTextCenta" valign="top" width="33%">
                                                    <asp:ImageButton ID="ImageButton3" runat="server" CssClass="iIconSize64" Height="64px"
                                                        ImageUrl="~/Images/i_dirPaste.gif" PostBackUrl="~/Reports/listCostElementOnTypes.aspx?Viw=1"
                                                        Width="64px" />
                                                    <br />
                                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Reports/listCostElementOnTypes.aspx?Viw=1">OPEX Cost Element Report [Group by SAP]</asp:HyperLink>
                                                </td>
                                                <td class="cTextCenta" valign="top" width="33%">
                                                    <asp:ImageButton ID="ImageButton4" runat="server" CssClass="iIconSize64" Height="64px"
                                                        ImageUrl="~/Images/i_dirConfig.gif" PostBackUrl="~/Reports/costListReportWizard.aspx"
                                                        Width="64px" /><br />
                                                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Reports/costListReportWizard.aspx">OPEX Cost Element Report [Customized Report]</asp:HyperLink>
                                                </td>
                                                <td class="cTextCenta" valign="top" width="33%">
                                                    <asp:ImageButton ID="ImageButton5" runat="server" CssClass="iIconSize64" Height="64px"
                                                        ImageUrl="~/Images/i_dirXml.gif" Width="64px" />
                                                    <br />
                                                    <asp:LinkButton ID="lnkDownloadXml" runat="server">Download Report As Microsoft Excel</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                </table>
            </td>
            <td align="center" valign="top" width="40%">
                </td>
        </tr>
    </table>--%>
</asp:Content>