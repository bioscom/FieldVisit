<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master" AutoEventWireup="true" CodeFile="approvalStatus.aspx.cs" Inherits="Forms_PEC_Approval_approvalStatus" %>

<%@ Register Src="../../../UserControl/SEPCiN/PecRequestInfo.ascx" TagName="PecRequestInfo" TagPrefix="uc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:PecRequestInfo ID="PecRequestInfo1" runat="server" />
    <table class="tSubGray" style="width: 100%">
        <tr>
            <td class="cHeadTile">Request Status
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
                        <asp:TemplateField HeaderText="Approver">
                            <ItemTemplate>
                                <asp:Label ID="labelFullName" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'
                                    USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Role">
                            <ItemTemplate>
                                <asp:Label ID="labelRole" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ROLEID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Received">
                            <ItemTemplate>
                                <asp:Label ID="labelDateReceived" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DATE_RECEIVED") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Comment">
                            <ItemTemplate>
                                <asp:Label ID="labelDateComment" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DATE_REVIEWED") %>'></asp:Label>
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
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

