<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HSSE.ascx.cs" Inherits="App_PDR_UserControl_HSSE" %>
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
                    IDHSSE='<%# DataBinder.Eval(Container.DataItem, "IDHSSE") %>'
                    Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="LTI">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtLTI" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LTI") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Operational Spills Goal Zero Days">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtOperationalSpill" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GOALZERODAYS") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Zero Plant Trip Days">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtZeroPlantDays" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ZEROPLANTDAYS") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Fountain Assurance">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtFountainAssurance" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FOUNTASSURANCE") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Security Ops. Level (SOL)">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtSOL" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SOL") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>
<hr />
<asp:Button ID="txtSubmit" runat="server" Text="Save" OnClick="txtSubmit_Click" Width="100px" />
<asp:HiddenField ID="lReportIdHF" runat="server" />