<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Start14DaysContract.ascx.cs" Inherits="App_Contract_UserControls_Start14DaysContract" %>

<%@ Register Src="../../../UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>
<table class="tMainBorder" style="width: 99%">
    <tr>
        <td colspan="3" class="cHeadTile">
            <asp:Label ID="lblAssetArea" runat="server"></asp:Label>
            &nbsp;- 14 Day Contract Data Input
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Trip Start Date:"></asp:Label>
        </td>
        <td>
            <uc2:dateControl ID="dtTripStart" runat="server" />
        </td>
        <td>
            <asp:DropDownList ID="ddlDistrict" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Width="300px" AutoPostBack="True">
                <asp:ListItem Value="-1">Select Asset Area</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="3">
            <hr />
            <asp:Button ID="txtSubmitUpper" runat="server" Text="Submit" OnClick="txtSubmitUpper_Click" Width="100px" />
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowHeader="true" Width="100%" OnRowDataBound="grdView_RowDataBound">
                <RowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Priority">
                        <ItemTemplate>
                            <asp:Label ID="lbPriority" runat="server"
                                IDPRIORITY='<%# DataBinder.Eval(Container.DataItem, "IDPRIORITY") %>'
                                Text='<%# DataBinder.Eval(Container.DataItem, "PRIORITY") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="250px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Activity">
                        <ItemTemplate>
                            <asp:Label ID="lbActivity" runat="server"
                                IDACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "IDACTIVITIES") %>'
                                IDSUBACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "IDSUBACTIVITIES") %>'
                                IDPRIORITY='<%# DataBinder.Eval(Container.DataItem, "IDPRIORITY") %>'
                                Text='<%# DataBinder.Eval(Container.DataItem, "ACTIVITY") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="250px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Trip Target">
                        <ItemTemplate>
                            <%--<asp:Label ID="lbDay12" runat="server" Text=''></asp:Label>--%>
                            <asp:Label ID="lbTarget" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TARGET") %>'></asp:Label>
                            <asp:TextBox ID="txtTarget" Width="50px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TARGET") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Trip Actual">
                        <ItemTemplate>
                            <asp:Label ID="lbActual" runat="server" Text=''></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="40px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbDay1" runat="server" Text=''></asp:Label>
                            <asp:TextBox ID="txtDay1" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DAY1") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbDay2" runat="server" Text=''></asp:Label>
                            <asp:TextBox ID="txtDay2" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DAY2") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbDay3" runat="server" Text=''></asp:Label>
                            <asp:TextBox ID="txtDay3" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DAY3") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbDay4" runat="server" Text=''></asp:Label>
                            <asp:TextBox ID="txtDay4" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DAY4") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbDay5" runat="server" Text=''></asp:Label>
                            <asp:TextBox ID="txtDay5" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DAY5") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbDay6" runat="server" Text=''></asp:Label>
                            <asp:TextBox ID="txtDay6" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DAY6") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbDay7" runat="server" Text=''></asp:Label>
                            <asp:TextBox ID="txtDay7" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DAY7") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbDay8" runat="server" Text=''></asp:Label>
                            <asp:TextBox ID="txtDay8" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DAY8") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbDay9" runat="server" Text=''></asp:Label>
                            <asp:TextBox ID="txtDay9" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DAY9") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbDay10" runat="server" Text=''></asp:Label>
                            <asp:TextBox ID="txtDay10" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DAY10") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbDay11" runat="server" Text=''></asp:Label>
                            <asp:TextBox ID="txtDay11" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DAY11") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbDay12" runat="server" Text=''></asp:Label>
                            <asp:TextBox ID="txtDay12" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DAY12") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbDay13" runat="server" Text=''></asp:Label>
                            <asp:TextBox ID="txtDay13" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DAY13") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbDay14" runat="server" Text=''></asp:Label>
                            <asp:TextBox ID="txtDay14" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DAY14") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="3">
            <asp:Button ID="txtSubmitLower" runat="server" Text="Submit" OnClick="txtSubmitLower_Click" Width="100px" />
        </td>
    </tr>
</table>
