<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PDCC.master" AutoEventWireup="true" CodeFile="iReport.aspx.cs" Inherits="App_PDCC_iReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <table class="tMainBorder" style="width: 99%">
        <tr>
            <td colspan="2" class="cHeadTile">Export Report to Excel Format</td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="float: left">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="10pt" Text="Choose Year to Report:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlYear" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td>Enter % Reduction:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPercRed" ErrorMessage="Please enter % Reduction">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPercRed" runat="server" Width="50px">25</asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Reload" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnExportToExcel" runat="server" Text="Export To Excel" Width="120px" OnClick="btnExportToExcel_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnChart" runat="server" Text="View Chart" Width="120px" OnClick="btnChart_Click" />
                        </td>
                    </tr>
                </table>
                <asp:ListBox ID="lstBoxDepartments" runat="server" Height="400px" SelectionMode="Multiple" Width="250px" ToolTip="Press down the Ctrl key to select multiple departments">
                    <asp:ListItem Value="-1">--Select Department(s)--</asp:ListItem>
                </asp:ListBox>

                <asp:Button ID="brnPreview" runat="server" Text="Preview Selections..." Width="250px" OnClick="brnPreview_Click" />
            </td>
            <td>
                <table>
                    <tr>
                        <td style="text-align: left">
                            <asp:PlaceHolder ID="cSPDCReport" runat="server"></asp:PlaceHolder>
                        </td>
                        <td style="text-align: left">
                            <asp:PlaceHolder ID="cSNEPCOReport" runat="server"></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left" colspan="2">
                            <asp:PlaceHolder ID="cCombinedReporter" runat="server"></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>

                <asp:GridView ID="grdGridView" runat="server" AllowPaging="True"
                    AutoGenerateColumns="False" OnLoad="grdGridView_Load"
                    OnPageIndexChanging="grdGridView_PageIndexChanging"
                    OnRowCommand="grdGridView_RowCommand"
                    OnSelectedIndexChanged="grdGridView_SelectedIndexChanged" PageSize="20"
                    Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Opportunities">
                            <ItemTemplate>
                                <asp:LinkButton ID="ProjectLinkButton" runat="server" ForeColor="#003366" Font-Bold="true" Text='<%# DataBinder.Eval(Container.DataItem, "OPPORTUNITY") %>'
                                    CommandName="Project" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDOPCOST='<%# DataBinder.Eval(Container.DataItem, "IDOPCOST") %>' ToolTip="Click on project to drill down">
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="250px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Sponsor">
                            <ItemTemplate>
                                <asp:Label ID="lblSponsor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SPONSORNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action Party">
                            <ItemTemplate>
                                <asp:Label ID="lblActionParty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIONPARTYNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="AcceptPark">
                            <ItemTemplate>
                                <asp:Label ID="lblAcceptPark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACCEPTPARK") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Priority">
                            <ItemTemplate>
                                <asp:Label ID="lblPriority" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PRIORITY") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Asset/Support Services">
                            <ItemTemplate>
                                <asp:Label ID="lblAssetSupport" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ASSERV") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="OPEX">
                            <ItemTemplate>
                                <asp:Label ID="lblOpex" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OPEX") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Front End Cost Take Out">
                            <ItemTemplate>
                                <asp:Label ID="lblFecto" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FECTO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Improvement">
                            <ItemTemplate>
                                <asp:Label ID="lblImprovement" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IMPROVEMENT") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Potential Saving (F$mln)">
                            <ItemTemplate>
                                <asp:Label ID="lblPotSavings" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "POTSAVINGS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Actual Saving">
                            <ItemTemplate>
                                <asp:Label ID="lblActualSaving" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTSAVINGS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="ViewLinkButton" runat="server" CommandName="ViewDetails" CommandArgument="<%# Container.DisplayIndex %>"
                                    IDOPCOST='<%# DataBinder.Eval(Container.DataItem, "IDOPCOST") %>'>View Details</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 250px"></td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
    </table>
</asp:Content>

