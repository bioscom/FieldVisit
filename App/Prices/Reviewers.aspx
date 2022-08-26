<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PriceTracker.master" AutoEventWireup="true" CodeFile="Reviewers.aspx.cs" Inherits="App_Prices_Reviewers" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">

    <div style="padding: 70px; width:570px">
        <h2>Red Flag Reviewers</h2>
        <ul style="list-style-type: none;">
            <li>
                <telerik:RadComboBox RenderMode="Lightweight" ID="ddlContractHolder" runat="server" Height="200" Width="425px" Font-Size="10pt"
                    DropDownWidth="500" EmptyMessage="Search for Reviewer..." HighlightTemplatedItems="true"
                    EnableLoadOnDemand="true" Filter="Contains" OnItemsRequested="ddlContractHolder_ItemsRequested"
                    Skin="Office2010Silver">

                    <HeaderTemplate>
                        <table style="width: 475px; font-size: 9pt" cellspacing="0" cellpadding="0">
                            <tr>
                                <td style="width: 165px;">Reviewer's Name</td>
                                <td style="width: 220px;">Email Address</td>
                                <td style="width: 90px;">Ref. Ind.</td>
                            </tr>
                        </table>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <table style="width: 475px; font-size: 9pt" cellspacing="0" cellpadding="0">
                            <tr>
                                <td style="width: 165px;"><%# DataBinder.Eval(Container, "Text")%></td>
                                <td style="width: 220px;"><%# DataBinder.Eval(Container, "Attributes['EMAIL']")%></td>
                                <td style="width: 90px;"><%# DataBinder.Eval(Container, "Attributes['REFIND']")%></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </telerik:RadComboBox>

                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" Width="100px" Height="28px" ValidationGroup="Save" />

            </li>
            <br />
            <li>
                <asp:GridView ID="grdView" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    OnPageIndexChanging="grdView_PageIndexChanging" OnRowCommand="grdView_RowCommand" Width="530px">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="...">
                            <ItemTemplate>
                                <asp:LinkButton ID="deleteLinkButton" runat="server"
                                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="DeleteThis"
                                    OnClick="btnDelete_Click"
                                    OnClientClick="return confirm('Are you sure you want to delete this user?')"
                                    USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>' ValidationGroup="Deleter">Delete</asp:LinkButton>

                                <%--                            <asp:LinkButton ID="LinkButton1" runat="server"
                                CommandArgument="<%# Container.DisplayIndex %>" CommandName="DeleteThis"
                                OnClick="btnDelete_Click"
                                USERID='<%# DataBinder.Eval(Container.DataItem, "USERID") %>' ValidationGroup="Remove">Remove from Superintendent</asp:LinkButton>--%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="labelFullName" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Email Address">
                            <ItemTemplate>
                                <asp:Label ID="labelEmail" runat="server"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "EMAIL") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </li>
            <br />
            <li>
                <div>
                    <div style="float: left; width: 140px">
                        <asp:Button ID="btnReminder" runat="server" OnClick="btnReminder_Click" Text="Send Reminder" />
                    </div>
                    <div style="float: right">
                        <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Close" Width="100px" ValidationGroup="xxxx" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
