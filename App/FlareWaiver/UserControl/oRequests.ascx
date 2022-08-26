<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oRequests.ascx.cs" Inherits="UserControl_oRequests" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Panel ID="pnlRequestStatus" runat="server">
    <div style="margin-bottom: 0.5em">
        <div style="float: left">
            <asp:CheckBox ID="allCkb" runat="server" OnCheckedChanged="allCkb_CheckedChanged" Text="Select All" AutoPostBack="True" />
        </div>
        <div style="float: left; margin-left: 1.5em">
            <asp:DropDownList ID="ddlDeligate" runat="server" Width="350px">
            </asp:DropDownList>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlDeligate" ErrorMessage="Please, select a deligate to whom Flare Waiver Requests are to be handed over" Type="Integer" ValidationGroup="handover" ValueToCompare="-1" Operator="NotEqual">*</asp:CompareValidator>
        </div>
        <div style="float: left">
            <asp:Button ID="handOverButton" runat="server" OnClick="handOverButton_Click" Text="Handover Requests" ValidationGroup="handover" />
        </div>
    </div>
</asp:Panel>

<br />
<br />

<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">

        <%--function ShowActionForm(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            var wndw = window.radopen("FlareApprovalProc.aspx?RequestId=" + id, "ActionDialog", 750, 500);
            wndw.set_visibleStatusbar(false);
            wndw.Center();
            return false;
        }--%>

        function ShowComment(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            var wndw = window.radopen("ViewComments.aspx?RequestId=" + id, "CommentDialog", 900, 500);
            wndw.set_visibleStatusbar(false);
            wndw.Center();
            return false;
        }

        function ShowEditForm(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            var wndw = window.radopen("FlareWaiverRequestEdt.aspx?RequestId=" + id, "EditDialog", 1200, 600);
            wndw.set_visibleStatusbar(false);
            wndw.Center();
            return false;
        }

        function ShowReport(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            var wndw = window.radopen("../FlareWaiver/Reports/Default.aspx?RequestId=" + id, "ReportDialog", 900, 500);
            wndw.set_visibleStatusbar(false);
            wndw.Center();
            return false;
        }

        function ShowRerouteForm(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

             var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
             grid.get_masterTableView().selectItem(rowControl, true);

             var wndw = window.radopen("FlareRequestRouter.aspx?RequestId=" + id, "RerouteDialog", 900, 500);
             wndw.set_visibleStatusbar(false);
             wndw.Center();
             return false;
         }

        function ShowAuditTrailForm(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            var wndw = window.radopen("FlareRequestApprovalAudit.aspx?RequestId=" + id, "AuditTrailDialog", 900, 500);
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

        (function () {
            var demo = window.demo = {};
            demo.onRequestStart = function (sender, args) {
                if (args.get_eventTarget().indexOf("Button") >= 0) {
                    args.set_enableAjax(false);
                }
            }
        })();

    </script>
</telerik:RadCodeBlock>

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
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

<div style="float: left; width: 100%">

    <telerik:RadGrid RenderMode="Lightweight" ID="grdView" AllowSorting="true" runat="server" AllowPaging="True" PagerStyle-AlwaysVisible="true" PageSize="20" Font-Size="11px" EnableHeaderContextFilterMenu="true"  
       OnItemCreated="grdView_ItemCreated" OnItemCommand="grdView_ItemCommand" OnItemDataBound="grdView_ItemDataBound" OnNeedDataSource="grdView_NeedDataSource" 
        OnDetailTableDataBind="grdView_DetailTableDataBind" Width="100%">

        <AlternatingItemStyle BackColor="#FFFF99" />
        <ItemStyle BackColor="#FFFFFF" />

        <PagerStyle PageSizes="20,50,100" PagerTextFormat="{4}<strong>{5}</strong> items matching your search criteria" PageSizeLabelText="Items per page:" />

        <MasterTableView Width="100%" CommandItemDisplay="Top" DataKeyNames="IDREQUEST" AutoGenerateColumns="false">
            <CommandItemSettings ShowExportToWordButton="true" ShowExportToCsvButton="true" ShowAddNewRecordButton="false" ShowRefreshButton="false" />

            <Columns>
                <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                    <ItemTemplate>
                        <asp:Label ID="numberLabel" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn UniqueName="ActionColumn">
                    <ItemTemplate>
                        <asp:LinkButton ID="ActionLink" runat="server" OnClick="ActionLink_Click" ToolTip="Approve/Support Flare Waiver Request">Action</asp:LinkButton>
                        <%--<asp:HyperLink ID="ActionLink" runat="server" Text="Action" ToolTip="Approve/Support Flare Waiver Request"></asp:HyperLink>--%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn UniqueName="CancelColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="CancelLink" runat="server" OnClientClick="return confirm('Are you sure you want to cancel this Request?')">
                            <asp:Image ID="ImgCancel" runat="server" ImageUrl="~/Images/Cancel.png" ToolTip="Cancel Request" />
                        </asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn UniqueName="deleteColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="deleteLink" runat="server" OnClientClick="return confirm('Are you sure you want to delete this Request?')" ToolTip="Delete this Request">
                            <asp:Image ID="ImgDelete" runat="server" ImageUrl="~/Images/Delete.GIF" ToolTip="Delete Request" />
                        </asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn ItemStyle-Width="90px" ItemStyle-ForeColor="#003366" ItemStyle-Font-Bold="true" SortExpression="REQUESTNO" HeaderText="Waiver No" HeaderButtonType="TextButton" DataField="REQUESTNO" AutoPostBackOnFilter="true" CurrentFilterFunction="StartsWith"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn ItemStyle-Width="80px" FilterCheckListEnableLoadOnDemand="true" SortExpression="DATE_CREATED" HeaderText="Request Date" HeaderButtonType="TextButton" DataField="DATE_CREATED" DataFormatString="{0:dd-MMM-yyyy}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn ItemStyle-Width="300px" SortExpression="REASON" HeaderText="Reason for Flaring" HeaderButtonType="TextButton" DataField="REASON"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterCheckListEnableLoadOnDemand="true" SortExpression="CATEGORY" HeaderText="Category" HeaderButtonType="TextButton" DataField="CATEGORY"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterCheckListEnableLoadOnDemand="true" SortExpression="FLAREVOL" HeaderText="Flare Vol.(mmscfd)" HeaderButtonType="TextButton" DataField="FLAREVOL"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterCheckListEnableLoadOnDemand="true" SortExpression="OILPROD" HeaderText="Ass. Oil Prod.(mbopd)" HeaderButtonType="TextButton" DataField="OILPROD"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn ItemStyle-Width="80px" FilterCheckListEnableLoadOnDemand="true" SortExpression="START_DATE" HeaderText="Start Date/Time" HeaderButtonType="TextButton" DataField="START_DATE" DataFormatString="{0:dd-MMM-yyyy}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn ItemStyle-Width="80px" FilterCheckListEnableLoadOnDemand="true" SortExpression="END_DATE" HeaderText="End Date/Time" HeaderButtonType="TextButton" DataField="END_DATE" DataFormatString="{0:dd-MMM-yyyy}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn ItemStyle-Width="150px" UniqueName="status" SortExpression="STATUS" HeaderText="Status" HeaderButtonType="TextButton" DataField="STATUS" AllowFiltering="false"></telerik:GridBoundColumn>
                
                <telerik:GridTemplateColumn HeaderText="Facilities" UniqueName="FacilitiesColumn">
                    <ItemTemplate>
                        <asp:Label ID="lblFacilities" runat="server"></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                
                
                
                <%--<telerik:GridBoundColumn FilterCheckListEnableLoadOnDemand="true" SortExpression="AUTHORISERNAME" HeaderText="Functional Authorizer" HeaderButtonType="TextButton" DataField="AUTHORISERNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterCheckListEnableLoadOnDemand="true" SortExpression="PLANNERNAME" HeaderText="IAP Planner" HeaderButtonType="TextButton" DataField="PLANNERNAME"></telerik:GridBoundColumn>--%>

                <telerik:GridTemplateColumn UniqueName="ViewCommentColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="ViewCommentLink" runat="server" Text="View Comment"></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn UniqueName="EditColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="editLink" runat="server" Text="Edit"></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn UniqueName="ViewReportColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="reportLink" runat="server" Text="View Report"></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn UniqueName="ReRouteColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="ReRouteLink" runat="server" Text="Re-Route"></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn UniqueName="AuditTrailColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="AuditTrailLink" runat="server" Text="Audit Trail"></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>

        </MasterTableView>
    </telerik:RadGrid>

    <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow RenderMode="Lightweight" ID="InputDialog" runat="server" Title="Request Form"
                Height="500px" Width="1100px" Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

            <telerik:RadWindow RenderMode="Lightweight" ID="EditDialog" runat="server" Title="Edit Request"
                Height="500px" Width="1100px" Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

            <telerik:RadWindow RenderMode="Lightweight" ID="CommentDialog" runat="server" Title="View Comments"
                Height="500px" Width="900px" Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

            <telerik:RadWindow RenderMode="Lightweight" ID="ReportDialog" runat="server" Title="Flare Waiver Generated Report"
                Height="500px" Width="900px" Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

            <telerik:RadWindow RenderMode="Lightweight" ID="ActionDialog" runat="server" Title="Support Request"
                Height="500px" Width="900px" Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

            <telerik:RadWindow RenderMode="Lightweight" ID="ApproverActionDialog" runat="server" Title="Support Request"
                Height="500px" Width="900px" Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

            <telerik:RadWindow RenderMode="Lightweight" ID="AuditTrailDialog" runat="server" Title="Audit Trail Report"
                Height="500px" Width="900px" Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>   

            <telerik:RadWindow RenderMode="Lightweight" ID="RerouteDialog" runat="server" Title="Reroute Request"
                Height="500px" Width="900px" Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

        </Windows>
    </telerik:RadWindowManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server">
    </telerik:RadAjaxLoadingPanel>
</div>

<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="handover" />
