<%@ Page Title="" Language="C#" MasterPageFile="~/CBIDashboard2.master" AutoEventWireup="true" CodeFile="PdccOnshore.aspx.cs" Inherits="PdccOnshore" %>

<%@ Register Src="App/PDCC/UserControl/Chartting.ascx" TagName="Chartting" TagPrefix="uc2" %>
<%@ Register Src="App/PDCC/UserControl/CharttingData.ascx" TagName="CharttingData" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 60%; margin-left: auto; margin-right: auto; margin-bottom:0.7em; margin-top:1.8em">
        <uc3:CharttingData ID="CharttingData1" runat="server" />
        <br />
        <uc2:Chartting ID="Chartting1" runat="server" />
    </div>
</asp:Content>

