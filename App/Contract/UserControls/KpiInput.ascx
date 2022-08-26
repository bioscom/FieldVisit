<%@ Control Language="C#" AutoEventWireup="true" CodeFile="KpiInput.ascx.cs" Inherits="App_Contract_UserControls_KpiInput" %>
<%@ Register Src="~/UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>

<style type="text/css">
    .label {
        font-family: Verdana, Arial, Helvetica, sans-serif;
        font-style: normal;
        font-variant: normal;
        color: black;
    }
</style>

<table class="tMainBorder" style="width: 850px">
    <tr>
        <td class="cHeadTile" colspan="4">
            <asp:Label ID="lblAssetArea" runat="server"></asp:Label>
            &nbsp;Operations Superintendent 14 Day Contract</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Trip Start Date:"></asp:Label>
        </td>
        <td>
            <uc2:dateControl ID="dtTripStart" runat="server" />
        </td>
        <td>
            <asp:Label ID="lblSuperintendent" Font-Bold="True" runat="server"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlDistrict" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Width="300px" AutoPostBack="True">
                <asp:ListItem Value="-1">Select Asset Area</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td colspan="3">
            <div style="float: right">
                <div style="float: left">
                    <asp:Label ID="Label3" runat="server" Text="At the end of 14 days contract, click ==>>" Font-Bold="True" ForeColor="Red"></asp:Label>
                </div>
                <div style="float: left">
                    <asp:Button ID="btnForwardForApproval" runat="server" Text="Send for Ops Manager's Approval" Width="350px" OnClick="btnForwardForApproval_Click" />
                </div>

            </div>
        </td>
    </tr>
    <tr>
        <td colspan="4">
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
                                            <asp:Label ID="lblActivity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIVITY") %>'
                                                IDACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "IDACTIVITIES") %>'></asp:Label>
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
                                            <asp:TextBox ID="txtTarget" Width="50px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TARGET") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Actual">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtActual" Width="50px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTUAL") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <div style="text-align: right">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Width="100px" />
                &nbsp;<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" Width="100px" />
                &nbsp;<asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Close" Width="100px" />
            </div>
        </td>
    </tr>
</table>
<asp:HiddenField ID="HFDistrictId" runat="server" />
