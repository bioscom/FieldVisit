<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/LeanMasterPage.master" AutoEventWireup="true" CodeFile="CIDashBoard.aspx.cs" Inherits="App_Lean_CIDashBoard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Src="UserControl/oLeanProjectDetails.ascx" TagName="oLeanProjectDetails" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" ID="smtAjaxManager" />
    <div style="align-content: center; margin-left: 5em">
        <table class="tMainBorder" style="width: 90%">
            <tr>
                <td colspan="2" class="cHeadTile">UIOG Continuous Improvement (CI) Dashboard</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    <div style="float: left">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="10pt" Text="Choose Year to Report:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" Width="200px">
                                    </asp:DropDownList>

                                </td>
                            </tr>
                        </table>
                    </div>
                    &nbsp;<asp:Button ID="btnClose" runat="server" Text="Close" Width="100px" OnClick="btnClose_Click" />
                </td>
            </tr>
        </table>

        <table style="width: 90%">
            <tr>
                <td style="width: 500px">
                    <asp:Label ID="lblFunctionIES" runat="server" Font-Bold="True" Font-Size="9pt"></asp:Label>
                    <hr />
                    <asp:HyperLink ID="hpkFunctionWorkDone" runat="server">Download to Excel</asp:HyperLink>
                    <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowFooter="True" Width="500px">
                        <Columns>
                            <asp:TemplateField HeaderText="Function">
                                <ItemTemplate>
                                    <asp:Label ID="lbFunction" runat="server"
                                        FUNCTIONID='<%# DataBinder.Eval(Container.DataItem, "FUNCTIONID") %>'
                                        Text='<%# DataBinder.Eval(Container.DataItem, "FUNCTION") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Identify">
                                <ItemTemplate>
                                    <div style="text-align: center">
                                        <asp:Label ID="lbIdentify" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IDENTIFY") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Eliminate">
                                <ItemTemplate>
                                    <div style="text-align: center">
                                        <asp:Label ID="lbEliminate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ELIMINATE") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sustain">
                                <ItemTemplate>
                                    <div style="text-align: center">
                                        <asp:Label ID="lbSustain" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SUSTAIN") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total No of Projects">
                                <ItemTemplate>
                                    <div style="text-align: center">
                                        <asp:Label ID="lbTotalProjects" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TOTALPROJINHOPPER") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                    <br />
                    <asp:Chart ID="chartWorkDone" runat="server" BackColor="#D3DFF0" BackGradientStyle="TopBottom" BorderColor="26, 59, 105"
                        BorderlineDashStyle="Solid" BorderWidth="2" Height="400px" Width="500px" ImageLocation="~/Charts/ChartPic_#SEQ(300,3)" Palette="BrightPastel">
                        <Titles>
                            <asp:Title Font="Trebuchet MS, 14.25pt, style=Bold" ForeColor="26, 59, 105" ShadowColor="32, 0, 0, 0" ShadowOffset="3" Text=""></asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend BackColor="Transparent" Docking="Bottom" Enabled="true" Font="Trebuchet MS, 8.25pt, style=Bold" HeaderSeparator="DotLine" IsTextAutoFit="False" Name="DefaultLegend"></asp:Legend>
                        </Legends>

                        <BorderSkin SkinStyle="Emboss"></BorderSkin>

                        <ChartAreas>
                            <asp:ChartArea Name="WorkDoneChartArea">
                            </asp:ChartArea>
                        </ChartAreas>

                    </asp:Chart>
                    <br />
                    <div style="overflow: auto; border: solid 1px silver; width: 500px; height: 300px">

                        <br />
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="9pt" Text="Completed and Ongoing Projects"></asp:Label>
                        &nbsp;-<asp:Label ID="lblYearCompletedOngoing" runat="server"></asp:Label>
                        <br />
                        <hr />

                        <asp:HyperLink ID="HPKCompletedOngoing" runat="server">Download to Excel</asp:HyperLink>
                        <asp:GridView ID="grdViewCompletedOngoingProjects" runat="server" AutoGenerateColumns="False" 
                            ShowHeader="true" ShowFooter="True" Width="120%" OnRowDataBound="grdViewCompletedOngoingProjects_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Function">
                                    <ItemTemplate>
                                        <asp:Label ID="lbFunction0" runat="server"
                                            FUNCTIONID='<%# DataBinder.Eval(Container.DataItem, "FUNCTIONID") %>'
                                            Text='<%# DataBinder.Eval(Container.DataItem, "FUNCTION") %>'></asp:Label>
                                    </ItemTemplate>
                                    <%--<ItemStyle Width="250px" />--%>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Completed">
                                    <ItemTemplate>
                                        <div style="text-align: right">
                                            <asp:Label ID="lbEliminate0" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMPLETED") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Cost Reduction($1,000,000)">
                                    <ItemTemplate>
                                        <div style="text-align: right">
                                            <asp:Label ID="lbActualCostReduction" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTUALBENEFITCR") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Cycle Time">
                                    <ItemTemplate>
                                        <div style="text-align: right">
                                            <asp:Label ID="lbActualCycleTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTUALBENEFITCT") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Barrel">
                                    <ItemTemplate>
                                        <div style="text-align: right">
                                            <asp:Label ID="lbActualBarrel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTUALBENEFITBARREL") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Ongoing">
                                    <ItemTemplate>
                                        <div style="text-align: right">
                                            <asp:Label ID="lbSustain0" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ONGOING") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Cost Reduction($1,000,000)">
                                    <ItemTemplate>
                                        <div style="text-align: right">
                                            <asp:Label ID="lbPotentialCostReduction" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "POTENTIALBENEFITCR") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Cycle Time">
                                    <ItemTemplate>
                                        <div style="text-align: right">
                                            <asp:Label ID="lbPotentialCycleTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "POTENTIALBENEFITCT") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Barrel">
                                    <ItemTemplate>
                                        <div style="text-align: right">
                                            <asp:Label ID="lbPotentialBarrel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "POTENTIALBENEFITBARREL") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Total No of Projects">
                                    <ItemTemplate>
                                        <div style="text-align: right">
                                            <asp:Label ID="lbTotalProjects0" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TOTALPROJECTS") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                    <br />
                    <asp:Chart ID="chartProjectStatus" runat="server" BackColor="#D3DFF0" BackGradientStyle="TopBottom" BorderColor="26, 59, 105"
                        BorderlineDashStyle="Solid" BorderWidth="2" Height="400px" Width="500px" ImageLocation="~/Charts/ChartPic_#SEQ(300,3)" Palette="BrightPastel">
                        <Titles>
                            <asp:Title Font="Trebuchet MS, 14.25pt, style=Bold" ForeColor="26, 59, 105" ShadowColor="32, 0, 0, 0" ShadowOffset="3" Text=""></asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend BackColor="Transparent" Docking="Bottom" Enabled="true" Font="Trebuchet MS, 8.25pt, style=Bold" HeaderSeparator="DotLine" IsTextAutoFit="False" Name="DefaultLegend"></asp:Legend>
                        </Legends>

                        <BorderSkin SkinStyle="Emboss"></BorderSkin>

                        <ChartAreas>
                            <asp:ChartArea Name="ProjectStatusChartArea">
                            </asp:ChartArea>
                        </ChartAreas>

                    </asp:Chart>
                    <br />
                    <br />

                    <br />
                    <br />
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="9pt" Text="Benefits"></asp:Label>
                    <hr />

                    <asp:HyperLink ID="HPKBenefit" runat="server">Download to Excel</asp:HyperLink>
                    <asp:GridView ID="grdViewBenefit" runat="server" AutoGenerateColumns="False" Width="99%">
                        <Columns>

                            <asp:TemplateField HeaderText="Years">
                                <ItemTemplate>
                                    <asp:Label ID="lbYear0" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "YYEAR") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cost Reduction ($)">
                                <ItemTemplate>
                                    <div style="text-align: center">
                                        <asp:Label ID="lbCostReduction" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COSTREDUCTION") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cycle Time(Days)">
                                <ItemTemplate>
                                    <div style="text-align: center">
                                        <asp:Label ID="lbCycleTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CYCLETIME") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Number*">
                                <ItemTemplate>
                                    <div style="text-align: center">
                                        <asp:Label ID="lbNumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NUMBER") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="No of Projects">
                                <ItemTemplate>
                                    <div style="text-align: center">
                                        <asp:Label ID="labelTotalProjects" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TOTALPROJECTS") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                    <br />
                    Note:Same project can deliver benefit for several year<br />
                    <br />
                    <asp:Chart ID="BenefitChart" runat="server" BackColor="#D3DFF0" BackGradientStyle="TopBottom" BackSecondaryColor="White" BorderColor="26, 59, 105"
                        BorderlineDashStyle="Solid" BorderWidth="2" Height="400px" Width="500px" ImageLocation="~/Charts/ChartPic_#SEQ(300,3)" Palette="BrightPastel">
                        <Titles>
                            <asp:Title Font="Trebuchet MS, 14.25pt, style=Bold" ForeColor="26, 59, 105" ShadowColor="32, 0, 0, 0" ShadowOffset="3" Text=""></asp:Title>
                        </Titles>
                        <Legends>
                            <asp:Legend BackColor="Transparent" Docking="Bottom" Enabled="true" Font="Trebuchet MS, 8.25pt, style=Bold" HeaderSeparator="DotLine" IsTextAutoFit="False" Name="DefaultLegend"></asp:Legend>
                        </Legends>

                        <BorderSkin SkinStyle="Emboss"></BorderSkin>

                        <ChartAreas>
                            <asp:ChartArea Name="BenefitChartArea">
                            </asp:ChartArea>
                        </ChartAreas>

                    </asp:Chart>
                    <br />
                    <div style="overflow: auto; border: solid 1px silver; width: 500px; height: 400px">
                        <br />
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="9pt" Text="Projects and Benefits - "></asp:Label>
                        <asp:Label ID="lblYear" runat="server"></asp:Label>
                        <hr />
                        <asp:HyperLink ID="HPKProjectBenefit" runat="server">Download to Excel</asp:HyperLink>
                        <br />
                        <asp:GridView ID="grdViewProjectBenefit" runat="server" AutoGenerateColumns="False" Width="120%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Projects">
                                    <ItemTemplate>
                                        <asp:Label ID="lbProjects" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TITLE") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="30%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Year">
                                    <ItemTemplate>
                                        <asp:Label ID="lbYear" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "YYEAR") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Cycle Time Savings">
                                    <ItemTemplate>
                                        <asp:Label ID="lbBenefit" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CT_SAINGS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Cost Savings">
                                    <ItemTemplate>
                                        <asp:Label ID="lbBenefit0" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COST_SAVINGS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Prod. Barrel">
                                    <ItemTemplate>
                                        <asp:Label ID="lbBenefit1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PRODUCTION_BARREL") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Comments">
                                    <ItemTemplate>
                                        <asp:Label ID="lbComments" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMMENTS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
                <td rowspan="3">
                    <div style="margin-left: 0.5em">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="9pt" Text="Project Status - % Workdone CI Project Maturation Phase"></asp:Label>
                        <hr />
                        <asp:HyperLink ID="HpkProjectStatus" runat="server">Download to Excel</asp:HyperLink>
                        <asp:GridView ID="grdViewProjectStatus" runat="server" AutoGenerateColumns="False" Width="99%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Projects">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblProject" runat="server"
                                            IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>'
                                            Text='<%# DataBinder.Eval(Container.DataItem, "TITLE") %>'></asp:Label>--%>

                                        <asp:LinkButton ID="ProjectLinkButton" runat="server" Font-Bold="true" Text='<%# DataBinder.Eval(Container.DataItem, "TITLE") %>'
                                            CommandName="Project" CommandArgument="<%# Container.DisplayIndex %>"
                                            IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>' OnClick="ProjectLinkButton_Click" ToolTip="Click on project to view project charter"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="300px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Function">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFunction" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FUNCTION") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Year">
                                    <ItemTemplate>
                                        <asp:Label ID="labelYear" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "YYEAR") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Identify">
                                    <ItemTemplate>
                                        <div>
                                            <div style="float: left">
                                                <asp:Image ID="imgIdentify" runat="server"></asp:Image>
                                            </div>
                                            <div style="float: left">
                                                <asp:Label ID="labelIdentify" runat="server" Text=''></asp:Label>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Eliminate">
                                    <ItemTemplate>
                                        <div>
                                            <div style="float: left">
                                                <asp:Image ID="imgEliminate" runat="server"></asp:Image>
                                            </div>
                                            <div style="float: left">
                                                <asp:Label ID="labelEliminate" runat="server" Text=''></asp:Label>
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Sustain">
                                    <ItemTemplate>
                                        <div>
                                            <div style="float: left">
                                                <asp:Image ID="imgSustain" runat="server"></asp:Image>
                                            </div>
                                            <div style="float: left">
                                                <asp:Label ID="labelSustain" runat="server" Text=''></asp:Label>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                        <br />

                        <table class="tMainBorder" style="width: 99%">
                            <tr>
                                <td class="cHeadTile">CULTURE &amp; SUSTAINABILITY</td>
                            </tr>
                        </table>
                        <br />
                        <b>Project Sustainability Assessments</b>
                        <hr />
                        <asp:GridView ID="grdViewSustainability" runat="server" AutoGenerateColumns="False" Width="99%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Projects">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSusProject" runat="server"
                                            IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>'
                                            Text='<%# DataBinder.Eval(Container.DataItem, "TITLE") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="300px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date Accessed">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDateAssessed" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DATE_ASSESSED") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Overrall Score">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtOverrallScore" runat="server" BorderStyle="None" Width="50px" ReadOnly="True"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Findings +ve">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPositiveFindings" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "POSITIVEFINDINGS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Findings -ve">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNegativeFindings" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NEGATIVEFINDINGS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <b>Capability – Training &amp; Certifications</b>
                        <hr />
                        <div style="overflow: auto; border: solid 1px silver; width: 99%; height: 300px">
                            <asp:GridView ID="grdViewTraining" runat="server"></asp:GridView>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>

    
    <br />
    <asp:LinkButton ID="EditLinkButton" runat="server" ForeColor="White"></asp:LinkButton>
    
    <asp:Panel ID="pnlModalPanel" runat="server" Style="display: none;"
        CssClass="modalPopup" Width="910px">
        <asp:Panel ID="pnlDragPanel" runat="server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black">
            +<asp:LinkButton ID="closeButton" runat="server" Text="Close"></asp:LinkButton>
        </asp:Panel>
        
        <uc2:oLeanProjectDetails ID="oLeanProjectDetails1" runat="server" />
    </asp:Panel>

    <%--The Modal Popup codes ends here--%>
    <ajaxToolkit:ModalPopupExtender ID="MPE"
        runat="server"
        TargetControlID="EditLinkButton"
        PopupControlID="pnlModalPanel"
        CancelControlID="closeButton"
        BackgroundCssClass="modalBackground"
        DropShadow="true"
        PopupDragHandleControlID="pnlDragPanel"
        Drag="true" />
</asp:Content>

