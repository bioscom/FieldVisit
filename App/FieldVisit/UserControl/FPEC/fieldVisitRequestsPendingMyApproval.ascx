<%@ Control Language="C#" AutoEventWireup="true" CodeFile="fieldVisitRequestsPendingMyApproval.ascx.cs" Inherits="UserControl_fieldVisitRequestsPendingMyApproval" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="~/App/FieldVisit/UserControl/FPEC/fieldVisitInformation.ascx" tagname="fieldVisitInformation" tagprefix="uc2" %>

<%@ Register src="FieldVisitQuestionaire.ascx" tagname="FieldVisitQuestionaire" tagprefix="uc2" %>

<asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" onpageindexchanging="grdView_PageIndexChanging" 
    onrowcommand="grdView_RowCommand" Width="100%">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
               <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="...">
            <ItemTemplate>
                <asp:LinkButton ID="actionLinkButton" runat="server" 
                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="Action" 
                    ID_ACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITIES") %>'
                    ID_APPROVAL='<%# DataBinder.Eval(Container.DataItem, "ID_APPROVAL") %>' ValidationGroup="oGrid">Action</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Fields">
            <ItemTemplate>
               <asp:LinkButton ID="fieldDetailsLinkButton" runat="server" 
                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="viwFieldDetails" ForeColor="#003366" Font-Bold="True"
                    ID_ACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITIES") %>'
                    Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>' ToolTip="View activity details" ValidationGroup="oGrid"></asp:LinkButton>     
            </ItemTemplate>
        </asp:TemplateField>
                                        
        <asp:TemplateField HeaderText="Activity ID">
            <ItemTemplate>
                <asp:Label ID="labelActivityID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIVITYID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Task">
            <ItemTemplate>
                <asp:Label ID="labelTask" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TASK_DESCRIPTION") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Initiator">
            <ItemTemplate>
                <asp:Label ID="labelInitiator" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FULLNAME") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Date From">
            <ItemTemplate>
                <asp:Label ID="labelDateFrom" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DATE_FROM") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Date To">
            <ItemTemplate>
                <asp:Label ID="labelDateTo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DATE_TO") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Status">
            <ItemTemplate>
                <%--<asp:Label ID="labelStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>'></asp:Label>--%>
                <asp:LinkButton ID="statusLinkButton" runat="server" 
                    CommandArgument="<%# Container.DisplayIndex %>" CommandName="viwStatus" Font-Bold="True"
                    ID_ACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITIES") %>'
                    Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>' ToolTip="View Status" ValidationGroup="oGrid"></asp:LinkButton>  
            </ItemTemplate>
        </asp:TemplateField>
                                                     
    </Columns>
</asp:GridView>
<asp:Label ID="lblMssg" runat="server" ForeColor="Red"></asp:Label>
<br />
<asp:Panel ID="detailsPanel" runat="server">
    <uc2:fieldVisitInformation ID="fieldVisitInformation1" runat="server" />
    <uc2:FieldVisitQuestionaire ID="FieldVisitQuestionaire1" runat="server" />   
</asp:Panel>