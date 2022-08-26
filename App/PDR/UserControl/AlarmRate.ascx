<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AlarmRate.ascx.cs" Inherits="App_PDR_UserControl_AlarmRate" %>

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
                    IDALARM='<%# DataBinder.Eval(Container.DataItem, "IDALARM") %>'
                    Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="ALARM/HR">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtAlarmHr" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ALARMHR") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="OVERIDES STATUS">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtOverrideStatus" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OVERIDESSTATUS") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Fire and Gas Detector Status	Open path">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtOpenPath" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GDSOP") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Fire and Gas Detector Status	Point Gas">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtPointGas" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GDSPG") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>
<hr />
<asp:Button ID="txtSubmit" runat="server" Text="Save" OnClick="txtSubmit_Click" Width="100px" />
<asp:HiddenField ID="lReportIdHF" runat="server" />