<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/configuration.master" AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="UserManagement" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="RightColumn" runat="Server">
    

    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">

            function RowDblClick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }

            function ShowEditForm(id, rowIndex) {
                var grid = $find("<%= RadGrdView.ClientID %>");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                window.radopen("EditUser.aspx?UserId=" + id, "InputEditDialog");
                return false;
            }

            function ShowActionForm(id, rowIndex) {
                var grid = $find("<%= RadGrdView.ClientID %>");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                window.radopen("CPFocalPointAction.aspx?lRequestId=" + id, "ActionDialogVM");
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



    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tSubGray" style="width: 99%">
                <tr>
                    <td class="cHeadTile" colspan="2">Users List
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="float: left">
                            <asp:LinkButton ID="lbAddNew" runat="server" PostBackUrl="~/AddUser.aspx">Add New User</asp:LinkButton>
                        </div>
                        <div style="float: right">
                            <asp:LinkButton ID="lbAddC4CUsers" runat="server" PostBackUrl="~/AddC4CUser.aspx">Add C4C User</asp:LinkButton>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div>
                            <div style="float: left">
                                <telerik:RadComboBox RenderMode="Lightweight" ID="ddlUsers" runat="server" Height="200" Width="430px" Font-Size="10pt"
                                    DropDownWidth="500" EmptyMessage="Search for user..." HighlightTemplatedItems="true" AutoPostBack="true"
                                    EnableLoadOnDemand="true" Filter="Contains" OnItemsRequested="ddlUsers_ItemsRequested"
                                    Skin="Office2010Silver" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged">

                                    <HeaderTemplate>
                                        <table style="width: 475px; font-size: 9pt" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td style="width: 165px;">Name</td>
                                                <td style="width: 220px;">Email Address</td>
                                                <td style="width: 90px;">Ref. Ind.</td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <table style="width: 475px; font-size: 9pt" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td style="width: 165px;"><%# DataBinder.Eval(Container, "Text")%></td>
                                                <td style="width: 220px;"><%# DataBinder.Eval(Container, "Attributes['EMAIL']")%></td>
                                                <td style="width: 90px;"><%# DataBinder.Eval(Container, "Attributes['REFIND']")%></td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </telerik:RadComboBox>
                            </div>
                            <div style="float: right">
                                <asp:Button ID="btnCleanUp" runat="server" OnClick="btnCleanUp_Click" Text="Clean Up Users Database" Width="220px" />
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div id="demo" class="demo-container no-bg" style="width: 100%">

                            <telerik:RadGrid RenderMode="Lightweight" ID="RadGrdView" AllowSorting="true" runat="server" PageSize="25" AllowAutomaticInserts="true"
                                AllowAutomaticUpdates="true" AllowAutomaticDeletes="true" AllowPaging="True"
                                OnItemDeleted="grdView_ItemDeleted" OnItemUpdated="grdView_ItemUpdated" OnItemInserted="grdView_ItemInserted" OnItemCreated="grdView_ItemCreated" OnPreRender="grdView_PreRender"
                                OnItemCommand="grdView_ItemCommand" OnItemDataBound="grdView_ItemDataBound" OnNeedDataSource="grdView_NeedDataSource" OnDetailTableDataBind="grdView_DetailTableDataBind" Width="100%">
                                <AlternatingItemStyle BackColor="#FFFF99" />
                                <ItemStyle BackColor="#FFFFFF" />
                                <%--<PagerStyle Mode="NumericPages"></PagerStyle>--%>
                                <%--<PagerStyle Mode="NextPrevNumericAndAdvanced"></PagerStyle>--%>
                                <PagerStyle PageSizes="5,10,25,50,100" PagerTextFormat="{4}<strong>{5}</strong> users matching your search criteria" PageSizeLabelText="User per page:" />

                                <MasterTableView Width="100%" CommandItemDisplay="Top" DataKeyNames="USERID" AutoGenerateColumns="false" InsertItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">

                                    <Columns>
                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="S/No">
                                            <ItemTemplate>
                                                <asp:Label ID="numberLabel" runat="server" Width="20px" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="20px" />
                                        </telerik:GridTemplateColumn>

                                        <telerik:GridTemplateColumn UniqueName="TemplateEditColumn">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="editLink" runat="server" Text="Edit"></asp:HyperLink>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                        <telerik:GridBoundColumn SortExpression="FULLNAME" HeaderText="Full Name" HeaderButtonType="TextButton" DataField="FULLNAME"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn SortExpression="ROLEID" HeaderText="Field Visit" HeaderButtonType="TextButton" DataField="ROLEID"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn SortExpression="ROLEIDPDCC" HeaderText="Cost Transparency" HeaderButtonType="TextButton" DataField="ROLEIDPDCC"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn SortExpression="ROLEIDBI" HeaderText="Bright Ideas" HeaderButtonType="TextButton" DataField="ROLEIDBI"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn SortExpression="ROLEIDFLR" HeaderText="Flare Waiver" HeaderButtonType="TextButton" DataField="ROLEIDFLR"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn SortExpression="ROLEIDMANHR" HeaderText="Initiative Mgt" HeaderButtonType="TextButton" DataField="ROLEIDMANHR"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn SortExpression="ROLEIDCONTRACT" HeaderText="14 Days Contract" HeaderButtonType="TextButton" DataField="ROLEIDCONTRACT"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn SortExpression="ROLEIDLEAN" HeaderText="Lean Mgt" HeaderButtonType="TextButton" DataField="ROLEIDLEAN"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn SortExpression="EMAIL" HeaderText="Email Address" HeaderButtonType="TextButton" DataField="EMAIL"></telerik:GridBoundColumn>

                                        <telerik:GridTemplateColumn UniqueName="TemplateDeleteColumn">
                                            <ItemTemplate>
                                                <%--<asp:HyperLink ID="DeleteLink" runat="server" Text="Delete"></asp:HyperLink>--%>
                                                <asp:LinkButton ID="DeleteLink" runat="server" OnClick="btnDelete_Click">Delete</asp:LinkButton>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>

                                    <CommandItemTemplate>
                                        <a href="#" onclick="return ShowInsertForm();">Add New User</a>
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

                                    <telerik:RadWindow RenderMode="Lightweight" ID="InputEditDialog" runat="server" Title="Update User's profile" Height="500px" Width="950px"
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

                    </td>
                </tr>
                <%--<tr>
                    <td>
                        <asp:DropDownList ID="ddlUserRole" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUserRole_SelectedIndexChanged">
                            <asp:ListItem Value="-1">--Select User Role--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <div style="float: right">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Find User"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="userTextBox" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="searchButton" runat="server" Text="Find..." OnClick="searchButton_Click" />
                                        <%--<asp:ImageButton ID="searchButton" runat="server" ImageUrl="~/Images/gosearch.gif" OnClick="searchButton_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grdView" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                            OnPageIndexChanged="grdView_PageIndexChanged" OnPageIndexChanging="grdView_PageIndexChanging"
                            OnSorted="grdView_Sorted" OnSorting="grdView_Sorting" PageSize="40" Width="100%">
                            <%--<RowStyle CssClass="gRepeatItemPlate" />
                                <AlternatingRowStyle CssClass="gRepeatAlterPlate" />
                            <Columns>


                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="...">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="editLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>" CommandName="EditThis" OnClick="btnSelect_Click" USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>' USERMAIL='<%# DataBinder.Eval(Container.DataItem, "EMAIL") %>' USERNAME='<%# DataBinder.Eval(Container.DataItem, "USERNAME") %>'>Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Full Name" SortExpression="FULLNAME">
                                    <ItemTemplate>
                                        <asp:Label ID="labelFullName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Field Visit">
                                    <ItemTemplate>
                                        <asp:Label ID="labelRole" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ROLEID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cost Transparency">
                                    <ItemTemplate>
                                        <asp:Label ID="labelRoleCostTransparency" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ROLEIDPDCC") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bright Ideas">
                                    <ItemTemplate>
                                        <asp:Label ID="labelRoleBI" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ROLEIDBI") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Flare Waiver">
                                    <ItemTemplate>
                                        <asp:Label ID="labelRoleFlareWaiver" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ROLEIDFLR") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Initiative Mgt">
                                    <ItemTemplate>
                                        <asp:Label ID="labelRoleInitiative" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ROLEIDMANHR") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="14 Days Contract">
                                    <ItemTemplate>
                                        <asp:Label ID="labelRoleContract" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ROLEIDCONTRACT") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Lean Mgt">
                                    <ItemTemplate>
                                        <asp:Label ID="labelRoleLean" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ROLEIDLEAN") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email Address" SortExpression="EMAIL">
                                    <ItemTemplate>
                                        <a href='mailto:%20<%# DataBinder.Eval(Container.DataItem, "EMAIL") %>'><%# DataBinder.Eval(Container.DataItem, "EMAIL")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="...">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="deleteLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>" CommandName="DeleteThis" OnClick="btnDelete_Click" USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>' USERROLESID='<%# DataBinder.Eval(Container.DataItem, "ROLEID") %>'>Delete</asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>--%>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

