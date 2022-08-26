<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/14DayContract.master" AutoEventWireup="true" CodeFile="Contracts.aspx.cs" Inherits="App_Contract_Contracts" %>

<%@ Register src="UserControls/OngoingContracts.ascx" tagname="OngoingContracts" tagprefix="uc2" %>

<%@ Register src="UserControls/ApprovedContracts.ascx" tagname="ApprovedContracts" tagprefix="uc3" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentContentPlaceHolder" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <div style="color: Black; float: left; width: 98%">
        <asp:UpdatePanel ID="uppAjaxBloc" runat="server">
            <ContentTemplate>
                <ajaxToolkit:TabContainer runat="server" ID="smtAjaxTabs" Width="100%" ActiveTabIndex="0">
                    <ajaxToolkit:TabPanel runat="server" ID="pnlOngoing" HeaderText="Ongoing 14 Days Contracts" Width="100%" Visible="true">
                        <HeaderTemplate>Ongoing 14 Days Contracts</HeaderTemplate>
                        <ContentTemplate>
                            <div>
                                
                                <uc2:OngoingContracts ID="OngoingContracts1" runat="server" />
                                
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel runat="server" ID="pnlAproved" HeaderText="Approved 14 Days Contracts" Width="100%" Visible="true">
                        <HeaderTemplate>Approved 14 Days Contracts</HeaderTemplate>
                        <ContentTemplate>
                            
                            <uc3:ApprovedContracts ID="ApprovedContracts1" runat="server" />
                            
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                </ajaxToolkit:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Label runat="server" ID="CurrentTab" />
        <asp:Label runat="server" ID="Messages" />
    </div>
</asp:Content>

