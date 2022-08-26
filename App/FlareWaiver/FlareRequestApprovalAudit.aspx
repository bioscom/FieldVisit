<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="FlareRequestApprovalAudit.aspx.cs" Inherits="FlareRequestApprovalAudit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                </Scripts>
            </telerik:RadScriptManager>
        <div>
            <div style="float: left; width: 100%">

                <telerik:RadGrid RenderMode="Lightweight" ID="grdView" AllowSorting="true" runat="server" AllowPaging="True" PagerStyle-AlwaysVisible="true" PageSize="20" 
                    Font-Size="11px" EnableHeaderContextFilterMenu="true" OnNeedDataSource="grdView_NeedDataSource" OnItemDataBound="grdView_ItemDataBound" Width="100%">

                    <AlternatingItemStyle BackColor="#FFFF99" />
                    <ItemStyle BackColor="#FFFFFF" />

                    <PagerStyle PageSizes="20,50,100" PagerTextFormat="{4}<strong>{5}</strong> items matching your search criteria" PageSizeLabelText="Items per page:" />

                    <MasterTableView Width="100%" CommandItemDisplay="Top" AutoGenerateColumns="false">
                        <CommandItemSettings ShowExportToWordButton="true" ShowExportToCsvButton="true" ShowAddNewRecordButton="false" ShowRefreshButton="false" />

                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                <ItemTemplate>
                                    <asp:Label ID="numberLabel" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridBoundColumn SortExpression="COMMENTS" HeaderText="Comment" HeaderButtonType="TextButton" DataField="COMMENTS"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn ItemStyle-Width="150px" FilterCheckListEnableLoadOnDemand="true" SortExpression="START_DATE" HeaderText="Start Date/Time" HeaderButtonType="TextButton" DataField="START_DATE" DataFormatString="{0:dd-MMM-yyyy}"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn ItemStyle-Width="150px" UniqueName="status" SortExpression="STAND" HeaderText="Stand" HeaderButtonType="TextButton" DataField="STAND" AllowFiltering="false"></telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
        </div>
    </form>
</body>
</html>
