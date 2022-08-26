<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CostReduction.master" AutoEventWireup="true" CodeFile="CostReductionStageGaters.aspx.cs" Inherits="App_BI500_CostReductionStageGaters" %>

<%@ Register Src="UserControl/Search4LocalUser.ascx" TagName="Search4LocalUser" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <div style="width: 500px; margin-left:5em">
            <table class="tSubGray">
                <tr>
                    <td class="cHeadTile">Business Improvement/Lean Team Reviewers</td>
                </tr>
                <tr>
                    <td>

                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc3:Search4LocalUser ID="Reviewers" runat="server" />
                        <%--<asp:CheckBoxList ID="revieweresCkbLst" runat="server" RepeatColumns="5">
                        </asp:CheckBoxList>--%>

                    </td>
                </tr>
                <tr>
                    <td>
                        <hr />
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />

                    </td>
                </tr>
            </table>
            <table class="tSubGray">
                <tr>
                    <td class="cHeadTile" style="font-size: 8pt">Business Improvement/Lean Team Reviewers</td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdView" runat="server" AllowPaging="True"
                            AutoGenerateColumns="False" PageSize="20" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Members">
                                    <ItemTemplate>
                                        <asp:Label ID="labelManager" runat="server"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="...">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="deleteLinkButton" runat="server"
                                            CommandArgument="<%# Container.DisplayIndex %>" CommandName="DeleteThis"
                                            OnClick="btnDelete_Click"
                                            USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>' ValidationGroup="Remove">Remove</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
    </div>
</asp:Content>

