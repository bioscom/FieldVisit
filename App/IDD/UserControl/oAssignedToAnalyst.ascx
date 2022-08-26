<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oAssignedToAnalyst.ascx.cs" Inherits="App_IDD_UserControl_oAssignedToAnalyst" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<%@ Reference Control="~/App/IDD/UserControl/oDueDiligenceAuditTrail.ascx" %>--%>
<%@ Register Src="~/App/IDD/UserControl/oDueDiligenceAuditTrailApproval.ascx" TagPrefix="app" TagName="oDueDiligenceAuditTrailApproval" %>
<%@ Register Src="~/App/IDD/UserControl/oDetails.ascx" TagPrefix="app" TagName="oDetails" %>
<%@ Register Src="~/App/IDD/UserControl/oVMIDDApproval.ascx" TagPrefix="app" TagName="oVMIDDApproval" %>




<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript" language="javascript">

        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }

        function ShowApprovalForm(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            window.radopen("VMIDDApproval.aspx?lRequestId=" + id, "ApprovalDialog");
            wndw.SetTitle("VM Integrity Due Diligence approval");
            wndw.set_visibleStatusbar(false);
            return false;
        }

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
</telerik:RadAjaxManager>--%>

<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>





<telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" DecorationZoneID="demo" DecoratedControls="All" EnableRoundedCorners="false" />

<div id="demo" class="demo-container no-bg" style="width: 100%">

    <div style="width: 100%">
        <div style="float: left">
        </div>
        <div style="float: right">
            Search for Vendor: 
        <telerik:RadComboBox ID="ddlVendor" runat="server" AutoPostBack="True" ValidationGroup="vali" EmptyMessage="Enter Vendor name..." Skin="Office2010Silver" Width="400px" DropDownWidth="600" EnableLoadOnDemand="true" Filter="Contains" Font-Size="10pt" Height="200" HighlightTemplatedItems="true" OnItemsRequested="ddlVendor_ItemsRequested" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged" RenderMode="Lightweight">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" style="width: 550px; font-size: 9pt">
                    <tr>
                        <td style="width: 240px;">Registered Name</td>
                        <td style="width: 220px;">Email Address</td>
                        <td style="width: 90px;">Phone No</td>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" style="width: 550px; font-size: 9pt">
                    <tr>
                        <td style="width: 240px;"><%# DataBinder.Eval(Container, "Text")%></td>
                        <td style="width: 220px;"><%# DataBinder.Eval(Container, "Attributes['EMAILADDRESS']")%></td>
                        <td style="width: 90px;"><%# DataBinder.Eval(Container, "Attributes['TELEPHONENO']")%></td>
                    </tr>
                </table>
            </ItemTemplate>
        </telerik:RadComboBox>
        </div>
    </div>

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
                                <telerik:RadTab runat="server" Text="Verification Process Audit Trail" PageViewID="VerificationPageView"></telerik:RadTab>
                                <telerik:RadTab runat="server" Text="Request Details" PageViewID="DetailsPageView"></telerik:RadTab>
                                <telerik:RadTab runat="server" Text="Uploaded Documents" PageViewID="DocumentsPageView"></telerik:RadTab>
                            </Tabs>
                        </telerik:RadTabStrip>

                        <telerik:RadMultiPage runat="server" ID="Multipage1" SelectedIndex="0" RenderSelectedPageOnly="false">

                            <telerik:RadPageView runat="server" ID="VerificationPageView">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="vertical-align: top">
                                            <app:oDueDiligenceAuditTrailApproval runat="server" ID="oDueDiligenceAuditTrailApproval" />
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPageView>

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

                <%--<telerik:GridTemplateColumn UniqueName="TemplateEditColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="approveLink" runat="server" Text="Approve..."></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>--%>

                <telerik:GridBoundColumn SortExpression="IDDNO" HeaderText="IDD No" HeaderButtonType="TextButton" DataField="IDDNO"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="CATEGORY" HeaderText="Category / Services" HeaderButtonType="TextButton" DataField="CATEGORY"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="NOR" HeaderText="Nature of Request" HeaderButtonType="TextButton" DataField="NOR"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="AMOUNT" HeaderText="Contract Value($)" HeaderButtonType="TextButton" DataField="AMOUNT" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="CODE" HeaderText="Vendor Code" HeaderButtonType="TextButton" DataField="CODE"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="REGISTEREDNAME" HeaderText="Vendor" HeaderButtonType="TextButton" DataField="REGISTEREDNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="CONTRACTHOLDERFULLNAME" HeaderText="Request initiator" HeaderButtonType="TextButton" DataField="CONTRACTHOLDERFULLNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="FOCALPOINTFULLNAME" HeaderText="CP IDD Focal Point" HeaderButtonType="TextButton" DataField="FOCALPOINTFULLNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="ANALYSTFULLNAME" HeaderText="IDD Analyst" HeaderButtonType="TextButton" DataField="ANALYSTFULLNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="STAGE" HeaderText="Status" UniqueName="Remarks" ItemStyle-Width="140px" HeaderButtonType="TextButton" DataField="STAGE"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="DATE_ASSIGNED" HeaderText="Date Assigned" HeaderButtonType="TextButton" DataField="DATE_ASSIGNED" DataFormatString="{0:dd-MMM-yyyy}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="DATESCREENED" HeaderText="Effective Date" HeaderButtonType="TextButton" DataField="DATESCREENED" DataFormatString="{0:dd-MMM-yyyy}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="VALIDTILL" HeaderText="Valid Till" HeaderButtonType="TextButton" DataField="VALIDTILL" DataFormatString="{0:dd-MMM-yyyy}"></telerik:GridBoundColumn>
            </Columns>

            <%--<CommandItemTemplate>
                <a href="#" onclick="return ShowInsertForm();">Add New Request</a>
            </CommandItemTemplate>--%>
        </MasterTableView>

        <ClientSettings>
            <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
        </ClientSettings>

    </telerik:RadGrid>

    <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow RenderMode="Lightweight" ID="UserListDialog" runat="server" Title="View Details and Compare Commitments" Height="500px" Width="950px"
                Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

            <telerik:RadWindow RenderMode="Lightweight" ID="ApprovalDialog" runat="server" Title="Approve Due Diligence Request" Height="500px" Width="650px"
                Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server">
    </telerik:RadAjaxLoadingPanel>
</div>
