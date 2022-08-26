<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PriceTracker.master" AutoEventWireup="true" CodeFile="Findings.aspx.cs" Inherits="App_Prices_Findings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">

            function RowDblClick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }

            function ShowEditForm(id, rowIndex) {
                var grid = $find("<%= grdView.ClientID %>");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                window.radopen("FindingsEntry.aspx?lRecommendId=" + id, "InputEditDialog");
                return false;
            }

            function ShowInsertForm() {
                window.radopen("FindingsEntry.aspx", "InputEditDialog");
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
                window.radopen("FindingsEntry.aspx?lRecommendId=" + eventArgs.getDataKeyValue("RECOMENDID"), "UserListDialog");
            }

            function RefreshParentPage()//function in parent page
            {
                document.location.reload();
            }

        </script>
    </telerik:RadCodeBlock>

    <p id="divMsgs" runat="server">
        <asp:Label ID="Label1" runat="server" EnableViewState="False" Font-Bold="True" ForeColor="#FF8080"></asp:Label>
        <asp:Label ID="Label2" runat="server" EnableViewState="False" Font-Bold="True" ForeColor="#00C000"></asp:Label>
    </p>

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

    <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1"></telerik:RadAjaxLoadingPanel>

    <telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" DecorationZoneID="demo" DecoratedControls="All" EnableRoundedCorners="false" />

    <div id="demo" style="width: 99%; font-size:9px">

        <telerik:RadGrid RenderMode="Lightweight" ID="grdView" AllowSorting="true" runat="server" PageSize="10" AllowAutomaticInserts="true" Font-Size="12px" HeaderStyle-ForeColor="Black"
            AllowAutomaticUpdates="true" AllowAutomaticDeletes="true" AllowPaging="True" OnItemCreated="grdView_ItemCreated" OnPreRender="grdView_PreRender"
            OnItemCommand="grdView_ItemCommand" OnItemDataBound="grdView_ItemDataBound" OnNeedDataSource="grdView_NeedDataSource" Width="100%">
            <AlternatingItemStyle BackColor="#FFFF99" />
            <ItemStyle BackColor="#FFFFFF" />
            <%--<PagerStyle Mode="NumericPages"></PagerStyle>
        <PagerStyle Mode="NextPrevNumericAndAdvanced"></PagerStyle>--%>
            <PagerStyle PageSizes="5,10,20,50,100" PagerTextFormat="{4}<strong>{5}</strong> items matching your search criteria" PageSizeLabelText="Items per page:" />

            <MasterTableView Width="100%" CommandItemDisplay="TopAndBottom" DataKeyNames="RECOMENDID" AutoGenerateColumns="false" Font-Size="10" InsertItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">
                <Columns>
                    <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="S/No">
                        <ItemTemplate>
                            <asp:Label ID="numberLabel" runat="server" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn UniqueName="TemplateEditColumn">
                        <ItemTemplate>
                            <asp:HyperLink ID="editLink" runat="server" Text="Edit"></asp:HyperLink>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridBoundColumn SortExpression="MATERIALNUM" HeaderText="Material Number" HeaderButtonType="TextButton" DataField="MATERIALNUM"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="MATERIALDESCRIPTION" HeaderText="Material Description" HeaderButtonType="TextButton" ItemStyle-Width="100px" DataField="MATERIALDESCRIPTION"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="PONUMBER" HeaderText="PO Number" HeaderButtonType="TextButton" DataField="PONUMBER"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="OLDPRICE" HeaderText="Old Price ($)" HeaderButtonType="TextButton" DataField="OLDPRICE" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="NEWPRICE" HeaderText="New Price ($)" HeaderButtonType="TextButton" DataField="NEWPRICE" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="VALDIFF" HeaderText="Value Difference ($)" HeaderButtonType="TextButton" DataField="VALDIFF" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="STOCKQTY" HeaderText="Stock Qty" HeaderButtonType="TextButton" DataField="STOCKQTY" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="VALLOSS" HeaderText="Value Loss ($)" HeaderButtonType="TextButton" ItemStyle-ForeColor="Red" DataField="VALLOSS" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="ISSUEDESCRIPTION" HeaderText="Issue Description" HeaderButtonType="TextButton" ItemStyle-Width="200px" DataField="ISSUEDESCRIPTION"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="COMMENTS" HeaderText="Comments" HeaderButtonType="TextButton" ItemStyle-Width="300px" DataField="COMMENTS"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="RECOMMENDATION" HeaderText="Recommendations" HeaderButtonType="TextButton" ItemStyle-Width="200px" DataField="RECOMMENDATION"></telerik:GridBoundColumn>

<%--                    <telerik:GridBoundColumn SortExpression="DATE_SUBMITTED" HeaderText="Date Submitted" HeaderButtonType="TextButton" DataField="DATE_SUBMITTED" DataFormatString="{0:dd/MM/yyyy}"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="STATUS" HeaderText="Status" HeaderButtonType="TextButton" DataField="STATUS"></telerik:GridBoundColumn>--%>

                    <%--<telerik:GridTemplateColumn UniqueName="TemplateStatusColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="ViewStatusLink" runat="server" Text="View Status"></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>--%>
                </Columns>

                <CommandItemTemplate>
                    <a href="#" onclick="return ShowInsertForm();">Add New Fidings and Recomendation</a>
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

                <telerik:RadWindow RenderMode="Lightweight" ID="InputEditDialog" runat="server" Title="Service/Material Cost Red Flag Fidings and Recommendations" Height="500px" Width="800px"
                    Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true" OnClientClose="RefreshParentPage">
                </telerik:RadWindow>

                <telerik:RadWindow RenderMode="Lightweight" ID="ActionDialog" runat="server" Title="Action Request" Height="320px" Width="750px"
                    Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
                </telerik:RadWindow>

            </Windows>
        </telerik:RadWindowManager>

        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server">
        </telerik:RadAjaxLoadingPanel>
    </div>
</asp:Content>
