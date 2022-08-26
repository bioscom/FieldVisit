<%@ Page Title="" Language="C#" MasterPageFile="~/BongaCCP.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="App_BONGACCP_Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/App/CommitmentControl/UserControl/oCommitmentPendingTele.ascx" TagPrefix="uc2" TagName="oCommitmentPendingTele" %>
<%@ Register Src="~/App/CommitmentControl/UserControl/oCommitmentsApprovedTele.ascx" TagPrefix="uc2" TagName="oCommitmentsApprovedTele" %>
<%@ Register Src="~/App/CommitmentControl/UserControl/oCommitmentsRejectedTele.ascx" TagPrefix="uc2" TagName="oCommitmentsRejectedTele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">

    <telerik:RadTabStrip RenderMode="Lightweight" runat="server" Skin="Silk" ID="RadTabStrip1" Align="Left" AutoPostBack="true" MultiPageID="RadMultiPage1" SelectedIndex="0">       
        <Tabs>
            <telerik:RadTab Text="Commitment Control Pending Review"></telerik:RadTab>
            <telerik:RadTab Text="Approved Commitment Control"></telerik:RadTab>
            <telerik:RadTab Text="Rejected Commitment Control"></telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>

    <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0">
        <telerik:RadPageView runat="server" ID="RadPageView1">
            <div class="contentWrapper">
                <uc2:oCommitmentPendingTele runat="server" ID="oCommitmentPendingTele" />
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView2">
            <div class="contentWrapper">
                <uc2:oCommitmentsApprovedTele runat="server" id="oCommitmentsApprovedTele" />
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView3" CssClass="RadPageView3">
            <div class="contentWrapper">
                <uc2:oCommitmentsRejectedTele runat="server" id="oCommitmentsRejectedTele" />
            </div>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</asp:Content>