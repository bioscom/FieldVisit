<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VendorsInformationMgt.ascx.cs" Inherits="App_IDD_UserControl_VendorsInformationMgt" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript" language="javascript">

        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }

        function ShowInsertForm() {
            var wndw = window.radopen("AddVendor.aspx", "InputDialog", 850, 530);
            wndw.SetTitle("Add New Vendor");  
            wndw.Center();
            return false;
        }

        function ShowEditForm(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            var wndw = window.radopen("EditVendor.aspx?lVendorId=" + id, "EditDialog", 850, 530);
            wndw.SetTitle("Update Vendor Information");  
            wndw.Center();
            return false;
        }

        function RowDblClick(sender, eventArgs) {
            window.radopen("ViewDetails.aspx?lCommitmentId=" + eventArgs.getDataKeyValue("lCommitmentId"), "UserListDialog");
        }

    </script>
</telerik:RadCodeBlock>


<%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    <Scripts>
        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
        <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
    </Scripts>
</telerik:RadScriptManager>--%>


<div style="width: 100%">
    <br />
    <div style="float: left; color:black">
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
    <br /><br />

    <telerik:RadGrid RenderMode="Lightweight" ID="grdView" AllowSorting="true" runat="server" PageSize="50" AllowAutomaticInserts="true" Font-Size="9pt"
        AllowAutomaticUpdates="true" AllowAutomaticDeletes="true" AllowPaging="True"
        OnItemCreated="grdView_ItemCreated" OnPreRender="grdView_PreRender" OnItemCommand="grdView_ItemCommand" OnItemDataBound="grdView_ItemDataBound"
        OnNeedDataSource="grdView_NeedDataSource" Width="100%">
        <AlternatingItemStyle BackColor="#FFFF99" />
        <ItemStyle BackColor="#FFFFFF" />
        <%--<PagerStyle Mode="NumericPages"></PagerStyle>
        <PagerStyle Mode="NextPrevNumericAndAdvanced"></PagerStyle>--%>
        <PagerStyle PageSizes="50,100,200" PagerTextFormat="{4}<strong>{5}</strong> items matching your search criteria" PageSizeLabelText="Items per page:" />

        <MasterTableView Width="100%" CommandItemDisplay="None" DataKeyNames="VENDORID" AutoGenerateColumns="false" InsertItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">

            <Columns>
                <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="S/No">
                    <ItemTemplate>
                        <asp:Label ID="numberLabel" runat="server" Width="10px" Text='<%# Container.DataSetIndex + 1 %>' />
                    </ItemTemplate>
                    <HeaderStyle Width="10px" />
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn UniqueName="TemplateEditColumn" ItemStyle-Width="50px">
                    <ItemTemplate>
                        <asp:HyperLink ID="editLink" runat="server" Text="Edit"></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn SortExpression="IDDNO" HeaderText="IDD No" HeaderButtonType="TextButton" DataField="IDDNO" ItemStyle-Width="100px"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="CATEGORY" HeaderText="Category / Services" HeaderButtonType="TextButton" DataField="CATEGORY" ItemStyle-Width="150px"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="CODE" HeaderText="Vendor Code" HeaderButtonType="TextButton" DataField="CODE" ItemStyle-Width="50px"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="REGISTEREDNAME" HeaderText="Vendor" HeaderButtonType="TextButton" DataField="REGISTEREDNAME" ItemStyle-Width="250px" ></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="ADDRESS" HeaderText="Address"  HeaderButtonType="TextButton" DataField="ADDRESS" ItemStyle-Width="300px" ></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="TELEPHONENO" HeaderText="Phone Number" HeaderButtonType="TextButton" DataField="TELEPHONENO" ItemStyle-Width="120px"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="AMOUNT" HeaderText="Contract Value($)" HeaderButtonType="TextButton" DataField="AMOUNT" ItemStyle-Width="150px" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                <%--<telerik:GridBoundColumn SortExpression="CONTRACTHOLDERFULLNAME" HeaderText="Request initiator" HeaderButtonType="TextButton" DataField="CONTRACTHOLDERFULLNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="DATE_SUBMITTED" HeaderText="Date Submitted" HeaderButtonType="TextButton" DataField="DATE_SUBMITTED" DataFormatString="{0:dd-MMM-yyyy}"></telerik:GridBoundColumn>--%>

            </Columns>

            <CommandItemTemplate>
                <center><a href="#" onclick="return ShowInsertForm();"><b style="color:red; font-size:14px">Add New Vendor</b></a></center>
            </CommandItemTemplate>

        </MasterTableView>

        <ClientSettings>
            <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
        </ClientSettings>

    </telerik:RadGrid>

    <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>

            <telerik:RadWindow RenderMode="Lightweight" ID="InputDialog" runat="server" Title="Add Vendor Information" Height="500px" Width="950px"
                Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true" VisibleStatusbar="false">
            </telerik:RadWindow>

            <telerik:RadWindow RenderMode="Lightweight" ID="EditDialog" runat="server" Title="Update Vendor Information" Height="500px" Width="950px"
                Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true" VisibleStatusbar="false">
            </telerik:RadWindow>

        </Windows>
    </telerik:RadWindowManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server">
    </telerik:RadAjaxLoadingPanel>
</div>
<br /><br />