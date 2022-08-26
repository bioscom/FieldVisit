<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oFlareTargetDashBoard.ascx.cs" Inherits="App_FlareWaiver_UserControl_oFlareTargetDashBoard" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%--<%@ Register Src="~/App/FlareWaiver/UserControl/oFlareECAnalyser.ascx" TagPrefix="app" TagName="oFlareECAnalyser" %>

<asp:LinkButton ID="EditLinkButton" ForeColor="White" runat="server" ValidationGroup="Recommendation"></asp:LinkButton>--%>

<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">

        function ShowActionForm(id, iYear, iMonth, sFacility, dFlareTarget, sCode, rowIndex) {
            var grid = $find("<%= grdView.ClientID %>");

            var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
            grid.get_masterTableView().selectItem(rowControl, true);

            var wndw = window.radopen("FlareECAnalyser.aspx?iFacId=" + id + "&iYear=" + iYear + "&iMonth=" + iMonth + "&sFac=" + sFacility + "&dTar=" + dFlareTarget + "&sCode=" + sCode, "InputDialog", 550, 500);
            wndw.set_visibleStatusbar(false);
            wndw.Center();
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

        (function () {
            var demo = window.demo = {};
            demo.onRequestStart = function (sender, args) {
                if (args.get_eventTarget().indexOf("Button") >= 0) {
                    args.set_enableAjax(false);
                }
            }
        })();

    </script>
</telerik:RadCodeBlock>

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
    <AjaxSettings>

        <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdView" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>

        <telerik:AjaxSetting AjaxControlID="grdView">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdView" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>

    </AjaxSettings>
</telerik:RadAjaxManager>

<telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel>

<asp:DropDownList ID="ddlYear" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
    <asp:ListItem Value="-1">Select Year...</asp:ListItem>
</asp:DropDownList>
<br />
<br />
<div style="float: left; width: 100%">

    <telerik:RadGrid RenderMode="Lightweight" ID="grdView" runat="server" Font-Size="11px" OnItemCreated="grdView_ItemCreated" OnItemDataBound="grdView_ItemDataBound"
        OnNeedDataSource="grdView_NeedDataSource" OnDetailTableDataBind="grdView_DetailTableDataBind" Width="100%">

        <AlternatingItemStyle BackColor="#FFFF99" />
        <ItemStyle BackColor="#FFFFFF" />

        <%--<PagerStyle PageSizes="20,50,100" PagerTextFormat="{4}<strong>{5}</strong> items matching your search criteria" PageSizeLabelText="Items per page:" />--%>

        <MasterTableView Width="100%" CommandItemDisplay="Top" DataKeyNames="TARGETID, IDFACILITY" AutoGenerateColumns="false">
            <CommandItemSettings ShowExportToWordButton="true" ShowExportToCsvButton="true" ShowAddNewRecordButton="false" ShowRefreshButton="false" />

            <Columns>
                <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                    <ItemTemplate>
                        <asp:Label ID="numberLabel" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn SortExpression="FACILITY" HeaderText="Facilities" HeaderButtonType="TextButton" DataField="FACILITY" UniqueName="Facility"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="CODE" HeaderText="Code" HeaderButtonType="TextButton" DataField="CODE" UniqueName="Code"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn SortExpression="AGG" HeaderText="AGG" HeaderButtonType="TextButton" DataField="AGG" UniqueName="Agg"></telerik:GridBoundColumn>

                <telerik:GridTemplateColumn HeaderText="Jan" SortExpression="JAN">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:LinkButton ID="lnkJan" OnClick="lnkJan_Click" runat="server" Text='<%# Eval("JAN","{0:N2}") %>' CODE='<%# DataBinder.Eval(Container.DataItem, "CODE") %>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="Feb" SortExpression="FEB">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:LinkButton ID="lnkFeb" OnClick="lnkFeb_Click" runat="server" Text='<%# Eval("FEB","{0:N2}") %>' CODE='<%# DataBinder.Eval(Container.DataItem, "CODE") %>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="Mar" SortExpression="MAR">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:LinkButton ID="lnkMar" OnClick="lnkMar_Click" runat="server" Text='<%# Eval("MAR","{0:N2}") %>' CODE='<%# DataBinder.Eval(Container.DataItem, "CODE") %>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="Apr" SortExpression="APR">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:LinkButton ID="lnkApr" OnClick="lnkApr_Click" runat="server" Text='<%# Eval("APR","{0:N2}") %>' CODE='<%# DataBinder.Eval(Container.DataItem, "CODE") %>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="May" SortExpression="MAY">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:LinkButton ID="lnkMay" OnClick="lnkMay_Click" runat="server" Text='<%# Eval("MAY","{0:N2}") %>' CODE='<%# DataBinder.Eval(Container.DataItem, "CODE") %>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="Jun" SortExpression="JUN">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:LinkButton ID="lnkJun" OnClick="lnkJun_Click" runat="server" Text='<%# Eval("JUN","{0:N2}") %>' CODE='<%# DataBinder.Eval(Container.DataItem, "CODE") %>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="Jul" SortExpression="JUL">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:LinkButton ID="lnkJul" OnClick="lnkJul_Click" runat="server" Text='<%# Eval("JUL","{0:N2}") %>' CODE='<%# DataBinder.Eval(Container.DataItem, "CODE") %>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="Aug" SortExpression="AUG">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:LinkButton ID="lnkAug" OnClick="lnkAug_Click" runat="server" Text='<%# Eval("AUG","{0:N2}") %>' CODE='<%# DataBinder.Eval(Container.DataItem, "CODE") %>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="Sep" SortExpression="SEP">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:LinkButton ID="lnkSep" OnClick="lnkSep_Click" runat="server" Text='<%# Eval("SEP","{0:N2}") %>' CODE='<%# DataBinder.Eval(Container.DataItem, "CODE") %>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="Oct" SortExpression="OCT">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:LinkButton ID="lnkOct" OnClick="lnkOct_Click" runat="server" Text='<%# Eval("OCT","{0:N2}") %>' CODE='<%# DataBinder.Eval(Container.DataItem, "CODE") %>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="Nov" SortExpression="NOV">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:LinkButton ID="lnkNov" OnClick="lnkNov_Click" runat="server" Text='<%# Eval("NOV","{0:N2}") %>' CODE='<%# DataBinder.Eval(Container.DataItem, "CODE") %>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="Dec" SortExpression="DECB">
                    <ItemTemplate>
                        <div style="float: right; text-align: right">
                            <asp:LinkButton ID="lnkDec" OnClick="lnkDec_Click" runat="server" Text='<%# Eval("DECB","{0:N2}") %>' CODE='<%# DataBinder.Eval(Container.DataItem, "CODE") %>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="YTD" SortExpression="YTD">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <asp:Label ID="labelYTD" runat="server" Text='<%# Eval("YTD","{0:N2}") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>

        </MasterTableView>
    </telerik:RadGrid>

    <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow RenderMode="Lightweight" ID="InputDialog" runat="server" Title="Flare Compliance Dashboard"
                Height="500px" Width="600px" Left="50px" ReloadOnShow="true" ShowContentDuringLoad="false" Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server">
    </telerik:RadAjaxLoadingPanel>
</div>