<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/14DayContract.master" AutoEventWireup="true" CodeFile="KPIReporting.aspx.cs" Inherits="App_Contract_Setup_KPIReporting" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" ScriptMode="Release">
                        </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tMainBorder" style="width: 99%">
                <tr>
                    <td class="cHeadTile" colspan="2">Report accuracy settings</td>
                </tr>
                <tr>
                    <td style="width: 50%">
                        <asp:DropDownList ID="ddlPriority" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlCorpPriority_SelectedIndexChanged">
                            <asp:ListItem Value="-1">[Select Corporate Priority]</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;<asp:Button ID="closeBtn" runat="server" OnClick="closeBtn_Click" Text="Close" Width="100px" />
                        
                    </td>
                    <td style="vertical-align: top; text-align: right">
                        &nbsp;</td>
                </tr>
                <%--<tr>
                    <td valign="top" class="style2" colspan="2">
                        <asp:Label ID="mssgLabel" runat="server" CssClass="Warning"></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:Panel ID="iPanel" runat="server">
                            <table style="width: 99%">
                                <tr>
                                    <td style="width: 50%">
                                        <table class="tSubGray">
                                            <tr>
                                                <td class="cHeadTile">KPI Performance Report Items</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBoxList ID="KPICkb" runat="server">
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                        </table>
                                        <table class="tSubGray">
                                            <tr>
                                                <td style="vertical-align: top; text-align: right">
                                                    <asp:Button ID="submitBtn" runat="server" OnClick="submitBtn_Click" Text="Submit" Width="100px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="iPanel2" runat="server">
                            <table style="width: 99%">
                                <tr>
                                    <td style="width: 50%">
                                        <table class="tSubGray">
                                            <tr>
                                                <td class="cHeadTile">KPI Performance Report Computation</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowHeader="false" Width="100%">
                                                        <RowStyle BackColor="White" />
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="Activity">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbActivity" runat="server"
                                                                        IDACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "IDACTIVITIES") %>'
                                                                        IDSUBACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "IDSUBACTIVITIES") %>'
                                                                        Text='<%# DataBinder.Eval(Container.DataItem, "ACTIVITY") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="...">
                                                                <ItemTemplate>
                                                                    <asp:RadioButtonList ID="RdBList" runat="server" RepeatDirection="Horizontal" oVAL='<%# DataBinder.Eval(Container.DataItem, "IBITCALC") %>'></asp:RadioButtonList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        <table class="tSubGray">
                                            <tr>
                                                <td style="vertical-align: top; text-align: right">
                                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Submit" Width="100px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>

        </ContentTemplate>
    </asp:UpdatePanel>

    <ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender" runat="server" Enabled="True" TargetControlID="UpdatePanel1">
    </ajaxToolkit:UpdatePanelAnimationExtender>

    <asp:UpdateProgress ID="upgAjaxBloc" runat="server" DisplayAfter="100" Visible="true" DynamicLayout="true">
        <ProgressTemplate>
            <div id="IMGDIV" align="center" valign="middle" runat="server" style="position: absolute; visibility: visible; left: 50%; top: 55%; vertical-align: middle; border-color: #FFFFFF; background-color: #FFFFFF;">
                <asp:Image ID="imgAjaxWait" runat="server" ImageUrl="~/Images/ajaxRoller.gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>

