<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMaster.master" AutoEventWireup="true" CodeFile="Facilities.aspx.cs" Inherits="App_FlareWaiver_Facilities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 99%; margin-left:0.2em">
        <tr>
            <td>
                <h3>Assets</h3>
                <hr />
                <div style="float: left; border: solid 1px silver; height: 500px; width:100%">
                    <div style="float: left; overflow-x: hidden; overflow: auto; height: 100%; width:400px">
                        <asp:TreeView ID="mnuTreeView" runat="server" OnSelectedNodeChanged="mnuTreeView_SelectedNodeChanged" ImageSet="Arrows" ExpandDepth="1" ShowLines="True">
                            <ParentNodeStyle Font-Bold="True" />
                            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD"
                            HorizontalPadding="0px" VerticalPadding="0px" />
                            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"
                            HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                        </asp:TreeView>
                    </div>
                    <div style="float: left; margin-left: 1.8em; border: solid 1px silver; height: 500px">
                        <asp:Panel ID="pnlAdd" Visible="false" runat="server">
                            <table class="tMainBorder">
                                <tr class="cHeadTile">
                                    <td colspan="2">
                                        <asp:Label ID="lblArea" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Facility:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFacility" runat="server" Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Code:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCode" runat="server" Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Has AGG Solution?:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rblAGG" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:LinkButton ID="lnkAddFacility" runat="server" OnClick="lnkAddFacility_Click">Add New Facility</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlUpdate" Visible="false" runat="server">
                            <table class="tMainBorder">
                                <tr class="cHeadTile">
                                    <td colspan="2">
                                        <asp:Label ID="lblFacility" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Facility:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFacilityUpt" runat="server" Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Code:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCodeUpt" runat="server" Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Has AGG Solution?:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rblAGG1" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:LinkButton ID="lnkUpdateFacility" runat="server" OnClick="lnkUpdateFacility_Click">Update</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <br /><br /><br />
</asp:Content>

