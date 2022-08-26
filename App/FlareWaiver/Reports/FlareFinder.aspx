<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="FlareFinder.aspx.cs" Inherits="App_FlareWaiver_Reports_FlareFinder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Src="../../../UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
    <%--<script src="Js/jquery-1.8.3.min.js"></script>
    <script src="Js/jquery-ui-1.9.2.custom.min.js"></script>
    <link href="Bootstrap/jquery-ui-1.10.3.custom.css" rel="stylesheet" /> --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" EnablePageMethods="true"></ajaxToolkit:ToolkitScriptManager>--%>
    <table class="tMainBorder" style="width: 99%">
        <tr>
            <td colspan="2" class="cHeadTile">Reporting Energy Component </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" Width="200px">
                    <asp:ListItem Value="-1">Select Area</asp:ListItem>
                </asp:DropDownList>
            &nbsp;
                <asp:DropDownList ID="ddlFacility" runat="server" Width="200px">
                    <asp:ListItem Value="-1">Select Facility</asp:ListItem>
                </asp:DropDownList>
            &nbsp;
                <asp:DropDownList ID="ddlMonth" runat="server" Width="200px">
                    <asp:ListItem Value="-1">Select Month</asp:ListItem>
                </asp:DropDownList>
            &nbsp;
                <asp:Button ID="btnRpt" runat="server" OnClick="btnRpt_Click" Text="Report" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <table class="tMainBorder" style="width: 99%">
                    <tr>
                        <td class="cHeadTile">Approved Gas Flare Requests from (<asp:Label ID="lblStation" runat="server"></asp:Label>
                            )</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="grdVWFlare" runat="server" AutoGenerateColumns="False" Width="100%">
                                <Columns>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Initiator" SortExpression="FULLNAME">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInitiator" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Flare Target(mmscfd)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFlareTarget" runat="server" Text=''></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Flare Vol.(mmscfd)" SortExpression="FLAREVOL">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFlareVol" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FLAREVOL") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Ass. Oil Prod.(mbopd)" SortExpression="OILPROD">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAssOilProd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OILPROD") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Start Date/Time" SortExpression="START_DATE">
                                        <ItemTemplate>
                                            <asp:Label ID="labelStartDate" runat="server" Text='<%# Bind("START_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                            /                               
                                <asp:Label ID="lblStartTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "START_TIME") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="End Date/Time" SortExpression="END_DATE">
                                        <ItemTemplate>
                                            <asp:Label ID="labelEndDate" runat="server" Text='<%# Bind("END_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                            /
                                <asp:Label ID="lblEndTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "END_TIME") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date Approved" SortExpression="DATE_APPROVED">
                                        <ItemTemplate>
                                            <asp:Label ID="labelDateApproved" runat="server" Text='<%# Bind("DATE_APPROVED", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="New End Date" SortExpression="NEW_END_DATE">
                                        <ItemTemplate>
                                            <asp:Label ID="labelNewEndDate" runat="server" Text='<%# Bind("NEW_END_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
            <td>

                <table class="tMainBorder" style="width: 99%">
                    <tr>
                        <td class="cHeadTile">Real Time Gas Flared from (<asp:Label ID="lblStation2" runat="server"></asp:Label>
                            )</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="grdVWEC" runat="server" AutoGenerateColumns="False" Width="100%">
                                <Columns>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Flare Target(mmscfd)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFlareTarget" runat="server" Text=''></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Flare Vol.(mmscfd)" SortExpression="SI">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFlareVol" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SI") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Ass. Oil Prod.(mbopd)" SortExpression="API">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAssOilProd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "API") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Start Date/Time" SortExpression="PRODUCTION_DAY">
                                        <ItemTemplate>
                                            <asp:Label ID="labelStartDate" runat="server" Text='<%# Bind("PRODUCTION_DAY", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            <%--<br />
                                            <asp:Label ID="lblStartTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PRODUCTION_DAY") %>'></asp:Label>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--<asp:TemplateField HeaderText="End Date/Time" SortExpression="END_DATE">
                            <ItemTemplate>
                                <asp:Label ID="labelEndDate" runat="server" Text='<%# Bind("END_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                <br />
                                <asp:Label ID="lblEndTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "END_TIME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
    </table>

</asp:Content>
