<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oFlaringBeyondEndDate.ascx.cs" Inherits="App_FlareWaiver_UserControl_oFlaringBeyondEndDate" %>

<asp:DropDownList ID="ddlYear" runat="server" Width="150px">
    <asp:ListItem Value="-1">Select Year...</asp:ListItem>
</asp:DropDownList>
&nbsp;<asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
    <asp:ListItem Value="-1">Select Month</asp:ListItem>
</asp:DropDownList>
<br />
<br />
<table style="width:100%">
    <tr>
        <td colspan="2">
            <strong>Legend</strong>
            <hr />
        </td>
    </tr>
    <tr>
        <td style="width:30px">
            <asp:TextBox ID="TextBox2" runat="server" BackColor="Red" BorderStyle="None" ReadOnly="True" Width="30px"></asp:TextBox>
        </td>
        <td>

            Flaring beyond the original approved date and flared volume above Annual Flare Limit</td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" BackColor="#009933" BorderStyle="None" ReadOnly="True" Width="30px"></asp:TextBox>
        </td>
        <td>

            Flaring within the original approved date and flare above Annual Flare limit / Or Flaring above the original approved date and flared volume below Annual Flare Limit</td>
    </tr>
    <tr>
        <td colspan="2">
            <hr />
        </td>
    </tr>
</table>

<asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" Width="100%">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Facilities" SortExpression="FACILITY">
            <ItemTemplate>
                <asp:Label ID="lblFacilities" runat="server" IDFACILITY='<%# DataBinder.Eval(Container.DataItem, "IDFACILITY") %>' Text='<%# DataBinder.Eval(Container.DataItem, "FACILITY") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Codes" SortExpression="CODE">
            <ItemTemplate>
                <asp:Label ID="labelCodes" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CODE") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Request Number" SortExpression="REQUESTNO">
            <ItemTemplate>
                <asp:Label ID="lblRequestNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "REQUESTNO") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Reason for flaring" SortExpression="REASON">
            <ItemTemplate>
                <asp:Label ID="lblReason" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "REASON") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="350px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Start Date" SortExpression="START_DATE">
            <ItemTemplate>
                <asp:Label ID="lblStartDate" runat="server" Text='<%# Bind("START_DATE", "{0:dd-MMM-yyyy}") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="End Date" SortExpression="END_DATE">
            <ItemTemplate>
                <asp:Label ID="lblEndDate" runat="server" Text='<%# Bind("END_DATE", "{0:dd-MMM-yyyy}") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Date Approved (Original Start Date)" SortExpression="DATE_APPROVED">
            <ItemTemplate>
                <asp:Label ID="lblDateApproved" runat="server" Text='<%# Bind("DATE_APPROVED", "{0:dd-MMM-yyyy}") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Total Flared YTD">
            <ItemTemplate>
                <asp:Label ID="lblTotalFlared" runat="server" Text=''></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Annual Flare Limit">
            <ItemTemplate>
                <asp:Label ID="lblAnnualLimit" runat="server" Text=''></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Actual Gas Flared YTD">
            <ItemTemplate>
                <asp:Label ID="lblActualFlared" runat="server" Text=''></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="(Original End Date)">
            <ItemTemplate>
                <asp:Label ID="lblOriginalED" runat="server" Text=''></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Last Flared Date">
            <ItemTemplate>
                <asp:Label ID="lblLastFlaredDate" runat="server" Text=''></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="...">
            <ItemTemplate>
                <asp:Label ID="lblStatus" runat="server" Text=''></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>
