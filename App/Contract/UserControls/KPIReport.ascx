<%@ Control Language="C#" AutoEventWireup="true" CodeFile="KPIReport.ascx.cs" Inherits="App_Contract_UserControls_KPIReport" %>
<%@ Register src="~/UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>

<table class="tMainBorder" style="width: 750px">
    <tr>
        <td class="cHeadTile" colspan="2">Operations Superintendent 14 Day Contract</td>
    </tr>
    <tr>
        <td style="width: 150px">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Trip Start Date:"></asp:Label>

        </td>
        <td style="width: 600px">
            <div style="width: 100%">
                <div style="float: left">
                    <uc2:datecontrol id="dtTripStartDate" runat="server" />
                </div>
                <div style="float: left">
                    &nbsp;
                </div>
                <div style="margin-left: 1.5em; float: left">
                    <asp:Label ID="lblSuperintendent" Font-Bold="True" runat="server"></asp:Label>
                </div>

            </div>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="grdView_PageIndexChanging" ShowHeader="False" Width="100%" OnRowCommand="grdView_RowCommand">
                <RowStyle CssClass="gRepeatItemPlate" />
                <AlternatingRowStyle CssClass="gRepeatAlterPlate" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <br />
                            <asp:Label ID="lblPriority" runat="server" Font-Bold="true"
                                IDPRIORITY='<%# DataBinder.Eval(Container.DataItem, "IDPRIORITY") %>'
                                Text='<%# DataBinder.Eval(Container.DataItem, "PRIORITY") %>'></asp:Label>
                            <br />
                            <hr />
                            <asp:GridView ID="subGrdView" runat="server" AutoGenerateColumns="False" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Activity">
                                        <ItemTemplate>
                                            <asp:Label ID="lblActivity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIVITY") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="300px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Measures">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMeasures" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MEASURES") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="250px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Target">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTarget" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TARGET") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Actual">
                                        <ItemTemplate>
                                            <asp:Label ID="lblActual" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTUAL") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
