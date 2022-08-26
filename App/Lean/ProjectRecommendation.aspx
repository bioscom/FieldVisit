<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/LeanMasterPage.master" AutoEventWireup="true" CodeFile="ProjectRecommendation.aspx.cs" Inherits="App_Lean_ProjectRecommendation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Src="UserControl/oLeanProjectDetails.ascx" TagName="oLeanProjectDetails" TagPrefix="uc2" %>
<%@ Register Src="../../UserControls/dateControl.ascx" TagName="dateControl" TagPrefix="uc3" %>
<%@ Register Src="UserControl/statusSelectorControl.ascx" TagName="statusSelectorControl" TagPrefix="uc4" %>
<%@ Register Src="../../UserControls/userFinder/Search4User.ascx" TagName="Search4User" TagPrefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">

        .auto-style1 {
            color: red;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" ScriptMode="Release" />
    <uc2:oLeanProjectDetails ID="oLeanProjectDetails1" runat="server" />
    <asp:LinkButton ID="EditLinkButton" runat="server" OnClick="EditLinkButton_Click" ValidationGroup="Recommendation">Add New Recommendation</asp:LinkButton>
    &nbsp;
    <asp:LinkButton ID="btnImprvRecommendation" runat="server" OnClick="btnImprvRecommendation_Click" ValidationGroup="xxx">Upload Improvement Recommendation</asp:LinkButton>
    <asp:Panel ID="pnlUpload" runat="server">

        <table cellpadding="2" cellspacing="0" class="tSubGray" style="width: 750px">
            <tr>
                <td class="cHeadLeft" colspan="2">Excel Improvement Recommendation Data Bulk Upload</td>
            </tr>
            <tr>
                <td>Use the Browse button to locate the Excel File containing your improvement recommendations Data on your Computer.
                    <br />
                    This MUST match the format of the Excel Template file provided here.<br />
                    See Sample data entry format for Improvement Recommendation
                    <asp:Image ID="Image2" runat="server" Height="20px" ImageUrl="~/Images/iGreenArrow.png" Width="40px" />
                    <br />
                    Ensure your file for upload, has exact sample data format.</td>
                <td>
                    <ul>
                        <li><asp:HyperLink ID="hpkSample" runat="server">Sample Improvement Recommendation</asp:HyperLink></li>
                        <li><asp:HyperLink ID="hpkFunction" runat="server">Functions</asp:HyperLink></li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td class="cTextCenta" colspan="2">
                    <asp:FileUpload ID="FUpBulkExcel" runat="server" TabIndex="3" Width="300px" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="FUpBulkExcel" Display="None" ErrorMessage="Browse for Value Stream Data Excel File" ValidationGroup="load">*</asp:RequiredFieldValidator>
                    &nbsp;<asp:Button ID="cmdUpload" runat="server" OnClick="cmdUpload_Click" Text="Upload File" ValidationGroup="load" />
                    &nbsp;<asp:Button ID="btnClose" runat="server" Text="Close" Width="100px" ValidationGroup="close" OnClick="btnClose_Click" />
                    &nbsp;<asp:ValidationSummary ID="VsmCreateUser" runat="server" BackColor="LightSkyBlue" BorderColor="MediumBlue" BorderStyle="Ridge" BorderWidth="3px" Font-Bold="True" Font-Names="Tahoma" HeaderText="!   In-Complete Specification  !" Height="12px" ShowMessageBox="True" ShowSummary="False" Width="159px" ValidationGroup="load" />
                </td>
            </tr>
        </table>

    </asp:Panel>
    &nbsp;&nbsp;
    <%--<ItemStyle Width="250px" />--%>
    <table class="tMainBorder" style="width:120%">
        <tr>
            <td class="cHeadTile">Project Improvement Recommendations</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdGridView" runat="server" AllowPaging="True"
                    AutoGenerateColumns="False" OnLoad="grdGridView_Load"
                    OnPageIndexChanging="grdGridView_PageIndexChanging"
                    OnRowCommand="grdGridView_RowCommand"
                    OnSelectedIndexChanged="grdGridView_SelectedIndexChanged" PageSize="20"
                    Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRecommendation" CommandArgument="<%# Container.DisplayIndex %>"
                                    RECOMMENDATIONID='<%# DataBinder.Eval(Container.DataItem, "RECOMMENDATIONID") %>'
                                    IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>' OnClick="lnkEdit_Click" ValidationGroup="Recommendation">Update</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Recommendations" SortExpression="RECOMMENDATION">
                            <ItemTemplate>
                                <asp:Label ID="labelRecommendations" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RECOMMENDATION") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="400px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Function" SortExpression="FUNCTION">
                            <ItemTemplate>
                                <asp:Label ID="labelFunction" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FUNCTION") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action Function" SortExpression="ACTIONFUNCTIONFUNCTION">
                            <ItemTemplate>
                                <asp:Label ID="lblActionFunction" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIONFUNTIONFUNCTION") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action Party" SortExpression="ACTIONPARTYFUNCTION">
                            <ItemTemplate>
                                <asp:Label ID="lblActionParty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIONPARTYFUNCTION") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Target Date" SortExpression="TARGETDATE">
                            <ItemTemplate>
                                <asp:Label ID="labelTargetDater" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TARGETDATE") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Sponsor Comment" SortExpression="SPONSORCOMMENT">
                            <ItemTemplate>
                                <asp:Label ID="lblSponsor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SPONSOR_COMMENT") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Champion Comment" SortExpression="CHAMPIONCOMMENT">
                            <ItemTemplate>
                                <asp:Label ID="labelChampion" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CHAMPION_COMMENT") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status" SortExpression="STATUS">
                            <ItemTemplate>
                                <asp:Label ID="labelStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'
                                    STATUS='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Cycle Time Reduction(days)">
                            <ItemTemplate>
                                <asp:Label ID="labelCycleTimeReduction" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CTREDUCTION") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Cost Reduction($) million">
                            <ItemTemplate>
                                <asp:Label ID="labelCostReduction" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COSTREDUCTION") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Production Enhancement (Barrel)">
                            <ItemTemplate>
                                <asp:Label ID="labelProductionEnhancement" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PRODUCTIONBARREL") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Number*">
                            <ItemTemplate>
                                <asp:Label ID="labelNumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NUMBERRS") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Benefits">
                            <ItemTemplate>
                                <asp:Label ID="labelBenefits" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OTHERBENEFITS") %>'></asp:Label>
                            </ItemTemplate>
                            <%--<ItemStyle Width="250px" />--%>
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Comments">
                            <ItemTemplate>
                                <asp:Label ID="labelComments" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMMENTS") %>'></asp:Label>
                            </ItemTemplate>
                            <%--<ItemStyle Width="250px" />--%>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRecommendation" CommandArgument="<%# Container.DisplayIndex %>"
                                    RECOMMENDATIONID='<%# DataBinder.Eval(Container.DataItem, "RECOMMENDATIONID") %>'
                                    IDPROJECT='<%# DataBinder.Eval(Container.DataItem, "IDPROJECT") %>' OnClick="lnkDelete_Click" ValidationGroup="Recommendation">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>

    <%--The Modal Popup codes ends here--%>
    <asp:Panel ID="pnlModalPanel" runat="server" Style="display:none;" CssClass="modalPopup" Width="826px">
        <asp:Panel ID="pnlDragPanel" runat="server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black">
            +
        </asp:Panel>
        <table class="tMainBorder" style="width:99%">
            <tr>
                <td class="cHeadTile" colspan="4">Add New Recommentation</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Recommendation:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtRecommendation" ErrorMessage="Recommendation is required">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtRecommendation" runat="server" Height="60px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Sponsor's Comments:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSponsorComment" runat="server" Height="60px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Function:"></asp:Label>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlFunction" ErrorMessage="Please select function" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                </td>
                <td>
                    <asp:DropDownList ID="ddlFunction" runat="server" Width="250px">
                        <asp:ListItem Value="-1">Select Function...</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Champion's Comments:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtChampionComment" runat="server" Height="60px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Action Party:"></asp:Label>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlActionParty" ErrorMessage="Please select Action Party" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                </td>
                <td>
                    <asp:DropDownList ID="ddlActionParty" runat="server" Width="250px">
                        <asp:ListItem Value="-1">Select Action Party...</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Target Date:"></asp:Label>
                    </td>
                <td>
                    <uc3:dateControl ID="targetDate" runat="server" />
                </td>
            </tr>
            <%--<tr>
                <td>&nbsp;</td>
                <td><%--<uc5:Search4User ID="ActionParty" runat="server" /></td>
                <td rowspan="2">
                    <br />
                </td>
                <td rowspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>--%>
            <tr>
                <td>
                    <asp:Label ID="Label15" runat="server" Text="Action Function:"></asp:Label>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddlActionFunction" ErrorMessage="Please select Action Function" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                </td>
                <td>
                    <asp:DropDownList ID="ddlActionFunction" runat="server" Width="250px">
                        <asp:ListItem Value="-1">Select Action Function...</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp; &nbsp;</td>
                <td>&nbsp; &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                   <b>Potential Benefit</b><hr /></td>
            </tr>
            <tr>
                <td colspan="4">
                    <table>
                         <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Cycle Time Reduction(days):"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCTR" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="Cost Reduction($)  (Abs. Value):"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCostReduction" runat="server"></asp:TextBox>
                    <span class="auto-style1">**Enter absolute values</span></td>
            </tr>

            <tr style="vertical-align: top">
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Production Enhancement (Barrel):"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProdEnhancmt" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="Number:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
                    </table>
                </td>
            </tr>
           
            <tr style="vertical-align: top">
                <td colspan="4"><hr /></td>
            </tr>
            <tr style="vertical-align: top">
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Benefits:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBenefit" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label14" runat="server" Text="Comments:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtComments" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Status:"></asp:Label>
                </td>
                <td>
                    <uc4:statusSelectorControl ID="Status" runat="server" />
                </td>
                <td colspan="2">
                    <asp:HiddenField ID="lRecommendationIdHF" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <center>
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Submit" Width="100px" />
                    &nbsp;
                    <asp:Button ID="closeButton" runat="server" OnClick="closeButton_Click" Text="Close" ValidationGroup="xxxx" Width="100px" />
                    </center>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <%--The Modal Popup codes ends here--%>
    <ajaxToolkit:ModalPopupExtender ID="MPE"
        runat="server"
        TargetControlID="EditLinkButton"
        PopupControlID="pnlModalPanel"
        CancelControlID="closeButton"
        BackgroundCssClass="modalBackground"
        DropShadow="true"
        PopupDragHandleControlID="pnlDragPanel"
        Drag="true" />
    <br />

</asp:Content>

