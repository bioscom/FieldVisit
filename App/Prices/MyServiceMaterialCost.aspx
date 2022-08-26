<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PriceTracker.master" AutoEventWireup="true" CodeFile="MyServiceMaterialCost.aspx.cs" Inherits="App_Prices_MyServiceMaterialCost" %>

<%@ Register Src="UserControl/oCostSaving.ascx" TagName="oCostSaving" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" ScriptMode="Release">
    </ajaxToolkit:ToolkitScriptManager>

    <table class="tMainBorder" style="width: 99%">
        <tr>
            <td class="cHeadTile">My Service/Material Cost Red Flags</td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="uppAjaxBloc" runat="server">
                    <ContentTemplate>
                        <ajaxToolkit:TabContainer runat="server" ID="smtAjaxTabs" ActiveTabIndex="0" Width="100%">
                            <ajaxToolkit:TabPanel runat="server" ID="pnlBusinessInitiative" HeaderText="Awaiting Approval" Width="100%" Visible="true">
                                <HeaderTemplate>My Items Ongoing Review</HeaderTemplate>
                                <ContentTemplate>
                                    <uc2:oCostSaving ID="MyOngoingSubmission" runat="server" />
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>

                            <ajaxToolkit:TabPanel runat="server" ID="pnlDistrict" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                                <HeaderTemplate>My Closed Out Items</HeaderTemplate>
                                <ContentTemplate>
                                    <uc2:oCostSaving ID="MyApprovedSubmission" runat="server" />
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

