<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/configuration.master" AutoEventWireup="true" CodeFile="Baggage.aspx.cs" Inherits="SetupSepcin_Baggage" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="rightColumn" Runat="Server">

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table style="width:50%">
            <tr>
                <td>
                    <table class="tSubGray">
                        <tr>
                            <td class="cHeadTile" colspan="2">
                                Baggage</td>
                        </tr>
                        <tr>
                            <td>
                                Baggage:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                    runat="server" ControlToValidate="txtBaggage" 
                                    ErrorMessage="Baggage is required" ValidationGroup="superintendent">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBaggage" runat="server" Width="300px"></asp:TextBox>
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
                                <asp:HiddenField ID="idBaggageHF" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp; &nbsp;</td>
            </tr>
            <tr>
                <td style="width:50%">
                    <asp:GridView ID="grdView" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" onpageindexchanging="grdView_PageIndexChanging" 
                        onrowcommand="grdView_RowCommand" PageSize="20" Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="...">
                                <ItemTemplate>
                                    <asp:LinkButton ID="editLinkButton" runat="server" 
                                        CommandArgument="<%# Container.DisplayIndex %>" CommandName="editThis" 
                                        ID_BAG='<%# DataBinder.Eval(Container.DataItem, "ID_BAG") %>'>Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Baggage">
                                <ItemTemplate>
                                    <asp:Label ID="labelBaggage" runat="server" 
                                        Text='<%# DataBinder.Eval(Container.DataItem, "BAGGAGE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>    
    </ContentTemplate>
</asp:UpdatePanel>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="superintendent" />
</asp:Content>

