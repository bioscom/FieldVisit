<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PriceTracker.master" AutoEventWireup="true" CodeFile="PriceCheckList.aspx.cs" Inherits="App_Prices_PriceCheckList" %>

<%@ Register Src="UserControl/oCostSaving.ascx" TagName="oCostSaving" TagPrefix="uc2" %>
<%@ Register Src="UserControl/oCostSavingForReviewer.ascx" TagPrefix="uc2" TagName="oCostSavingForReviewer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" ScriptMode="Release">
    </ajaxToolkit:ToolkitScriptManager>

    <table class="tMainBorder" style="width: 99%">
        <tr>
            <td class="cHeadTile">Service/Material Cost Red Flags</td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="uppAjaxBloc" runat="server">
                    <ContentTemplate>
                        <ajaxToolkit:TabContainer runat="server" ID="smtAjaxTabs" ActiveTabIndex="0" Width="100%">
                            <ajaxToolkit:TabPanel runat="server" ID="pnlBusinessInitiative" HeaderText="Awaiting Approval" Width="100%" Visible="true">
                                <HeaderTemplate>Cost Red Flag Ongoing Review</HeaderTemplate>
                                <ContentTemplate>
                                    <uc2:oCostSavingForReviewer ID="oCostSavingForReviewer" runat="server" />
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>

                            <ajaxToolkit:TabPanel runat="server" ID="pnlDistrict" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                                <HeaderTemplate>Closed Out Items</HeaderTemplate>
                                <ContentTemplate>
                                    <uc2:oCostSavingForReviewer ID="oClosedOut" runat="server" />
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>

                        </ajaxToolkit:TabContainer>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Label runat="server" ID="CurrentTab" />
                <asp:Label runat="server" ID="Messages" />
            </td>
        </tr>
    </table>
</asp:Content>

