<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oPendingApproval.ascx.cs" Inherits="App_IDD_UserControl_oPendingApproval" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Reference Control="~/App/IDD/UserControl/oDueDiligenceAuditTrail.ascx" %>
<%@ Register Src="~/App/IDD/UserControl/oDueDiligenceAuditTrail.ascx" TagPrefix="app" TagName="oDueDiligenceAuditTrail" %>
<%@ Register Src="~/App/IDD/UserControl/oDetails.ascx" TagPrefix="app" TagName="oDetails" %>


<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">

        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }

        function ShowInsertForm() {
            var wndw = window.radopen("MakeRequestNew.aspx", "InputDialog", 950, 500);
            wndw.SetTitle("Integrity Due Diligence");
            wndw.set_visibleStatusbar(false);
            wndw.Center();
            return false;
        }

        function ShowEditForm(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            var wndw = window.radopen("EditRequest.aspx?lRequestId=" + id, "EditDialog", 950, 500);
            wndw.SetTitle("Integrity Due Diligence");
            wndw.set_visibleStatusbar(false);
            wndw.Center();
            return false;
        }

        function ShowActionForm(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            var wndw = window.radopen("CPFocalPointAction.aspx?lRequestId=" + id, "ActionDialogVM", 700, 300);
            wndw.SetTitle("Integrity Due Diligence");
            wndw.set_visibleStatusbar(false);
            wndw.Center();
        }

        function ShowDeleteForm(id, lVendorId, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            var wndw = window.radopen("DeleteRequest.aspx?lRequestId=" + id + "&lVendorId=" + lVendorId, "DeleteDialog", 950, 500);
            wndw.SetTitle("Delete Duplicate Integrity Due Diligence Request");
            wndw.set_visibleStatusbar(false);
            wndw.Center();
            return false;
        }

        function refreshGrid(arg) {
            if (!arg) {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
            }
            else {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
            }
        }

        function RowDblClick(sender, eventArgs) {
            window.radopen("ViewDetails.aspx?lCommitmentId=" + eventArgs.getDataKeyValue("lCommitmentId"), "UserListDialog");
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
</telerik:RadAjaxManager>

<telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel>
<%--<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>--%>

<telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" DecorationZoneID="demo" DecoratedControls="All" EnableRoundedCorners="false" />

<div id="demo" class="demo-container no-bg" style="width: 99%">

    <telerik:RadGrid RenderMode="Lightweight" ID="grdView" AllowSorting="true" runat="server" PageSize="20" AllowAutomaticInserts="true"
        AllowAutomaticUpdates="true" AllowAutomaticDeletes="true" AllowPaging="True"
        OnItemDeleted="grdView_ItemDeleted" OnItemUpdated="grdView_ItemUpdated" OnItemInserted="grdView_ItemInserted" OnItemCreated="grdView_ItemCreated" OnPreRender="grdView_PreRender"
        OnItemCommand="grdView_ItemCommand" OnItemDataBound="grdView_ItemDataBound" OnNeedDataSource="grdView_NeedDataSource" OnDetailTableDataBind="grdView_DetailTableDataBind" Width="100%">
        <AlternatingItemStyle BackColor="#FFFF99" />
        <ItemStyle BackColor="#FFFFFF" />
        <%--<PagerStyle Mode="NumericPages"></PagerStyle>
        <PagerStyle Mode="NextPrevNumericAndAdvanced"></PagerStyle>--%>
        <PagerStyle PageSizes="20,50,100,200" PagerTextFormat="{4}<strong>{5}</strong> items matching your search criteria" PageSizeLabelText="Items per page:" />

        <MasterTableView Width="100%" CommandItemDisplay="None" DataKeyNames="REQUESTID, VENDORID" AutoGenerateColumns="false" InsertItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">

            <NestedViewTemplate>
                <div style="border-bottom: 2em">
                    <asp:Panel runat="server" ID="InnerContainer" CssClass="viewWrap" Visible="true">
                        <telerik:RadTabStrip RenderMode="Lightweight" runat="server" ID="TabStip1" MultiPageID="Multipage1" SelectedIndex="0">
                            <Tabs>
                                <telerik:RadTab runat="server" Text="Request Details" PageViewID="DetailsPageView"></telerik:RadTab>
                                <telerik:RadTab runat="server" Text="Uploaded Documents" PageViewID="DocumentsPageView"></telerik:RadTab>
                            </Tabs>
                        </telerik:RadTabStrip>

                        <telerik:RadMultiPage runat="server" ID="Multipage1" SelectedIndex="0" RenderSelectedPageOnly="false">
                            <telerik:RadPageView runat="server" ID="DetailsPageView">
                                <div style="width: 70%">
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
                                        </Columns>
                                    </MasterTableView>

                                    <ClientSettings AllowDragToGroup="true">
                                        <Scrolling AllowScroll="true" ScrollHeight="" />
                                    </ClientSettings>
                                    <PagerStyle PageButtonCount="3" Mode="NextPrevAndNumeric" ShowPagerText="false" />

                                </telerik:RadGrid>
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

                <telerik:GridTemplateColumn UniqueName="TemplateActionColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="actionLink" runat="server" Text="Action..."></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn SortExpression="IDDNO" HeaderText="IDD No" HeaderButtonType="TextButton" DataField="IDDNO"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="CATEGORY" HeaderText="Category / Services" HeaderButtonType="TextButton" DataField="CATEGORY"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="NOR" HeaderText="Nature of Request" HeaderButtonType="TextButton" DataField="NOR"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="CODE" HeaderText="Vendor Code" HeaderButtonType="TextButton" DataField="CODE"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="REGISTEREDNAME" HeaderText="Vendor" HeaderButtonType="TextButton" DataField="REGISTEREDNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="TELEPHONENO" HeaderText="Phone Number" HeaderButtonType="TextButton" DataField="TELEPHONENO"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="AMOUNT" HeaderText="Contract Value($)" HeaderButtonType="TextButton" DataField="AMOUNT" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="CONTRACTHOLDERFULLNAME" HeaderText="Request initiator" HeaderButtonType="TextButton" DataField="CONTRACTHOLDERFULLNAME"></telerik:GridBoundColumn>                
                <telerik:GridBoundColumn SortExpression="DATE_SUBMITTED" HeaderText="Date Submitted" HeaderButtonType="TextButton" DataField="DATE_SUBMITTED" DataFormatString="{0:dd-MMM-yyyy}"></telerik:GridBoundColumn>

                <telerik:GridTemplateColumn UniqueName="TemplateEditColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="deleteLink" runat="server" Text="Delete Duplicate"></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

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
            <telerik:RadWindow RenderMode="Lightweight" ID="InputDialog" runat="server" Title="Integrity Due Diligence Request" Height="500px" Width="950px"
                Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

            <telerik:RadWindow RenderMode="Lightweight" ID="EditDialog" runat="server" Title="Edit Integrity Due Diligence Request" Height="500px" Width="950px"
                Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

            <telerik:RadWindow RenderMode="Lightweight" ID="DeleteDialog" runat="server" Title="Delete Integrity Due Diligence Request" Height="500px" Width="950px"
                Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

            <telerik:RadWindow RenderMode="Lightweight" ID="ActionDialogVM" runat="server" Title="Assign IDD Request to an Analyst" Height="300px" Width="700px"
                Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

        </Windows>
    </telerik:RadWindowManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server">
    </telerik:RadAjaxLoadingPanel>
</div>
