<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oCommitmentsRejectedTele.ascx.cs" Inherits="App_BONGACCP_UserControl_oCommitmentsRejectedTele" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">

        function ShowRejectedDetailsForm(id, rowIndex) {
            var grid = $find("<%= grdViewRejected.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            window.radopen("ViewDetails.aspx?lCommitmentId=" + id, "UserListDialog");
            return false;
        }

        <%--function refreshGrid(arg) {
            if (!arg) {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
            }
            else {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
            }
        }--%>

        function RowDblClick(sender, eventArgs) {
            window.radopen("ViewDetails.aspx.aspx?lCommitmentId=" + eventArgs.getDataKeyValue("lCommitmentId"), "UserListDialog");
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
                <telerik:AjaxUpdatedControl ControlID="grdView"></telerik:AjaxUpdatedControl>
                <telerik:AjaxUpdatedControl ControlID="divMsgs"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>--%>

<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>

<telerik:RadFormDecorator RenderMode="Lightweight" ID="RadFormDecorator1" runat="server" DecorationZoneID="demo" DecoratedControls="All" EnableRoundedCorners="false" />

<div id="demo" class="demo-container no-bg" style="width: 99%">
    <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Excel_XLSX.png" OnClick="ImageButton_Click" AlternateText="Html" ToolTip="Export to Excel" />--%>
    <br />

    <telerik:RadGrid RenderMode="Lightweight" ID="grdViewRejected" AllowSorting="true" runat="server" PageSize="15" AllowPaging="True" ShowFooter="True" 
        OnItemCreated="grdViewRejected_ItemCreated" OnItemCommand="grdViewRejected_ItemCommand" OnItemDataBound="grdViewRejected_ItemDataBound" OnNeedDataSource="grdViewRejected_NeedDataSource" Width="100%">
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

                <telerik:GridTemplateColumn UniqueName="Represent">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkRepresent" runat="server" OnClick="lnkRepresent_Click" Text="Represent"></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn SortExpression="COMITMNTNO" HeaderText="BCC No" HeaderButtonType="TextButton" DataField="COMITMNTNO"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="TITLE" HeaderText="Title" ItemStyle-Width="250px" HeaderButtonType="TextButton" DataField="TITLE"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="GROUPNAME" HeaderText="Pur. Grp" HeaderButtonType="TextButton" DataField="GROUPNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="TEAMNAME" HeaderText="Team" ItemStyle-Width="100px" HeaderButtonType="TextButton" DataField="TEAMNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="INITIATORFULLNAME" HeaderText="Initiator" ItemStyle-Width="100px" HeaderButtonType="TextButton" DataField="INITIATORFULLNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="DECISION" HeaderText="Approval Decision" HeaderButtonType="TextButton" DataField="DECISION"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="STATUS" HeaderText="New or Represented" ItemStyle-Width="150px" HeaderButtonType="TextButton" DataField="STATUS"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="PRVALUE" HeaderText="PR Value (F$)" HeaderButtonType="TextButton" DataField="PRVALUE" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="POVALUE" HeaderText="PO Value (F$)" HeaderButtonType="TextButton" DataField="POVALUE" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn Aggregate="Sum" FooterText="Total Commitment: " SortExpression="COMMITMENT" HeaderText="Commitment (F$)" HeaderButtonType="TextButton" DataField="COMMITMENT" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn Aggregate="Sum" FooterText="Total Savings: " SortExpression="SAVINGS" HeaderText="Savings($)" HeaderButtonType="TextButton" DataField="SAVINGS" DataFormatString="{0:N}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>

                <telerik:GridTemplateColumn UniqueName="TemplateViewColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="ViewLink" runat="server" Text="View Details"></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

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
            <telerik:RadWindow RenderMode="Lightweight" ID="UserListDialog" runat="server" Title="View Details and Compare Commitments" Height="700px"
                Width="950px" Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

            <telerik:RadWindow RenderMode="Lightweight" ID="InputEditDialog" runat="server" Title="Insert/Edit Commitment" Height="700px"
                Width="950px" Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server">
    </telerik:RadAjaxLoadingPanel>
</div>
