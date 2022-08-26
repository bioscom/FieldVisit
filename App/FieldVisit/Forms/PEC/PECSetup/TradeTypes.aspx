<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/configuration.master" AutoEventWireup="true" CodeFile="TradeTypes.aspx.cs" Inherits="SetupSepcin_TradeTypes" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightColumn" Runat="Server">

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table style="width:90%">
            <tr>
                <td style="width:400px">
                    <table class="tSubGray" style="width:400px">
                        <tr>
                            <td class="cHeadTile" colspan="2">
                                Trade Type</td>
                        </tr>
                        <tr>
                            <td>
                                Trade Type:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                    runat="server" ControlToValidate="txtTradeType" 
                                    ErrorMessage="Trade Type is required" ValidationGroup="superintendent">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTradeType" runat="server" Width="250px" Height="50px" 
                                    TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="submitButton" runat="server" onclick="submitButton_Click" 
                                    Text="Submit" ValidationGroup="superintendent" />
                                &nbsp;<asp:Button ID="resetButton" runat="server" onclick="resetButton_Click" 
                                    Text="Reset" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:HiddenField ID="idTradeTypeHF" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <asp:GridView ID="grdView" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                        onpageindexchanging="grdView_PageIndexChanging" onrowcommand="grdView_RowCommand" PageSize="50" Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="...">
                                <ItemTemplate>
                                    <asp:LinkButton ID="editLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>" CommandName="editThis" ID_TRADE_TYPE='<%# DataBinder.Eval(Container.DataItem, "ID_TRADE_TYPE") %>'>Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Trade Type">
                                <ItemTemplate>
                                    <asp:Label ID="labelTradeType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TRADE_TYPE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>    
        <br />
    </ContentTemplate>
</asp:UpdatePanel>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="superintendent" />
</asp:Content>

