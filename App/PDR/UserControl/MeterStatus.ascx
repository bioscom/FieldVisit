<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MeterStatus.ascx.cs" Inherits="App_PDR_UserControl_MeterStatus" %>

<asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowFooter="True" Width="100%">
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
                    IDMETER='<%# DataBinder.Eval(Container.DataItem, "IDMETER") %>'
                    Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
            
        <asp:TemplateField HeaderText="GROSS OIL (BBLS)">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtGrossOil" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GROSSOIL") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="FLARE (MMSCF)">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtFlare" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FLARE") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="GAS PRODUCED (MMSCF)">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtGasProduced" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GASPRODUCED") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="GAS SOLD (MMSCF)">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtGasSold" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GASSOLD") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="CONDESSATE PRODUCED (BBLS)">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtCondessateProduced" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CONDESSATEPROD") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="FUEL GAS METER">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtFuelGasMeter" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FUELGASMETER") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="REMARKS">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtRemarks" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "REMARKS") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>
       
    </Columns>
</asp:GridView>
<hr />
<asp:Button ID="txtSubmit" runat="server" Text="Save" OnClick="txtSubmit_Click" Width="100px" />
<asp:HiddenField ID="lReportIdHF" runat="server" />