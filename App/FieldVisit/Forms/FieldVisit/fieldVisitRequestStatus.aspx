<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master"
    AutoEventWireup="true" CodeFile="fieldVisitRequestStatus.aspx.cs" Inherits="fieldVisitRequestStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/App/FieldVisit/UserControl/FPEC/allRequestsPendingApproval.ascx" TagName="allRequestsPendingApproval"
    TagPrefix="uc2" %>
<%@ Register Src="~/App/FieldVisit/UserControl/FPEC/allRequestsApproved.ascx" TagName="allRequestsApproved"
    TagPrefix="uc3" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="smtAjaxManager" CombineScripts="false" />

    <script type="text/javascript">
        function PanelClick(sender, e) {
            var Messages = $get('<%=Messages.ClientID%>');
            Highlight(Messages);
        }

        function ActiveTabChanged(sender, e) {
            var CurrentTab = $get('<%=CurrentTab.ClientID%>');
            CurrentTab.innerHTML = sender.get_activeTab().get_headerText();
            Highlight(CurrentTab);
        }

        var HighlightAnimations = {};
        function Highlight(el) {
            if (HighlightAnimations[el.uniqueID] == null) {
                HighlightAnimations[el.uniqueID] = Sys.Extended.UI.Animation.createAnimation({
                    AnimationName: "color",
                    duration: 0.5,
                    property: "style",
                    propertyKey: "backgroundColor",
                    startValue: "#FFFF90",
                    endValue: "#FFFFFF"
                }, el);
            }
            HighlightAnimations[el.uniqueID].stop();
            HighlightAnimations[el.uniqueID].play();
        }

        function ToggleHidden(value) {
            $find('<%=smtAjaxTabs.ClientID%>').get_tabs()[2].set_enabled(value);
        }
    </script>

    <div style="color: Black; width: 98%">
        <asp:UpdatePanel ID="uppAjaxBloc" runat="server">
            <ContentTemplate>
                <ajaxToolkit:TabContainer runat="server" ID="smtAjaxTabs" ActiveTabIndex="0" Width="100%">
                    <ajaxToolkit:TabPanel runat="server" ID="pnlAwaiting" HeaderText="Awaiting Approval"
                        Visible="true">
                        <HeaderTemplate>
                            Requests Pending Approval</HeaderTemplate>
                        <ContentTemplate>
                                        <uc2:allRequestsPendingApproval ID="allRequestsPendingApproval1" runat="server" />
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel runat="server" ID="pnlApproved" HeaderText="Approved PPS Code"
                        Visible="true">
                        <HeaderTemplate>
                            Requests Approved</HeaderTemplate>
                        <ContentTemplate>
                            <%--<table class="tSubGray" style="width: 100%">
                                <tr>
                                    <td>--%>
                                        <uc3:allRequestsApproved ID="allRequestsApproved1" runat="server" />
                                    <%--</td>
                                </tr>
                            </table>--%>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="Approved PPS Code"
                        Visible="true">
                        <HeaderTemplate>
                            Requests Not Approved</HeaderTemplate>
                        <ContentTemplate>
                            <%--<table class="tSubGray" style="width: 100%">
                                <tr>
                                    <td>--%>
                                        
                                        <uc3:allRequestsApproved ID="allRequestsApproved2" runat="server" />
                                        
                                    <%--</td>
                                </tr>
                            </table>--%>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="TabPanel2" HeaderText="Approved PPS Code"
                        Visible="true">
                        <HeaderTemplate>
                            Requests Reschedule</HeaderTemplate>
                        <ContentTemplate>
                            <%--<table class="tSubGray" style="width: 100%">
                                <tr>
                                    <td>--%>
                                        
                                        <uc3:allRequestsApproved ID="allRequestsApproved3" runat="server" />
                                        
                                    <%--</td>
                                </tr>
                            </table>--%>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    

                </ajaxToolkit:TabContainer>
            </ContentTemplate>


        </asp:UpdatePanel>
        <asp:Label runat="server" ID="CurrentTab" />
        <asp:Label runat="server" ID="Messages" />
    </div>
</asp:Content>
