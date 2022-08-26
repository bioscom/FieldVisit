<%@ Page Language="C#" MasterPageFile="~/MasterPages/configuration.master" AutoEventWireup="true" CodeFile="Questionaire.aspx.cs" Inherits="Setup_Questionaire" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightColumn" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tMainBorder" style="width: 98%">
                <tr>
                    <td style="width: 400px">                        
                        <table class="tSubGray" style="width:420px">
                            <tr>
                                <td class="cHeadTile">Questionaire</td>
                            </tr>
                            <tr>
                                <td>Questionaire<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="questionaireTextBox" ErrorMessage="Questionaire is required" ValidationGroup="questions">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="questionaireTextBox" runat="server" Height="50px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Description<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="descriptionTextBox" ErrorMessage="Description is required" ValidationGroup="questions">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="descriptionTextBox" runat="server" Height="70px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click" Text="Submit" ValidationGroup="questions" />
                                    <asp:HiddenField ID="idQuestionHF" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="facility" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <asp:GridView ID="grdView" runat="server" AllowPaging="True"
                            AutoGenerateColumns="False" OnPageIndexChanging="grdView_PageIndexChanging"
                            OnRowCommand="grdView_RowCommand" PageSize="20" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="...">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="editLinkButton" runat="server"
                                            CommandArgument="<%# Container.DisplayIndex %>" CommandName="editThis"
                                            ID_QUESTION='<%# DataBinder.Eval(Container.DataItem, "ID_QUESTION") %>'>Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Seq.">
                                    <ItemTemplate>
                                        <asp:Label ID="labelSequence" runat="server"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "SEQUENCIAL") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Question">
                                    <ItemTemplate>
                                        <asp:Label ID="labelQuestion" runat="server" Font-Bold="True" ForeColor="#003366"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "QUESTION") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="labelDescription" runat="server"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "DESCRIPTION") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>

                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

