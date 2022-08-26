<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WeeklyHighLight.ascx.cs" Inherits="UserControls_WeeklyHighLight" %>

<table class="tSubGray" style="width: 100%">
    <tr>
        <td class="cHeadTile">Competitiveness &amp; Business Improvement Weekly Highlights</td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gviw" runat="server" AutoGenerateColumns="False" OnRowCommand="gviw_RowCommand"
                AllowPaging="True" ShowHeader="False" PageSize="10" Width="100%" AllowSorting="True" OnPageIndexChanging="gviw_PageIndexChanging">
                <Columns>

                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="labelDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DATESUBMIT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="...">
                        <ItemTemplate>
                            <asp:LinkButton ID="ViewLinkButton" runat="server" 
                                HIGHLIGHTID='<%# DataBinder.Eval(Container.DataItem, "HIGHLIGHTID") %>'
                                CommandName="View" CommandArgument='<%# Container.DisplayIndex %>' 
                                Text='<%# "C&BI Weekly Highlight Report - Week " + DataBinder.Eval(Container.DataItem, "IWEEK") + " (" + DataBinder.Eval(Container.DataItem, "DATEFROM") + " TO " + DataBinder.Eval(Container.DataItem, "DATETO") + " )"  %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--<asp:TemplateField HeaderText="...">
                        <ItemTemplate>
                            <asp:LinkButton ID="deleteLinkButton" runat="server"
                                fileName='<%# DataBinder.Eval(Container.DataItem, "HIGHLIGHTID") %>'
                                CommandName="deleteThis" CommandArgument='<%# Container.DisplayIndex %>'>Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>

