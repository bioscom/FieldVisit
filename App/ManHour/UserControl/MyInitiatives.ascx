<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyInitiatives.ascx.cs" Inherits="UserControl_MyInitiatives" %>
<div style="width: 270px">
    <asp:Button ID="btnNewInitiative" runat="server" Text="Create New Project" Width="270px" OnClick="btnNewInitiative_Click" ValidationGroup="None" />
    <br />
    <div style="float: left">
        <asp:TextBox ID="txtFilter" Height="16px" runat="server" Width="230px"></asp:TextBox>
    </div>
    <div style="float: left">
        <asp:ImageButton ID="ImageButton1" runat="server" Height="20px" Width="25px" ImageUrl="~/Images/gosearch.gif" />
    </div>

<%--</div>
<div style="width: 250px; margin-bottom: 0.5em">--%>
    <ajaxToolkit:TabContainer runat="server" ID="itemsPnlTabs" Width="100%" ActiveTabIndex="0">

        <ajaxToolkit:TabPanel runat="server" ID="pnlAwaiting" HeaderText="Awaiting Approval" Width="98%" Visible="true">
            <HeaderTemplate>Pending</HeaderTemplate>
            <ContentTemplate>
                <br />
                <asp:ListBox ID="MyPendingInitiativeListBox" runat="server" AutoPostBack="True" Font-Size="9pt"
                    Height="400px" OnSelectedIndexChanged="MyInitiativeListBox_SelectedIndexChanged" Width="250px"></asp:ListBox>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>

        <ajaxToolkit:TabPanel runat="server" ID="pnlApproved" HeaderText="Approved" Width="98%" Visible="true">
            <HeaderTemplate>Approved</HeaderTemplate>
            <ContentTemplate>
                <br />
                <asp:ListBox ID="MyApprovedInitiativeListBox" runat="server" AutoPostBack="True"
                    Height="400px" OnSelectedIndexChanged="MyApprovedInitiativeListBox_SelectedIndexChanged" Width="250px"></asp:ListBox>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>

        <ajaxToolkit:TabPanel runat="server" ID="pnlNotApproved" HeaderText="Not Approval" Width="98%" Visible="true">
            <HeaderTemplate>Rejected</HeaderTemplate>
            <ContentTemplate>
                <br />
                <asp:ListBox ID="NotApprovedInitiativeListBox" runat="server" AutoPostBack="True"
                    Height="400px" OnSelectedIndexChanged="NotApprovedInitiativeListBox_SelectedIndexChanged" Width="250px"></asp:ListBox>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>

    </ajaxToolkit:TabContainer>
</div>
