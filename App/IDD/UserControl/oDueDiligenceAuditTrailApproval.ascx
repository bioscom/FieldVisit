<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oDueDiligenceAuditTrailApproval.ascx.cs" Inherits="App_IDD_UserControl_oDueDiligenceAuditTrailApproval" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">
        function ShowActionForm(id, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            var wndw = window.radopen("IDDApproval.aspx?lAuditId=" + id, "ApprovalDialog", 650, 500);
            wndw.SetTitle("Approval");
            wndw.set_visibleStatusbar(false);
            wndw.Center();
            return false;
        }
    </script>
</telerik:RadCodeBlock>




<div style="margin-bottom: 10px; margin-right: 2px">
    <telerik:RadGrid RenderMode="Lightweight" ID="grdView" AllowSorting="true" runat="server" PageSize="5" AllowAutomaticInserts="true"
        AllowAutomaticUpdates="true" AllowAutomaticDeletes="true" AllowPaging="True" OnItemCreated="grdView_ItemCreated" OnNeedDataSource="grdView_NeedDataSource" OnItemDataBound="grdView_ItemDataBound" Width="100%">
        <AlternatingItemStyle BackColor="Silver" />
        <ItemStyle BackColor="#FFFFFF" />
        <%--<PagerStyle Mode="NumericPages"></PagerStyle>--%>
        <PagerStyle Mode="NextPrevNumericAndAdvanced"></PagerStyle>
        <%--<PagerStyle PageSizes="5,10" PagerTextFormat="{4}<strong>{5}</strong> cars matching your search criteria" PageSizeLabelText="Cars per page:" />--%>

        <MasterTableView Width="100%" DataKeyNames="AUDITID" AutoGenerateColumns="false" InsertItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">
            <Columns>
                <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="S/No">
                    <ItemTemplate>
                        <asp:Label ID="numberLabel" runat="server" Width="10px" Text='<%# Container.DataSetIndex + 1 %>' />
                    </ItemTemplate>
                    <HeaderStyle Width="10px" />
                </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn SortExpression="ANALYSTNAME" HeaderText="Analyst" HeaderButtonType="TextButton" DataField="ANALYSTNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="STATUS" UniqueName="status" HeaderText="Status" HeaderButtonType="TextButton" DataField="STATUS"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="STAGE" UniqueName="Remarks" HeaderText="Comments" HeaderButtonType="TextButton" DataField="STAGE"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="COMMENTS" HeaderText="Other Information" ItemStyle-Width="250px" HeaderButtonType="TextButton" DataField="COMMENTS"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="DATECOMMENT" HeaderText="Date Comment" HeaderButtonType="TextButton" DataField="DATECOMMENT" DataFormatString="{0:dd-MMM-yyyy}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="VALIDITYPERIOD" HeaderText="Validity Period" HeaderButtonType="TextButton" DataField="VALIDITYPERIOD" DataFormatString="{0:dd-MMM-yyyy}"></telerik:GridBoundColumn>

                <telerik:GridBoundColumn SortExpression="APPROVERNAME" HeaderText="Approved By" HeaderButtonType="TextButton" DataField="APPROVERNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="APPROVALSTATUS" HeaderText="Approval Status" HeaderButtonType="TextButton" DataField="APPROVALSTATUS"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="APPROVERCOMMENT" HeaderText="Approval Comments" ItemStyle-Width="250px" HeaderButtonType="TextButton" DataField="APPROVERCOMMENT"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="DATEAPPROVED" HeaderText="Date Approved" HeaderButtonType="TextButton" DataField="DATEAPPROVED" DataFormatString="{0:dd-MMM-yyyy}"></telerik:GridBoundColumn>

                <telerik:GridTemplateColumn UniqueName="TemplateApproveColumn" HeaderText="...">
                    <ItemTemplate>
                        <asp:HyperLink ID="approveLink" runat="server" Text="Approve..."></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

            </Columns>
        </MasterTableView>
    </telerik:RadGrid>

    <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow RenderMode="Lightweight" ID="ApprovalDialog" runat="server" Title="Approve Analyst Action" Height="500px" Width="650px"
                Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>

        </Windows>
    </telerik:RadWindowManager>

</div>

<asp:HiddenField ID="RequestIdHF" runat="server" />
