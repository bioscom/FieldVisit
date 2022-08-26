<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master"
    AutoEventWireup="true" CodeFile="SuperintendentPendingRequests.aspx.cs" Inherits="Forms_Approvers_SuperintendentPendingRequests" %>

<%@ Register Src="~/App/FieldVisit/UserControl/FPEC/fieldVisitRequestsPendingSuperintendentApproval.ascx"
    TagName="fieldVisitRequestsPendingSuperintendentApproval" TagPrefix="uc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true"
        ScriptMode="Release">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <table class="tSubGray" style="width: 100%">
                <tr>
                    <td class="cHeadTile">
                        Field Visit Requests Pending Superintendent's Approval
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc2:fieldVisitRequestsPendingSuperintendentApproval ID="fieldVisitRequestsPendingSuperintendentApproval1"
                            runat="server" />
                    </td>
                </tr>
            </table>

        </ContentTemplate>
    </asp:UpdatePanel>
    <ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender"
        runat="server" Enabled="True" TargetControlID="UpdatePanel1">
    </ajaxToolkit:UpdatePanelAnimationExtender>
    <asp:UpdateProgress ID="upgAjaxBloc" runat="server" DisplayAfter="100" Visible="true"
        DynamicLayout="true">
        <ProgressTemplate>
            <div id="IMGDIV" align="center" valign="middle" runat="server" style="position: absolute;
                visibility: visible; left: 50%; top: 70%; vertical-align: middle; border-color: #FFFFFF;
                background-color: #FFFFFF;">
                <asp:Image ID="imgAjaxWait" runat="server" ImageUrl="~/Images/ajaxRoller.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
