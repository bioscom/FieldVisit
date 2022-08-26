<%@ Control Language="C#" AutoEventWireup="true" CodeFile="frmSuperintendent.ascx.cs" Inherits="App_FieldVisit_UserControl_frmSuperintendent" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/App/FieldVisit/UserControl/frmDistricts.ascx" TagPrefix="app" TagName="frmDistricts" %>
<%@ Register Src="~/App/FieldVisit/UserControl/FPEC/viwFunctionalAcctMembers.ascx" TagName="viwFunctionalAcctMembers" TagPrefix="uc2" %>



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


<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
</telerik:RadAjaxLoadingPanel>
<telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" DecorationZoneID="demo" EnableRoundedCorners="false" RenderMode="Lightweight" />

<div style="width: 100%" class="demo-container size-narrow">
    <table style="width: 100%">
        <tr>
            <td style="width: 50%; vertical-align: top">
                <div style="margin-left: 5px">
                    <telerik:RadGrid ID="grdView" runat="server" AllowAutomaticDeletes="true" AllowAutomaticInserts="true" AllowAutomaticUpdates="true" AllowPaging="True" AllowSorting="true"
                        OnItemCommand="grdView_ItemCommand" OnItemCreated="grdView_ItemCreated" OnItemDataBound="grdView_ItemDataBound" OnItemDeleted="grdView_ItemDeleted"
                        OnItemInserted="grdView_ItemInserted" OnItemUpdated="grdView_ItemUpdated" OnNeedDataSource="grdView_NeedDataSource" PageSize="25" RenderMode="Lightweight" OnDetailTableDataBind="grdView_DetailTableDataBind">

                        <AlternatingItemStyle BackColor="#FFFF99" />
                        <ItemStyle BackColor="#FFFFFF" />
                        <%--<PagerStyle Mode="NumericPages" />--%>
                        <PagerStyle PageSizes="5,10,15,20,50" PagerTextFormat="{4}<strong>{5}</strong> matching your search criteria" PageSizeLabelText="per page:" />

                        <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="None" DataKeyNames="ID_SUPERINTENDENT" InsertItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">

                            <DetailTables>
                                <telerik:GridTableView DataKeyNames="ID_SUPERINTENDENT, ID_DISTRICT" Name="Districts" Width="100%" AutoGenerateColumns="false">

                                    <DetailTables>
                                        <telerik:GridTableView DataKeyNames="ID_DISTRICT" Name="facilities" Width="100%" AutoGenerateColumns="false">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="FACILITIES" HeaderButtonType="TextButton" HeaderText="Facilities" SortExpression="FACILITIES"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DIVESTED" HeaderButtonType="TextButton" HeaderText="Divested?" SortExpression="DIVESTED"></telerik:GridBoundColumn>
                                            </Columns>
                                        </telerik:GridTableView>
                                    </DetailTables>

                                    <Columns>
                                        <telerik:GridBoundColumn DataField="DISTRICT" HeaderButtonType="TextButton" HeaderText="District" SortExpression="DISTRICT"></telerik:GridBoundColumn>
                                    </Columns>
                                </telerik:GridTableView>
                            </DetailTables>

                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="S/No" UniqueName="TemplateColumn">
                                    <ItemTemplate>
                                        <asp:Label ID="numberLabel" runat="server" Width="30px" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="10px" />
                                </telerik:GridTemplateColumn>

                                <telerik:GridBoundColumn DataField="SUPERINTENDENT" HeaderButtonType="TextButton" HeaderText="Production Units" SortExpression="SUPERINTENDENT"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SUPERINTENDENT_EMAIL" HeaderButtonType="TextButton" HeaderText="Functional Email" SortExpression="SUPERINTENDENT_EMAIL"></telerik:GridBoundColumn>

                                <telerik:GridTemplateColumn HeaderText="..." UniqueName="ViewColumn">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="ViewMembersLink" runat="server" ValidationGroup="xxxx" CommandName="ViewMembers" Text="View Members"></asp:LinkButton>
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


            </td>
            <td>
                <asp:Panel ID="addUserPanel" runat="server" Visible="false">
                    <uc2:viwFunctionalAcctMembers ID="viwFunctionalAcctMembers1" runat="server" />
                    <table class="tSubGray">
                        <tr>
                            <td class="cHeadTile" colspan="2" style="font-size: 8pt">Add New User to
                                    <asp:Label ID="superintendentLabel" runat="server" Font-Bold="true"></asp:Label>
                                &nbsp;Functional Account</td>
                        </tr>
                        <tr>
                            <td>Select User:<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drpSuperintendentUsers" ErrorMessage="Please select User" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpSuperintendentUsers" runat="server">
                                    <asp:ListItem Value="-1">--Select Superintendent User--</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:HiddenField ID="superintendentIdHF" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="addNewUserButton" runat="server"
                                    OnClick="addNewUserButton_Click" Text="Submit" ValidationGroup="district" />
                                &nbsp;<asp:Button ID="closeButton" runat="server" OnClick="closeButton_Click"
                                    Text="Close" ValidationGroup="xxxx" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="superintendent" />
</div>
