<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oBCostSavingsApproved.ascx.cs" Inherits="App_Prices_UserControl_oBCostSavingsApproved" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="~/App/Prices/UserControl/oRequestForm.ascx" TagPrefix="app" TagName="oRequestForm" %>
<%@ Register Src="~/App/Prices/UserControl/oReviewerReport.ascx" TagPrefix="app" TagName="oReviewerReport" %>

<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">

        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }

        function ShowStatusForm(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            window.radopen("ReviewStatus.aspx?lPriceId=" + id, "StatusDialog");
            return false;
        }

        <%--function ShowEditForm(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            window.radopen("MakeRequest.aspx?lPriceId=" + id, "InputEditDialog");
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
        }--%>

        function RowDblClick(sender, eventArgs) {
            window.radopen("ReviewStatus.aspx?lPriceId=" + eventArgs.getDataKeyValue("lPriceId"), "UserListDialog");
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

<telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel>

<telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1"></telerik:RadAjaxLoadingPanel>

<telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" DecorationZoneID="demo" DecoratedControls="All" EnableRoundedCorners="false" />

<div id="demo" class="demo-container no-bg" style="width: 99%">

    <telerik:RadGrid RenderMode="Lightweight" ID="grdView" AllowSorting="true" runat="server" PageSize="20" AllowAutomaticInserts="true"
        AllowAutomaticUpdates="true" AllowAutomaticDeletes="true" AllowPaging="True" OnItemCreated="grdView_ItemCreated" OnPreRender="grdView_PreRender"
        OnItemCommand="grdView_ItemCommand" OnItemDataBound="grdView_ItemDataBound" OnNeedDataSource="grdView_NeedDataSource" Width="100%">
        <AlternatingItemStyle BackColor="#FFFF99" />
        <ItemStyle BackColor="#FFFFFF" />
        <%--<PagerStyle Mode="NumericPages"></PagerStyle>
        <PagerStyle Mode="NextPrevNumericAndAdvanced"></PagerStyle>--%>
        <PagerStyle PageSizes="5,10,20,50,100" PagerTextFormat="{4}<strong>{5}</strong> items matching your search criteria" PageSizeLabelText="Items per page:" />

        <MasterTableView Width="100%" CommandItemDisplay="None" DataKeyNames="PRICEID" AutoGenerateColumns="false" InsertItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">

            <NestedViewTemplate>
                <div style="border-bottom: 2em">
                    <asp:Panel runat="server" ID="InnerContainer" CssClass="viewWrap" Visible="true">
                        <telerik:RadTabStrip RenderMode="Lightweight" runat="server" ID="TabStip1" MultiPageID="Multipage1" SelectedIndex="0">
                            <Tabs>
                                <telerik:RadTab runat="server" Text="Red Flag Details" PageViewID="DetailsPageView"></telerik:RadTab>
                                <telerik:RadTab runat="server" Text="Attached Documents" PageViewID="DocumentsPageView"></telerik:RadTab>
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
                                                <%# Eval("DATE_SUBMITTED") %>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label15" Font-Bold="true" runat="server" Text="Saving Achieved?:"></asp:Label>
                                            </td>
                                            <td>
                                                <%# Eval("CLOSEOUTSTATUS") %>

                                            </td>
                                        </tr>
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
                                <asp:linkbutton runat="server" PRICEID='<%# DataBinder.Eval(Container.DataItem, "PRICEID") %>' ID="lnkViewAttachments" onclick="lnkViewAttachments_Click" Text="Please, click here to view attachement"></asp:linkbutton>
                                <div style="margin-bottom:4em; border-bottom:1px solid silver">
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

                <telerik:GridBoundColumn SortExpression="MATERIALDESC" HeaderText="Material Description" HeaderButtonType="TextButton" ItemStyle-Width="400px" DataField="MATERIALDESC"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="PONUMBER" HeaderText="PO Number" HeaderButtonType="TextButton" DataField="PONUMBER"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="MATERIALCODE" HeaderText="Material Code" HeaderButtonType="TextButton" DataField="MATERIALCODE"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="PRICE" HeaderText="Price ($)" HeaderButtonType="TextButton" DataField="PRICE" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="SHOULDBEPRICE" HeaderText="Should br Price ($)" HeaderButtonType="TextButton" DataField="SHOULDBEPRICE" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="XVARIANCE" HeaderText="Price Variance($)" HeaderButtonType="TextButton" DataField="XVARIANCE" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="DATE_SUBMITTED" HeaderText="Date Submitted" HeaderButtonType="TextButton" DataField="DATE_SUBMITTED" DataFormatString="{0:dd/MM/yyyy}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="CLOSEOUTSTATUS" HeaderText="Status" HeaderButtonType="TextButton" DataField="CLOSEOUTSTATUS"></telerik:GridBoundColumn>

                <%--<telerik:GridTemplateColumn UniqueName="TemplateStatusColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="ViewStatusLink" runat="server" Text="View Status"></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>--%>

            </Columns>

        </MasterTableView>

        <ClientSettings>
            <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
        </ClientSettings>

    </telerik:RadGrid>

    <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow RenderMode="Lightweight" ID="StatusDialog" runat="server" Title="View Status Details" Height="500px"
                Width="950px" Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

        </Windows>
    </telerik:RadWindowManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server">
    </telerik:RadAjaxLoadingPanel>
</div>
