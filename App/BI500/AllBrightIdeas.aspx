<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BI500.master" AutoEventWireup="true" CodeFile="AllBrightIdeas.aspx.cs" Inherits="App_BI500_AllBrightIdeas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" CombineScripts="false" EnablePartialRendering="true" />

    <table class="tMainBorder" style="width: 98%">
        <tr>
            <td class="cHeadTile" >Bright Idea Register</td>
        </tr>
        <tr>
            <td>
                <ajaxToolkit:TabContainer runat="server" ID="smtAjaxTabs" ActiveTabIndex="0" Width="100%">

                    <ajaxToolkit:TabPanel runat="server" ID="pnlAwaiting" HeaderText="Ongoing Projects" Visible="true">
                        <HeaderTemplate>
                            Pending Bright Ideas
                        </HeaderTemplate>
                        <ContentTemplate>
                            <bi500:oPndgRqst ID="oPndgRqst1" runat="server"></bi500:oPndgRqst>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="pnlApproved" HeaderText="Approved Projects" Visible="true">
                        <HeaderTemplate>
                            Approved Bright Ideas
                        </HeaderTemplate>
                        <ContentTemplate>
                            <bi500:oAprdgRqst ID="oAprdgRqst1" runat="server"></bi500:oAprdgRqst>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="pnlDiscontinued" HeaderText="Rejected Projects" Visible="true">
                        <HeaderTemplate>
                            Rejected Bright Ideas
                        </HeaderTemplate>
                        <ContentTemplate>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                </ajaxToolkit:TabContainer>

            </td>
        </tr>
    </table>
    <br />
</asp:Content>

