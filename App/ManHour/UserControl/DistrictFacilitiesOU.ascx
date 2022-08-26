<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DistrictFacilitiesOU.ascx.cs" Inherits="UserControl_DistrictFacilitiesOU" %>

<div style="width: 98%">
    <%--<div style="float: left; width: 20%">
        <b>Select Organisation Units</b>
        <hr />
        <%--<asp:CheckBoxList ID="OUCheckBoxList" runat="server"></asp:CheckBoxList>
        <asp:DropDownList ID="ddlOU" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOU_SelectedIndexChanged" ValidationGroup="Facilities">
            <asp:ListItem Value="-1">Select Organisation Unit</asp:ListItem>
        </asp:DropDownList>
    </div>--%>
    <div style="float: left; width: 100%; height: 450px; overflow: auto; border: solid 1px silver">
        <b>Assets Impacted</b>
        <hr />
        <asp:GridView ID="grdViewOU" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="grdViewOU_PageIndexChanging" Width="98%" OnRowCommand="grdViewOU_RowCommand">
            <RowStyle CssClass="gRepeatItemPlate" />
            <AlternatingRowStyle CssClass="gRepeatAlterPlate" />
            <Columns>

                <asp:TemplateField HeaderText="OU">
                    <ItemTemplate>
                        <asp:CheckBox ID="OUCkB" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OU") %>' 
                            IDOU='<%# DataBinder.Eval(Container.DataItem, "IDOU") %>' OnCheckedChanged="OUCkB_CheckedChanged" AutoPostBack="True" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Asset">
                    <ItemTemplate>
                        <asp:GridView ID="subGrdViewAsset" runat="server" ShowHeader="false" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="AssetsCkB" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ASSETS") %>' 
                                            IDASSET='<%# DataBinder.Eval(Container.DataItem, "IDASSET") %>'  OnCheckedChanged="AssetsCkB_CheckedChanged" AutoPostBack="True"/>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="District">
                                    <ItemTemplate>
                                        <asp:GridView ID="subGrdViewDistrict" runat="server" ShowHeader="false" AutoGenerateColumns="False" Width="100%">
                                            <RowStyle CssClass="gRepeatItemPlate" />
                                            <AlternatingRowStyle CssClass="gRepeatAlterPlate" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="DistrictCkB" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DISTRICT") %>' ID_DISTRICT='<%# DataBinder.Eval(Container.DataItem, "ID_DISTRICT") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Facilities">
                                                    <ItemTemplate>
                                                        <asp:GridView ID="subGrdViewFacilities" runat="server" ShowHeader="false" AutoGenerateColumns="False" Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="FacilitiesCkB" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>' ID_FACILITIES='<%# DataBinder.Eval(Container.DataItem, "ID_FACILITIES") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div style="float: right">
        <asp:Button ID="submitBtn" runat="server" Text="Submit" Width="100px" OnClick="submitBtn_Click" ValidationGroup="Facilities" />
    </div>
</div>
<asp:HiddenField ID="lInitiativeHF" runat="server" />
