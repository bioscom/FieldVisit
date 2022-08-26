<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/LeanMasterPage.master" AutoEventWireup="true" CodeFile="IES.aspx.cs" Inherits="App_Lean_IES" %>

<%@ Register Src="../../UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>

<%@ Register Src="UserControl/statusSelectorControl.ascx" TagName="statusSelectorControl" TagPrefix="uc3" %>

<%@ Register Src="../../UserControls/userFinder/Search4User.ascx" TagName="Search4User" TagPrefix="uc4" %>

<%@ Register Src="UserControl/oLeanProjectDetails.ascx" TagName="oLeanProjectDetails" TagPrefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div style="margin-left: 5em; margin-top: 1em">
        <table>
            <tr>
                <td>
                    <uc5:oLeanProjectDetails ID="oLeanProjectDetails1" runat="server" />
                    <div style="float: left">
                        <table class="tMainBorder" style="width: 300px">
                            <tr>
                                <td class="cHeadTile" colspan="2">Identify</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Kick-off Meeting held:"></asp:Label>
                                </td>
                                <td style="width: 150px">
                                    <uc3:statusSelectorControl ID="ddlIdentifyKickOffMeeting" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Project Charter Completed:"></asp:Label>
                                </td>
                                <td>
                                    <uc3:statusSelectorControl ID="ddlIdentifyProjectCharterCompleted" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="Process Walk:"></asp:Label>
                                </td>
                                <td>
                                    <uc3:statusSelectorControl ID="ddlIdentifyProcessWalk" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="VSM:"></asp:Label>
                                </td>
                                <td>
                                    <uc3:statusSelectorControl ID="ddlIdentifyVSM" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="float: left">
                        <table class="tMainBorder" style="width: 300px">
                            <tr>
                                <td class="cHeadTile" colspan="2">Eliminate</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label17" runat="server" Text="Plan in place:"></asp:Label>
                                    <br />
                                </td>
                                <td style="width: 150px">
                                    <uc3:statusSelectorControl ID="ddlEliminatePlanInPlace" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Text="Kaizen Event:"></asp:Label>
                                    <br />
                                </td>
                                <td>
                                    <uc3:statusSelectorControl ID="ddlEliminateKaizenEvent" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label16" runat="server" Text="Recommendation Signed off:"></asp:Label>
                                </td>
                                <td>
                                    <uc3:statusSelectorControl ID="ddlEliminateRecommendationSignedOff" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Text="Implement:"></asp:Label>
                                </td>
                                <td>
                                    <uc3:statusSelectorControl ID="ddlEliminateImplement" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <center>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100px" OnClick="btnSubmit_Click" />
                &nbsp;<asp:Button ID="btnClose" runat="server" Text="Close" Width="100px" OnClick="btnClose_Click" />
                    </center>

                    </div>
                    <div style="float: left">
                        <table class="tMainBorder" style="width: 300px">
                            <tr>
                                <td class="cHeadTile" colspan="2">Sustain</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text="SOP in place:"></asp:Label>
                                </td>
                                <td style="width: 150px">
                                    <uc3:statusSelectorControl ID="ddlSustainSOP" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label18" runat="server" Text="Visual Measures in place:"></asp:Label>
                                </td>
                                <td style="width: 150px">
                                    <uc3:statusSelectorControl ID="ddlSustainVisualMeasures" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="Project Handover:"></asp:Label>
                                </td>
                                <td>
                                    <uc3:statusSelectorControl ID="ddlSustainHandOver" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

