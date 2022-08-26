<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PDCC.master" AutoEventWireup="true" CodeFile="PDSummaryCostReductionList.aspx.cs" Inherits="App_PDCC_PDSummaryCostReductionList" %>

<%@ Register Src="~/App/PDCC/UserControl/PDSummaryCostRedn.ascx" TagPrefix="app" TagName="PDSummaryCostRedn" %>


<%--<asp:Content ID="Content1" ContentPlaceHolderID="headId" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuContentContentPlaceHolder" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <asp:Label runat="server" id="lblTitle" Text="Summary Cost Reduction" Font-Bold="true" Font-Size="120%"></asp:Label>
     <hr />
    <asp:GridView ID="grdView" runat="server" AllowPaging="True" RowStyle-BackColor="White"
        AutoGenerateColumns="False" PageSize="15" Width="100%" ShowHeader="false">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <br />
                    <div style="text-align: left;">
                        <asp:Label ID="lbService" runat="server" ForeColor="#000066" Font-Bold="true" Font-Size="100%"
                            IDSERVICE='<%# DataBinder.Eval(Container.DataItem, "IDSERVICE") %>' 
                            Text='<%# DataBinder.Eval(Container.DataItem, "SERVICE") %>'></asp:Label>
                    </div>
                    <br />
                    <app:PDSummaryCostRedn runat="server" ID="PDSummaryCostRednT" />
                    <br />
                </ItemTemplate>
                <ItemStyle Width="100px" />
                <HeaderStyle BackColor="White" Font-Size="Large" BorderStyle="Solid" HorizontalAlign="Left" />
                
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
    <app:PDSummaryCostRedn runat="server" ID="PDPerformance" />
    <br /><br />
    <app:PDSummaryCostRedn runat="server" ID="PDCostSummary" />

</asp:Content>

