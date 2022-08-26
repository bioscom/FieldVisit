<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oRequestsIApproved.ascx.cs" Inherits="App_BI500_UserControl_Cost_oRequestsIApproved" %>

<%@ Reference VirtualPath="~/App/BI500/UserControl/Cost/oRequestDetails.ascx" %>
<%@ Register src="_Reroute.ascx" tagname="_Reroute" tagprefix="uc2" %>

<asp:LinkButton ID="EditLinkButton" ForeColor="White" runat="server" ValidationGroup="XP"></asp:LinkButton>

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
                <asp:Label ID="labelInitiator" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Focal Point" SortExpression="FOCALPOINTFULLNAME">
            <ItemTemplate>
                <asp:Label ID="labelFocalPoint" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FOCALPOINTFULLNAME") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Project Champion" SortExpression="CHAMPIONFULLNAME">
            <ItemTemplate>
                <asp:Label ID="labelChampion" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CHAMPIONFULLNAME") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Project Sponsor" SortExpression="SPONSORFULLNAME">
            <ItemTemplate>
                <asp:Label ID="lblSponsor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SPONSORFULLNAME") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Expected Benefit" SortExpression="BENEFIT">
            <ItemTemplate>
                <asp:Label ID="lblAssOilProd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BENEFIT") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Status">
            <ItemTemplate>
                <asp:Label ID="labelStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="180px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Stage Gate">
            <ItemTemplate>
                <asp:Label ID="lblGate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GATE") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="80px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:LinkButton ID="RerouteLinkButton" runat="server" ValidationGroup="Xpx"
                    CommandArgument="<%# Container.DisplayIndex %>" OnClick="lnkReroute_Click" 
                    IDREQUEST='<%# DataBinder.Eval(Container.DataItem, "IDREQUEST") %>'>Re-route...</asp:LinkButton>
            </ItemTemplate>
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

<asp:Panel ID="pnlModalPanel" runat="server" Style="display:none;" CssClass="modalPopup" Width="780px">
    <asp:Panel ID="pnlDragPanel" runat="server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black">
        <div style="width: 770px">
            <div style="float: left">+</div>
            <div style="float: right">
                <asp:Button ID="closeButton" runat="server" Text="x" ValidationGroup="xxxx" />
            </div>
            &nbsp;<b>Reroute Workstream Flow</b></div>
    </asp:Panel>
    <div style="width: 780px">
        <uc2:_Reroute ID="_Reroute1" runat="server" />
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