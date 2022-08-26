<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PDCC.master" AutoEventWireup="true" CodeFile="ThreePartMonthlySumm.aspx.cs" Inherits="App_PDCC_ThreePartMonthlySumm" %>

<%@ Register Src="UserControl/ThreePartOpprInitialEst.ascx" TagName="ThreePartOpprInitialEst" TagPrefix="uc2" %>
<%@ Register Src="UserControl/ThreePartOpprEstSavings.ascx" TagName="ThreePartOpprEstSavings" TagPrefix="uc3" %>
<%@ Register Src="UserControl/ThreePartOpprActual.ascx" TagName="ThreePartOpprActual" TagPrefix="uc4" %>
<%@ Register Src="~/App/PDCC/UserControl/ThreePartOpprLE.ascx" TagName="ThreePartOpprLE" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">

    <asp:UpdatePanel ID="uppAjaxBloc" runat="server">
        <ContentTemplate>
            <ajaxToolkit:TabContainer runat="server" ID="smtAjaxTabs" Width="99%" ActiveTabIndex="0">
                <ajaxToolkit:TabPanel runat="server" ID="pnlBusinessInitiative" HeaderText="Awaiting Approval" Width="100%" Visible="true">
                    <HeaderTemplate>Estimated Savings (25% Reduction)</HeaderTemplate>
                    <ContentTemplate>
                        <div style="overflow: auto">
                            <uc2:ThreePartOpprInitialEst ID="ThreePartOpprInitialEst1" runat="server" />
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>

                <ajaxToolkit:TabPanel runat="server" ID="pnlDistrict" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                    <HeaderTemplate>3 Part Opportunity - Estimated</HeaderTemplate>
                    <ContentTemplate>
                        <div style="overflow: auto">
                            <uc3:ThreePartOpprEstSavings ID="ThreePartOpprEstSavings1" runat="server" />
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>

                <ajaxToolkit:TabPanel runat="server" ID="pnlResourceUtilisation" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                    <HeaderTemplate>3 Part Opportunity - Actual</HeaderTemplate>
                    <ContentTemplate>
                        <div style="overflow: auto">
                            <uc4:ThreePartOpprActual ID="ThreePartOpprActual1" runat="server" />
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>

                <ajaxToolkit:TabPanel ID="progressTabPanel" runat="server" HeaderText="Project Status" Width="100%" Visible="true">
                    <HeaderTemplate>3 Part Opportunity - Latest Estimate</HeaderTemplate>
                    <ContentTemplate>
                        <div style="overflow: auto">
                            <uc2:ThreePartOpprLE runat="server" ID="ThreePartOpprLE1" />
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>

            </ajaxToolkit:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Label runat="server" ID="CurrentTab" />
    <asp:Label runat="server" ID="Messages" />
    <b><u>Legend:</u></b><br />
    <b style="color:blue">DD  = Deep Dive</b><br />
    <b style="color:purple">DDO = Deep Dive Opportunity</b><br />
    <b style="color:black">EIO  = Efficiency Improvement Opportunity</b><br />

</asp:Content>

