<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AssessorsControl.ascx.cs" Inherits="App_FLBM_UserControl_AssessorsControl" %>
<br />
<br />
<div style="margin: 2em">
    <table>
        <tr>
            <td>
                <uc:Search4LocalUser ID="ddlAssessor" runat="server" />
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Add to Assessor" />
            </td>
        </tr>
    </table>

    <hr />
    <br />
    <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" PageSize="20" Width="100%">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Competence Assessor">
                <ItemTemplate>
                    <asp:Label ID="labelAssessor" runat="server"
                        Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email Address">
                <ItemTemplate>
                    <asp:Label ID="labelEmail" runat="server"
                        Text='<%# DataBinder.Eval(Container.DataItem, "EMAIL") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="...">
                <ItemTemplate>
                    <asp:LinkButton ID="deleteLinkButton" runat="server"
                        CommandArgument="<%# Container.DisplayIndex %>" CommandName="DeleteThis"
                        OnClick="btnDelete_Click"
                        USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>' ValidationGroup="Remove">Remove from Assessor's List</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
