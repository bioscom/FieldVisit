<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CompetenceAssessment.master" AutoEventWireup="true" CodeFile="Assessment.aspx.cs" Inherits="App_FLBM_Assessment" %>

<%@ Register src="UserControl/KnowledgeControl.ascx" tagname="KnowledgeControl" tagprefix="uc3" %>
<%@ Register Src="~/App/FLBM/UserControl/KnowledgeControlEdt.ascx" TagPrefix="uc3" TagName="KnowledgeControlEdt" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-size:13pt; border-bottom:5em">
        <uc3:KnowledgeControl runat="server" ID="KnowledgeControl1" />
        <uc3:KnowledgeControlEdt runat="server" id="KnowledgeControlEdt1" />
    </div>
</asp:Content>

