<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oCHCLMgt.ascx.cs" Inherits="App_IDD_UserControl_oCHCLMgt" %>
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

        function refreshGrid(arg) {
            if (!arg) {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
            }
            else {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
            }
        }

        function RowDblClick(sender, eventArgs) {
            window.radopen("ViewDetails.aspx?lCommitmentId=" + eventArgs.getDataKeyValue("lCommitmentId"), "UserListDialog");
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

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="grdView">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdView" />
                <telerik:AjaxUpdatedControl ControlID="divMsgs" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
</telerik:RadAjaxLoadingPanel>
<telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" DecorationZoneID="demo" EnableRoundedCorners="false" RenderMode="Lightweight" />

<div style="width: 99%" class="demo-container size-narrow">
    <table style="color: black">
        <tr>
            <td>
                <asp:Label ID="lblLocation" runat="server" Text="Location:"></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="ddlLocation" runat="server" EmptyMessage="Select Location...">
                </telerik:RadComboBox>
            </td>
            <td>
                <asp:Label ID="lblLocation0" runat="server" Text="Department:"></asp:Label>
            </td>
            <td>
                <telerik:RadComboBox ID="ddlDepartment" AutoPostBack="true" Width="200px" EmptyMessage="Select Department..." runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblLocation1" runat="server" Text="Category:"></asp:Label>
            </td>
            <td colspan="3">
                <telerik:RadComboBox ID="ddlCategory" EmptyMessage="Select Category..." runat="server" Width="430px">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblLocation2" runat="server" Text="Request initiator:"></asp:Label>
            </td>
            <td colspan="3">
                <%--<telerik:RadComboBox ID="ddlContractHolder" EmptyMessage="Select Request initiator..." runat="server" Width="430px">
            </telerik:RadComboBox>--%>

                <telerik:RadComboBox RenderMode="Lightweight" ID="ddlContractHolder" runat="server" Height="200" Width="430px" Font-Size="10pt"
                    DropDownWidth="500" EmptyMessage="Select Request initiator..." HighlightTemplatedItems="true"
                    EnableLoadOnDemand="true" Filter="Contains" OnItemsRequested="ddlContractHolder_ItemsRequested"
                    Skin="Office2010Silver">

                    <HeaderTemplate>
                        <table style="width: 475px; font-size: 9pt" cellspacing="0" cellpadding="0">
                            <tr>
                                <td style="width: 165px;">Sponsor Name</td>
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
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="3">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="100px" />
            </td>
        </tr>
    </table>

    <br />
    <div style="float: right">
        <table>
            <tr>
                <td>Filter by Location: </td>
                <td>
                    <telerik:RadComboBox ID="ddlLocationFilter" runat="server" EmptyMessage="Select Location..." AutoPostBack="true" OnSelectedIndexChanged="ddlLocationFilter_SelectedIndexChanged"></telerik:RadComboBox>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <br />
    <telerik:RadGrid ID="grdView" runat="server" AllowAutomaticDeletes="true" AllowAutomaticInserts="true" AllowAutomaticUpdates="true" AllowPaging="True" AllowSorting="true"
        OnItemCommand="grdView_ItemCommand" OnItemCreated="grdView_ItemCreated" OnItemDataBound="grdView_ItemDataBound" OnItemDeleted="grdView_ItemDeleted"
        OnItemInserted="grdView_ItemInserted" OnItemUpdated="grdView_ItemUpdated" OnNeedDataSource="grdView_NeedDataSource" PageSize="25" RenderMode="Lightweight" Width="100%">

        <AlternatingItemStyle BackColor="#FFFF99" />
        <ItemStyle BackColor="#FFFFFF" />
        <%--<PagerStyle Mode="NumericPages" />--%>
        <PagerStyle PageSizes="5,10,15,20,50,100" PagerTextFormat="{4}<strong>{5}</strong> matching your search criteria" PageSizeLabelText="per page:" />

        <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="None" DataKeyNames="USERID" InsertItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage" Width="100%">
            <Columns>
                <telerik:GridTemplateColumn HeaderText="S/No" UniqueName="TemplateColumn">
                    <ItemTemplate>
                        <asp:Label ID="numberLabel" runat="server" Width="10px" Text='<%# Container.DataSetIndex + 1 %>' />
                    </ItemTemplate>
                    <HeaderStyle Width="10px" />
                </telerik:GridTemplateColumn>

                <%--<telerik:GridTemplateColumn UniqueName="TemplateEditColumn">
                <ItemTemplate>
                    <asp:HyperLink ID="UpdateLink" runat="server" Text="Update"></asp:HyperLink>
                </ItemTemplate>
            </telerik:GridTemplateColumn>

            <telerik:GridTemplateColumn UniqueName="TemplateViewColumn">
                <ItemTemplate>
                    <asp:HyperLink ID="RefreshLink" runat="server" Text="Refresh"></asp:HyperLink>
                </ItemTemplate>
            </telerik:GridTemplateColumn>--%>


                <telerik:GridBoundColumn DataField="LOCATION" HeaderButtonType="TextButton" HeaderText="Location" ItemStyle-Width="100px" SortExpression="LOCATION"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DEPARTMENT" HeaderButtonType="TextButton" HeaderText="Department" ItemStyle-Width="100px" SortExpression="DEPARTMENT"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="CATEGORY" HeaderButtonType="TextButton" HeaderText="Category" ItemStyle-Width="250px" SortExpression="CATEGORY"></telerik:GridBoundColumn>
                <%--            <telerik:GridBoundColumn DataField="OFFICEEXT" HeaderButtonType="TextButton" HeaderText="Office Ext." ItemStyle-Width="100px" SortExpression="OFFICEEXT"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOBTITLE" HeaderButtonType="TextButton" HeaderText="Job Title" SortExpression="JOBTITLE"></telerik:GridBoundColumn>--%>
                <telerik:GridBoundColumn DataField="FULLNAME" HeaderButtonType="TextButton" HeaderText="Request initiator" SortExpression="FULLNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="USERNAME" HeaderButtonType="TextButton" HeaderText="User ID" SortExpression="USERID"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="EMAIL" HeaderButtonType="TextButton" HeaderText="Email" SortExpression="EMAIL"></telerik:GridBoundColumn>

                <telerik:GridTemplateColumn UniqueName="DeleteColumn">
                    <ItemTemplate>
                        <asp:LinkButton ID="DeleteLink" runat="server" OnClick="lnkDelete_Click" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

            </Columns>
        </MasterTableView>

        <ClientSettings>
            <ClientEvents OnRowDblClick="RowDblClick" />
        </ClientSettings>

    </telerik:RadGrid>
</div>
<br /><br /><br /><br />

<telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true" RenderMode="Lightweight">
    <Windows>
        <telerik:RadWindow ID="UserListDialog" runat="server" Height="300px" Left="50px" Modal="true" ReloadOnShow="true" RenderMode="Lightweight" ShowContentDuringLoad="false" Title="View Details and Compare Commitments" Width="550px">
        </telerik:RadWindow>
        <telerik:RadWindow ID="InputEditDialog" runat="server" Height="300px" Left="50px" Modal="true" ReloadOnShow="true" RenderMode="Lightweight" ShowContentDuringLoad="false" Title="Insert/Edit Commitment" Width="550em">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server">
</telerik:RadAjaxLoadingPanel>
