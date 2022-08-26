<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oSavingsStatistics.ascx.cs" Inherits="App_BONGACCP_UserControl_oSavingsStatistics" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/App/CommitmentControl/UserControl/oSavingsBreakDown.ascx" TagPrefix="app" TagName="oSavingsBreakDown" %>


<script type="text/javascript">
    //Put your JavaScript code here.

    function NodeClientClicked(sender, args) {
        //var nodeText = args.get_node().get_text();
        var nodeValue = args.get_node().get_value();
        var oWnd = window.radopen("ViewComments2.aspx?RequestId=" + nodeValue);
        oWnd.SetTitle("View Request Details");
        oWnd.setSize(900, 500);
        oWnd.set_visibleStatusbar(false);
        oWnd.Center();

    }
</script>

<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
</telerik:RadAjaxLoadingPanel>

<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1" Height="700px" Width="250px" HorizontalAlign="NotSet">

    <fieldset>
        <legend>
            <b style="color: green">Savings Statistics</b>
        </legend>

        <hr />

        <telerik:RadGrid ID="grdView" runat="server" AllowSorting="true" ShowHeader="false" 
            OnItemCommand="grdView_ItemCommand" OnItemCreated="grdView_ItemCreated" 
            OnDetailTableDataBind="grdView_DetailTableDataBind" OnItemDataBound="grdView_ItemDataBound" 
            OnNeedDataSource="grdView_NeedDataSource" 
            EnableHierarchyExpandAll="true" RenderMode="Lightweight">
            
                <AlternatingItemStyle BackColor="#FFFF99" />
                <ItemStyle BackColor="#FFFFFF" />

                <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="None" HierarchyDefaultExpanded="true" DataKeyNames="IDOU" InsertItemDisplay="Top">
                    <NestedViewTemplate>
                        <app:oSavingsBreakDown runat="server" ID="oSavingsBreakDown" />
                    </NestedViewTemplate>

                    <Columns>
                        <telerik:GridBoundColumn SortExpression="OU" HeaderText="Organisation Unit" HeaderButtonType="TextButton" DataField="OU"></telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>

            </telerik:RadGrid>
    </fieldset>


</telerik:RadAjaxPanel>

<telerik:RadWindow ID="RadWindow1" runat="server"></telerik:RadWindow>
