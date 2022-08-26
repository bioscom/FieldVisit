<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProficiencyControl.ascx.cs" Inherits="App_FLBM_UserControl_ProficiencyControl" %>

<div style="margin: 2em">
    <table class="tMainBorder">
        <tr>
            <td class="cHeadTile" colspan="2">Proficiencies</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Proficiency:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtProficiency" runat="server" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Save" Width="100px" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>

    <table class="tMainBorder">
        <tr>
            <td>
                <asp:GridView ID="grdGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="grdGridView_RowCommand" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditLinkButton" runat="server"
                                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="EditThisRequest"
                                    PROFICIENCYID='<%# DataBinder.Eval(Container.DataItem, "PROFICIENCYID") %>'>Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Proficiency">
                            <ItemTemplate>
                                <asp:Label ID="lblProficiency" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "PROFICIENCY") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</div>
