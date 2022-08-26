<%@ Page Title="" Language="C#" MasterPageFile="~/IDD.master" AutoEventWireup="true" CodeFile="Vendors.aspx.cs" Inherits="App_IDD_Vendors" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/App/IDD/UserControl/oHistoricalData.ascx" TagPrefix="app" TagName="oHistoricalData" %>
<%@ Register Src="~/App/IDD/UserControl/oDueDiligenceAuditTrailApproval.ascx" TagPrefix="app" TagName="oDueDiligenceAuditTrailApproval" %>
<%@ Register Src="~/App/IDD/UserControl/oDetails.ascx" TagPrefix="app" TagName="oDetails" %>
<%@ Register Src="~/App/IDD/UserControl/oVMIDDApproval.ascx" TagPrefix="app" TagName="oVMIDDApproval" %>


<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="HistoryContentPlaceHolder" Runat="Server">
    <app:oHistoricalData runat="server" ID="oHistoricalData" />
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">

    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

        <script type="text/javascript">
            var xmlHttpPanel = null;

            Sys.Application.add_load(function () {
                xmlHttpPanel = $find("<%=XmlHttpPanelWCF.ClientID %>");
            });


            function RowDblClick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }

            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
                }
            }


            function ShowActionForm(id, vId, rowIndex) {
                var grid = $find("<%= grdView.ClientID %>");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                var wndw = window.radopen("VSRManagent.aspx?lRequestId=" + id + "&lVendorId=" + vId, "ApprovalDialog", 750, 550);
                wndw.SetTitle("VSR Manager");
                wndw.set_visibleStatusbar(false);
                wndw.Center();
                return false;
            }

            function RowDblClick(sender, eventArgs) {
                window.radopen("ViewDetails.aspx?lCommitmentId=" + eventArgs.getDataKeyValue("lCommitmentId"), "UserListDialog");
            }

            function onRequestStart(sender, args) {
                if (args.get_eventTarget().indexOf("btnDocument") >= 0)
                    args.set_enableAjax(false);
            }

            (function (global, undefined) {
                var chart = null;

                function clearConsole(sender, args) {
                    clearLog();
                }

                function onChartLoad(sender, args) {
                    chart = sender;
                }

                function setRandomDataSource() {
                    //Parse the current datasource to an array of JSON objects and store it a variable 
                    var currentDataSource = $telerik.$.parseJSON(chart.get_dataSourceJSON());

                    //Define JavaScript random generator function
                    var getRandomNumber = function (min, max) {
                        return Math.floor(Math.random() * (max - min + 1)) + min;
                    }

                    var getRandomBoolean = function () {
                        return Math.random(0, 1) > 0.5;
                    }

                    //Iterate through YValues and Exploded values of the Items and generate random ones
                    for (var i = 0; i < currentDataSource.length; i++) {
                        currentDataSource[i].Barrels = getRandomNumber(10000, 90000);
                        currentDataSource[i].IsExploded = getRandomBoolean();
                    }

                    //Set the new datasource to the RadHtmlChart
                    chart.set_dataSource(currentDataSource);

                    //Repaint the RadHtmlChart to apply the changes
                    chart.repaint();
                    logEvent("<strong>Randomly generated data:</strong>" + chart.get_dataSourceJSON());
                }

                function getDataFromService(sender, args) {
                    xmlHttpPanel.set_value();
                }

                function setDataFromService(sender, args) {
                    //Get the returned data
                    var newData = args.get_content();

                    //Set the new datasource to the RadHtmlChart
                    chart.set_dataSource(newData);

                    //Repaint the RadHtmlChart
                    chart.repaint();

                    //Avoid raising the OnClientResponseEnded client-side event
                    //avoid setting the received data as content for the RadXmlHttpPanel
                    args.set_cancel(true);

                    logEvent("<strong>Data from the WCF service:</strong>" + newData);
                }


                global.onChartLoad = onChartLoad;
                global.clearConsole = clearConsole;
                global.setRandomDataSource = setRandomDataSource;
                global.getDataFromService = getDataFromService;
                global.setDataFromService = setDataFromService

            })(window);
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

    <div style="margin-left: 1.0em; margin-right: 1.0em; border: 1px solid silver">
        <h2 style="color: black">Vendor Status Report</h2>

        <div>
            <div style="margin-left: 2.5em">
                <telerik:RadXmlHttpPanel runat="server" ID="XmlHttpPanelWCF" WcfRequestMethod="GET" OnClientResponseEnding="setDataFromService " WcfServicePath="HtmlChartWcfService.svc" WcfServiceMethod="getJsonData">
                </telerik:RadXmlHttpPanel>

                <telerik:RadHtmlChart ID="RadHtmlChart1" runat="server">
                    <ClientEvents OnLoad="onChartLoad" />
                    <ChartTitle Text="Summary of SCiN Vendors Status">
                        <Appearance Align="Right" Position="Top">
                            <TextStyle Bold="true" Padding="15px" />
                        </Appearance>
                    </ChartTitle>

                    <PlotArea>
                        <Series>
                            <telerik:PieSeries DataFieldY="Barrels" ColorField="Color" ExplodeField="IsExploded" NameField="Country">
                                <LabelsAppearance DataFormatString="{N}"></LabelsAppearance>
                                <TooltipsAppearance Color="White" />
                            </telerik:PieSeries>
                        </Series>
                    </PlotArea>
                    <Legend>
                        <Appearance Position="Right" Width="300">
                        </Appearance>
                    </Legend>
                </telerik:RadHtmlChart>
            </div>

            <div style="color: black">
                <table style="width:100%">
                    <tr>
                        <td>
                            <div style="float: left">
                                <asp:Label runat="server" ID="lblSearch" Text="Search:"></asp:Label>
                                <telerik:RadComboBox RenderMode="Lightweight" ID="ddlVendor" runat="server" Height="200" Width="430px" Font-Size="10pt"
                                    DropDownWidth="600" EmptyMessage="Search a Vendor..." AutoPostBack="true"
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
                            </div>

                        </td>
                        <td>
                            <div>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Excel_XLSX.png" OnClick="ImageButton_Click" AlternateText="Html" ToolTip="Export to Excel" />
                            </div>
                        </td>
                        <td>
                            <div style="float: right">
                                <table>
                                    <tr>
                                        <td>Filter by Status: </td>
                                        <td>
                                            <telerik:RadComboBox ID="ddlStatusFilter" runat="server" EmptyMessage="Select Status..." AutoPostBack="true" OnSelectedIndexChanged="ddlStatusFilter_SelectedIndexChanged"></telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>

            <telerik:RadGrid ID="grdView" runat="server" AllowAutomaticDeletes="true" AllowAutomaticInserts="true" AllowAutomaticUpdates="true" AllowPaging="True" AllowSorting="true"
                OnItemCommand="grdView_ItemCommand" OnItemCreated="grdView_ItemCreated" OnItemDataBound="grdView_ItemDataBound" OnItemDeleted="grdView_ItemDeleted"
                OnItemInserted="grdView_ItemInserted" OnItemUpdated="grdView_ItemUpdated" OnNeedDataSource="grdView_NeedDataSource" PageSize="50" RenderMode="Lightweight">

                <AlternatingItemStyle BackColor="#FFFF99" />
                <ItemStyle BackColor="#FFFFFF" />

                <PagerStyle PageSizes="50,100,200" PagerTextFormat="{4}<strong>{5}</strong> matching your search criteria" PageSizeLabelText="per page:" />

                <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="None" DataKeyNames="REQUESTID, VENDORID" InsertItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">

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
                        <telerik:GridTemplateColumn HeaderText="S/No" UniqueName="TemplateColumn">
                            <ItemTemplate>
                                <asp:Label ID="numberLabel" runat="server" Width="10px" Text='<%# Container.DataSetIndex + 1 %>' />
                            </ItemTemplate>
                            <HeaderStyle Width="10px" />
                        </telerik:GridTemplateColumn>

                        <telerik:GridBoundColumn SortExpression="IDDNO" HeaderText="IDD No" HeaderButtonType="TextButton" DataField="IDDNO"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn SortExpression="CODE" HeaderText="Vendor Code" HeaderButtonType="TextButton" DataField="CODE"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="REGISTEREDNAME" HeaderButtonType="TextButton" HeaderText="Vendor Name" SortExpression="REGISTEREDNAME"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="STATUS" UniqueName="Status" HeaderButtonType="TextButton" HeaderText="Status" SortExpression="STATUS"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn SortExpression="VALIDTILL" UniqueName="Validity" HeaderText="Valid Till" ItemStyle-Font-Bold="true" ItemStyle-Width="90px" ItemStyle-ForeColor="Green" HeaderButtonType="TextButton" DataField="VALIDTILL" DataFormatString="{0:dd/MM/yyyy}"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="STAGE" UniqueName="Remarks" HeaderButtonType="TextButton" HeaderText="Remarks" SortExpression="STAGE"></telerik:GridBoundColumn>
                        <%--<telerik:GridBoundColumn DataField="COMMENTS" UniqueName="comments" HeaderButtonType="TextButton" HeaderText="Comments" SortExpression="COMMENTS"></telerik:GridBoundColumn>--%>
                        <telerik:GridBoundColumn DataField="APPROVERCOMMENT" ItemStyle-Wrap="true" UniqueName="Further" HeaderButtonType="TextButton" HeaderText="Further Comments" SortExpression="APPROVERCOMMENT"></telerik:GridBoundColumn>

                        <telerik:GridTemplateColumn UniqueName="UpdateColumn">
                            <ItemTemplate>
                                <asp:HyperLink ID="editLink" runat="server" Text="Update"></asp:HyperLink>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn UniqueName="DeleteColumn">
                            <ItemTemplate>
                                <asp:LinkButton ID="deleteLink" OnClick="deleteLink_Click" runat="server" OnClientClick='return confirm("Are you sure you want to delete this vendour?");' Text="Delete Duplicate"></asp:LinkButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>

                <ClientSettings>
                    <ClientEvents OnRowDblClick="RowDblClick" />
                </ClientSettings>

            </telerik:RadGrid>
        </div>
    </div>

    <br />

    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true" RenderMode="Lightweight">
        <Windows>
            <telerik:RadWindow RenderMode="Lightweight" ID="ApprovalDialog" runat="server" Title="" Height="650px" Width="500px" EnableShadow="true"
                Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server">
    </telerik:RadAjaxLoadingPanel>
</asp:Content>