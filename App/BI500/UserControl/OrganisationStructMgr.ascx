<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrganisationStructMgr.ascx.cs" Inherits="App_BI500_UserControl_OrganisationStructMgr" %>

<table style="width: 90%; margin-left:0.5em">
    <tr>
        <td>
            <h3>Business Organisational Structure</h3>
            <hr />
            <div style="float: left; border: solid 1px silver; height: 500px; width:100%">
                <div style="float: left; overflow-x: hidden; overflow: auto; height: 100%">
                    <asp:TreeView ID="mnuTreeView" runat="server" OnSelectedNodeChanged="mnuTreeView_SelectedNodeChanged" ImageSet="Arrows" ExpandDepth="1" ShowLines="True">
                        <ParentNodeStyle Font-Bold="True" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD"
                            HorizontalPadding="0px" VerticalPadding="0px" />
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"
                            HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </div>
                <div style="float: left; margin-left: 2.5em; border: solid 1px silver; height: 500px">
                    <asp:Panel ID="pnlDepartment" Visible="false" runat="server">
                        <table class="tMainBorder">
                            <tr class="cHeadTile">
                                <td colspan="2">
                                    <asp:Label ID="lblBusinessUnit" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Department:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDepartment" runat="server" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:LinkButton ID="lnkAddDepartment" runat="server" OnClick="lnkAddDepartment_Click">Add New Department</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlTeam" Visible="false" runat="server">
                        <table class="tMainBorder">
                            <tr class="cHeadTile">
                                <td colspan="2">
                                    <asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Team:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTeam" runat="server" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:LinkButton ID="lnkAddTeam" runat="server" OnClick="lnkAddTeam_Click">Add New Team</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </div>
        </td>
    </tr>
</table>

