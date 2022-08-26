<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PDCC.master" AutoEventWireup="true" CodeFile="AssignDepartment.aspx.cs" Inherits="App_PDCC_AssignDepartment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tSubGray" style="width:70%">
                <tr>
                    <td class="cHeadTile" colspan="2">Assign Department to Users</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlUsers" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged">
                            <asp:ListItem Value="-1">--Select User--</asp:ListItem>
                        </asp:DropDownList>
                        <hr />

                        <%--<div>
                            <div style="border: solid 1px gray; float: left; width: 500px">
                            </div>
                            <div style="margin-left: 0.8em">
                            </div>
                        </div>--%>
                    </td>
                </tr>
                <tr>
                    <td style="width:40%">
                        <div style="border: solid 1px gray;">
                            <asp:CheckBoxList ID="ckbDept" runat="server"><%-- RepeatColumns="2"--%>
                            </asp:CheckBoxList>
                        </div>
                    </td>
                    <td>
                        <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="...">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Width="10px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Asset">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOpex" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "ASSET") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Focal Point">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAsset" runat="server" ForeColor="Black" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click"
                            Text="Submit" Width="100px" />
                    </td>
                </tr>
            </table>

        </ContentTemplate>
    </asp:UpdatePanel>
    <ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender"
        runat="server" Enabled="True" TargetControlID="UpdatePanel1">
    </ajaxToolkit:UpdatePanelAnimationExtender>
    <asp:UpdateProgress ID="upgAjaxBloc" runat="server" DisplayAfter="100" Visible="true"
        DynamicLayout="true">
        <ProgressTemplate>
            <div id="IMGDIV" align="center" valign="middle" runat="server" style="position: absolute; visibility: visible; left: 50%; top: 70%; vertical-align: middle; border-color: #FFFFFF; background-color: #FFFFFF;">
                <asp:Image ID="imgAjaxWait" runat="server" ImageUrl="~/Images/ajaxRoller.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <br />
</asp:Content>

