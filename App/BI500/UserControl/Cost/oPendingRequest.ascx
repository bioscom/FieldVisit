<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oPendingRequest.ascx.cs" Inherits="App_BI500_UserControl_Cost_oPendingRequest" %>
<%@ Reference VirtualPath="~/App/BI500/UserControl/Cost/oRequestDetails.ascx" %>
<%@ Reference VirtualPath="~/UserControls/userFinder/Search4LocalUser.ascx" %>
<%@ Register Src="BrightIdeasFormEdt.ascx" TagName="BrightIdeasFormEdt" TagPrefix="uc2" %>

<asp:LinkButton ID="EditLinkButton" ForeColor="White" runat="server" ValidationGroup="XP"></asp:LinkButton>
<div style="margin-top:0.5em; margin-bottom:0.5em">
    <center>
        <div>
            <div style="float:left">
                <asp:Button ID="btnReminderMail" runat="server" Text="Send Reminder to all defaulting support/approval" OnClick="btnReminderMail_Click" />
            </div>
            <div style="float:right">
                <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="Export_Click" />
            </div>
        </div>
    </center>
</div>

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
            <ItemStyle Width="12px" />
        </asp:TemplateField>

        <%--<asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:LinkButton ID="UpdateLinkButton" runat="server"  OnClick="lnkUpdate_Click" ValidationGroup="Xpx"
                    CommandArgument="<%# Container.DisplayIndex %>" IDREQUEST='<%# DataBinder.Eval(Container.DataItem, "IDREQUEST") %>'>Update</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>--%>

        <asp:TemplateField HeaderText="Request No" SortExpression="REQUESTNO">
            <ItemTemplate>
                <asp:Label ID="labelWaiverNumber" runat="server"
                    Text='<%# DataBinder.Eval(Container.DataItem, "REQUESTNO") %>'></asp:Label>
            </ItemTemplate>
            <%--<ItemStyle Width="100px" />--%>
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

        <asp:TemplateField HeaderText="Stage Gate">
            <HeaderTemplate>
                Stage Gate
                <asp:DropDownList ID="ddlStageGate" runat="server" OnSelectedIndexChanged="StageGateChanged" AutoPostBack="true" AppendDataBoundItems="true">
                    <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>

            <ItemTemplate>
                <asp:DropDownList ID="ddlStageGate" runat="server" GATE='<%# DataBinder.Eval(Container.DataItem, "GATE") %>' IDREQUEST='<%# DataBinder.Eval(Container.DataItem, "IDREQUEST") %>' AutoPostBack="true" OnSelectedIndexChanged="ddlStageGate_SelectedIndexChanged"></asp:DropDownList>
            </ItemTemplate>
            <ItemStyle Width="130px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Title" SortExpression="TITLE">
            <ItemTemplate>
                <asp:Label ID="labelTitle" runat="server" ForeColor="#003366"
                    Text='<%# DataBinder.Eval(Container.DataItem, "TITLE") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="250px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Target Savings($)">
            <ItemTemplate>
                <asp:Label ID="lblTargetSavings" runat="server" Text='<%# Eval("TARGETSAVINGS","{0:N2}") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Actual Savings($)">
            <ItemTemplate>
                <asp:Label ID="lblActualSavings" runat="server" Text='<%# Eval("AMOUNTSAVED","{0:N2}") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100px" />
        </asp:TemplateField>

        <asp:TemplateField>
            <HeaderTemplate>
                Team:
                <asp:DropDownList ID="ddlTeam" runat="server" OnSelectedIndexChanged="TeamChanged" AutoPostBack="true" AppendDataBoundItems="true">
                    <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>

            <ItemTemplate>
                <asp:Label ID="labelTeam" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TEAM") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="150px" />
        </asp:TemplateField>

        <asp:TemplateField>
            <HeaderTemplate>
                Initiator:
                <asp:DropDownList ID="ddlInitiator" runat="server" OnSelectedIndexChanged="InitiatorChanged" AutoPostBack="true" AppendDataBoundItems="true">
                    <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>

            <ItemTemplate>
                <asp:Label ID="labelInitiator" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="150px" />
        </asp:TemplateField>

        <asp:TemplateField>
            <HeaderTemplate>
                Focal Point:
                <asp:DropDownList ID="ddlFocalPoint" runat="server" OnSelectedIndexChanged="FocalPointChanged" AutoPostBack="true" AppendDataBoundItems="true">
                    <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>

            <ItemTemplate>
                <asp:Label ID="labelFocalPoint" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FOCALPOINTFULLNAME") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="150px" />
        </asp:TemplateField>

        <asp:TemplateField>
            <HeaderTemplate>
                Initiative Lead:
                <asp:DropDownList ID="ddlInitiativeLead" runat="server" OnSelectedIndexChanged="InitiativeLeadChanged" AutoPostBack="true" AppendDataBoundItems="true">
                    <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>

            <ItemTemplate>
                <asp:Label ID="labelInitiativeLead" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "INITIATIVELEADFULLNAME") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="150px" />
        </asp:TemplateField>

        <asp:TemplateField>
            <HeaderTemplate>
                Workstream Owner
                <asp:DropDownList ID="ddlProjectChampion" runat="server" OnSelectedIndexChanged="ProjectChampionChanged" AutoPostBack="true" AppendDataBoundItems="true">
                    <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>

            <ItemTemplate>
                <asp:Label ID="labelChampion" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CHAMPIONFULLNAME") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="150px" />
        </asp:TemplateField>

        <asp:TemplateField>
            <HeaderTemplate>
                Workstream Sponsor
                <asp:DropDownList ID="ddlProjectSponsor" runat="server" OnSelectedIndexChanged="ProjectSponsorChanged" AutoPostBack="true" AppendDataBoundItems="true">
                    <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>

            <ItemTemplate>
                <asp:Label ID="lblSponsor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SPONSORFULLNAME") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="150px" />
        </asp:TemplateField>

        <asp:TemplateField>
            <HeaderTemplate>
                Benefit:
                <asp:DropDownList ID="ddlExpectedBenefit" runat="server" OnSelectedIndexChanged="ExpectedBenefitChanged" AutoPostBack="true" AppendDataBoundItems="true">
                    <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>

            <ItemTemplate>
                <asp:Label ID="lblAssOilProd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BENEFIT") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="150px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Status">
            <HeaderTemplate>
                Status:
                <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="StatusChanged" AutoPostBack="true" AppendDataBoundItems="true">
                    <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                </asp:DropDownList>
            </HeaderTemplate>

            <ItemTemplate>
                <asp:Label ID="labelStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="180px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Date Request" SortExpression="DATE_SUBMITTED">
            <ItemTemplate>
                <asp:Label ID="lblDateRequest" runat="server" Text='<%# Bind("DATE_SUBMITTED", "{0:dd/MM/yyyy}") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100px" />
        </asp:TemplateField>

    </Columns>
</asp:GridView>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="handover" />

<asp:Panel ID="pnlModalPanel" runat="server" Style="display: none;" CssClass="modalPopup" Width="805px">
    <asp:Panel ID="pnlDragPanel" runat="server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black">
        <div style="width: 805px">
            <div style="float: left">+</div>
            <div style="float: right">
                <asp:Button ID="closeButton" runat="server" Text="Close" ValidationGroup="xxxx" Width="100px" />
            </div>
        </div>
    </asp:Panel>
    <br />
    <div style="width: 805px">
        <uc2:BrightIdeasFormEdt ID="BrightIdeasFormEdt1" runat="server" />
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





