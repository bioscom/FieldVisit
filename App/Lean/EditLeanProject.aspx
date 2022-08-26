<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/LeanMasterPage.master" AutoEventWireup="true" CodeFile="EditLeanProject.aspx.cs" Inherits="App_Lean_EditLeanProject" %>

<%@ Reference VirtualPath="~/UserControls/userFinder/Search4LocalUser.ascx" %>

<%@ Register Src="../../UserControls/userFinder/Search4LocalUser.ascx" TagName="Search4LocalUser" TagPrefix="uc4" %>
<%@ Register Src="../../UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc2" %>
<%@ Register Src="UserControl/oLeanProjectDetails.ascx" TagName="oLeanProjectDetails" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/userFinder/Search4LocalUser2.ascx" TagPrefix="uc2" TagName="Search4LocalUser2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .auto-style1 {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" ScriptMode="Release">
    </ajaxToolkit:ToolkitScriptManager>

    <div style="margin-left: 5em; margin-top: 0.5em">
        <uc3:oLeanProjectDetails ID="oLeanProjectDetails1" runat="server" />
        <asp:UpdatePanel ID="uppAjaxBloc" runat="server">
            <ContentTemplate>
                <ajaxToolkit:TabContainer runat="server" ID="smtAjaxTabs" Width="80%" ActiveTabIndex="1">
                    <ajaxToolkit:TabPanel runat="server" ID="pnlBusinessInitiative" HeaderText="Awaiting Approval" Width="100%">
                        <HeaderTemplate>Project</HeaderTemplate>
                        <ContentTemplate>
                            <table style="width:70%">
                                <tr>
                                    <td style="width: 100px">
                                        &nbsp;</td>
                                    <td>
                                        <asp:Label ID="Label29" runat="server" CssClass="Warning" Text="***Please, enter all required fields on each tab before submitting this form."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:Label ID="Label1" runat="server" Text="Project Title"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTitle" runat="server" Height="50px" TextMode="MultiLine" Width="390px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp; &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Project Year:"></asp:Label>
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
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProjType" runat="server" Width="250px">
                                            <asp:ListItem Value="-1">Select Project Type</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 120px">
                                        <asp:Label ID="Label10" runat="server" Text="Department:"></asp:Label>
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
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlFunction" runat="server" Width="250px">
                                            <asp:ListItem Value="-1">Select Function</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>DRB Members:&nbsp;</td>
                                    <td>
                                        <asp:GridView ID="grdViewDRB" runat="server" AutoGenerateColumns="False" DataKeyNames="IDPROJECT" OnDataBinding="grdViewDRB_DataBinding" OnInit="grdViewDRB_Init" 
                                            OnPageIndexChanging="grdViewDRB_PageIndexChanging" OnRowCancelingEdit="grdViewDRB_RowCancelingEdit" OnRowCommand="grdViewDRB_RowCommand" OnRowDataBound="grdViewDRB_RowDataBound" 
                                            OnRowDeleting="grdViewDRB_RowDeleting" OnRowEditing="grdViewDRB_RowEditing" OnRowUpdating="grdViewDRB_RowUpdating" ShowFooter="True" Width="100%">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="DRB Members">
                                                    <EditItemTemplate>
                                                        <uc2:Search4LocalUser2 ID="ddlDRBMember" runat="server" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <uc2:Search4LocalUser2 ID="ddlDRBMember" runat="server" />
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDRBMember" runat="server" IDDRB='<%# DataBinder.Eval(Container.DataItem, "IDDRB") %>' Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="..." ShowHeader="False">
                                                    <FooterTemplate>
                                                        <asp:LinkButton ID="lnkAddDRB" runat="server" CausesValidation="True" CommandName="Insert" Text="Add" ValidationGroup="Insert"></asp:LinkButton>
                                                    </FooterTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="..." ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDeleteDRB" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('Remove from DRB Team?')" Text="Remove from DRB Member"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Width="30%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <table id="gvEGDRB" border="1" style="width: 100%">
                                                    <tr>
                                                        <th scope="col">DRB Members</th>
                                                        <%--<th scope="col">Edit</th>--%>
                                                        <th scope="col">...</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <uc2:Search4LocalUser2 ID="ddlDRBMember" runat="server" />
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:LinkButton ID="lnkAddDRB" runat="server" CausesValidation="false" CommandName="emptyInsert" Text="Add" ValidationGroup="Update"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="pnlDistrict" HeaderText="Approved PPS Code" Width="100%">
                        <HeaderTemplate>Project Governance</HeaderTemplate>
                        <ContentTemplate>
                            <table style="width:70%">
                                <tr>
                                    <td style="width: 120px">
                                        <asp:Label ID="Label2" runat="server" Text="Project Sponsor:"></asp:Label>
                                    </td>
                                    <td>
                                        <uc4:Search4LocalUser ID="sponsor" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text="Project Champion:"></asp:Label>
                                    </td>
                                    <td>
                                        <uc4:Search4LocalUser ID="champion" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Project Manager:"></asp:Label>
                                    </td>
                                    <td>
                                        <uc4:Search4LocalUser ID="manager" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" Text="Project Coach:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:GridView ID="grdViewPrjCoach" runat="server" AutoGenerateColumns="False" DataKeyNames="IDPROJECT" 
                                            OnDataBinding="grdViewPrjCoach_DataBinding" 
                                            OnInit="grdViewPrjCoach_Init" 
                                            OnPageIndexChanging="grdViewPrjCoach_PageIndexChanging" 
                                            OnRowCancelingEdit="grdViewPrjCoach_RowCancelingEdit" 
                                            OnRowCommand="grdViewPrjCoach_RowCommand" 
                                            OnRowDataBound="grdViewPrjCoach_RowDataBound" 
                                            OnRowDeleting="grdViewPrjCoach_RowDeleting" 
                                            OnRowEditing="grdViewPrjCoach_RowEditing" 
                                            OnRowUpdating="grdViewPrjCoach_RowUpdating" ShowFooter="True" Width="100%">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Project Coach">
                                                    <EditItemTemplate>
                                                        <uc2:Search4LocalUser2 ID="ddlCoach" runat="server" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <uc2:Search4LocalUser2 ID="ddlCoach" runat="server" />
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCoach" runat="server" IDCOACH='<%# DataBinder.Eval(Container.DataItem, "IDCOACH") %>' Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="..." ShowHeader="False">
                                                    <FooterTemplate>
                                                        <asp:LinkButton ID="lnkAddCoach" runat="server" CausesValidation="True" CommandName="Insert" Text="Add" ValidationGroup="Insert"></asp:LinkButton>
                                                    </FooterTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="..." ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDeleteCoach" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('Remove Lean Coach?')" Text="Remove Lean Coach"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Width="30%" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <table id="gvEGCoach" border="1" style="width: 100%">
                                                    <tr>
                                                        <th scope="col">Project Coach</th>
                                                        <%--<th scope="col">Edit</th>--%>
                                                        <th scope="col">...</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <uc2:Search4LocalUser2 ID="ddlCoach" runat="server" />
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:LinkButton ID="lnkAddCoach" runat="server" CausesValidation="false" CommandName="emptyInsert" Text="Add" ValidationGroup="Update"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="pnlResourceUtilisation" HeaderText="Approved PPS Code" Width="100%">
                        <HeaderTemplate>Business Reasons</HeaderTemplate>
                        <ContentTemplate>
                            <table style="width: 98%">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Font-Bold="true" Text="Business Case:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBuzCase" runat="server" Height="100px" TextMode="MultiLine" Width="650px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" Font-Bold="true" Text="Opportunity Statement:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOpportunity" runat="server" Height="100px" TextMode="MultiLine" Width="650px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" Font-Bold="true" Text="Goals:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtGoals" runat="server" Height="100px" TextMode="MultiLine" Width="650px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="BITabPanel" HeaderText="Approved PPS Code" Width="100%">
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
                                    <td>Cost Reduction($) (Abs. Value):<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCostReduction" ErrorMessage="Invalid entry!!!" ValidationExpression="^\-{0,1}\d+(.\d+){0,1}$">*</asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCostReduction" runat="server"></asp:TextBox>
                                        &nbsp;<span class="auto-style1">**Please, enter absolute values</span></td>
                                </tr>

                                <tr style="vertical-align: top">
                                    <td>Production Enhancement (Barrel):<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtProdEnhancmt" ErrorMessage="Invalid entry!!!" ValidationExpression="^\-{0,1}\d+(.\d+){0,1}$">*</asp:RegularExpressionValidator>
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
                                        <asp:TextBox ID="txtBenefit" runat="server" Height="80px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Comments:</td>
                                    <td>
                                        <asp:TextBox ID="txtPotentialBenftComments" runat="server" Height="80px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                                    </td>
                                </tr>

                            </table>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="grapReportTabPanel" HeaderText="Approved PPS Code" Width="100%">
                        <HeaderTemplate>Scope/Potential</HeaderTemplate>
                        <ContentTemplate>
                            <table style="width: 98%">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label16" runat="server" Font-Bold="true" Text="In Scope:"></asp:Label>
                                    </td>
                                    
                                    <td>
                                        <asp:Label ID="Label18" runat="server" Font-Bold="true" Text="Potential Blockers"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtInScope" runat="server" Height="150px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                                    </td>
                                    
                                    <td>
                                        <asp:TextBox ID="txtPotential" runat="server" Height="150px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label17" runat="server" Font-Bold="true" Text="Out Scope:"></asp:Label>
                                    </td>
                                    
                                    <td>
                                        <asp:Label ID="Label19" runat="server" Font-Bold="true" Text="Comments:"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtOutScope" runat="server" Height="150px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                                    </td>
                                    
                                    <td>
                                        <asp:TextBox ID="txtComments" runat="server" Height="150px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel ID="approvalTabPanel" runat="server" HeaderText="Awaiting Approval" Width="100%">
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
                                    <td colspan="5"><hr /></td>
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

                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Awaiting Approval" Width="100%">
                        <HeaderTemplate>Project Team Members</HeaderTemplate>
                        <ContentTemplate>
                            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                                OnPageIndexChanging="grdView_PageIndexChanging" OnRowCommand="grdView_RowCommand"
                                OnRowCancelingEdit="grdView_RowCancelingEdit"
                                OnRowDataBound="grdView_RowDataBound" OnRowDeleting="grdView_RowDeleting"
                                OnRowEditing="grdView_RowEditing" OnRowUpdating="grdView_RowUpdating" DataKeyNames="IDPROJECT"
                                Width="60%" OnDataBinding="grdView_DataBinding" OnInit="grdView_Init">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Project Team Members">
                                        <EditItemTemplate>
                                            <uc2:Search4LocalUser2 runat="server" ID="ddlTeamMember" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <uc2:Search4LocalUser2 runat="server" ID="ddlTeamMember" />
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTeamMember" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'
                                                IDTEAM='<%# DataBinder.Eval(Container.DataItem, "IDTEAM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="..." ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                                        <%--<EditItemTemplate>
                                            <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                                Text="Update" OnClientClick="return confirm('Update?')" ValidationGroup="Update"></asp:LinkButton>
                                            <asp:ValidationSummary ID="vsUpdate" runat="server" ShowMessageBox="true" ShowSummary="false"
                                                ValidationGroup="Update" Enabled="true" HeaderText="Validation Summary..." />
                                            <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                                Text="Cancel"></asp:LinkButton>
                                        </EditItemTemplate>--%>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="True" CommandName="Insert"
                                                ValidationGroup="Insert" Text="Add"></asp:LinkButton>
                                            <%--<asp:ValidationSummary ID="vsInsert" runat="server" ShowMessageBox="true" ShowSummary="false"
                                                ValidationGroup="Insert" Enabled="true" HeaderText="Validation..." />--%>
                                        </FooterTemplate>
                                        <%--<ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="Edit"></asp:LinkButton>
                                        </ItemTemplate>--%>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="..." ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                                Text="Remove from Project Team" OnClientClick="return confirm('Remove from Project Team?')"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="30%" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>

                                </Columns>
                                <EmptyDataTemplate>
                                    <table style="width: 100%" border="1" id="gvEG">
                                        <tr>
                                            <th scope="col">Project Team Members</th>
                                            <%--<th scope="col">Edit</th>--%>
                                            <th scope="col">...</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <uc2:Search4LocalUser2 runat="server" ID="ddlTeamMember" />
                                            </td>

                                            <td colspan="2">
                                                <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="false" CommandName="emptyInsert"
                                                    Text="Add" ValidationGroup="Update"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>

                            </asp:GridView>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer>
                <table class="tSubGray" style="width: 80%">
                    <tr>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Width="100px" />
                           <%-- &nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" Width="100px" ValidationGroup="reset" />--%>
                            &nbsp;<asp:Button ID="btnClose" runat="server" Text="Close" OnClientClick="javascript:history.back();" Width="100px" ValidationGroup="close" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                        </td>
                    </tr>
                </table>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />
</asp:Content>

