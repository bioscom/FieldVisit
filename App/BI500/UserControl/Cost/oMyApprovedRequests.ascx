<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oMyApprovedRequests.ascx.cs" Inherits="App_BI500_UserControl_Cost_oApprovedRequests" %>
<%@ Register Src="~/App/BI500/UserControl/Cost/Phasing.ascx" TagPrefix="app" TagName="Phasing" %>
<%@ Register Src="~/App/BI500/UserControl/Cost/oMilestones.ascx" TagPrefix="app" TagName="oMilestones" %>
<%@ Register Src="~/App/BI500/UserControl/Cost/oCadenceReporting.ascx" TagPrefix="app" TagName="oCadenceReporting" %>

<%@ Reference VirtualPath="~/App/BI500/UserControl/Cost/oRequestDetails.ascx" %>


<asp:LinkButton ID="EditLinkButton" ForeColor="White" runat="server" ValidationGroup="AP"></asp:LinkButton>
<asp:GridView ID="grdGridView" runat="server" AllowPaging="True"
    AutoGenerateColumns="False" OnLoad="grdGridView_Load"
    OnPageIndexChanging="grdGridView_PageIndexChanging"
    OnRowCommand="grdGridView_RowCommand"
    OnSelectedIndexChanged="grdGridView_SelectedIndexChanged" PageSize="15"
    Width="100%">
    <Columns>

        <asp:TemplateField>
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="...">
            <ItemTemplate>
                <asp:LinkButton ID="MilestoneLinkButton" runat="server" OnClick="lnkMilestone_Click" ValidationGroup="Apx"
                    CommandArgument="<%# Container.DisplayIndex %>" IDREQUEST='<%# DataBinder.Eval(Container.DataItem, "IDREQUEST") %>'
                    Font-Bold="True" Text='Cadence Commitments'></asp:LinkButton>
            </ItemTemplate>
            <ItemStyle Width="150px" />
        </asp:TemplateField>

        <%--<asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:LinkButton ID="UpdateLinkButton" runat="server" OnClick="lnkUpdate_Click" ValidationGroup="Xpx"
                    CommandArgument="<%# Container.DisplayIndex %>" IDREQUEST='<%# DataBinder.Eval(Container.DataItem, "IDREQUEST") %>'>Update</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>--%>

        <asp:TemplateField HeaderText="Request No" SortExpression="REQUESTNO">
            <ItemTemplate>
                <asp:Label ID="labelWaiverNumber" runat="server"
                    Text='<%# DataBinder.Eval(Container.DataItem, "REQUESTNO") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Date Request" SortExpression="DATE_SUBMITTED">
            <ItemTemplate>
                <asp:Label ID="lblDateRequest" runat="server" Text='<%# Bind("DATE_SUBMITTED", "{0:dd/MM/yyyy}") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Title" SortExpression="TITLE">
            <ItemTemplate>
                <asp:Label ID="labelTitle" runat="server" ForeColor="#003366"
                    Text='<%# DataBinder.Eval(Container.DataItem, "TITLE") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="250px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Target Savings ($)">
            <ItemTemplate>
                <asp:Label ID="lblTargetSavings" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TARGETSAVINGS") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Actual Savings ($)">
            <ItemTemplate>
                <asp:Label ID="lblActualSavings" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AMOUNTSAVED") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Team" SortExpression="TEAM">
            <ItemTemplate>
                <asp:Label ID="labelTeam" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TEAM") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="150px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Initiator" SortExpression="FULLNAME">
            <ItemTemplate>
                <asp:Label ID="labelInitiator" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'
                    USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Initiative Lead" SortExpression="INITIATIVELEADFULLNAME">
            <ItemTemplate>
                <asp:Label ID="labelInitiativeLead" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "INITIATIVELEADFULLNAME") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Workstream Owner" SortExpression="CHAMPIONFULLNAME">
            <ItemTemplate>
                <asp:Label ID="labelChampion" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CHAMPIONFULLNAME") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Workstream Sponsor" SortExpression="SPONSORFULLNAME">
            <ItemTemplate>
                <asp:Label ID="lblSponsor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SPONSORFULLNAME") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Impacted Area" SortExpression="BENEFIT">
            <ItemTemplate>
                <asp:Label ID="lblAssOilProd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BENEFIT") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Plan Completion Date" SortExpression="DATE_COMPLETION">
            <ItemTemplate>
                <asp:Label ID="labelCompletionDate" runat="server" Text='<%# Bind("DATE_COMPLETION", "{0:dd/MM/yyyy}") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Status">
            <ItemTemplate>
                <asp:Label ID="labelStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Stage Gate">
            <ItemTemplate>
                <asp:Label ID="lblGate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GATE") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="80px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:LinkButton ID="ViewStatusLinkButton" runat="server" ValidationGroup="Xpx"
                    CommandArgument="<%# Container.DisplayIndex %>"
                    CommandName="ViewStatus"
                    STATUS='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'
                    IDREQUEST='<%# DataBinder.Eval(Container.DataItem, "IDREQUEST") %>'>View Progress...</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="handover" />

<asp:Panel ID="pnlModalPanel" runat="server" Style="display: block;" CssClass="modalPopup" Width="100%">
    <asp:Panel ID="pnlDragPanel" runat="server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black">
        <div>
		Cadence
            <div style="float: left">+</div>
            <div style="float: right">
                <asp:Button ID="closeButton" runat="server" Text="X" ValidationGroup="kkk" Width="30px" />
            </div>
        </div>
    </asp:Panel>
    <br />
    <div>
        <%--<app:Phasing runat="server" ID="Phasing" />
        <app:oMilestones runat="server" ID="oMilestones" />--%>
        <app:oCadenceReporting runat="server" ID="oCadenceReporting" />
    </div>
</asp:Panel>

<ajaxToolkit:ModalPopupExtender ID="MPE"
    runat="server"
    TargetControlID="EditLinkButton"
    PopupControlID="pnlModalPanel"
    CancelControlID="closeButton"
    BackgroundCssClass="modalBackground"
    DropShadow="true"
    PopupDragHandleControlID="pnlDragPanel"
    Drag="true" />
