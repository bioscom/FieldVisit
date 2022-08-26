<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oCompleted.ascx.cs" Inherits="App_IDD_UserControl_oCompleted" %>

<%@ Reference Control="~/App/IDD/UserControl/oDueDiligenceAuditTrail.ascx" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/App/IDD/UserControl/oDueDiligenceAuditTrail.ascx" TagPrefix="app" TagName="oDueDiligenceAuditTrail" %>
<%@ Register Src="~/App/IDD/UserControl/oDetails.ascx" TagPrefix="app" TagName="oDetails" %>


<style type="text/css">
    .RadComboBox_Office2010Silver {
        color: #3b3b3b;
        font-size: 12px;
        font-family: "Segoe UI",Arial,Helvetica,sans-serif;
    }

    .RadComboBox {
        text-align: left;
        display: inline-block;
        vertical-align: middle;
        white-space: nowrap;
        *display: inline;
        *zoom: 1;
    }

    .RadComboBox_Office2010Silver {
        color: #3b3b3b;
        font-size: 12px;
        font-family: "Segoe UI",Arial,Helvetica,sans-serif;
    }

    .RadComboBox {
        text-align: left;
        display: inline-block;
        vertical-align: middle;
        white-space: nowrap;
        *display: inline;
        *zoom: 1;
    }

        .RadComboBox .rcbReadOnly .rcbInputCellLeft {
            background-position: 0 -88px;
        }

        .RadComboBox .rcbReadOnly .rcbInputCellLeft {
            background-position: 0 -88px;
        }

    .RadComboBox_Office2010Silver .rcbInputCell {
        background-image: url('mvwres://Telerik.Web.UI.Skins, Version=2016.3.1027.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Office2010Silver.Common.radFormSprite.png');
    }

    .RadComboBox .rcbInputCellLeft {
        background-position: 0 0;
    }

    .RadComboBox .rcbInputCell {
        padding-right: 4px;
        padding-left: 5px;
        width: 100%;
        height: 20px;
        line-height: 20px;
        text-align: left;
        vertical-align: middle;
    }

    .RadComboBox .rcbInputCell {
        padding: 0;
        border-width: 0;
        border-style: solid;
        background-color: transparent;
        background-repeat: no-repeat;
    }

    .RadComboBox_Office2010Silver .rcbInputCell {
        background-image: url('mvwres://Telerik.Web.UI.Skins, Version=2016.3.1027.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Office2010Silver.Common.radFormSprite.png');
    }

    .RadComboBox .rcbInputCellLeft {
        background-position: 0 0;
    }

    .RadComboBox .rcbInputCell {
        padding-right: 4px;
        padding-left: 5px;
        width: 100%;
        height: 20px;
        line-height: 20px;
        text-align: left;
        vertical-align: middle;
    }

    .RadComboBox .rcbInputCell {
        padding: 0;
        border-width: 0;
        border-style: solid;
        background-color: transparent;
        background-repeat: no-repeat;
    }

    .RadComboBox_Office2010Silver .rcbReadOnly .rcbInput {
        color: #3b3b3b;
    }

    .RadComboBox .rcbReadOnly .rcbInput {
        cursor: default;
    }

    .RadComboBox_Office2010Silver .rcbReadOnly .rcbInput {
        color: #3b3b3b;
    }

    .RadComboBox .rcbReadOnly .rcbInput {
        cursor: default;
    }

    .RadComboBox_Office2010Silver .rcbInput {
        color: #3b3b3b;
        font-size: 12px;
        font-family: "Segoe UI",Arial,Helvetica,sans-serif;
        line-height: 16px;
    }

    .RadComboBox .rcbInput {
        margin: 0;
        padding: 2px 0 1px;
        height: auto;
        width: 100%;
        border-width: 0;
        outline: 0;
        color: inherit;
        background-color: transparent;
        vertical-align: top;
        opacity: 1;
    }

    .RadComboBox_Office2010Silver .rcbInput {
        color: #3b3b3b;
        font-size: 12px;
        font-family: "Segoe UI",Arial,Helvetica,sans-serif;
        line-height: 16px;
    }

    .RadComboBox .rcbInput {
        margin: 0;
        padding: 2px 0 1px;
        height: auto;
        width: 100%;
        border-width: 0;
        outline: 0;
        color: inherit;
        background-color: transparent;
        vertical-align: top;
        opacity: 1;
    }

    .RadComboBox input {
        box-shadow: none;
        outline: 0;
        -webkit-appearance: none;
    }

    .RadComboBox input {
        box-shadow: none;
        outline: 0;
        -webkit-appearance: none;
    }

    .RadComboBox .rcbReadOnly .rcbArrowCellRight {
        background-position: -162px -176px;
    }

    .RadComboBox .rcbReadOnly .rcbArrowCellRight {
        background-position: -162px -176px;
    }

    .RadComboBox_Office2010Silver .rcbArrowCell {
        background-image: url('mvwres://Telerik.Web.UI.Skins, Version=2016.3.1027.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Office2010Silver.Common.radFormSprite.png');
    }

    .RadComboBox .rcbArrowCellRight {
        background-position: -18px -176px;
    }

    .RadComboBox .rcbArrowCell {
        width: 18px;
    }

    .RadComboBox .rcbArrowCell {
        padding: 0;
        border-width: 0;
        border-style: solid;
        background-color: transparent;
        background-repeat: no-repeat;
    }

    .RadComboBox_Office2010Silver .rcbArrowCell {
        background-image: url('mvwres://Telerik.Web.UI.Skins, Version=2016.3.1027.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Office2010Silver.Common.radFormSprite.png');
    }

    .RadComboBox .rcbArrowCellRight {
        background-position: -18px -176px;
    }

    .RadComboBox .rcbArrowCell {
        width: 18px;
    }

    .RadComboBox .rcbArrowCell {
        padding: 0;
        border-width: 0;
        border-style: solid;
        background-color: transparent;
        background-repeat: no-repeat;
    }

    .auto-style1 {
        border-width: 0;
        padding-left: 5px;
        padding-right: 4px;
        padding-top: 0;
        padding-bottom: 0;
    }

    .auto-style2 {
        border-width: 0;
        padding: 0;
    }
</style>


<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">

        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }

        function ShowEditForm(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            window.radopen("MakeRequest.aspx?lRequestId=" + id, "InputEditDialog");
            return false;
        }

        <%--function ShowActionForm(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            window.radopen("AnalystAction.aspx?lRequestId=" + id, "ActionDialog");
            return false;
        }

        <%--function ShowInsertForm() {
            window.radopen("MakeRequest.aspx", "InputEditDialog");
            return false;
        }

        function refreshGrid(arg) {
            if (!arg) {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
            }
            else {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
            }
        }--%>

        function RowDblClick(sender, eventArgs) {
            window.radopen("ViewDetails.aspx.aspx?lCommitmentId=" + eventArgs.getDataKeyValue("lCommitmentId"), "UserListDialog");
        }

        function onRequestStart(sender, args) {
            if (args.get_eventTarget().indexOf("btnDocument") >= 0)
                args.set_enableAjax(false);
        }

    </script>
</telerik:RadCodeBlock>

<p id="divMsgs" runat="server">
    <asp:Label ID="Label1" runat="server" EnableViewState="False" Font-Bold="True" ForeColor="#FF8080"></asp:Label>
    <asp:Label ID="Label2" runat="server" EnableViewState="False" Font-Bold="True" ForeColor="#00C000"></asp:Label>
</p>

<%--<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" ClientEvents-OnRequestStart="onRequestStart">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="grdView">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdView"></telerik:AjaxUpdatedControl>
                <telerik:AjaxUpdatedControl ControlID="divMsgs"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>


<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest" ClientEvents-OnRequestStart="onRequestStart">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdView" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="grdView">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdView" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>--%>

<telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel>
<%--<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>--%>

<telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" DecorationZoneID="demo" DecoratedControls="All" EnableRoundedCorners="false" />

<div id="demo" class="demo-container no-bg" style="width: 99%">
    <asp:Label runat="server" ID="lblSearch" Text="Search:"></asp:Label>
    <telerik:RadComboBox RenderMode="Lightweight" ID="ddlVendor" runat="server" Height="200" Width="430px" Font-Size="10pt"
        DropDownWidth="600" EmptyMessage="Search a Vendor..." HighlightTemplatedItems="true" AutoPostBack="true"
        EnableLoadOnDemand="true" Filter="Contains" OnItemsRequested="ddlVendor_ItemsRequested"
        Skin="Office2010Silver" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged">

        <HeaderTemplate>
            <table style="width: 550px; font-size: 9pt" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="width: 240px;">Registered Name</td>
                    <td style="width: 220px;">Email Address</td>
                    <td style="width: 90px;">Phone No</td>
                </tr>
            </table>
        </HeaderTemplate>

        <ItemTemplate>
            <table style="width: 550px; font-size: 9pt" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="width: 240px;"><%# DataBinder.Eval(Container, "Text")%></td>
                    <td style="width: 220px;"><%# DataBinder.Eval(Container, "Attributes['EMAILADDRESS']")%></td>
                    <td style="width: 90px;"><%# DataBinder.Eval(Container, "Attributes['TELEPHONENO']")%></td>
                </tr>
            </table>
        </ItemTemplate>
    </telerik:RadComboBox>
    <br /><br />
    <telerik:RadGrid RenderMode="Lightweight" ID="grdView" AllowSorting="true" runat="server" PageSize="25" AllowAutomaticInserts="true"
        AllowAutomaticUpdates="true" AllowAutomaticDeletes="true" AllowPaging="True"
        OnItemDeleted="grdView_ItemDeleted" OnItemUpdated="grdView_ItemUpdated" OnItemInserted="grdView_ItemInserted" OnItemCreated="grdView_ItemCreated" OnPreRender="grdView_PreRender"
        OnItemCommand="grdView_ItemCommand" OnItemDataBound="grdView_ItemDataBound" OnNeedDataSource="grdView_NeedDataSource" OnDetailTableDataBind="grdView_DetailTableDataBind" Width="100%">
        <AlternatingItemStyle BackColor="#FFFF99" />
        <ItemStyle BackColor="#FFFFFF" />
        <%--<PagerStyle Mode="NumericPages"></PagerStyle>--%>
        <%--<PagerStyle Mode="NextPrevNumericAndAdvanced"></PagerStyle>--%>
        <PagerStyle PageSizes="5,10,20,50,100" PagerTextFormat="{4}<strong>{5}</strong> items matching your search criteria" PageSizeLabelText="Items per page:" />

        <MasterTableView Width="100%" DataKeyNames="REQUESTID, VENDORID" AutoGenerateColumns="false" InsertItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">

            <NestedViewTemplate>
                <div style="border-bottom: 2em">
                    <asp:Panel runat="server" ID="InnerContainer" CssClass="viewWrap" Visible="true">
                        <telerik:RadTabStrip RenderMode="Lightweight" runat="server" ID="TabStip1" MultiPageID="Multipage1" SelectedIndex="0">
                            <Tabs>
                                <telerik:RadTab runat="server" Text="Request Details" PageViewID="DetailsPageView"></telerik:RadTab>
                                <telerik:RadTab runat="server" Text="Uploaded Documents" PageViewID="DocumentsPageView"></telerik:RadTab>
                                <telerik:RadTab runat="server" Text="Verification Process Audit Trail" PageViewID="VerificationPageView"></telerik:RadTab>
                            </Tabs>
                        </telerik:RadTabStrip>

                        <telerik:RadMultiPage runat="server" ID="Multipage1" SelectedIndex="0" RenderSelectedPageOnly="false">
                            <telerik:RadPageView runat="server" ID="DetailsPageView">
                                <div style="float: left; width: 70%">
                                    <app:oDetails runat="server" ID="oDetails" />
                                </div>
                            </telerik:RadPageView>

                            <telerik:RadPageView runat="server" ID="DocumentsPageView" Width="100%">
                                <telerik:RadGrid RenderMode="Lightweight" runat="server" ID="DocumentsGrid" AllowSorting="true" OnNeedDataSource="DocumentsGrid_NeedDataSource">
                                    <MasterTableView ShowHeader="true" AutoGenerateColumns="False" AllowPaging="true" DataKeyNames="DOCSID" PageSize="7">
                                        <Columns>
                                            <telerik:GridTemplateColumn HeaderText="Request Uploaded Documents">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDocument" IDDOCS='<%# DataBinder.Eval(Container.DataItem, "DOCSID") %>' runat="server" OnClick="btnDocument_Click" Text='<%# Eval("SFILENAME") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>

                                            <telerik:GridTemplateColumn UniqueName="DeleteColumn">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="deleteLink" OnClick="lnkDelete_Click" runat="server" Text="Delete"></asp:LinkButton>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>

                                            <%--<telerik:GridTemplateColumn DataKeyNames="" Name="Docs" AutoGenerateColumns="false">
                                            <alternatingitemstyle backcolor="#FFFFFF" />
                                            <itemstyle backcolor="#FFFFFF" font-size="8pt" />
                                        </telerik:GridTemplateColumn>  HierarchyLoadMode="ServerOnDemand" --%>
                                        </Columns>
                                    </MasterTableView>

                                    <ClientSettings AllowDragToGroup="true">
                                        <Scrolling AllowScroll="true" ScrollHeight="" />
                                    </ClientSettings>
                                    <PagerStyle PageButtonCount="3" Mode="NextPrevAndNumeric" ShowPagerText="false" />

                                </telerik:RadGrid>
                            </telerik:RadPageView>

                            <telerik:RadPageView runat="server" ID="VerificationPageView">
                                <app:oDueDiligenceAuditTrail runat="server" ID="oDueDiligenceAuditTrail" />
                            </telerik:RadPageView>

                        </telerik:RadMultiPage>
                    </asp:Panel>
                </div>
            </NestedViewTemplate>

            <Columns>
                <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="S/No">
                    <ItemTemplate>
                        <asp:Label ID="numberLabel" runat="server" Width="10px" Text='<%# Container.DataSetIndex + 1 %>' />
                    </ItemTemplate>
                    <HeaderStyle Width="10px" />
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn UniqueName="TemplateEditColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="editLink" runat="server" Text="Edit"></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn SortExpression="IDDNO" HeaderText="IDD No" HeaderButtonType="TextButton" DataField="IDDNO"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="CATEGORY" HeaderText="Category / Services" HeaderButtonType="TextButton" DataField="CATEGORY"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="NOR" HeaderText="Nature of Request" HeaderButtonType="TextButton" DataField="NOR"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="VENDOURCODE" HeaderText="Vendor Code" HeaderButtonType="TextButton" DataField="VENDOURCODE"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="REGISTEREDNAME" HeaderText="Vendor" HeaderButtonType="TextButton" DataField="REGISTEREDNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="TELEPHONENO" HeaderText="Phone Number" HeaderButtonType="TextButton" DataField="TELEPHONENO"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="AMOUNT" HeaderText="Contract Value($)" HeaderButtonType="TextButton" DataField="AMOUNT" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="CONTRACTHOLDERFULLNAME" HeaderText="Request initiator" HeaderButtonType="TextButton" DataField="CONTRACTHOLDERFULLNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="DATE_SUBMITTED" HeaderText="Date Submitted" HeaderButtonType="TextButton" DataField="DATE_SUBMITTED" DataFormatString="{0:dd-MMM-yyyy}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="VALIDITYPERIOD" HeaderText="Effective Date" ItemStyle-Font-Bold="true" ItemStyle-Width="90px" ItemStyle-ForeColor="Green" HeaderButtonType="TextButton" DataField="VALIDITYPERIOD" DataFormatString="{0:dd-MM-yyyy}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="VALIDTILL" HeaderText="Valid Till" ItemStyle-Font-Bold="true" ItemStyle-Width="90px" ItemStyle-ForeColor="Green" HeaderButtonType="TextButton" DataField="VALIDTILL" DataFormatString="{0:dd-MM-yyyy}"></telerik:GridBoundColumn>

            </Columns>

            <CommandItemTemplate>
                <a href="#" onclick="return ShowInsertForm();">Add New Request</a>
            </CommandItemTemplate>

        </MasterTableView>

        <ClientSettings>
            <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
        </ClientSettings>

    </telerik:RadGrid>

    <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow RenderMode="Lightweight" ID="UserListDialog" runat="server" Title="View Details and Compare Commitments" Height="500px"
                Width="950px" Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

            <telerik:RadWindow RenderMode="Lightweight" ID="InputEditDialog" runat="server" Title="Integrity Due Diligence Request" Height="500px" Width="950px"
                Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

            <telerik:RadWindow RenderMode="Lightweight" ID="ActionDialog" runat="server" Title="Action Integrity Due Diligence Request" Height="500px" Width="650px"
                Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

        </Windows>
    </telerik:RadWindowManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server">
    </telerik:RadAjaxLoadingPanel>
</div>
