<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/LeanMasterPage.master" AutoEventWireup="true" CodeFile="LoadDocs.aspx.cs" Inherits="App_Lean_LoadDocs" %>

<%@ Register Src="UserControl/oLeanProjectDetails.ascx" TagName="oLeanProjectDetails" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <uc2:oLeanProjectDetails ID="oLeanProjectDetails1" runat="server" />
    <br />
    <div style="width:100%">
        <div style="float: left">
            <asp:Panel ID="oPanel" runat="server">
                <table class="tMainBorder" style="width: 500px">
                    <tr>
                        <td style="width: 150px">&nbsp;</td>
                        <td>
                            <asp:Label ID="statusLabel" runat="server" CssClass="AdminError" />
                        </td>
                    </tr>

                    <tr>
                        <td style="width: 150px">Document Title:<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtTitle" ErrorMessage="Document Title is required" ValidationGroup="upload">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Document Description:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescription" runat="server" Width="300px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:FileUpload ID="FUpload" runat="server" TabIndex="3" Width="250px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="FUpload" Display="None" ErrorMessage="Browse for file to be uploaded" ValidationGroup="upload">*</asp:RequiredFieldValidator>
                            <asp:Button ID="cmdUpload" runat="server" OnClick="cmdUpload_Click" Text="Upload File" ValidationGroup="upload" Width="91px" />
                            &nbsp;<asp:Button ID="btnClose" runat="server" OnClientClick="javascript:history.back();" Text="Close" Width="100px" ValidationGroup="Close" OnClick="btnClose_Click" />
                            &nbsp;<asp:ValidationSummary ID="VsmCreateUser" runat="server" BackColor="LightSkyBlue" BorderColor="MediumBlue" BorderStyle="Ridge" BorderWidth="3px" Font-Bold="True" Font-Names="Tahoma" HeaderText="!   In-Complete Specification  !" Height="12px" ShowMessageBox="True" ShowSummary="False" Width="159px" ValidationGroup="upload" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>

        </div>
        <div style="float: left; margin-left:0.5em; width:60%">
            <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" DataKeyNames="IDDOC" OnRowCancelingEdit="grid_RowCancelingEdit"
                OnRowEditing="grid_RowEditing" OnRowUpdating="grid_RowUpdating" Width="98%" OnRowCommand="grid_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Title" SortExpression="DOC_TITLE">
                        <EditItemTemplate>
                            <asp:TextBox ID="nameTextBox" runat="server" CssClass="GridEditingRow" Text='<%# Bind("DOC_TITLE") %>' Width="97%">
                            </asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("DOC_TITLE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Description" SortExpression="DESCRIPTION">
                        <EditItemTemplate>
                            <asp:TextBox ID="descriptionTextBox" runat="server" CssClass="GridEditingRow" Height="100px" Text='<%# Bind("DESCRIPTION") %>' TextMode="MultiLine" Width="97%" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("DESCRIPTION") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Document">
                        <ItemTemplate>
                            <asp:HyperLink ID="LinkButton1" runat="server" NavigateUrl='<%#"~/App/Lean/Documents/" + Eval("FILE_NAME") %>' Target="_blank" Text='<%# Eval("FILE_NAME") %>'> </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="...">
                        <ItemTemplate>
                            <asp:LinkButton ID="deleteLinkButton" runat="server" CommandName="deleteThis" Text="Delete" CommandArgument="<%# Container.DisplayIndex %>"
                                IDDOC='<%# DataBinder.Eval(Container.DataItem, "IDDOC") %>'> </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField ShowEditButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

