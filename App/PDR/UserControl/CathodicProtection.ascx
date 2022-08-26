<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CathodicProtection.ascx.cs" Inherits="App_PDR_UserControl_CathodicProtection" %>

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
                    IDCATHODIC='<%# DataBinder.Eval(Container.DataItem, "IDCATHODIC") %>'
                    Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="CURRENT(AMPS)">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtCurrent" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CURRENTS") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="VOLTAGE (VOLTS)">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtVoltage" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VOLTAGE") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="SILICA GEL Standard">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtSilicaGelStandard" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SILCALGELSTANDARD") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="SILICA GEL Actual">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtSilicaGelActual" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SILCAGELACTUAL") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>
<hr />
<asp:Button ID="txtSubmit" runat="server" Text="Save" OnClick="txtSubmit_Click" Width="100px" />
<asp:HiddenField ID="lReportIdHF" runat="server" />