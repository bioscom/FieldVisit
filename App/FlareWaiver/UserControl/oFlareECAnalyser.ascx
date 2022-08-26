<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oFlareECAnalyser.ascx.cs" Inherits="App_FlareWaiver_UserControl_oFlareECAnalyser" %>
<%@ Register Src="~/App/FlareWaiver/UserControl/Specific/oRequestDetails.ascx" TagPrefix="bi500" TagName="oRequestDetails" %>

<table class="tMainBorder" style="width: 500px">
    <tr>
        <td class="cHeadTile" colspan="6">Flare Compliance Dashboard</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Facility:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblFacility" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Code:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblCode" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblMonth" Font-Bold="true" ForeColor="Red" runat="server"></asp:Label>
            &nbsp;<asp:Label ID="Label3" Font-Bold="True" ForeColor="Red" runat="server" Text="Flare Limit:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblFlareTarget" runat="server"></asp:Label>
            &nbsp;(mscfd)</td>
    </tr>
</table>

<div style="margin-left: 4px">
    <asp:GridView ID="grdViewEC" runat="server" AutoGenerateColumns="False" Width="500px">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Area" SortExpression="AREA">
                <ItemTemplate>
                    <asp:Label ID="labelArea" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AREA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Facility Key" SortExpression="FACILITYKEY">
                <ItemTemplate>
                    <asp:Label ID="labelKey" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FACILITYKEY") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Production Day" SortExpression="PRODUCTION_DAY">
                <ItemTemplate>
                    <asp:Label ID="lblProdDay" runat="server" Text='<%# Bind("PRODUCTION_DAY", "{0:dd/MM/yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Codes" SortExpression="CODE">
                <ItemTemplate>
                    <asp:Label ID="lblCode0" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="API (mscfd)" SortExpression="API">
                <ItemTemplate>
                    <div style="float: right">
                        <asp:Label ID="lblAPI" runat="server" Text='<%# Eval("API","{0:N2}") %>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>

<table class="tMainBorder" style="width: 500px">
    <tr>
        <td class="cHeadTile" colspan="4">Summary</td>
    </tr>
    <tr>
        <td>Flare Limit:&nbsp; </td>
        <td>
            <asp:Label ID="lbTarget" runat="server" Font-Bold="True" ForeColor="Green"></asp:Label>(mscfd)
        </td>
        <td>Actual Flare&nbsp;</td>
        <td>
            <asp:Label ID="lbActual" runat="server" Font-Bold="True"></asp:Label>(mscfd)
        </td>
    </tr>
</table>

<asp:Panel ID="PnlFlareWaiverApproval" runat="server">
    <bi500:oRequestDetails runat="server" ID="oRequestDetails1" />
</asp:Panel>
<asp:Panel ID="PnlNoApproval" runat="server">
    <asp:Label ID="lblNoApproval" runat="server" Font-Bold="true" ForeColor="Red" Font-Size="3em" Text=""></asp:Label>
</asp:Panel>