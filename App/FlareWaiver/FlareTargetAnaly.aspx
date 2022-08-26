 
 
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="FlareTargetAnaly.aspx.cs" Inherits="App_FlareWaiver_FlareTargetAnaly" %>
<%@ Register Src="UserControl/GraphicalReports.ascx" TagName="GraphicalReports" TagPrefix="uc2" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
    <table class="tMainBorder" style="width: 98%">
        <tr>
            <td colspan="3" class="cHeadTile">Reporting Flare Violation</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlYear" runat="server" Width="150px">
                    <asp:ListItem Value="-1">Select Year...</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlYear" ErrorMessage="Please select Year" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                &nbsp;<asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Select Month</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlMonth" ErrorMessage="Please select Month" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
            </td>
 
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Select Day:"></asp:Label>
            </td>
 
            <td>
                <asp:Repeater ID="DailyRepeater" runat="server" OnItemCommand="DailyRepeater_ItemCommand">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDaily" runat="server" NOID='<%# DataBinder.Eval(Container.DataItem, "NOID") %>'
                            Text='<%# DataBinder.Eval(Container.DataItem, "NOID") %>' />&nbsp;                                        
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
 
        <tr>
            <td colspan="3">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <div>
                    <h3 style="float:right; margin-right:4.5em"><asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></h3>
 
                        <table class="tMainBorder" style="width:99%">
                            <tr class="cHeadTile">
                                <td>Gas Flare Target
                                </td>
                                <td>Flared Volume from Energy Component
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" DataKeyNames="TARGETID">
                                        <Columns>
 
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
 
                                            <asp:TemplateField HeaderText="Facilities" SortExpression="FACILITY">
                                                <ItemTemplate>
                                                    <asp:Label ID="labelFacilities" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FACILITY") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="150px" />
                                            </asp:TemplateField>
 
                                            <asp:TemplateField HeaderText="Codes" SortExpression="CODE">
                                                <ItemTemplate>
                                                    <asp:Label ID="labelCodes" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CODE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
 
                                            <asp:TemplateField HeaderText="Target" SortExpression="MON">
                                                <ItemTemplate>
                                                    <asp:Label ID="labelMonth" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MON") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>
 
                                            <asp:TemplateField HeaderText="Approved Flare Vol." SortExpression="FLAREVOL">
                                                <ItemTemplate>
                                                    <asp:Label ID="labelFlaredVol" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FLAREVOL") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="50px" />
                                            </asp:TemplateField>
 
                                            <asp:TemplateField HeaderText="Start Date" SortExpression="START_DATE">
                                                <ItemTemplate>
                                                    <asp:Label ID="labelRequestedStartDate" runat="server" Text='<%# Bind("START_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
 
                                            <asp:TemplateField HeaderText="End Date" SortExpression="END_DATE">
                                                <ItemTemplate>
                                                    <asp:Label ID="labelRequestedEndDate" runat="server" Text='<%# Bind("END_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
 
                                            <asp:TemplateField HeaderText="Approved Start Date" SortExpression="DATE_APPROVED">
                                                <ItemTemplate>
                                                    <asp:Label ID="labelApprovedStartDate" runat="server" Text='<%# Bind("DATE_APPROVED", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="80px" />
                                            </asp:TemplateField>
 
                                            <asp:TemplateField HeaderText="Approved End Date" SortExpression="NEW_END_DATE">
                                                <ItemTemplate>
                                                    <asp:Label ID="labelApproveEndDate" runat="server" Text='<%# Bind("NEW_END_DATE", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="80px" />
                                            </asp:TemplateField>
 
                                            <asp:TemplateField HeaderText="Status" SortExpression="STATUS">
                                                <ItemTemplate>
                                                    <asp:Label ID="labelStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="150px" />
                                            </asp:TemplateField>
 
                                        </Columns>
                                    </asp:GridView>
 
                                </td>
                                <td>
                                    <asp:GridView ID="grdViewEC" runat="server" AutoGenerateColumns="False" Width="100%">
                                        <Columns>
 
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
 
                                            <asp:TemplateField HeaderText="Facilities" SortExpression="FacilityKey">
                                                <ItemTemplate>
                                                    <asp:Label ID="labelFacilities0" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FacilityKey") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="150px" />
                                            </asp:TemplateField>
 
                                            <asp:TemplateField HeaderText="Codes" SortExpression="CODE">
                                                <ItemTemplate>
                                                    <asp:Label ID="labelCodes0" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CODE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
 
                                            <asp:TemplateField HeaderText="..." SortExpression="SI">
                                                <ItemTemplate>
                                                    <asp:Label ID="labelMonth0" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SI") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
 
                                        </Columns>
                                    </asp:GridView>
                                </td>
 
                            </tr>
                        </table>
                    </div>
                <br />
            </td>
        </tr>
    </table>
 
    <uc2:GraphicalReports ID="GraphicalReports1" runat="server" />
    <br />
    <uc2:GraphicalReports ID="GraphicalReports2" runat="server" />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
</asp:Content>
 
 
