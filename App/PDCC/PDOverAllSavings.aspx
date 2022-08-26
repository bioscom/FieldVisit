<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PDCC.master" AutoEventWireup="true" CodeFile="PDOverAllSavings.aspx.cs" Inherits="App_PDCC_PDOverAllSavings" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Src="~/App/PDCC/UserControl/PDSavings.ascx" TagPrefix="app" TagName="PDSavings" %>
<%@ Register Src="~/App/PDCC/UserControl/PDSavingsViewer.ascx" TagPrefix="app" TagName="PDSavingsViewer" %>
<%@ Register Src="~/App/PDCC/UserControl/PDSavingsViewerSummary.ascx" TagPrefix="app" TagName="PDSavingsViewerSummary" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
<%--<ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" EnablePartialRendering="true" ScriptMode="Release" />--%>

    <script type="text/javascript" src="JavaScript/fieldVisit.js"></script>

    <script lang="javascript" type="text/javascript">
        function toggleFade() {
            var behavior = $find('ctl00_SampleContent_MyAccordion_AccordionExtender');
            if (behavior) {
                behavior.set_FadeTransitions(!behavior.get_FadeTransitions());
            }
        }

        function changeAutoSize() {
            var behavior = $find('ctl00_SampleContent_MyAccordion_AccordionExtender');
            var ctrl = $get('autosize');
            if (behavior) {
                var size = 'None';
                switch (ctrl.selectedIndex) {
                    case 0:
                        behavior.get_element().style.height = 'auto';
                        size = Sys.Extended.UI.AutoSize.None;
                        break;
                    case 1:
                        behavior.get_element().style.height = '400px';
                        size = Sys.Extended.UI.AutoSize.Limit;
                        break;
                    case 2:
                        behavior.get_element().style.height = '400px';
                        size = Sys.Extended.UI.AutoSize.Fill;
                        break;
                }
                behavior.set_AutoSize(size);
            }
            if (document.focus) {
                document.focus();
            }
        }
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div style="width: 99%">
                <ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="1" Width="100%"
                    HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
                    ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40"
                    TransitionDuration="250" AutoSize="None" RequireOpenedPane="False" SuppressHeaderPostbacks="true">
                    <Panes>
                        <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                            <Header><a href="#" class="accordionLink">Update PD Overall Savings</a></Header>
                            <Content>
                                <table class="tMainBorder" style="width: 98%">
                                    <tr>
                                        <td class="cHeadTile" colspan="2">PD Savings Overall
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlMonth" runat="server" ValidationGroup="Filter" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                                <asp:ListItem Value="-1">Select Month...</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:CompareValidator ID="CompareValidatorMonth" runat="server" ControlToValidate="ddlMonth" 
                                                ErrorMessage="Select Month" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblYear" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: silver">
                                        <td colspan="2">
                                            <asp:GridView ID="grdView" runat="server" RowStyle-BackColor="White" PageSize="3" AllowPaging="true"
                                                AutoGenerateColumns="False" Width="100%" ShowHeader="false" OnPageIndexChanging="grdView_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <br />
                                                            <div style="text-align: left; background-color: ButtonFace; padding: 5px; vertical-align: middle; width: 200px">
                                                                <asp:Label ID="lbAsset" runat="server" ForeColor="Navy" Font-Bold="true" Font-Size="100%"
                                                                    ASSETID='<%# DataBinder.Eval(Container.DataItem, "ASSETID") %>'
                                                                    Text='<%# DataBinder.Eval(Container.DataItem, "ASSET") %>'></asp:Label>
                                                            </div>

                                                            <table style="width: 100%" border="0">
                                                                <tr>
                                                                    <td style="background-color: #f7d6a5">
                                                                        <asp:Label ID="lbEst" runat="server" Text="Estimated Savings" Font-Bold="true" ForeColor="Red"></asp:Label>
                                                                        <hr />
                                                                        <app:PDSavings runat="server" ID="PDSavingsEstimated" />
                                                                    </td>
                                                                    <td style="background-color: #87CEEB">
                                                                        <asp:Label ID="lbAct" runat="server" Text="Actual Savings" Font-Bold="true" ForeColor="Green"></asp:Label>
                                                                        <hr />
                                                                        <app:PDSavings runat="server" ID="PDSavingsActual" />
                                                                    </td>
                                                                    <td style="background-color:antiquewhite">
                                                                        <asp:Label ID="lbLE" runat="server" Text="Latest Est. Savings" Font-Bold="true" ForeColor="Navy"></asp:Label>
                                                                        <hr />
                                                                        <app:PDSavings runat="server" ID="PDLatestEstimate" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="100px" />
                                                        <HeaderStyle BackColor="White" Font-Size="Large" BorderStyle="Solid" HorizontalAlign="Left" />

                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                            </Content>
                        </ajaxToolkit:AccordionPane>

                        <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                            <Header><a href="" class="accordionLink">View PD Overall Savings</a></Header>
                            <Content>
                                <asp:Label runat="server" ID="lblEstimate" Text="PD Estimated Savings" Font-Bold="True" ForeColor="Red"></asp:Label>
                                <hr />
                                <app:PDSavingsViewer runat="server" ID="PDEstimatedSavings" />
                                <br />
                                <asp:Label runat="server" ID="lblActual" Text="PD Actual Savings" Font-Bold="True" ForeColor="Green"></asp:Label>
                                <hr />
                                <app:PDSavingsViewer runat="server" ID="PDActualSavings" />
                                <br />
                                <asp:Label runat="server" ID="lblLE" Text="PD Latest Estimate Savings" Font-Bold="True" ForeColor="Navy"></asp:Label>
                                <hr />
                                <app:PDSavingsViewer runat="server" ID="PDLESavingsViewer" />
                                <br />
                                <br />
                                <app:PDSavingsViewerSummary runat="server" ID="PDValue" />
                                <br />
                                <asp:Label runat="server" ID="lblCummulative" Text="PD Summary Cummulative" Font-Bold="True" ForeColor="Red"></asp:Label>
                                <hr />
                                <app:PDSavingsViewerSummary runat="server" ID="PDCummulative" />
                            </Content>
                        </ajaxToolkit:AccordionPane>

                    </Panes>
                </ajaxToolkit:Accordion>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <%--<ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender" runat="server" Enabled="True" TargetControlID="UpdatePanel1">
    </ajaxToolkit:UpdatePanelAnimationExtender>

    <asp:UpdateProgress ID="upgAjaxBloc" runat="server" DisplayAfter="100" Visible="true" DynamicLayout="true">
        <ProgressTemplate>
            <div id="IMGDIV" align="center" valign="middle" runat="server" style="position: absolute; visibility: visible; left: 50%; top: 70%; vertical-align: middle; border-color: #FFFFFF; background-color: #FFFFFF;">
                <asp:Image ID="imgAjaxWait" runat="server" ImageUrl="~/Images/ajaxRoller.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
</asp:Content>

