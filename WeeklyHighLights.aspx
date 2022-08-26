<%@ Page Title="" Language="C#" MasterPageFile="~/CBIDashboard2.master" AutoEventWireup="true" CodeFile="WeeklyHighLights.aspx.cs" Inherits="WeeklyHighLights" %>

<%@ Register Src="~/UserControls/WeeklyHighLight.ascx" TagPrefix="uc2" TagName="WeeklyHighLight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div style="margin-left: auto; margin-right: auto; color: Black; margin-top: 3.0em; margin-bottom: auto; width:800px">
            <uc2:WeeklyHighLight runat="server" ID="WeeklyHighLight" />
        </div>
    </div>
</asp:Content>

