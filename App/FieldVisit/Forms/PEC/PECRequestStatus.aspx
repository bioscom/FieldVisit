<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master" AutoEventWireup="true" CodeFile="PECRequestStatus.aspx.cs" Inherits="Forms_SEPCiN_PECRequestStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Src="../../UserControl/SEPCiN/AllPECRequestsPendingApproval.ascx" TagName="AllPECRequestsPendingApproval" TagPrefix="uc2" %>
<%@ Register Src="../../UserControl/SEPCiN/AllPECRequestsApproved.ascx" TagName="AllPECRequestsApproved" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="smtAjaxManager"
        CombineScripts="false" />

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

    <div style="color: Black; width: 99%">
        <asp:UpdatePanel ID="uppAjaxBloc" runat="server">
            <ContentTemplate>
                <ajaxToolkit:TabContainer runat="server" ID="smtAjaxTabs" ActiveTabIndex="0" Width="100%">
                    <ajaxToolkit:TabPanel runat="server" ID="pnlAwaiting" HeaderText="Awaiting Approval"
                        Visible="true">
                        <HeaderTemplate>
                            PEC Requests Pending Approval
                        </HeaderTemplate>
                        <ContentTemplate>

                            <uc2:AllPECRequestsPendingApproval ID="AllPECRequestsPendingApproval1" runat="server" />

                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel runat="server" ID="pnlApproved" HeaderText="Approved PPS Code"
                        Visible="true">
                        <HeaderTemplate>
                            PEC Requests Approved
                        </HeaderTemplate>
                        <ContentTemplate>

                            <uc3:AllPECRequestsApproved ID="AllPECRequestsApproved1" runat="server" />

                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Label runat="server" ID="CurrentTab" />
        <asp:Label runat="server" ID="Messages" />
    </div>
</asp:Content>

