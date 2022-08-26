<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master" AutoEventWireup="true" CodeFile="eSearch.aspx.cs" Inherits="App_FieldVisit_Forms_FieldVisit_eSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tSubGray">
        <tr>
            <td class="cHeadTile" colspan="2">Approved Field Visit Request</td>
        </tr>
        <tr>
            <td style="vertical-align: top">
                <asp:Label ID="Label1" runat="server" Text="Enter Request Number:"></asp:Label>
                &nbsp;<asp:TextBox ID="txtRequest" runat="server" Width="200px" ToolTip="Enter Request Number"></asp:TextBox>
                <asp:Button ID="btnFind" runat="server" Text="Find..." Width="60px" OnClick="btnFind_Click" />
            </td>
            <td style="vertical-align: top">
                <asp:Label ID="Label2" runat="server" Text="Note: To recall deleted request, please call support contact." Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20"
                    OnPageIndexChanging="grdView_PageIndexChanging" OnRowCommand="grdView_RowCommand" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Activity ID">
                            <ItemTemplate>
                                <asp:Label ID="labelActivityID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIVITYID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fields">
                            <ItemTemplate>
                                <asp:LinkButton ID="fieldDetailsLinkButton" runat="server"
                                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="viwFieldDetails" ForeColor="#003366" Font-Bold="True"
                                    ID_ACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITIES") %>'
                                    Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>' ToolTip="View activity details"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="District">
                            <ItemTemplate>
                                <asp:Label ID="labelDistrict" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DISTRICT") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Superintendent">
                            <ItemTemplate>
                                <asp:Label ID="labelSuperintendent" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SUPERINTENDENT") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Account to charge">
                            <ItemTemplate>
                                <asp:Label ID="labelAccountToCharge" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACCOUNT") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Initiator">
                            <ItemTemplate>
                                <asp:Label ID="labelInitiator" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date From">
                            <ItemTemplate>
                                <asp:Label ID="labelDateFrom" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DATE_FROM") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date To">
                            <ItemTemplate>
                                <asp:Label ID="labelDateTo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DATE_TO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Status">
            <ItemTemplate>
                <asp:Label ID="labelStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:LinkButton ID="statusLinkButton" runat="server"
                                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="viwStatus" Font-Bold="True"
                                    ID_ACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITIES") %>'
                                    Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>' ToolTip="View Status" ValidationGroup="oGrid"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                <asp:LinkButton ID="reportLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                                    CommandName="report" ID_ACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITIES") %>'
                                    ValidationGroup="gridVal">Report</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="grdPEC" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="20" OnPageIndexChanging="grdPEC_PageIndexChanging"
                        OnRowCommand="grdPEC_RowCommand" Width="100%">
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
</asp:Content>

