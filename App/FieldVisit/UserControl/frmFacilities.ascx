<%@ Control Language="C#" AutoEventWireup="true" CodeFile="frmFacilities.ascx.cs" Inherits="App_FieldVisit_UserControl_frmFacilities" %>

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

            window.radopen("MakeRequest.aspx?lRequestId=" + id, "InputEditDialog");
            return false;
        }

        function ShowInsertForm() {
            window.radopen("MakeRequest.aspx", "InputEditDialog");
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


<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
</telerik:RadAjaxLoadingPanel>
<telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" DecorationZoneID="demo" EnableRoundedCorners="false" RenderMode="Lightweight" />

<div style="width: 100%" class="demo-container size-narrow">
    <telerik:RadGrid ID="grdView" runat="server" AllowAutomaticDeletes="true" AllowAutomaticInserts="true" AllowAutomaticUpdates="true" AllowPaging="True" AllowSorting="true"
        OnItemCommand="grdView_ItemCommand" OnItemCreated="grdView_ItemCreated" OnItemDataBound="grdView_ItemDataBound" OnItemDeleted="grdView_ItemDeleted"
        OnItemInserted="grdView_ItemInserted" OnItemUpdated="grdView_ItemUpdated" OnNeedDataSource="grdView_NeedDataSource" PageSize="25" RenderMode="Lightweight">

        <AlternatingItemStyle BackColor="#FFFF99" />
        <ItemStyle BackColor="#FFFFFF" />
        <%--<PagerStyle Mode="NumericPages" />--%>
        <PagerStyle PageSizes="5,10,15,20,50" PagerTextFormat="{4}<strong>{5}</strong> matching your search criteria" PageSizeLabelText="per page:" />

        <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="None" DataKeyNames="ID_FACILITIES" InsertItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">
            <Columns>
                <telerik:GridTemplateColumn HeaderText="S/No" UniqueName="TemplateColumn">
                    <ItemTemplate>
                        <asp:Label ID="numberLabel" runat="server" Width="10px" />
                    </ItemTemplate>
                    <HeaderStyle Width="10px" />
                </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn DataField="FACILITIES" HeaderButtonType="TextButton" HeaderText="Facilities" SortExpression="FACILITIES"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DIVESTED" HeaderButtonType="TextButton" HeaderText="Divested?" SortExpression="DIVESTED"></telerik:GridBoundColumn>
                

                <telerik:GridTemplateColumn UniqueName="DeleteColumn">
                    <ItemTemplate>
                        <asp:LinkButton ID="DeleteLink" runat="server" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

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
        <telerik:RadWindow ID="UserListDialog" runat="server" Height="700px" Left="50px" Modal="true" ReloadOnShow="true" RenderMode="Lightweight" ShowContentDuringLoad="false" Title="View Details and Compare Commitments" Width="950px">
        </telerik:RadWindow>
        <telerik:RadWindow ID="InputEditDialog" runat="server" Height="700px" Left="50px" Modal="true" ReloadOnShow="true" RenderMode="Lightweight" ShowContentDuringLoad="false" Title="Insert/Edit Commitment" Width="950em">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server">
</telerik:RadAjaxLoadingPanel>
<asp:HiddenField ID="districtIdHF" runat="server" />

