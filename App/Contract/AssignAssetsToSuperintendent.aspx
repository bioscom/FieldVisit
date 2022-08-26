<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/14DayContract.master" AutoEventWireup="true" CodeFile="AssignAssetsToSuperintendent.aspx.cs" Inherits="App_Contract_AssignAssetsToSuperintendent" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="headId" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>--%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/UserControls/userFinder/Search4User.ascx" TagName="Search4User"
    TagPrefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="smtAjaxManager" runat="Server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tSubGray">
                <tr>
                    <td class="cHeadTile">Assign Asset to Superintendents</td>
                </tr>
                <tr>
                    <td>
                        <div style="margin-left: 0.5em">
                            <table>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlSuperintendent" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSuperintendent_SelectedIndexChanged">
                                            <asp:ListItem Value="-1">--Select Superintendents--</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <div style="border: solid 1px gray; margin-left: 0.5em;">
                            <asp:CheckBoxList ID="AssetCheckBoxList" runat="server" RepeatColumns="8">
                            </asp:CheckBoxList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="margin-left: 0.5em">
                            <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click"
                                Text="Submit" Width="100px" />
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
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
</asp:Content>
