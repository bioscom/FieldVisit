<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SkillControl.ascx.cs" Inherits="App_FLBM_UserControl_SkillControl" %>

<table style="width: 80%; margin-left: auto; margin-right: auto" class="tMainBorder">
    <tr>
        <td>Proficiency:</td>
        <td colspan="2">Skill</td>
    </tr>
    <tr>
        <td colspan="2"><b>Description of Competence:</b> 
            <br />
            Operational tasks associated with monitoring and controlling hydrocarbon processes to ensure technical integrity, whilst maximizing availability. This ensures processes stay within predefined limits as specified by regulatory statutes, internal and external guidelines and procedures.</td>
        <td>DIRECT OBSERVED DEMONSTRATION
            <br />
            (Using Skill evidence criteria as stated in this assessor sheet)</td>
    </tr>
    <tr>
        <td colspan="3">
            <%--<asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" OnRowCommand="grdView_RowCommand" Width="100%">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Level">
                        <ItemTemplate>
                            <asp:Label ID="lblLevel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LEVEL") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Performance Criteria">
                        <ItemTemplate>
                            <asp:LinkButton ID="performanceLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>" 
                                Text='<%# DataBinder.Eval(Container.DataItem, "PERFORMANCE") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Required Evidence">
                        <ItemTemplate>
                            <asp:Label ID="lblEvidence" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EVIDENCE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Assessment/Assessor Comments">
                        <ItemTemplate>
                            <asp:Label ID="lblComments" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMMENTS") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Competence Achieved">
                        <ItemTemplate>
                            <asp:Label ID="lblCompetence" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMPETENCE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Assessor Signoff and Date">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DATE_SIGNOFF") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>--%>

        </td>
    </tr>
</table>

