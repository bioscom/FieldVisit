<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Report.ascx.cs" Inherits="App_BI500_UserControl_Report" %>

<asp:MultiView ID="FormMultiView" runat="server" ActiveViewIndex="0">
    <asp:View ID="WeeklyReportTab" runat="server">
        <div style="width: 100%">
        </div>
    </asp:View>
    <asp:View ID="MonthlyReportTab" runat="server">
        <div style="width: 100%">
        </div>
    </asp:View>
    <asp:View ID="YearlyReportTab" runat="server">
        <div style="width: 100%">
        </div>
    </asp:View>
</asp:MultiView>