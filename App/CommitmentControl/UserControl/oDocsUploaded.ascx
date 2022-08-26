<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oDocsUploaded.ascx.cs" Inherits="App_CommitmentControl_UserControl_oDocsUploaded" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadGrid RenderMode="Lightweight" runat="server" ID="DocumentsGrid" AllowSorting="true" OnNeedDataSource="DocumentsGrid_NeedDataSource" ShowHeader="false">
    <MasterTableView ShowHeader="true" AutoGenerateColumns="False" AllowPaging="true" DataKeyNames="DOCSID" PageSize="7">
        <Columns>
            <telerik:GridTemplateColumn HeaderText="...">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDocument" IDDOCS='<%# DataBinder.Eval(Container.DataItem, "DOCSID") %>' runat="server" OnClick="btnDocument_Click" Text='<%# Eval("SFILENAME") %>'></asp:LinkButton>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            
        </Columns>
    </MasterTableView>

    <ClientSettings AllowDragToGroup="true">
        <Scrolling AllowScroll="true" ScrollHeight="" />
    </ClientSettings>
    <PagerStyle PageButtonCount="3" Mode="NextPrevAndNumeric" ShowPagerText="false" />

</telerik:RadGrid>
            <asp:HiddenField ID="CommitmentIdHF" runat="server" />
        