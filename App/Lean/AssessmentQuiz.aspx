<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/LeanMasterPage.master" AutoEventWireup="true" CodeFile="AssessmentQuiz.aspx.cs" Inherits="App_Lean_AssessmentQuiz" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Src="UserControl/oLeanProjectDetails.ascx" TagName="oLeanProjectDetails" TagPrefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" EnablePageMethods="true">
    </ajaxToolkit:ToolkitScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc2:oLeanProjectDetails ID="oLeanProjectDetails1" runat="server" />
            <table style="width: 98%">
                <tr>
                    <td style="width: 450px">
                        <table style="width: 450px" class="tMainBorder">
                            <tr>
                                <td class="cHeadTile" colspan="2">Key Customers/Reviewers</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Key Customers:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtKeyCustomers" ErrorMessage="Key Customer is Required" ValidationGroup="Customer">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtKeyCustomers" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Reviewers:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReviwers" ErrorMessage="Reviewer is Required" ValidationGroup="Customer">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtReviwers" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Findings +ve:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPositive" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Findings -ve:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNegative" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" ValidationGroup="Customer" Width="100px" />
                                    &nbsp;<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" ValidationGroup="Customer" Width="100px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <div style="margin-left: 0.5em">
                            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" Width="98%">
                                <RowStyle CssClass="gRepeatItemPlate" />
                                <AlternatingRowStyle CssClass="gRepeatAlterPlate" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Assessment Questions">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CATEGORY") %>'
                                                IDCATEGORY='<%# DataBinder.Eval(Container.DataItem, "IDCATEGORY") %>' Font-Bold="true" />
                                            <br />
                                            <hr />
                                            <asp:GridView ID="subGrdView" runat="server" ShowHeader="false" AutoGenerateColumns="False" Width="100%">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Questions">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSustainability" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "XQUESTIONS") %>' IDSUSTAIN='<%# DataBinder.Eval(Container.DataItem, "IDSUSTAIN") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:RadioButtonList ID="rblYesNo" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="rblYesNo" ErrorMessage="option cannot be empty" ValidationGroup="Customer">*</asp:RequiredFieldValidator>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 450px">
                        <asp:HiddenField ID="assessmentHF" runat="server" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Customer" />
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

