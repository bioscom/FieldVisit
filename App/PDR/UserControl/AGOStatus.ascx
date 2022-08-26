<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AGOStatus.ascx.cs" Inherits="App_PDR_UserControl_AGOStatus" %>

<style type="text/css">
    .auto-style1 {
        width: 100px;
        font-family: Verdana, Arial, Helvetica, sans-serif;
        font-size: 100%;
    }
</style>

<asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowFooter="True" Width="600px">
    <Columns>

        <asp:TemplateField>
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Facilities">
            <ItemTemplate>
                <asp:Label ID="lbFacility" runat="server"
                    ID_FACILITIES='<%# DataBinder.Eval(Container.DataItem, "ID_FACILITIES") %>'
                    IDAGO='<%# DataBinder.Eval(Container.DataItem, "IDAGO") %>'
                    Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="ACTUAL STOCK">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtActualStock" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTUALSTOCK") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="ISSUED / CONSUMED">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtIssuedConsumed" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ISSUEDCONSUMED") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="ENDURANCE (Days)">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtEndurance" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ENDURANCE") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Boat Availability">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtBoatAvailability" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BOATAVAILABILITY") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>
<hr />
<asp:Button ID="txtSubmit" runat="server" Text="Save" OnClick="txtSubmit_Click" Width="100px" />
<asp:HiddenField ID="lReportIdHF" runat="server" />