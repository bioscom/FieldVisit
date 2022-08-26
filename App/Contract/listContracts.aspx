<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/14DayContract.master" AutoEventWireup="true" CodeFile="listContracts.aspx.cs" Inherits="App_Contract_listContracts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <table class="tMainBorder" style="width: 98%">
                <tr>
                    <td colspan="3" class="cHeadTile">&nbsp;14 Day Contracts</td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlDistrict" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Width="300px" AutoPostBack="True">
                            <asp:ListItem Value="-1">Select Asset Area</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowHeader="true" Width="100%" OnRowCommand="grdView_RowCommand">
                            <Columns>

                                <asp:TemplateField HeaderText="...">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="UpdateLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                            CommandName="Update" ID_DISTRICT='<%# DataBinder.Eval(Container.DataItem, "ID_DISTRICT") %>'>Update Contract</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="...">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Update2LinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                            CommandName="Update2" ID_DISTRICT='<%# DataBinder.Eval(Container.DataItem, "ID_DISTRICT") %>'>Update Contract 2</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Asset">
                                    <ItemTemplate>
                                        <asp:Label ID="lbAsset" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ASSETS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="District">
                                    <ItemTemplate>
                                        <asp:Label ID="lbDistrict" runat="server"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "DISTRICT") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Start Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbStartDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "START_DATE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="End Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbEndDate" runat="server" Text='<%# DateTime.Parse(Eval("START_DATE").ToString()).AddDays(14) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Superintendent">
                                    <ItemTemplate>
                                        <asp:Label ID="lbSuperintendent" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="...">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="ReportLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                            CommandName="Report" ID_DISTRICT='<%# DataBinder.Eval(Container.DataItem, "ID_DISTRICT") %>'>View Report</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--<asp:TemplateField HeaderText="...">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LeadershipActivityReportLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                            CommandName="LeadershipActivityReport" ID_DISTRICT='<%# DataBinder.Eval(Container.DataItem, "ID_DISTRICT") %>'>View Leadership Activity Report</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

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

</asp:Content>

