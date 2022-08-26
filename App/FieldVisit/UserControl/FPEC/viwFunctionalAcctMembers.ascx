<%@ Control Language="C#" AutoEventWireup="true" CodeFile="viwFunctionalAcctMembers.ascx.cs" Inherits="UserControl_viwFunctionalAcctMembers" %>
<table class="tSubGray">
    <tr>
        <td class="cHeadTile" style="font-size: 8pt">&nbsp;
                    
                    Functional Email Members list</td>
    </tr>
    <tr>
        <td style="font-size: 8pt">
            <asp:Label ID="superintendentLabel" Font-Bold="true" runat="server"></asp:Label>
        </td>
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

                    <asp:TemplateField HeaderText="Acct Members">
                        <ItemTemplate>
                            <asp:Label ID="labelManager" runat="server"
                                Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Ref.Ind.">
                        <ItemTemplate>
                            <asp:Label ID="labelRefInd" runat="server"
                                Text='<%# DataBinder.Eval(Container.DataItem, "REFIND") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="...">
                        <ItemTemplate>
                            <asp:LinkButton ID="deleteLinkButton" runat="server"
                                CommandArgument="<%# Container.DisplayIndex %>" CommandName="DeleteThis"
                                OnClick="btnDelete_Click"
                                USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>' ValidationGroup="Remove">Remove from Superintendent</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%-- <asp:TemplateField HeaderText="Job Title">
                                <ItemTemplate>
                                    <asp:Label ID="labelJobTitle" runat="server" 
                                        Text='<%# DataBinder.Eval(Container.DataItem, "JOB_TITLE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
<asp:HiddenField ID="idSuperHF" runat="server" />

<%--</td>
</tr>
</table>--%>