<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oCorporate.ascx.cs" Inherits="App_IDD_UserControl_oCorporate" %>
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


<p id="divMsgs" runat="server">
    <asp:Label ID="Label1" runat="server" EnableViewState="False" Font-Bold="True" ForeColor="#FF8080"></asp:Label>
    <asp:Label ID="Label2" runat="server" EnableViewState="False" Font-Bold="True" ForeColor="#00C000"></asp:Label>
</p>

<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
</telerik:RadAjaxLoadingPanel>
<telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" DecorationZoneID="demo" EnableRoundedCorners="false" RenderMode="Lightweight" />

<div style="width: 99%" class="demo-container size-narrow">
    <table style="color: black">
        <tr>
            <td>
                <asp:Label ID="lblLocation2" runat="server" Text="Search Corporate User:"></asp:Label>
            </td>
            <td>
                <%--<telerik:RadComboBox ID="ddlContractHolder" EmptyMessage="Select Request initiator..." runat="server" Width="430px">
            </telerik:RadComboBox>--%>

                <telerik:RadComboBox RenderMode="Lightweight" ID="ddlAdmin" runat="server" Height="200" Width="430px" Font-Size="10pt"
                    DropDownWidth="500" EmptyMessage="Select Corporate User..." HighlightTemplatedItems="true"
                    EnableLoadOnDemand="true" Filter="Contains" OnItemsRequested="ddlAdmin_ItemsRequested"
                    Skin="Office2010Silver">

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
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Add Corporate User" OnClick="btnSave_Click" Width="150px" />
            </td>
        </tr>
    </table>

    <br />

    <telerik:RadGrid ID="grdView" runat="server" AllowAutomaticDeletes="true" AllowAutomaticInserts="true" AllowAutomaticUpdates="true" AllowPaging="True" AllowSorting="true"
        OnItemCommand="grdView_ItemCommand" OnItemCreated="grdView_ItemCreated" OnItemDataBound="grdView_ItemDataBound" OnItemDeleted="grdView_ItemDeleted"
        OnItemInserted="grdView_ItemInserted" OnItemUpdated="grdView_ItemUpdated" OnNeedDataSource="grdView_NeedDataSource" PageSize="15" RenderMode="Lightweight">

        <AlternatingItemStyle BackColor="#FFFF99" />
        <ItemStyle BackColor="#FFFFFF" />
        <%--<PagerStyle Mode="NumericPages" />--%>
        <PagerStyle PageSizes="5,10,20,50,100" PagerTextFormat="{4}<strong>{5}</strong> matching your search criteria" PageSizeLabelText="per page:" />

        <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="None" DataKeyNames="USERID" InsertItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">
            <Columns>
                <telerik:GridTemplateColumn HeaderText="S/No" UniqueName="TemplateColumn">
                    <ItemTemplate>
                        <asp:Label ID="numberLabel" runat="server" Width="10px" Text='<%# Container.DataSetIndex + 1 %>' />
                    </ItemTemplate>
                    <HeaderStyle Width="10px" />
                </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn DataField="FULLNAME" HeaderButtonType="TextButton" HeaderText="Corporate User" SortExpression="FULLNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="USERNAME" HeaderButtonType="TextButton" HeaderText="User Name" SortExpression="USERNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="EMAIL" HeaderButtonType="TextButton" HeaderText="Email Address" SortExpression="EMAIL"></telerik:GridBoundColumn>

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
