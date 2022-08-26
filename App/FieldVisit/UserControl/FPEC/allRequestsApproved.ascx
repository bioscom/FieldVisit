<%@ Control Language="C#" AutoEventWireup="true" CodeFile="allRequestsApproved.ascx.cs" Inherits="UserControl_allRequestsApproved" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:DropDownList ID="ddlAsset" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAsset_SelectedIndexChanged" Width="200px">
        <asp:ListItem Value="-1">--Select Asset--</asp:ListItem>
</asp:DropDownList>

    &nbsp;

<asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Width="200px">
        <asp:ListItem Value="-1">--Select District--</asp:ListItem>
</asp:DropDownList>

    &nbsp;
    <asp:DropDownList ID="ddlFieldsApproved" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFieldsApproved_SelectedIndexChanged" Width="200px">
        <asp:ListItem Value="-1">--Select Facility--</asp:ListItem>
</asp:DropDownList>
&nbsp;<asp:DropDownList ID="ddlFieldsNotApproved" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFieldsNotApproved_SelectedIndexChanged" Width="200px">
        <asp:ListItem Value="-1">--Select Facility--</asp:ListItem>
</asp:DropDownList>
&nbsp;<asp:DropDownList ID="ddlFieldsRescheduled" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFieldsRescheduled_SelectedIndexChanged" Width="200px">
        <asp:ListItem Value="-1">--Select Facility--</asp:ListItem>
</asp:DropDownList>
&nbsp;<asp:Button ID="btnList" runat="server" OnClick="btnList_Click" Text="List..." />
<hr />
    <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" onpageindexchanging="grdView_PageIndexChanging" onrowcommand="grdView_RowCommand" Width="100%" AllowPaging="True" PageSize="40">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                   <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
                                
            <asp:TemplateField HeaderText="Fields">
                <ItemTemplate>
                   <asp:LinkButton ID="fieldDetailsLinkButton" runat="server" 
                        CommandArgument="<%# Container.DisplayIndex %>" CommandName="viwFieldDetails" ForeColor="#003366" Font-Bold="True"
                        ID_ACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITIES") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>' ToolTip="View activity details"></asp:LinkButton>     
                </ItemTemplate>
            </asp:TemplateField>
                                            
            <asp:TemplateField HeaderText="Activity ID">
                <ItemTemplate>
                    <asp:Label ID="labelActivityID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACTIVITYID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Account to charge">
                <ItemTemplate>
                    <asp:Label ID="labelAccountToCharge" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ACCOUNT") %>'></asp:Label>
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
                        Text='<%# DataBinder.Eval(Container.DataItem, "STATUS") %>' ToolTip="View Status"></asp:LinkButton>  
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="...">
            <ItemTemplate>
                <asp:LinkButton ID="reportLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>"
                    CommandName="report" ID_ACTIVITIES='<%# DataBinder.Eval(Container.DataItem, "ID_ACTIVITIES") %>'
                    ValidationGroup="gridVal">Report</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
                                                         
        </Columns>
    </asp:GridView>
       