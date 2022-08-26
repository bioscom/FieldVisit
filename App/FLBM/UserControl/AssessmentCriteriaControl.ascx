<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AssessmentCriteriaControl.ascx.cs" Inherits="App_FLBM_UserControl_AssessmentCriteriaControl" %>
<%@ Register Src="AssessmentKSEntryControl.ascx" TagName="AssessmentKSEntryControl" TagPrefix="uc2" %>

<div style="margin: 2em">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Grouping:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlGroup" runat="server" Width="400px" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Select Group...</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Competency:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCompetency" runat="server" Width="400px" AutoPostBack="True" OnSelectedIndexChanged="ddlCompetency_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Select Competency...</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Proficiency:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlProficiency" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProficiency_SelectedIndexChanged" Width="200px">
                    <asp:ListItem Value="-1">Select Proficiency...</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <hr />
    <asp:Panel ID="pnlCriteriah" runat="server">
        <br />
        <asp:LinkButton ID="lnkPerformanceCriteria" runat="server">Add Performance Criteria</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="AddLinkButton" runat="server"></asp:LinkButton>
        <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" OnRowCommand="grdView_RowCommand" Width="100%">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Level">
                    <ItemTemplate>
                        <asp:Label ID="lblLevel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SLEVEL") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Performance Criteria">
                    <ItemTemplate>
                        <asp:Label ID="lblPerformance" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CRITERIA") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="400px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Required Evidence">
                    <ItemTemplate>
                        <div style="background-color: #ffe; font: bold;">
                            <asp:Label ID="lblEvidence" runat="server" Font-Bold="true" Text='<%# DataBinder.Eval(Container.DataItem, "EVIDENCE") %>'></asp:Label>
                            <br />
                            <asp:LinkButton ID="AddLinkButton" runat="server" ASSESSMENTID='<%# DataBinder.Eval(Container.DataItem, "ASSESSMENTID") %>'
                                CommandArgument="<%# Container.DisplayIndex %>" CommandName="AddEvidence"
                                OnClick="AddLinkButton_Click" ValidationGroup="Evidenced">Add Required Evidence</asp:LinkButton>
                            <hr />
                        </div>
                        <asp:BulletedList ID="lstRequiredEvidences" runat="server">
                        </asp:BulletedList>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </asp:Panel>
</div>

<asp:Panel ID="pnlModalPanel2" runat="server" Style="display: none;" CssClass="modalPopup" Width="600px">
    <asp:Panel ID="pnlDragPanel2" runat="server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black">
        +
    </asp:Panel>

    <asp:Label ID="Label1" runat="server" Text="Required Evidence:"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRequiredEvidence" ErrorMessage="Evidence Required" ValidationGroup="RequiredEvidence">*</asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="txtRequiredEvidence" runat="server" Height="50px" TextMode="MultiLine" Width="400px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="RequiredEvidence" Width="100px" />
    &nbsp;
                <asp:Button ID="btnClose" runat="server" Text="Close" ValidationGroup="zzzz" Width="100px" />
    &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="RequiredEvidence" />

</asp:Panel>



<asp:Panel ID="pnlModalPanel" runat="server" Style="display: none;" CssClass="modalPopup" Width="600px">
    <asp:Panel ID="pnlDragPanel" runat="server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black">
        +
    </asp:Panel>
    <uc2:AssessmentKSEntryControl ID="AssessmentKSEntryControl1" runat="server" />
</asp:Panel>

<ajaxToolkit:ModalPopupExtender ID="MPE"
    runat="server"
    TargetControlID="lnkPerformanceCriteria"
    PopupControlID="pnlModalPanel"
    BackgroundCssClass="modalBackground"
    DropShadow="true"
    PopupDragHandleControlID="pnlDragPanel"
    Drag="true" />

<ajaxToolkit:ModalPopupExtender ID="MPE2"
    runat="server"
    TargetControlID="AddLinkButton"
    PopupControlID="pnlModalPanel2"
    BackgroundCssClass="modalBackground"
    DropShadow="true"
    PopupDragHandleControlID="pnlDragPanel2"
    Drag="true" />



