<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master" AutoEventWireup="true" CodeFile="oPendingFieldVisitRequest.aspx.cs" Inherits="oPendingFieldVisitRequest" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<%@ Register Src="~/App/FieldVisit/UserControl/FPEC/fieldVisitRequestsPendingMyApproval.ascx" tagname="fieldVisitRequestsPendingMyApproval" tagprefix="uc2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true" ScriptMode="Release"></ajaxToolkit:ToolkitScriptManager>
    
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table class="tSubGray" style="width:100%">
            <tr>
                <td class="cHeadTile">
                    Field Visit Requests Pending My Approval  </td>
            </tr>
            <tr>
                <td>
                    <uc2:fieldVisitRequestsPendingMyApproval ID="fieldVisitRequestsPendingMyApproval1" runat="server" />
                </td>
            </tr>
        </table>
        
    </ContentTemplate>
    </asp:UpdatePanel>
    
    <ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender" runat="server" Enabled="True" TargetControlID="UpdatePanel1">
    </ajaxToolkit:UpdatePanelAnimationExtender>

    <asp:UpdateProgress ID="upgAjaxBloc" runat="server" DisplayAfter="100" Visible="true" DynamicLayout="true">
        <ProgressTemplate>
            <div id="IMGDIV" align="center" valign="middle" runat="server" style="position:absolute; visibility: visible; 
                left: 50%; top: 70%;vertical-align:middle; border-color: #FFFFFF; background-color: #FFFFFF;">
                <asp:Image ID="imgAjaxWait" runat="server" ImageUrl="~/Images/ajaxRoller.gif"/>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>