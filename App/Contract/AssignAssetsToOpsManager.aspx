<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/configuration.master" AutoEventWireup="true" CodeFile="AssignAssetsToOpsManager.aspx.cs" Inherits="App_Contract_AssignAssetsToOpsManager" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<%@ Register src="~/App/FieldVisit/UserControl/FPEC/viwFunctionalAcctMembers.ascx" tagname="viwFunctionalAcctMembers" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/userFinder/Search4User.ascx" TagName="Search4User" TagPrefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="rightColumn" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table style="width:99%">
                        <tr>
                            <td style="width:50%">
                                <div style="margin-left:5px">
                                    <table class="tSubGray">
                                        <tr>
                                            <td class="cHeadTile">Field Operations</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" onpageindexchanging="grdView_PageIndexChanging" onrowcommand="grdView_RowCommand" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="...">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="editLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>" CommandName="editThis" ID_SUPERINTENDENT='<%# DataBinder.Eval(Container.DataItem, "ID_SUPERINTENDENT") %>' ValidationGroup="main">Edit</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Superintendent">
                                                            <ItemTemplate>
                                                                <asp:Label ID="labelSuperintendent" runat="server" Font-Bold="True" ForeColor="#003366" Text='<%# DataBinder.Eval(Container.DataItem, "SUPERINTENDENT") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Functional Email">
                                                            <ItemTemplate>
                                                                <asp:Label ID="labelEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SUPERINTENDENT_EMAIL") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="...">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="viwMemberLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>" CommandName="viwMember" ID_SUPERINTENDENT='<%# DataBinder.Eval(Container.DataItem, "ID_SUPERINTENDENT") %>' ValidationGroup="x">View Members</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="...">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="addMemberLinkButton" runat="server" 
                                                CommandArgument="<%# Container.DisplayIndex %>" CommandName="addMember" 
                                                ID_SUPERINTENDENT='<%# DataBinder.Eval(Container.DataItem, "ID_SUPERINTENDENT") %>'>Add Member</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td>
                                <asp:Panel ID="addUserPanel" runat="server">
                                    <uc2:viwFunctionalAcctMembers ID="viwFunctionalAcctMembers1" runat="server" />
                                    <table class="tSubGray">
                                        <tr>
                                            <td class="cHeadTile" colspan="2" style="font-size:8pt">Add New User to
                                                <asp:Label ID="superintendentLabel" runat="server" Font-Bold="true"></asp:Label>
                                                &nbsp;Functional Account</td>
                                        </tr>
                                        <tr>
                                            <td>Select User:<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drpOpsMgrUsers" ErrorMessage="Please select User" Operator="NotEqual" Type="Integer" ValueToCompare="-1">*</asp:CompareValidator>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpOpsMgrUsers" runat="server">
                                                    <asp:ListItem Value="-1">--Select Operations Manager--</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:HiddenField ID="opsMgrIdHF" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Button ID="addNewUserButton" runat="server" onclick="addNewUserButton_Click" Text="Submit" ValidationGroup="district" />
                                                &nbsp;<asp:Button ID="closeButton" runat="server" onclick="closeButton_Click" Text="Close" ValidationGroup="xxxx" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>

        <%--The Modal Popup codes starts here--%>
                    <asp:Panel ID="pnlModalPanel" runat="server" CssClass="modalPopup" Style="display: none; width: 500px">
                        <asp:Panel ID="pnlDragPanel" runat="server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black">
                            Drag Here
                        </asp:Panel>
                        <table class="tSubGray">
                            <tr>
                                <td class="cHeadTile" colspan="2">Add New Superintendent</td>
                            </tr>
                            <tr>
                                <td>Superintendent:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="superintendentTextBox" ErrorMessage="Superintendent is required" ValidationGroup="superintendent">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="superintendentTextBox" runat="server" Width="350px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Functional Email:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="functionalEmailTextBox" ErrorMessage="Functional email is required" ValidationGroup="superintendent">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="functionalEmailTextBox" ErrorMessage="Invalid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="superintendent">*</asp:RegularExpressionValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="functionalEmailTextBox" runat="server" Width="350px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="submitButton" runat="server" onclick="submitButton_Click" Text="Submit" ValidationGroup="superintendent" />
                                    &nbsp;<asp:Button ID="resetButton" runat="server" onclick="resetButton_Click" Text="Reset" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:HiddenField ID="idSuperintendentHF" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="Button1" runat="server" OnClick="closeButton_Click" Text="Close" ValidationGroup="xxxx" />
                    </asp:Panel>
    <%--The Modal Popup codes ends here--%>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
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
