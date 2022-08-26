<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WellTest.ascx.cs" Inherits="App_PDR_UserControl_WellTest" %>
 	
<asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" ShowFooter="True" Width="100%">
    <Columns>

        <asp:TemplateField>
            <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>

       <%-- <asp:TemplateField HeaderText="...">
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

        <asp:TemplateField HeaderText="Wells on Program">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtWellsOnProgramm" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WELLONPROGRAM") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="No. of Wells Flowing at start of Month">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtNoOfWells" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WELLSFLOWINGSTART") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Current No. of Wells flowing">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtCurrNoOfWells" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WELLSFLOWINGCURRENT") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Cummulative Wells Tested">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtCummulativeWells" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CUMMWELLTESTED") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="% of Wells Tested">
            <ItemTemplate>
                <div style="text-align: center">
                    
                </div>
            </ItemTemplate>
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="No. of Wells Sampled">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtWellsSampled" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WELLSAMPLED") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="% of Wells Sampled">
            <ItemTemplate>
                <div style="text-align: center">
                    
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="MER Plan">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtMERPlan" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MERPLAN") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="MER Actual">
            <ItemTemplate>
                <div style="text-align: center">
                    <asp:TextBox ID="txtMERActual" Width="30px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MERACTUAL") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="MER Outstanding">
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