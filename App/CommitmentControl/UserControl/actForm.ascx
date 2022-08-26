<%@ Control Language="C#" AutoEventWireup="true" CodeFile="actForm.ascx.cs" Inherits="App_CommitmentControl_UserControl_actForm" %>
<%--<%@ Register Src="SPDC.ascx" TagName="SPDC" TagPrefix="uc2" %>
<%@ Register Src="Snepco.ascx" TagName="Snepco" TagPrefix="uc3" %>--%>

<%--<%@ Register Src="InputUpdateCommitmentDetailsUpdt.ascx" TagName="InputUpdateCommitmentDetailsUpdt" TagPrefix="uc5" %>--%>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="InputUpdateCommitmentDetails.ascx" TagName="InputUpdateCommitmentDetails" TagPrefix="uc4" %>
<%@ Register Src="~/App/CommitmentControl/UserControl/Snepco.ascx" TagPrefix="uc3" TagName="Snepco" %>
<%@ Register Src="~/App/CommitmentControl/UserControl/SPDC.ascx" TagPrefix="uc2" TagName="SPDC" %>
<%@ Register Src="~/App/CommitmentControl/UserControl/oDocsUpload.ascx" TagPrefix="uc2" TagName="oDocsUpload" %>
<%@ Register Src="~/App/CommitmentControl/UserControl/oEmailsUpload.ascx" TagPrefix="uc2" TagName="oEmailsUpload" %>

<style>
    #example .demo-container {
        min-height: 203px;
        max-width: 900px;
        width: 700px;
    }

    .demo-content {
        display: inline-block;
        *display: inline;
        zoom: 1;
    }

    .multiPage {
        display: inline-block;
        *display: inline;
        margin-left:auto;
        zoom: 1;
    }

    .demo-container .RadTabStrip.rtsHorizontal.rtsBottom {
        margin-top: -5px;
    }

    .demo-container .RadTabStrip.rtsVertical.rtsLeft {
        margin-right: -10px;
    }

    .demo-container .RadTabStrip.rtsVertical.rtsRight {
        margin-left: -10px;
    }

    * html .demo-container div.RadTabStripVertical .rtsLevel {
        width: 93px;
    }

    .demo-container img {
        display: block;
    }

    .demo-container .rtsLevel.rtsCenter {
        height: 36px;
    }
</style>


<table style="width:100%">
    <tr>
        <td style="width:150px">Organisation Unit:<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="ddlOU"
            Display="Dynamic" ErrorMessage="Select Organisation Unit" CssClass="validator" ValidationGroup="MainForm">*</asp:RequiredFieldValidator>
        </td>
        <td>
            <telerik:RadComboBox RenderMode="Lightweight" ID="ddlOU" Font-Size="9pt" ValidationGroup="options" AutoPostBack="true" runat="server" Width="200px" EmptyMessage="Choose OU" Skin="Office2010Silver">
            </telerik:RadComboBox>
        </td>
    </tr>
</table>

<br />

<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
    <div class="demo-container no-bg size-narrow">
        <div class="demo-content">

            <telerik:RadTabStrip RenderMode="Lightweight" runat="server" ID="RadTabStrip1" Orientation="VerticalLeft" Width="200px" SelectedIndex="0" MultiPageID="RadMultiPage1" Skin="Glow">
                <Tabs>
                    <telerik:RadTab Text="Commitment">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Activity Details">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Attachments">
                    </telerik:RadTab>
                    <%--<telerik:RadTab Text="Email Evidence">
                    </telerik:RadTab>--%>
                </Tabs>
            </telerik:RadTabStrip>

            <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="multiPage" Width="800px">
                <telerik:RadPageView runat="server" ID="RadPageView1">
                    <asp:Panel ID="pnlSPDC" runat="server">
                        <uc2:SPDC ID="SPDC1" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="pnlSnepco" runat="server">
                        <uc3:Snepco ID="Snepco1" runat="server" />
                    </asp:Panel>
                </telerik:RadPageView>

                <telerik:RadPageView runat="server" ID="RadPageView2">
                    <uc4:InputUpdateCommitmentDetails ID="InputUpdateCommitmentDetails1" runat="server" />
                </telerik:RadPageView>

                <telerik:RadPageView runat="server" ID="RadPageView3">
                    <uc2:oDocsUpload runat="server" ID="oDocsUpload" />
                </telerik:RadPageView>

                <%--<telerik:RadPageView runat="server" ID="RadPageView4">
                    <uc2:oEmailsUpload runat="server" ID="oEmailsUpload" />
                </telerik:RadPageView>--%>
            </telerik:RadMultiPage>

        </div>
    </div>
</telerik:RadAjaxPanel>

<asp:HiddenField ID="CommitmentHF" runat="server" />

