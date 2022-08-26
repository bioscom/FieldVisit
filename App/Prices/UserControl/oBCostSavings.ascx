<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oBCostSavings.ascx.cs" Inherits="App_Prices_UserControl_oBCostSavings" %>
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

            window.radopen("MakeRequest.aspx?lPriceId=" + id, "InputEditDialog");
            return false;
        }

        function ShowActionForm(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            window.radopen("Action.aspx?lPriceId=" + id, "ActionDialog");
            return false;
        }

        function ShowInsertForm() {
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
        }

        function RowDblClick(sender, eventArgs) {
            window.radopen("ReviewStatus.aspx?lPriceId=" + eventArgs.getDataKeyValue("lPriceId"), "UserListDialog");
        }

        function onRequestStart(sender, args) {
            if (args.get_eventTarget().indexOf("btnDocument") >= 0)
                args.set_enableAjax(false);
        }

        function RefreshParentPage()//function in parent page
        {
            document.location.reload();
        }

        <%--function refreshGrid() {
            $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
        }--%>


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

<telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1"></telerik:RadAjaxLoadingPanel>

<telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" DecorationZoneID="demo" DecoratedControls="All" EnableRoundedCorners="false" />

<div id="demo" class="demo-container no-bg" style="width: 99%">

    <telerik:RadGrid RenderMode="Lightweight" ID="grdView" AllowSorting="true" runat="server" PageSize="20" AllowAutomaticInserts="true" Font-Size="9pt" HeaderStyle-ForeColor="Black"
        AllowAutomaticUpdates="true" AllowAutomaticDeletes="true" AllowPaging="True" OnItemCreated="grdView_ItemCreated" OnPreRender="grdView_PreRender"
        OnItemCommand="grdView_ItemCommand" OnItemDataBound="grdView_ItemDataBound" OnNeedDataSource="grdView_NeedDataSource" Width="100%">
        <AlternatingItemStyle BackColor="#FFFF99" />
        <ItemStyle BackColor="#FFFFFF" />
        <%--<PagerStyle Mode="NumericPages"></PagerStyle>
        <PagerStyle Mode="NextPrevNumericAndAdvanced"></PagerStyle>--%>
        <PagerStyle PageSizes="5,10,20,50,100" PagerTextFormat="{4}<strong>{5}</strong> items matching your search criteria" PageSizeLabelText="Items per page:" />

        <MasterTableView Width="100%" CommandItemDisplay="Top" DataKeyNames="PRICEID" AutoGenerateColumns="false" Font-Size="9pt" InsertItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">

            <NestedViewTemplate>
                <div style="border-bottom: 2em">
                    <asp:Panel runat="server" ID="InnerContainer" CssClass="viewWrap" Visible="true">
                        <telerik:RadTabStrip RenderMode="Lightweight" ID="TabStip1" runat="server" MultiPageID="Multipage1" SelectedIndex="0">
                            <Tabs>
                                <telerik:RadTab runat="server" Text="Red Flag Details" PageViewID="DetailsPageView"></telerik:RadTab>
                                <telerik:RadTab runat="server" Text="Attachments" PageViewID="DocumentsPageView"></telerik:RadTab>
                            </Tabs>
                        </telerik:RadTabStrip>

                        <telerik:RadMultiPage runat="server" ID="Multipage1" SelectedIndex="0" RenderSelectedPageOnly="false">
                            <telerik:RadPageView runat="server" ID="DetailsPageView">
                                <div style="margin-left: 0.5em; width: 70%">
                                    <table style="color: black; width: 99%; border-left: 1px solid silver; border-right: 1px solid silver; border-bottom: 5px solid silver; border-top: 5px solid silver">
                                        <tr>
                                            <td style="width: 200px">
                                                <asp:Label ID="Label2" Font-Bold="true" runat="server" Text="PO Number:"></asp:Label>
                                            </td>
                                            <td>
                                                <%# Eval("PONUMBER") %>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="Label12" Font-Bold="true" runat="server" Text="Material Description:"></asp:Label>
                                            </td>
                                            <td>
                                                <%# Eval("MATERIALDESC") %>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="Label17" Font-Bold="true" runat="server" Text="Material Code:"></asp:Label>
                                            </td>
                                            <td><%# Eval("MATERIALCODE") %></td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" Font-Bold="true" runat="server" Text="Price ($):"></asp:Label>
                                            </td>
                                            <td>
                                                <%# Eval("PRICE") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label3" Font-Bold="true" runat="server" Text="Should be price ($):"></asp:Label>
                                            </td>
                                            <td>
                                                <%# Eval("SHOULDBEPRICE") %>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label4" Font-Bold="true" runat="server" Text="Price Variance ($):"></asp:Label>
                                            </td>
                                            <td>
                                                <%# Eval("XVARIANCE") %>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:Label ID="Label6" Font-Bold="true" runat="server" Text="Price Source:"></asp:Label>
                                            </td>
                                            <td>
                                                <%# Eval("PRICESOURCE") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" Font-Bold="true" runat="server" Text="Other Information:"></asp:Label>
                                            </td>
                                            <td>
                                                <%# Eval("OTHERINFORMATION") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label13" Font-Bold="true" runat="server" Text="Submitted By:"></asp:Label>
                                            </td>
                                            <td>
                                                <%# Eval("FULLNAME") %>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label14" Font-Bold="true" runat="server" Text="Date Reported:"></asp:Label>
                                            </td>
                                            <td>
                                                <%# dateRoutine.dateStandard(DateTime.Parse(Eval("DATE_SUBMITTED").ToString())) %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <hr />
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td>
                                                <asp:Label ID="Label15" Font-Bold="true" runat="server" Text="Saving Achieved?:"></asp:Label>
                                            </td>
                                            <td>
                                                <%# ReviewStatus.status((ReviewStatus.RevStatus) Eval("CLOSEOUTSTATUS")) %>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label16" Font-Bold="true" runat="server" Text="Reviewers Report:"></asp:Label>
                                            </td>
                                            <td>
                                                <b style="color: red"><%# Eval("COMMENTS") %></b>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </telerik:RadPageView>

                            <telerik:RadPageView runat="server" ID="DocumentsPageView" Width="100%">
                                <asp:LinkButton runat="server" PRICEID='<%# DataBinder.Eval(Container.DataItem, "PRICEID") %>' ID="lnkViewAttachments" OnClick="lnkViewAttachments_Click" Text="Please, click here to view attachement"></asp:LinkButton>
                                <div style="margin-bottom: 4em; border-bottom: 1px solid silver">
                                    <iframe id="fileLoader" name="fileLoader" style="width: 99%; height: 450px" runat="server" scrolling="auto"></iframe>
                                </div>

                            </telerik:RadPageView>

                        </telerik:RadMultiPage>
                    </asp:Panel>
                </div>
            </NestedViewTemplate>

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

                <telerik:GridTemplateColumn UniqueName="TemplateActionColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="actionLink" runat="server" Text="Action..."></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn SortExpression="MATERIALDESC" HeaderText="Material Description" HeaderButtonType="TextButton" DataField="MATERIALDESC"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="PONUMBER" HeaderText="PO Number" HeaderButtonType="TextButton" DataField="PONUMBER"></telerik:GridBoundColumn>
                <%--<telerik:GridBoundColumn SortExpression="MATERIALCODE" HeaderText="Material Code" ItemStyle-Wrap="true" HeaderButtonType="TextButton" DataField="MATERIALCODE"></telerik:GridBoundColumn>--%>
                <telerik:GridBoundColumn SortExpression="PRICE" HeaderText="Price ($)" HeaderButtonType="TextButton" DataField="PRICE" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="SHOULDBEPRICE" HeaderText="Should br Price ($)" HeaderButtonType="TextButton" DataField="SHOULDBEPRICE" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="XVARIANCE" HeaderText="Price Variance($)" HeaderButtonType="TextButton" DataField="XVARIANCE" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="DATE_SUBMITTED" HeaderText="Date Submitted" HeaderButtonType="TextButton" DataField="DATE_SUBMITTED" DataFormatString="{0:dd/MM/yyyy}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="STATUS" HeaderText="Status" HeaderButtonType="TextButton" DataField="STATUS"></telerik:GridBoundColumn>

                <%--<telerik:GridTemplateColumn UniqueName="TemplateStatusColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="ViewStatusLink" runat="server" Text="View Status"></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>--%>
            </Columns>

            <CommandItemTemplate>
                <a href="#" onclick="return ShowInsertForm();">Add New Cost Red Flag</a>
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

            <telerik:RadWindow RenderMode="Lightweight" ID="InputEditDialog" runat="server" Title="Service/Material Cost Red Flag Form" Height="500px" Width="800px"
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