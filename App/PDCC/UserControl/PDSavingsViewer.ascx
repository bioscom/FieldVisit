<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PDSavingsViewer.ascx.cs" Inherits="App_PDCC_UserControl_PDSavingsViewer" %>

<asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False"  RowStyle-BackColor="White" ShowFooter="True" Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="Asset/Team">
            <ItemTemplate>
                <asp:Label ID="lbAsset" runat="server" Font-Bold="true" Font-Size="9pt"
                    ASSETID='<%# DataBinder.Eval(Container.DataItem, "ASSETID") %>'
                    Text='<%# DataBinder.Eval(Container.DataItem, "ASSET") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="150px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Jan">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:Label ID="lbJan" runat="server"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Feb">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:Label ID="lbFeb" runat="server"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Mar">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:Label ID="lbMar" runat="server"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Apr">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:Label ID="lbApr" runat="server"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="May">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:Label ID="lbMay" runat="server"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="June">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:Label ID="lbJun" runat="server"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Jul">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:Label ID="lbJul" runat="server"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Aug">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:Label ID="lbAug" runat="server"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Sep">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:Label ID="lbSep" runat="server"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Oct">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:Label ID="lbOct" runat="server"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Nov">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:Label ID="lbNov" runat="server"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Dec">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:Label ID="lbDec" runat="server"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>

