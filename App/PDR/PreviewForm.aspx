<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPagePDR.master" AutoEventWireup="true" CodeFile="PreviewForm.aspx.cs" Inherits="App_PDR_PreviewForm" %>

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

<%@ Register Src="../../UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
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

            <div style="width: 100%; height: 2.5em">
                <h2>
                    <asp:Label ID="lblAssetDistrict" runat="server"></asp:Label>
                    &nbsp;Production Daily Report</h2>
            </div>
            <%--<div style="width: 100%; height: 1.5em">
                
                <asp:Label ID="lblDate" runat="server" Font-Bold="True"></asp:Label>
            </div>--%>
            <table>
                <tr>
                    <td>

                        <uc12:dateControl ID="dateControl1" runat="server" />

                    </td>
                    <td>

                        <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />

                    </td>
                </tr>
            </table>

            <table class="tMainBorder" style="width: 99%">
                <tr>
                    <td class="cHeadTile">HSSE/Goal Zero</td>
                </tr>
                <tr>
                    <td>
                        <uc2:HSSE ID="HSSE1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="cHeadTile">PTW Summary</td>
                </tr>
                <tr>
                    <td>
                        <uc3:PTWSummary ID="PTWSummary1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="cHeadTile">POB</td>
                </tr>
                <tr>
                    <td>
                        <uc4:POB ID="POB1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="cHeadTile">DPR Snap Shot 1</td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="imgSnapShot1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="cHeadTile">DPR Snap Shot 2</td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="imgSnapShot2" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="cHeadTile">DPR Snap Shot 3</td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="imgSnapShot3" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="cHeadTile">Meter Status</td>
                </tr>
                <tr>
                    <td>

                        <uc5:MeterStatus ID="MeterStatus1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="cHeadTile">Alarm Rate</td>
                </tr>
                <tr>
                    <td>
                        <uc6:AlarmRate ID="AlarmRate1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="cHeadTile">Well Test</td>
                </tr>
                <tr>
                    <td>
                        <uc7:WellTest ID="WellTest1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="cHeadTile">Technical Integrity</td>
                </tr>
                <tr>
                    <td>
                        <uc8:TechnicalIntegrity ID="TechnicalIntegrity1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="cHeadTile">Cathodic Protection</td>
                </tr>
                <tr>
                    <td>

                        <uc9:CathodicProtection ID="CathodicProtection1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="cHeadTile">AGO Status</td>
                </tr>
                <tr>
                    <td>
                        <uc10:AGOStatus ID="AGOStatus1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="cHeadTile">Genrator/Air Compressor</td>
                </tr>
                <tr>
                    <td>
                        <uc11:GeneratorAirCompressorStatus ID="GeneratorAirCompressorStatus1" runat="server" />
                    </td>
                </tr>
            </table>

            <br />
        </div>
    </div>
</asp:Content>

