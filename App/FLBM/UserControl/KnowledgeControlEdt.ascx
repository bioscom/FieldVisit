<%@ Control Language="C#" AutoEventWireup="true" CodeFile="KnowledgeControlEdt.ascx.cs" Inherits="App_FLBM_UserControl_KnowledgeControlEdt" %>

<%@ Register Src="MainHeaderControl.ascx" TagName="MainHeaderControl" TagPrefix="uc2" %>

<div style="margin: 2em">
    <uc2:MainHeaderControl ID="MainHeaderControl1" runat="server" />

    <table style="width: 100%; margin-left: auto; margin-right: auto" class="tMainBorder">
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Name of Assessee:"></asp:Label>
            </td>
            <td colspan="2">
                <%--<asp:TextBox ID="txtAssessee" runat="server" Width="300px"></asp:TextBox>--%>
                <uc:Search4LocalUser ID="txtAssessee" runat="server" />
            </td>
            <td colspan="2">
                <asp:Label ID="Label11" runat="server" Text="Name of Authorised Assessor:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAssessor" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Grouping:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" Width="300px">
                    <asp:ListItem Value="-1">Select Group...</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Competence:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCompetency" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompetency_SelectedIndexChanged" Width="300px">
                    <asp:ListItem Value="-1">Select Competency...</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label10" runat="server" Text="Proficiency:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlProficiency" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProficiency_SelectedIndexChanged" Width="200px">
                    <asp:ListItem Value="-1">Select Proficiency...</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlAssementSheet" runat="server">
        <table style="width: 100%; margin-left: auto; margin-right: auto" class="tMainBorder">
            <tr style="background-color: Silver">
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Proficiency:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Knowledge"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Evidence Record"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <table style="width: 500px">
                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Description of Competence:"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCompetenceDescription" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>

                </td>
                <td style="background-color: Silver">
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="STRUCTURED INTERVIEW: "></asp:Label>
                    <br />
                    (Using knowledge evidence criteria as stated in this assessor sheet)</td>
                <td style="background-color: Silver">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="TEST :"></asp:Label>
                    <br />
                    1. Written test after completing classroom training
            <br />
                    2. Test after completing E-Learning</td>
            </tr>
        </table>
        <div style="height: 700px; overflow: auto">
            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" OnRowCommand="grdView_RowCommand" Width="100%">
                <Columns>
                    <%-- <asp:TemplateField>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Level">
                        <ItemTemplate>
                            <asp:Label ID="lblLevel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SLEVEL") %>'
                                ASSESSMENTID='<%# DataBinder.Eval(Container.DataItem, "ASSESSMENTID") %>'
                                SHEETID='<%# DataBinder.Eval(Container.DataItem, "SHEETID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Performance Criteria">
                        <ItemTemplate>
                            <asp:Label ID="lblPerf" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CRITERIA") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="300px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Required Evidence">
                        <ItemTemplate>
                            <div style="background-color: #ffe; font: bold;">
                                <asp:Label ID="lblEvidence" runat="server" Font-Bold="true" Text='<%# DataBinder.Eval(Container.DataItem, "EVIDENCE") %>'></asp:Label>
                                <hr />
                            </div>

                            <asp:CheckBoxList ID="ckbEvidence" runat="server" ASSESSMENTID='<%# DataBinder.Eval(Container.DataItem, "ASSESSMENTID") %>'></asp:CheckBoxList>
                        </ItemTemplate>
                        <%--<ItemStyle Width="400px" />--%>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Assessment/Assessor Comments">
                        <ItemTemplate>
                            <asp:TextBox ID="txtComment" Height="100px" Width="300px" TextMode="MultiLine" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "COMMENTS") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Competence Achieved">
                        <ItemTemplate>
                            <asp:RadioButtonList ID="rblYesNo" runat="server" ACHIEVED='<%# DataBinder.Eval(Container.DataItem, "ACHIEVED") %>' RepeatDirection="Horizontal">
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Assessor Signoff and Date">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DATE_ACHIEVED") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>


        <table style="width: 100%; margin-left: auto; margin-right: auto" class="tMainBorder">
            <tr>
                <td>
                    <div style="float: right">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Submit" Width="150px" />
                        &nbsp;<asp:Button ID="btnClose" runat="server" Text="Close" ValidationGroup="close" Width="150px" OnClick="btnClose_Click" />
                        <asp:HiddenField ID="AssessIdHF" runat="server" />
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
