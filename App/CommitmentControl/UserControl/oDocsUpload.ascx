<%@ Control Language="C#" AutoEventWireup="true" CodeFile="oDocsUpload.ascx.cs" Inherits="App_CommitmentControl_UserControl_oDocsUpload" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadGrid RenderMode="Lightweight" runat="server" ID="DocumentsGrid" AllowSorting="true" OnNeedDataSource="DocumentsGrid_NeedDataSource">
    <MasterTableView ShowHeader="true" AutoGenerateColumns="False" AllowPaging="true" DataKeyNames="DOCSID" PageSize="7">
        <Columns>
            <telerik:GridTemplateColumn HeaderText="Uploaded Documents">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDocument" IDDOCS='<%# DataBinder.Eval(Container.DataItem, "DOCSID") %>' runat="server" OnClick="btnDocument_Click" Text='<%# Eval("SFILENAME") %>'></asp:LinkButton>
                </ItemTemplate>
            </telerik:GridTemplateColumn>

            <telerik:GridTemplateColumn UniqueName="DeleteColumn">
                <ItemTemplate>
                    <asp:LinkButton ID="deleteLink" OnClick="lnkDelete_Click" runat="server" Text="Delete"></asp:LinkButton>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
        </Columns>
    </MasterTableView>

    <ClientSettings AllowDragToGroup="true">
        <Scrolling AllowScroll="true" ScrollHeight="" />
    </ClientSettings>
    <PagerStyle PageButtonCount="3" Mode="NextPrevAndNumeric" ShowPagerText="false" />

</telerik:RadGrid>

<br /><br />

<table>
    <tr>
        <td><strong>Select File:</strong></td>
        <td>

            <div id="DemoContainer1" runat="server" class="demo-container size-narrow">
                <telerik:RadAsyncUpload ID="AsyncUpload1" runat="server" ChunkSize="1048576" RenderMode="Lightweight" />
                <telerik:RadProgressArea ID="RadProgressArea1" runat="server" RenderMode="Lightweight" />
            </div>
            <%--<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1" />
                            <telerik:AjaxUpdatedControl ControlID="DemoContainer1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>--%>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:HiddenField ID="CommitmentIdHF" runat="server" />
        </td>
        <td>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100px" OnClick="btnSubmit_Click" />
        </td>
    </tr>
</table>