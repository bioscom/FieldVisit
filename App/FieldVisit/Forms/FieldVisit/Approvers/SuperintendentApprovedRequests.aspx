<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master"
    AutoEventWireup="true" CodeFile="SuperintendentApprovedRequests.aspx.cs" Inherits="Forms_Approvers_SuperintendentApprovedRequests" %>

<%@ Register Src="~/App/FieldVisit/UserControl/FPEC/approvedFieldVisitRequestsBySuperintendentApprover.ascx"
    TagName="approvedFieldVisitRequestsBySuperintendentApprover" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxtoolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true"
        ScriptMode="Release">
    </ajaxtoolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tSubGray">
                <tr>
                    <td class="cHeadTile">
                        Superintendent Approval Track History
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc2:approvedFieldVisitRequestsBySuperintendentApprover ID="approvedFieldVisitRequestsBySuperintendentApprover1"
                            runat="server" />
                    </td>
                </tr>
            </table>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <ajaxtoolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender"
        runat="server" Enabled="True" TargetControlID="UpdatePanel1">
    </ajaxtoolkit:UpdatePanelAnimationExtender>
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
