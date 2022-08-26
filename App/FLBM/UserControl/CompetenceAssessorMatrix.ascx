<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CompetenceAssessorMatrix.ascx.cs" Inherits="App_FLBM_UserControl_CompetenceAssessorMatrixControl" %>

<br />
<br />
<div style="margin: 2em">
    This page defines Assessors <b>Right to Knowledge and Skill</b> Competence Assessment Checklist.<br />
    **Select Assessor, then check the corresponding checkbox that defines the access right of the accessor to the Competence assessment checklists.<br />
    <br />
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Select Assessor:"></asp:Label>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlAssessors" ErrorMessage="Please select an assessor" Operator="NotEqual" Type="Integer" ValidationGroup="assessorright" ValueToCompare="-1">*</asp:CompareValidator>
            </td>
            <td>
                <asp:DropDownList ID="ddlAssessors" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAssessors_SelectedIndexChanged" Width="300px">
                    <asp:ListItem Value="-1">Select Assessor</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <%--<asp:GridView ID="grdGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="grdGridView_RowCommand" Width="100%">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Group">
            <ItemTemplate>
                <asp:Label ID="lblGroup" runat="server"
                    Text='<%# DataBinder.Eval(Container.DataItem, "GROUPS") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Competence Assessment Checklists">
            <ItemTemplate>
                <asp:Label ID="lblCompetence" runat="server"
                    Text='<%# DataBinder.Eval(Container.DataItem, "COMPETENCE") %>'
                    COMPETENCEID='<%# DataBinder.Eval(Container.DataItem, "COMPETENCEID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="...">
            <ItemTemplate>
                <asp:CheckBoxList ID="ckbProficiency" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>
</asp:GridView>--%>
    <br />

    <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowHeader="False" GridLines="None" Width="600px">
        <RowStyle CssClass="gRepeatItemPlate" />
        <AlternatingRowStyle CssClass="gRepeatAlterPlate" />
        <Columns>
            <asp:TemplateField HeaderText="Group">
                <ItemTemplate>
                    <br />
                    <b><%# Container.DataItemIndex + 1 %>. </b>
                    <asp:Label ID="lblGroup" runat="server" Font-Bold="true" ForeColor="Navy"
                        GROUPID='<%# DataBinder.Eval(Container.DataItem, "GROUPID") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "GROUPS") %>'></asp:Label>
                    <br />
                    <br />
                    <div style="margin-left: 1.5em; margin-right: 1.5em">
                        <asp:GridView ID="subGrdView" runat="server" AutoGenerateColumns="False" Font-Size="10pt" Width="550px">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Competence Assessment Checklists">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompetence" runat="server"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "COMPETENCE") %>'
                                            COMPETENCEID='<%# DataBinder.Eval(Container.DataItem, "COMPETENCEID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="350px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="...">
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="ckbProficiency" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" />
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                    </div>
                    <br />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <br />
    <div style="text-align: right; width: 550px">
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Width="150px" ValidationGroup="assessorright" />
    </div>
</div>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="assessorright" />
