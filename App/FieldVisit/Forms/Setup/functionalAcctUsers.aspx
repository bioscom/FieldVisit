<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/siteMasterFieldVisit.master" AutoEventWireup="true" CodeFile="functionalAcctUsers.aspx.cs" Inherits="Setup_functionalAcctUsers" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<%@ Register src="~/App/FieldVisit/UserControl/FPEC/viwFunctionalAcctMembers.ascx" tagname="viwFunctionalAcctMembers" tagprefix="uc2" %>
<%@ Register Src="~/UserControls/userFinder/Search4User.ascx" tagname="Search4User" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <table class="style1">
        <tr>
            <td style="width:50%">
                <table class="tSubGray">
                    <tr>
                        <td class="cHeadTile" colspan="2">
                            Assign User to Superintendent Functional Account</td>
                    </tr>
                    <tr>
                        <td>
                            Select Superintendent:<asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToValidate="drpSuperintendents" 
                    ErrorMessage="Please Select Superintendent" Type="Integer" 
                    ValueToCompare="-1" ValidationGroup="district" Operator="NotEqual">*</asp:CompareValidator>
                        </td>
                        <td>
                <asp:DropDownList ID="drpSuperintendents" runat="server" Width="350px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="drpSuperintendents_SelectedIndexChanged">
                    <asp:ListItem Value="-1">Select Superintendent...</asp:ListItem>
                </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Search user:</td>
                        <td>
                            <uc1:Search4User ID="Search4User1" runat="server" />
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
                <asp:Button ID="submitButton" runat="server" Text="Submit" 
                    ValidationGroup="district" onclick="submitButton_Click" />
                        &nbsp;<asp:Button ID="closeButton" runat="server" onclick="closeButton_Click" 
                                Text="Close" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <%--<table class="tSubGray">
                    <tr>
                        <td class="cHeadTile" style="font-size:8pt">
                            &nbsp;
                            <asp:Label ID="superintendentLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                    <asp:GridView ID="grdView" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" PageSize="20" Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                   <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                                                        
                            <asp:TemplateField HeaderText="Functional Account Members">
                                <ItemTemplate>
                                    <asp:Label ID="labelManager" runat="server" 
                                        Text='<%# DataBinder.Eval(Container.DataItem, "FULL_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Ref. Ind.">
                                <ItemTemplate>
                                    <asp:Label ID="labelRefInd" runat="server" 
                                        Text='<%# DataBinder.Eval(Container.DataItem, "REF_IND") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Job Title">
                                <ItemTemplate>
                                    <asp:Label ID="labelJobTitle" runat="server" 
                                        Text='<%# DataBinder.Eval(Container.DataItem, "JOB_TITLE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                                                          
                        </Columns>
                    </asp:GridView>
                        </td>
                    </tr>
                </table>--%>
                <uc2:viwFunctionalAcctMembers ID="viwFunctionalAcctMembers1" runat="server" />
            </td>
        </tr>
        </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="district" />
</asp:Content>

