<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/configuration.master" MaintainScrollPositionOnPostback="true"
    AutoEventWireup="true" CodeFile="PlannerFacilityMapView.aspx.cs" Inherits="Forms_Setup_PlannerFacilityMapView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="rightColumn" runat="Server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tSubGray" style="width: 98%">
                <tr>
                    <td class="cHeadTile">Facilities Planners Mapping
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False"
                            OnPageIndexChanging="grdView_PageIndexChanging" Width="100%">
                            <RowStyle CssClass="gRepeatItemPlate" />
                            <AlternatingRowStyle CssClass="gRepeatAlterPlate" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Superintendent">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSuperintendent" runat="server"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "SUPERINTENDENT") %>' ID_SUPERINTENDENT='<%# DataBinder.Eval(Container.DataItem, "ID_SUPERINTENDENT") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="250px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="District">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:BulletedList ID="DistrictLst" runat="server" Font-Bold="true" BulletStyle="Square">
                                                    </asp:BulletedList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div style="font-size: 11pt; margin-left: 1.5em">
                                                        <asp:GridView ID="subGrdView" runat="server" DataKeyNames="ID_FACILITIES" AutoGenerateColumns="False" Width="100%">
                                                            <Columns>

                                                                <asp:TemplateField HeaderText="Facilities">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFacilities" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="250px" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Planners">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPlanner" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="...">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="deleteLinkButton" runat="server"
                                                                            CommandArgument="<%# Container.DisplayIndex %>" CommandName="DeleteThis"
                                                                            OnClick="btnDelete_Click"
                                                                            USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>' 
                                                                            IDFACILITY ='<%# DataBinder.Eval(Container.DataItem, "ID_FACILITIES") %>'
                                                                            ValidationGroup="Remove">Remove from Planners</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>

                                                </td>
                                            </tr>
                                        </table>

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
