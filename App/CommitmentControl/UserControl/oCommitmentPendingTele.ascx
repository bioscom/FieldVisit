<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oCommitmentPendingTele.ascx.cs" Inherits="App_BONGACCP_UserControl_oCommitmentPendingTele" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">

        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }

        function ShowDetailsForm(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            var wndw = window.radopen("ViewDetails.aspx?lCommitmentId=" + id, "UserListDialog", 950, 500);
            wndw.set_visibleStatusbar(false);
            wndw.Center();
            return false;
        }

        function ShowEditForm(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            var wndw = window.radopen("InputEdit.aspx?lCommitmentId=" + id, "InputEditDialog", 1100, 500);
            wndw.set_visibleStatusbar(false);
            wndw.Center();
            return false;
        }

        function ShowInsertForm() {
            window.radopen("InputEdit.aspx", "InputEditDialog");
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
            window.radopen("ViewDetails.aspx?lCommitmentId=" + eventArgs.getDataKeyValue("COMMITMENTID"), "UserListDialog");
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
                <telerik:AjaxUpdatedControl ControlID="grdView"></telerik:AjaxUpdatedControl>
                <telerik:AjaxUpdatedControl ControlID="divMsgs"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>

<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>

<telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" DecorationZoneID="demo" DecoratedControls="All" EnableRoundedCorners="false" />

<div id="demo"  style="width: 99%">
    <div style="float: left">
        <asp:Label runat="server" ID="lblSearch" Text="Search:"></asp:Label>
        <telerik:RadComboBox RenderMode="Lightweight" ID="ddlCommitment" runat="server" Height="200" Width="600px" Font-Size="10pt"
            DropDownWidth="600" EmptyMessage="Search for Commitment by Activity description..." AutoPostBack="true"
            EnableLoadOnDemand="true" Filter="Contains" OnItemsRequested="ddlCommitment_ItemsRequested"
            Skin="Office2010Silver" OnSelectedIndexChanged="ddlCommitment_SelectedIndexChanged">

            <HeaderTemplate>
                <table style="width: 600px; font-size: 9pt" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 350px;">Title</td>
                        <td style="width: 150px;">Commitment No.</td>
                        <td style="width: 100px;">Date Submitted</td>
                    </tr>
                </table>
            </HeaderTemplate>

            <ItemTemplate>
                <table style="width: 600px; font-size: 9pt" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 350px;"><%# DataBinder.Eval(Container, "Text")%></td>
                        <td style="width: 150px;"><%# DataBinder.Eval(Container, "Attributes['COMITMNTNO']")%></td>
                        <td style="width: 100px;"><%# DataBinder.Eval(Container, "Attributes['DATE_SUBMITTED']")%></td>
                    </tr>
                </table>
            </ItemTemplate>
        </telerik:RadComboBox>

        <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Excel_XLSX.png" OnClick="ImageButton_Click" AlternateText="Html" ToolTip="Export to Excel" />--%>
    </div>

    <telerik:RadGrid RenderMode="Lightweight" ID="grdView" AllowSorting="true" runat="server" PageSize="25" AllowAutomaticInserts="true"
        AllowAutomaticUpdates="true" AllowAutomaticDeletes="true" AllowPaging="True" ShowFooter="True"
        OnItemDeleted="grdView_ItemDeleted" OnItemUpdated="grdView_ItemUpdated" OnItemInserted="grdView_ItemInserted" OnItemCreated="grdView_ItemCreated"
        OnItemCommand="grdView_ItemCommand" OnItemDataBound="grdView_ItemDataBound" OnNeedDataSource="grdView_NeedDataSource" Width="100%">

        <AlternatingItemStyle BackColor="#FFFF99" Font-Size="8pt" />
        <ItemStyle BackColor="#FFFFFF" Font-Size="8pt" />

        <PagerStyle PageSizes="20,50,100,200" PagerTextFormat="{4}<strong>{5}</strong> items matching your search criteria" PageSizeLabelText="Items per page:" />

        <MasterTableView Width="100%" CommandItemDisplay="None" DataKeyNames="COMMITMENTID" AutoGenerateColumns="false" InsertItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">
            <Columns>

                <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="S/No">
                    <ItemTemplate>
                        <asp:Label ID="numberLabel" runat="server" Width="10px" />
                    </ItemTemplate>
                    <HeaderStyle Width="10px" />
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn UniqueName="TemplateEditColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="editLink" runat="server" Text="Edit"></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn UniqueName="TemplateViewColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="ViewLink" runat="server" Text="Present/Approve"></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn SortExpression="COMITMNTNO" HeaderText="BCC No" HeaderButtonType="TextButton" DataField="COMITMNTNO"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="TITLE" HeaderText="Activity Description" ItemStyle-Width="350px" HeaderButtonType="TextButton" DataField="TITLE"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="GROUPNAME" HeaderText="Pur. Grp" HeaderButtonType="TextButton" DataField="GROUPNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="TEAMNAME" HeaderText="Team" ItemStyle-Width="100px" HeaderButtonType="TextButton" DataField="TEAMNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="INITIATORFULLNAME" HeaderText="Initiator" ItemStyle-Width="100px" HeaderButtonType="TextButton" DataField="INITIATORFULLNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="DECISION" HeaderText="Approval Decision" HeaderButtonType="TextButton" DataField="DECISION"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="STATUS" HeaderText="New or Represented" ItemStyle-Width="150px" HeaderButtonType="TextButton" DataField="STATUS"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="PRVALUE" HeaderText="PR (F$)" HeaderButtonType="TextButton" DataField="PRVALUE" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="POVALUE" HeaderText="PO (F$)" HeaderButtonType="TextButton" DataField="POVALUE" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn Aggregate="Sum" FooterText="Total Commitment: " SortExpression="COMMITMENT" HeaderText="Commitment (F$)" HeaderButtonType="TextButton" DataField="COMMITMENT" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                <%--<telerik:GridBoundColumn Aggregate="Sum" FooterText="Total Savings: " SortExpression="dSavings" HeaderText="Savings($)" HeaderButtonType="TextButton" DataField="SAVINGS" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>--%>

            </Columns>

            <CommandItemTemplate>
                <a href="#" onclick="return ShowInsertForm();">Add New Commitment</a>
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

            <telerik:RadWindow RenderMode="Lightweight" ID="InputEditDialog" runat="server" Title="Commitment Control Form" Height="500px" Width="1100px"
                Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server">
    </telerik:RadAjaxLoadingPanel>
</div>
