<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CompetenceAssessment.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="App_FLBM_Settings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Src="UserControl/CompetenceControl.ascx" TagName="CompetenceControl" TagPrefix="uc2" %>
<%@ Register Src="UserControl/GroupControl.ascx" TagName="GroupControl" TagPrefix="uc3" %>
<%@ Register Src="UserControl/AssessmentCriteriaControl.ascx" TagName="AssessmentCriteriaControl" TagPrefix="uc4" %>

<%@ Register Src="UserControl/ProficiencyControl.ascx" TagName="ProficiencyControl" TagPrefix="uc5" %>
<%@ Register Src="~/App/FLBM/UserControl/CompetenceAssessorMatrix.ascx" TagPrefix="uc2" TagName="CompetenceAssessorMatrix" %>
<%@ Register Src="~/App/FLBM/UserControl/AssessorsControl.ascx" TagPrefix="uc2" TagName="AssessorsControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="server" ScriptMode="Release"></ajaxToolkit:ToolkitScriptManager>

    <div style="margin-left: 2.0em">
        <h3 style="color: black">Application Setup Management</h3>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="menu" style="margin-left: 2.0em; width: 98%; background-color:silver">
                <ul>
                    <li>
                        <asp:LinkButton ID="HyperLink1" runat="server" OnClick="btnProficiency_Click" ValidationGroup="menu">Proficiency</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton ID="HyperLink2" runat="server" OnClick="btnGroupings_Click" ValidationGroup="menu">Competence Groupings</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton ID="HyperLink3" runat="server" OnClick="btnAssessment_Click" ValidationGroup="menu">Competence Assessment Resources</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton ID="HyperLink4" runat="server" OnClick="btnChecklist_Click" ValidationGroup="menu">Knowledge and Skill Checklist Management</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton ID="HyperLink5" runat="server" OnClick="btnAssessorMngt_Click" ValidationGroup="menu">Assessors Management</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton ID="HyperLink6" runat="server" OnClick="btnChecklistRightt_Click" ValidationGroup="menu">Assessors Checklist Right Control</asp:LinkButton></li>
                </ul>
            </div>


            <div style="border: 1px solid silver; margin-left: 2.0em; width: 98%">
                <asp:MultiView ID="FormMultiView" runat="server" ActiveViewIndex="0">
                    <asp:View ID="ProficiencyTab" runat="server">
                        <br /><br />
                        <uc5:ProficiencyControl ID="ProficiencyControl1" runat="server" />
                    </asp:View>

                    <asp:View ID="CompetenceGroupingTab" runat="server">
                        <br /><br />
                        <uc3:GroupControl ID="GroupControl1" runat="server" />
                    </asp:View>

                    <asp:View ID="CompetenceAssessmentTab" runat="server">
                        <br /><br />
                        <uc2:CompetenceControl ID="CompetenceControl1" runat="server" />
                    </asp:View>

                    <asp:View ID="ChecklistTab" runat="server">
                        <br /><br />
                        <uc4:AssessmentCriteriaControl ID="AssessmentCriteriaControl1" runat="server"></uc4:AssessmentCriteriaControl>
                    </asp:View>

                    <asp:View ID="AssessorMgtTab" runat="server">
                        <br /><br />
                        <uc2:AssessorsControl runat="server" ID="AssessorsControl" />
                    </asp:View>

                    <asp:View ID="AssessorsRightTab" runat="server">
                        <br /><br />
                        <uc2:CompetenceAssessorMatrix runat="server" ID="CompetenceAssessorMatrix" />
                    </asp:View>

                </asp:MultiView>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender"
        runat="server" Enabled="True" TargetControlID="UpdatePanel1">
    </ajaxToolkit:UpdatePanelAnimationExtender>


    <asp:UpdateProgress ID="upgAjaxBloc" runat="server" DisplayAfter="100" Visible="true"
        DynamicLayout="true">
        <ProgressTemplate>
            <div id="IMGDIV" align="center" valign="middle" runat="server" style="position: absolute; visibility: visible; left: 50%; top: 70%; vertical-align: middle; border-color: #FFFFFF; background-color: #FFFFFF;">
                <asp:Image ID="imgAjaxWait" runat="server" ImageUrl="~/Images/ajaxRoller.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

