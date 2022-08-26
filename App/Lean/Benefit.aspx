<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/LeanMasterPage.master" AutoEventWireup="true" CodeFile="Benefit.aspx.cs" Inherits="App_Lean_Benefit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/App/Lean/UserControl/BenefitActual.ascx" TagPrefix="app" TagName="BenefitActual" %>
<%@ Register Src="UserControl/oLeanProjectDetails.ascx" TagName="oLeanProjectDetails" TagPrefix="uc2" %>
<%@ Register Src="UserControl/oLeanProjectRecomendation.ascx" TagName="oLeanProjectRecomendation" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" CombineScripts="false" EnablePartialRendering="true" />
<%--    <script lang="javascript" type="text/javascript">
        function toggleFade() {
            var behavior = $find('ctl00_SampleContent_MyAccordion_AccordionExtender');
            if (behavior) {
                behavior.set_FadeTransitions(!behavior.get_FadeTransitions());
            }
        }

        function changeAutoSize() {
            var behavior = $find('ctl00_SampleContent_MyAccordion_AccordionExtender');
            var ctrl = $get('autosize');
            if (behavior) {
                var size = 'None';
                switch (ctrl.selectedIndex) {
                    case 0:
                        behavior.get_element().style.height = 'auto';
                        size = Sys.Extended.UI.AutoSize.None;
                        break;
                    case 1:
                        behavior.get_element().style.height = '400px';
                        size = Sys.Extended.UI.AutoSize.Limit;
                        break;
                    case 2:
                        behavior.get_element().style.height = '400px';
                        size = Sys.Extended.UI.AutoSize.Fill;
                        break;
                }
                behavior.set_AutoSize(size);
            }
            if (document.focus) {
                document.focus();
            }
        }
    </script>--%>

    <div style="width:auto; margin-left: 5em; margin-right:5em">
        <uc2:oLeanProjectDetails ID="oLeanProjectDetails1" runat="server" />
        <app:BenefitActual runat="server" ID="BenefitActual" />
      
        <br />
    </div>
    <%--<ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender" runat="server" Enabled="True" TargetControlID="UpdatePanel1">
    </ajaxToolkit:UpdatePanelAnimationExtender>

    <asp:UpdateProgress ID="upgAjaxBloc" runat="server" DisplayAfter="100" Visible="true" DynamicLayout="true">
        <ProgressTemplate>
            <div id="IMGDIV" align="center" valign="middle" runat="server" style="position: absolute; visibility: visible; left: 50%; top: 70%; vertical-align: middle; border-color: #FFFFFF; background-color: #FFFFFF;">
                <asp:Image ID="imgAjaxWait" runat="server" ImageUrl="~/Images/ajaxRoller.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>

</asp:Content>

