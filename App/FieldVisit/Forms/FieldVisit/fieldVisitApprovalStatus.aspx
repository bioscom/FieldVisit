<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master"
    AutoEventWireup="true" CodeFile="fieldVisitApprovalStatus.aspx.cs" Inherits="fieldVisitApprovalStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/App/FieldVisit/UserControl/FPEC/fieldVisitInformation.ascx" TagName="fieldVisitInformation"
    TagPrefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" ID="smtAjaxManager" />
    <table style="width: 100%">
        <tr>
            <td>
                <uc2:fieldVisitInformation ID="fieldVisitInformation1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <table class="tSubGray" style="width: 100%">
                    <tr>
                        <td class="cHeadTile">Field Visit Request Status
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="grdView_PageIndexChanging"
                                OnRowCommand="grdView_RowCommand" Width="100%">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="...">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="reminderCheckBox" runat="server" USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Approver">
                                        <ItemTemplate>
                                            <asp:Label ID="labelFullName" runat="server"
                                                Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'
                                                USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Role">
                                        <ItemTemplate>
                                            <asp:Label ID="labelRole" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ROLES") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date Received">
                                        <ItemTemplate>
                                            <asp:Label ID="labelDateReceived" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DATE_RECEIVED") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date Comment">
                                        <ItemTemplate>
                                            <asp:Label ID="labelDateComment" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DATE_COMMENT") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Stand">
                                        <ItemTemplate>
                                            <asp:Label ID="labelStand" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STAND") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Comment">
                                        <ItemTemplate>
                                            <asp:Label ID="labelComment" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMMENTS") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Button ID="reminderButton" runat="server" Height="25px" OnClick="reminderButton_Click" Text="Send Reminder" Width="150px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="LnkViewMembers" runat="server">View Superintendent members...</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%--The Modal Popup codes starts here--%>
    <asp:Panel ID="pnlModalPanel" runat="server" Style="display: none; width: 400px"
        CssClass="modalPopup">
        <asp:Panel ID="pnlDragPanel" runat="server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black">
            Drag Here
        </asp:Panel>
        <table class="tMainBorder" style="width: 400px">
            <tr>
                <td class="cHeadTile">
                    <asp:Label ID="Label17" runat="server" Font-Bold="True" ForeColor="#003366" Text="Superintendent Members"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:BulletedList ID="superIntendentMembersCheckBoxList" runat="server">
                    </asp:BulletedList>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
        </table>
        <asp:Button ID="closeButton" runat="server" OnClick="closeButton_Click" Text="Close"
            ValidationGroup="xxxx" />
    </asp:Panel>
    <%--The Modal Popup codes ends here--%>
    <ajaxToolkit:ModalPopupExtender ID="MPE" runat="server" TargetControlID="LnkViewMembers"
        PopupControlID="pnlModalPanel" CancelControlID="closeButton" BackgroundCssClass="modalBackground"
        DropShadow="true" PopupDragHandleControlID="pnlDragPanel" />
</asp:Content>
