<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/configuration.master" AutoEventWireup="true" CodeFile="PlanExeccutionCriteria.aspx.cs" Inherits="Forms_SetupSepcin_PlanExeccutionCriteria" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="rightColumn" Runat="Server">

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table style="width:60%">
            <tr>
                <td>
                    <table class="tSubGray">
                        <tr>
                            <td class="cHeadTile" colspan="2">
                                Plan Execution Criteria</td>
                        </tr>
                        <tr>
                            <td>
                                IAP Window:<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drpWindow" ErrorMessage="Please Select IAP Window" Operator="NotEqual" Type="Integer" ValidationGroup="district" ValueToCompare="-1">*</asp:CompareValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="drpWindow" runat="server" AutoPostBack="True" onselectedindexchanged="drpSuperintendents_SelectedIndexChanged" Width="300px">
                                    <asp:ListItem Value="-1">Select IAP Window...</asp:ListItem>
                                    <asp:ListItem Value="0">Show all PEC</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Plan Execution Criteria:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPEC" ErrorMessage="Plan Execution Criteria is required" ValidationGroup="superintendent">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPEC" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
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
                                <asp:HiddenField ID="idPECHF" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
           
            <tr>
                <td style="width:60%">
                    <asp:GridView ID="grdView" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" 
                        onpageindexchanging="grdView_PageIndexChanging" 
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
                                        ID_FIELD_LOC='<%# DataBinder.Eval(Container.DataItem, "ID_FIELD_LOC") %>'
                                        ID_WINDOW ='<%# DataBinder.Eval(Container.DataItem, "ID_WINDOW") %>'>Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="IAP Window">
                                <ItemTemplate>
                                    <asp:Label ID="labelWindow" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID_WINDOW") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                                    
                            <asp:TemplateField HeaderText="Plan Execution Criteria">
                                <ItemTemplate>
                                    <asp:Label ID="labelPEC" runat="server" 
                                        Text='<%# DataBinder.Eval(Container.DataItem, "FIELD_LOCATION") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                                                         
                        </Columns>
                    </asp:GridView>
                    <br />
                </td>
            </tr>
        </table>    
    </ContentTemplate>
</asp:UpdatePanel>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="superintendent" />
</asp:Content>

