<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oCatServices.ascx.cs" Inherits="App_IDD_UserControl_oCatServices" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript" language="javascript">

        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }

        function ShowEditForm(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            window.radopen("CatLead.aspx?iCategoryId=" + id, "InputEditDialog");
            wndw.SetTitle("Category Lead Management");
            wndw.set_visibleStatusbar(false);
            return false;
        }

        function ShowInsertForm() {
            window.radopen("MakeRequest.aspx", "InputEditDialog");
            return false;
        }

       <%-- function refreshGrid(arg) {
            if (!arg) {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
            }
            else {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
            }
        }--%>

        function RowDblClick(sender, eventArgs) {
            window.radopen("CatLead.aspx?iCategoryId=" + eventArgs.getDataKeyValue("CATEGORYID"), "UserListDialog");
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

<%--<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="grdView">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdView" />
                <telerik:AjaxUpdatedControl ControlID="divMsgs" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>--%>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
</telerik:RadAjaxLoadingPanel>
<telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" DecorationZoneID="demo" EnableRoundedCorners="false" RenderMode="Lightweight" />

<div style="width: 99%">
    <telerik:RadGrid ID="grdView" runat="server" AllowAutomaticDeletes="true" AllowAutomaticInserts="true" AllowAutomaticUpdates="true" AllowPaging="True" AllowSorting="true"
        OnItemCommand="grdView_ItemCommand" OnItemCreated="grdView_ItemCreated" OnItemDataBound="grdView_ItemDataBound" OnItemDeleted="grdView_ItemDeleted"
        OnItemInserted="grdView_ItemInserted" OnItemUpdated="grdView_ItemUpdated" OnNeedDataSource="grdView_NeedDataSource" PageSize="15" RenderMode="Lightweight">

        <AlternatingItemStyle BackColor="#FFFF99" />
        <ItemStyle BackColor="#FFFFFF" />
        <%--<PagerStyle Mode="NumericPages" />--%>
        <PagerStyle PageSizes="5,10,15,20" PagerTextFormat="{4}<strong>{5}</strong> matching your search criteria" PageSizeLabelText="per page:" />

        <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="None" DataKeyNames="CATEGORYID" InsertItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">
            <Columns>
                <telerik:GridTemplateColumn HeaderText="S/No" UniqueName="TemplateColumn">
                    <ItemTemplate>
                        <asp:Label ID="numberLabel" runat="server" Width="10px" />
                    </ItemTemplate>
                    <HeaderStyle Width="10px" />
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn UniqueName="TemplateEditColumn">
                    <ItemTemplate>
                        <asp:LinkButton ID="AssignCategoryLeadLink" runat="server" Text="Assign Category Lead"></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <%--<telerik:GridTemplateColumn UniqueName="TemplateViewColumn">
                <ItemTemplate>
                    <asp:HyperLink ID="RefreshLink" runat="server" Text="Refresh"></asp:HyperLink>
                </ItemTemplate>
            </telerik:GridTemplateColumn>--%>

                <telerik:GridBoundColumn DataField="CATEGORY" HeaderButtonType="TextButton" HeaderText="Categories/Services" SortExpression="CATEGORY"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FULLNAME" HeaderButtonType="TextButton" HeaderText="Category Lead" SortExpression="FULLNAME"></telerik:GridBoundColumn>

            </Columns>
        </MasterTableView>

        <ClientSettings>
            <ClientEvents OnRowDblClick="RowDblClick" />
        </ClientSettings>

    </telerik:RadGrid>
</div>

<br />

<telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true" RenderMode="Lightweight">
    <Windows>
        <telerik:RadWindow ID="UserListDialog" runat="server" Height="250px" Left="50px" Modal="true" ReloadOnShow="true" RenderMode="Lightweight" ShowContentDuringLoad="false" Title="View Details and Compare Commitments" Width="550px">
        </telerik:RadWindow>
        <telerik:RadWindow ID="InputEditDialog" runat="server" Height="250px" Left="50px" Modal="true" ReloadOnShow="true" RenderMode="Lightweight" ShowContentDuringLoad="false" Title="Assign Category Lead" Width="550px">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server">
</telerik:RadAjaxLoadingPanel>
