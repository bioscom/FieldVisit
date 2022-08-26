<%@ Control Language="C#" AutoEventWireup="true" CodeFile="POB.ascx.cs" Inherits="App_PDR_UserControl_POB" %>

  <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowFooter="True" Width="600px">
    <Columns>

        <asp:TemplateField>
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Station">
            <ItemTemplate>
                <asp:Label ID="lbFacility" runat="server"
                    ID_FACILITIES='<%# DataBinder.Eval(Container.DataItem, "ID_FACILITIES") %>'
                    IDPOB='<%# DataBinder.Eval(Container.DataItem, "IDPOB") %>'
                    Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Current POB">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtCurrentPOB" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CURRENTPOB") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Critical (To stay)">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtCritical" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CRITICAL") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="	Non-Critical (To leave)">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtNonCritical" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NONCRITICAL") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="	 REMARKS">
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