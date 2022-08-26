<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GeneratorAirCompressorStatus.ascx.cs" Inherits="App_PDR_UserControl_GeneratorAirCompressorStatus" %>

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
                    IDGEN='<%# DataBinder.Eval(Container.DataItem, "IDGEN") %>'
                    Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Gen A">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtGenA" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GEN1") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Gen B">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtGenB" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GEN2") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Gen C">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtGenC" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GEN3") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Diesel Gen A">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtDieselGenA" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DIESELGEN1") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Diesel Gen B">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtDieselGenB" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DIESELGEN2") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="AIR COMP A">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtAirCompA" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, " AIRCOMP1") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="AIR COMP B">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtAirCompB" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, " AIRCOMP2") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="AIR COMP C">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtAirCompC" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, " AIRCOMP3") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="AIR COMP D">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtAirCompD" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, " AIRCOMP4") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<hr />
<asp:Button ID="txtSubmit" runat="server" Text="Save" OnClick="txtSubmit_Click" Width="100px" />
<asp:HiddenField ID="lReportIdHF" runat="server" />