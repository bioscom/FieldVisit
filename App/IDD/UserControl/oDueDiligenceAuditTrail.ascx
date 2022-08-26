<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oDueDiligenceAuditTrail.ascx.cs" Inherits="App_IDD_UserControl_oDueDiligenceAuditTrail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%--<div style="margin-left: 24em; margin-bottom:10px; margin-right:20px">--%>
<div style="margin-bottom:10px; margin-right:20px">
    <telerik:RadGrid RenderMode="Lightweight" ID="grdView" AllowSorting="true" runat="server" PageSize="5" AllowAutomaticInserts="true"
        AllowAutomaticUpdates="true" AllowAutomaticDeletes="true" AllowPaging="True" OnNeedDataSource="grdView_NeedDataSource" OnItemDataBound="grdView_ItemDataBound" Width="100%">
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
                <telerik:GridBoundColumn SortExpression="STATUS" HeaderText="Status" HeaderButtonType="TextButton" DataField="STATUS"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="STAGE" UniqueName="Remarks" HeaderText="Comments" HeaderButtonType="TextButton" DataField="STAGE"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="COMMENTS" HeaderText="Other Information" HeaderButtonType="TextButton" DataField="COMMENTS"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="DATECOMMENT" HeaderText="Date Comment" HeaderButtonType="TextButton" DataField="DATECOMMENT" DataFormatString="{0:dd/MM/yyyy}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="DATESCREENED" HeaderText="Effective Date" HeaderButtonType="TextButton" DataField="DATESCREENED" DataFormatString="{0:dd/MM/yyyy}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="VALIDITYPERIOD" HeaderText="Valid Till" HeaderButtonType="TextButton" DataField="VALIDITYPERIOD" DataFormatString="{0:dd/MM/yyyy}"></telerik:GridBoundColumn>

                <telerik:GridBoundColumn SortExpression="APPROVERNAME" HeaderText="Approved By" HeaderButtonType="TextButton" DataField="APPROVERNAME"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="APPROVALSTATUS" HeaderText="Approval Status" HeaderButtonType="TextButton" DataField="APPROVALSTATUS"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="APPROVERCOMMENT" HeaderText="Approval Comments" HeaderButtonType="TextButton" DataField="APPROVERCOMMENT"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="DATEAPPROVED" HeaderText="Validity Period" HeaderButtonType="TextButton" DataField="DATEAPPROVED" DataFormatString="{0:dd/MM/yyyy}"></telerik:GridBoundColumn>
            </Columns>

        </MasterTableView>

    </telerik:RadGrid>
</div>

<asp:HiddenField ID="RequestIdHF" runat="server" />
