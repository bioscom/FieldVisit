<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TechnicalIntegrity.ascx.cs" Inherits="App_PDR_UserControl_TechnicalIntegrity" %>

<asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowFooter="True" Width="100%">
    <Columns>

        <asp:TemplateField>
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>

        <%--<asp:TemplateField HeaderText="...">
            <ItemTemplate>
                <asp:LinkButton ID="editLinkButton" runat="server" CommandArgument="<%# Container.DisplayIndex %>" CommandName="EditThis"
                    OnClick="btnSelect_Click" IDHSSE='<%# DataBinder.Eval(Container.DataItem, "IDHSSE") %>'>Edit</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>--%>

        <asp:TemplateField HeaderText="Facilities">
            <ItemTemplate>
                <asp:Label ID="lbFacility" runat="server"
                    ID_FACILITIES='<%# DataBinder.Eval(Container.DataItem, "ID_FACILITIES") %>'
                    Text='<%# DataBinder.Eval(Container.DataItem, "FACILITIES") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
           
        <asp:TemplateField HeaderText="PM DUE" ItemStyle-BackColor="#ffffcc" HeaderStyle-BackColor="#ffffcc">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtPMDue" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PMDUE") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Completed" ItemStyle-BackColor="#ffffcc" HeaderStyle-BackColor="#ffffcc">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtPMCompleted" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PMCOMPLETED") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Complaint" ItemStyle-BackColor="#ffffcc" HeaderStyle-BackColor="#ffffcc">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtPMComplaint" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PMCOMPLAINT") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="%Complaint" ItemStyle-BackColor="#ffffcc" HeaderStyle-BackColor="#ffffcc">
            <ItemTemplate>
                <div style="text-align: center">
                    
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="SCE PM DUE" ItemStyle-BackColor="#ffccff" HeaderStyle-BackColor="#ffccff">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtSCEDue" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SCEPMDUE") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Completed" ItemStyle-BackColor="#ffccff" HeaderStyle-BackColor="#ffccff">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtSCECompleted" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SCEPMCOMPLETED") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Complaint" ItemStyle-BackColor="#ffccff" HeaderStyle-BackColor="#ffccff">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtSCEComplaint" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SCEPMCOMPLAINT") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="%Complaint" ItemStyle-BackColor="#ffccff" HeaderStyle-BackColor="#ffccff">
            <ItemTemplate>
                <div style="text-align: center">
                    
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="CM DUE" ItemStyle-BackColor="#ffffcc" HeaderStyle-BackColor="#ffffcc">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtCMDUE" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CMDUE") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Completed" ItemStyle-BackColor="#ffffcc" HeaderStyle-BackColor="#ffffcc">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtCMCompleted" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CMCOMPLETED") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Complaint" ItemStyle-BackColor="#ffffcc" HeaderStyle-BackColor="#ffffcc">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtCMComplaint" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CMCOMPLAINT") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="%Complaint" ItemStyle-BackColor="#ffffcc" HeaderStyle-BackColor="#ffffcc">
            <ItemTemplate>
                <div style="text-align: center">
                    
                </div>
            </ItemTemplate>
        </asp:TemplateField>       
    </Columns>
</asp:GridView>
<hr />
<asp:Button ID="txtSubmit" runat="server" Text="Save" OnClick="txtSubmit_Click" Width="100px" />
<asp:HiddenField ID="lReportIdHF" runat="server" />