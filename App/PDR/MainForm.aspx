<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPagePDR.master" AutoEventWireup="true" CodeFile="MainForm.aspx.cs" Inherits="App_PDR_MainForm" %>

<%@ Register Src="UserControl/HSSE.ascx" TagName="HSSE" TagPrefix="uc2" %>
<%@ Register Src="UserControl/PTWSummary.ascx" TagName="PTWSummary" TagPrefix="uc3" %>
<%@ Register Src="UserControl/POB.ascx" TagName="POB" TagPrefix="uc4" %>
<%@ Register Src="UserControl/MeterStatus.ascx" TagName="MeterStatus" TagPrefix="uc5" %>
<%@ Register Src="UserControl/AlarmRate.ascx" TagName="AlarmRate" TagPrefix="uc6" %>
<%@ Register Src="UserControl/WellTest.ascx" TagName="WellTest" TagPrefix="uc7" %>
<%@ Register Src="UserControl/TechnicalIntegrity.ascx" TagName="TechnicalIntegrity" TagPrefix="uc8" %>
<%@ Register Src="UserControl/CathodicProtection.ascx" TagName="CathodicProtection" TagPrefix="uc9" %>
<%@ Register Src="UserControl/AGOStatus.ascx" TagName="AGOStatus" TagPrefix="uc10" %>
<%@ Register Src="UserControl/GeneratorAirCompressorStatus.ascx" TagName="GeneratorAirCompressorStatus" TagPrefix="uc11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
    <script type="text/javascript">

        function uploadStarted() {
            $get("imgDisplay1").style.display = "none";
        }

        function uploadStarted2() {
            $get("imgDisplay2").style.display = "none";
        }

        function uploadStarted3() {
            $get("imgDisplay3").style.display = "none";
        }

        function uploadComplete(sender, args) {
            var imgDisplay = $get("imgDisplay1");
            imgDisplay.src = "images/loader.gif";
            imgDisplay.style.cssText = "";

            var img = new Image();

            img.onload = function () {
                imgDisplay.style.cssText = "height:100px;width:100px";
                imgDisplay.src = img.src;

            };

            img.src = "<%=ResolveUrl(UploadFolderPath) %>" + args.get_fileName();

        }

        function uploadComplete2(sender, args) {
            var imgDisplay = $get("imgDisplay2");
            imgDisplay.src = "images/loader.gif";
            imgDisplay.style.cssText = "";

            var img = new Image();

            img.onload = function () {
                imgDisplay.style.cssText = "height:100px;width:100px";
                imgDisplay.src = img.src;

            };

            img.src = "<%=ResolveUrl(UploadFolderPath) %>" + args.get_fileName();

        }

        function uploadComplete3(sender, args) {
            var imgDisplay = $get("imgDisplay3");
            imgDisplay.src = "images/loader.gif";
            imgDisplay.style.cssText = "";

            var img = new Image();

            img.onload = function () {
                imgDisplay.style.cssText = "height:100px;width:100px";
                imgDisplay.src = img.src;

            };

            img.src = "<%=ResolveUrl(UploadFolderPath) %>" + args.get_fileName();

        }

    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="rightColumn" runat="Server">
    <div>
        <div style="float: left; width: 200px; background-color: #ddf; border-right: solid 1px gray">
            <asp:TreeView ID="mnuTreeView" runat="server" DataSourceID="XmlMenuDataSource" OnSelectedNodeChanged="mnuTreeView_SelectedNodeChanged" ImageSet="Arrows" ExpandDepth="1" ShowCheckBoxes="All" ShowLines="True">
                <ParentNodeStyle Font-Bold="False" />
                <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD"
                    HorizontalPadding="0px" VerticalPadding="0px" />
                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"
                    HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                <DataBindings>
                    <asp:TreeNodeBinding DataMember="MenuItem" TextField="TITLE" />
                </DataBindings>
            </asp:TreeView>
            <asp:XmlDataSource ID="XmlMenuDataSource" runat="server" EnableCaching="False" TransformFile="~/CSS/TransformXSLT.xslt" XPath="MenuItems/MenuItem" />

        </div>
        <div style="color: Black; margin-left: 5px; margin-right: 2px; margin-top: 5px; float: left; width: 950px">
            <%--</ContentTemplate>
        </asp:UpdatePanel>
            <asp:Label runat="server" ID="CurrentTab" />
            <asp:Label runat="server" ID="Messages" />--%>
            <div style="width: 100%; height: 2.5em">
                <h2>
                    <asp:Label ID="lblAssetDistrict" runat="server"></asp:Label>
                    &nbsp;Production Daily Report</h2>
            </div>
            <div style="width: 100%; height: 1.5em">
                <asp:Label ID="lblDate" runat="server" Font-Bold="True"></asp:Label>
            </div>
            <asp:Panel ID="pnlForm" runat="server">

                <ajaxToolkit:TabContainer runat="server" ID="smtAjaxTabs" Width="99%" ActiveTabIndex="0">
                    <ajaxToolkit:TabPanel runat="server" ID="pnlBusinessInitiative" HeaderText="Awaiting Approval" Width="100%" Visible="true">
                        <HeaderTemplate>HSSE/Goal Zero</HeaderTemplate>
                        <ContentTemplate>
                            <uc2:HSSE ID="HSSE1" runat="server"></uc2:HSSE>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="pnlDistrict" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>PTW Summary</HeaderTemplate>
                        <ContentTemplate>
                            <uc3:PTWSummary ID="PTWSummary1" runat="server"></uc3:PTWSummary>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="pnlResourceUtilisation" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>POB</HeaderTemplate>
                        <ContentTemplate>
                            <uc4:POB ID="POB1" runat="server"></uc4:POB>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                </ajaxToolkit:TabContainer>
                <%--</ContentTemplate>
        </asp:UpdatePanel>
            <asp:Label runat="server" ID="CurrentTab" />
            <asp:Label runat="server" ID="Messages" />--%>

                <table class="tMainBorder" style="width: 99%">
                    <tr>
                        <td class="cHeadTile">DPR Snap Shot 1</td>
                    </tr>
                    <tr>
                        <td>
                            <%--<asp:Image ID="imgSnapShot1" runat="server" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img id="imgDisplay1" alt="" src="" style="display: none" />
                            <ajaxToolkit:asyncfileupload onclientuploadcomplete="uploadComplete" runat="server" id="SnapShot1"
                                width="400px" uploaderstyle="Modern" completebackcolor="White" uploadingbackcolor="#CCFFFF"
                                throbberid="imgLoader1" onuploadedcomplete="FileUploadComplete" onclientuploadstarted="uploadStarted" />

                            <asp:Image ID="imgLoader1" runat="server" ImageUrl="~/images/loader.gif" /><br />
                            <br />
                            <%--<asp:FileUpload ID="flSnapShot1" runat="server" />
                            &nbsp;<asp:Label ID="statusLabel1" runat="server" CssClass="Warning"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="cHeadTile">DPR Snap Shot 2</td>
                    </tr>
                    <tr>
                        <td>
                            <%--<asp:Image ID="imgSnapShot2" runat="server" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img id="imgDisplay2" alt="" src="" style="display: none" />
                            <ajaxToolkit:asyncfileupload onclientuploadcomplete="uploadComplete2" runat="server" id="SnapShot2"
                                width="400px" uploaderstyle="Modern" completebackcolor="White" uploadingbackcolor="#CCFFFF"
                                throbberid="imgLoader2" onuploadedcomplete="FileUploadComplete2" onclientuploadstarted="uploadStarted2" />

                            <asp:Image ID="imgLoader2" runat="server" ImageUrl="~/images/loader.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td class="cHeadTile">DPR Snap Shot 3</td>
                    </tr>
                    <tr>
                        <td>
                            <%--<asp:Image ID="imgSnapShot3" runat="server" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img id="imgDisplay3" alt="" src="" style="display: none" />
                            <ajaxToolkit:asyncfileupload onclientuploadcomplete="uploadComplete3" runat="server" id="SnapShot3"
                                width="400px" uploaderstyle="Modern" completebackcolor="White" uploadingbackcolor="#CCFFFF"
                                throbberid="imgLoader3" onuploadedcomplete="FileUploadComplete3" onclientuploadstarted="uploadStarted3" />

                            <asp:Image ID="imgLoader3" runat="server" ImageUrl="~/images/loader.gif" />
                        </td>
                    </tr>
                </table>
                <ajaxToolkit:TabContainer runat="server" ID="TabContainer1" Width="99%" ActiveTabIndex="0">
                    <ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="Awaiting Approval" Width="100%" Visible="true">
                        <HeaderTemplate>Meter Startus</HeaderTemplate>
                        <ContentTemplate>
                            <uc5:MeterStatus ID="MeterStatus1" runat="server"></uc5:MeterStatus>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="TabPanel2" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>Alarm Rate</HeaderTemplate>
                        <ContentTemplate>
                            <uc6:AlarmRate ID="AlarmRate1" runat="server"></uc6:AlarmRate>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="TabPanel3" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>Well Test &amp; Sampling Status</HeaderTemplate>
                        <ContentTemplate>
                            <uc7:WellTest ID="WellTest1" runat="server"></uc7:WellTest>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="TabPanel4" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>Technical Integrity</HeaderTemplate>
                        <ContentTemplate>
                            <uc8:TechnicalIntegrity ID="TechnicalIntegrity1" runat="server" />
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="TabPanel5" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>Cathodic Protection</HeaderTemplate>
                        <ContentTemplate>
                            <uc9:CathodicProtection ID="CathodicProtection1" runat="server" />
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="TabPanel6" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>AGO Status/Logistics</HeaderTemplate>
                        <ContentTemplate>
                            <uc10:AGOStatus ID="AGOStatus1" runat="server" />
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="TabPanel7" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>Generator/Air Compressor Status</HeaderTemplate>
                        <ContentTemplate>
                            <uc11:GeneratorAirCompressorStatus ID="GeneratorAirCompressorStatus1" runat="server" />
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                </ajaxToolkit:TabContainer>

                <table class="tMainBorder" style="width: 99%">
                    <tr>
                        <td class="cHeadTile">Highlights</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtHighlights" runat="server" Height="150px" TextMode="MultiLine" Width="930px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="cHeadTile">Lowlights</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtLowlights" runat="server" Height="150px" TextMode="MultiLine" Width="930px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="cHeadTile">Look ahead</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtLookahead" runat="server" Height="150px" TextMode="MultiLine" Width="930px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HiddenField ID="lReportIdHF" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div>
                                <div style="float: left">
                                    <asp:Button ID="btnPreview" runat="server" Text="Submit" Width="100px" OnClick="btnPreview_Click" />
                                </div>
                                <div style="float: right">
                                    <asp:Button ID="btnBroadcast" runat="server" Text="Broad Cast" Width="100px" OnClick="btnBroadcast_Click" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>

