<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AllPECRequestsApproved.ascx.cs" Inherits="UserControl_SEPCiN_AllPECRequestsApproved" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table class="tSubGray" style="width: 100%">
            <tr>
                <td class="cHeadTile">PEC Requests Approved</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="20" OnPageIndexChanging="grdView_PageIndexChanging"
                        OnRowCommand="grdView_RowCommand" Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Asset/Platform">
                                <ItemTemplate>
                                    <asp:Label ID="labelAsset" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Activity ID">
                                <ItemTemplate>
                                    <asp:Label ID="labelActivityID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIVITYID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Activity">
                                <ItemTemplate>
                                    <asp:Label ID="lblActivity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIVITYDESCRIPTION") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Originator">
                                <ItemTemplate>
                                    <asp:Label ID="labelInitiator" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Date Submitted">
                                <ItemTemplate>
                                    <asp:Label ID="labelDateFrom" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DATE_SUMBITTED") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:LinkButton ID="statusLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                        CommandName="viwStatus" Font-Bold="True"
                                        ID_ACTIVITYINFO='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITYINFO") %>'
                                        Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>' ToolTip="View Status"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="...">
                                <ItemTemplate>
                                    <asp:LinkButton ID="reportLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                        CommandName="report" ID_ACTIVITYINFO='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITYINFO") %>'
                                        ValidationGroup="gridVal">Report</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="VST" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtStatusVST" runat="server" ReadOnly="true" BorderStyle="None" Width="30px"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="30px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ST" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtStatusST" runat="server" ReadOnly="true" BorderStyle="None" Width="30px"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="30px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="MT" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtStatusMT" runat="server" ReadOnly="true" BorderStyle="None" Width="30px"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="30px" />
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender"
    runat="server" Enabled="True" TargetControlID="UpdatePanel1">
</ajaxToolkit:UpdatePanelAnimationExtender>
<asp:UpdateProgress ID="upgAjaxBloc" runat="server" DisplayAfter="100" Visible="true"
    DynamicLayout="true">
    <ProgressTemplate>
        <div id="IMGDIV" align="center" valign="middle" runat="server" style="position: absolute; visibility: visible; left: 50%; top: 70%; vertical-align: middle; border-color: #FFFFFF; background-color: #FFFFFF;">
            <asp:Image ID="imgAjaxWait" runat="server" ImageUrl="~/Images/ajaxRoller.gif" />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>


