<%@ Page Title="" Language="C#" MasterPageFile="~/CBIDashboard2.master" AutoEventWireup="true" CodeFile="Dashboard2.aspx.cs" Inherits="Dashboard2" %>

<%@ Register Src="App/PDCC/UserControl/Chartting.ascx" TagName="Chartting" TagPrefix="uc2" %>
<%@ Register Src="~/App/PDCC/UserControl/CharttingDataNT.ascx" TagPrefix="uc2" TagName="CharttingDataNT" %>
<%@ Register Src="~/App/PDCC/UserControl/PDPerformance.ascx" TagPrefix="uc2" TagName="PDPerformance" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Main content -->
    <section class="content">
        <!-- Small boxes (Stat box) -->
        <div class="row">
            <div style="margin-left: 0.6em; background-color: white; width: 98%">
                <uc2:Chartting ID="Chartting1" runat="server" />
            </div>
        </div>
        <!-- /.row -->
        <!-- Main row -->
        <div class="row" style="margin-left: auto; margin-right: auto; height:700px; width:100%; overflow:auto; margin-top: 0.5em;" >
            <asp:GridView ID="grdView" runat="server" AllowPaging="True"
                AutoGenerateColumns="False" OnLoad="grdView_Load"
                OnPageIndexChanging="grdView_PageIndexChanging"
                OnRowCommand="grdView_RowCommand" PageSize="15" Width="100%"
                OnSelectedIndexChanged="grdView_SelectedIndexChanged" OnRowDataBound="grdView_RowDataBound">
                <Columns>

                    <asp:TemplateField HeaderText="Summary Cost Reduction">
                        <ItemTemplate>
                            <div style="text-align:left">
                                <asp:Label ID="lbDepartment" runat="server" ForeColor="#000066" Font-Bold="true" Font-Size="100%"
                                IDDEPARTMENT='<%# DataBinder.Eval(Container.DataItem, "IDDEPARTMENT") %>'
                                Text='<%# DataBinder.Eval(Container.DataItem, "DEPARTMENT") %>'></asp:Label>
                            </div>
                            <uc2:CharttingDataNT runat="server" ID="CharttingData1" />
                            <br />
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                        <HeaderStyle BackColor="White" />
                        <%--<ControlStyle BackColor="#ffff99" Width="100%"  />--%>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
            <br />
            <uc2:PDPerformance runat="server" ID="PDPerformance" />
        </div>
    </section>
</asp:Content>

