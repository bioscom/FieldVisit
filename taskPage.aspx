<%@ Page Title="" Language="C#" MasterPageFile="~/CBIDashboard2.master" AutoEventWireup="true" CodeFile="taskPage.aspx.cs" Inherits="taskPage" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/App/PDCC/UserControl/PDSavingsViewer.ascx" TagPrefix="uc1" TagName="PDSavingsViewer" %>
<%@ Register Src="~/App/PDCC/UserControl/PDSavingsViewerSummary.ascx" TagPrefix="uc1" TagName="PDSavingsViewerSummary" %>
<%@ Register Src="~/App/PDCC/UserControl/PDSummaryCostRedn.ascx" TagPrefix="app" TagName="PDSummaryCostRedn" %>
<%@ Register Src="~/App/PDCC/UserControl/PartsOpportunities.ascx" TagPrefix="app" TagName="PartsOpportunities" %>
<%@ Register Src="~/App/PDCC/UserControl/PDSavingsLineGraph.ascx" TagPrefix="app" TagName="PDSavingsLineGraph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" EnablePartialRendering="true" ScriptMode="Release" />
    <script src="plugins/jQuery/jQuery-2.1.3.min.js"></script>
    <script type="text/javascript">
        $(function () {
            blinkeffect('#txtblnk');
        });

        function blinkeffect(selector) {
            $(selector).fadeOut('slow', function () {
                $(this).fadeIn('slow', function () {
                    blinkeffect(this);
                });
            });
        }
    </script>

    <script type="text/javascript">
 <!--
    /****************************************************
         AUTHOR: WWW.CGISCRIPT.NET, LLC
         URL: http://www.cgiscript.net
         Use the code for FREE but leave this message intact.
         Download your FREE CGI/Perl Scripts today!
         ( http://www.cgiscript.net/scripts.htm )
    ****************************************************/
    var win = null;
    function NewWindow(mypage, myname, w, h, pos, infocus) {
        if (pos == "random") {
            myleft = (screen.width) ? Math.floor(Math.random() * (screen.width - w)) : 100; mytop = (screen.height) ? Math.floor(Math.random() * ((screen.height - h) - 75)) : 100;
        }
        if (pos == "center") {
            myleft = (screen.width) ? (screen.width - w) / 2 : 100; mytop = (screen.height) ? (screen.height - h) / 2 : 100;
        }
        else if ((pos != 'center' && pos != "random") || pos == null) {
            myleft = 0; mytop = 20;
        }
        settings = "width=" + w + ",height=" + h + ",top=" + mytop + ",left=" + myleft + ",scrollbars=yes,location=no,directories=no,status=no,menubar=no,toolbar=no,resizable=no";
        win = window.open(mypage, myname, settings);
        win.focus();
    }
    // -->
    </script>

    <asp:UpdatePanel ID="AnimationUpdatePanel" runat="server">
        <ContentTemplate>

            <!-- Main content -->
            <section class="content">
                <div class="row">
                    <!-- ./col -->
                    <div class="col-lg-3 col-xs-4">
                        <!-- small box -->
                        <div class="small-box bg-shell-active">
                            <div class="inner">
                                <h3>Cost Agenda</h3>
                                <%--<asp:LinkButton ID="lnkOnshore" CssClass="button" runat="server" Text="ONSHORE" OnClick="lnkOnshore_Click" ToolTip="View Onshore Cost Saving Performance"></asp:LinkButton></li>--%>
                                <%--<div id="menu">--%>
                                <nav id="menu">
                                    <ul>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="lnkOnshore" runat="server" Text="ONSHORE" OnClick="lnkOnshore_Click" ToolTip="View Onshore Cost Saving Performance"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="lnkOffshore" runat="server" Text="OFFSHORE" OnClick="lnkOffshore_Click" ToolTip="View Offshore Cost Saving Performance"></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="lnkPD" runat="server" Text="PD" OnClick="lnkPD_Click" ToolTip="View  PD Cost Saving Performance"></asp:LinkButton></li>
                                        </ul>

                                    </ul>
                                    <ul>
                                        <li>
                                            <asp:LinkButton ID="lnkPDDash" runat="server" Text="Performance Summary Dashboard " OnClick="lnkPDDash_Click" ToolTip="Cost Saving Performance Summary"></asp:LinkButton>
                                        </li>
                                    </ul>
                                </nav>
                                <%--</div>--%>
                                <br />
                                <br />
                            </div>

                            <div class="icon">
                                <i class="ion ion-pie-graph"></i>
                            </div>
                            <br />
                            <br />
                            <a href="Dashboard2.aspx" class="small-box-footer">Cost Agenda <i class="fa fa-arrow-circle-right"></i></a>
                        </div>
                    </div>
                    <!-- ./col -->

                    <!-- ./col -->
                    <div class="col-lg-3 col-xs-4" style="margin-left: auto; margin-right: auto">
                        <!-- small box -->
                        <div class="small-box bg-shell-active" style="margin-bottom: 0">
                            <div class="inner">
                                <h3 style="text-wrap: inherit">Cost Saving Stories</h3>

                                <br />
                                <nav id="menu">
                                    <ul>
                                        <li>
                                            <b><a href="PdccTellYourStories.aspx" class="small-box-footer">View Cost Saving Stories</a></b>
                                        </li>
                                    </ul>
                                </nav>
                            </div>
                            <div class="icon">
                                <i class="ion ion-pie-graph"></i>
                            </div>
                            <br />
                            <br />
                            <br />
                            <a href="PdccTellYourStories.aspx" class="small-box-footer">Tell your cost saving stories <i class="fa fa-arrow-circle-right"></i></a>
                        </div>
                    </div>
                    <!-- ./col -->

                    <div class="col-lg-3 col-xs-4" style="margin-left: auto; margin-right: auto">
                        <!-- small box -->
                        <div class="small-box bg-shell-active" style="margin-bottom: 0">
                            <div class="inner">
                                <marquee direction="up" onmouseover="this.stop()" onmouseout="this.start()" scrolldelay="300" style="height: 105px; width: 100%;">
                                <asp:Literal ID="lt1" runat="server"></asp:Literal></marquee>
                            </div>
                            <a href="PdccTellYourStories.aspx" class="small-box-footer">Cost Saving Projects <i class="fa fa-arrow-circle-right"></i></a>
                        </div>
                    </div>

                    <!-- ./col -->
                    <div class="col-lg-3 col-xs-4" style="margin-left: auto; margin-right: auto">
                        <!-- small box -->
                        <div class="small-box bg-shell-active" style="margin-bottom: 0">
                            <div class="inner">
                                <div style="height: 108px; width: 100%;">
                                    <h3>PD Savings</h3>
                                    <p>Performance to date</p>
                                    <div id="txtblnk">
                                        <%--<asp:Label ID="lblPDSavings" Font-Bold="True" ForeColor="Yellow" Font-Size="X-Large" runat="server"></asp:Label> <br />--%>

                                        <asp:Label ID="lblPercentagePD" Font-Bold="True" ForeColor="Red" Font-Size="X-Large" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="icon">
                                <i class="ion ion-pie-graph"></i>
                            </div>
                            <a href="PDCCIndex.aspx" class="small-box-footer">PD Savings <i class="fa fa-arrow-circle-right"></i></a>
                        </div>
                    </div>
                    <!-- ./col -->
                </div>

                <div class="row">
                    <asp:Panel runat="server" Width="99%" ID="pnlGraph">
                        <div style="width: 100%">
                            <div style="float: left; color: Black; height: 510px; overflow: auto; width: 75%; border: solid 1px silver">
                                <div style="width: 130%; margin-left:0.1em; margin-top: 0.2em">
                                    <div style="float: left;">
                                        <app:PDSavingsLineGraph runat="server" ID="LineGraph" />
                                    </div>
                                    <div style="float: left; margin-left: 0.2em">
                                        <app:PDSavingsLineGraph runat="server" ID="StackedChart" />
                                    </div>
                                </div>
                            </div>
                            <div style="float: left; width: 24%; margin-left: 5px">
                                <h3 style="padding: 0px; margin: 0px;">
                                    <a style="font: normal, 9px arial;">PD Cost Saving Stories</a>
                                </h3>
                                <asp:HyperLink ForeColor="Red" Font-Bold="true" ToolTip="Click to download Power Point template to tell your Cost Saving Stories. Let's hear your story." ID="hpkTemplate" runat="server" NavigateUrl="~/Handlers/CostSavingStories.ashx?Msg=TypeOne">*Download Cost Saving Template*</asp:HyperLink>

                                <object width="420" height="460" id="player" style="width:100%; border:solid 1px silver">
                                    <param name="movie" value="App/PDCC/CostSavingStories/CostSavingStories.swf" />
                                    <param name="allowFullScreenInteractive" value="true" />
                                    <param name="allowScriptAccess" value="always" />
                                    <embed src="App/PDCC/CostSavingStories/CostSavingStories.swf" type="application/x-shockwave-flash"
                                        allowscriptaccess="always" allowfullscreeninteractive="true" width="420" height="460"></embed>
                                </object>
                            </div>
                        </div>
                    </asp:Panel>
                </div>

                <asp:Panel runat="server" ID="pnlPDReportSummary">
                    <asp:Label runat="server" ID="Label8" Text="PD Summary Cost Reduction" Font-Bold="true" Font-Size="120%"></asp:Label>
                    <table style="width: 99%">
                        <tr>
                            <td>
                                <asp:GridView ID="grdView" runat="server" AllowPaging="True" RowStyle-BackColor="White"
                                    AutoGenerateColumns="False" PageSize="15" Width="100%" ShowHeader="false">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <br />
                                                <div style="text-align: left;">
                                                    <asp:Label ID="lbService" runat="server" ForeColor="#000066" Font-Bold="true" Font-Size="100%"
                                                        IDSERVICE='<%# DataBinder.Eval(Container.DataItem, "IDSERVICE") %>'
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "SERVICE") %>'></asp:Label>
                                                </div>
                                                <br />
                                                <app:PDSummaryCostRedn runat="server" ID="PDSummaryCostRednT" />
                                                <br />
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" />
                                            <HeaderStyle BackColor="White" Font-Size="Large" BorderStyle="Solid" HorizontalAlign="Left" />

                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                                <app:PDSummaryCostRedn runat="server" ID="PDPerformance" />
                                <br />
                                <br />
                                <app:PDSummaryCostRedn runat="server" ID="PDCostSummary" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <asp:Panel runat="server" ID="pnlSummary">
                    <table style="border: none">
                        <tr>
                            <td style="border: none">
                                <h4>
                                    <b>
                                        <asp:LinkButton ID="lblTitle" runat="server" Text=""></asp:LinkButton></b>
                                </h4>
                            </td>

                            <td style="border: none">
                                <h4>
                                    <asp:Label ID="lblOpex0" runat="server" ForeColor="Black"></asp:Label></h4>
                            </td>
                            <td style="border: none">
                                <h4>
                                    <asp:Label ID="lblOpexResult0" runat="server" ForeColor="Black"></asp:Label>|</h4>
                            </td>

                            <td style="border: none">
                                <h4>
                                    <asp:Label ID="Label4" runat="server" Text="Improvement Opportunity:" ForeColor="#0066cc"></asp:Label></h4>
                            </td>
                            <td style="border: none">
                                <h4>
                                    <asp:Label ID="lblImproved0" runat="server" ForeColor="#0066cc"></asp:Label>|</h4>
                            </td>

                            <td style="border: none">
                                <h4>
                                    <asp:Label ID="Label5" runat="server" Text="Actual Saving:" ForeColor="Green"></asp:Label></h4>
                            </td>
                            <td style="border: none">
                                <h4>
                                    <asp:Label ID="lblActual0" runat="server" ForeColor="Green"></asp:Label>|</h4>
                            </td>

                            <td style="border: none">
                                <h4>
                                    <asp:Label ID="Label6" runat="server" Text="%Saving:" ForeColor="Green"></asp:Label></h4>
                            </td>
                            <td style="border: none">
                                <h4>
                                    <asp:Label ID="lblPercentageSavings0" runat="server" ForeColor="Green"></asp:Label></h4>
                            </td>
                        </tr>
                    </table>

                    <div id="collapseOne" class="panel-collapse collapse in">
                        <div class="box-body">
                            <asp:Repeater ID="RepeaterImages" runat="server" OnItemCommand="RepeaterImages_ItemCommand">
                                <ItemTemplate>
                                    <asp:Button ID="btnAsset" ASSETID='<%# DataBinder.Eval(Container.DataItem, "ASSETID") %>' runat="server"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "ASSET") %>' ValidationGroup="vvvv" />
                                </ItemTemplate>
                            </asp:Repeater>

                            <asp:Panel ID="pnlView" runat="server">
                                <div class="panel box box-primary" style="margin-bottom: 0">
                                    <div class="box-header with-border">
                                        <table style="border: none">
                                            <%-- class="nav-justified"--%>
                                            <tr>
                                                <td style="border: none">
                                                    <h4>
                                                        <asp:LinkButton ID="lblAsset" runat="server" Font-Bold="True" Font-Size="Medium" Text=""></asp:LinkButton>
                                                    </h4>
                                                </td>
                                                <td style="border: none">
                                                    <h4>
                                                        <asp:Label ID="lblOpex" runat="server" ForeColor="Black"></asp:Label>
                                                    </h4>
                                                </td>
                                                <td style="border: none">
                                                    <h4>
                                                        <asp:Label ID="lblOpexResult" runat="server" ForeColor="Black"></asp:Label>
                                                        |</h4>
                                                </td>
                                                <td style="border: none">
                                                    <h4>
                                                        <asp:Label ID="Label1" runat="server" ForeColor="#0066cc" Text="Improvement Opportunity:"></asp:Label>
                                                    </h4>
                                                </td>
                                                <td style="border: none">
                                                    <h4>
                                                        <asp:Label ID="lblImproved" runat="server" ForeColor="#0066cc"></asp:Label>
                                                        |</h4>
                                                </td>
                                                <td style="border: none">
                                                    <h4>
                                                        <asp:Label ID="Label2" runat="server" ForeColor="Green" Text="Actual Saving:"></asp:Label>
                                                    </h4>
                                                </td>
                                                <td style="border: none">
                                                    <h4>
                                                        <asp:Label ID="lblActual" runat="server" ForeColor="Green"></asp:Label>
                                                        |</h4>
                                                </td>
                                                <td style="border: none">
                                                    <h4>
                                                        <asp:Label ID="Label3" runat="server" ForeColor="Green" Text="%Saving:"></asp:Label>
                                                    </h4>
                                                </td>
                                                <td style="border: none">
                                                    <h4>
                                                        <asp:Label ID="lblPercentageSavings" runat="server" ForeColor="Green"></asp:Label>
                                                    </h4>
                                                </td>
                                            </tr>

                                        </table>
                                    </div>
                                </div>

                                <div style="width: 100%">
                                    <div style="background-color: white; width: 60%; text-align: left">
                                        <asp:Label ID="Label10" runat="server" Font-Bold="true" ForeColor="Red" CssClass="warning" Text="Please, you may not be able to see the actual values of the items here, due to right access."></asp:Label>
                                    </div>
                                    <div style="background-color: white; width: 30%; text-align: right; float: right">
                                        <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export Full Report" />
                                        <asp:Button ID="btnSummaryExport" runat="server" OnClick="btnSummaryExport_Click" Text="Export Summary Report" />
                                    </div>
                                </div>
                                <div style="overflow: auto; background-color: white; height: 400px; width: 100%; border: solid 1px silver">
                                    <asp:GridView ID="grdViewDetails" runat="server" AutoGenerateColumns="False" AllowPaging="false" ShowHeader="true"
                                        OnPageIndexChanging="grdViewDetails_PageIndexChanging" BackColor="White" AlternatingRowStyle-BackColor="#f9f9f9" ShowFooter="true">
                                        <Columns>

                                            <asp:TemplateField HeaderText="S/No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbSNo" runat="server" ForeColor="Black"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "SERIALNO") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="10px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Opportunity">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbAsset" runat="server" ForeColor="Black"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "OPPORTUNITY") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" Width="250px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="OP ($mln)">
                                                <ItemTemplate>
                                                    <div style="text-align: right">
                                                        <asp:Label ID="lblOpex" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "OPEX") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Banked ($mln)">
                                                <ItemTemplate>
                                                    <div style="text-align: right">
                                                        <asp:Label ID="lblActualSaving" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "ACTSAVINGS") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="%age Banked">
                                                <ItemTemplate>
                                                    <div style="text-align: right">
                                                        <asp:Label ID="lblPercentageBanked" ForeColor="Black" runat="server" Text=''></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Opportunities ($mln)">
                                                <ItemTemplate>
                                                    <div style="text-align: right">
                                                        <asp:Label ID="lblImprovement" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "IMPROVEMENT") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="B&O ($mln)">
                                                <ItemTemplate>
                                                    <div style="text-align: right">
                                                        <asp:Label ID="lblBO" runat="server" ForeColor="Black" Text=''></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="25% Target Reduction($mln)">
                                                <ItemTemplate>
                                                    <div style="text-align: right">
                                                        <asp:Label ID="lblReduction" runat="server" ForeColor="Black" Text=''></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Current Gap($mln) excl. Oppor.">
                                                <ItemTemplate>
                                                    <div style="text-align: right">
                                                        <asp:Label ID="lblCurrentGap" runat="server" ForeColor="Black" Text=''></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <ItemStyle Width="100px" />
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                    <asp:HiddenField ID="iAssetIdHF" runat="server" />
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </asp:Panel>

            </section>

        </ContentTemplate>
    </asp:UpdatePanel>

    <ajaxToolkit:UpdatePanelAnimationExtender ID="AnimationUpdatePanel_UpdatePanelAnimationExtender"
        runat="server" Enabled="True" TargetControlID="AnimationUpdatePanel">
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
