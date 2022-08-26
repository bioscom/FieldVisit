<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/14DayContract.master" AutoEventWireup="true" CodeFile="KPIReport.aspx.cs" Inherits="App_Contract_KPIReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/App/Contract/UserControls/KPIReport.ascx" TagPrefix="uc2" TagName="KPIReport" %>
<%@ Register Src="~/App/Contract/UserControls/WhatWhyConsequences.ascx" TagPrefix="uc2" TagName="WhatWhyConsequences" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" ScriptMode="Release"></ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <ajaxToolkit:TabContainer ID="smtAjaxTabs" runat="server" ActiveTabIndex="0" Width="99%">

                <ajaxToolkit:TabPanel ID="pnlRequests" runat="server" HeaderText="14 Day Contract Data Input" Visible="true">
                    <HeaderTemplate>Key Performance Report</HeaderTemplate>
                    <ContentTemplate>
                        
                        <uc2:KPIReport runat="server" id="KPIReport1" />
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>

                <ajaxToolkit:TabPanel ID="pnlApprovedRequests" runat="server" HeaderText="What Why Consequences" Visible="true">
                    <HeaderTemplate>What Why Consequences</HeaderTemplate>
                    <ContentTemplate>
                        <uc2:WhatWhyConsequences runat="server" ID="WhatWhyConsequences1" />
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>

            </ajaxToolkit:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>

    <ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender" runat="server" Enabled="True" TargetControlID="UpdatePanel1">
    </ajaxToolkit:UpdatePanelAnimationExtender>

    <asp:UpdateProgress ID="upgAjaxBloc" runat="server" DisplayAfter="100" Visible="true" DynamicLayout="true">
        <ProgressTemplate>
            <div id="IMGDIV" align="center" valign="middle" runat="server" style="position: absolute; visibility: visible; left: 50%; top: 55%; vertical-align: middle; border-color: #FFFFFF; background-color: #FFFFFF;">
                <asp:Image ID="imgAjaxWait" runat="server" ImageUrl="~/Images/ajaxRoller.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

