<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BI500.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="App_BI500_Report_Default" %>

<%@ Register Src="../UserControl/WeeklyReport.ascx" TagName="WeeklyReport" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/MonthlyReport.ascx" TagPrefix="uc2" TagName="MonthlyReport" %>
<%@ Register Src="~/App/BI500/UserControl/YearlyReport.ascx" TagPrefix="uc2" TagName="YearlyReport" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div style="margin: 0.5em 1.0em 0em 2.0em">
        <asp:Button ID="btnWeekly" runat="server" Text="Weekly Report" OnClick="btnWeekly_Click" ValidationGroup="Wkly" />
        | <asp:Button ID="btnMonthly" runat="server" Text="Monthly Report" OnClick="btnMonthly_Click" ValidationGroup="mntly" />
        | <asp:Button ID="btnYearly" runat="server" Text="Yearly Report" OnClick="btnYearly_Click" ValidationGroup="yrly" />
        <br />
        <asp:MultiView ID="FormMultiView" runat="server" ActiveViewIndex="0">
            <asp:View ID="WeeklyReportTab" runat="server">
                <div style="width: 100%">
                    <uc2:WeeklyReport ID="WeeklyReport1" runat="server" />
                </div>
            </asp:View>
            <asp:View ID="MonthlyReportTab" runat="server">
                <div style="width: 100%">
                    <uc2:MonthlyReport runat="server" ID="MonthlyReport" />
                </div>
            </asp:View>
            <asp:View ID="YearlyReportTab" runat="server">
                <div style="width: 100%">
                    <uc2:YearlyReport runat="server" ID="YearlyReport1" />
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>

