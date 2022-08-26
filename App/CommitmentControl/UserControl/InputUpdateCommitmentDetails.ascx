<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InputUpdateCommitmentDetails.ascx.cs" Inherits="App_BONGACCP_UserControl_InputUpdateCommitmentDetails" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

    <script type="text/javascript">

        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }

        function ShowInsertForm() {
            var wndw = window.radopen("CommitmentDetails.aspx", "InputDialog", 600, 300);
            wndw.SetTitle("Activity Detailed Description");
            wndw.set_visibleStatusbar(true);
            wndw.Center();
        }

        function ShowEditForm(Id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            var wndw = window.radopen("CommitmentDetails.aspx?Id=" + Id, "EditDialog", 600, 300);
            wndw.SetTitle("Activity Detailed Description");
            wndw.set_visibleStatusbar(false);
            wndw.Center();
        }

        function RowDblClick(sender, eventArgs) {
            var wndw = window.radopen("CommitmentDetails.aspx?Id=" + eventArgs.getDataKeyValue("DETAILSID"), "CommentDialog");
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


<h4>Detailed Description of Activity (Include quantity/duration as required)</h4>


<telerik:RadGrid RenderMode="Lightweight" ID="grdView" runat="server" AutoGenerateColumns="false" PageSize="15" Font-Size="12px" 
    OnNeedDataSource="grdView_NeedDataSource" OnUpdateCommand="grdView_UpdateCommand" 
    OnItemCreated="grdView_ItemCreated" OnInsertCommand="grdView_InsertCommand"
    OnItemDataBound="grdView_ItemDataBound" OnDeleteCommand="grdView_DeleteCommand" Width="100%">

    <AlternatingItemStyle BackColor="#FFFF99" />
    <ItemStyle BackColor="#FFFFFF" />

    <PagerStyle PageSizes="5,10,20" PagerTextFormat="{4}<strong>{5}</strong> items matching your search criteria" PageSizeLabelText="Items per page:" />

    <MasterTableView DataKeyNames="DETAILSID" CommandItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnCurrentPage" Width="100%" >
        <Columns>
            <%--AutoGenerateColumns="false"--%>
            <telerik:GridEditCommandColumn />

            <telerik:GridTemplateColumn HeaderText="S/No" UniqueName="TemplateColumn">
                <ItemTemplate>
                    <asp:Label ID="numberLabel" runat="server" Width="10px" />
                </ItemTemplate>
                <HeaderStyle Width="10px" />
            </telerik:GridTemplateColumn>

            <telerik:GridBoundColumn SortExpression="DESCRIPTION" HeaderText="Activity" HeaderButtonType="TextButton" DataField="DESCRIPTION" ItemStyle-Width="500px"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="Qty" SortExpression="QUANTITY" HeaderText="Qty" HeaderButtonType="TextButton" DataField="QUANTITY" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="Rate" SortExpression="RATE" HeaderText="Rate($)" HeaderButtonType="TextButton" DataField="RATE" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>

            <telerik:GridTemplateColumn UniqueName="AmountColumn" HeaderText="Amount ($)">
                <ItemTemplate>
                    <div style="text-align: right">
                        <asp:Label ID="lblAmount" runat="server" Text=''></asp:Label>
                    </div>
                </ItemTemplate>
            </telerik:GridTemplateColumn>

            <telerik:GridButtonColumn ConfirmText="Delete this activity?" ConfirmDialogType="RadWindow" ConfirmTitle="Delete" ButtonType="FontIconButton" CommandName="Delete" />
        </Columns>

    </MasterTableView>

    <ClientSettings>
        <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
    </ClientSettings>

</telerik:RadGrid>

<telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true">
    <Windows>
        <telerik:RadWindow RenderMode="Lightweight" ID="InputDialog" runat="server" Title="Operations Narratives"
            Height="500px" Width="1100px" Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
        </telerik:RadWindow>

        <telerik:RadWindow RenderMode="Lightweight" ID="EditDialog" runat="server" Title="Edit Operations Narratives"
            Height="500px" Width="1100px" Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
        </telerik:RadWindow>

    </Windows>
</telerik:RadWindowManager>


<telerik:RadInputManager RenderMode="Lightweight" runat="server" ID="RadInputManager1" Enabled="true">
    <telerik:TextBoxSetting BehaviorID="TextBoxSetting1"></telerik:TextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="NumericTextBoxRate" Type="Currency" AllowRounding="true" DecimalDigits="2"></telerik:NumericTextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="NumericTextBoxQuantity" Type="Number" AllowRounding="true" DecimalDigits="0" MinValue="0"></telerik:NumericTextBoxSetting>
</telerik:RadInputManager>

<telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager2" runat="server" />


<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server">
</telerik:RadAjaxLoadingPanel>
<asp:HiddenField ID="CommitmentIdHF" runat="server" />