<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CompetenceControl.ascx.cs" Inherits="App_FLBM_UserControl_CompetenceControl" %>

<div style="margin: 2em">
<table style="width: 90%">
    <tr>
        <td style="width: 450px">
            <h3>Add new Competence assessment resource</h3>
            <hr />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Group:"></asp:Label>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlGroup" ErrorMessage="Select Group the competence belongs" Operator="NotEqual" Type="Integer" ValueToCompare="-1" ValidationGroup="grouping">*</asp:CompareValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGroup" runat="server" Width="380px">
                            <asp:ListItem Value="-1">Select Group...</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Competence:"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCompetence" ErrorMessage="Competence is required" ValidationGroup="grouping">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompetence" runat="server" TextMode="MultiLine" Height="50px" Width="380px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Descriptions:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="50px" Width="380px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Url:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUrl" runat="server" Width="380px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" Width="100px" OnClick="btnSubmit_Click" ValidationGroup="grouping" />
                        <asp:HiddenField ID="HFGroup" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="grouping" ShowMessageBox="True" ShowSummary="False" />
                    </td>
                </tr>
            </table>
        </td>

        <td>
            <h3>Competence assessment groupings</h3>
            <hr />
            <div style="float: left; margin-left: 3em; border-left: solid 1px silver; border-bottom: solid 1px silver; height:500px">
                <div style="overflow-x: hidden; overflow: auto; height:100%">
                    <asp:TreeView ID="mnuTreeView" runat="server" OnSelectedNodeChanged="mnuTreeView_SelectedNodeChanged" ImageSet="Arrows" ExpandDepth="1" ShowLines="True">
                        <ParentNodeStyle Font-Bold="True" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD"
                            HorizontalPadding="0px" VerticalPadding="0px" />
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"
                            HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </div>
            </div>
        </td>
    </tr>
</table>
    </div>
<br />