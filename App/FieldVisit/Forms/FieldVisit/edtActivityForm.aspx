<%@ Page Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master" AutoEventWireup="true"
    CodeFile="edtActivityForm.aspx.cs" Inherits="Initiator_edtActivityForm" Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/userFinder/Search4User.ascx" TagName="Search4User" TagPrefix="uc1" %>
<%@ Register Src="~/App/FieldVisit/UserControl/FPEC/FieldVisitQuestionaire.ascx" TagName="FieldVisitQuestionaire"
    TagPrefix="uc2" %>
<%@ Register src="../../../../UserControls/dateControldisabld.ascx" tagname="dateControldisabld" tagprefix="uc3" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function ChangeCalendarView(sender, args) {
            sender._switchMode("years", false);
        }

        function checkDate(sender, args) {
            if (sender._selectedDate < new Date) {
                alert("You cannot select a day earlier than today!");
                sender._selectedDate = new Date();
                sender._textbox.set_Value(sender._selectedDate.format(sender._format));
            }
        }
    </script>
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true" ScriptMode="Release"></ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tSubGray" style="width: 98%">
                <tr>
                    <td class="cHeadLeft" colspan="2">Field Visit Form</td>
                </tr>
                <tr>
                    <td colspan="2">

                        <table>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td style="width: 150px">&nbsp;</td>
                                            <td>
                                                From:</td>
                                            <td>To:</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">Planned Dates:</td>
                                            <td>                                                
                                                <uc3:dateControldisabld ID="dtFrom" runat="server" />
                                            </td>
                                            <td>
                                                <uc3:dateControldisabld ID="dtTo" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 18px">Task Description:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                ControlToValidate="taxDesTextBox" ErrorMessage="Task Description is required">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td style="height: 18px" colspan="2">
                                                <asp:TextBox ID="taxDesTextBox" runat="server" Height="70px" TextMode="MultiLine"
                                                    Width="320px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Account to Charge:
                                            </td>
                                            <td colspan="2">
                                                <%--<asp:DropDownList ID="drpAccountToCharge" runat="server" Width="350px" AutoPostBack="True"
                                                        OnSelectedIndexChanged="drpAccountToCharge_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">Not Applicable</asp:ListItem>
                                                    </asp:DropDownList>--%>
                                                <asp:TextBox ID="txtCostCentre" runat="server" Width="320px"></asp:TextBox>
                                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender_txtCostCentre" runat="server" CompletionInterval="1" CompletionSetCount="12" EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetCompletionList" TargetControlID="txtCostCentre" UseContextKey="True">
                                                </ajaxToolkit:AutoCompleteExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Field:<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drpFacilities"
                                                ErrorMessage="Select the field to be visited" Operator="NotEqual" Type="Integer"
                                                ValueToCompare="-1">*</asp:CompareValidator>
                                            </td>
                                            <td colspan="2">
                                                <asp:DropDownList ID="drpFacilities" runat="server" AutoPostBack="True" Width="300px"
                                                    OnSelectedIndexChanged="drpFacilities_SelectedIndexChanged">
                                                    <asp:ListItem Value="-1">Select Field...</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Planner:
                                                <asp:CompareValidator ID="CompareValidator4" runat="server" 
                                                    ControlToValidate="drpPlanner" ErrorMessage="Select Planner" 
                                                    Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                                            </td>
                                            <td colspan="2">
                                                <asp:DropDownList ID="drpPlanner" runat="server" AutoPostBack="True" 
                                                    OnSelectedIndexChanged="drpPlanner_SelectedIndexChanged" Width="270px">
                                                    <asp:ListItem Value="-1">--Select Planner--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>District:
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="districtLabel" runat="server" Font-Bold="True" ForeColor="#006600"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Superintendent:
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="superintendentLabel" runat="server" Font-Bold="True" ForeColor="#006600"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Number of Personnel:<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPersonnel" ErrorMessage="No of Personnel requires numeric value" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPersonnel" ErrorMessage="No of personnel is required">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtPersonnel" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>No of Night stay:
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNight" ErrorMessage="No of Night of stay requires numeric value" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtNight" ErrorMessage="No of night of stay is required">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtNight" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>

                                </td>
                                <td>Activity Id:
                            <asp:Label ID="lblActivityId" runat="server" CssClass="Warning"></asp:Label>
                                    <br />
                                    <table>
                                        <tr>
                                            <td>General Comment:<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="commentTextBox" ErrorMessage="Please enter General Comment">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="commentTextBox" runat="server" Height="150px" TextMode="MultiLine" Width="370px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <%--<table>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                &nbsp;</td>

                                        </tr>
                                        <tr>
                                            <td>Activity Sponsor:<asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="drpSponsor" ErrorMessage="Select Activity Sponsor" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                                                &nbsp;</td>
                                            <td>
                                                <asp:DropDownList ID="drpSponsor" runat="server" Width="270px">
                                                    <asp:ListItem Value="-1">--Select Activity Sponsor--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <hr />
            <uc2:FieldVisitQuestionaire ID="FieldVisitQuestionaire1" runat="server" />
            <hr />
            <center>
                <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
                &nbsp;<asp:Button ID="closeButton" runat="server" OnClick="closeButton_Click" Text="Close"
                    ValidationGroup="close" />
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <br />
    <br />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" />
    <%--<asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="impact" />--%>
    <ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender" runat="server" Enabled="True" TargetControlID="UpdatePanel1">
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
