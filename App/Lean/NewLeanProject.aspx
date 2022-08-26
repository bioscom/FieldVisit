<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/LeanMasterPage.master" AutoEventWireup="true" CodeFile="NewLeanProject.aspx.cs" Inherits="App_Lean_NewLeanProject" %>

<%@ Register Src="../../UserControls/userFinder/Search4LocalUser.ascx" TagName="Search4LocalUser" TagPrefix="uc4" %>
<%@ Register Src="../../UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" ScriptMode="Release">
    </ajaxToolkit:ToolkitScriptManager>

    <div style="margin-left: 6.5em; margin-top: 0.5em">
        <asp:UpdatePanel ID="uppAjaxBloc" runat="server">
            <ContentTemplate>
                <ajaxToolkit:TabContainer runat="server" ID="smtAjaxTabs" Width="80%" ActiveTabIndex="0">
                    <ajaxToolkit:TabPanel runat="server" ID="pnlBusinessInitiative" HeaderText="Awaiting Approval" Width="100%" Visible="true">
                        <HeaderTemplate>Project</HeaderTemplate>
                        <ContentTemplate>

                            <table style="width:70%">                        
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:Label ID="Label29" runat="server" CssClass="Warning" Text="***Please, enter all required fields on each tab before submitting this form."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Project Title"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ErrorMessage="Project Title is required">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTitle" runat="server" Height="50px" TextMode="MultiLine" Width="390px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Project Year:"></asp:Label>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlYear" ErrorMessage="Select Project Year" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlYear" runat="server" Width="250px">
                                            <asp:ListItem Value="-1">Select Year</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="Project Type:"></asp:Label>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlProjType" ErrorMessage="Select Project Type" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProjType" runat="server" Width="250px">
                                            <asp:ListItem Value="-1">Select Project Type</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="Department:"></asp:Label>
                                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddlDept" ErrorMessage="Select Department" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDept" runat="server" Width="250px">
                                            <asp:ListItem Value="-1">Select Department</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Function:"></asp:Label>
                                        <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlFunction" ErrorMessage="Select Function" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlFunction" runat="server" Width="250px">
                                            <asp:ListItem Value="-1">Select Function</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>

                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="pnlDistrict" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>Project Governance</HeaderTemplate>
                        <ContentTemplate>

                            <table>
                                
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Project Sponsor:"></asp:Label>
                                    </td>
                                    <td><uc4:Search4LocalUser ID="sponsor" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text="Project Champion:"></asp:Label>
                                    </td>
                                    <td><uc4:Search4LocalUser ID="champion" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Project Manager:"></asp:Label>
                                    </td>
                                    <td><uc4:Search4LocalUser ID="manager" runat="server" />
                                    </td>
                                </tr>
                            </table>

                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="pnlResourceUtilisation" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>Business Reasons</HeaderTemplate>
                        <ContentTemplate>

                            <table style="width: 75%">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="Business Case"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBuzCase" runat="server" Height="100px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" Text="Opportunity Statement"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOpportunity" runat="server" Height="70px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" Text="Goals"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtGoals" runat="server" Height="70px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>

                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="BITabPanel" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>Potential Benefit</HeaderTemplate>
                        <ContentTemplate>

                            <table>
                                <tr>
                                    <td>Cycle Time Reduction(days):<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCTR" ErrorMessage="Invalid entry!!!" ValidationExpression="^\-{0,1}\d+(.\d+){0,1}$">*</asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCTR" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="vertical-align: top">
                                    <td>Cost Reduction($) million:<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCostReduction" ErrorMessage="Invalid entry!!!" ValidationExpression="^\-{0,1}\d+(.\d+){0,1}$">*</asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCostReduction" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="vertical-align: top">
                                    <td>Production Enhancement&nbsp;(Barrel):<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtProdEnhancmt" ErrorMessage="Invalid entry!!!" ValidationExpression="^\-{0,1}\d+(.\d+){0,1}$">*</asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtProdEnhancmt" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="vertical-align: top">
                                    <td>Number:<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtNumber" ErrorMessage="Invalid entry!!!" ValidationExpression="^\-{0,1}\d+(.\d+){0,1}$">*</asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Other Benefits:</td>
                                    <td>
                                        <asp:TextBox ID="txtBenefit" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Comments:</td>
                                    <td>
                                        <asp:TextBox ID="txtPotentialBenftComments" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>

                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="grapReportTabPanel" HeaderText="Approved PPS Code" Width="100%" Visible="true">
                        <HeaderTemplate>Scope/Potential</HeaderTemplate>
                        <ContentTemplate>

                            <table style="width: 70%">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label16" runat="server" Text="In Scope:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtInScope" runat="server" Height="70px" TextMode="MultiLine" Width="470px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label17" runat="server" Text="Out Scope:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOutScope" runat="server" Height="70px" TextMode="MultiLine" Width="470px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label18" runat="server" Text="Potential Blockers"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPotential" runat="server" Height="70px" TextMode="MultiLine" Width="470px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label19" runat="server" Text="Comments:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtComments" runat="server" Height="70px" TextMode="MultiLine" Width="470px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>

                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                     <ajaxToolkit:TabPanel ID="approvalTabPanel" runat="server" HeaderText="Awaiting Approval" Width="100%" Visible="true">
                        <HeaderTemplate>Project Status</HeaderTemplate>
                        <ContentTemplate>

                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="Overall% Completion"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label25" runat="server" Font-Bold="True" Text="Start Date"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label26" runat="server" Font-Bold="True" Text="Completion Date"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label27" runat="server" Font-Bold="True" Text="% Compl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label28" runat="server" Font-Bold="True" Text="Health"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label22" runat="server" Text="Identify"></asp:Label>
                                    </td>
                                    <td>
                                        <uc2:dateControl ID="IdentifyStartDate" runat="server" />
                                    </td>
                                    <td>
                                        <uc2:dateControl ID="IdentifyEndDate" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblIdentifyPerc" runat="server"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label23" runat="server" Text="Eliminate"></asp:Label>
                                    </td>
                                    <td>
                                        <uc2:dateControl ID="EliminateStartDate" runat="server" />
                                    </td>
                                    <td>
                                        <uc2:dateControl ID="EliminateEndDate" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEliminatePerc" runat="server"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label24" runat="server" Text="Sustain"></asp:Label>
                                    </td>
                                    <td>
                                        <uc2:dateControl ID="SustainStartDate" runat="server" />
                                    </td>
                                    <td>
                                        <uc2:dateControl ID="SustainEndDate" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSustainPerc" runat="server"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>

                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                </ajaxToolkit:TabContainer>
                <table>
                    <tr>
                        <td>
                            <center>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Width="100px" />
                &nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" Width="100px" ValidationGroup="reset" />
                &nbsp;<asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" Width="100px" ValidationGroup="close" />
                        </center>
                        </td>
                    </tr>
                </table>

            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
    </div>
    <br />
</asp:Content>




                   
